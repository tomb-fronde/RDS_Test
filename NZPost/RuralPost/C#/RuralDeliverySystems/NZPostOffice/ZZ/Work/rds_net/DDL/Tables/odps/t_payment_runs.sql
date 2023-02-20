/****** Object:  Table [odps].[t_payment_runs]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_payment_runs](
	[pr_id] [int] IDENTITY(1,1) NOT NULL,
	[pr_date] [int] NOT NULL,
	[gl_posted] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pr_ap_posted] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[pr_contract_no] [int] NULL,
	[POTS] [varchar](50) COLLATE Latin1_General_CI_AS NULL CONSTRAINT [DF__t_payment___POTS__405A880E]  DEFAULT ('N'),
 CONSTRAINT [t_payment_runs_cns] PRIMARY KEY CLUSTERED 
(
	[pr_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
