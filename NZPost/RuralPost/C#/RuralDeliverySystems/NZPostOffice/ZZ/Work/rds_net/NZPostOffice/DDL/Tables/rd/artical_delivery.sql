/****** Object:  Table [rd].[artical_delivery]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[artical_delivery](
	[contract_no] [int] NOT NULL,
	[ad_date] [datetime] NOT NULL,
	[at_key] [int] NOT NULL,
	[art_effective_date] [datetime] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[ad_quantity] [int] NULL,
	[ad_value_paid] [numeric](10, 2) NULL,
 CONSTRAINT [artical_delivery_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[ad_date] ASC,
	[at_key] ASC,
	[art_effective_date] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
