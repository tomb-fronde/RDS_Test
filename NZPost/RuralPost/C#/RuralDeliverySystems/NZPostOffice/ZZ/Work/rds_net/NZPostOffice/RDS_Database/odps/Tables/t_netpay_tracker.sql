CREATE TABLE [odps].[t_netpay_tracker] (
    [contractor_supplier_no] INT             NOT NULL,
    [contract_no]            INT             NOT NULL,
    [net_pay]                NUMERIC (12, 2) NULL,
    [invoice_id]             INT             NOT NULL,
    [gross_pay]              NUMERIC (12, 2) NULL,
    CONSTRAINT [t_netpay_tracker_cns] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC, [contract_no] ASC, [invoice_id] ASC)
);

