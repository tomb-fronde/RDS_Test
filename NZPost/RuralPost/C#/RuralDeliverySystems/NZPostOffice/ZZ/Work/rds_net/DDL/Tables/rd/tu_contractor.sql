/****** Object:  Table [rd].[tu_contractor]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[tu_contractor](
	[c_surname_company] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[old_ds_number] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_bank_account_no] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[c_address] [varchar](300) COLLATE Latin1_General_CI_AS NULL,
	[contractor_supplier_no] [int] NULL,
	[c_tax_rate] [numeric](12, 2) NULL,
	[c_withholding_tax_certificate] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[c_ird_no] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[c_gst_number] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[rc_name] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[title] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[cct_key] [int] NULL,
	[contractno] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
