
--
-- Definition for user-defined function f_estParcelPostValue : 
--

--
-- Definition for user-defined function f_estParcelPostValue : 
--

create function [rd].[f_estParcelPostValue](@inContract int,@inSequence int,@inRGcode int,@inYearStart datetime,@inMonthEnd datetime,@inRenewalEnd datetime,@inRenewalStart datetime)
returns decimal(12,2)
-- TJB  SR4684  June 2006    -- New --
-- Calculate an estimated Parcel Post value for a current contract
-- using the PP1 rate and the Large Parcel volume.
-- TJB  SR4684 Fixup July 2006
-- Changed parameter list (inRGcode, inRenewalEnd) and value selection
-- TJB  SR4684 Fixup August 2006
as -- Changed 'PP1"" to 'PP4''
begin

  declare @iTotLargeParValue decimal(12,2),
  @iPRKey integer
  select @iPRKey = prt_key 
    from piece_rate_type where
    prt_code = 'PP4'
  select @iTotLargeParValue=sum(((isnull(ac_w1_large_parcels,0)+
    isnull(ac_w2_large_parcels,0))*
    isnull(ac_scale_factor,0))*
    pr.pr_rate)
    from artical_count as ac,
    piece_rate as pr where
    ac.contract_no = @inContract and
    ac.contract_seq_number = @inSequence and
    ac_start_week_period between @inYearStart
    and @inMonthEnd and
    pr.prt_key = @iPRKey and
    pr.rg_code = @inRGcode and
    pr.pr_active_status = 'Y' and
    pr_effective_date = 
    (select max(pr_effective_date) from piece_rate where
      prt_key = @iPRKey and
      rg_code = @inRGcode and
      pr_active_status = 'Y' and
      ((@inRenewalEnd is not null and pr_effective_date <= @inRenewalEnd) or
      (@inRenewalEnd is null and pr_effective_date >= @inRenewalStart)))
  return @iTotLargeParValue
end