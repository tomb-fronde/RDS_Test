/****** Object:  Table [rd].[rengrp1]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[rengrp1](
	[rgn_name] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[rgn_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[rgn_telephone] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[rgn_fax] [varchar](11) COLLATE Latin1_General_CI_AS NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[c_title] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_initials] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[c_surname_company] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[rgn_rcm_manager] [varchar](40) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
