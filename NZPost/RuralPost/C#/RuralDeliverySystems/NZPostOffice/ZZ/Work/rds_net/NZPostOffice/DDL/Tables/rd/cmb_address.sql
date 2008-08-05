/****** Object:  Table [rd].[cmb_address]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[cmb_address](
	[cmb_id] [int] NOT NULL,
	[contract_no] [int] NULL,
	[cmb_box_no] [varchar](5) COLLATE Latin1_General_CI_AS NULL,
	[tc_id] [int] NULL,
	[post_code_id] [int] NULL,
	[adr_rd_no] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[cmb_cust_surname] [varchar](45) COLLATE Latin1_General_CI_AS NULL,
	[cmb_cust_initials] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
	[cmb_date_added] [datetime] NULL,
	[cmb_last_amended_date] [datetime] NULL,
	[cmb_last_amended_user] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [cmb_address_cns] PRIMARY KEY CLUSTERED 
(
	[cmb_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [cmb_address UNIQUE (cmb_id)] UNIQUE NONCLUSTERED 
(
	[cmb_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
