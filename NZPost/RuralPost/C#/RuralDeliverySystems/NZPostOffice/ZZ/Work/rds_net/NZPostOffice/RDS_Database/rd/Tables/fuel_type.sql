CREATE TABLE [rd].[fuel_type] (
    [ft_key]         INT          IDENTITY (1, 1) NOT NULL,
    [ft_description] VARCHAR (35) NULL,
    CONSTRAINT [fuel_type_cns] PRIMARY KEY CLUSTERED ([ft_key] ASC)
);

