CREATE TABLE [rd].[RCMStatPR1] (
    [AdpostCost] NUMERIC (12, 2) NULL,
    [AdPostVol]  INT             NULL,
    [Region_id]  INT             NULL
);


GO
CREATE NONCLUSTERED INDEX [pr1_reg]
    ON [rd].[RCMStatPR1]([Region_id] ASC);

