CREATE TABLE [odps].[PBU_Code] (
    [PBU_Code]        VARCHAR (10)  NOT NULL,
    [PBU_Description] VARCHAR (100) NOT NULL,
    [PBU_ID]          INT           IDENTITY (1, 1) NOT NULL,
    [pbu_email_1]     VARCHAR (50)  NULL,
    [pbu_email_2]     VARCHAR (50)  NULL,
    [pbu_email_3]     VARCHAR (50)  NULL,
    CONSTRAINT [PBU_Code_cns] PRIMARY KEY CLUSTERED ([PBU_ID] ASC)
);

