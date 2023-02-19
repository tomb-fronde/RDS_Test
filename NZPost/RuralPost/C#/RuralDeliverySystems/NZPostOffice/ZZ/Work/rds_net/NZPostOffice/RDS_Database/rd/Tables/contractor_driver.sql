CREATE TABLE [rd].[contractor_driver] (
    [contractor_supplier_no] INT NOT NULL,
    [driver_no]              INT NOT NULL,
    CONSTRAINT [pk_contractor_driver] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC, [driver_no] ASC)
);

