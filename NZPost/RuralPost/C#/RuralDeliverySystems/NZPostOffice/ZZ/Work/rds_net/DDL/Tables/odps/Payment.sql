/****** Object:  Table [odps].[Payment]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[Payment](
	[contractor_supplier_no] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[Invoice_ID] [int] NOT NULL,
	[pr_id] [int] NOT NULL,
	[Invoice_date] [datetime] NOT NULL,
	[Witholding_tax_rate_applied] [numeric](5, 2) NULL,
	[invoice_no] [int] NULL,
	[case_no] [int] NULL,
	[POTS] [varchar](50) COLLATE Latin1_General_CI_AS NULL CONSTRAINT [DF__Payment__POTS__1C1D2798]  DEFAULT ('N'),
 CONSTRAINT [Payment_cns] PRIMARY KEY CLUSTERED 
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
