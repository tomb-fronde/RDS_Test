CREATE TABLE [rd].[t_fuel_allowance] (
    [contract_no]    INT             NOT NULL,
    [effective_date] DATETIME        NOT NULL,
    [amount]         NUMERIC (10, 2) NOT NULL,
    [notes]          VARCHAR (100)   NOT NULL
);

