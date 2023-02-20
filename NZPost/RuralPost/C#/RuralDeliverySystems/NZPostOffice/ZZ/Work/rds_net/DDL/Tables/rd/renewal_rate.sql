/****** Object:  Table [rd].[renewal_rate]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[renewal_rate](
	[rg_code] [int] NOT NULL,
	[rr_rates_effective_date] [datetime] NOT NULL,
	[rr_nominal_vehical_value] [numeric](10, 2) NULL,
	[rr_wage_hourly_rate] [numeric](6, 2) NULL,
	[rr_repairs_maintenance_rate] [numeric](6, 2) NULL,
	[rr_tyre_tubes_rate] [numeric](6, 2) NULL,
	[rr_vehical_allowance_rate] [numeric](6, 2) NULL,
	[rr_vehical_insurance_premium] [numeric](6, 2) NULL,
	[rr_public_liability_rate] [numeric](6, 2) NULL,
	[rr_carrier_risk_rate] [numeric](6, 2) NULL,
	[rr_acc_rate] [numeric](6, 2) NULL,
	[rr_licence_rate] [numeric](6, 2) NULL,
	[rr_vehical_rate_of_return_pct] [numeric](6, 2) NULL,
	[rr_salvage_ratio] [numeric](6, 2) NULL,
	[rr_item_proc_rate_per_hr] [smallint] NULL,
	[rr_frozen_indicator] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rr_contract_start] [datetime] NULL,
	[rr_contract_end] [datetime] NULL,
	[rr_ruc] [numeric](8, 2) NULL,
	[rr_accounting] [numeric](8, 2) NULL,
	[rr_telephone] [numeric](8, 2) NULL,
	[rr_sundries] [numeric](8, 2) NULL,
	[rr_sundries_k] [numeric](12, 2) NULL,
 CONSTRAINT [renewal_rate_cns] PRIMARY KEY CLUSTERED 
(
	[rg_code] ASC,
	[rr_rates_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
