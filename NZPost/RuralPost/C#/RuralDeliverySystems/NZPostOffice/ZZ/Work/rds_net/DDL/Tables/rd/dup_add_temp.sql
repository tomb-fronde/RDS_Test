/****** Object:  Table [rd].[dup_add_temp]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[dup_add_temp](
	[contract_no] [varchar](5) COLLATE Latin1_General_CI_AS NULL,
	[count] [int] NULL,
	[tc_name] [varchar](25) COLLATE Latin1_General_CI_AS NULL,
	[road_name] [varchar](25) COLLATE Latin1_General_CI_AS NULL,
	[adr_no] [varchar](6) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
