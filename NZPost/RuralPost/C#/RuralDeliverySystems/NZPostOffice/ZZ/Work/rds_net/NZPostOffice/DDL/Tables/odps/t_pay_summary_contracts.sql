/****** Object:  Table [odps].[t_pay_summary_contracts]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_pay_summary_contracts](
	[region_name] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[region_id] [int] NULL,
	[contractor_supplier_no] [int] NULL,
	[contract_no] [int] NULL,
	[contract_seq_number] [int] NULL,
	[invoice_id] [int] NULL,
	[ct_key] [int] NULL,
	[co_surname] [varchar](52) COLLATE Latin1_General_CI_AS NULL,
	[contract_type] [varchar](40) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
