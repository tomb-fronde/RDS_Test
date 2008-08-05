/****** Object:  Table [rd].[rcm_stat_report]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rcm_stat_report](
	[region] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[description] [varchar](60) COLLATE Latin1_General_CI_AS NULL,
	[sumamount] [numeric](16, 2) NULL,
	[sort_order] [int] NULL,
	[column_order] [int] NULL,
	[showdecimals] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[variablename] [varchar](10) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
