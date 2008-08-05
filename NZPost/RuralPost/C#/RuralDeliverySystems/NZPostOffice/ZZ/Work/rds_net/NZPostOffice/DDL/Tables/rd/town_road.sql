/****** Object:  Table [rd].[town_road]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[town_road](
	[tc_id] [int] NOT NULL,
	[road_id] [int] NOT NULL,
 CONSTRAINT [town_road_cns] PRIMARY KEY CLUSTERED 
(
	[tc_id] ASC,
	[road_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
