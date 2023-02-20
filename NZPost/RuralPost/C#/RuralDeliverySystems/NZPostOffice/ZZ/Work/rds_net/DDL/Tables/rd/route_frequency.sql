/****** Object:  Table [rd].[route_frequency]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[route_frequency](
	[contract_no] [int] NOT NULL,
	[sf_key] [int] NOT NULL,
	[rf_delivery_days] [varchar](7) COLLATE Latin1_General_CI_AS NOT NULL,
	[rf_active] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rf_distance] [numeric](10, 2) NULL,
	[rf_annotation] [varchar](500) COLLATE Latin1_General_CI_AS NULL,
	[rf_annotation_print] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[rf_valid_ind] [int] NULL,
	[rf_valid_date] [datetime] NULL,
	[rf_valid_user] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [route_frequency_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[sf_key] ASC,
	[rf_delivery_days] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
