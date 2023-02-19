CREATE TABLE [rd].[contractor_procurement] (
    [contractor_supplier_no] INT NULL,
    [proc_id]                INT NULL,
    CONSTRAINT [FK_contractor] FOREIGN KEY ([contractor_supplier_no]) REFERENCES [rd].[contractor] ([contractor_supplier_no]),
    CONSTRAINT [FK_procurement] FOREIGN KEY ([proc_id]) REFERENCES [rd].[procurement] ([proc_id])
);

