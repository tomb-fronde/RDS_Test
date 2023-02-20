/****** Object:  Table [rd].[userids]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[userids](
	[u_code] [numeric](10, 0) NOT NULL,
	[u_userid] [varchar](20) COLLATE Latin1_General_CI_AS NOT NULL,
	[u_password] [varchar](20) COLLATE Latin1_General_CI_AS NOT NULL,
	[u_cargo] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[u_last_login_date] [datetime] NULL,
	[u_last_login_time] [datetime] NULL,
	[u_created_date] [datetime] NULL,
	[u_created_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[u_modified_date] [datetime] NULL,
	[u_modified_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[gp_code] [numeric](10, 0) NULL,
	[u_name] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[u_location] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[u_phone] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[u_mobile] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[u_can_change_password] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[region_id] [int] NULL,
	[u_password_expiry] [datetime] NULL,
	[u_grace_logins] [smallint] NULL,
	[u_locked_date] [datetime] NULL,
 CONSTRAINT [userids_cns] PRIMARY KEY CLUSTERED 
(
	[u_code] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
