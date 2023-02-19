CREATE TABLE [rd].[artical_count] (
    [contract_no]           INT             NOT NULL,
    [ac_start_week_period]  DATETIME        NOT NULL,
    [contract_seq_number]   INT             NULL,
    [ac_w1_medium_letters]  INT             NULL,
    [ac_w1_other_envelopes] INT             NULL,
    [ac_w1_small_parcels]   INT             NULL,
    [ac_w1_large_parcels]   INT             NULL,
    [ac_w1_inward_mail]     INT             NULL,
    [ac_w2_medium_letters]  INT             NULL,
    [ac_w2_other_envelopes] INT             NULL,
    [ac_w2_small_parcels]   INT             NULL,
    [ac_w2_large_parcels]   INT             NULL,
    [ac_w2_inward_mail]     INT             NULL,
    [ac_scale_factor]       NUMERIC (10, 6) NULL,
    CONSTRAINT [artical_count_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [ac_start_week_period] ASC),
    CONSTRAINT [FK_contract_renewals7] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number]),
    CONSTRAINT [FK_contract7] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no])
);


GO

CREATE TRIGGER [rd].[trig_ModArtCount2001] ON [rd].[artical_count]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
BEGIN
    -- TJB  RD7_0050  Sept2009
    -- Added @inContract and @inSequence
    -- Fixed bug in @nItemProc select
    --
  if update(contract_seq_number)
  begin
    -- TJB  SR4684 bug fix  Aug 2006
    -- Removed large parcels from Total Volume calculation
    declare @nVolume int,
            @nCount int,
            @nItemProc int,
            @nItemHours real

    -- TJB  RD7_0050  Sept2009: added
    -- Use variables instead of re-issuing 'select' statements
    declare @inContract int
    declare @inSequence int

    select @inContract = contract_no from inserted
    select @inSequence = contract_seq_number from inserted

    --new 2001    
    -- TJB  RD7_0050  Sept2009: changed
    -- Made join on non_vehicle_override_rate the nvor alias
    -- Wasn't finding the override rate
    select @nItemProc = isNull(nvor.nvor_item_proc_rate_per_hour,nvr.nvr_item_proc_rate_per_hr) 
      from contract_renewals as cr left outer join  non_vehicle_override_rate as nvor    -- was nvo
                   on cr.contract_no = nvor.contract_no and 
                      cr.contract_seq_number = nvor.contract_seq_number,
           --non_vehicle_override_rate as nvor,                                          -- commented out: duplicate
           contract_vehical as cv,
           contract as c,
           non_vehicle_rate as nvr
     where
           cv.contract_no = cr.contract_no and
           cv.contract_seq_number = cr.contract_seq_number and
           c.contract_no = cr.contract_no and
           c.rg_code = nvr.rg_code and
           cr.contract_no = @inContract and              -- (select contract_no from inserted) and
           cr.contract_seq_number = @inSequence and      -- (select contract_seq_number from inserted) and
           nvr.nvr_rates_effective_date = cr.con_rates_effective_date and
           cv_vehical_status = 'A'

    -- TJB  SR4684 bug fix  Aug 2006
    -- Removed large parcels from Total Volume calculation
    --  select count(*) as numrows,
    --         sum((ifnull(ac_w1_other_envelopes,0,ac_w1_other_envelopes)
    --              + ifnull(ac_w1_medium_letters,0,ac_w1_medium_letters)
    --              + ifnull(ac_w1_small_parcels,0,ac_w1_small_parcels)
    --              + ifnull(ac_w1_large_parcels,0,ac_w1_large_parcels)
    --              + ifnull(ac_w2_other_envelopes,0,ac_w2_other_envelopes)
    --              + ifnull(ac_w2_medium_letters,0,ac_w2_medium_letters)
    --              + ifnull(ac_w2_small_parcels,0,ac_w2_small_parcels)
    --              + ifnull(ac_w2_large_parcels,0,ac_w2_large_parcels)
    --              ) * ac_scale_factor)/numrows 
    select @nCount = count(*),
           @nVolume = sum((isnull(ac_w1_other_envelopes,0)
                           + isnull(ac_w1_medium_letters,0)
                           + isnull(ac_w1_small_parcels,0)
                           + isnull(ac_w2_other_envelopes,0)
                           + isnull(ac_w2_medium_letters,0)
                           + isnull(ac_w2_small_parcels,0)
                          )*ac_scale_factor)/count(*) 
      from artical_count 
     where contract_no = @inContract and              -- (select contract_no from inserted) and
           contract_seq_number = @inSequence          -- (select contract_seq_number from inserted)

    select @nItemHours=(@nVolume/@nItemProc)/52.1429

    update contract_renewals 
       set con_volume_at_renewal = @nVolume,
           con_processing_hours_per_week = @nItemHours 
     where contract_no = @inContract and              -- (select contract_no from inserted) and
           contract_seq_number = @inSequence          -- (select contract_seq_number from inserted)
  end
END