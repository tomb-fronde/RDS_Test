/****** Object:  Table [rd].[rds_component2]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_component2](
	[rc_id] [int] NOT NULL,
	[rc_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[rc_description] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[rc_allowcreate] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rc_allowread] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rc_allowmodify] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rc_allowdelete] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [rds_component_cns2] PRIMARY KEY CLUSTERED 
(
	[rc_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
