CREATE TABLE [odps].[t_rps_gl_interface] (
    [entity_id_1]            VARCHAR (5)     NULL,
    [journal_id_2]           VARCHAR (20)    NULL,
    [effective_date_3]       DATETIME        NULL,
    [journal_sequence_4]     INT             NULL,
    [line_entity_id_6]       VARCHAR (5)     NULL,
    [rc_number_7]            VARCHAR (10)    NULL,
    [account_number_8]       VARCHAR (100)   NULL,
    [product_code_9]         VARCHAR (1)     NULL,
    [analysis_code_10]       VARCHAR (1)     NULL,
    [primary_dr_cr_code_11]  VARCHAR (1)     NULL,
    [transaction_amount_12]  NUMERIC (30, 6) NULL,
    [misc_cr_dr_code_13]     VARCHAR (1)     NULL,
    [misc_amount_14]         SMALLINT        NULL,
    [jrnl_user_alpha_fld_15] VARCHAR (10)    NULL,
    [date_created_16]        DATETIME        NULL,
    [description_17]         VARCHAR (100)   NULL
);

