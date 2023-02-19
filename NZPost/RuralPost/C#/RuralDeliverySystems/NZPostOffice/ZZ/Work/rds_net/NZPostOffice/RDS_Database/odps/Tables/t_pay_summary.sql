CREATE TABLE [odps].[t_pay_summary] (
    [region]                VARCHAR (40)    NULL,
    [contract_no]           INT             NULL,
    [name]                  VARCHAR (52)    NULL,
    [m_standard]            NUMERIC (18, 2) NULL,
    [m_allowance]           NUMERIC (18, 2) NULL,
    [m_extension]           NUMERIC (18, 2) NULL,
    [m_contract_adjustment] NUMERIC (18, 2) NULL,
    [m_Adpost]              NUMERIC (18, 2) NULL,
    [m_CourierPost]         NUMERIC (18, 2) NULL,
    [m_GST_value]           NUMERIC (19, 2) NULL,
    [m_wtax_value]          NUMERIC (19, 2) NULL,
    [m_adj_notax]           NUMERIC (19, 2) NULL,
    [contract_type]         VARCHAR (40)    NULL,
    [m_ParcelPost]          NUMERIC (18, 2) NULL,
    [m_Skyroad]             NUMERIC (18, 2) NULL
);

