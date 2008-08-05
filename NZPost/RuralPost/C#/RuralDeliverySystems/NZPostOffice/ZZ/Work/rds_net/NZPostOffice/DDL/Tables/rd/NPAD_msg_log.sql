/****** Object:  Table [rd].[NPAD_msg_log]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[NPAD_msg_log](
	[msg_date] [datetime] NULL,
	[msg_username] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[msg_type] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[msg_dpid] [int] NULL,
	[msg_status] [int] NULL,
	[msg_description] [varchar](120) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
