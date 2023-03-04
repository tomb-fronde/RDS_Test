CREATE TABLE [rd].[contract_vehical] (
    [vehicle_number]                 INT             NOT NULL,
    [contract_no]                    INT             NOT NULL,
    [contract_seq_number]            INT             NOT NULL,
    [start_kms]                      INT             NULL,
    [vehicle_allowance_paid_to_date] NUMERIC (10, 2) NULL,
    [cv_vehical_status]              VARCHAR (1)     NULL,
    [signage_compliant]              VARCHAR (1)     NULL,
    CONSTRAINT [contract_vehical_cns] PRIMARY KEY CLUSTERED ([vehicle_number] ASC, [contract_no] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_contract_renewals5] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number]),
    CONSTRAINT [FK_vehicle] FOREIGN KEY ([vehicle_number]) REFERENCES [rd].[vehicle] ([vehicle_number])
);

