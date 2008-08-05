/****** Object:  Table [rd].[contract_fixed_assets]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract_fixed_assets](
	[contract_no] [int] NOT NULL,
	[fa_fixed_asset_no] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [contract_fixed_assets_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[fa_fixed_asset_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
