/****** Object:  Table [odps].[payment_component_group]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[payment_component_group](
	[pcg_id] [int] NOT NULL,
	[pcg_short_code] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[pcg_description] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [payment_component_group_cns] PRIMARY KEY CLUSTERED 
(
	[pcg_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
