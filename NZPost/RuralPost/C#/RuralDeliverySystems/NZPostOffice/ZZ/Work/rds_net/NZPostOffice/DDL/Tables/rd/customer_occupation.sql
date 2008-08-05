/****** Object:  Table [rd].[customer_occupation]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[customer_occupation](
	[cust_id] [int] NOT NULL,
	[occupation_id] [int] NOT NULL,
 CONSTRAINT [customer_occupation_cns] PRIMARY KEY CLUSTERED 
(
	[cust_id] ASC,
	[occupation_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
