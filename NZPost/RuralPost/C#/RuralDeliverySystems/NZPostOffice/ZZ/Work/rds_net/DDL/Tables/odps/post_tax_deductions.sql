/****** Object:  Table [odps].[post_tax_deductions]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[post_tax_deductions](
	[ded_id] [int] IDENTITY(1,1) NOT NULL,
	[ded_description] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[ded_priority] [smallint] NULL,
	[pct_id] [int] NULL,
	[ded_reference] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[ded_type_period] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[ded_percent_gross] [numeric](5, 2) NULL,
	[ded_percent_net] [numeric](5, 2) NULL,
	[ded_percent_start_balance] [numeric](5, 2) NULL,
	[ded_fixed_amount] [numeric](12, 2) NULL,
	[ded_min_threshold_gross] [numeric](12, 2) NULL,
	[ded_max_threshold_net_pct] [numeric](5, 2) NULL,
	[ded_default_minimum] [numeric](12, 2) NULL,
	[ded_start_balance] [numeric](12, 2) NULL,
	[ded_end_balance] [numeric](12, 2) NULL,
	[contractor_supplier_no] [int] NULL,
	[ded_pay_highest_value] [smallint] NULL,
 CONSTRAINT [post_tax_deductions_cns] PRIMARY KEY CLUSTERED 
(
	[ded_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
