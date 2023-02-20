/****** Object:  Table [rd].[t_contractor_renewals]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[t_contractor_renewals](
	[contractor_supplier_no] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[cr_effective_date] [datetime] NULL
) ON [PRIMARY]

GO
