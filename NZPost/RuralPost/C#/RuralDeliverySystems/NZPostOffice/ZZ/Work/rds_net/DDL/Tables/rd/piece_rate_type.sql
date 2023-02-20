/****** Object:  Table [rd].[piece_rate_type]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[piece_rate_type](
	[prt_key] [int] IDENTITY(1,1) NOT NULL,
	[prt_description] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[prt_code] [varchar](4) COLLATE Latin1_General_CI_AS NULL,
	[prt_print_on_schedule] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[prs_key] [int] NULL,
	[prs_true_value] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [piece_rate_type_cns] PRIMARY KEY CLUSTERED 
(
	[prt_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
