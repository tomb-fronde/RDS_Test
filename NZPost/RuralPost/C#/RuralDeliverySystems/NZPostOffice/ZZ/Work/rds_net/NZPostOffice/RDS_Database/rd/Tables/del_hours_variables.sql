CREATE TABLE [rd].[del_hours_variables] (
    [dhv_travelling_speed] SMALLINT NOT NULL,
    [dhr_seconds_customer] SMALLINT NOT NULL,
    CONSTRAINT [del_hours_variables_cns] PRIMARY KEY CLUSTERED ([dhv_travelling_speed] ASC, [dhr_seconds_customer] ASC)
);

