CREATE TABLE [rd].[renewal_rate] (
    [rg_code]                       INT             NOT NULL,
    [rr_rates_effective_date]       DATETIME        NOT NULL,
    [rr_nominal_vehical_value]      NUMERIC (10, 2) NULL,
    [rr_wage_hourly_rate]           NUMERIC (6, 2)  NULL,
    [rr_repairs_maintenance_rate]   NUMERIC (6, 2)  NULL,
    [rr_tyre_tubes_rate]            NUMERIC (6, 2)  NULL,
    [rr_vehical_allowance_rate]     NUMERIC (6, 2)  NULL,
    [rr_vehical_insurance_premium]  NUMERIC (6, 2)  NULL,
    [rr_public_liability_rate]      NUMERIC (6, 2)  NULL,
    [rr_carrier_risk_rate]          NUMERIC (6, 2)  NULL,
    [rr_acc_rate]                   NUMERIC (6, 2)  NULL,
    [rr_licence_rate]               NUMERIC (6, 2)  NULL,
    [rr_vehical_rate_of_return_pct] NUMERIC (6, 2)  NULL,
    [rr_salvage_ratio]              NUMERIC (6, 2)  NULL,
    [rr_item_proc_rate_per_hr]      SMALLINT        NULL,
    [rr_frozen_indicator]           VARCHAR (1)     NULL,
    [rr_contract_start]             DATETIME        NULL,
    [rr_contract_end]               DATETIME        NULL,
    [rr_ruc]                        NUMERIC (8, 2)  NULL,
    [rr_accounting]                 NUMERIC (8, 2)  NULL,
    [rr_telephone]                  NUMERIC (8, 2)  NULL,
    [rr_sundries]                   NUMERIC (8, 2)  NULL,
    [rr_sundries_k]                 NUMERIC (12, 2) NULL,
    CONSTRAINT [renewal_rate_cns] PRIMARY KEY CLUSTERED ([rg_code] ASC, [rr_rates_effective_date] ASC),
    CONSTRAINT [FK_renewal_group1] FOREIGN KEY ([rg_code]) REFERENCES [rd].[renewal_group] ([rg_code])
);


GO




CREATE TRIGGER [rd].[trig_AddRenewalRates1] ON [rd].[renewal_rate]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  declare @nRGCode int,
  @dDate datetime
  select @dDate = max(rr_rates_effective_date),
    @nRGCode = max(rg_code) 
     from renewal_rate where
    rr_rates_effective_date < (select rr_rates_effective_date from inserted)
  if @dDate is not null
    begin
      insert into fuel_rates(ft_key,
        rg_code,
        rr_rates_effective_date,
        fr_fuel_rate,
        fr_fuel_consumtion_rate)
        select ft_key,
          (select rg_code from inserted),
          (select rr_rates_effective_date from inserted),
          fr_fuel_rate,
          fr_fuel_consumtion_rate from
          fuel_rates where
          rg_code = @nRGCode and
          rr_rates_effective_date = @dDate
      insert into rate_days(rg_code,
        rr_rates_effective_date,
        sf_key,
        rtd_days_per_annum)
        select (select rg_code from inserted),
          (select rr_rates_effective_date from inserted),
          sf_key,
          rtd_days_per_annum from
          rate_days where
          rg_code = @nRGCode and
          rr_rates_effective_date = @dDate
      insert into piece_rate(prt_key,
        pr_effective_date,
        rg_code,
        pr_active_status,
        pr_rate)
        select prt_key,
          (select rr_rates_effective_date from inserted),
          (select rg_code from inserted),
          pr_active_status,
          pr_rate from
          piece_rate where
          rg_code = @nRGCode and
          pr_effective_date = @dDate
    end
end