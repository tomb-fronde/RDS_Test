CREATE TABLE [rd].[contract_renewals] (
    [contract_no]                          INT             NOT NULL,
    [contract_seq_number]                  INT             NOT NULL,
    [con_start_date]                       DATETIME        NULL,
    [con_rates_effective_date]             DATETIME        NULL,
    [con_rg_code_at_renewal]               INT             NULL,
    [con_expiry_date]                      DATETIME        NULL,
    [con_start_pay_date]                   DATETIME        NULL,
    [con_last_paid_date]                   DATETIME        NULL,
    [con_processing_hours_per_week]        NUMERIC (6, 2)  NULL,
    [con_renewal_benchmark_price]          NUMERIC (10, 2) NULL,
    [con_renewal_payment_value]            NUMERIC (10, 2) NULL,
    [con_relief_driver_name]               VARCHAR (40)    NULL,
    [con_relief_driver_address]            VARCHAR (200)   NULL,
    [con_relief_driver_home_phone]         VARCHAR (15)    NULL,
    [con_date_last_assigned]               DATETIME        NULL,
    [con_acceptance_flag]                  VARCHAR (1)     NULL,
    [con_distance_at_renewal]              NUMERIC (10, 2) NULL,
    [con_no_customers_at_renewal]          SMALLINT        NULL,
    [con_no_rural_private_bags_at_renewal] SMALLINT        NULL,
    [con_no_other_bags_at_renewal]         SMALLINT        NULL,
    [con_no_private_bags_at_renewal]       SMALLINT        NULL,
    [con_no_post_offices_at_renewal]       SMALLINT        NULL,
    [con_no_cmbs_at_renewal]               SMALLINT        NULL,
    [con_no_cmb_custs_at_renewal]          SMALLINT        NULL,
    [con_del_hrs_week_at_renewal]          NUMERIC (6, 2)  NULL,
    [con_volume_at_renewal]                INT             NULL,
    [renewal_type]                         VARCHAR (20)    NULL,
    CONSTRAINT [contract_renewals_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_contract2] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no])
);


GO
CREATE NONCLUSTERED INDEX [ir_start]
    ON [rd].[contract_renewals]([con_start_date] DESC);


GO

CREATE TRIGGER [rd].[trig_NewRenewal2001] ON [rd].[contract_renewals]
WITH EXECUTE AS CALLER
FOR INSERT
/*******************************************************************
 * Modifications
 * 25 Jul 2021  TJB Frequencies & Vehicles 
 *        Re-wrote select queries for inserting override rates to allow for
 *        multiple vehicles per contract.  Required changing the override rate
 *        tables' primary keys to include the vehicle number.
 * 24 Jul 2021  TJB Frequencies & Vehicles 
 *        Added vehicle number (and missing wage rates) to inserted override rates
 * 22 May 2019  TJB   RPCR_129
 *        Add clause to insert into NVOR's SELECT conditions
 * 27 Oct 2016  TJB   Bugfix: 
 *        Add NVOR_Effective_date initialisation to AdRenewalRateDate
 *  8 Sep 2009  TJB   
 *        Bug in nDelHrs calculation
 * 21 Jul 2008  Metex bug fixes
 *        Changed "if @@error < 0 ..." to "if @@error = 0 ..."
 *******************************************************************/
