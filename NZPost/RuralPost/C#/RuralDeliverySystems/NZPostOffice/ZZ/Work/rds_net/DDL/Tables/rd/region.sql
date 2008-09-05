/****** Object:  Table [rd].[region]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[region](
	[region_id] [int] NOT NULL,
	[rgn_name] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[rgn_rcm_manager] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[rgn_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[rgn_telephone] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[rgn_fax] [varchar](11) COLLATE Latin1_General_CI_AS NULL,
	[rgn_responsibility_centre_no] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[rgn_expenditure_code] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[rgn_mobile] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [region_cns] PRIMARY KEY CLUSTERED 
(
	[region_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
