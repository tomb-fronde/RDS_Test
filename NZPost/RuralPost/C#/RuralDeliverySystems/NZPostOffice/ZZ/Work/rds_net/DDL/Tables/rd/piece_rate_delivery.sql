/****** Object:  Table [rd].[piece_rate_delivery]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[piece_rate_delivery](
	[contract_no] [int] NOT NULL,
	[prd_date] [datetime] NOT NULL,
	[prt_key] [int] NOT NULL,
	[prd_quantity] [int] NULL,
	[prd_cost] [numeric](10, 3) NULL,
	[____] [int] NULL,
	[prd_paid_to_date] [datetime] NULL,
 CONSTRAINT [piece_rate_delivery_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[prd_date] ASC,
	[prt_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
