CREATE TABLE [rd].[userids] (
    [u_code]                NUMERIC (10)  NOT NULL,
    [u_userid]              VARCHAR (20)  NOT NULL,
    [u_password]            VARCHAR (20)  NOT NULL,
    [u_cargo]               VARCHAR (255) NULL,
    [u_last_login_date]     DATETIME      NULL,
    [u_last_login_time]     DATETIME      NULL,
    [u_created_date]        DATETIME      NULL,
    [u_created_by]          VARCHAR (20)  NULL,
    [u_modified_date]       DATETIME      NULL,
    [u_modified_by]         VARCHAR (20)  NULL,
    [gp_code]               NUMERIC (10)  NULL,
    [u_name]                VARCHAR (40)  NULL,
    [u_location]            VARCHAR (255) NULL,
    [u_phone]               VARCHAR (15)  NULL,
    [u_mobile]              VARCHAR (15)  NULL,
    [u_can_change_password] VARCHAR (1)   NULL,
    [region_id]             INT           NULL,
    [u_password_expiry]     DATETIME      NULL,
    [u_grace_logins]        SMALLINT      NULL,
    [u_locked_date]         DATETIME      NULL,
    CONSTRAINT [userids_cns] PRIMARY KEY CLUSTERED ([u_code] ASC),
    CONSTRAINT [fk_region] FOREIGN KEY ([region_id]) REFERENCES [rd].[region] ([region_id]) ON DELETE SET NULL,
    CONSTRAINT [FK_user_groups] FOREIGN KEY ([gp_code]) REFERENCES [rd].[user_groups] ([gp_code])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [u_userid]
    ON [rd].[userids]([u_userid] ASC);


GO
CREATE NONCLUSTERED INDEX [u_upass]
    ON [rd].[userids]([u_password] ASC);


GO
CREATE NONCLUSTERED INDEX [u_ugpcode]
    ON [rd].[userids]([gp_code] ASC);


GO


CREATE TRIGGER [rd].[trig_Userid1] ON [rd].[userids]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
if update(u_last_login_date) begin
  begin
    declare @nCount int
    select @nCount = count(*) 
      from userids where
      u_last_login_date = rd.today()
    if @nCount < 1 or @nCount is null
      update contract set
        con_active_sequence = (select max(contract_renewals.contract_seq_number) from contract_renewals where(contract_renewals.contract_no = contract.contract_no)) where
        contract_no = any(select contract.contract_no from
          contract join
          contract_renewals on
          contract.contract_no = contract_renewals.contract_no and
          (contract.con_active_sequence < contract_renewals.contract_seq_number or
          contract.con_active_sequence is null) and
          contract_renewals.con_acceptance_flag = 'Y' and
          contract_renewals.con_start_date <= rd.today())
  end
end