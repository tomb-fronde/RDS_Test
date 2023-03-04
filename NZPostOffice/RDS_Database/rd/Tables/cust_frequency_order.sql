CREATE TABLE [rd].[cust_frequency_order] (
    [contract_no]           INT          NOT NULL,
    [sf_key]                INT          NOT NULL,
    [rf_delivery_days]      VARCHAR (50) NOT NULL,
    [cust_id]               INT          NOT NULL,
    [cfo_previous_customer] INT          NULL,
    [cfo_sequence]          SMALLINT     NULL,
    CONSTRAINT [cust_frequency_order_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [sf_key] ASC, [rf_delivery_days] ASC, [cust_id] ASC)
);

