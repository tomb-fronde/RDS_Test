/****** Object:  Table [rd].[rds_temp]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[rds_temp](
	[rds_id] [int] NOT NULL,
	[rds_code] [int] NOT NULL,
 CONSTRAINT [rds_temp_cns] PRIMARY KEY CLUSTERED 
(
	[rds_id] ASC,
	[rds_code] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
