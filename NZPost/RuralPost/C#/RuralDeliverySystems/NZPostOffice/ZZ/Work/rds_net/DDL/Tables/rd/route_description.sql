/****** Object:  Table [rd].[route_description]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[route_description](
	[sf_key] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[rd_sequence] [smallint] NOT NULL,
	[rf_delivery_days] [varchar](7) COLLATE Latin1_General_CI_AS NOT NULL,
	[rd_description_of_point] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[rd_time_at_point] [datetime] NULL,
	[rfv_id] [int] NULL,
	[rfpd_id] [int] NULL,
	[rf_distance_of_leg] [numeric](10, 2) NULL,
	[rf_running_total] [numeric](10, 2) NULL,
	[rfv_id_2] [int] NULL,
	[cust_id] [int] NULL,
	[adr_id] [int] NULL,
 CONSTRAINT [route_description_cns] PRIMARY KEY CLUSTERED 
(
	[sf_key] ASC,
	[contract_no] ASC,
	[rd_sequence] ASC,
	[rf_delivery_days] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
