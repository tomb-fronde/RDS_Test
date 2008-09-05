/****** Object:  Table [rd].[rds_user]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_user](
	[u_id] [int] NOT NULL,
	[u_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[u_location] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[u_phone] [varchar](25) COLLATE Latin1_General_CI_AS NULL,
	[u_mobile] [varchar](25) COLLATE Latin1_General_CI_AS NULL,
	[region_id] [int] NULL,
 CONSTRAINT [rds_user_cns] PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
