/****** Object:  Table [odps].[t_payment]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_payment](
	[contractor_supplier_no] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[invoice_id] [int] IDENTITY(1,1) NOT NULL,
	[pr_id] [int] NOT NULL,
	[invoice_date] [datetime] NOT NULL,
	[witholding_tax_rate_applied] [numeric](5, 2) NULL,
	[invoice_no] [int] NULL,
	[case_no] [int] NULL,
	[POTS] [varchar](50) COLLATE Latin1_General_CI_AS NULL CONSTRAINT [DF__t_payment__POTS__4336F4B9]  DEFAULT ('N'),
 CONSTRAINT [t_payment_cns] PRIMARY KEY CLUSTERED 
(
	[invoice_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
