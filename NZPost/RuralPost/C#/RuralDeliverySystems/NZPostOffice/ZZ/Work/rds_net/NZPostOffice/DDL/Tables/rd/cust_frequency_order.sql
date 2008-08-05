/****** Object:  Table [rd].[cust_frequency_order]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[cust_frequency_order](
	[contract_no] [int] NOT NULL,
	[sf_key] [int] NOT NULL,
	[rf_delivery_days] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[cust_id] [int] NOT NULL,
	[cfo_previous_customer] [int] NULL,
	[cfo_sequence] [smallint] NULL,
 CONSTRAINT [cust_frequency_order_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[sf_key] ASC,
	[rf_delivery_days] ASC,
	[cust_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
