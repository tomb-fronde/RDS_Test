/****** Object:  Table [rd].[types_for_contractor]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[types_for_contractor](
	[contractor_supplier_no] [int] NOT NULL,
	[ct_key] [int] NOT NULL,
 CONSTRAINT [types_for_contractor_cns] PRIMARY KEY CLUSTERED 
(
	[contractor_supplier_no] ASC,
	[ct_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
