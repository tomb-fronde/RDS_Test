/****** Object:  UserDefinedFunction [rd].[privacyPercent]    Script Date: 08/05/2008 11:25:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function privacyPercent : 
--

create function [rd].[privacyPercent](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns float
AS
BEGIN

  declare @i_no_num float,
  @i_total float,
  @d_percentage float
  select @i_no_num = count(cust.cust_id) 
    from towncity as tc join 
address as addr on addr.tc_id = tc.tc_id  join customer_address_moves as cam on addr.adr_id = cam.adr_id join rds_customer as cust on cust.cust_id = cam.cust_id 
join contract as con on  addr.contract_no = con.contract_no where
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
    cust.master_cust_id is null and
    cam.move_out_date is null and
    cust.cust_dir_listing_ind = 'N'
  select @i_total = count(cust.cust_id) 
    from towncity as tc join
address as addr on addr.tc_id = tc.tc_id  join customer_address_moves as cam on addr.adr_id = cam.adr_id join rds_customer as cust on cust.cust_id = cam.cust_id 
 join contract as con on  addr.contract_no = con.contract_no where
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
    cust.master_cust_id is null and
    cam.move_out_date is null
  if @i_total <> 0
    begin
      select @d_percentage=(@i_no_num/@i_total)*100
      select @d_percentage=round(@d_percentage,2)
    end
  else
    select @d_percentage=0
  return round(@d_percentage,2)
end
GO
