CREATE TABLE [rd].[freight_allocations] (
    [contract_no]       INT NOT NULL,
    [fr_active_ind]     INT NULL,
    [pbu_id]            INT NULL,
    [fr_ecl_pct]        INT NULL,
    [fr_reachmedia_pct] INT NULL,
    [fr_psg_pct]        INT NULL,
    CONSTRAINT [freight_allocations_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC),
    CONSTRAINT [FK_fr_contract] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no])
);

