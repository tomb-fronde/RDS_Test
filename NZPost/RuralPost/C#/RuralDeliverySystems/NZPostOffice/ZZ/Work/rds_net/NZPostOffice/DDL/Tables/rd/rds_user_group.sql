/****** Object:  Table [rd].[rds_user_group]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_user_group](
	[ug_id] [int] NOT NULL,
	[ug_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[ug_description] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[ug_created_date] [datetime] NULL,
	[ug_created_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ug_modified_date] [datetime] NULL,
	[ug_modified_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ug_privacy_override] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [rds_user_group_cns] PRIMARY KEY CLUSTERED 
(
	[ug_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
