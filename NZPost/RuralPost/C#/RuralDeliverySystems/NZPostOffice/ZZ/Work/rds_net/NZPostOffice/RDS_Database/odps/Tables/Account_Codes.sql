CREATE TABLE [odps].[Account_Codes] (
    [ac_id]          INT           IDENTITY (1, 1) NOT NULL,
    [ac_code]        VARCHAR (100) NOT NULL,
    [ac_description] VARCHAR (200) NOT NULL,
    CONSTRAINT [Account_Codes_cns] PRIMARY KEY CLUSTERED ([ac_id] ASC)
);

