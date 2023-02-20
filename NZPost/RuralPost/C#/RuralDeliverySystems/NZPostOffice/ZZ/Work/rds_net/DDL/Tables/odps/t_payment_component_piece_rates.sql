/****** Object:  Table [odps].[t_payment_component_piece_rates]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [odps].[t_payment_component_piece_rates](
	[pcpr_id] [int] IDENTITY(1,1) NOT NULL,
	[prt_key] [int] NOT NULL,
	[pc_id] [int] NOT NULL,
	[pcpr_volume] [int] NOT NULL,
	[pcpr_value] [numeric](12, 2) NOT NULL,
 CONSTRAINT [t_payment_component_piece_rates_cns] PRIMARY KEY CLUSTERED 
(
	[pcpr_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
