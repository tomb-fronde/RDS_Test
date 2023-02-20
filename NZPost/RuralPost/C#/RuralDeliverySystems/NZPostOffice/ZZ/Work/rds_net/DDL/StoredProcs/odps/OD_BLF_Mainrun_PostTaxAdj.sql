/****** Object:  StoredProcedure [odps].[OD_BLF_Mainrun_PostTaxAdj]    Script Date: 08/05/2008 10:13:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [odps].[OD_BLF_Mainrun_PostTaxAdj](@startdate datetime,@enddate datetime)
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
-- returns integer
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare
  @v_ded_id int,
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
  @v_tempint int,
  @v_tempint2 int,
  @v_tempdec decimal(12,2),
  @v_tempdec2 decimal(12,2),
  @v_tempdec3 decimal(12,2),
  @v_IRD_ded_to_apply decimal(12,2),
  @v_deduction decimal(12,2),
  @v_tempcount int,
  @v_comment varchar(300),
  @v_comment2 varchar(300),
  @v_pcfaker int,
  @v_temps varchar(100)
  declare c_contractor cursor for select distinct t_payment.contractor_supplier_no from
      t_payment order by
      contractor_supplier_no asc;
  declare @t_errmsg varchar(252);
  set @v_returncode=999;
  set @v_tempcount=0;
  set @v_tempdec=0.0;
  set @v_tempdec2=0.0;
  set @v_tempdec3=0.0;
  set @v_IRD_ded_to_apply=0.0;
  delete from t_posttax_deductions_not_applied;
  if @@error < 0
  begin
    rollback work
    return '-100200'
  end --    return(-100200);
  delete from t_post_tax_deductions_applied;
  if @@error < 0
  begin
    rollback work
    return '-100201'
  end --    return(-100201);
  delete from t_netpay_tracker;
  if @@error < 0
  begin
    rollback work
    return '-100201'
  end --    return(-100201);
  insert into t_netpay_tracker(contractor_supplier_no,
    contract_no,net_pay,invoice_id,gross_pay)
    select contractor_supplier_no,
      contract_no,
      odps.OD_BLF_Get_NetPay_PreAccept(invoice_id,null,null),
      invoice_id,
      odps.OD_BLF_Get_GrossPay_PreAccept(invoice_id,null,null) from
      t_payment where
      t_payment.contractor_supplier_no = 
      any(select post_tax_deductions.contractor_supplier_no from
        post_tax_deductions where
        ((ded_end_balance > 0 or ded_start_balance = 0) or
        (ded_end_balance < 0 and ded_end_balance = ded_start_balance and
        post_tax_deductions.ded_fixed_amount = post_tax_deductions.ded_end_balance) or
        (ded_end_balance is null or ded_start_balance is null)));
  if @@error < 0
  begin
    rollback work
    return '-100202'
  end --    return(-100202);
  open c_contractor
  if @@error < 0
  begin
    return '-100000'
  end --    return(-100000);
  while (1 = 1)
  begin
    fetch c_contractor into @v_contractor_supplier_no
    if @@FETCH_STATUS < 0
	begin
      break
    end;
  declare c_ptd cursor for select post_tax_deductions.ded_id,
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
      post_tax_deductions.ded_pay_highest_value from
      post_tax_deductions where
      contractor_supplier_no = @v_contractor_supplier_no and
      ((post_tax_deductions.ded_end_balance > 0 and post_tax_deductions.ded_start_balance > 0) or
      (post_tax_deductions.ded_end_balance is null and post_tax_deductions.ded_start_balance is null) or
      (post_tax_deductions.ded_end_balance < 0 and post_tax_deductions.ded_start_balance = post_tax_deductions.ded_end_balance and post_tax_deductions.ded_fixed_amount = post_tax_deductions.ded_end_balance) or
      (post_tax_deductions.ded_start_balance = 0 and post_tax_deductions.ded_end_balance is null)) and
      exists(select t_payment.contractor_supplier_no from
        t_payment where
        t_payment.contractor_supplier_no = post_tax_deductions.contractor_supplier_no) order by
      ded_priority asc;
    open c_ptd;
    if @@error < 0
	begin
      return '-100000'
    end --      return-100000;
    while (1 = 1)
    begin
      fetch c_ptd into @v_ded_id,
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
        break
      select @v_perioddiff = datediff(day, @startdate, @enddate) + 1
      if  @@error < 0
	  begin
        rollback work
        return '-100010'
      end--        return(-100010);
      if @v_ded_type_period = 'W'
        set @v_multiplier =@v_perioddiff/7.0
      else
        set @v_multiplier=1
      select @v_invoice_id = min(invoice_id)
        from t_netpay_tracker as p1 where
        p1.contractor_supplier_no = @v_contractor_supplier_no and
        p1.net_pay = (select max(p2.net_pay) from
          t_netpay_tracker as p2 where
          p2.contractor_supplier_no = @v_contractor_supplier_no);
      if @@error < 0
	  begin
        rollback work
        return '-100030'
      end; --        return(-100030);
      select @v_netpay=net_pay
        from t_netpay_tracker where
        invoice_id = @v_invoice_id;
      if @@error < 0
	  begin
        rollback work
        return '-100040'
      end --        return(-100040);
      select @v_grosspay = gross_pay
        from t_netpay_tracker where
        invoice_id = @v_invoice_id;
      if @@error < 0
        return '-100050'
      --// Start Shell etc deductions here
      if @v_ded_description like 'Shell%' or
        @v_ded_description like 'Telecom%' or
        @v_ded_description like 'Piecerate%' or
        @v_ded_description like 'Other%'
	  begin
        --// TJB  SR4648
       ---- // For Telecom deductions we need to apply to the specific contract.
       -- // Other deductions are relevant to all contracts.  v_contract_ok 
       -- // when = 1 says the deduction applies.
        set @v_contract_ok=1
        if @v_ded_description like 'Shell%'
          if @v_netpay < @v_ded_default_minimum
		    begin
				set @v_comment='PTA: Type=Shell;Netpay<Shell deduction : Deduct netpay';
				set @v_deduction =@v_netpay
		    end
          else
            begin
              if @v_ded_default_minimum < 0
                set @v_comment='PTA: Type=Shell;Refund full amount'
              else
                set @v_comment='PTA: Type=Shell;Deduct full amount'
              set @v_deduction =@v_ded_default_minimum
			end
        else if @v_ded_description like 'Telecom%'
			begin  --Feb2008 001
          if @v_netpay < @v_ded_default_minimum
			begin
				set @v_comment='PTA: Type=Telecom;Netpay<Telecom deduction : Deduct netpay';
				set @v_deduction=@v_netpay
			end
          else
			begin
			  set @v_comment='PTA: Type=Telecom;Deduct full amount';
			   set @v_deduction=@v_ded_default_minimum
			 end
          --//  TJB  SR4648
          --// Extract the relevant contract number from the reference string
          --//   (which looks like "Telecom Deduction Contract #### imported on <date>")
		  set @v_tempint=charindex(' ', @v_ded_reference,20);
		  set @v_tempint2=charindex(' ', @v_ded_reference,@v_tempint+1)
		  if @v_tempint2 > @v_tempint
			set @v_temps = rtrim(ltrim(substring(@v_ded_reference,@v_tempint,@v_tempint2-@v_tempint)))
		  else
			set @v_temps = ''
		  if len(@v_temps) > 0 and substring(@v_temps, 1, 1) in ('1','2','3','4','5','6','7','8','9','0')
			set @v_ded_contract=convert(int, @v_temps)
		  else
			set @v_ded_contract = null
          --// TJB  SR4648
          --// Check to see if there''s an invoice for this contract for this contractor.
          --// --> v_invoice_id will not be changed if the select doesn''t find anything, 
          --//     so we use that information to set v_contract_ok to disable the application
          --//     of the deduction.  Otherwise, v_invoice_id references the correct invoice
          --//     for the deduction.
          set @v_invoice_id=-1
          select @v_invoice_id = invoice_id 
            from t_netpay_tracker where
            contractor_supplier_no = @v_contractor_supplier_no and
            contract_no = @v_ded_contract;
          if @@error < 0
		  begin
            rollback work
            return '-100050'
		  end
          if @v_invoice_id is null or @v_invoice_id = -1
            set @v_contract_ok=0
			end   --Feb2008  001
        else if @v_ded_description like 'Piecerate%'
          if @v_netpay < @v_ded_default_minimum
		    begin
				set @v_comment='PTA: Type=Piecerate;Netpay<Piecerate deduction : Deduct netpay';
				set @v_deduction=@v_netpay
		    end
          else
            begin
				set @v_comment='PTA: Type=Piecerate;Deduct full amount';
				set @v_deduction=@v_ded_default_minimum
		    end
        else if @v_ded_description like 'Other%'
          if @v_netpay < @v_ded_default_minimum
			begin
				set @v_comment='PTA: Type=Other;Netpay<Other deduction : Deduct netpay';
				set @v_deduction=@v_netpay
			end
          else
			begin
				set @v_comment='PTA: Type=Other;Deduct full amount';
				set @v_deduction=@v_ded_default_minimum
            end
        --// TJB  SR4648
        --// If the deduction isn''t relevant to the current contract, 
        --// don''t do anything with it.
        if @v_contract_ok = 1
		begin
          select @v_pcfaker = max(pc_id)
            from t_payment_component
          if @v_deduction is null
		  begin
            set @t_errmsg='-1'+','+
              convert(char,@v_contractor_supplier_no)+','+
              convert(char,@v_ded_id)+','+
              @v_ded_description
            return @t_errmsg
          end
          insert into t_payment_component(
            pct_id,invoice_id,pc_amount,comments)
            select 
              (select pct_id from
                payment_component_type where
                pct_description like 'Post-Tax adj%'),
              @v_invoice_id,
              @v_deduction*-1,
              @v_comment;
          update t_netpay_tracker set
            net_pay = net_pay-@v_deduction where
            invoice_id = @v_invoice_id
          insert into t_post_tax_deductions_applied(
            pcd_amount,ded_id,pcd_date,invoice_id) values(
            @v_deduction*(-1),@v_ded_id,@enddate,@v_invoice_id)
        end
      end
      else
		begin
        --//If the deduction is not a shell deduction go in here to deduct IRD and DSW as normal
       if @v_ded_fixed_amount > 0
		begin
          if @v_ded_pay_highest_value = 1
            if @v_ded_default_minimum is not null and(@v_ded_default_minimum >= @v_ded_fixed_amount or @v_ded_fixed_amount is null)
			  begin
				set @v_comment='PTA: Type=DSW; Pay highest value: We try to use default minimum which is > fixed amount';
				set @v_deduction=@v_ded_default_minimum*@v_multiplier
			  end
            else
			  begin
				set @v_comment='PTA: Type=DSW; Pay highest value: We attempt to use fixed amount which is > default minimum';
				set @v_deduction=@v_ded_fixed_amount*@v_multiplier
			  end
          else
            if(@v_ded_default_minimum is not null) and(@v_ded_default_minimum <= @v_ded_fixed_amount or @v_ded_fixed_amount = 0)
			  begin
				set @v_comment='PTA: Type=DSW; Pay lowest value: We try to use default minimum';
				set @v_deduction=@v_ded_default_minimum*@v_multiplier
		      end
            else
			  begin
				set @v_comment='PTA: Type=DSW; Pay lowest value: We try to use fixed amount';
				set @v_deduction=@v_ded_fixed_amount*@v_multiplier
			  end
          if @v_deduction is null
            set @v_deduction=0.0
          set @v_comment2='';
          set @v_comment=@v_comment+'; NetPay='+
            ltrim(str(@v_netpay))+'; ID='+
            ltrim(str(@v_ded_id))+'; Threshold='+
            ltrim(str(@v_ded_max_threshold_net_pct))+'; End balance='+
            ltrim(str(@v_ded_end_balance))+'; Period type='+
            @v_ded_type_period+'; Prorata factor='+
            ltrim(str(@v_multiplier))+'; Other factors ignored because this is type DSW'
          if @v_netpay > 0 and @v_deduction > 0
            if((@v_netpay-@v_deduction)/@v_netpay)*100 >= @v_ded_max_threshold_net_pct
			begin
              if @v_deduction > @v_ded_end_balance and @v_ded_start_balance > 0
			  begin
                set @v_deduction=@v_ded_end_balance
                set @v_comment=@v_comment+'; <Final amount applied is end balance which is less than computed ded> '
                set @v_comment2='More'
              end
              select @v_pcfaker = max(pc_id)  from t_payment_component
              if @v_deduction is null
			  begin
                set @t_errmsg='-1'+','+
                  convert(char,@v_contractor_supplier_no)+','+
                  convert(char,@v_ded_id)+','+
                  @v_ded_description
                return @t_errmsg
              end
