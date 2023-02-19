CREATE TABLE [rd].[types_for_contractor] (
    [contractor_supplier_no] INT NOT NULL,
    [ct_key]                 INT NOT NULL,
    CONSTRAINT [types_for_contractor_cns] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC, [ct_key] ASC),
    CONSTRAINT [FK_contract_type2] FOREIGN KEY ([ct_key]) REFERENCES [rd].[contract_type] ([ct_key]),
    CONSTRAINT [FK_contractor2] FOREIGN KEY ([contractor_supplier_no]) REFERENCES [rd].[contractor] ([contractor_supplier_no])
);

