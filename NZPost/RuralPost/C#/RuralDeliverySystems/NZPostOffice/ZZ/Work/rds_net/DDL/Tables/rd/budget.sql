/****** Object:  Table [rd].[budget]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[budget](
	[region_id] [int] NOT NULL,
	[bud_year] [datetime] NOT NULL,
	[bud_fixed_cost_vol] [int] NULL,
	[bud_adpost_vol] [int] NULL,
	[bud_courier_vol] [int] NULL,
	[bud_medium_vol] [int] NULL,
	[bud_small_parcel_vol] [int] NULL,
	[bud_large_parcel_vol] [int] NULL,
	[bud_fixed_cost_value] [int] NULL,
	[bud_adpost_value] [int] NULL,
	[bud_courier_value] [int] NULL,
	[bud_medium_value] [int] NULL,
	[bud_small_parcel_value] [int] NULL,
	[bud_large_parcel_value] [int] NULL,
	[bud_posting_qty] [int] NULL,
	[bud_allowance_val] [int] NULL,
 CONSTRAINT [budget_cns] PRIMARY KEY CLUSTERED 
(
	[region_id] ASC,
	[bud_year] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
