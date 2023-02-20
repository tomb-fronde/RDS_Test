/****** Object:  Table [rd].[ca_load_results]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[ca_load_results](
	[rows_inserted] [int] NULL,
	[rows_skipped] [int] NULL,
	[row_errors] [int] NULL,
	[amount_inserted] [numeric](10, 2) NULL,
	[load_name] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[load_date] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
