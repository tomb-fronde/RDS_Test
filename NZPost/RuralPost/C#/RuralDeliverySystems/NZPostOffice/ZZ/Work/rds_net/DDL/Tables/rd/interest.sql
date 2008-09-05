/****** Object:  Table [rd].[interest]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[interest](
	[interest_id] [int] NOT NULL,
	[interest_description] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [interest_cns] PRIMARY KEY CLUSTERED 
(
	[interest_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
