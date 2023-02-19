CREATE TABLE [rd].[RCMStatPR2] (
    [CourpostCost] NUMERIC (12, 2) NULL,
    [CourpostVol]  INT             NULL,
    [region_id]    INT             NULL
);


GO
CREATE NONCLUSTERED INDEX [pr2_reg]
    ON [rd].[RCMStatPR2]([region_id] ASC);

