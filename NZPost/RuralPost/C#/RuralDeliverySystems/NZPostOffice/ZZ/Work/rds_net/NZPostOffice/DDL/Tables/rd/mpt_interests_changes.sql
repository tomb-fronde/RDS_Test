/****** Object:  Table [rd].[mpt_interests_changes]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[mpt_interests_changes](
	[cust_id] [int] NOT NULL,
	[type] [char](1) COLLATE Latin1_General_CI_AS NOT NULL,
	[code] [int] NOT NULL,
	[change_type] [char](1) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
