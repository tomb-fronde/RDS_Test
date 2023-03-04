
CREATE procedure [odps].[OD_BLF_Mainrun_PostTaxAdj](
        @startdate datetime, 
        @enddate datetime
    )
-- TJB Feb-2015
-- Changed sequence of checking deductions against net pay to ensure deduction
-- checked against the right contract's net pay.
--
-- TJB Jan-2015
-- Trace added for debugging
--
-- TJB May-2014
-- Added code to check for attempts to insert comments into the odps.t_payment_component 
-- and odps.t_posttax_deductions_not_applied tables that are too large for the columns.
-- Write diagnostic info to the t_posttaxadj_err table and truncate the comments.
--
-- TJB Oct-2010
-- Changed IRD Post Tax Deduction final amount to test end balance (was begin balance)
-- and use if end balance less than calculated deduction.
--
-- TJB RPCR_020 20-Sep-2010
-- Add lookup of contract number for Shell deductions  a la Telecom deductions
--
-- TJB  RD7_0041 Feb 2010
-- If the ded_default_minimum value is null, use a value of 0 when 
-- calculating Shell, Telecom, Piecerate or Other deductions.
-- Fix @v_comment1 to show NULL for ded_default_minimum value instead of no comment;
-- change str to convert for display values.
-- Some restructuring: removed unnecessary else clauses when selecting 
-- between Shell, Telecom etc deductions.
--
-- TJB  Aug 2009
-- Change -997 and -998 (were both -999) return codes to 0
-- The negative values were being interpreted as errors but were only
-- meant to be informative (I think).
-- 
-- TJB RD7_0016  Jan 2009
-- Can only return numeric return code (or implicitly converted number as string).
-- Return error message in temporary table #tmp_blf_error_message (defined in OD_BLF_MainRun).
-- Note change: only OD_BLF_MainRun begins and commits/rollsback transaction(s).
--   CREATE TABLE #tmp_blf_error_message
--     (
--             msg_proc   varchar(63),
--             msg_date   datetime,
--             msg_text   varchar(255)
--     )
--
-- TJB  SR4648  Jan 2005
-- Added processing for Telecom deductions
-- Changed 'Piecerate%' and 'Other%' from 'else  if ...' to 'elseif ...' structure
--
-- TJB  SR4649  Dec 2004
-- Changed return value to string to return error information to OD_BLF_Mainrun.
-- Caught and parsed by Powerbuilder Payrun code (w_payrun_search)
-- When there''s an error, the string is a comma-separated list of values:
--      <return code>, <contractor no>, <deduction ID>, <deduction description>
-- otherwise its just a single value (the return code).
--
AS
BEGIN
  set CONCAT_NULL_YIELDS_NULL off
  
  declare @v_ded_id int,
          @v_contractor_supplier_no int,
          @v_contract_no int,
          @v_contract_ok int,
          @v_invoice_id int,
          @v_ded_contract int,
          @v_ded_description varchar(200),
          @v_ded_priority int,
          @v_pct_id int,
          @v_ded_reference varchar(200),
          @v_ded_type_period varchar(1),
          @v_ded_percent_gross decimal(5,2),
          @v_ded_percent_net decimal(5,2),
          @v_ded_percent_start_balance decimal(5,2),
          @v_ded_fixed_amount decimal(12,2),
          @v_ded_min_threshold_gross decimal(12,2),
          @v_ded_max_threshold_net_pct decimal(5,2),
          @v_ded_default_minimum decimal(12,2),
          @v_ded_start_balance decimal(12,2),
          @v_ded_end_balance decimal(12,2),
          @v_ded_pay_highest_value int,
          @v_multiplier decimal(15,10),
          @v_returncode int,
          @v_netpay decimal(12,2),
          @v_grosspay decimal(12,2),
          @v_perioddiff int,
          @v_tempint1 int,
          @v_tempint2 int,
          @v_tempdec1 decimal(12,2),
          @v_tempdec2 decimal(12,2),
          @v_tempdec3 decimal(12,2),
          @v_IRD_ded_to_apply decimal(12,2),
          @v_deduction decimal(12,2),
          @v_tempcount int,
          @v_comment1 varchar(300),
          @v_comment2 varchar(300),
          @v_comment1a varchar(400),      -- TJB  May 2014: Added for debugging payrun failure
          @v_pcfaker int,
          @v_temps  varchar(100),
          @t_errmsg varchar(255);

  -- TJB  RD7_0041 Feb 2010
  declare @s_ded_contract varchar(20)
  declare @s_ded_default_minimum varchar(15)
  
  declare c_contractor cursor for 
      select distinct t_payment.contractor_supplier_no 
        from odps.t_payment 
       order by contractor_supplier_no asc;
       
  set @v_returncode=999;
  set @v_tempcount=0;
  set @v_tempdec1=0.0;
  set @v_tempdec2=0.0;
  set @v_tempdec3=0.0;
  set @v_IRD_ded_to_apply=0.0;
  set @v_contract_ok = 0;

  delete from odps.t_posttax_deductions_not_applied;
  if @@error < 0
  begin
    return '-100200'
  end;

  delete from odps.t_post_tax_deductions_applied;
  if @@error < 0
  begin
    return '-100201'
  end;

  delete from odps.t_netpay_tracker;
  if @@error < 0
  begin
    return '-100201'
  end;

  insert into odps.t_netpay_tracker
        (contractor_supplier_no, contract_no, net_pay, invoice_id, gross_pay)
    select contractor_supplier_no,
           contract_no,
           odps.OD_BLF_Get_NetPay_PreAccept(invoice_id,null,null),
           invoice_id,
           odps.OD_BLF_Get_GrossPay_PreAccept(invoice_id,null,null) 
      from odps.t_payment 
     where t_payment.contractor_supplier_no = 
                   any(select post_tax_deductions.contractor_supplier_no 
                         from odps.post_tax_deductions 
                        where ((ded_end_balance > 0 or ded_start_balance = 0) 
                                or (ded_end_balance < 0 
                                    and ded_end_balance = ded_start_balance 
                                    and post_tax_deductions.ded_fixed_amount = post_tax_deductions.ded_end_balance) 
                                or (ded_end_balance is null or ded_start_balance is null)));
  if @@error < 0
  begin
    return '-100202'
  end
  
  open c_contractor
  if @@error < 0
  begin
    return '-100000'
  end;

  while (1 = 1)
  begin
    fetch c_contractor into @v_contractor_supplier_no
    if @@FETCH_STATUS < 0
    begin
      break
    end

    declare c_ptd cursor for 
               select post_tax_deductions.ded_id,
                      post_tax_deductions.ded_description,
                      post_tax_deductions.ded_priority,
                      post_tax_deductions.pct_id,
                      post_tax_deductions.ded_reference,
                      post_tax_deductions.ded_type_period,
                      post_tax_deductions.ded_percent_gross,
                      post_tax_deductions.ded_percent_net,
                      post_tax_deductions.ded_percent_start_balance,
                      post_tax_deductions.ded_fixed_amount,
                      post_tax_deductions.ded_min_threshold_gross,
                      post_tax_deductions.ded_max_threshold_net_pct,
                      post_tax_deductions.ded_default_minimum,
                      post_tax_deductions.ded_start_balance,
                      post_tax_deductions.ded_end_balance,
                      post_tax_deductions.ded_pay_highest_value 
                 from odps.post_tax_deductions 
                where contractor_supplier_no = @v_contractor_supplier_no 
                  and ((post_tax_deductions.ded_end_balance > 0 and post_tax_deductions.ded_start_balance > 0) 
                        or (post_tax_deductions.ded_end_balance is null 
                            and post_tax_deductions.ded_start_balance is null) 
                        or (post_tax_deductions.ded_end_balance < 0 
                            and post_tax_deductions.ded_start_balance = post_tax_deductions.ded_end_balance 
                            and post_tax_deductions.ded_fixed_amount = post_tax_deductions.ded_end_balance) 
                        or (post_tax_deductions.ded_start_balance = 0 
                            and post_tax_deductions.ded_end_balance is null)) 
                  and exists(select t_payment.contractor_supplier_no 
                               from odps.t_payment 
                              where t_payment.contractor_supplier_no = post_tax_deductions.contractor_supplier_no) 
                order by ded_priority asc;

    open c_ptd;
    if @@error < 0
    begin
        return '-100000'
    end;

    while (1 = 1)
    begin

      fetch c_ptd 
       into @v_ded_id,
            @v_ded_description,
            @v_ded_priority,
            @v_pct_id,
            @v_ded_reference,
            @v_ded_type_period,
            @v_ded_percent_gross,
            @v_ded_percent_net,
            @v_ded_percent_start_balance,
            @v_ded_fixed_amount,
            @v_ded_min_threshold_gross,
            @v_ded_max_threshold_net_pct,
            @v_ded_default_minimum,
            @v_ded_start_balance,
            @v_ded_end_balance,
            @v_ded_pay_highest_value;

      if @@FETCH_STATUS < 0
      begin
          break
      end

      select @v_perioddiff = datediff(day, @startdate, @enddate) + 1
      if  @@error < 0
      begin
        return '-100010'
      end;

      if @v_ded_type_period = 'W'
        set @v_multiplier = @v_perioddiff/7.0
      else
        set @v_multiplier = 1

      select @v_invoice_id = min(invoice_id)
        from odps.t_netpay_tracker as p1 
       where p1.contractor_supplier_no = @v_contractor_supplier_no 
         and p1.net_pay = (select max(p2.net_pay) 
                             from odps.t_netpay_tracker as p2 
                            where p2.contractor_supplier_no = @v_contractor_supplier_no)
      if @@error < 0
      begin
        return '-100030'
      end;
      
      select @v_netpay = net_pay
           , @v_grosspay = gross_pay
        from odps.t_netpay_tracker 
       where invoice_id = @v_invoice_id;
      if @@error < 0
      begin
        return '-100040'
      end;
      
      -- TJB  RPCR_094  Mar-2015
      -- Combined netpay and grosspay selects (see above)
      --
      -- select @v_grosspay = gross_pay
      --   from odps.t_netpay_tracker 
      --  where invoice_id = @v_invoice_id;
      -- if @@error < 0
      -- begin
      --   return '-100050'
      -- end
      
  -- Start Shell etc deductions here
      if (@v_ded_description like 'Shell%'
          or @v_ded_description like 'Fuel%'
          or @v_ded_description like 'Telecom%'
          or @v_ded_description like 'Mobile%'
          or @v_ded_description like 'Piecerate%'
          or @v_ded_description like 'Other%')
      begin

        -- TJB  RD7_0041 Feb 2010: added
        if @v_ded_default_minimum is null
            set @v_ded_default_minimum = 0

        -- TJB  SR4648
        -- For Telecom and Shell deductions we need to apply to the specific contract.
        -- Other deductions are relevant to all contracts.  
        -- v_contract_ok = 1 says the deduction applies.
        --               = 0 says it doesn''t

        set @v_contract_ok = 1

        -- TJB RPCR_020 20-Sep-2010
        -- Add lookup of contract number a la Telecom deductions (below)
        -- TJB RPCR_094 Mar-2015
        -- Modified: Look in ther deduction reference field to see if the deduction 
        --           applies to a specific contract

        -- TJB RPCR_020 20-Sep-2010: added
            -- Extract the relevant contract number from the reference string
            --   (which looks like "Telecom Deduction Contract #### imported on <date>")
            -- TJB RPCR_020 20-Sep-2010
            --   Change to use OD_MiscF_GetContractNo
        select @v_ded_contract = [odps].[OD_MiscF_GetContractNo](@v_ded_reference)

        if ( @v_ded_contract is null )
            set @s_ded_contract = 'null'
        else
            set @s_ded_contract = convert(varchar,@v_ded_contract)

        -- TJB  RPCR_094  Mar-2015
        -- Moved this block of code from Teleco processing to here
        -- If there was a contract number found, get the invoice_id, net_pay and gross_pay
        -- for this contractor's contract - not the default values.
        -- These are now used for all Shell, Telecom, Piecerate and Other deductions
        -- If no values are found, @v_contract_found is set to 0 and the deduction 
        -- is not applied for this contract.
        
        -- If no contract number found, carry on as originally (all deductions for contractor 
        -- accepted and charged against the default contract (largest)).
        -- If a contract number was found, accept this deduction only if it for this contract.
        if @v_ded_contract is not null
        begin
            -- TJB  SR4648
            -- Check to see if there''s an invoice for this contract for this contractor.
            -- --> v_invoice_id will not be changed if the select doesn''t find anything, 
            --     so we use that information to set v_contract_ok to disable the application
            --     of the deduction.  Otherwise, v_invoice_id references the correct invoice
            --     for the deduction.
            set @v_invoice_id = -1
                
            select @v_invoice_id = invoice_id 
                 , @v_netpay = net_pay
                 , @v_grosspay = gross_pay
              from odps.t_netpay_tracker 
             where contractor_supplier_no = @v_contractor_supplier_no 
               and contract_no = @v_ded_contract;
               
            if @@error < 0
            begin
                return '-100051'
            end

            if @v_invoice_id is null or @v_invoice_id = -1
                set @v_contract_ok = 0
        end    

        if (@v_ded_description like 'Shell%' or @v_ded_description like 'Fuel%' )
           and @v_contract_ok = 1
        begin
            if @v_netpay < @v_ded_default_minimum
            begin
                set @v_comment1  = 'PTA: Type=Fuel;Netpay<Fuel Card deduction : Deduct netpay';
                set @v_deduction = @v_netpay
            end
            else
            begin
                if @v_ded_default_minimum < 0
                    set @v_comment1 = 'PTA: Type=Fuel;Refund full amount'
                else
                    set @v_comment1 = 'PTA: Type=Fuel;Deduct full amount'
     
                set @v_deduction = @v_ded_default_minimum
            end
            
        end   -- Shell deduction

        if (@v_ded_description like 'Telecom%' or @v_ded_description like 'Mobile%')
           and @v_contract_ok = 1
        begin
            if @v_netpay < @v_ded_default_minimum
            begin
                set @v_comment1  = 'PTA: Type=Mobile;Netpay<Mobile deduction : Deduct netpay';
                set @v_deduction = @v_netpay
            end
            else
            begin
                set @v_comment1  = 'PTA: Type=Mobile;Deduct full amount';
                set @v_deduction = @v_ded_default_minimum
            end
        end   -- Telecom deduction

        if @v_ded_description like 'Piecerate%' and @v_contract_ok = 1
        begin
            if @v_netpay < @v_ded_default_minimum
            begin
                set @v_comment1  = 'PTA: Type=Piecerate;Netpay<Piecerate deduction : Deduct netpay';
                set @v_deduction = @v_netpay
            end
            else
            begin
                set @v_comment1  = 'PTA: Type=Piecerate;Deduct full amount';
                set @v_deduction = @v_ded_default_minimum
            end
        end   -- Piecerate deduction

        if @v_ded_description like 'Other%' and @v_contract_ok = 1
        begin
            if @v_netpay < @v_ded_default_minimum
            begin
                set @v_comment1  = 'PTA: Type=Other;Netpay<Other deduction : Deduct netpay';
                set @v_deduction = @v_netpay
            end
            else
            begin
                set @v_comment1  = 'PTA: Type=Other;Deduct full amount';
                set @v_deduction = @v_ded_default_minimum
            end
        end  -- Other deduction
        
        -- TJB  SR4648
        -- If the deduction isn''t relevant to the current contract, 
        -- don''t do anything with it.
        if @v_contract_ok = 1
        begin
            select @v_pcfaker = max(pc_id)
              from odps.t_payment_component

            if @v_deduction is null
            begin
                 set @t_errmsg = '-1, NULL Deduction: '
                                 + convert(varchar,@v_contractor_supplier_no)+', '
                                 + convert(varchar,@v_ded_id)+', '
                                 + @v_ded_description;
                 insert into #tmp_blf_error_message
                 values ('OD_BLF_Mainrun_PostTaxAdj',getdate(),@t_errmsg);

                 return '-1'
            end
            
            -- TJB  RPCR_094  Mar-2015
            -- Flag situations where the pay would have been negative
            if @v_netpay < @v_ded_default_minimum
            begin
                set @t_errmsg = '-1, Negative Pay: '
                                 + 'Contractor '+convert(varchar,@v_contractor_supplier_no)
                                 + ', Contract '+@s_ded_contract
                                 + ', ded_id '+convert(varchar,@v_ded_id)
                                 + ', '+@v_ded_description;
                insert into #tmp_blf_error_message
                values ('OD_BLF_Mainrun_PostTaxAdj',getdate(),@t_errmsg);
            end

            insert into odps.t_payment_component
                 (pct_id, invoice_id, pc_amount, comments)
            select (select pct_id from odps.payment_component_type 
                     where pct_description like 'Post-Tax adj%'),
                   @v_invoice_id,
                   @v_deduction * -1,
                   @v_comment1;
                          
            update odps.t_netpay_tracker 
               set net_pay    = net_pay - @v_deduction 
             where invoice_id = @v_invoice_id
                            
            insert into odps.t_post_tax_deductions_applied
                (pcd_amount, ded_id, pcd_date, invoice_id) 
            values
                (@v_deduction*(-1), @v_ded_id, @enddate, @v_invoice_id)
        end
    end
    else
    begin
        -- Process IRD and DSW deductions
        -- (the deduction is not a Shell, Telecom, Piecerate or Other deduction)
        
        if @v_ded_fixed_amount > 0
        begin
            if @v_ded_pay_highest_value = 1
            begin
                if @v_ded_default_minimum is not null 
                   and (@v_ded_default_minimum >= @v_ded_fixed_amount or @v_ded_fixed_amount is null)
                begin
                    set @v_comment1  = 'PTA: Type=DSW; Pay highest value: We try to use default minimum which is > fixed amount';
                    set @v_deduction = @v_ded_default_minimum * @v_multiplier
                end
                else
                begin
                    set @v_comment1  = 'PTA: Type=DSW; Pay highest value: We attempt to use fixed amount which is > default minimum';
                    set @v_deduction = @v_ded_fixed_amount * @v_multiplier
                end
            end
            else
            begin
                if (@v_ded_default_minimum is not null) 
                    and (@v_ded_fixed_amount is null or @v_ded_fixed_amount = 0 or @v_ded_default_minimum <= @v_ded_fixed_amount)
                begin
                    set @v_comment1  = 'PTA: Type=DSW; Pay lowest value: We try to use default minimum';
                    set @v_deduction = @v_ded_default_minimum * @v_multiplier
                end
                else
                begin
                    set @v_comment1  = 'PTA: Type=DSW; Pay lowest value: We try to use fixed amount';
                    set @v_deduction = @v_ded_fixed_amount * @v_multiplier
                end
            end
            
            if @v_deduction is null
                set @v_deduction = 0.0
                
            set @v_comment2='';
            set @v_comment1 = @v_comment1
                             +'; NetPay=' + ltrim(str(@v_netpay))
                             +'; ID=' + ltrim(str(@v_ded_id))
                             +'; Threshold=' + ltrim(str(@v_ded_max_threshold_net_pct))
                             +'; End balance=' + ltrim(str(@v_ded_end_balance))
                             +'; Period type=' + @v_ded_type_period
                             +'; Prorata factor=' + ltrim(str(@v_multiplier))
                             +'; Other factors ignored because this is type DSW'

            if @v_netpay > 0 and @v_deduction > 0
            begin
                if ((@v_netpay-@v_deduction)/@v_netpay)*100 >= @v_ded_max_threshold_net_pct
                begin
                    if @v_deduction > @v_ded_end_balance and @v_ded_start_balance > 0
                    begin
                        set @v_deduction = @v_ded_end_balance
                        set @v_comment1  = @v_comment1+'; <Final amount applied is end balance which is less than computed ded> '
                        set @v_comment2  = 'More'
                    end
                    
                    select @v_pcfaker = max(pc_id) 
					  from odps.t_payment_component

                    if @v_deduction is null
                    begin
                        set @t_errmsg = '-1,'
                                        + convert(varchar,@v_contractor_supplier_no)+','
                                        + convert(varchar,@v_ded_id)+','
                                        + @v_ded_description;
                        insert into #tmp_blf_error_message
                        values ('OD_BLF_Mainrun_PostTaxAdj',getdate(),@t_errmsg);

                        return '-1'
                    end

                    if @v_comment2 <> 'More'
                    begin
                        if @v_ded_default_minimum is not null and @v_ded_default_minimum > @v_ded_fixed_amount 
                            set @v_temps = '; Final amount applied = Default ('+ ltrim(str(@v_ded_default_minimum))
                        else 
                            set @v_temps = '; Final amount applied = Fixed amt('+ ltrim(str(@v_ded_fixed_amount)) 
                    end
                    
                    -- TJB  May 2014: Added for debugging payrun failure
                    select @v_comment1a = @v_comment1 + @v_temps +') multiplied by Prorata factor'
                    if len(@v_comment1a) > 300
                    begin
                        insert into odps.t_posttaxadj_err
                            (run_date, contractor_no, invoice_id, pct_ded_id, pc_amount, instance_no, comment_length, comment)
                        select 
                            getdate(), 
                            @v_contractor_supplier_no, 
                            @v_invoice_id,
                            (select pct_id from odps.payment_component_type 
                              where pct_description like 'Post-Tax adj%'),
                            @v_deduction*-1,
                            1,
                            len(@v_comment1a), 
                            @v_comment1a
                    end
                   
                    -- TJB  May 2014: Added substring(@v_comment1... to fix payrun failure
                    insert into odps.t_payment_component
                        (pct_id, invoice_id, pc_amount, comments)
                    select 
                        (select pct_id from odps.payment_component_type 
                          where pct_description like 'Post-Tax adj%'),
                        @v_invoice_id,
                        @v_deduction*-1,
                        substring(@v_comment1 + @v_temps +') multiplied by Prorata factor',1,300)
                   
                    update odps.t_netpay_tracker 
                       set net_pay = net_pay-@v_deduction 
                     where invoice_id = @v_invoice_id;
                        
                    insert into odps.t_post_tax_deductions_applied
                         (pcd_amount, ded_id, pcd_date, invoice_id) 
                    values (@v_deduction * -1, @v_ded_id, @enddate, @v_invoice_id)
                end
                else
                begin
                    set @v_returncode=-998;
                    
                    -- TJB  May 2014: Added for debugging payrun failure
                    set @v_comment1a = @v_comment1+'<Not Applied(1)>'
                    if len(@v_comment1a) > 300
                    begin
                        insert into odps.t_posttaxadj_err
                            (run_date, contractor_no, invoice_id, pct_ded_id, instance_no, comment_length, comment)
                        select 
                            getdate(), 
                            @v_contractor_supplier_no, 
                            @v_invoice_id, 
                            @v_ded_id, 
                            2, 
                            len(@v_comment1a), 
                            @v_comment1a
                    end

                    -- TJB  May 2014: Added substring(@v_comment1... to fix payrun failure
                    insert into odps.t_posttax_deductions_not_applied 
                    values
                        (@v_ded_id, @v_contractor_supplier_no, substring(@v_comment1+'<Not Applied(1)>',1,300), @v_invoice_id)
                         
                    if @@error < 0 
                    begin
                        return '-100053'
                    end;
                end
            end  -- if @v_netpay > 0 and @v_deduction > 0
        end -- if @v_ded_fixed_amount > 0
        
        if @v_ded_fixed_amount = 0 or @v_ded_fixed_amount is null
        begin
            set @v_comment1 = 'PTA: Type=IRD';
            if @v_ded_percent_gross > 0
                if @v_grosspay >= @v_ded_min_threshold_gross
                    set @v_tempdec1 = @v_ded_percent_gross * @v_grosspay/100
                    
            if @v_ded_percent_net > 0
                if @v_netpay >= @v_ded_min_threshold_gross
                    set @v_tempdec2 = @v_ded_percent_net * @v_netpay/100

            if @v_ded_percent_start_balance > 0
                if @v_netpay > (@v_multiplier * @v_ded_percent_start_balance * @v_ded_start_balance)/100
                    set @v_tempdec3 = (@v_ded_percent_start_balance * @v_ded_start_balance)/100

            if @v_tempdec1 is null 
                set @v_tempdec1 = 0.0

            if @v_tempdec2 is null 
                set @v_tempdec2 = 0.0

            if @v_tempdec3 is null 
                set @v_tempdec3 = 0.0

            if @v_tempdec1 > 0 or @v_tempdec2 > 0 or @v_tempdec3 > 0
            begin
                if @v_ded_pay_highest_value = 1 
                begin
                    if @v_tempdec1 >= @v_tempdec2
                    begin
                        set @v_IRD_ded_to_apply = @v_tempdec1;
                        if @v_IRD_ded_to_apply <= @v_tempdec3
                        begin
                            set @v_IRD_ded_to_apply = @v_tempdec3;
                            set @v_comment1 = @v_comment1+'; Evaluate highest which is Total%('+ltrim(str(@v_tempdec3))+')'
                        end
                        else
                            set @v_comment1 = @v_comment1+'; Evaluate highest which is Gross%('+ltrim(str(@v_tempdec1))+')'
                    end
                    else
                    begin
                        set @v_IRD_ded_to_apply = @v_tempdec2;
                        if @v_IRD_ded_to_apply <= @v_tempdec3
                        begin
                            set @v_IRD_ded_to_apply = @v_tempdec3;
                            set @v_comment1 = @v_comment1+'; Evaluate highest which is Total%('+ltrim(str(@v_tempdec3))+')'
                        end
                        else
                            set @v_comment1 = @v_comment1+'; Evaluate highest which is Net%('+ltrim(str(@v_tempdec2))+')'
                    end
                end
                else
                begin
                    if (@v_tempdec3 <= @v_tempdec1 or @v_tempdec1 = 0) 
                        and (@v_tempdec3 <= @v_tempdec2 or @v_tempdec2 = 0) 
                        and (@v_tempdec3 > 0)
                    begin
                        set @v_IRD_ded_to_apply = @v_tempdec3;
                        set @v_comment1 = @v_comment1+'; Evaluate lowest which is Total%('+ltrim(str(@v_tempdec3))+')'
                    end 
                    else if (@v_tempdec1 <= @v_tempdec2 or @v_tempdec2 = 0) 
                             and (@v_tempdec1 <= @v_tempdec3 or @v_tempdec3 = 0) 
                             and (@v_tempdec1 > 0)
                    begin
                        set @v_IRD_ded_to_apply = @v_tempdec1;
                        set @v_comment1 = @v_comment1+'; Evaluate lowest which is Gross%('+ltrim(str(@v_tempdec1))+')'
                    end
                end
            end
            else
            begin
                if (@v_tempdec2 <= @v_tempdec1 or @v_tempdec1 = 0) 
                    and (@v_tempdec2 <= @v_tempdec3 or @v_tempdec3 = 0) 
                    and (@v_tempdec2 > 0)
                begin
                    set @v_IRD_ded_to_apply =@v_tempdec2;
                    set @v_comment1 = @v_comment1+'; Evaluate lowest which is Net%'+ltrim(str(@v_tempdec2))+')'
                end
                else
                    set @v_comment1 = @v_comment1+'; <Cannot find lowest value. Probable data entry error>'
            end  -- if {@v_tempdec1 or @v_tempdec2 or @v_tempdec3} > 0
           -- end

            if @v_IRD_ded_to_apply is null or @v_IRD_ded_to_apply = 0 or @v_netpay < (@v_IRD_ded_to_apply*@v_multiplier)
            begin
                -- TJB  RD7_0041 Feb 2010: Added the @v_ded_default_minimum is not null test
                if @v_ded_default_minimum is not null and @v_ded_default_minimum > 0 and @v_ded_default_minimum <= @v_netpay
                begin
                    set @v_IRD_ded_to_apply = @v_ded_default_minimum;
                    set @v_comment1 = @v_comment1+'<***Dflt min overrides highest/lowest:'+ltrim(str(@v_ded_default_minimum))+'***>'
                end
                else
                begin
                    set @v_IRD_ded_to_apply = 0.0;
                    set @v_comment1 = @v_comment1+'<Not applied(2), and default too large>'
                end
            end
            else
            begin
                if @v_netpay >= @v_IRD_ded_to_apply*@v_multiplier
                    set @v_comment1 = @v_comment1+'<OK! Apply value on the left multiplied by '+ltrim(str(@v_multiplier))+'>'
                else
                    set @v_comment1 = @v_comment1+'<Value at left not applied(3): Net pay too small>'
            end
          
           set @v_deduction = @v_IRD_ded_to_apply * @v_multiplier;

           -- TJB  RD7_0041 Feb 2010
           -- Fix @v_comment1 to show NULL for ded_default_minimum value instead of no comment;
           -- change str to convert for display values.
           if @v_ded_default_minimum is null
               set @s_ded_default_minimum = 'NULL'
           else
               set @s_ded_default_minimum = convert(varchar(15),@v_ded_default_minimum);

           set @v_comment1 = @v_comment1
                            +'; Net= '         + convert(varchar(15),@v_netpay)
                            +'; Gross= '       + convert(varchar(15),@v_grosspay)
                            +'; ID= '          + convert(varchar(15),@v_ded_id)
                            +'; NetThresh= '   + 'n.a.'
                            +'; GrossThresh= ' + convert(varchar(15),@v_ded_min_threshold_gross)
                            +'; DfltMin= '     + @s_ded_default_minimum
                            +'; Period= '      + @v_ded_type_period
                            +'; Prorata = '    + convert(varchar(15),@v_multiplier)
                            +'; Net%= '        + convert(varchar(15),@v_ded_percent_net)
                            +'; Gross%= '      + convert(varchar(15),@v_ded_percent_gross)
                            +'; Total%= '      + convert(varchar(15),@v_ded_percent_start_balance)
                            +'; Total= '       + convert(varchar(15),@v_ded_start_balance);

           if @v_deduction <> 0 and @v_deduction is not null and @v_netpay >= @v_deduction
           begin
               -- TJB Oct-2010
               -- Changed to end balance (was begin balance)
               if @v_deduction > @v_ded_end_balance           -- @v_ded_start_balance
               begin
                   set @v_deduction = @v_ded_end_balance      -- @v_ded_start_balance;
                   set @v_comment1  = @v_comment1+'; <End balance applied>'
               end
               
               select @v_pcfaker = max(pc_id) 
			     from odps.t_payment_component;

               if @v_deduction is null
               begin
                   set @t_errmsg = '-1,'
                                   + convert(varchar,@v_contractor_supplier_no)+','
                                   + convert(varchar,@v_ded_id)+','
                                   + @v_ded_description;
                   insert into #tmp_blf_error_message
                   values ('OD_BLF_Mainrun_PostTaxAdj',getdate(),@t_errmsg);
  
                   return '-1'
               end
               
               insert into odps.t_payment_component
                    (pct_id, invoice_id, pc_amount, comments)
                  select (select pct_id from odps.payment_component_type 
                           where pct_description like 'Post-Tax adj%'),
                         @v_invoice_id,
                         @v_deduction*-1,
                         @v_comment1
                         
               update odps.t_netpay_tracker 
                  set net_pay = net_pay-@v_deduction 
                where invoice_id = @v_invoice_id;
                
               insert into odps.t_post_tax_deductions_applied
                      (pcd_amount, ded_id, pcd_date,invoice_id) 
               values (@v_deduction*-1, @v_ded_id, @enddate, @v_invoice_id)
           end
           else
           begin
               set @v_returncode=-997;

               insert into odps.t_posttax_deductions_not_applied 
               values
                   (@v_ded_id, @v_contractor_supplier_no, @v_comment1, @v_invoice_id);
               if @@error < 0 
               begin
                   -- rollback work
                   return '-100054'
               end;
            end
        end
      end  -- IRD, DSW section
      set @v_tempcount = @v_tempcount+1
    end  -- End Deduction loop
    
    close c_ptd
    DEALLOCATE c_ptd
  end  -- End contractor loop
  close c_contractor;

  if (@v_returncode = -997) or (@v_returncode = -998)
      set @v_returncode = 0

  return convert(varchar,@v_returncode)
end