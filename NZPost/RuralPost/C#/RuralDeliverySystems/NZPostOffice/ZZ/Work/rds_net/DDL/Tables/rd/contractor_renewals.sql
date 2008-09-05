/****** Object:  Table [rd].[contractor_renewals]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[contractor_renewals](
	[contractor_supplier_no] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[cr_effective_date] [datetime] NULL,
 CONSTRAINT [contractor_renewals_cns] PRIMARY KEY CLUSTERED 
(
	[contractor_supplier_no] ASC,
	[contract_no] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
