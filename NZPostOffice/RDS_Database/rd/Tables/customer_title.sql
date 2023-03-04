CREATE TABLE [rd].[customer_title] (
    [customer_title_id]   INT          NOT NULL,
    [customer_title_name] VARCHAR (20) NULL,
    [user_id]             VARCHAR (20) NULL,
    [last_mod_date]       DATETIME     NULL,
    CONSTRAINT [customer_title_cns] PRIMARY KEY CLUSTERED ([customer_title_id] ASC)
);

