CREATE TABLE [rd].[address] (
    [adr_id]                      INT           NOT NULL,
    [tc_id]                       INT           NULL,
    [road_id]                     INT           NULL,
    [sl_id]                       INT           NULL,
    [contract_no]                 INT           NULL,
    [post_code_id]                INT           NULL,
    [adr_rd_no]                   VARCHAR (40)  NULL,
    [adr_no]                      VARCHAR (20)  NULL,
    [dp_id]                       INT           NULL,
    [adr_delivery_days]           VARCHAR (1)   NULL,
    [adr_property_identification] VARCHAR (100) NULL,
    [adr_alpha]                   VARCHAR (20)  NULL,
    [adr_date_loaded]             DATETIME      NULL,
    [adr_last_amended_date]       DATETIME      NULL,
    [adr_last_amended_user]       VARCHAR (20)  NULL,
    [adr_unit]                    VARCHAR (10)  NULL,
    [seq_num]                     INT           NULL,
    [adr_location_ind]            CHAR (1)      NULL,
    CONSTRAINT [address_cns] PRIMARY KEY CLUSTERED ([adr_id] ASC),
    CONSTRAINT [FK_ADDRESS_REF_576_CONTRACT] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_ADDRESS_REF_594_TOWNCITY] FOREIGN KEY ([tc_id]) REFERENCES [rd].[TownCity] ([tc_id]),
    CONSTRAINT [FK_ADDRESS_REF_597_SUBURBLO] FOREIGN KEY ([sl_id]) REFERENCES [rd].[SuburbLocality] ([sl_id]),
    CONSTRAINT [FK_ADDRESS_REF_603_ROAD] FOREIGN KEY ([road_id]) REFERENCES [rd].[Road] ([road_id]),
    CONSTRAINT [FK_ADDRESS_REFERENCE_POST_COD] FOREIGN KEY ([post_code_id]) REFERENCES [rd].[post_code] ([post_code_id])
);


GO
CREATE NONCLUSTERED INDEX [idx_contract_no]
    ON [rd].[address]([contract_no] ASC);


GO




CREATE TRIGGER [rd].[trig_newAddress] ON [rd].[address]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  --set the adr loaded to current time upon insert
  update address set
    adr_date_loaded = getdate() where
    adr_id = (select adr_id from inserted)
end
GO





--
-- Definition for triggers : 
--

CREATE TRIGGER [rd].[t_address_update] ON [rd].[address]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
begin
set CONCAT_NULL_YIELDS_NULL off

  declare @newString char(300),
  @OldString char(300),
  @Old_Mail_Town char(300),
  @New_Mail_Town char(300),
  @cno integer
  select @newString=''
  select @OldString=''
  select @cno = deleted.contract_no from deleted
	declare @old_adr_rd_no varchar(40),@new_adr_rd_no varchar(40)
	select @old_adr_rd_no = adr_rd_no from deleted
	select @new_adr_rd_no = adr_rd_no from inserted
  if @old_adr_rd_no <> @new_adr_rd_no
    begin
      if len(@newString) > 0
        begin
          select @newString=@newString+convert(char,10)
          select @oldString=@oldString+convert(char,10)
        end
      select @newString=@newString+'RD No:'+@new_adr_rd_no
      select @OldString=@OldString+'RD No:'+@old_adr_rd_no
    end
	declare @old_tc_id int,@new_tc_id int
	select @old_tc_id = tc_id from deleted
	select @new_tc_id = tc_id from inserted
  if @old_tc_id <> @new_tc_id
    begin
      if len(@newString) > 0
        begin
          select @newString=@newString+convert(char,10)
          select @oldString=@oldString+convert(char,10)
        end
      select @New_Mail_Town = tc_name from towncity where tc_id = @new_tc_id
      select @Old_Mail_Town = tc_name from towncity where tc_id = @old_tc_id
      select @newString=@newString+'Town/City:'+@New_Mail_Town
      select @OldString=@OldString+'Town/City:'+@Old_Mail_Town
    end
  if len(@newString) > 0 or len(@OldString) > 0
	declare @int_temp int
	select @int_temp = contractor_renewals.contractor_supplier_no from "contract",contract_renewals,contractor_renewals 
			where(contract_renewals.contract_no = @cno) and(contract_renewals.contract_no = "contract".contract_no) and
				("contract".con_active_sequence = contract_renewals.contract_seq_number) and
				(contractor_renewals.contract_no = contract_renewals.contract_no) and
				(contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
				(contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date)
 
    insert into rds_audit(/*a_key,*/
      a_datetime,
      a_userid,
      a_contract,
      a_contractor,
      a_comment,
      a_oldvalue,
      a_newvalue) values(
      /*null,*/
      getdate(),'DB Trigger',@cno,
		@int_temp,
      'Address update audit by trigger',
      @oldString,@newString)
end