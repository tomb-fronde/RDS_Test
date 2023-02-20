/****** Object:  Table [odps].[Account_Codes]    Script Date: 08/05/2008 15:01:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[Account_Codes](
	[ac_id] [int] IDENTITY(1,1) NOT NULL,
	[ac_code] [varchar](100) COLLATE Latin1_General_CI_AS NOT NULL,
	[ac_description] [varchar](200) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [Account_Codes_cns] PRIMARY KEY CLUSTERED 
(
	[ac_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
