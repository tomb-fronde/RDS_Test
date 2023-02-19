CREATE TABLE [rd].[address_frequency_sequence] (
    [adr_id]           INT         NOT NULL,
    [sf_key]           INT         NOT NULL,
    [rf_delivery_days] VARCHAR (7) NOT NULL,
    [contract_no]      INT         NOT NULL,
    [seq_num]          INT         NOT NULL,
    CONSTRAINT [address_frequency_sequence_cns] PRIMARY KEY CLUSTERED ([adr_id] ASC, [sf_key] ASC, [rf_delivery_days] ASC, [contract_no] ASC, [seq_num] ASC),
    CONSTRAINT [FK_ADDRESS__REF_591_ADDRESS] FOREIGN KEY ([adr_id]) REFERENCES [rd].[address] ([adr_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ADDRESS__REFERENCE_ROUTE_FR] FOREIGN KEY ([contract_no], [sf_key], [rf_delivery_days]) REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days]) ON DELETE CASCADE ON UPDATE CASCADE
);

