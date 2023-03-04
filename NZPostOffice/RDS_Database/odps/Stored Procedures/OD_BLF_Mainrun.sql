
CREATE PROCEDURE [odps].[OD_BLF_Mainrun](
    @incontract_no       int,
    @inContractor_No     int,
    @inPayPeriod_Start   datetime,
    @inPayPeriod_End     datetime,
    @inRenewalGroup      int = 0)
AS
BEGIN
  set NoCount on   -- TJB May-2019  recommended to improve performance (slightly)
-- TJB  RPCR_139 Bugfix July-2019
-- Replaced ContractorEnd in vc_contract_list1 cursor, 
-- wih method from vc_contract_list cursor
--
-- TJB  RPCR_141  June-2019
-- Added @inRenewalGroup parameter.  Modified vc_contract_list1 cursor to allow 
-- @inContractor_no, @inContract_no, and/or @inRenewalGroup to be specified.
-- Consolidated duplicate logic.
--
-- TJB  RPCR_139  May-2019
-- Replaced subquery in cursor definitions with getContractorEnd() fuction
--
-- TJB  RPCR_054  Apr-2013
-- Changes to Piece Rate calculation.
-- See OD_BLF_Mainrun_Grosspay (v2) and OD_BLF_Mainrun_Grosspay_Piecerates (v2)
-- This routine essentially unchanged (comments and some formatting).
--
-- TJB  Aug-2009  Payrun issue
-- Changed returned code to distinguish it from witholdingtax error
--
-- TJB  13-May-2009
-- Fixed date formatting
--
-- TJB  RD7_0016  Jan 2009
-- Status returned to C# app via result set (not return code!).  Return codes as varchar.
-- Create temporary table to get error message from PostTaxAdj and return in result set.
-- Note change: only OD_BLF_MainRun begins and commits/rollsback transaction(s).
--
-- TJB  14-July-2008
-- Payrun duplicate results bug fix: 
-- Explicitly empty the t_payment table because the cascading delete from
--     deleting rows from the t_payment_runs table doesn't seem to work
--
-- TJB  SR4649  Dec-2004
-- Changed return value to string to return error information from OD_BLF_Mainrun_PostTaxAdj
-- Caught and parsed by Powerbuilder Payrun code (w_payrun_search)
-- When there''s an error, the string is a comma-separated list of values:
--      <return code>, <contractor no>, <deduction ID>, <deduction description>
-- otherwise its just a single value (the return code).
--
  set implicit_transactions on

  declare @v_contract_no int,
          @v_sequence_no int,
          @v_contractor_no int,
          @v_contractor_start datetime,
          @v_contractor_contract_start datetime,
          @v_contractor_end datetime,
          @v_renewal_start datetime,
          @v_renewal_end datetime,
          @v_grossresult int,
          @v_run_number int,
          @v_numloops int,
          @v_tempdate datetime,
          @v_termdate datetime,
          @v_temp_int int,
          @v_temp_int1 int, -- tjb SR4649
          @v_temp_string varchar(254), -- tjb SR4649
          @errmsg varchar(254)
  
  declare @mode int   -- TJB RPCR_141
          
  -- TJB RD7_0016  Jan 2009
  --     Currently this is only used by OD_BLF_PostTaxAdj
  CREATE TABLE #tmp_blf_error_message
    (
            msg_proc   varchar(63),
            msg_date   datetime,
            msg_text   varchar(255)
    )

