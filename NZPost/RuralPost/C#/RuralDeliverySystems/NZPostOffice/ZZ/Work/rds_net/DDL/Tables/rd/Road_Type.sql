/****** Object:  Table [rd].[Road_Type]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[Road_Type](
	[rt_id] [int] IDENTITY(1,1) NOT NULL,
	[rt_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[rt_abbrev] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [Road_Type_cns] PRIMARY KEY CLUSTERED 
(
	[rt_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
