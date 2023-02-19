CREATE TABLE [rd].[post_code] (
    [post_code_id]   INT          IDENTITY (1, 1) NOT NULL,
    [post_code]      VARCHAR (4)  NULL,
    [post_mail_town] VARCHAR (40) NULL,
    [post_district]  VARCHAR (40) NULL,
    [rd_no]          VARCHAR (4)  NULL,
    [contract_no]    INT          NULL,
    CONSTRAINT [post_code_cns] PRIMARY KEY CLUSTERED ([post_code_id] ASC)
);

