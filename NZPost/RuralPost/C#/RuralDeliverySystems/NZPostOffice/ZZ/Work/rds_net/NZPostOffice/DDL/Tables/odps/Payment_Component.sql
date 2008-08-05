/****** Object:  Table [odps].[Payment_Component]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[Payment_Component](
	[pc_id] [int] NOT NULL,
	[pct_id] [int] NOT NULL,
	[Invoice_ID] [int] NOT NULL,
	[pc_amount] [numeric](12, 2) NOT NULL,
	[comments] [varchar](400) COLLATE Latin1_General_CI_AS NULL,
	[misc_date] [datetime] NULL,
	[misc_string] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[misc_decimal] [numeric](20, 12) NULL,
 CONSTRAINT [Payment_Component_cns] PRIMARY KEY CLUSTERED 
(
	[pc_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
