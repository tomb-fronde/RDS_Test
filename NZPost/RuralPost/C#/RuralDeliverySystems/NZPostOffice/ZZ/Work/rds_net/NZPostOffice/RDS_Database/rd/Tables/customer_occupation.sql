CREATE TABLE [rd].[customer_occupation] (
    [cust_id]       INT NOT NULL,
    [occupation_id] INT NOT NULL,
    CONSTRAINT [customer_occupation_cns] PRIMARY KEY CLUSTERED ([cust_id] ASC, [occupation_id] ASC),
    CONSTRAINT [cust_occupation2] FOREIGN KEY ([occupation_id]) REFERENCES [rd].[occupation] ([occupation_id]),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_RDS_CUST1] FOREIGN KEY ([cust_id]) REFERENCES [rd].[rds_customer] ([cust_id])
);

