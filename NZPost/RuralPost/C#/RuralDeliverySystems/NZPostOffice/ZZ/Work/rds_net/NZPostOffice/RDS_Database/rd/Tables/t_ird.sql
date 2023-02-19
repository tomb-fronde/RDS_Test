CREATE TABLE [rd].[t_ird] (
    [contractor_supplier_no] INT          NOT NULL,
    [c_ird_no]               VARCHAR (10) NULL,
    [c_gst_number]           VARCHAR (10) NULL,
    CONSTRAINT [t_ird_cns] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC)
);

