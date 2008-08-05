/****** Object:  Table [rd].[t_contractor]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_contractor](
	[contractor_supplier_no] [int] NOT NULL,
	[c_title] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_surname_company] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[c_first_names] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[c_initials] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[c_phone_day] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[c_phone_night] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[c_bank_account_no] [varchar](18) COLLATE Latin1_General_CI_AS NULL,
	[c_ird_no] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_gst_number] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_tax_rate] [numeric](4, 2) NULL,
	[c_mobile] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[c_salutation] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[_______________] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[nz_post_employee] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[c_witholding_tax_certificate] [varchar](1) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
