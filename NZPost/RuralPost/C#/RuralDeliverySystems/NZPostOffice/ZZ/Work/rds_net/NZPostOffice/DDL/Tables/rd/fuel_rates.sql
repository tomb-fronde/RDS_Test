/****** Object:  Table [rd].[fuel_rates]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[fuel_rates](
	[ft_key] [int] NOT NULL,
	[rg_code] [int] NOT NULL,
	[rr_rates_effective_date] [datetime] NOT NULL,
	[fr_fuel_rate] [numeric](6, 2) NULL,
	[fr_fuel_consumtion_rate] [numeric](6, 2) NULL,
 CONSTRAINT [fuel_rates_cns] PRIMARY KEY CLUSTERED 
(
	[ft_key] ASC,
	[rg_code] ASC,
	[rr_rates_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
