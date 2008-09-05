/****** Object:  UserDefinedFunction [rd].[ownerwithcellPercent]    Script Date: 08/05/2008 11:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function ownerwithcellPercent : 
--

create function [rd].[ownerwithcellPercent](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns float
AS
BEGIN

  declare @i_cell_num float,
  @i_total float,
  @d_percentage float
  select @i_cell_num = count(cont.contractor_supplier_no) 
    from towncity as tc join address as addr on tc.tc_id = addr.tc_id join contract as con on addr.contract_no = con.contract_no,
contractor_renewals as cr join contractor as cont on cr.contractor_supplier_no = cont.contractor_supplier_no where
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
    con.contract_no = cr.contract_no and
    cr.contract_seq_number = (select max(cr1.contract_seq_number) from contractor_renewals as cr1 where cr1.contract_no = cr.contract_no) and
    cont.c_mobile is not null
  select @i_total = count(cont.contractor_supplier_no) 
    from towncity as tc join address as addr on tc.tc_id = addr.tc_id join contract as con on addr.contract_no = con.contract_no,
contractor_renewals as cr join contractor as cont on cr.contractor_supplier_no = cont.contractor_supplier_no where
    con.contract_no = cr.contract_no and
    cr.contract_seq_number = (select max(cr1.contract_seq_number) from contractor_renewals as cr1 where cr1.contract_no = cr.contract_no) and
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup)
  if @i_total <> 0
    begin
      select @d_percentage=(@i_cell_num/@i_total)*100
      select @d_percentage=round(@d_percentage,2)
    end
  else
    select @d_percentage=0
  return round(@d_percentage,2)
end
GO
