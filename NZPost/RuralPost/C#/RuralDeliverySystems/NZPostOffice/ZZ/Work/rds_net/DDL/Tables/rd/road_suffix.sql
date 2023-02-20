/****** Object:  Table [rd].[road_suffix]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[road_suffix](
	[rs_id] [int] NOT NULL,
	[rs_name] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[rs_abbrev] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [road_suffix_cns] PRIMARY KEY CLUSTERED 
(
	[rs_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
