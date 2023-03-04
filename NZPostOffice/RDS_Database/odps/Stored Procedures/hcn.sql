
--
-- Definition for stored procedure hcn : 
--

create procedure [odps].[hcn](@sdate datetime,@edate datetime)
as
select Item='nat_ac_id_gst_gl',
  PreviousPeriod=case when rd.OD_BLF_GetValue(@sdate,@edate-1,'nat_ac_id_gst_gl') = nat_ac_id_gst_gl then
    nat_ac_id_gst_gl
  else
    rd.OD_BLF_GetValue(@sdate,@edate-1,'nat_ac_id_gst_gl')
  end,
  ThisPeriod=rd.OD_BLF_GetValue(@sdate,@edate,'nat_ac_id_gst_gl') from
  "national" where
  nat_effective_date between @sdate and @edate and
  nat_id = rd.OD_BLF_GetValue(@sdate,@edate-1,'nat_id')