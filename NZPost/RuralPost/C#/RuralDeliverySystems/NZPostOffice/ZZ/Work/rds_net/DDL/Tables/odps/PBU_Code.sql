/****** Object:  Table [odps].[PBU_Code]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[PBU_Code](
	[PBU_Code] [varchar](10) COLLATE Latin1_General_CI_AS NOT NULL,
	[PBU_Description] [varchar](100) COLLATE Latin1_General_CI_AS NOT NULL,
	[PBU_ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PBU_Code_cns] PRIMARY KEY CLUSTERED 
(
	[PBU_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO