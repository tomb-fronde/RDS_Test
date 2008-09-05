/****** Object:  Table [rd].[non_vehicle_override_rate_history]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[non_vehicle_override_rate_history](
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[nvor_wage_hourly_rate] [numeric](6, 2) NULL,
	[nvor_public_liability_rate_2] [numeric](6, 2) NULL,
	[nvor_carrier_risk_rate] [numeric](6, 2) NULL,
	[nvor_acc_rate] [numeric](6, 2) NULL,
	[nvor_item_proc_rate_per_hour] [smallint] NULL,
	[nvor_frozen] [char](1) COLLATE Latin1_General_CI_AS NULL,
	[nvor_accounting] [numeric](8, 2) NULL,
	[nvor_telephone] [numeric](8, 2) NULL,
	[nvor_sundries] [numeric](8, 2) NULL,
	[nvor_acc_rate_amount] [numeric](12, 2) NULL,
	[nvor_uniform] [numeric](12, 2) NULL,
	[nvor_delivery_wage_rate] [numeric](6, 2) NULL,
	[nvor_processing_wage_rate] [numeric](6, 2) NULL,
	[nvor_effective_date] [datetime] NOT NULL,
 CONSTRAINT [non_vehicle_override_rate_history_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[contract_seq_number] ASC,
	[nvor_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
