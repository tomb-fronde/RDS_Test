/****** Object:  Table [rd].[t_piecerate_remove]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[t_piecerate_remove](
	[contract_no] [int] NULL,
	[prd_date] [datetime] NULL,
	[prt_key] [int] NULL,
	[prd_quantity] [int] NULL,
	[prd_cost] [numeric](10, 3) NULL
) ON [PRIMARY]

GO