--@v_temps
			 if @v_comment2 <> 'More'
                    if @v_ded_default_minimum is not null and @v_ded_default_minimum > @v_ded_fixed_amount 
						 set @v_temps = '; Final amount applied = Default ('+ ltrim(str(@v_ded_default_minimum))
					 else 
						set @v_temps = '; Final amount applied = (Fixed amt:'+ ltrim(str(@v_ded_fixed_amount)) 
              insert into t_payment_component(
                pct_id,invoice_id,pc_amount,comments)
                select 
                  (select pct_id from
                    payment_component_type where
                    pct_description like 'Post-Tax adj%'),
                  @v_invoice_id,
                  @v_deduction*-1,
                  @v_comment + @v_temps +') multiplied by Prorata factor'
print '3..'
              update t_netpay_tracker set
                net_pay = net_pay-@v_deduction where
                invoice_id = @v_invoice_id;
              insert into t_post_tax_deductions_applied(
                pcd_amount,ded_id,pcd_date,invoice_id) values(
                @v_deduction*-1,@v_ded_id,@enddate,@v_invoice_id)
			end
            else
			begin
              set @v_returncode=-999;
              insert into t_posttax_deductions_not_applied values(
                @v_ded_id,@v_contractor_supplier_no,@v_comment+'<Not Applied(1)>',@v_invoice_id)
              if @@error < 0 
			  begin
                rollback work
                return '-100050'
              end --                return(-100050);
            end
        end
        if @v_ded_fixed_amount = 0 or @v_ded_fixed_amount is null
	    begin
          set @v_comment='PTA: Type=IRD';
          if @v_ded_percent_gross > 0
            if @v_grosspay >= @v_ded_min_threshold_gross
              set @v_tempdec=@v_ded_percent_gross*@v_grosspay/100
          if @v_ded_percent_net > 0
            if @v_netpay >= @v_ded_min_threshold_gross
              set @v_tempdec2=@v_ded_percent_net*@v_netpay/100
          if @v_ded_percent_start_balance > 0
            if @v_netpay > (@v_multiplier*@v_ded_percent_start_balance*@v_ded_start_balance)/100
              set @v_tempdec3=(@v_ded_percent_start_balance*@v_ded_start_balance)/100
          if @v_tempdec is null 
            set @v_tempdec=0.0
          if @v_tempdec2 is null 
            set @v_tempdec2=0.0
          if @v_tempdec3 is null 
            set @v_tempdec3=0.0
          if @v_tempdec > 0 or @v_tempdec2 > 0 or @v_tempdec3 > 0
            if @v_ded_pay_highest_value = 1 
				if @v_tempdec >= @v_tempdec2
					begin
						set @v_IRD_ded_to_apply=@v_tempdec;
						if @v_IRD_ded_to_apply <= @v_tempdec3
						 begin
							 set @v_IRD_ded_to_apply=@v_tempdec3;
							set @v_comment=@v_comment+'; Evaluate highest which is Total%('+str(@v_tempdec3)+')'
						end
						else
							set @v_comment=@v_comment+'; Evaluate highest which is Gross%('+str(@v_tempdec)+')'
					end
				else
					begin
						set @v_IRD_ded_to_apply =@v_tempdec2;
						if @v_IRD_ded_to_apply <= @v_tempdec3
							begin
								set @v_IRD_ded_to_apply =@v_tempdec3;
								set @v_comment =@v_comment+'; Evaluate highest whcih is Total%('+str(@v_tempdec3)+')'
							end
						else
							set @v_comment =@v_comment+'; Evaluate highest which is Net%('+str(@v_tempdec2)+')'
					end
            else
              if(@v_tempdec3 <= @v_tempdec or @v_tempdec = 0) and(@v_tempdec3 <= @v_tempdec2 or @v_tempdec2 = 0) and(@v_tempdec3 > 0)
				begin
					set @v_IRD_ded_to_apply =@v_tempdec3;
					set @v_comment =@v_comment+'; Evaluate lowest which is Total%('+str(@v_tempdec3)+')'
		        end 
              else if(@v_tempdec <= @v_tempdec2 or @v_tempdec2 = 0) and(@v_tempdec <= @v_tempdec3 or @v_tempdec3 = 0) and (@v_tempdec > 0)
			    begin
					set @v_IRD_ded_to_apply =@v_tempdec;
					set @v_comment =@v_comment+'; Evaluate lowest which is Gross%('+str(@v_tempdec)+')'
			    end
              else if(@v_tempdec2 <= @v_tempdec or @v_tempdec = 0) and(@v_tempdec2 <= @v_tempdec3 or @v_tempdec3 = 0) and(@v_tempdec2 > 0)
				begin
					set @v_IRD_ded_to_apply =@v_tempdec2;
					set @v_comment =@v_comment+'; Evaluate lowest which is Net%'+str(@v_tempdec2)+')'
				end
              else
                set @v_comment =@v_comment+'; <Cannot find lowest value. Probable data entry error>'

          if(@v_IRD_ded_to_apply = 0 or @v_IRD_ded_to_apply is null) or(@v_netpay < @v_IRD_ded_to_apply*@v_multiplier)
		    if @v_ded_default_minimum <= @v_netpay and @v_ded_default_minimum > 0
				begin
					set @v_IRD_ded_to_apply =@v_ded_default_minimum;
					set @v_comment =@v_comment+'<***Dflt min overrides highest/lowest:'+str(@v_ded_default_minimum)+'***>'
				end
            else
				begin
					set @v_IRD_ded_to_apply=0.0;
					set @v_comment =@v_comment+'<Not applied(2), and default too large>'
				end
          else
			begin
				if @v_netpay >= @v_IRD_ded_to_apply*@v_multiplier
					 set @v_comment =@v_comment+'<OK! Apply value on the left multiplied by '+str(@v_multiplier)+'>'
				else
					set @v_comment =@v_comment+'<Value at left not applied(3): Net pay too small>'
            end
          set @v_deduction =@v_IRD_ded_to_apply*@v_multiplier;
          set @v_comment =@v_comment+'; Net='+
            str(@v_netpay)+'; Gross='+
            str(@v_grosspay)+'; ID='+
            str(@v_ded_id)+'; NetThresh=n.a.'+'; GrossThresh='+
            str(@v_ded_min_threshold_gross)+str(@v_ded_id)+'; DfltMin='+
            str(@v_ded_default_minimum)+'; Period='+
            @v_ded_type_period+'; Prorata ='+
            str(@v_multiplier)+'; Net%='+
            str(@v_ded_percent_net)+'; Gross%='+
            str(@v_ded_percent_gross)+'; Total%='+
            str(@v_ded_percent_start_balance)+'; Total='+
            str(@v_ded_start_balance);
          if @v_deduction <> 0 and @v_deduction is not null and @v_netpay >= @v_deduction
		  begin
            if @v_deduction > @v_ded_start_balance
		    begin
              set @v_deduction =@v_ded_start_balance;
              set @v_comment =@v_comment+'; <Final amountt applied=end balance> '
            end
            select @v_pcfaker = max(pc_id) from t_payment_component;
            if @v_deduction is null
			begin
              set @t_errmsg='-1'+','+
                convert(char,@v_contractor_supplier_no)+','+
                convert(char,@v_ded_id)+','+
                @v_ded_description
              return @t_errmsg
            end
            insert into t_payment_component(
              pct_id,invoice_id,pc_amount,comments)
              select 
                (select pct_id from
                  payment_component_type where
                  pct_description like 'Post-Tax adj%'),
                @v_invoice_id,
                @v_deduction*-1,
                @v_comment
            update t_netpay_tracker set
              net_pay = net_pay-@v_deduction where
              invoice_id = @v_invoice_id;
            insert into t_post_tax_deductions_applied(
              pcd_amount,ded_id,pcd_date,invoice_id) values(
              @v_deduction*-1,@v_ded_id,@enddate,@v_invoice_id)
		  end
         else
			begin
				set @v_returncode=-999;
				insert into t_posttax_deductions_not_applied values(
				@v_ded_id,@v_contractor_supplier_no,@v_comment,@v_invoice_id);
				if @@error < 0 
				 begin
					rollback work
					 return '-100050'
				end --              return(-100050);
			end
       end
      end
      set @v_tempcount =@v_tempcount+1
    end
    close c_ptd
	DEALLOCATE c_ptd
  end
  close c_contractor
select convert(varchar,@v_returncode)
  return convert(varchar,@v_returncode)
/*!
exception --  return(@v_returncode)
  when others then
    rollback work;
    resignal;
    return '-1'
--  return(-1);*/
end
GO
