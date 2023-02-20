/****** Object:  Table [rd].[route_freq_verbs]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[route_freq_verbs](
	[rfv_id] [int] IDENTITY(1,1) NOT NULL,
	[rfv_description] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [route_freq_verbs_cns] PRIMARY KEY CLUSTERED 
(
	[rfv_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
