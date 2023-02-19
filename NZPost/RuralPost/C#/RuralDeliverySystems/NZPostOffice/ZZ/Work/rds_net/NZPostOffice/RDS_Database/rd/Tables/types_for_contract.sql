CREATE TABLE [rd].[types_for_contract] (
    [ct_key]      INT NOT NULL,
    [contract_no] INT NOT NULL,
    CONSTRAINT [types_for_contract_cns] PRIMARY KEY CLUSTERED ([ct_key] ASC, [contract_no] ASC),
    CONSTRAINT [FK_contract_type] FOREIGN KEY ([ct_key]) REFERENCES [rd].[contract_type] ([ct_key]),
    CONSTRAINT [FK_contract5] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no])
);


GO
CREATE NONCLUSTERED INDEX [itc_key]
    ON [rd].[types_for_contract]([ct_key] ASC);


GO
CREATE NONCLUSTERED INDEX [itc_contract]
    ON [rd].[types_for_contract]([contract_no] ASC);

