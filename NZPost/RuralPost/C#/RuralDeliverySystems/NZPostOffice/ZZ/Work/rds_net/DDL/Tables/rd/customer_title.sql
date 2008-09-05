/****** Object:  Table [rd].[customer_title]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[customer_title](
	[customer_title_id] [int] NOT NULL,
	[customer_title_name] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[user_id] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[last_mod_date] [datetime] NULL,
 CONSTRAINT [customer_title_cns] PRIMARY KEY CLUSTERED 
(
	[customer_title_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