----------------------------------- Define cursors ---------------------------------
  -- This cursor is for all contracts/contractors - original, @inRenewalGroup not referenced
  --           (@inContract_no = 0, @inContractor_no = 0, @inRenewalGroup = 0)
  declare vc_contract_list 
      cursor for 
          select contract.contract_no,
                 contractor_renewals.contract_seq_number,
                 contractor_renewals.contractor_supplier_no,
                 contractor_renewals.cr_effective_date,
                 -- TJB  RPCR_139  May-2019
                 -- Replaced subquery with getContractorEnd() fuction
                 rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no)
                                                                                  as getContractorEnd,
               --  (select dateadd(day,-1,min(cr.cr_effective_date)) 
               --     from rd.contractor_renewals as cr 
               --    where cr.contract_no = contract_renewals.contract_no and
               --          cr.contract_seq_number = contract_renewals.contract_seq_number and
               --          cr.cr_effective_date > contractor_renewals.cr_effective_date),
                 contract_renewals.con_start_date,
                 contract_renewals.con_expiry_date,
                 contract.con_date_terminated 
            from rd.contract_renewals,
                 rd.contractor_renewals,
                 rd.contract 
           where contractor_renewals.contract_no = contract_renewals.contract_no
             and contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number
             and contract.contract_no = contract_renewals.contract_no
             and contract_renewals.contract_seq_number = rd.maxSeqContractor(contract.contract_no,contractor_renewals.contractor_supplier_no)
             and rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) >= dateadd(month,-2,@inPayPeriod_End)
             and contract_renewals.con_start_date <= @inPayPeriod_End
             and (contract.con_date_terminated is null 
                   or contract.con_date_terminated > @inPayPeriod_End 
                      --PP or datediff(day,@inPayPeriod_Start,contract.con_date_terminated) < 63 
                   or datediff(day, contract.con_date_terminated, @inPayPeriod_Start) < 63 
                   or contract.con_date_terminated between @inPayPeriod_Start and @inPayPeriod_End) 
           order by contract.contract_no asc,
                    contractor_renewals.contract_seq_number asc,
                    contractor_renewals.cr_effective_date asc

  -- and(contract.con_active_sequence=contract_renewals.contract_seq_number)
  -- TWC 12/08/2003 - call 4544
  -- TWC 01/09/2003 - call 4557

  -- This cursor is for a single contract/contractor (@inContract_no/@inContractor_no)
  -- TJB RPCR_141 Modified to allow @inContract_no, @inContractor_no and/or @inRenewalGroup to be specified
  declare vc_contract_list1 
      cursor for 
          select contract.contract_no,
                 contractor_renewals.contract_seq_number,
                 contractor_renewals.contractor_supplier_no,
                 contractor_renewals.cr_effective_date,
                 -- TJB  RPCR_139  May-2019
                 -- Replaced subquery with getContractorEnd() fuction
                 -- TJB  RPCR_139 July-2019 bugfix
                 -- Replaced ContractorEnd wih method from vc_contract_list cursor (above)
                 --rd.getContractorEnd(@inContract_no,@inContractor_no),
                 rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no)
                                                                                  as getContractorEnd,
              --   (select dateadd(day,-1,min(cr.cr_effective_date)) 
              --      from rd.contractor_renewals as cr 
              --     where cr.contract_no = contract_renewals.contract_no and
              --           cr.contract_seq_number = contract_renewals.contract_seq_number and
              --           cr.cr_effective_date > contractor_renewals.cr_effective_date),
                 contract_renewals.con_start_date,
                 contract_renewals.con_expiry_date,
                 contract.con_date_terminated 
            from rd.contract_renewals,
                 rd.contractor_renewals,
                 rd.contract 
           where (@inContract_No = 0 or contract_renewals.contract_no = @inContract_No)
             and (@inContractor_No = 0 or contractor_renewals.contractor_supplier_no = @inContractor_No)
             and (@inRenewalGroup = 0 or [contract].rg_code = @inRenewalGroup)
             and contractor_renewals.contract_no = contract_renewals.contract_no
             and contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number
             and contract.contract_no = contract_renewals.contract_no
             and contract_renewals.contract_seq_number = rd.maxSeqContractor(contract.contract_no,contractor_renewals.contractor_supplier_no)
             and rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) >= dateadd(month,-2,@inPayPeriod_Start)
             and contract_renewals.con_start_date <= @inPayPeriod_End
             and (contract.con_date_terminated is null 
                   or contract.con_date_terminated > @inPayPeriod_End 
                      --PP or datediff(day,@inPayPeriod_Start,contract.con_date_terminated) < 63 
                   or datediff(day, contract.con_date_terminated, @inPayPeriod_Start) < 63 
                   or contract.con_date_terminated between @inPayPeriod_Start and @inPayPeriod_End) 
           order by contract.contract_no asc,
                    contractor_renewals.contract_seq_number asc,
                    contractor_renewals.cr_effective_date asc  
