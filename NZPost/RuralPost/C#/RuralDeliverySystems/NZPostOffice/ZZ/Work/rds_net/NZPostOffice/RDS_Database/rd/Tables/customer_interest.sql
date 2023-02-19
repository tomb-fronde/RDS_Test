CREATE TABLE [rd].[customer_interest] (
    [cust_id]     INT NOT NULL,
    [interest_id] INT NOT NULL,
    CONSTRAINT [customer_interest_cns] PRIMARY KEY CLUSTERED ([cust_id] ASC, [interest_id] ASC),
    CONSTRAINT [cust_interest2] FOREIGN KEY ([interest_id]) REFERENCES [rd].[interest] ([interest_id]),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_RDS_CUST] FOREIGN KEY ([cust_id]) REFERENCES [rd].[rds_customer] ([cust_id]) ON DELETE CASCADE
);

