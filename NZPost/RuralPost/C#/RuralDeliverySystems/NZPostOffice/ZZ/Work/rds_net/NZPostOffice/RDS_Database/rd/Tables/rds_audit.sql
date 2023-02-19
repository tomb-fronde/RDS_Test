CREATE TABLE [rd].[rds_audit] (
    [a_key]        INT            IDENTITY (1, 1) NOT NULL,
    [a_datetime]   DATETIME       NOT NULL,
    [a_userid]     VARCHAR (20)   NULL,
    [a_contract]   INT            NULL,
    [a_contractor] INT            NULL,
    [a_comment]    VARCHAR (1000) NULL,
    [a_oldvalue]   VARCHAR (1000) NULL,
    [a_newvalue]   VARCHAR (1000) NULL,
    CONSTRAINT [rds_audit_cns] PRIMARY KEY CLUSTERED ([a_key] ASC)
);


GO
CREATE NONCLUSTERED INDEX [au_index]
    ON [rd].[rds_audit]([a_datetime] ASC);

