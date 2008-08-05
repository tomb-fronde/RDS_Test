/****** Object:  Table [rd].[contractor_ds]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contractor_ds](
	[contractor_supplier_no] [int] NOT NULL,
	[cd_old_ds_no] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [contractor_ds_cns] PRIMARY KEY CLUSTERED 
(
	[contractor_supplier_no] ASC,
	[cd_old_ds_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
