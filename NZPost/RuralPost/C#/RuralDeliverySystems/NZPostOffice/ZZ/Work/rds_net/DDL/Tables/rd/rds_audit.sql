/****** Object:  Table [rd].[rds_audit]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_audit](
	[a_key] [int] IDENTITY(1,1) NOT NULL,
	[a_datetime] [datetime] NOT NULL,
	[a_userid] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[a_contract] [int] NULL,
	[a_contractor] [int] NULL,
	[a_comment] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[a_oldvalue] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[a_newvalue] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [rds_audit_cns] PRIMARY KEY CLUSTERED 
(
	[a_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
