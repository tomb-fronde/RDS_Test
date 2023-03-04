CREATE TABLE [rd].[contract] (
    [contract_no]                INT            NOT NULL,
    [rg_code]                    INT            NULL,
    [con_old_mail_service_no]    VARCHAR (6)    NULL,
    [con_title]                  VARCHAR (60)   NULL,
    [con_rd_paper_file_text]     VARCHAR (40)   NULL,
    [con_rcm_paper_file_text]    VARCHAR (40)   NULL,
    [con_base_office]            INT            NULL,
    [con_lodgement_office]       INT            NULL,
    [con_active_sequence]        INT            NULL,
    [con_base_cont_type]         INT            NULL,
    [con_rd_ref_text]            VARCHAR (35)   NULL,
    [con_last_service_review]    DATETIME       NULL,
    [con_last_delivery_check]    DATETIME       NULL,
    [con_last_work_msrmnt_check] DATETIME       NULL,
    [con_lngth_sealed_road]      INT            NULL,
    [con_lngth_unsealed_road]    INT            NULL,
    [con_date_terminated]        DATETIME       NULL,
    [con_date_last_prt_for_od]   DATETIME       NULL,
    [__________]                 VARCHAR (1)    NULL,
    [ac_id]                      INT            NULL,
    [message_for_invoice]        VARCHAR (1000) NULL,
    [PBU_ID]                     INT            NULL,
    [cust_list_printed]          DATETIME       NULL,
    [cust_list_updated]          DATETIME       NULL,
    CONSTRAINT [contract_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC),
    CONSTRAINT [fk_base_office] FOREIGN KEY ([con_base_office]) REFERENCES [rd].[outlet] ([outlet_id]),
    CONSTRAINT [fk_base_office1] FOREIGN KEY ([con_base_office]) REFERENCES [rd].[outlet] ([outlet_id]),
    CONSTRAINT [FK_outlet] FOREIGN KEY ([con_lodgement_office]) REFERENCES [rd].[outlet] ([outlet_id]),
    CONSTRAINT [FK_renewal_group] FOREIGN KEY ([rg_code]) REFERENCES [rd].[renewal_group] ([rg_code])
);


GO




CREATE TRIGGER [rd].[trig_AddRenewal2001] ON [rd].[contract]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  -- TJB  SR4605  July 2006
  declare @nRGCode int,
  @dDate datetime
  	declare @contract_no_temp int
	select @contract_no_temp = contract_no from inserted
select @nRGCode = rg_code  
    from contract where
    contract_no = @contract_no_temp
  select @dDate = max(nvr_rates_effective_date)  
    from non_vehicle_rate where
    rg_code = @nRGCode
  insert into contract_renewals(contract_no,
    contract_seq_number,con_rg_code_at_renewal,
    con_rates_effective_date,con_acceptance_flag) values(
    @contract_no_temp,1,@nRGCode,@dDate,'N')
end