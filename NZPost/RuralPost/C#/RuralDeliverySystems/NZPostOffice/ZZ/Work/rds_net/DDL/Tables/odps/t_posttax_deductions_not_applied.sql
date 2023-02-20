/****** Object:  Table [odps].[t_posttax_deductions_not_applied]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_posttax_deductions_not_applied](
	[ded_id] [int] NOT NULL,
	[contractor_supplier_no] [int] NOT NULL,
	[comments] [varchar](300) COLLATE Latin1_General_CI_AS NULL,
	[invoice_id] [int] NULL,
 CONSTRAINT [t_posttax_deductions_not_applied_cns] PRIMARY KEY CLUSTERED 
(
	[ded_id] ASC,
	[contractor_supplier_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
