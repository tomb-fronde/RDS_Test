/****** Object:  Table [odps].[t_payment_runs_2]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_payment_runs_2](
	[pr_id] [int] NOT NULL,
	[pr_date] [int] NOT NULL,
	[gl_posted] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pr_ap_posted] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pr_contract_no] [int] NULL,
	[POTS] [varchar](50) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
