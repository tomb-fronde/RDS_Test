/****** Object:  Table [rd].[artical_type]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[artical_type](
	[at_key] [int] IDENTITY(1,1) NOT NULL,
	[at_description] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [artical_type_cns] PRIMARY KEY CLUSTERED 
(
	[at_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
