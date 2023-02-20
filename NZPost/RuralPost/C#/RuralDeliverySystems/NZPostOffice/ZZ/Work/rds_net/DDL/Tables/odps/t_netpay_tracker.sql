/****** Object:  Table [odps].[t_netpay_tracker]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [odps].[t_netpay_tracker](
	[contractor_supplier_no] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[net_pay] [numeric](12, 2) NULL,
	[invoice_id] [int] NOT NULL,
	[gross_pay] [numeric](12, 2) NULL,
 CONSTRAINT [t_netpay_tracker_cns] PRIMARY KEY CLUSTERED 
(
	[contractor_supplier_no] ASC,
	[contract_no] ASC,
	[invoice_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
