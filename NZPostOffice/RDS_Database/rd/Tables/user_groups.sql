CREATE TABLE [rd].[user_groups] (
    [gp_code]          NUMERIC (10)  NOT NULL,
    [gp_title]         VARCHAR (40)  NULL,
    [gp_cargo]         VARCHAR (255) NULL,
    [gp_created_date]  DATETIME      NULL,
    [gp_created_by]    VARCHAR (20)  NULL,
    [gp_modified_date] DATETIME      NULL,
    [gp_modified_by]   VARCHAR (20)  NULL,
    [gp_level_1]       NUMERIC (2)   NULL,
    [gp_level_2]       NUMERIC (2)   NULL,
    [gp_level_3]       NUMERIC (2)   NULL,
    [gp_level_4]       NUMERIC (2)   NULL,
    [gp_level_5]       NUMERIC (2)   NULL,
    [gp_level_6]       NUMERIC (2)   NULL,
    [gp_level_7]       NUMERIC (2)   NULL,
    [gp_level_8]       NUMERIC (2)   NULL,
    [gp_level_9]       NUMERIC (2)   NULL,
    [gp_odps]          NUMERIC (2)   NULL,
    [gp_payrun]        NUMERIC (2)   NULL,
    CONSTRAINT [user_groups_cns] PRIMARY KEY CLUSTERED ([gp_code] ASC)
);

