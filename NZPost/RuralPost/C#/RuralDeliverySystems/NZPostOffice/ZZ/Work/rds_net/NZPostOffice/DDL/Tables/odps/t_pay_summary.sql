/****** Object:  Table [odps].[t_pay_summary]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_pay_summary](
	[region] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[contract_no] [int] NULL,
	[name] [varchar](52) COLLATE Latin1_General_CI_AS NULL,
	[m_standard] [numeric](18, 2) NULL,
	[m_allowance] [numeric](18, 2) NULL,
	[m_extension] [numeric](18, 2) NULL,
	[m_contract_adjustment] [numeric](18, 2) NULL,
	[m_Adpost] [numeric](18, 2) NULL,
	[m_CourierPost] [numeric](18, 2) NULL,
	[m_GST_value] [numeric](19, 2) NULL,
	[m_wtax_value] [numeric](19, 2) NULL,
	[m_adj_notax] [numeric](19, 2) NULL,
	[contract_type] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[m_ParcelPost] [numeric](18, 2) NULL,
	[m_Skyroad] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
