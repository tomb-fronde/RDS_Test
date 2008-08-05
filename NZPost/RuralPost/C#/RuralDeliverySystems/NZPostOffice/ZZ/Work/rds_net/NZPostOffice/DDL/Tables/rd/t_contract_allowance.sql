/****** Object:  Table [rd].[t_contract_allowance]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_contract_allowance](
	[alt_key] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[ca_effective_date] [datetime] NOT NULL,
	[ca_annual_amount] [numeric](10, 2) NULL,
	[ca_notes] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[ca_paid_to_date] [datetime] NULL,
	[pct_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
