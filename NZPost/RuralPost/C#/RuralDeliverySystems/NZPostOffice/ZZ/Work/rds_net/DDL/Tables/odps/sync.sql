/****** Object:  Table [odps].[sync]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[sync](
	[sync_no] [int] NOT NULL,
	[sync_name] [varchar](30) COLLATE Latin1_General_CI_AS NOT NULL,
	[sync_value] [numeric](5, 0) NOT NULL,
 CONSTRAINT [sync_cns] PRIMARY KEY CLUSTERED 
(
	[sync_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
