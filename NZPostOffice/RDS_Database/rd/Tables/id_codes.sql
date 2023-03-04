CREATE TABLE [rd].[id_codes] (
    [sequence_name] VARCHAR (20) NOT NULL,
    [next_value]    INT          NOT NULL,
    CONSTRAINT [id_codes_cns] PRIMARY KEY CLUSTERED ([sequence_name] ASC)
);

