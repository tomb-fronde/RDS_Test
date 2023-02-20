/****** Object:  Table [rd].[tu_contract_renewals]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[tu_contract_renewals](
	[con_active_sequence] [smallint] NOT NULL,
	[cct_key] [int] NULL,
	[contractno] [int] NULL,
	[rc_name] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[title] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[con_renewal_payment_value] [numeric](12, 2) NULL,
	[ca_annual_amount] [numeric](12, 2) NULL,
	[con_no_customers_at_renewal] [int] NULL,
	[con_no_private_bags_at_renewal] [int] NULL,
	[con_start_date] [datetime] NOT NULL,
	[con_rates_effective_date] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
