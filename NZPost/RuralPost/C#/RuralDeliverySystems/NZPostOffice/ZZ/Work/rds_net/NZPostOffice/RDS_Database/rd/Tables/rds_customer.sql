CREATE TABLE [rd].[rds_customer] (
    [cust_id]                INT          NOT NULL,
    [cust_title]             VARCHAR (10) NULL,
    [cust_surname_company]   VARCHAR (45) NULL,
    [cust_initials]          VARCHAR (30) NULL,
    [cust_phone_day]         VARCHAR (14) NULL,
    [cust_phone_night]       VARCHAR (14) NULL,
    [cust_dir_listing_ind]   VARCHAR (1)  NULL,
    [cust_dir_listing_text]  VARCHAR (60) NULL,
    [cust_business]          VARCHAR (1)  NULL,
    [cust_rural_resident]    VARCHAR (1)  NULL,
    [cust_rural_farmer]      VARCHAR (1)  NULL,
    [printedon]              DATETIME     NULL,
    [cust_date_commenced]    DATETIME     NULL,
    [cust_phone_mobile]      VARCHAR (14) NULL,
    [master_cust_id]         INT          NULL,
    [cust_care_of]           VARCHAR (75) NULL,
    [cust_adpost_quantity]   INT          NULL,
    [cust_last_amended_date] DATETIME     NULL,
    [cust_last_amended_user] VARCHAR (20) NULL,
    [cust_case_name]         VARCHAR (25) NULL,
    [cust_slot_allocation]   INT          DEFAULT ((2)) NULL,
    [cust_stripmaker_seq]    CHAR (1)     NULL,
    [cust_vr_number]         VARCHAR (10) NULL,
    CONSTRAINT [rds_customer_cns] PRIMARY KEY CLUSTERED ([cust_id] ASC),
    CONSTRAINT [FK_RDS_CUST_REFERENCE_RDS_CUST] FOREIGN KEY ([master_cust_id]) REFERENCES [rd].[rds_customer] ([cust_id])
);


GO
CREATE NONCLUSTERED INDEX [idx_master_cust_id]
    ON [rd].[rds_customer]([master_cust_id] ASC);

