/****** Object:  Table [rd].[post_code]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[post_code](
	[post_code_id] [int] IDENTITY(1,1) NOT NULL,
	[post_code] [varchar](4) COLLATE Latin1_General_CI_AS NULL,
	[post_mail_town] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[post_district] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[rd_no] [varchar](4) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [post_code_cns] PRIMARY KEY CLUSTERED 
(
	[post_code_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
