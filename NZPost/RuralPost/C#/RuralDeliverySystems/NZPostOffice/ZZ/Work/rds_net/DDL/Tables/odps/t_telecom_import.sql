/****** Object:  Table [odps].[t_telecom_import]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_telecom_import](
	[bill_month] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[bill_cycle] [int] NULL,
	[customer_no] [int] NULL,
	[account_no] [int] NULL,
	[account_name] [varchar](16) COLLATE Latin1_General_CI_AS NULL,
	[open_bal] [numeric](10, 2) NULL,
	[payments] [numeric](10, 2) NULL,
	[adj_tran] [numeric](10, 2) NULL,
	[bal_bf] [numeric](10, 2) NULL,
	[curr_chg] [numeric](10, 2) NULL,
	[total_due] [numeric](10, 2) NULL,
	[supplier_no] [int] NULL,
	[contract_no] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
