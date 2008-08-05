/****** Object:  Table [rd].[contract_adjustments]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract_adjustments](
	[ca_key] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[ca_date_occured] [datetime] NULL,
	[ca_reason] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[ca_date_paid] [datetime] NULL,
	[ca_amount] [numeric](10, 2) NULL,
	[ca_confirmed] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pct_id] [int] NULL,
 CONSTRAINT [contract_adjustments_cns] PRIMARY KEY CLUSTERED 
(
	[ca_key] ASC,
	[contract_no] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
