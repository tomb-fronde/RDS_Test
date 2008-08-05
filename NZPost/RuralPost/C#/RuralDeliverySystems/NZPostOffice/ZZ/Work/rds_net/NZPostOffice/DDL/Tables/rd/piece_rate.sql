/****** Object:  Table [rd].[piece_rate]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[piece_rate](
	[prt_key] [int] NOT NULL,
	[pr_effective_date] [datetime] NOT NULL,
	[rg_code] [int] NOT NULL,
	[pr_active_status] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pr_rate] [numeric](6, 3) NULL,
 CONSTRAINT [piece_rate_cns] PRIMARY KEY CLUSTERED 
(
	[prt_key] ASC,
	[pr_effective_date] ASC,
	[rg_code] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
