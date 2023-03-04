CREATE TABLE [rd].[temp_Contract_Adjustments] (
    [contract_no]         INT             NOT NULL,
    [ca_date_occured]     DATETIME        NOT NULL,
    [ca_amount]           NUMERIC (10, 2) NOT NULL,
    [ca_reason]           VARCHAR (40)    NULL,
    [contract_seq_number] INT             NULL
);

