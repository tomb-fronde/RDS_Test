/****** Object:  Table [rd].[artical_rate]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[artical_rate](
	[at_key] [int] NOT NULL,
	[art_effective_date] [datetime] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[art_rate] [numeric](8, 2) NULL,
 CONSTRAINT [artical_rate_cns] PRIMARY KEY CLUSTERED 
(
	[at_key] ASC,
	[art_effective_date] ASC,
	[contract_no] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
