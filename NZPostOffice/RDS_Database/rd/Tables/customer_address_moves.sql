CREATE TABLE [rd].[customer_address_moves] (
    [adr_id]          INT          NOT NULL,
    [cust_id]         INT          NOT NULL,
    [move_in_date]    DATETIME     NOT NULL,
    [move_out_date]   DATETIME     NULL,
    [move_out_source] VARCHAR (40) NULL,
    [move_out_user]   VARCHAR (20) NULL,
    [dp_id]           INT          NULL,
    CONSTRAINT [customer_address_moves_cns] PRIMARY KEY CLUSTERED ([adr_id] ASC, [cust_id] ASC, [move_in_date] ASC),
    CONSTRAINT [FK_CUSTOMER_REF_582_RDS_CUST] FOREIGN KEY ([cust_id]) REFERENCES [rd].[rds_customer] ([cust_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CUSTOMER_REF_588_ADDRESS] FOREIGN KEY ([adr_id]) REFERENCES [rd].[address] ([adr_id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [idx_adrm_id]
    ON [rd].[customer_address_moves]([adr_id] ASC);

