CREATE TABLE [rd].[allowance_calc_type] (
    [alct_id]          INT          IDENTITY (1, 1) NOT NULL,
    [alct_description] VARCHAR (35) NULL,
    CONSTRAINT [allowance_calc_type_cns] PRIMARY KEY CLUSTERED ([alct_id] ASC)
);

