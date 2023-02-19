CREATE TABLE [rd].[strip_height] (
    [sh_id]      INT IDENTITY (1, 1) NOT NULL,
    [sh_height]  INT NOT NULL,
    [sh_default] INT NULL,
    CONSTRAINT [strip_height_cns] PRIMARY KEY CLUSTERED ([sh_id] ASC)
);

