/****** Object:  Table [rd].[t_xp_fix]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_xp_fix](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data_contract_no] [int] NOT NULL,
	[data_xp_value] [numeric](12, 2) NOT NULL,
	[data_tax] [numeric](12, 2) NOT NULL,
	[data_gst] [numeric](12, 2) NOT NULL,
	[pc_invoice_id] [int] NULL,
	[pc_gst] [numeric](12, 2) NOT NULL,
	[pc_tax] [numeric](12, 2) NOT NULL,
	[total_gst] [numeric](12, 2) NOT NULL,
	[total_tax] [numeric](12, 2) NOT NULL,
	[pc_comments] [varchar](2) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [t_xp_fix_cns] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
