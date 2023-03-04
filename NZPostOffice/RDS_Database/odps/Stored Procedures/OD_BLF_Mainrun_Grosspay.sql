
CREATE procedure [odps].[OD_BLF_Mainrun_Grosspay](
        @incontract_no int,
        @inSequence_no int,
        @inContractor_no int,
        @inContractorStart datetime,
        @inContractorEnd datetime,
        @inPayPeriod_Start datetime,
        @inPayPeriod_End datetime,
        @run_id int,
        @inRenewalStart datetime,
        @inRenewalEnd datetime,
        @v_contractor_contract_start datetime
    )
as
begin
	--..............................................................--
	--Author: Rex Bustria                                           --
	--Function: Computes the gross pay                              --
	--..............................................................--
	-- Notes
	--   1  If the contractor's actual start or end date lie outside the pay period,
	--      the pay period start or end date is passed to this procedure as the 
	--      contractor start or end date.
	--.............................................................................
	--
        -- TJB  RPCR_054 Apr-2013: OD_BLF_Mainrun_Grosspay (v2)
        --      Changed piece rate handling from 4 fixed suppliers to variable number of suppliers
        --      See OD_BLF_Mainrun_Grosspay_Piecerates.
        --
        -- TJB  RPCR_050 Feb-2013: Allowance calculation fix
        --      Added additional condition to calculated prorata multiplier 
        --      when an allowance starts during the pay period.
        --      Added test to see if there's also a contractor change, and if so 
        --      check to see if the contractor starts later than the allowance.
        --
	-- TJB  RPI_029   June-2011
	--      Merged RPCR_017 and RPCR_021 changes
	--
	-- TJB  RPCR_021  Sept-2010
	--      Added alt_key to t_payment_component
	--
	-- TJB  RPCR_017  July-2010
	--      Added ca_approved condition
	--
	-- TJB  RD7_0031  May 2009
	--      Cosmetic/readability changes only
	--
	-- TJB  SR4684  June 2006
	-- TJB  February 2007
	-- Fix bug with payroll calculation.  See notes related to v_multiplier_old.
	-- Added comments to section determining multipliers and other places
	--
	-- Add handling for Parcel Post 
	-- set implicit_transactions on
	--
	
  -- Declare heaps of things here
  declare @v_Multiplier              numeric(15,10), --.prorate factor for current renewal
          @v_Multiplier2             numeric(15,10), --.prorate factor for the previous renewal
          @v_PeriodDiff              numeric(12,2),  --.days between period start and period end
          @v_Contract_Payment_Value  numeric(12,2),  --.contract payment value
          @v_Payment_Value_old       numeric(12,2),  --.contract payment value for old renewal
          @v_Frequency_Adjustments   numeric(12,2),  --.as it says
          @v_Contract_Adjustments    numeric(12,2),  --.as it says
          @v_Contract_Allowance      numeric(12,2),  --.as it says
          @v_Grosspay                numeric(12,2),  --.as it says
          @v_ParcelPost              numeric(12,2),  --.parcel post amount
          @v_CourierPost             numeric(12,2),  --.courier post amount
          @v_AdPost                  numeric(12,2),  --.adpost amount
          @v_XP                      numeric(12,2),  --.adpost amount
          @v_PiecerateStartDate      datetime,       --.courier/adpost start date (beg. of the month instead of pay period start)
          @v_PiecerateEndDate        datetime,       --.courier/adpost end date (end of the month instead of pay period end)
          @v_PieceRate               numeric(12,2),  --.courierpost + adpost
          @v_InvoiceNumber           int,            --.invoice number(generated)
          @v_Tax_Rate                numeric(12,2),  --.the applicable tax rate
          @v_NextContractorStart     datetime,       --.as it says
          @v_PreviousContractorStart datetime,       --.as it says
          @v_UseOldRenewalValueOnly  char(1),        --.as it says
          @v_UseBothRenewals         char(1),        --.as it says
          @v_Case                    int,            --.prorate case advisor
          @v_RenewalAndPayStartDiff  int,
          @v_temp_dec                numeric(12,2),
          @v_pcfaker                 int,
          @v_multiplier_old          numeric(15,10); -- Multiplier to use for previous contract in Frequency Adjustment
                                                     -- calculation (see note in that section) - TJB  Feb-2007
  
  declare @v_result                  numeric(12,2)   -- OD_BLF_Mainrun_Grosspay_Piecerates result


  --********************** Set initial values ********************--

  select @v_UseOldRenewalValueOnly='N'
  select @v_UseBothRenewals='N'
  select @v_Grosspay=0
  select @v_perioddiff=datediff(day,@inPayPeriod_Start,@inPayPeriod_End)+1.0
  --
  -- See Paycomp max PK
  --  select "count"(*) into v_pcfaker from odps.t_payment_component;
  if @v_pcfaker is null
    select @v_pcfaker=0


  --***************** Check the dates passed ********************--

  if @inContractorStart is null or @inContractorEnd is null
  begin
      return (-100000100)
  end


  --****************** GET CONTRACTOR TAX RATE *******************--

  select @v_Tax_Rate = odps.od_blf_getTaxRate(@inContractor_no,@inContractorEnd) 

  if @v_Tax_Rate < 0 or @@ERROR < 0
  begin
      return (-100000120)
  end


  --****************** GET INVOICE NUMBER ************************--

  select @v_InvoiceNumber = max(invoice_id)+1 
    from t_payment

  if @@ERROR < 0
  begin
      return (-100000130)
  end

  if @v_InvoiceNumber is null
    select @v_InvoiceNumber=1


  --****************** DETERMINE RENEWALs TO USE *****************--   
  -- (for prorating annualised amounts)
  --
  -- PBY 07-08-2002 SR#4443 Set the initial value
  set @v_Multiplier2=0;
  
  -- Determine if we should use the old renewal ONLY
  if (@inRenewalStart is null) 
  or (@inRenewalStart between @inPayPeriod_Start and @inPayPeriod_End
      and @inContractorEnd < @inRenewalStart) 
  or (@inRenewalStart > @inContractorEnd)
  begin
      select @v_UseOldRenewalValueOnly = 'Y' --.Pay using the previous renewal rates
  end

  --Determine if we should use BOTH the old and new renewals here!
  if  @inRenewalStart is not null 
  and @inRenewalStart between @inPayPeriod_Start and @inPayPeriod_End 
  and @inContractorStart < @inRenewalStart 
  and (@inContractorEnd is null or @inContractorEnd > @inRenewalStart)
  begin
      select @v_UseBothRenewals = 'Y' --.Pay using the previous and the current renewal rates
  end

  --Determine Multipliers (for prorating annualised amounts)
  if @inRenewalStart <= @inPayPeriod_Start
  begin
      select @v_Case=1
      if @inContractorStart <= @inPayPeriod_Start
      begin
          select @v_Case=2
          if @inContractorEnd is null or @inContractorEnd >= @inPayPeriod_End
          begin
              select @v_Case=3
              if @inRenewalEnd >= @inPayPeriod_End or @inRenewalEnd is null
              begin
                  select @v_Case=4
                  select @v_Multiplier=1
              end
              else  -- inRenewalEnd < inPayPeriod_End
              begin
                  select @v_Case=5
                  select @v_Multiplier=(datediff(day,@inPayPeriod_Start,@inRenewalEnd)+1)/@v_Perioddiff
              end
          end
          else  -- @inContractorEnd < @inPayPeriod_End
          begin
              select @v_Case=6
              if @inRenewalEnd >= @inPayPeriod_End or @inRenewalEnd is null
              begin
                  select @v_Case=61
                  --Transfer pair with case 82
                  select @v_Multiplier=(datediff(day,@inPayPeriod_Start,@inContractorEnd)+1)/@v_Perioddiff
                  select @v_Multiplier2=0
              end
              else   -- @inRenewalEnd < @inPayPeriod_End
                if @inRenewalEnd <= @inContractorEnd
                  select @v_Multiplier=(datediff(day,@inPayPeriod_Start,@inRenewalEnd)+1)/@v_Perioddiff
                else
                  select @v_Multiplier=(datediff(day,@inPayPeriod_Start,@inContractorEnd)+1)/@v_Perioddiff
          end
      end
      else   -- inContractorStart > inPayPeriod_Start
      begin
          select @v_Case=7
          if @inContractorEnd is null or @inContractorEnd >= @inPayPeriod_End
          begin
              select @v_Case=8
              if @inRenewalEnd <= @inPayPeriod_End
              begin
                  select @v_Case=81
                  select @v_Multiplier=(datediff(day,@inContractorStart,@inRenewalEnd)+1)/@v_Perioddiff
              end
              else  -- inRenewalEnd > inPayPeriod_End
              begin
                  select @v_Case=82
                  --Transfer pair with case 61
                  select @v_Multiplier=(datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_Perioddiff
              end
          end
          else  -- inContractorEnd < inPayPeriod_End
          begin
              select @v_Case=9
              if @inRenewalEnd <= @inPayPeriod_End
              begin
                  select @v_Case=811
                  select @v_Multiplier=(datediff(day,@inContractorStart,@inRenewalEnd)+1)/@v_Perioddiff
              end
              else -- inRenewalEnd > inPayPeriod_End
              begin
                  select @v_Case=91
                  select @v_Multiplier=(datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_Perioddiff
              end
          end
      end
  end
  else   -- inRenewalStart > inPayPeriod_Start
  begin
      select @v_Case=10
      if @inContractorStart <= @inPayPeriod_Start
      begin
          select @v_Case=11
          if @inContractorEnd is null or @inContractorEnd >= @inPayPeriod_End
          begin
              select @v_Case=12
              if @inRenewalEnd is null or @inRenewalEnd >= @inPayPeriod_End
              begin
                  select @v_Case=121
                  select @v_Multiplier=(datediff(day,@inRenewalStart,@inPayPeriod_End)+1)/@v_Perioddiff
                  select @v_Multiplier2=(@v_Perioddiff-(datediff(day,@inRenewalStart,@inPayPeriod_End)+1))/@v_Perioddiff
              end
              else  -- inRenewalEnd < inPayPeriod_End
              begin
                  select @v_Case=122
                  select @v_Multiplier=(datediff(day,@inRenewalStart,@inRenewalEnd)+1)/@v_Perioddiff
              end
          end
          else -- inContractorEnd < inPayPeriod_End
          begin
              select @v_Case=13
              if @inRenewalEnd is null or @inRenewalEnd >= @inContractorEnd
              begin
                  --Transfer pair with case 162
                  select @v_Case=131
                  -- 
                  select @v_Multiplier=(datediff(day,@inPayPeriod_Start,@inContractorEnd)+1)/@v_Perioddiff
                  select @v_Multiplier2=0
              end
              else   -- inRenewalEnd < inContractorEnd
              begin
                  select @v_Case=132
                  select @v_Multiplier=(datediff(day,@inRenewalStart,@inRenewalEnd)+1)/@v_Perioddiff
              end
          end
      end
      else
      begin
          select @v_Case=14
          if @inContractorStart <= @inRenewalStart
          begin
              select @v_Case=15
              if @inContractorEnd is null or @inContractorEnd >= @inPayPeriod_End
              begin
                  select @v_Case=16
                  if @inRenewalEnd is null or @inRenewalEnd <= @inPayPeriod_End
                  begin
                      select @v_Case=161
                      --Transfer pair with case 131
                      select @v_Multiplier=(datediff(day,@inRenewalStart,@inPayPeriod_End)+1)/@v_Perioddiff
                  end
                  else  -- inRenewalEnd > inPayPeriod_End
                  begin
                      select @v_Case=162
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_Perioddiff
                  end
              end
              else  -- inContractorEnd < inPayPeriod_End
              begin
                  select @v_Case=17
                  if @inRenewalEnd is null or @inRenewalEnd <= @inPayPeriod_End
                  begin
                      select @v_Case=171
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_Perioddiff
                  end
                  else  -- inRenewalEnd > inPayPeriod_End
                  begin
                      select @v_Case=172
                      --Changed from v_Multiplier=(days(inContractorStart,inRenewalEnd)+1)/v_Perioddiff to
                      --13/08/1999
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_Perioddiff
                  end
              end
          end
          else -- inContractorStart > inRenewalStart
          begin
              select @v_Case=18
              if @inContractorEnd is null or @inContractorEnd >= @inPayPeriod_End
              begin
                  select @v_Case=19
                  if @inRenewalEnd is null or @inRenewalEnd <= @inPayPeriod_End
                  begin
                      select @v_Case=191
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_Perioddiff
                  end
                  else  -- inRenewalEnd > inPayPeriod_End
                  begin
                      select @v_Case=192
                      --Changed from v_Multiplier=(days(inContractorStart,inRenewalEnd)+1)/v_Perioddiff to
                      --13/08/1999
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_Perioddiff
                  end
              end
              else   -- inContractorEnd < inPayPeriod_End
              begin
                  select @v_Case=20
                  if @inRenewalEnd is null or @inRenewalEnd >= @inContractorEnd
                  begin
                      select @v_Case=201
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_Perioddiff
                  end
                  else  -- inRenewalEnd < inContractorEnd
                  begin
                      select @v_Case=202
                      select @v_Multiplier=(datediff(day,@inContractorStart,@inRenewalEnd)+1)/@v_Perioddiff
                  end
              end
          end
      end
  end

  if @v_Multiplier <= 0 or @v_Multiplier is null
  begin
      select @v_Case = @v_Case * -1
      select @v_Multiplier = 0
  end


  --***************** CREATE A PAYMENT RECORD *****************--

  SET IDENTITY_INSERT odps.t_payment On  --2008

  insert into t_payment
  ( contractor_supplier_no,
    contract_no,
    contract_seq_number,
    invoice_id,			-- 2008
    pr_id, 
    invoice_date,
    witholding_tax_rate_applied,
    case_no
  ) 
  values
  (
    @inContractor_no,
    @inContract_No,
    @inSequence_no,
    @v_invoicenumber,	       -- 2008
    @run_id,
    @inPayPeriod_End,
    @v_Tax_Rate,
    @v_Case
  )

  if @@ERROR <> 0
  begin
      SET IDENTITY_INSERT odps.t_payment Off --2008
      return (-100000140)
  end

  SET IDENTITY_INSERT odps.t_payment Off --2008


  --************** CONTRACT PAYMENT VALUE ******************--

  if @v_UseOldRenewalValueOnly = 'N'
  begin
      --use current
      select @v_Contract_Payment_Value = sum((contract_renewals.con_renewal_payment_value*@v_multiplier)/12.0)  
        from rd.contract_renewals 
       where contract_renewals.contract_no = @incontract_no
         and contract_renewals.contract_seq_number = @inSequence_no

      if @v_UseBothRenewals = 'Y'    --also use previous
      begin
        select @v_Payment_value_old = sum((contract_renewals.con_renewal_payment_value*@v_multiplier2)/12.0) 
          from rd.contract_renewals 
         where contract_renewals.contract_no = @incontract_no
           and contract_renewals.contract_seq_number = @inSequence_no - 1
      end
  end
  else  --use previous only
  begin
      select @v_Contract_Payment_Value = sum((contract_renewals.con_renewal_payment_value*@v_multiplier)/12.0)
        from rd.contract_renewals 
       where contract_renewals.contract_no = @incontract_no
         and contract_renewals.contract_seq_number = @inSequence_no - 1
  end

  if @@ERROR < 0
  begin
      return (-100000165)
  end

  if @v_Contract_Payment_Value is null
      select @v_Contract_Payment_Value=0

  if @v_Payment_value_old is null
      select @v_Payment_value_old=0

  select @v_Contract_Payment_Value = @v_Contract_Payment_Value + @v_Payment_value_old
  
      
  --************** FREQUENCY ADJUSTMENTS *******************--
  -- this is  an annualised amount                        --
  -- all 'fd_adjustment_amount' was replaced with 'fd_amount_to_pay'
  -- ie. Benchmark increase has been replaced with amount payable
  -- refer to observation id - 12 
  -- Changed by Jayas on 19/12/97 

  if @v_UseOldRenewalValueOnly = 'N'
  begin
      select @v_pcfaker = count(*) from odps.t_payment_component
	  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008   

      insert into odps.t_payment_component                                 --#1
          (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string)
          select /*!isnull(pct_id,(select nat_freqadj_defaultcomptype from odps."national" 
                                    where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd)))),
                    @v_InvoiceNumber, (sum(isnull(fd_amount_to_pay,0))*  */
                 isnull(pct_id,(select nat_freqadj_defaultcomptype from odps."national"
                                 where nat_id = (select odps.OD_BLF_getwhichnational(@inContractorEnd)))),
                 @v_InvoiceNumber,
                     -- TJB 15-July-2004 SR4625: New calculation
                     -- If there''s an adjustment during the pay period and there is also a change in contractor, 
                     -- prorate the amount between them according to the portion of the period it applies to each.
                     -- Otherwise the adjustment applies to the whole period and the previously-calculated 
                     -- scaling factor can be used.
                     -- Note: A contractor will be selected only if his/her end date is within the pay period.
                     --       The adjustment date may then either be before the contractor starts, or after 
                     --       he/she starts and before he/she ends (though the test for the end is redundant).
                     -- (Also changed the prorata displayed value in the comment field)
                (sum(isnull(fd_amount_to_pay,0))*
                         (case when fd_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                               then case when fd_effective_date between @inContractorStart and @inContractorEnd 
                                         then (datediff(day,fd_effective_date,@inContractorEnd)+1)/@v_perioddiff
                                         else (datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_perioddiff
                                    end
                               else @v_multiplier
                          end))/12.0,
                (case when fd_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                      then 'Arrears:' 
                      else '' 
                 end)
                 + 'Freq Adjust:For the period, current renewal'
                 +', Effective: '+ convert(varchar,fd_effective_date,106)
                 +', Annual amount: '+ convert(varchar,isnull(fd_amount_to_pay,0))
                 +', Prorata: '+ convert(varchar,round(case when fd_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                                                            then case when fd_effective_date between @inContractorStart and @inContractorEnd 
                                                                      then (datediff(day,fd_effective_date,@inContractorEnd)+1)/@v_perioddiff
                                                                      else (datediff(day,@inContractorStart,@inContractorEnd)+1)/@v_perioddiff
                                                                 end
                                                            else @v_multiplier
                                                       end,10)),
                 fd_effective_date,
                 ext=(select top 1  fd.fd_change_reason 
                        from rd.frequency_distances as fd 
                       where fd.fd_effective_date = rd.frequency_adjustments.fd_effective_date and
                             fd.contract_no = rd.frequency_adjustments.contract_no) 
            from rd.frequency_adjustments 
           where (contract_no = @inContract_no) and
                 (contract_seq_number = @inSequence_no) and
                 (fd_confirmed = 'Y') and
                 (fd_effective_date <= @inContractorEnd) and 
                 ((select nat_freqadj_defaultcomptype from odps."national" 
                    where nat_id = (select odps.OD_BLF_getwhichnational(@inContractorEnd))) is not null)
           group by pct_id, 
                    fd_effective_date,
                    fd_amount_to_pay,
                    contract_no,
                    contract_seq_number,
                    fd_confirmed,
                    fd_unique_seq_number,
                    fd_adjustment_amount,
                    fd_paid_to_date,
                    fd_bm_after_extn,
                    sf_key,
                    rf_delivery_days         

      if @@ERROR <> 0
      begin
          return (-100000170)
      end

      select @v_pcfaker = count(*) from odps.t_payment_component

      DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)

      insert into odps.t_payment_component                                --#2
          (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string)
          select isnull(pct_id,(select nat_freqadj_defaultcomptype from odps."national" 
                                 where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd)))),
                 @v_InvoiceNumber,
                 (sum(isnull(fd_amount_to_pay,0))*datediff(day,fd_effective_date,@inContractorStart))/365.0,
                 'Arrears:Frequency Adjustment, current renewal'
                    +', Effective:'+convert(varchar,fd_effective_date,106)
                    +', Days overdue:'+convert(varchar,datediff(day,fd_effective_date,@inContractorStart))
                    +', Annual amount: '+convert(varchar,isnull(fd_amount_to_pay,0)),
                 fd_effective_date,
                 'Extension Arrears' 
            from rd.frequency_adjustments 
           where (contract_no = @inContract_no) and
                 (contract_seq_number = @inSequence_no) and
                 (fd_paid_to_date is null) and
                 (fd_confirmed = 'Y') and
                 (fd_effective_date >= @v_contractor_contract_start) and
                 (fd_effective_date < @inContractorStart) and
                 (fd_effective_date <= @inContractorEnd) and -- TJB  Dec 2005 SR4677
                 (fd_effective_date < @inPayPeriod_Start)
           group by pct_id,
                    fd_effective_date,
                    fd_amount_to_pay,
                    contract_no,
                    contract_seq_number,
                    fd_unique_seq_number,
                    fd_adjustment_amount,
                    fd_paid_to_date,
                    fd_bm_after_extn,
                    fd_confirmed,
                    sf_key,
                    rf_delivery_days

      if @@ERROR <> 0
      begin
          return (-100000171)
      end
  end

  if @v_UseOldRenewalValueOnly = 'Y' or @v_UseBothRenewals = 'Y'
  begin
      if @v_UseOldRenewalValueOnly = 'Y' 
          set @v_multiplier_old=@v_multiplier
      else
          set @v_multiplier_old=@v_multiplier2

      select @v_pcfaker = count(*) from t_payment_component

      DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008 

      insert into t_payment_component                                --#3
          ( pct_id, invoice_id, pc_amount, comments, misc_date, misc_string)
          select isnull(pct_id,(select nat_freqadj_defaultcomptype from odps."national" 
                                 where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd)))),
                 @v_InvoiceNumber,
                 (sum(isnull(fd_amount_to_pay,0))*
                     (case when fd_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                           then (case when fd_effective_date between @inPayPeriod_Start and @inRenewalStart 
                                      then (datediff(day,fd_effective_date,@inRenewalStart)/@v_perioddiff)
                                      else ((datediff(day,fd_effective_date,@inPayPeriod_End)+1)/@v_perioddiff)
                                 end)
                           else @v_multiplier_old
                      end))/12.0,
                 (case when fd_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                       then 'Arrears:' 
                       else '' 
                  end)
                  +'Frequency Adjustment, previous renewal'
                  +' / Effective:'+convert(varchar,fd_effective_date,106)
                  +' / Annual amount: '+convert(varchar,isnull(fd_amount_to_pay,0))
                  +', Prorata: '+convert(varchar,round(case when fd_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                                                            then ((datediff(day,fd_effective_date,@inPayPeriod_End)+1)/@v_perioddiff)
                                                            else @v_multiplier_old
                                                       end,10)),
                 fd_effective_date,
                     -- PBY 04/06/2002 SR#4397 Retrieve extension reason from frequency_distances.fd_change_reason
                     --'Extension ' || 
                     -- (if fd_effective_date between inPayPeriod_Start and inPayPeriod_End then 
                     --    string(fd_effective_date) || ' to ' || string(inPayPeriod_End) 
                     -- else '' 
                     -- endif)         
                     -- PBY 07-08-2002 SR#4443 Added ",CONTRACT_NO" to the group_by clause
                 ext=(select top 1 fd.fd_change_reason 
                        from rd.frequency_distances as fd 
                       where fd.fd_effective_date = rd.frequency_adjustments.fd_effective_date and
                             fd.contract_no = rd.frequency_adjustments.contract_no) 
            from rd.frequency_adjustments 
           where (contract_no = @inContract_no) and
                 (contract_seq_number = @inSequence_no-1) and
                 (fd_confirmed = 'Y') and
                 (fd_effective_date <= @inContractorEnd)
           group by pct_id,
                    fd_effective_date, 
                    fd_amount_to_pay, 
                    contract_no,
                    contract_seq_number,
                    fd_unique_seq_number,
                    fd_adjustment_amount,
                    fd_paid_to_date,
                    fd_bm_after_extn,
                    fd_confirmed,
                    sf_key,
                    rf_delivery_days

          select @v_pcfaker = count(*) from odps.t_payment_component

	  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008 

      insert into odps.t_payment_component				--#4
          (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string)
          select isnull(pct_id,(select nat_freqadj_defaultcomptype from odps."national" 
                                 where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd) ))),
                 @v_InvoiceNumber,
                 (sum(isnull(fd_amount_to_pay,0))*datediff(day,fd_effective_date,@inContractorStart))/365.0,
                 'Arrears:Frequency Adjustment, previous renewal'
                    +' *** Effective:'+convert(varchar,fd_effective_date,106)
                    +' *** Days overdue:'+convert(varchar,datediff(day,fd_effective_date,@inContractorStart))
                    +' *** Annual amount: '+convert(varchar,isnull(fd_amount_to_pay,0)),
                 fd_effective_date,
                 'Extension Arrears' 
            from rd.frequency_adjustments 
           where (contract_no = @inContract_no) and
                 (contract_seq_number = @inSequence_no-1) and
                 (fd_paid_to_date is null) and
                 (fd_confirmed = 'Y') and
                 (fd_effective_date < @inContractorStart) and
                 (fd_effective_date >= @v_contractor_contract_start)
           group by pct_id,
                    fd_effective_date,
                    fd_amount_to_pay,
                    contract_no,
                    contract_seq_number,
                    fd_unique_seq_number,
                    fd_adjustment_amount,
                    fd_paid_to_date,
                    fd_bm_after_extn,
                    fd_confirmed,
                    sf_key,
                    rf_delivery_days

      if @@ERROR <> 0
      begin
          return (-100000175)
      end
  end


  --************** CONTRACT ADJUSTMENTS *******************--

  select @v_pcfaker = count(*) from odps.t_payment_component

  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008 

  insert into odps.t_payment_component			--#5
     (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string)
    select isnull(pct_id,(select nat_ContAdj_DefaultCompType from "national" 
                           where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd)))),
           @v_InvoiceNumber,
           sum(isnull(ca_amount,0)),
           'Contract Adj:Current renewal'
               +' *** Occurred '+convert(varchar,ca_date_occured,106)
               +' *** Amount:'+convert(varchar,isnull(ca_amount,0)),
           ca_date_occured,
           isnull(ca_reason,'Contract Adjustment') 
      from rd.contract_adjustments 
     where (contract_no = @inCOntract_no) and
           (ca_confirmed = 'Y') and
           (ca_date_occured between @v_contractor_contract_start and @inContractorEnd) and
           (ca_date_paid is null)
     group by pct_id,
              ca_date_occured,
              ca_amount,
              ca_reason,
              ca_key,
              contract_no,
              contract_seq_number,
              ca_date_paid,
              ca_confirmed

  if @@ERROR <> 0
  begin
      return (-100000180)
  end


  --************** CONTRACT ALLOWANCES *******************--

  select @v_pcfaker = count(*) from odps.t_payment_component

  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008 

      -- TJB RPCR_050 Feb-2013
      -- Added additional condition to calculated prorata multiplier 
      -- when an allowance starts during the pay period.
      -- Added test to see if there's also a contractor change, and if so 
      -- check to see if the contractor starts later than the allowance.

      -- TJB RPCR_021 Sept-2010
      -- Add copy alt_key to t_payment_component

  if @v_UseBothRenewals = 'Y'
      insert into t_payment_component
         (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string ,alt_key)
        select isnull(pct_id,(select nat_ContAllow_DefaultComptype from "national" 
                               where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd)))),
               @v_InvoiceNumber,
               sum(isnull(contract_allowance.ca_annual_amount,0))*
                   (case when ca_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                         then case when ca_effective_date >= @inContractorStart
                                   then ((datediff(day,ca_effective_date,@inPayPeriod_End)+1)/@v_perioddiff)
                                   else ((datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_perioddiff)
                              end
                         else (@v_multiplier+@v_multiplier2)
                    end)/12.0,
               'Contract allowance: For the period'
                  +' *** Effective '+convert(varchar,ca_effective_date,106)
                  +' *** Annual amount: '+convert(varchar,isnull(ca_annual_amount,0))
                  +', Prorata: '+convert(varchar,round(case when ca_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                                                            then case when ca_effective_date >= @inContractorStart
                                                                      then ((datediff(day,ca_effective_date,@inPayPeriod_End)+1)/@v_perioddiff)
                                                                      else ((datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_perioddiff)
                                                                 end
                                                            else @v_multiplier
                                                       end,10)),
               ca_effective_date,
               isnull(ca_notes,'Contract Allowance') 
             , alt_key
          from rd.contract_allowance 
         where contract_allowance.contract_no = @inContract_no 
           and contract_allowance.ca_effective_date <= @inContractorEnd 
           and (select nat_freqadj_defaultcomptype from odps."national" 
                  where nat_id = (select odps.OD_BLF_getwhichnational(@inContractorEnd))) is not null 
           and contract_allowance.ca_approved = 'Y'        -- TJB RPCR_017 July-2010: added
         group by pct_id,ca_effective_date,ca_annual_amount,ca_effective_date,ca_notes,alt_key,contract_no,ca_paid_to_date

  else  -- @v_UseBothRenewals = 'N'  (actually != 'Y')
      insert into odps.t_payment_component
         (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string, alt_key)
         select isnull(pct_id,(select nat_ContAllow_DefaultComptype from odps."national" 
                                where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd) ))),
                @v_InvoiceNumber,
                sum(isnull(contract_allowance.ca_annual_amount,0))* 
                   (case when ca_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                         then case when ca_effective_date >= @inContractorStart
                                   then ((datediff(day,ca_effective_date,@inPayPeriod_End)+1)/@v_perioddiff)
                                   else ((datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_perioddiff)
                              end
                         else @v_multiplier
                    end)/12.0,
               'Contract allowance: For the period'
                  +' *** Effective '+convert(varchar,ca_effective_date,106)
                  +' *** Annual amount: '+convert(varchar,isnull(ca_annual_amount,0))
                  +', Prorata: ' + convert(varchar,round(case when ca_effective_date between @inPayPeriod_Start and @inPayPeriod_End 
                                                              then case when ca_effective_date >= @inContractorStart
                                                                        then ((datediff(day,ca_effective_date,@inPayPeriod_End)+1)/@v_perioddiff)
                                                                        else ((datediff(day,@inContractorStart,@inPayPeriod_End)+1)/@v_perioddiff)
                                                                   end
                                                              else @v_multiplier
                                                              end,10)),
               ca_effective_date,
               isnull(ca_notes,'Contract Allowance') 
             , alt_key
          from rd.contract_allowance 
         where contract_allowance.contract_no = @inContract_no 
           and contract_allowance.ca_effective_date <= @inContractorEnd 
           and (select nat_freqadj_defaultcomptype from odps."national" 
                  where nat_id = (select odps.OD_BLF_getwhichnational(@inContractorEnd))) is not null
           and contract_allowance.ca_approved = 'Y'        -- TJB RPCR_017 July-2010: added
         group by pct_id,ca_effective_date,ca_annual_amount,ca_effective_date,ca_notes,alt_key,contract_no,ca_paid_to_date
	
  if @@ERROR < 0
  begin
      return (-100000190)
  end

  select @v_pcfaker = count(*) from t_payment_component

  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008 

  insert into t_payment_component
     (pct_id, invoice_id, pc_amount, comments, misc_date, misc_string, alt_key)
    select isnull(pct_id,(select nat_ContAllow_DefaultComptype from odps."national" 
                           where nat_id = (select odps.od_blf_getwhichnational(@inContractorEnd)))),
           @v_InvoiceNumber,
           sum(isnull(contract_allowance.ca_annual_amount,0))*(datediff(day,ca_effective_date,@inContractorStart)/365.0),
           'Arrears:Contract Allowance,'
              +' Effect '+convert(varchar,ca_effective_date,106)
              +' *** Days overdue:'+convert(varchar,datediff(day,ca_effective_date,@inContractorStart))
              +' *** Annual amount: '+convert(varchar,isnull(ca_annual_amount,0)),
           ca_effective_date,
           isnull(ca_notes,'Contract Allowance Arrears') 
         , alt_key
      from rd.contract_allowance 
     where contract_allowance.contract_no = @inContract_no 
       and contract_allowance.ca_effective_date <= @inContractorEnd 
       and contract_allowance.ca_effective_date < @inPayPeriod_Start 
       and ca_paid_to_date is null
       and contract_allowance.ca_approved = 'Y'        -- TJB RPCR_017 July-2010: added
     group by pct_id,
              ca_effective_date,
              ca_annual_amount,
              ca_effective_date,
              ca_notes,
              alt_key,
              contract_no,
              ca_paid_to_date

  if @@ERROR <> 0
  begin
      return (-100000194)
  end

  select @v_PiecerateStartDate = odps.OD_MiscF_GetFirstDayofMonth(@inContractorEnd)

  if @@ERROR <> 0
  begin
      return (-100000200)
  end

  select @v_PiecerateEndDate = odps.OD_MiscF_getlastdayofmonth(@inContractorEnd) 

  if @@ERROR <> 0
  begin
      return (-100000210)
  end


  --*********************** Piece Rates *************************--

  -- PBY 07/08/2002 SR#4443 
  --    Passed in PayPeriodStart & Ends instead of the contractor start & end dates
  -- PBY 18/08/2002 SR#4446 
  --    added contractor_end date to the query

  -- TJB  RPCR_054  Apr-2013
  --    Changed piece rates calculation to do all suppliers at once, not hard-coded 4.
  --    Note: @v_result only used to return status (>=0 = Success, <0 = error code)
  --    [6th parameter below ('A') no longer used]
  
  declare @inSequence_no_1 int

  set @inSequence_no_1=@inSequence_no - 1

  if @v_UseOldRenewalValueOnly = 'N'
      execute @v_result = odps.OD_BLF_Mainrun_Grosspay_Piecerates 
        @incontract_no,
        @inSequence_no,
        @inPayPeriod_Start,
        @inPayPeriod_End,
        @v_InvoiceNumber,
        'A',
        @v_contractor_contract_start,
        @inContractorEnd,
        @inContractor_no 
  else
      execute @v_result = odps.OD_BLF_Mainrun_Grosspay_Piecerates 
        @incontract_no, 
        @inSequence_no_1 ,  -- @inSequence_no - 1 ,
        @inPayPeriod_Start,
        @inPayPeriod_End,
        @v_InvoiceNumber,
        'A',
        @v_contractor_contract_start,
        @inContractorEnd,
        @inContractor_no
      
  if @@ERROR <> 0
  begin
      return (-100000211)
  end

  if @v_result is null
      select @v_result = 0

  if @v_result < 0
  begin
      return (@v_result)
  end


  --***************** Finished: Return results ******************--
  --***************** in t_payment_component   ******************--

  select @v_pcfaker = count(*) from odps.t_payment_component

  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008 

  insert into odps.t_payment_component(
          pct_id,
          invoice_id,
          pc_amount,
          comments)
   select top 1  
          (select min(pct_id) 
             from payment_component_type 
            where pct_description like 'Contract payment value%'),
          @v_InvoiceNumber,
          @v_Contract_Payment_Value,
          'Payment val ' + '(prorata 1='+convert(varchar,@v_multiplier)+'='
                         + convert(varchar,convert(int,round(@v_multiplier*@v_perioddiff,0)))
                         + ' days)'
                         + ' CCS='+convert(varchar,@v_contractor_contract_start,106)
                         + ' CS=' +convert(varchar,@inContractorStart,106)
                         + ' CE=' +convert(varchar,@inContractorEnd,106)
                         + ' RS=' +convert(varchar,@inRenewalStart,106)
                         + ' RE=' +convert(varchar,@inRenewalEnd,106)
                         + ' PS=' +convert(varchar,@inPayPeriod_Start,106)
                         + ' PE=' +convert(varchar,@inPayPeriod_End,106)
                         + ' Case='+convert(varchar,@v_Case)
                         + ' Prorata 2= '+convert(varchar,@v_multiplier2) 

  if @@ERROR <> 0
  begin
      return (-100000270)
  end

  -- This doesn''t appear to do anything useful since the value isn''t sent anywhere
  -- (but MAY result in an error code being returned)
  select @v_grosspay = sum(pc_amount) 
    from odps.t_payment_component;

  if @@ERROR < 0
  begin
      return (-100000280)
  end

  return (1)   -- Success
end