/****** Object:  Table [rd].[piece_rate_supplier]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[piece_rate_supplier](
	[prs_key] [int] IDENTITY(1,1) NOT NULL,
	[prs_description] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[pct_id] [int] NULL,
 CONSTRAINT [piece_rate_supplier_cns] PRIMARY KEY CLUSTERED 
(
	[prs_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
