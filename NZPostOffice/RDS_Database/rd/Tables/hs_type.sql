CREATE TABLE [rd].[hs_type] (
    [hst_id]                     INT           NOT NULL,
    [hst_name]                   VARCHAR (50)  NULL,
    [hst_description]            VARCHAR (200) NULL,
    [hst_help]                   VARCHAR (250) NULL,
    [hst_additional_date_errmsg] VARCHAR (250) NULL,
    [hst_notes_errmsg]           VARCHAR (250) NULL,
    CONSTRAINT [PK_hs_type] PRIMARY KEY CLUSTERED ([hst_id] ASC)
);

