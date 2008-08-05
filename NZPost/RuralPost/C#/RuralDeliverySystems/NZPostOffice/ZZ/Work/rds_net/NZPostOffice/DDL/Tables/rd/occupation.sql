/****** Object:  Table [rd].[occupation]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[occupation](
	[occupation_id] [int] NOT NULL,
	[occupation_description] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [occupation_cns] PRIMARY KEY CLUSTERED 
(
	[occupation_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
