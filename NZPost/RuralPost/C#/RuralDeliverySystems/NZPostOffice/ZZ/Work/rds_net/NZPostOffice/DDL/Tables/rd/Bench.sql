/****** Object:  Table [rd].[Bench]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[Bench](
	[contract_no] [int] NOT NULL,
	[con_renewal_benchmark_price] [numeric](10, 2) NULL,
	[con_renewal_payment_value] [numeric](10, 2) NULL
) ON [PRIMARY]

GO
