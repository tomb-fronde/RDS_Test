/****** Object:  Table [odps].[t_invoice_piecerates2]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_invoice_piecerates2](
	[invoice_id] [int] NOT NULL,
	[atype] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[prd_date] [datetime] NOT NULL,
	[prt_code] [varchar](4) COLLATE Latin1_General_CI_AS NULL,
	[prd_quantity] [int] NOT NULL,
	[rate] [numeric](12, 3) NULL,
	[cost] [numeric](12, 2) NULL,
	[rownum] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
