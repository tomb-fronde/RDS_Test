CREATE TABLE [rd].[rds_user_id] (
    [ui_id]                  INT           NOT NULL,
    [u_id]                   INT           NULL,
    [ui_userid]              VARCHAR (20)  NULL,
    [ui_password]            VARCHAR (20)  NULL,
    [ui_last_login_date]     DATETIME      NULL,
    [ui_last_login_time]     DATETIME      NULL,
    [ui_created_date]        DATETIME      NULL,
    [ui_created_by]          VARCHAR (20)  NULL,
    [ui_modified_date]       DATETIME      NULL,
    [ui_modified_by]         VARCHAR (20)  NULL,
    [ui_location]            VARCHAR (255) NULL,
    [ui_password_expiry]     DATETIME      NULL,
    [ui_grace_logins]        SMALLINT      NULL,
    [ui_locked_date]         DATETIME      NULL,
    [ui_can_change_password] VARCHAR (1)   NULL,
    CONSTRAINT [rds_user_id_cns] PRIMARY KEY CLUSTERED ([ui_id] ASC),
    CONSTRAINT [FK_RDS_USER_REFERENCE_RDS_USER] FOREIGN KEY ([u_id]) REFERENCES [rd].[rds_user] ([u_id]) ON DELETE CASCADE
);


GO




CREATE TRIGGER [rd].[trig_Userid2] ON [rd].[rds_user_id]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
if update(ui_last_login_date) begin
  begin
    declare @nCount int
    select @nCount = count(*) 
      from rds_user_id where
      ui_last_login_date = rd.today()
    if @nCount < 1 or @nCount is null
      update contract set
        con_active_sequence = (select max(contract_renewals.contract_seq_number)
        from contract_renewals where(contract_renewals.contract_no = contract.contract_no)) where
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