CREATE TABLE [rd].[t_contractor] (
    [contractor_supplier_no]       INT            NOT NULL,
    [c_title]                      VARCHAR (10)   NULL,
    [c_surname_company]            VARCHAR (40)   NULL,
    [c_first_names]                VARCHAR (40)   NULL,
    [c_initials]                   VARCHAR (10)   NULL,
    [c_address]                    VARCHAR (200)  NULL,
    [c_phone_day]                  VARCHAR (15)   NULL,
    [c_phone_night]                VARCHAR (15)   NULL,
    [c_bank_account_no]            VARCHAR (18)   NULL,
    [c_ird_no]                     VARCHAR (10)   NULL,
    [c_gst_number]                 VARCHAR (10)   NULL,
    [c_tax_rate]                   NUMERIC (4, 2) NULL,
    [c_mobile]                     VARCHAR (15)   NULL,
    [c_salutation]                 VARCHAR (40)   NULL,
    [_______________]              VARCHAR (1)    NULL,
    [nz_post_employee]             VARCHAR (1)    NULL,
    [c_witholding_tax_certificate] VARCHAR (1)    NULL
);

