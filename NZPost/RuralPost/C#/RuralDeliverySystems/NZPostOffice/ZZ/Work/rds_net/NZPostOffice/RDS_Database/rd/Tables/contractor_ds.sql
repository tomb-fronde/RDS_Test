CREATE TABLE [rd].[contractor_ds] (
    [contractor_supplier_no] INT          NOT NULL,
    [cd_old_ds_no]           VARCHAR (50) NOT NULL,
    CONSTRAINT [contractor_ds_cns] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC, [cd_old_ds_no] ASC),
    CONSTRAINT [FK_contractor3] FOREIGN KEY ([contractor_supplier_no]) REFERENCES [rd].[contractor] ([contractor_supplier_no])
);


GO
CREATE NONCLUSTERED INDEX [ds_dsno]
    ON [rd].[contractor_ds]([cd_old_ds_no] ASC);


GO
CREATE NONCLUSTERED INDEX [ds_contractor]
    ON [rd].[contractor_ds]([contractor_supplier_no] ASC);

