CREATE TABLE [odps].[t_piecerate_tracker] (
    [contract_no] INT      NULL,
    [sdate]       DATETIME NULL,
    [edate]       DATETIME NULL
);


GO
CREATE NONCLUSTERED INDEX [tprt_contract]
    ON [odps].[t_piecerate_tracker]([contract_no] ASC);


GO
CREATE NONCLUSTERED INDEX [tprt_3]
    ON [odps].[t_piecerate_tracker]([edate] ASC);


GO
CREATE NONCLUSTERED INDEX [tprt_2]
    ON [odps].[t_piecerate_tracker]([sdate] ASC);

