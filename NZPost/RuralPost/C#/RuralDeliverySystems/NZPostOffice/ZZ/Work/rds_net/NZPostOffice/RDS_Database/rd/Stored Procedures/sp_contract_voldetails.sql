
--
-- Definition for stored procedure sp_contract_voldetails : 
--

create procedure [rd].[sp_contract_voldetails](
@inContract int,
@inSequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4684  June 2006
  -- Removed Large Parcels from totals calculations
  declare @StartDate datetime

CREATE TABLE #tmp_articals(
    sortorder integer null,
    description char(20) null,
    dispdecs char(1) null,
    displine char(1) null,
    medium_env decimal(10,2) null,
    other_env decimal(10,2) null,
    small_par decimal(10,2) null,
    large_par decimal(10,2) null,
    total_vol decimal(10,2) null,
    )

  select @startdate = max(ac_start_week_period)
    from artical_count where
    contract_no = @inContract
  insert into #tmp_articals
    select sortorder=10,description='Latest Mail Count',dispdecs='N',displine='N',
      medium=round((isNull(ac_w1_medium_letters,0)+
      isNull(ac_w2_medium_letters,0))*
      isNull(ac_scale_factor,0),0),
      other_env=round((isNull(ac_w1_other_envelopes,0)+
      isNull(ac_w2_other_envelopes,0))*
      isNull(ac_scale_factor,0),0),
      small_par=round((isNull(ac_w1_small_parcels,0)+
      isNull(ac_w2_small_parcels,0))*
      isNull(ac_scale_factor,0),0),
      large_par=round((isNull(ac_w1_large_parcels,0)+
      isNull(ac_w2_large_parcels,0))*
      isNull(ac_scale_factor,0),0),
      -- medium + other_env + small_par + large_par           as total_vol
      total_vol=round((isNull(ac_w1_medium_letters,0)+
      isNull(ac_w2_medium_letters,0))*
      isNull(ac_scale_factor,0),0)
		       +round((isNull(ac_w1_other_envelopes,0)+
      isNull(ac_w2_other_envelopes,0))*
      isNull(ac_scale_factor,0),0)
			+round((isNull(ac_w1_small_parcels,0)+
      isNull(ac_w2_small_parcels,0))*
      isNull(ac_scale_factor,0),0) 
from
      artical_count where
      contract_no = @inContract and
      ac_start_week_period = @startdate
  -- union 
  insert into #tmp_articals
    select sortorder=20,description='Previous Mail Count',dispdecs='N',displine='N',
      medium=round((isNull(ac_w1_medium_letters,0)+
      isNull(ac_w2_medium_letters,0))*
      isNull(ac_scale_factor,0),0),
      other_env=round((isNull(ac_w1_other_envelopes,0)+
      isNull(ac_w2_other_envelopes,0))*
      isNull(ac_scale_factor,0),0),
      small_par=round((isNull(ac_w1_small_parcels,0)+
      isNull(ac_w2_small_parcels,0))*
      isNull(ac_scale_factor,0),0),
      large_par=round((isNull(ac_w1_large_parcels,0)+
      isNull(ac_w2_large_parcels,0))*
      isNull(ac_scale_factor,0),0),
      -- medium + other_env + small_par + large_par           as total_vol
      total_vol=round((isNull(ac_w1_medium_letters,0)+
      isNull(ac_w2_medium_letters,0))*
      isNull(ac_scale_factor,0),0)
				+round((isNull(ac_w1_other_envelopes,0)+
      isNull(ac_w2_other_envelopes,0))*
      isNull(ac_scale_factor,0),0)
				+round((isNull(ac_w1_small_parcels,0)+
      isNull(ac_w2_small_parcels,0))*
      isNull(ac_scale_factor,0),0)
 from
      artical_count as ac1 where
      contract_no = @inContract and
      ac_start_week_period = (select max(ac2.ac_start_week_period) from
        artical_count as ac2 where
        ac2.contract_no = ac1.contract_no and
        ac2.ac_start_week_period < @StartDate)
  insert into #tmp_articals
    select 30,'Variance','N','Y',
      isnull((select medium_env from #tmp_articals where sortorder = 10),0)-
      isnull((select medium_env from #tmp_articals where sortorder = 20),0),
      isnull((select other_env from #tmp_articals where sortorder = 10),0)-
      isnull((select other_env from #tmp_articals where sortorder = 20),0),
      isnull((select small_par from #tmp_articals where sortorder = 10),0)-
      isnull((select small_par from #tmp_articals where sortorder = 20),0),
      isnull((select large_par from #tmp_articals where sortorder = 10),0)-
      isnull((select large_par from #tmp_articals where sortorder = 20),0),
      isnull((select total_vol from #tmp_articals where sortorder = 10),0)-
      isnull((select total_vol from #tmp_articals where sortorder = 20),0) 
  insert into #tmp_articals
    select 40,'Variance (%)','Y','N',
      case when isnull((select medium_env from #tmp_articals where sortorder = 20),0) = 0 then
        0
      else isnull((select medium_env from #tmp_articals where sortorder = 30),0)/
        (select medium_env from #tmp_articals where sortorder = 20)*100
      end,
      case when isnull((select other_env from #tmp_articals where sortorder = 20),0) = 0 then
        0
      else isnull((select other_env from #tmp_articals where sortorder = 30),0)/
        (select other_env from #tmp_articals where sortorder = 20)*100
      end,
      case when isnull((select small_par from #tmp_articals where sortorder = 20),0) = 0 then
        0
      else isnull((select small_par from #tmp_articals where sortorder = 30),0)/
        (select small_par from #tmp_articals where sortorder = 20)*100
      end,
      case when isnull((select large_par from #tmp_articals where sortorder = 20),0) = 0 then
        0
      else isnull((select large_par from #tmp_articals where sortorder = 30),0)/
        (select large_par from #tmp_articals where sortorder = 20)*100
      end,
      case when isnull((select total_vol from #tmp_articals where sortorder = 20),0) = 0 then
        0
      else isnull((select total_vol from #tmp_articals where sortorder = 30),0)/
        (select total_vol from #tmp_articals where sortorder = 20)*100
      end 
  select* from #tmp_articals order by
    sortorder asc
end