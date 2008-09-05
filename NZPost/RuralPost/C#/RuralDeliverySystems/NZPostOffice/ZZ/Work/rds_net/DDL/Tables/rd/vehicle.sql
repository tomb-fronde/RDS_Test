/****** Object:  Table [rd].[vehicle]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[vehicle](
	[vehicle_number] [int] NOT NULL,
	[vt_key] [int] NULL,
	[ft_key] [int] NULL,
	[v_vehicle_make] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[v_vehicle_model] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[v_vehicle_year] [smallint] NULL,
	[v_vehicle_registration_number] [varchar](8) COLLATE Latin1_General_CI_AS NULL,
	[v_vehicle_cc_rating] [smallint] NULL,
	[v_road_user_charges_indicator] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[v_purchased_date] [datetime] NULL,
	[v_purchase_value] [int] NULL,
	[v_leased] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[v_vehicle_month] [smallint] NULL,
	[v_vehicle_transmission] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[vs_key] [int] NULL,
	[v_remaining_economic_life] [int] NULL,
	[v_vehicle_speedo_kms] [int] NULL,
	[v_vehicle_speedo_date] [datetime] NULL,
	[v_salvage_value] [int] NULL,
 CONSTRAINT [vehicle_cns] PRIMARY KEY CLUSTERED 
(
	[vehicle_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
