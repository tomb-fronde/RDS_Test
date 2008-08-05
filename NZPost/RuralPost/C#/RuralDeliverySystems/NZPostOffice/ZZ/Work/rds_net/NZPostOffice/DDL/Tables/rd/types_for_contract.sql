/****** Object:  Table [rd].[types_for_contract]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[types_for_contract](
	[ct_key] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
 CONSTRAINT [types_for_contract_cns] PRIMARY KEY CLUSTERED 
(
	[ct_key] ASC,
	[contract_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
