/****** Object:  Table [rd].[town_suburb]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[town_suburb](
	[tc_id] [int] NOT NULL,
	[sl_id] [int] NOT NULL,
 CONSTRAINT [town_suburb_cns] PRIMARY KEY CLUSTERED 
(
	[tc_id] ASC,
	[sl_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
