/****** Object:  Table [rd].[address]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[address](
	[adr_id] [int] NOT NULL,
	[tc_id] [int] NULL,
	[road_id] [int] NULL,
	[sl_id] [int] NULL,
	[contract_no] [int] NULL,
	[post_code_id] [int] NULL,
	[adr_rd_no] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[adr_no] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[dp_id] [int] NULL,
	[adr_old_delivery_days] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[adr_property_identification] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[adr_alpha] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[adr_date_loaded] [datetime] NULL,
	[adr_last_amended_date] [datetime] NULL,
	[adr_last_amended_user] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[adr_unit] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [address_cns] PRIMARY KEY CLUSTERED 
(
	[adr_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
