/****** Object:  Table [rd].[customer_address_moves]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[customer_address_moves](
	[adr_id] [int] NOT NULL,
	[cust_id] [int] NOT NULL,
	[move_in_date] [datetime] NOT NULL,
	[move_out_date] [datetime] NULL,
	[move_out_source] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[move_out_user] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[dp_id] [int] NULL,
 CONSTRAINT [customer_address_moves_cns] PRIMARY KEY CLUSTERED 
(
	[adr_id] ASC,
	[cust_id] ASC,
	[move_in_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
