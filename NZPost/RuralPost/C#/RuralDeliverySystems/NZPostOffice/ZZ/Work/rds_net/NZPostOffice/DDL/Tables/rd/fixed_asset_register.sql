/****** Object:  Table [rd].[fixed_asset_register]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[fixed_asset_register](
	[fa_fixed_asset_no] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[fat_id] [int] NULL,
	[fa_owner] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[fa_purchase_date] [datetime] NULL,
	[fa_purchase_price] [numeric](10, 2) NULL,
 CONSTRAINT [fixed_asset_register_cns] PRIMARY KEY CLUSTERED 
(
	[fa_fixed_asset_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
