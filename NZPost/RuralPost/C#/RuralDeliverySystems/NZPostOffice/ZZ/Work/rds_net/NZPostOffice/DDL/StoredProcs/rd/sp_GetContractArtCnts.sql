/****** Object:  StoredProcedure [rd].[sp_GetContractArtCnts]    Script Date: 08/05/2008 10:19:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetContractArtCnts : 
--

--
-- Definition for stored procedure sp_GetContractArtCnts : 
--

create procedure [rd].[sp_GetContractArtCnts](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @maxcust integer
  /*  select max(customer.cust_rd_number) into maxcust
  from customer where
  customer.contract_no = in_Contract; */
  select artical_count.contract_no,
    artical_count.contract_seq_number,
    artical_count.ac_start_week_period,
    artical_count.ac_w1_medium_letters,
    artical_count.ac_w1_other_envelopes,
    artical_count.ac_w1_small_parcels,
    artical_count.ac_w1_large_parcels,
    artical_count.ac_w1_inward_mail,
    artical_count.ac_w2_medium_letters,
    artical_count.ac_w2_other_envelopes,
    artical_count.ac_w2_small_parcels,
    artical_count.ac_w2_large_parcels,
    artical_count.ac_w2_inward_mail,
    artical_count.ac_scale_factor,
    @maxcust from
    artical_count where
    artical_count.contract_no = @in_Contract order by
    artical_count.ac_start_week_period desc
end
GO
