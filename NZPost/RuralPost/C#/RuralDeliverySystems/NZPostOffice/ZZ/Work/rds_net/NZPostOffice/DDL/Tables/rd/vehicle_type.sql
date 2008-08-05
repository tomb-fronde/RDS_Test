/****** Object:  Table [rd].[vehicle_type]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[vehicle_type](
	[vt_key] [int] IDENTITY(1,1) NOT NULL,
	[vt_description] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [vehicle_type_cns] PRIMARY KEY CLUSTERED 
(
	[vt_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
