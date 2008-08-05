/****** Object:  Table [rd].[Road_Suburb]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[Road_Suburb](
	[sl_id] [int] NOT NULL,
	[road_id] [int] NOT NULL,
 CONSTRAINT [Road_Suburb_cns] PRIMARY KEY CLUSTERED 
(
	[sl_id] ASC,
	[road_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
