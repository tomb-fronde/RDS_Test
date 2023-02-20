/****** Object:  Table [rd].[rds_maintenance_table]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_maintenance_table](
	[mt_id] [int] NOT NULL,
	[mt_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[mt_dataobject] [varchar](50) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
