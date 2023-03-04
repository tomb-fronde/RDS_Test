CREATE TABLE [rd].[driver_hs_info] (
    [driver_no]           INT           NOT NULL,
    [hst_id]              INT           NOT NULL,
    [hsi_date_checked]    DATETIME      NOT NULL,
    [hsi_additional_date] DATETIME      NULL,
    [hsi_passfail_ind]    CHAR (1)      NULL,
    [hsi_notes]           VARCHAR (200) NULL,
    CONSTRAINT [PK_driver_hs_info] PRIMARY KEY CLUSTERED ([driver_no] ASC, [hst_id] ASC, [hsi_date_checked] ASC)
);

