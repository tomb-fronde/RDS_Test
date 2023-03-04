
--
-- Definition for stored procedure ps_count_articles : 
--

create procedure [rd].[ps_count_articles](@inRegion int,@inYearStart datetime,@inMonthEnd datetime,@outLetters int output,@outSmallParcels int output,@outLargeParcels int output,@outExtnLetters int output,@outExtnSmallParcels int output,@outExtnLargeParcels int output) 
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4684  June 2006
  -- Reformatted for legibility
  declare @iTotLetters decimal(12),
  @iTotSmallPar decimal(12),
  @iTotLargePar decimal(12),
  @iVolume decimal(12),
  @iExtnVolume decimal(12),
  @fLetters real,
  @fSmallPar real,
  @fLargePar real,
  @dMonthStart datetime,
  @dEndLastFinYear datetime,
  @decMonths decimal(10,5),
  @iExtnLetters decimal(12),
  @iExtnSmallParcels decimal(12),
  @iExtnLargeParcels decimal(12)
  /* Watcom only
  err_notfound exception for sqlstate value '02000'
  */
  select @iTotLetters=sum((isnull(ac_w1_medium_letters,0)+
    isnull(ac_w1_other_envelopes,0)+
    isnull(ac_w2_medium_letters,0)+
    isnull(ac_w2_other_envelopes,0))*
    ac_scale_factor),
    @iTotSmallPar=sum((isnull(ac_w1_small_parcels,0)+
    isnull(ac_w2_small_parcels,0))*
    ac_scale_factor),
    @iTotLargePar=sum((isnull(ac_w1_large_parcels,0)+
    isnull(ac_w2_large_parcels,0))*
    ac_scale_factor)
     from artical_count join contract on
    artical_count.contract_no = contract.contract_no and
    artical_count.contract_seq_number = contract.con_active_sequence and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) where
    artical_count.contract_seq_number is not null
  select @iVolume=isnull(@iTotLetters,0)+
    isnull(@iTotSmallPar,0)+
    isnull(@iTotLargePar,0)
  select @fLetters=@iTotLetters/@iVolume
  select @fSmallPar=@iTotSmallPar/@iVolume
  select @fLargePar=@iTotLargePar/@iVolume
  select @iVolume = sum(contract_renewals.con_volume_at_renewal) 
    from contract_renewals join contract on
    contract_renewals.contract_no = contract.contract_no and
    contract_renewals.contract_seq_number = contract.con_active_sequence and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0)
  select @iExtnVolume = sum(fd_volume) 
    from frequency_distances join contract on
    frequency_distances.contract_no = contract.contract_no and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) where
    fd_effective_date between @inYearStart and @inMonthEnd
  select @dEndLastFinYear=rd.ymd(year(@inYearStart),3,1)
  select @decMonths=datediff(month,@dEndLastFinYear,@inMonthEnd)
  select @decMonths=@decMonths/12
  select @iVolume=((isnull(@iVolume,0)+isnull(@iExtnVolume,0)))*@decMonths
  select @outLetters=@iVolume*@fLetters
  select @outSmallParcels=@iVolume*@fSmallPar
  select @outLargeParcels=@iVolume*@fLargePar
  select @dMonthStart=rd.ymd(year(@inMonthEnd),month(@inMonthEnd),1)
  select @iVolume = sum(fd_volume)
    from frequency_distances join contract on
    frequency_distances.contract_no = contract.contract_no and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) where
    fd_effective_date between @dMonthStart and @inMonthEnd
  select @outExtnLetters=@iVolume*@fLetters
  select @outExtnSmallParcels=@iVolume*@fSmallPar
  select @outExtnLargeParcels=@iVolume*@fLargePar
end