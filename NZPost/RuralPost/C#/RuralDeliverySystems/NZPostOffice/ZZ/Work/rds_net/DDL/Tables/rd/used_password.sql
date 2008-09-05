/****** Object:  Table [rd].[used_password]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[used_password](
	[up_id] [int] IDENTITY(1,1) NOT NULL,
	[up_password] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[ui_id] [int] NULL,
 CONSTRAINT [used_password_cns] PRIMARY KEY CLUSTERED 
(
	[up_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [used_password UNIQUE (up_id)] UNIQUE NONCLUSTERED 
(
	[up_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