--------------------------------------------------------------------------------------------------

  -- TJB  RPCR_141 July-2019 bugfix
  -- Ensure the contract, contractor and renewal group and not null
  if (@inContract_No is null) set @inContract_No = 0
  if (@inContractor_No is null) set @inContractor_No = 0
  if (@inRenewalGroup is null) set @inRenewalGroup = 0
  -- Ignore the renewal group if a specific contractor or contract has been selected
  if (@inContractor_No > 0 or @inContract_No > 0)
      set @inRenewalGroup = 0
  
  select @v_numloops   = 0
  select @v_run_number = 1 

  if @v_run_number = -1 or @@error < 0
  begin
      rollback transaction
      set implicit_transactions off
      select '-1'
      return '-1'
  end

  delete from odps.t_payment_runs

  if @@error <> 0 
  begin
      rollback transaction
      set implicit_transactions off
      select convert(varchar,@@error)
      return convert(varchar,@@error)
  end

  delete from odps.t_piecerate_tracker

  if @@error <> 0 
  begin
      rollback transaction
      set implicit_transactions off
      select convert(varchar,@@error)
      return convert(varchar,@@error)
  end
  
  -- *********** Added TJB  14-July-2008 *********** --
  -- Payrun duplicate results bug fix 
  -- Explicitly empty the t_payment table because the cascading delete from
  --     deleting rows from the t_payment_runs table doesn''t seem to work
    
  delete from odps.t_payment;
  
  if @@error <> 0 
  begin
      rollback transaction
      set implicit_transactions off
      select convert(varchar,@@error)
      return convert(varchar,@@error)
  end
  -- ********************************************** --

  commit transaction
 
  DBCC CHECKIDENT ('odps.t_payment_runs', RESEED, 0)
  DBCC CHECKIDENT ('odps.t_payment', RESEED, 0)
  DBCC CHECKIDENT ('odps.t_payment_component',reseed,0)

  -- TJB  13-May-2009  Fixed date formating
  -- Changed case when len(month(@inPayPeriod_End)) to case when len(day(@inPayPeriod_End))
  
  insert into odps.t_payment_runs(/*pr_id,*/  --!Cannot insert explicit value for identity column
      pr_date,
      gl_posted,
      pr_ap_posted,
      pr_contract_no) 
  values( /*@v_run_number,*/ 
      (convert(varchar,YEAR(@inPayPeriod_End))  -- @inPayPeriod_End as yyyymmdd string
        +(case when len(month(@inPayPeriod_End))= 1 
               then '0' 
               else '' 
          end)
        +convert(varchar,month(@inPayPeriod_End))
        +(case when len(day(@inPayPeriod_End))= 1 
               then '0' 
               else '' 
          end)
        +convert(varchar,day(@inPayPeriod_End)))
    , 'N'
    , 'N'
    , @inContract_no)

  if @@error <> 0
  begin
      rollback transaction
      set implicit_transactions off
      select '-2'
      return '-2'
  end

  -- TJB  RPCR_141: Determine which cursor to use
  set @mode = 2
  if (@inContract_no = 0 and @inContractor_no = 0 and @inRenewalGroup = 0)
  begin
      set @mode = 1
  end
  
  -- TJB RPCR_141:  Consolidated duplicate code by using this loop for both
  --                cursors.  Which cursor to open/fetch determined by @mode.
  begin
      if @mode = 0
      begin
          open vc_contract_list
          if @@error <> 0
          begin
              rollback transaction
              set implicit_transactions off
              select '-3'
              return '-3'
          end
      end
      else  -- @mode = 1
      begin
          open vc_contract_list1
          if @@error<>0
          begin
              rollback transaction
              set implicit_transactions off
              select '-7'
              return '-7'
          end
      end

      while 1=1 
      begin
          if @mode = 0
          begin
              fetch next from vc_contract_list into 
                @v_contract_no,
                @v_sequence_no,
                @v_contractor_no,
                @v_contractor_start,
                @v_contractor_end,
                @v_renewal_start,
                @v_renewal_end,
                @v_termdate

              if @@error <>0
              begin
                  rollback transaction
                  set implicit_transactions off
                  select '-4'
                  return '-4'
              end
          end
          else   -- @mode = 1
          begin
              fetch next from vc_contract_list1 into @v_contract_no,
                @v_sequence_no,
                @v_contractor_no,
                @v_contractor_start,
                @v_contractor_end,
                @v_renewal_start,
                @v_renewal_end,
                @v_termdate

              if @@fetch_status = -2
              begin
                  rollback transaction
                  set implicit_transactions off
                  select '-8'
                  return '-8'
              end
          end

          if @@fetch_status <0
              break

          select @v_contractor_contract_start=@v_contractor_start

          select @v_temp_int = count(payment.contractor_supplier_no)
            from odps.payment 
           where (payment.contractor_supplier_no = @v_contractor_no) and
                 (payment.invoice_date between @inPayPeriod_Start and @inPayPeriod_End) and
                 (payment.contract_no = @v_contract_no)
                 
          if @@error <> 0 
          begin
              rollback transaction
              set implicit_transactions off
              select '-20'
              return '-20'
          end

        if @v_temp_int <= 0
            if (@v_contractor_end is null 
                  or @v_contractor_end >= @inPayPeriod_Start 
                     --PP or datediff(day,@v_contractor_end,@inPayPeriod_Start) < 63)
                  or datediff(day, @inPayPeriod_Start, @v_contractor_end) < 63)
               and @v_contractor_start <= @inPayPeriod_End
            begin
                if @v_contractor_start <= @inPayPeriod_Start
                    select @v_contractor_start=@inPayPeriod_Start

                if @v_contractor_end is null or @v_contractor_end >= @inPayPeriod_End
                    select @v_contractor_end=@inPayPeriod_End

                if @v_termdate < @v_contractor_end
                    select @v_contractor_end=@v_termdate

                exec @v_grossresult = odps.od_blf_mainrun_grosspay
                                                  @v_contract_no
                                                 ,@v_sequence_no
                                                 ,@v_contractor_no
                                                 ,@v_contractor_start
                                                 ,@v_contractor_end
                                                 ,@inPayPeriod_Start
                                                 ,@inPayPeriod_End
                                                 ,@v_run_number
                                                 ,@v_renewal_start
                                                 ,@v_renewal_end
                                                 ,@v_contractor_contract_start

                if @v_grossresult < -100000000
                begin
                    rollback transaction
                    set implicit_transactions off
                    select convert(varchar,@v_grossresult)
                    return convert(varchar,@v_grossresult)
                end

                if @@error <> 0 
                begin
                    rollback transaction
                    set implicit_transactions off
                    select convert(varchar,@@error)
                    return convert(varchar,@@error)
                end

                select @v_numloops=@v_numloops+1
          end
      end  --end of while 

      if @@error <> 0
      begin
          rollback transaction
          set implicit_transactions off
          select '-6'
          return '-6'
      end
  end
