/****** Object:  Table [rd].[rds_user_id]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_user_id](
	[ui_id] [int] NOT NULL,
	[u_id] [int] NULL,
	[ui_userid] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ui_password] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ui_last_login_date] [datetime] NULL,
	[ui_last_login_time] [datetime] NULL,
	[ui_created_date] [datetime] NULL,
	[ui_created_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ui_modified_date] [datetime] NULL,
	[ui_modified_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ui_location] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[ui_password_expiry] [datetime] NULL,
	[ui_grace_logins] [smallint] NULL,
	[ui_locked_date] [datetime] NULL,
	[ui_can_change_password] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [rds_user_id_cns] PRIMARY KEY CLUSTERED 
(
	[ui_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
