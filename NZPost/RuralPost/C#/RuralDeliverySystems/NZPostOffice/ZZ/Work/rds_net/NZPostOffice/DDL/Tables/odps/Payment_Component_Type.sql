/****** Object:  Table [odps].[Payment_Component_Type]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[Payment_Component_Type](
	[pct_id] [int] IDENTITY(1,1) NOT NULL,
	[ac_id] [int] NULL,
	[pct_description] [varchar](100) COLLATE Latin1_General_CI_AS NOT NULL,
	[pct_witholding_tax_status] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pcg_id] [int] NULL,
	[prs_key] [int] NULL,
 CONSTRAINT [Payment_Component_Type_cns] PRIMARY KEY CLUSTERED 
(
	[pct_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
