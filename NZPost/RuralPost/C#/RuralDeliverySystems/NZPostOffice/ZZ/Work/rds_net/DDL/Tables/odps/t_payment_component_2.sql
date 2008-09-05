/****** Object:  Table [odps].[t_payment_component_2]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_payment_component_2](
	[pc_id] [int] NOT NULL,
	[pct_id] [int] NOT NULL,
	[invoice_id] [int] NOT NULL,
	[pc_amount] [numeric](12, 2) NOT NULL,
	[comments] [varchar](300) COLLATE Latin1_General_CI_AS NULL,
	[misc_date] [datetime] NULL,
	[misc_string] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[misc_decimal] [numeric](20, 12) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
