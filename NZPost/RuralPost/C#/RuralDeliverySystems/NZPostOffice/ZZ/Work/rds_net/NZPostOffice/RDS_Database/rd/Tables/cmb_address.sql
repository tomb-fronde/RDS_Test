CREATE TABLE [rd].[cmb_address] (
    [cmb_id]                INT          NOT NULL,
    [contract_no]           INT          NULL,
    [cmb_box_no]            VARCHAR (5)  NULL,
    [tc_id]                 INT          NULL,
    [post_code_id]          INT          NULL,
    [adr_rd_no]             VARCHAR (40) NULL,
    [cmb_cust_surname]      VARCHAR (45) NULL,
    [cmb_cust_initials]     VARCHAR (30) NULL,
    [cmb_date_added]        DATETIME     NULL,
    [cmb_last_amended_date] DATETIME     NULL,
    [cmb_last_amended_user] VARCHAR (20) NULL,
    CONSTRAINT [cmb_address_cns] PRIMARY KEY CLUSTERED ([cmb_id] ASC),
    CONSTRAINT [FK_cmb_address_contract] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_CMB_ADDRESS_TOWNCITY] FOREIGN KEY ([tc_id]) REFERENCES [rd].[TownCity] ([tc_id]),
    CONSTRAINT [FK_CNB_ADDRESS_POST_CODE] FOREIGN KEY ([post_code_id]) REFERENCES [rd].[post_code] ([post_code_id]),
    CONSTRAINT [cmb_address UNIQUE (cmb_id)] UNIQUE NONCLUSTERED ([cmb_id] ASC)
);

