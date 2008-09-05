/****** Object:  Table [rd].[systemcontrol]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[systemcontrol](
	[sc_keyname] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[sc_keynumber] [numeric](16, 0) NULL,
	[sc_string] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[sc_number] [numeric](16, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
