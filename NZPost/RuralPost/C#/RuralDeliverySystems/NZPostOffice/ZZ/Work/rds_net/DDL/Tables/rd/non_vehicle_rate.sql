/****** Object:  Table [rd].[non_vehicle_rate]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[non_vehicle_rate](
	[rg_code] [int] NOT NULL,
	[nvr_rates_effective_date] [datetime] NOT NULL,
	[nvr_wage_hourly_rate] [numeric](6, 2) NULL,
	[nvr_vehicle_insurance_base_premium] [numeric](6, 2) NULL,
	[nvr_public_liability_rate] [numeric](6, 2) NULL,
	[nvr_carrier_risk_rate] [numeric](6, 2) NULL,
	[nvr_acc_rate] [numeric](6, 2) NULL,
	[nvr_item_proc_rate_per_hr] [smallint] NULL,
	[nvr_frozen_indicator] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[nvr_contract_start] [datetime] NULL,
	[nvr_contract_end] [datetime] NULL,
	[nvr_accounting] [numeric](8, 2) NULL,
	[nvr_telephone] [numeric](8, 2) NULL,
	[nvr_sundries] [numeric](8, 2) NULL,
	[nvr_acc_rate_amount] [numeric](12, 2) NULL,
	[nvr_uniform] [numeric](12, 2) NULL,
	[nvr_delivery_wage_rate] [numeric](6, 2) NULL,
	[nvr_processing_wage_rate] [numeric](6, 2) NULL,
 CONSTRAINT [non_vehicle_rate_cns] PRIMARY KEY CLUSTERED 
(
	[rg_code] ASC,
	[nvr_rates_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
