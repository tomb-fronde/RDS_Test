CREATE TABLE [rd].[contractor] (
    [contractor_supplier_no]       INT            NOT NULL,
    [c_title]                      VARCHAR (10)   NULL,
    [c_surname_company]            VARCHAR (50)   NULL,
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
    [NZ_Post_Employee]             VARCHAR (1)    NULL,
    [c_witholding_tax_certificate] VARCHAR (1)    NULL,
    [c_survey_name]                VARCHAR (60)   NULL,
    [c_tpid_number]                INT            NULL,
    [c_email_address]              VARCHAR (50)   NULL,
    [c_mobile2]                    VARCHAR (15)   NULL,
    [c_notes]                      VARCHAR (200)  NULL,
    [c_prime_contact]              INT            NULL,
    [supplier_no]                  CHAR (8)       NULL,
    CONSTRAINT [PK_contractor] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC)
);


GO
CREATE NONCLUSTERED INDEX [contractor_name]
    ON [rd].[contractor]([c_surname_company] ASC);

