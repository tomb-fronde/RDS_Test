/****** Object:  Table [rd].[mpt_customers_old]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[mpt_customers_old](
	[cust_id] [int] NOT NULL,
	[change_type] [char](1) COLLATE Latin1_General_CI_AS NOT NULL,
	[change_date] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
