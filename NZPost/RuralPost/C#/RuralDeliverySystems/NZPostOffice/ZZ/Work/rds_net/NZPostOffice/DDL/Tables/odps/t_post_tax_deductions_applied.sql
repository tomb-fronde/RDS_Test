/****** Object:  Table [odps].[t_post_tax_deductions_applied]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [odps].[t_post_tax_deductions_applied](
	[pcd_id] [int] IDENTITY(1,1) NOT NULL,
	[pcd_amount] [numeric](12, 2) NOT NULL,
	[ded_id] [int] NOT NULL,
	[pcd_date] [datetime] NULL,
	[invoice_id] [int] NULL,
 CONSTRAINT [t_post_tax_deductions_applied_cns] PRIMARY KEY CLUSTERED 
(
	[pcd_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
