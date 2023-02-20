/****** Object:  Table [rd].[vehicle_override_rate]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[vehicle_override_rate](
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[vor_nominal_vehicle_value] [numeric](10, 2) NULL,
	[vor_repairs_maintenance_rate] [numeric](6, 2) NULL,
	[vor_tyre_tubes_rate] [numeric](6, 2) NULL,
	[vor_vehical_allowance_rate] [numeric](6, 2) NULL,
	[vor_licence_rate] [numeric](6, 2) NULL,
	[vor_vehicle_rate_of_return_pct] [numeric](6, 2) NULL,
	[vor_salvage_ratio] [numeric](6, 2) NULL,
	[vor_ruc] [numeric](8, 2) NULL,
	[vor_sundries_k] [numeric](12, 2) NULL,
	[vor_vehicle_insurance_premium] [numeric](12, 2) NULL,
	[vor_fuel_rate] [numeric](6, 2) NULL,
	[vor_consumption_rate] [numeric](6, 2) NULL,
	[vor_livery] [numeric](12, 2) NULL,
	[vor_effective_date] [datetime] NOT NULL,
 CONSTRAINT [vehicle_override_rate_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[contract_seq_number] ASC,
	[vor_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
