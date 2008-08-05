/****** Object:  Table [rd].[contract_type]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract_type](
	[ct_key] [int] IDENTITY(1,1) NOT NULL,
	[contract_type] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[ct_next_contract] [int] NULL,
	[ct_rd_ref_mandatory] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [contract_type_cns] PRIMARY KEY CLUSTERED 
(
	[ct_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
