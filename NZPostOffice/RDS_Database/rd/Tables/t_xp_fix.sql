CREATE TABLE [rd].[t_xp_fix] (
    [id]               INT             IDENTITY (1, 1) NOT NULL,
    [data_contract_no] INT             NOT NULL,
    [data_xp_value]    NUMERIC (12, 2) NOT NULL,
    [data_tax]         NUMERIC (12, 2) NOT NULL,
    [data_gst]         NUMERIC (12, 2) NOT NULL,
    [pc_invoice_id]    INT             NULL,
    [pc_gst]           NUMERIC (12, 2) NOT NULL,
    [pc_tax]           NUMERIC (12, 2) NOT NULL,
    [total_gst]        NUMERIC (12, 2) NOT NULL,
    [total_tax]        NUMERIC (12, 2) NOT NULL,
    [pc_comments]      VARCHAR (2)     NULL,
    CONSTRAINT [t_xp_fix_cns] PRIMARY KEY CLUSTERED ([id] ASC)
);

