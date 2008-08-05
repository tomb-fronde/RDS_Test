/****** Object:  Table [rd].[t_contract_renewals]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_contract_renewals](
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[con_start_date] [datetime] NULL,
	[con_rates_effective_date] [datetime] NULL,
	[con_rg_code_at_renewal] [int] NULL,
	[con_expiry_date] [datetime] NULL,
	[con_start_pay_date] [datetime] NULL,
	[con_last_paid_date] [datetime] NULL,
	[con_processing_hours_per_week] [numeric](6, 2) NULL,
	[con_renewal_benchmark_price] [numeric](10, 2) NULL,
	[con_renewal_payment_value] [numeric](10, 2) NULL,
	[con_relief_driver_name] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[con_relief_driver_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[con_relief_driver_home_phone] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[con_date_last_assigned] [datetime] NULL,
	[con_acceptance_flag] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[con_distance_at_renewal] [numeric](10, 2) NULL,
	[con_no_customers_at_renewal] [smallint] NULL,
	[con_no_rural_private_bags_at_renewal] [smallint] NULL,
	[con_no_other_bags_at_renewal] [smallint] NULL,
	[con_no_private_bags_at_renewal] [smallint] NULL,
	[con_no_post_offices_at_renewal] [smallint] NULL,
	[con_no_cmbs_at_renewal] [smallint] NULL,
	[con_no_cmb_custs_at_renewal] [smallint] NULL,
	[con_del_hrs_week_at_renewal] [numeric](6, 2) NULL,
	[con_volume_at_renewal] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
