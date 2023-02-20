/****** Object:  Table [rd].[contract_allowance]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract_allowance](
	[alt_key] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[ca_effective_date] [datetime] NOT NULL,
	[ca_annual_amount] [numeric](10, 2) NULL,
	[ca_notes] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[ca_paid_to_date] [datetime] NULL,
	[pct_id] [int] NULL,
 CONSTRAINT [contract_allowance_cns] PRIMARY KEY CLUSTERED 
(
	[alt_key] ASC,
	[contract_no] ASC,
	[ca_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
