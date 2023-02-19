CREATE TABLE [rd].[artical_count_31jan2002] (
    [contract_no]           INT             NOT NULL,
    [ac_start_week_period]  DATETIME        NOT NULL,
    [contract_seq_number]   INT             NULL,
    [ac_w1_medium_letters]  INT             NULL,
    [ac_w1_other_envelopes] INT             NULL,
    [ac_w1_small_parcels]   INT             NULL,
    [ac_w1_large_parcels]   INT             NULL,
    [ac_w1_inward_mail]     INT             NULL,
    [ac_w2_medium_letters]  INT             NULL,
    [ac_w2_other_envelopes] INT             NULL,
    [ac_w2_small_parcels]   INT             NULL,
    [ac_w2_large_parcels]   INT             NULL,
    [ac_w2_inward_mail]     INT             NULL,
    [ac_scale_factor]       NUMERIC (12, 6) NULL
);

