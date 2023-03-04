CREATE TABLE [rd].[artical_count_daily] (
    [contract_no]          INT      NOT NULL,
    [ac_start_week_period] DATETIME NOT NULL,
    [contract_seq_number]  INT      NULL,
    [acd_week_no]          INT      NOT NULL,
    [act_key]              INT      NOT NULL,
    [acd_mon_count]        INT      NULL,
    [acd_tue_count]        INT      NULL,
    [acd_wed_count]        INT      NULL,
    [acd_thu_count]        INT      NULL,
    [acd_fri_count]        INT      NULL,
    [acd_sat_count]        INT      NULL,
    CONSTRAINT [PK_artical_count_daily] PRIMARY KEY CLUSTERED ([contract_no] ASC, [ac_start_week_period] ASC, [acd_week_no] ASC, [act_key] ASC),
    CONSTRAINT [FK_contract_renewals8] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number]),
    CONSTRAINT [FK_contract8] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no])
);

