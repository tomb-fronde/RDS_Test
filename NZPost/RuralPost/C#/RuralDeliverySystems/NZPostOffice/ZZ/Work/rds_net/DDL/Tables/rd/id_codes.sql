/****** Object:  Table [rd].[id_codes]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[id_codes](
	[sequence_name] [varchar](20) COLLATE Latin1_General_CI_AS NOT NULL,
	[next_value] [int] NOT NULL,
 CONSTRAINT [id_codes_cns] PRIMARY KEY CLUSTERED 
(
	[sequence_name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
