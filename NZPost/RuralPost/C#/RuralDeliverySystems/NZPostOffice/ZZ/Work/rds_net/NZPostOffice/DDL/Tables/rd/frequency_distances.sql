/****** Object:  Table [rd].[frequency_distances]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[frequency_distances](
	[fd_effective_date] [datetime] NOT NULL,
	[contract_no] [int] NOT NULL,
	[sf_key] [int] NOT NULL,
	[rf_delivery_days] [varchar](7) COLLATE Latin1_General_CI_AS NOT NULL,
	[fd_distance] [numeric](8, 2) NULL,
	[fd_no_of_boxes] [smallint] NULL,
	[fd_no_rural_bags] [smallint] NULL,
	[fd_no_other_bags] [smallint] NULL,
	[fd_no_private_bags] [smallint] NULL,
	[fd_no_post_offices] [smallint] NULL,
	[fd_no_cmbs] [smallint] NULL,
	[fd_no_cmb_customers] [smallint] NULL,
	[fd_change_reason] [varchar](250) COLLATE Latin1_General_CI_AS NULL,
	[fd_delivery_hrs_per_week] [numeric](6, 3) NULL,
	[fd_processing_hrs_week] [numeric](6, 2) NULL,
	[fd_volume] [numeric](8, 2) NULL,
 CONSTRAINT [frequency_distances_cns] PRIMARY KEY CLUSTERED 
(
	[fd_effective_date] ASC,
	[contract_no] ASC,
	[sf_key] ASC,
	[rf_delivery_days] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
