/****** Object:  Table [odps].[t_payment_component_piece_rates_2]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [odps].[t_payment_component_piece_rates_2](
	[pcpr_id] [int] NOT NULL,
	[prt_key] [int] NOT NULL,
	[pc_id] [int] NOT NULL,
	[pcpr_volume] [int] NOT NULL,
	[pcpr_value] [numeric](12, 2) NOT NULL
) ON [PRIMARY]

GO
