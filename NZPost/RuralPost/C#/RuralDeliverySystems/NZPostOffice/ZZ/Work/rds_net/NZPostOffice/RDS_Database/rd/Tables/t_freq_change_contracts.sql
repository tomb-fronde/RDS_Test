CREATE TABLE [rd].[t_freq_change_contracts] (
    [contract_no]      INT          NOT NULL,
    [sf_key]           INT          NOT NULL,
    [rf_delivery_days] VARCHAR (7)  NOT NULL,
    [region_id]        INT          NULL,
    [rgn_name]         VARCHAR (40) NULL,
    [rg_code]          INT          NULL,
    [rg_description]   VARCHAR (30) NULL
);

