/****** Object:  Table [odps].[t_shell_import]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_shell_import](
	[contract_no] [int] NULL,
	[contractor] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
	[total_deduction] [numeric](10, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
