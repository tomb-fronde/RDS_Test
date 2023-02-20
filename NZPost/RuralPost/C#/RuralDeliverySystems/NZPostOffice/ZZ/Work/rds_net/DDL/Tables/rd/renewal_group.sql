/****** Object:  Table [rd].[renewal_group]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[renewal_group](
	[rg_code] [int] IDENTITY(1,1) NOT NULL,
	[rg_description] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
	[rg_next_renewal_date] [datetime] NULL,
 CONSTRAINT [renewal_group_cns] PRIMARY KEY CLUSTERED 
(
	[rg_code] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
