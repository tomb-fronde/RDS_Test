/****** Object:  Table [rd].[t_fuel_allowance]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_fuel_allowance](
	[contract_no] [int] NOT NULL,
	[effective_date] [datetime] NOT NULL,
	[amount] [numeric](10, 2) NOT NULL,
	[notes] [varchar](100) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
