/****** Object:  Table [rd].[outlet_type]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[outlet_type](
	[ot_code] [int] NOT NULL,
	[ot_outlet_type] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [outlet_type(primary key)] PRIMARY KEY CLUSTERED 
(
	[ot_code] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
