CREATE TABLE [rd].[contract_type] (
    [ct_key]              INT          IDENTITY (1, 1) NOT NULL,
    [contract_type]       VARCHAR (40) NULL,
    [ct_next_contract]    INT          NULL,
    [ct_rd_ref_mandatory] VARCHAR (1)  NULL,
    CONSTRAINT [contract_type_cns] PRIMARY KEY CLUSTERED ([ct_key] ASC)
);

