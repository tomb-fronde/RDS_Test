/****** Object:  Table [rd].[t_contract_adjustment]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_contract_adjustment](
	[contract_no] [int] NOT NULL,
	[ca_date_occured] [datetime] NOT NULL,
	[ca_amount] [numeric](10, 2) NOT NULL,
	[ca_reason] [varchar](100) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
