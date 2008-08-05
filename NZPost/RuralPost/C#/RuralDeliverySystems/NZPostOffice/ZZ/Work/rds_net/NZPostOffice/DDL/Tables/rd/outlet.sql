/****** Object:  Table [rd].[outlet]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[outlet](
	[outlet_id] [int] NOT NULL,
	[ot_code] [int] NULL,
	[region_id] [int] NULL,
	[o_name] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[o_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[o_telephone] [varchar](11) COLLATE Latin1_General_CI_AS NULL,
	[o_fax] [varchar](11) COLLATE Latin1_General_CI_AS NULL,
	[o_manager] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[o_responsibility_code] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[o_phy_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [outlet_cns] PRIMARY KEY CLUSTERED 
(
	[outlet_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
