/****** Object:  Table [rd].[temp_custlist]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[temp_custlist](
	[cust_id] [int] NULL,
	[cust_title] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[cust_initials] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
	[cust_surname_company] [varchar](45) COLLATE Latin1_General_CI_AS NULL,
	[adr_unit] [int] NULL,
	[adr_no] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[road] [varchar](80) COLLATE Latin1_General_CI_AS NULL,
	[adr_rd_no] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[sl_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[tc_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[post_code] [varchar](4) COLLATE Latin1_General_CI_AS NULL,
	[Agricultural] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Beef] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Cropping_Arable] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Dairy] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Horticulture] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Other_Farmer] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Other_Livestock] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Sheep] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Small_Lifestyle_Farmer] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Other_Business] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Other_Residential] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Retired] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[Tourism] [varchar](1) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
