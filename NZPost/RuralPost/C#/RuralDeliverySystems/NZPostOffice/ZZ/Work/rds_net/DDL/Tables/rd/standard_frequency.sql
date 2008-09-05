/****** Object:  Table [rd].[standard_frequency]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[standard_frequency](
	[sf_key] [int] IDENTITY(1,1) NOT NULL,
	[sf_description] [varchar](35) COLLATE Latin1_General_CI_AS NULL,
	[sf_days_week] [smallint] NULL,
 CONSTRAINT [standard_frequency_cns] PRIMARY KEY CLUSTERED 
(
	[sf_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