/********************* TJB RPCR_141: Begin duplicate code removed *********************
  else
  begin
      open vc_contract_list1
      if @@error<>0
      begin
          rollback transaction
          set implicit_transactions off
          select '-7'
          return '-7'
      end

      while 1=1 
      begin
          fetch next from vc_contract_list1 into @v_contract_no,
            @v_sequence_no,
            @v_contractor_no,
            @v_contractor_start,
            @v_contractor_end,
            @v_renewal_start,
            @v_renewal_end,
            @v_termdate

          if @@fetch_status = -2
          begin
              rollback transaction
              set implicit_transactions off
              select '-8'
              return '-8'
          end

          if @@fetch_status <0
              break

          select @v_contractor_contract_start=@v_contractor_start

          if (@v_contractor_end is null 
               or @v_contractor_end >= @inPayPeriod_Start 
               or datediff(day, @inPayPeriod_Start, @v_contractor_end) < 63) and 
             @v_contractor_start <= @inPayPeriod_End
          begin
              if @v_contractor_start <= @inPayPeriod_Start
                  select @v_contractor_start=@inPayPeriod_Start

              if @v_contractor_end is null or @v_contractor_end >= @inPayPeriod_End
                  select @v_contractor_end=@inPayPeriod_End

              if @v_termdate < @v_contractor_end
                  select @v_contractor_end=@v_termdate

              execute @v_grossresult = odps.od_blf_mainrun_grosspay 
                                                @v_contract_no
                                               ,@v_sequence_no
                                               ,@v_contractor_no
                                               ,@v_contractor_start
                                               ,@v_contractor_end
                                               ,@inPayPeriod_Start
                                               ,@inPayPeriod_End
                                               ,@v_run_number
                                               ,@v_renewal_start
                                               ,@v_renewal_end
                                               ,@v_contractor_contract_start
             
              if @v_grossresult < -100000000
              begin
                  rollback transaction
                  set implicit_transactions off
                  select convert(varchar,@v_grossresult)
                  return convert(varchar,@v_grossresult)
              end

              if @@error <> 0
              begin
                  rollback transaction
                  set implicit_transactions off
                  select convert(varchar,@@error)
                  return convert(varchar,@@error)
              end

              select @v_numloops = @v_numloops + 1
          end
      end

      if @@error <> 0
      begin
          rollback transaction
          set implicit_transactions off
          select '-10'
          return '-10'
      end
  end
********************* TJB RPCR_141: End repeated code removed *********************/

  execute @v_temp_int = odps.OD_BLF_Mainrun_WithHoldingTax 

  if @@error <> 0 or @v_temp_int <> 0
  begin
      rollback transaction
      set implicit_transactions off
      select '-13'
      return '-13'
  end

  execute @v_temp_int = odps.OD_BLF_Mainrun_GST
  
  if @@error <> 0 or @v_temp_int <> 0
  begin
      rollback transaction
      set implicit_transactions off
      select '-12'
      return '-12'
  end

  -- tjb  sr4649   Changed to trap error info from PostTaxAdj and pass it on
  --  select OD_BLF_Mainrun_PostTaxAdj( inPayPeriod_Start, inPayPeriod_End) 
  --    into v_temp_int 
  --    from sys.dummy;
  --  if sqlcode<>0 or (v_temp_int<0 and v_temp_int>-500) then
  --    rollback work;
  --    return '-12';
  --  end if;

  -- tjb RD7_0016 Jan 2008
  --     @v_temp_string is only the return code.  If -1, error message will be in #tmp_blf_error_message.
  
  execute @v_temp_string = odps.OD_BLF_Mainrun_PostTaxAdj @inPayPeriod_Start,@inPayPeriod_End

  select @v_temp_int=convert(int,@v_temp_string);
  
      -- If PostTaxAdj returns -1, get error message from #tmp_blf_error_message
      -- and return it as the result set. 
      -- The message includes the "-1" as the first element.
  if @v_temp_int = -1
  begin
       select @v_temp_string = (select msg_text from #tmp_blf_error_message
                                 where msg_proc = 'OD_BLF_Mainrun_PostTaxAdj')
  
      rollback transaction
      set implicit_transactions off
      select @v_temp_string
      return '-1'
  end
  
  -- TJB Aug2009 Payrun issue
  -- Changed returned code to distinguish it from witholdingtax error
  if @@error <> 0 or @v_temp_int < -1
  begin
      rollback transaction
      set implicit_transactions off
      select '-13'
      return '-13'
  end
  
  commit transaction

  if @@error <> 0 
  begin
      set implicit_transactions off
      select '-15'
      return '-15'
  end

  select convert(varchar,@v_numloops)

  set implicit_transactions off

END