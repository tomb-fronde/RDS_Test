/****** Object:  Table [rd].[del_hours_variables]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[del_hours_variables](
	[dhv_travelling_speed] [smallint] NOT NULL,
	[dhr_seconds_customer] [smallint] NOT NULL,
 CONSTRAINT [del_hours_variables_cns] PRIMARY KEY CLUSTERED 
(
	[dhv_travelling_speed] ASC,
	[dhr_seconds_customer] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
