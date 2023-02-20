/****** Object:  Table [rd].[t_benchmark]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_benchmark](
	[RenewalGroup] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
	[RenewalDate] [datetime] NULL,
	[ContractStartDate] [datetime] NULL,
	[ContractEndDate] [datetime] NULL,
	[NominalVehicleValue] [numeric](12, 2) NULL,
	[RemainingEconomicLife] [numeric](12, 2) NULL,
	[WageHourlyRate] [numeric](12, 2) NULL,
	[RepairsMaintRate] [numeric](12, 2) NULL,
	[TyreTubesRate] [numeric](12, 2) NULL,
	[VehicalAllowRate] [numeric](12, 2) NULL,
	[VehicalInsureCost] [numeric](12, 2) NULL,
	[PublicLiaRate] [numeric](12, 2) NULL,
	[CarrierRiskRate] [numeric](12, 2) NULL,
	[ACCRate] [numeric](12, 2) NULL,
	[LicenceRate] [numeric](12, 2) NULL,
	[RateOfReturn] [numeric](12, 2) NULL,
	[SalvageRatio] [numeric](12, 2) NULL,
	[ItemsHourRate] [numeric](12, 2) NULL,
	[FuelRate] [numeric](12, 2) NULL,
	[ConsumptionRate] [numeric](12, 2) NULL,
	[AccountingRate] [numeric](12, 2) NULL,
	[TelephoneRate] [numeric](12, 2) NULL,
	[SundriesRate] [numeric](12, 2) NULL,
	[SundriesKRate] [numeric](12, 2) NULL,
	[RUCRate] [numeric](12, 2) NULL,
	[InsurancePct] [numeric](12, 2) NULL,
	[LiveryRate] [numeric](12, 2) NULL,
	[UniformRate] [numeric](12, 2) NULL,
	[ACCFixedAmount] [numeric](12, 2) NULL,
	[NumRows] [int] NULL,
	[DeliveryDays] [numeric](12, 2) NULL,
	[RouteDistance] [numeric](12, 2) NULL,
	[DeliveryHours] [numeric](12, 2) NULL,
	[ProcessingHours] [numeric](12, 2) NULL,
	[Volume] [numeric](12, 2) NULL,
	[MaxDeliveryDays] [numeric](12, 2) NULL,
	[RouteDistancePerDay] [numeric](12, 2) NULL,
	[VehicleDepreciation] [numeric](12, 2) NULL,
	[FuelCostPerAnnum] [numeric](12, 2) NULL,
	[RepairsPerAnnum] [numeric](12, 2) NULL,
	[TyresTubesPerAnnum] [numeric](12, 2) NULL,
	[DeliveryCost] [numeric](12, 2) NULL,
	[ProcessingCost] [numeric](12, 2) NULL,
	[PublicLiabilityCost] [numeric](12, 2) NULL,
	[ACCPerAnnum] [numeric](12, 2) NULL,
	[LicensingCost] [numeric](12, 2) NULL,
	[CarrierRiskAmount] [numeric](12, 2) NULL,
	[RateofReturnCost] [numeric](12, 2) NULL,
	[TelephoneCost] [numeric](12, 2) NULL,
	[SundriesCost] [numeric](12, 2) NULL,
	[SundriesKCost] [numeric](12, 2) NULL,
	[AccountingCost] [numeric](12, 2) NULL,
	[RUCCost] [numeric](12, 2) NULL,
	[Benchmark] [numeric](12, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
