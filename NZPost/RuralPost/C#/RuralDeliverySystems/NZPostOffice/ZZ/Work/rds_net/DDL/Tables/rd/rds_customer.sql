/****** Object:  Table [rd].[rds_customer]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rds_customer](
	[cust_id] [int] NOT NULL,
	[cust_title] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[cust_surname_company] [varchar](45) COLLATE Latin1_General_CI_AS NULL,
	[cust_initials] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
	[cust_phone_day] [varchar](14) COLLATE Latin1_General_CI_AS NULL,
	[cust_phone_night] [varchar](14) COLLATE Latin1_General_CI_AS NULL,
	[cust_dir_listing_ind] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[cust_dir_listing_text] [varchar](60) COLLATE Latin1_General_CI_AS NULL,
	[cust_business] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[cust_rural_resident] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[cust_rural_farmer] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[printedon] [datetime] NULL,
	[cust_date_commenced] [datetime] NULL,
	[cust_phone_mobile] [varchar](14) COLLATE Latin1_General_CI_AS NULL,
	[master_cust_id] [int] NULL,
	[cust_care_of] [varchar](75) COLLATE Latin1_General_CI_AS NULL,
	[cust_adpost_quantity] [int] NULL,
	[cust_last_amended_date] [datetime] NULL,
	[cust_last_amended_user] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [rds_customer_cns] PRIMARY KEY CLUSTERED 
(
	[cust_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
