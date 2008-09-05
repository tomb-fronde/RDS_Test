/****** Object:  StoredProcedure [odps].[OD_BLF_Mainrun]    Script Date: 08/05/2008 10:13:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [odps].[OD_BLF_Mainrun](
    @incontract_no       int,
    @inContractor_No     int,
    @inPayPeriod_Start   datetime,
    @inPayPeriod_End     datetime)
--
-- TJB  14-July-2008
-- Payrun duplicate results bug fix: 
-- Explicitly empty the t_payment table because the cascading delete from
--     deleting rows from the t_payment_runs table doesn't seem to work
--
-- TJB  SR4649  Dec 2004
-- Changed return value to string to return error information from OD_BLF_Mainrun_PostTaxAdj
-- Caught and parsed by Powerbuilder Payrun code (w_payrun_search)
-- When there''s an error, the string is a comma-separated list of values:
--      <return code>, <contractor no>, <deduction ID>, <deduction description>
-- otherwise its just a single value (the return code).
as -- returns integer
begin
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
          @v_temp_string char(254), -- tjb SR4649
          @errmsg char(254)
          
  -- TWC - 12/08/2003 call 4544
  -- and(contract.con_active_sequence=contract_renewals.contract_seq_number)
  -- TWC - 01/09/2003 call 4557 
  declare vc_contract_list cursor for select contract.contract_no,
          contractor_renewals.contract_seq_number,
          contractor_renewals.contractor_supplier_no,
          contractor_renewals.cr_effective_date,
          (select dateadd(day,-1,min(cr.cr_effective_date)) 
             from rd.contractor_renewals as cr 
            where cr.contract_no = contract_renewals.contract_no and
                  cr.contract_seq_number = contract_renewals.contract_seq_number and
                  cr.cr_effective_date > contractor_renewals.cr_effective_date),
          contract_renewals.con_start_date,
          contract_renewals.con_expiry_date,
          contract.con_date_terminated 
     from rd.contract_renewals,
          rd.contractor_renewals,
          rd.contract 
    where (contractor_renewals.contract_no = contract_renewals.contract_no) and
          (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
          (contract.contract_no = contract_renewals.contract_no) and
          (contract_renewals.contract_seq_number = rd.maxSeqContractor(contract.contract_no,contractor_renewals.contractor_supplier_no)) and
          (rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) >= dateadd(month,-2,@inPayPeriod_End)) and
          (contract_renewals.con_start_date <= @inPayPeriod_End) and
          (contract.con_date_terminated is null 
            or contract.con_date_terminated > @inPayPeriod_End 
               --PP or datediff(day,@inPayPeriod_Start,contract.con_date_terminated) < 63 
            or datediff(day, contract.con_date_terminated, @inPayPeriod_Start) < 63 
            or contract.con_date_terminated between @inPayPeriod_Start and @inPayPeriod_End) 
    order by contract.contract_no asc,
             contractor_renewals.contract_seq_number asc,
             contractor_renewals.cr_effective_date asc

  -- and(contract.con_active_sequence=contract_renewals.contract_seq_number)
  -- TWC - 12/08/2003 - call 4544
  -- TWC 01/09/2003 - call 4557
  declare vc_contract_list1 cursor for select  contract.contract_no,
          contractor_renewals.contract_seq_number,
          contractor_renewals.contractor_supplier_no,
          contractor_renewals.cr_effective_date,
          (select dateadd(day,-1,min(cr.cr_effective_date)) 
             from rd.contractor_renewals as cr 
            where cr.contract_no = contract_renewals.contract_no and
                  cr.contract_seq_number = contract_renewals.contract_seq_number and
                  cr.cr_effective_date > contractor_renewals.cr_effective_date),
          contract_renewals.con_start_date,
          contract_renewals.con_expiry_date,
          contract.con_date_terminated 
     from rd.contract_renewals,
          rd.contractor_renewals,
          rd.contract 
    where (contract_renewals.contract_no = @inContract_no) and
          (contractor_renewals.contractor_supplier_no = @inContractor_No) and
          (contractor_renewals.contract_no = contract_renewals.contract_no) and
          (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
          (contract.contract_no = contract_renewals.contract_no) and
          (contract_renewals.contract_seq_number = rd.maxSeqContractor(contract.contract_no,contractor_renewals.contractor_supplier_no)) and
          (rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) >= dateadd(month,-2,@inPayPeriod_Start)) and
          (contract_renewals.con_start_date <= @inPayPeriod_End) and
          (contract.con_date_terminated is null 
            or contract.con_date_terminated > @inPayPeriod_End 
               --PP or datediff(day,@inPayPeriod_Start,contract.con_date_terminated) < 63 
            or datediff(day, contract.con_date_terminated, @inPayPeriod_Start) < 63 
            or contract.con_date_terminated between @inPayPeriod_Start and @inPayPeriod_End) 
    order by contract.contract_no asc,
             contractor_renewals.contract_seq_number asc,
             contractor_renewals.cr_effective_date asc  

  select @v_numloops=0
  select @v_run_number = 1 

  if @v_run_number = -1 or @@error < 0
  begin
      rollback transaction
      select '-1'
      set implicit_transactions off
      return '-1'
  end

  delete from t_payment_runs

  if @@error <> 0 /* <> was < */
  begin
      rollback transaction
      select convert(char(254),@@error)
      set implicit_transactions off
      return convert(char(254),@@error)
  end

  delete from t_piecerate_tracker

  if @@error <> 0 /* <> was < */
  begin
      rollback transaction
      select convert(char(254),@@error)
      set implicit_transactions off
      return convert(char(254),@@error)
  end
  
  -- *********** Added TJB  14-July-2008 *********** --
  -- Payrun duplicate results bug fix 
  -- Explicitly empty the t_payment table because the cascading delete from
  --     deleting rows from the t_payment_runs table doesn't seem to work
  --  
  --  delete from t_payment;
  --  
  --  if @@error <> 0 /* <> was < */
  --  begin
  --      rollback transaction
  --      select convert(char(254),@@error)
  --      set implicit_transactions off
  --      return convert(char(254),@@error)
  --  end
  -- ********************************************** --

  commit transaction
 
 /*jlwang:set identity start from 0*/
  -- DBCC CHECKIDENT ('odps.t_payment_runs', RESEED, 0)
  DBCC CHECKIDENT ('odps.t_payment', RESEED, 0)
  DBCC CHECKIDENT ('odps.t_payment_component',reseed,0)
 /*jlwang:end*/

  insert into t_payment_runs(/*pr_id,*/  --!Cannot insert explicit value for identity column
      pr_date,
      gl_posted,
      pr_ap_posted,
      pr_contract_no) 
  values(
      /*@v_run_number,*/ 
      -- jlwang: convert(int,@inPayPeriod_End)
      (convert(varchar,YEAR(@inPayPeriod_End))
        +(case when len(month(@inPayPeriod_End))= 1 
               then '0' 
               else '' 
          end)
        +convert(varchar,month(@inPayPeriod_End))
        +(case when len(month(@inPayPeriod_End))= 1 
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
      select '-2'
      set implicit_transactions off
      return '-2'
  end

  if @incontract_no = 0
  begin
      open vc_contract_list
      if @@error <> 0
      begin
          rollback transaction
          select '-3'
          set implicit_transactions off
          return '-3'
      end

      /* Watcom only
      MAINLOOP:
      */
      while 1=1 
        /* Watcom only
        MYLABEL1:
        */
      begin
          fetch next from vc_contract_list into @v_contract_no,
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
              select '-4'
              set implicit_transactions off
              return '-4'
          end

          if @@fetch_status <0
              break
              /* Watcom only
              MAINLOOP
              */

          select @v_contractor_contract_start=@v_contractor_start

          select @v_temp_int = count(payment.contractor_supplier_no)
            from payment 
           where (payment.contractor_supplier_no = @v_contractor_no) and
                 (payment.invoice_date between @inPayPeriod_Start and @inPayPeriod_End) and
                 (payment.contract_no = @v_contract_no)
                 
          if @@error <> 0 /* <> was < */
          begin
              rollback transaction
              select '-20'
              set implicit_transactions off
              return '-20'
          end

        if @v_temp_int <= 0
            /* Watcom only
            MYLABEL1
            */
            -- TWC call 4557
            if(@v_contractor_end is null or @v_contractor_end >= @inPayPeriod_Start or 
				--PP datediff(day,@v_contractor_end,@inPayPeriod_Start) < 63) 				
				datediff(day, @inPayPeriod_Start, @v_contractor_end) < 63) 				
				and @v_contractor_start <= @inPayPeriod_End
            begin
                if @v_contractor_start <= @inPayPeriod_Start
                    select @v_contractor_start=@inPayPeriod_Start

                if @v_contractor_end is null or @v_contractor_end >= @inPayPeriod_End
                    select @v_contractor_end=@inPayPeriod_End

                if @v_termdate < @v_contractor_end
                    select @v_contractor_end=@v_termdate

                exec @v_grossresult = odps.od_blf_mainrun_grosspay @v_contract_no,@v_sequence_no,@v_contractor_no,@v_contractor_start,@v_contractor_end,@inPayPeriod_Start,@inPayPeriod_End,@v_run_number,@v_renewal_start,@v_renewal_end,@v_contractor_contract_start

                if @v_grossresult < -100000000
                begin
                    rollback transaction
                    select convert(char(254),@v_grossresult)
                    set implicit_transactions off
                    return convert(char(254),@v_grossresult)
                end

                if @@error <> 0 /* <> was < */
                begin
                    rollback transaction
                    select convert(char(254),@@error)
                    set implicit_transactions off
                    return convert(char(254),@@error)
                end

                select @v_numloops=@v_numloops+1
          end
      end  --end of while 

      if @@error <> 0
      begin
          rollback transaction
          select '-6'
          set implicit_transactions off
          return '-6'
      end
  end
  else
  begin
      open vc_contract_list1
      if @@error<>0
      begin
          rollback transaction
          select '-7'
          set implicit_transactions off
          return '-7'
      end

        /* Watcom only
        MAINLOOP2:
        */
      while 1=1 
          /* Watcom only
          MYLABEL2:
          */
      begin
          fetch next from vc_contract_list1 into @v_contract_no,
            @v_sequence_no,
            @v_contractor_no,
            @v_contractor_start,
            @v_contractor_end,
            @v_renewal_start,
            @v_renewal_end,
            @v_termdate

          if @@fetch_status =-2
          begin
              rollback transaction
              select '-8'
              set implicit_transactions off
              return '-8'
          end

          if @@fetch_status <0
              break
                /* Watcom only
                MAINLOOP2
                */

          select @v_contractor_contract_start=@v_contractor_start

          -- TWC - 01/09/2003 call 4557
          if(@v_contractor_end is null or @v_contractor_end >= @inPayPeriod_Start or 
			--PP datediff(day,@v_contractor_end,@inPayPeriod_Start) < 63) and 
			datediff(day, @inPayPeriod_Start, @v_contractor_end) < 63) and 
			@v_contractor_start <= @inPayPeriod_End
          begin
              if @v_contractor_start <= @inPayPeriod_Start
                  select @v_contractor_start=@inPayPeriod_Start

              if @v_contractor_end is null or @v_contractor_end >= @inPayPeriod_End
                  select @v_contractor_end=@inPayPeriod_End

              if @v_termdate < @v_contractor_end
                  select @v_contractor_end=@v_termdate

              execute @v_grossresult = odps.od_blf_mainrun_grosspay @v_contract_no,@v_sequence_no,@v_contractor_no,@v_contractor_start,@v_contractor_end,@inPayPeriod_Start,@inPayPeriod_End,@v_run_number,@v_renewal_start,@v_renewal_end,@v_contractor_contract_start
             
              if @v_grossresult < -100000000
              begin
                  rollback transaction
                  select convert(char(254),@v_grossresult)
                  set implicit_transactions off
                  return convert(char(254),@v_grossresult)
              end

              if @@error <> 0 /* <> was < */
              begin
                  rollback transaction
                  select convert(char(254),@@error)
                  set implicit_transactions off
                  return convert(char(254),@@error)
              end

              select @v_numloops=@v_numloops+1
          end
          else
              select @v_numloops=@v_numloops
      end

      if @@error <> 0
      begin
          rollback transaction
          select '-10'
          set implicit_transactions off
          return '-10'
      end
  end

  execute @v_temp_int = odps.OD_BLF_Mainrun_WithHoldingTax 

  if @@error <> 0
  begin
      rollback transaction
      select '-13'
      set implicit_transactions off
      return '-13'
  end

  execute @v_temp_int = odps.OD_BLF_Mainrun_GST
  
  if @@error <> 0
  begin
      rollback transaction
      select '-12'
      set implicit_transactions off
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

  execute @v_temp_string = odps.OD_BLF_Mainrun_PostTaxAdj @inPayPeriod_Start,@inPayPeriod_End

  -- Extract the numeric return code from the string
  select @v_temp_int1=charindex(',',@v_temp_string)

  if @v_temp_int1 > 0
      select @v_temp_int=convert(int,left(@v_temp_string,@v_temp_int1-1))
  else
      select @v_temp_int=convert(int,@v_temp_string)

  if @@error <> 0 or(@v_temp_int < -1 and @v_temp_int > -500)
  begin
      rollback transaction
      select '-12'
      set implicit_transactions off
      return '-12'
  end
  else
      if @v_temp_int = -1
      begin
          rollback transaction
          select '-12'
          set implicit_transactions off
          return @v_temp_string
      end

  commit transaction

  if @@error <> 0 /* <> was < */
    begin
		select '-15'
		set implicit_transactions off
      return '-15'
    end

  select convert(char(254),@v_numloops)

  /* Watcom only
  --   exception
  --     when others then --  return v_numloops;
  --       rollback transaction
  --       resignal
  --       return '-1'
  */

  set implicit_transactions off

END
GO
