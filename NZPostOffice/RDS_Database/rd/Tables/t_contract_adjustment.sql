CREATE TABLE [rd].[t_contract_adjustment] (
    [contract_no]     INT             NOT NULL,
    [ca_date_occured] DATETIME        NOT NULL,
    [ca_amount]       NUMERIC (10, 2) NOT NULL,
    [ca_reason]       VARCHAR (100)   NOT NULL
);

