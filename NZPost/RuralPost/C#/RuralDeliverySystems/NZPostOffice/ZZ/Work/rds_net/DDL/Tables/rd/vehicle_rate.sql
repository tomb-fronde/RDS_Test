/****** Object:  Table [rd].[vehicle_rate]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[vehicle_rate](
	[vr_rates_effective_date] [datetime] NOT NULL,
	[vr_nominal_vehicle_value] [numeric](10, 2) NULL,
	[vr_repairs_maintenance_rate] [numeric](6, 2) NULL,
	[vr_tyre_tubes_rate] [numeric](6, 2) NULL,
	[vr_vehicle_allowance_rate] [numeric](6, 2) NULL,
	[vr_licence_rate] [numeric](6, 2) NULL,
	[vr_vehicle_rate_of_return_pct] [numeric](6, 2) NULL,
	[vr_salvage_ratio] [numeric](6, 2) NULL,
	[vr_ruc] [numeric](8, 2) NULL,
	[vr_sundries_k] [numeric](12, 2) NULL,
	[vr_vehicle_value_insurance_pct] [numeric](12, 2) NULL,
	[vt_key] [int] NOT NULL,
	[vr_livery] [numeric](12, 2) NULL,
 CONSTRAINT [vehicle_rate_cns] PRIMARY KEY CLUSTERED 
(
	[vr_rates_effective_date] ASC,
	[vt_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
