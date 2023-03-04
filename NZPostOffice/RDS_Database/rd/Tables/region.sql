CREATE TABLE [rd].[region] (
    [region_id]                    INT           NOT NULL,
    [rgn_name]                     VARCHAR (40)  NULL,
    [rgn_rcm_manager]              VARCHAR (40)  NULL,
    [rgn_address]                  VARCHAR (200) NULL,
    [rgn_telephone]                VARCHAR (20)  NULL,
    [rgn_fax]                      VARCHAR (11)  NULL,
    [rgn_responsibility_centre_no] VARCHAR (10)  NULL,
    [rgn_expenditure_code]         VARCHAR (10)  NULL,
    [rgn_mobile]                   VARCHAR (20)  NULL,
    CONSTRAINT [region_cns] PRIMARY KEY CLUSTERED ([region_id] ASC)
);

