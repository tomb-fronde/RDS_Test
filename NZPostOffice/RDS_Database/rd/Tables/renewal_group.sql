CREATE TABLE [rd].[renewal_group] (
    [rg_code]              INT          IDENTITY (1, 1) NOT NULL,
    [rg_description]       VARCHAR (30) NULL,
    [rg_next_renewal_date] DATETIME     NULL,
    CONSTRAINT [renewal_group_cns] PRIMARY KEY CLUSTERED ([rg_code] ASC)
);

