/****** Object:  Table [rd].[Road]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[Road](
	[road_id] [int] NOT NULL,
	[rt_id] [int] NULL,
	[road_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[unique_road_id] [int] NULL,
	[rs_id] [int] NULL,
	[last_amended_date] [datetime] NULL,
	[last_amended_user] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [Road_cns] PRIMARY KEY CLUSTERED 
(
	[road_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
