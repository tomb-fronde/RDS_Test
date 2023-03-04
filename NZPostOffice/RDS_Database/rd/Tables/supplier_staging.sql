CREATE TABLE [rd].[supplier_staging] (
    [dummy]              VARCHAR (10)  NOT NULL,
    [supplier_id]        VARCHAR (10)  NOT NULL,
    [peoplesoft_id]      VARCHAR (10)  NOT NULL,
    [supplier_name]      VARCHAR (100) NOT NULL,
    [supplier_bank_acct] CHAR (16)     NOT NULL,
    [supplier_gst_no]    VARCHAR (12)  NULL,
    [supplier_updated]   VARCHAR (12)  NULL
);

