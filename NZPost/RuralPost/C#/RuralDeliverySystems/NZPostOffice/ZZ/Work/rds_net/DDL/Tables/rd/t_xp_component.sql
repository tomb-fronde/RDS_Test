/****** Object:  Table [rd].[t_xp_component]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[t_xp_component](
	[pc_id] [int] NULL,
	[pcpr_value] [numeric](12, 2) NULL,
	[pcpr_volume] [int] NULL,
	[prt_key] [int] NULL,
	[invoice_id] [int] NULL,
	[contract_no] [int] NULL,
	[pcpr_value_sum] [numeric](12, 2) NULL
) ON [PRIMARY]

GO
