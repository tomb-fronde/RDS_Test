/****** Object:  Table [rd].[contract_rates]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract_rates](
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[rr_nominal_vehical_value] [numeric](10, 2) NULL,
	[rr_wage_hourly_rate] [numeric](6, 2) NULL,
	[rr_repairs_maintenance_rate] [numeric](6, 2) NULL,
	[rr_tyre_tubes_rate] [numeric](6, 2) NULL,
	[rr_vehical_allowance_rate] [numeric](6, 2) NULL,
	[rr_vehical_insurance_premium] [numeric](6, 2) NULL,
	[rr_public_liability_rate_2] [numeric](6, 2) NULL,
	[rr_carrier_risk_rate] [numeric](6, 2) NULL,
	[rr_acc_rate] [numeric](6, 2) NULL,
	[rr_licence_rate] [numeric](6, 2) NULL,
	[rr_vehical_rate_of_return_pct] [numeric](6, 2) NULL,
	[rr_salvage_ratio] [numeric](6, 2) NULL,
	[rr_item_proc_rate_per_hour] [smallint] NULL,
	[rr_fuel_rate] [numeric](6, 2) NULL,
	[rr_consumption_rate] [numeric](6, 2) NULL,
	[rr_frozen] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rr_ruc] [numeric](8, 2) NULL,
	[rr_accounting] [numeric](8, 2) NULL,
	[rr_telephone] [numeric](8, 2) NULL,
	[rr_sundries] [numeric](8, 2) NULL,
	[rr_sundries_k] [numeric](12, 2) NULL,
 CONSTRAINT [contract_rates_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
