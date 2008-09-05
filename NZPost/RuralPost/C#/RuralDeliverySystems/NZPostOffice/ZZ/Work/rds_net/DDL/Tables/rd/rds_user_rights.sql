/****** Object:  Table [rd].[rds_user_rights]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_user_rights](
	[rur_id] [int] NOT NULL,
	[rur_create] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[region_id] [int] NULL,
	[ug_id] [int] NULL,
	[rc_id] [int] NULL,
	[rur_read] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rur_modify] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rur_delete] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [rds_user_rights_cns] PRIMARY KEY CLUSTERED 
(
	[rur_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
