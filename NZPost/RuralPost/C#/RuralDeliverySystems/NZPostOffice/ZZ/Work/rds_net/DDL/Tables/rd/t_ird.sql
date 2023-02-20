/****** Object:  Table [rd].[t_ird]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[t_ird](
	[contractor_supplier_no] [int] NOT NULL,
	[c_ird_no] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_gst_number] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [t_ird_cns] PRIMARY KEY CLUSTERED 
(
	[contractor_supplier_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
