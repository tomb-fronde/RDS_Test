/****** Object:  Table [rd].[TownCity]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[TownCity](
	[tc_id] [int] IDENTITY(1,1) NOT NULL,
	[region_id] [int] NOT NULL,
	[tc_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [TownCity_cns] PRIMARY KEY CLUSTERED 
(
	[tc_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
