/****** Object:  Table [rd].[SuburbLocality]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[SuburbLocality](
	[sl_id] [int] IDENTITY(1,1) NOT NULL,
	[sl_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [SuburbLocality_cns] PRIMARY KEY CLUSTERED 
(
	[sl_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