AS
begin
    SET NOCOUNT ON
    SET CONCAT_NULL_YIELDS_NULL OFF

    declare @dStartDate datetime,
            @nNumRows int,
            @nDistance real,
            @nCustomers real,
            @nRuralBags real,
            @nOtherBags real,
            @nPrivateBags real,
            @nPostOffices real,
            @dRenewalARateDate datetime,
            @nCMBs real,
            @nCMBCusts real,
            @nDelHrs real,
            @nProcHrs real,
            @nVolume real,
            @nRGCode int,
            @nFreqs int,
            @dRenewalRateDate datetime,
            @dDate datetime,
            @nCount int,
            @nPaymentPrice numeric(10,2),
            @nFDAmount numeric(10,2),
            @dConStartDate datetime,
            @dConEndDate datetime,
            @nVehicle_number int
            
    declare @new_contract_no int,
            @new_contract_seq_number int,
            @new_con_rg_code_at_renewal int,
            @new_con_rates_effective_date datetime
            
    select  @new_contract_no = contract_no ,
            @new_contract_seq_number = contract_seq_number ,
            @new_con_rates_effective_date = con_rates_effective_date,
            @new_con_rg_code_at_renewal = con_rg_code_at_renewal 
      from inserted

    if @new_contract_seq_number > 1
    begin
        if @new_con_rg_code_at_renewal is null
            select @nRGCode = rg_code
              from rd.[contract] 
             where contract_no = @new_contract_no
        else
            select @nRGCode=@new_con_rg_code_at_renewal
            
        if @new_con_rates_effective_date is null
            select @dRenewalRateDate = max(nvr_rates_effective_date)
              from rd.non_vehicle_rate 
             where rg_code = @nRGCode
        else
            select @dRenewalARateDate=@new_con_rates_effective_date
            
        select @dConStartDate = non_vehicle_rate.nvr_contract_start,
               @dConEndDate = non_vehicle_rate.nvr_contract_end
          from rd.non_vehicle_rate 
         where non_vehicle_rate.rg_code = @nRGCode 
           and non_vehicle_rate.nvr_rates_effective_date = @dRenewalRateDate
               
        select @dStartDate = con_start_date
          from rd.contract_renewals 
         where contract_renewals.contract_no = @new_contract_no 
           and contract_renewals.contract_seq_number = (@new_contract_seq_number-1)
           
        select @nFreqs = count(*)
          from rd.route_frequency 
         where route_frequency.contract_no = @new_contract_no 
           and route_frequency.rf_active = 'Y'
           
            --set nFreqs=1
        select @nNumRows = count(*),
               @nDistance=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_distance_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum),
               @nCustomers=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_customers_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_of_boxes,0)),
               @nRuralBags=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_rural_private_bags_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_rural_bags,0)),
               @nOtherBags=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_other_bags_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_other_bags,0)),
               @nPrivateBags=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_private_bags_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_private_bags,0)),
               @nPostOffices=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_post_offices_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_post_offices,0)),
               @nCMBs=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_cmbs_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_cmbs,0)),
               @nCMBCusts=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_no_cmb_custs_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_no_cmb_customers,0)),
               @nDelHrs=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_del_hrs_week_at_renewal,0))/ count(*)) else 0 end)
                           +(case when @nFreqs > 0 then sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0))/@nFreqs else 0 end),
               @nProcHrs=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_processing_hours_per_week,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
               @nVolume=(case when  count(*) > 0 then(sum(isnull(contract_renewals.con_volume_at_renewal,0))/ count(*)) else 0 end)
                           +sum(isnull(frequency_distances.fd_volume,0)),
               @nPaymentprice = contract_renewals.con_renewal_payment_value
          from rd.[contract] 
                        join rd.contract_renewals 
                             on  [contract].contract_no = contract_renewals.contract_no 
                             and [contract].con_active_sequence = contract_renewals.contract_seq_number 
                        join rd.route_frequency as rou 
                             on [contract].contract_no = rou.contract_no
                        left outer join frequency_distances 
                             on (rou.contract_no = frequency_distances.contract_no 
                                 and frequency_distances.fd_effective_date >= @dStartDate 
                                 and @dStartDate is not null) 
              -- TJB  RD7_0046  Sept2009: removed join and added Where clause
              --         join standard_frequency as sta on rou.sf_key = sta.sf_key,
              , rd.standard_frequency  
                        join rd.rate_days 
                             on standard_frequency.sf_key = rate_days.sf_key 
         where [contract].contract_no = @new_contract_no and
               rate_days.rg_code = contract_renewals.con_rg_code_at_renewal and
               rate_days.rr_rates_effective_date = contract_renewals.con_rates_effective_date and
               rou.rf_active = 'Y'
           and standard_frequency.sf_key = rou.sf_key   -- TJB  RD7_0046  Sept2009: added
         group by [contract].contract_no,
                  [contract].con_title,
                  contract_renewals.
                  con_renewal_payment_value
         
        -- PBY 25/06/2002 SR#4412
        -- The payment value for the pending contract should
        -- be calculated as payment_value from last period + any
        -- confirmed frequency adjustments
        select @nFDAmount = sum(fd_amount_to_pay)
          from rd.frequency_adjustments 
         where contract_no = @new_contract_no and
               contract_seq_number = @new_contract_seq_number-1 and
               fd_confirmed = 'Y'

        select @nPaymentprice=isNull(@nPaymentPrice,0)+isNull(@nFDAmount,0)

        /*select count(customer.cust_id) into nCustomers
            from rd.customer 
           where customer.contract_no = @new_contract_no;*/

        select @nCustomers = count(customer_address_moves.cust_id)
          from rd.[address],
               rd.customer_address_moves,
               rd.rds_customer 
         where customer_address_moves.adr_id = [address].adr_id and
               rds_customer.cust_id = customer_address_moves.cust_id and
               customer_address_moves.move_out_date is null and
               [address].contract_no = @new_contract_no and
               rds_customer.master_cust_id is null

        /********************************
        *  contract_renewals            *
        ********************************/
        if @@error = 0
        --BEGIN
            update rd.contract_renewals 
               set con_acceptance_flag = 'N',
                   con_no_customers_at_renewal = @nCustomers,
                   con_no_rural_private_bags_at_renewal = @nRuralBags,
                   con_no_other_bags_at_renewal = @nOtherBags,
                   con_no_private_bags_at_renewal = @nPrivateBags,
                   con_no_post_offices_at_renewal = @nPostOffices,
                   con_no_cmbs_at_renewal = @nCMBs,
                   con_no_cmb_custs_at_renewal = @nCMBCusts,
                   con_del_hrs_week_at_renewal = @nDelHrs,
                   con_processing_hours_per_week = @nProcHrs,
                   con_volume_at_renewal = @nVolume,
                   con_rg_code_at_renewal = @nRgCode,
                   con_rates_effective_date = @dRenewalRateDate,
                   con_start_date = @dConStartDate,
                   con_expiry_date = @dConEndDate,
                   con_renewal_payment_value = @nPaymentPrice 
             where contract_renewals.contract_no = @new_contract_no and
                   contract_renewals.contract_seq_number = @new_contract_seq_number
        --END
                   
        update rd.contract_renewals 
           set con_distance_at_renewal = rd.GetContractDistance(contract_no,contract_seq_number) 
         where contract_no = @new_contract_no and
               contract_seq_number = @new_contract_seq_number
               
        /********************************
        *  contractor_renewals          *
        ********************************/
        insert into rd.contractor_renewals
               ( contractor_supplier_no,
                 contract_no,
                 contract_seq_number,
                 cr_effective_date)
        select contractor_supplier_no,
               contract_no,
               @new_contract_seq_number,
               cr_effective_date 
          from rd.contractor_renewals 
         where contract_no = @new_contract_no and
               contract_seq_number = @new_contract_seq_number-1 and
               cr_effective_date = (select max(cr_effective_date) 
                                      from contractor_renewals 
                                     where contract_no = @new_contract_no 
                                       and contract_seq_number = @new_contract_seq_number-1)
                                        
        /********************************
        *  contract_vehical             *
        ********************************/
        insert into rd.contract_vehical
               ( contract_no,
                 contract_seq_number,
                 vehicle_number,
                 start_kms,
                 vehicle_allowance_paid_to_date,
                 cv_vehical_status,
                 signage_compliant)
        select contract_no,
               @new_contract_seq_number,
               vehicle_number,
               start_kms,
               vehicle_allowance_paid_to_date,
               cv_vehical_status,
               signage_compliant
          from rd.contract_vehical 
         where contract_no = @new_contract_no 
           and contract_seq_number = @new_contract_seq_number-1 
           --and vehicle_number = rd.f_GetLatestVehicle(@new_contract_no,@new_contract_seq_number-1)
                   
        /********************************
        *  vehicle_override_rate        *
        ********************************/
        insert into rd.vehicle_override_rate
               ( contract_no,
                 contract_seq_number,
                 vor_nominal_vehicle_value,
                 vor_repairs_maintenance_rate,
                 vor_tyre_tubes_rate,
                 vor_vehical_allowance_rate,
                 vor_licence_rate,
                 vor_vehicle_rate_of_return_pct,
                 vor_salvage_ratio,
                 vor_ruc,
                 vor_sundries_k,
                 vor_vehicle_insurance_premium,
                 vor_fuel_rate,
                 vor_consumption_rate,
                 vor_livery,
                 vor_effective_date,
                 vehicle_number)
        select @new_contract_no,
               @new_contract_seq_number,
               vor_nominal_vehicle_value,
               vor_repairs_maintenance_rate,
               vor_tyre_tubes_rate,
               vor_vehical_allowance_rate,
               vor_licence_rate,
               vor_vehicle_rate_of_return_pct,
               vor_salvage_ratio,
               vor_ruc,
               vor_sundries_k,
               vor_vehicle_insurance_premium,
               vor_fuel_rate,
               vor_consumption_rate,
               vor_livery,
               @dRenewalRateDate,
               vehicle_number
          from rd.vehicle_override_rate vor1
         where vor1.contract_no = @new_contract_no
           and vor1.contract_seq_number = @new_contract_seq_number-1 
           and vor1.vor_effective_date 
                   = (select max(vor2.vor_effective_date) 
                        from rd.vehicle_override_rate vor2
                       where vor2.contract_no = vor1.contract_no
                         and vor2.contract_seq_number = vor1.contract_seq_number
                         and vor2.vehicle_number = vor1.vehicle_number)
            
        /********************************
        *  non_vehicle_override_rate    *
        ********************************/
        insert into rd.non_vehicle_override_rate
               ( contract_no,
                 contract_seq_number,
                 nvor_wage_hourly_rate,
                 nvor_public_liability_rate_2,
                 nvor_carrier_risk_rate,
                 nvor_acc_rate,
                 nvor_item_proc_rate_per_hour,
                 nvor_frozen,
                 nvor_accounting,
                 nvor_telephone,
                 nvor_sundries,
                 nvor_acc_rate_amount,
                 nvor_uniform,
                 nvor_delivery_wage_rate,
                 nvor_processing_wage_rate,
                 nvor_relief_weeks,
                 nvor_effective_date,
                 vehicle_number)
        select @new_contract_no,
               @new_contract_seq_number,
               nvor_wage_hourly_rate,
               nvor_public_liability_rate_2,
               nvor_carrier_risk_rate,
               nvor_acc_rate,
               nvor_item_proc_rate_per_hour,
               nvor_frozen,
               nvor_accounting,
               nvor_telephone,
               nvor_sundries,
               nvor_acc_rate_amount,
               nvor_uniform,
               nvor_delivery_wage_rate,
               nvor_processing_wage_rate,
               nvor_relief_weeks,
               @dRenewalRateDate,
               vehicle_number
          from rd.non_vehicle_override_rate nvor1
         where nvor1.contract_no = @new_contract_no
           and nvor1.contract_seq_number = @new_contract_seq_number-1 
           and nvor1.nvor_effective_date 
		           = (select max(nvor2.nvor_effective_date) 
                        from rd.non_vehicle_override_rate nvor2
                       where nvor2.contract_no = nvor1.contract_no
                         and nvor2.contract_seq_number = nvor1.contract_seq_number
						 and nvor2.vehicle_number = nvor1.vehicle_number)
    end
end
GO




CREATE TRIGGER [rd].[trig_DelVehOverrideRate] ON [rd].[contract_renewals]
WITH EXECUTE AS CALLER
FOR DELETE
AS
begin
  -- non_vehicle_override_rate
  delete from non_vehicle_override_rate where
    contract_no = (select contract_no from deleted) and
    contract_seq_number = (select contract_seq_number from deleted)
  -- delete the vehicle override rates which were created in the trigger for contract_renewals
  delete from vehicle_override_rate where
    contract_no = (select contract_no from deleted) and
    contract_seq_number = (select contract_seq_number from deleted)
  -- contractor_renewals
  delete from contractor_renewals where
    contract_no = (select contract_no from deleted) and
    contract_seq_number = (select contract_seq_number from deleted)
  -- delete contract_vehical
  delete from contract_vehical where
    contract_no = (select contract_no from deleted) and
    contract_seq_number = (select contract_seq_number from deleted)
end