/****** Object:  Table [rd].[vehicle_style]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[vehicle_style](
	[vs_key] [int] IDENTITY(1,1) NOT NULL,
	[vs_description] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [vehicle_style_cns] PRIMARY KEY CLUSTERED 
(
	[vs_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
