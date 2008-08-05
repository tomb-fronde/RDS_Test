/****** Object:  StoredProcedure [rd].[sp_out_val_list]    Script Date: 08/05/2008 10:21:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_out_val_list : 
--

create procedure [rd].[sp_out_val_list]
-- TWC - 05/09/2003 
-- This is a new procedure to populate the "Outstanding Validation Lists" report
-- For now this takes no arguments and returns all contracts 
-- TJB  SR4657  June05
-- Added conditions:  newest renewal date, contract not terminated
as -- Fixed selection updated < printed
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @current_date datetime
  declare @period integer
  select @current_date=getdate()
  select @period=30
  select reg.rgn_name,
    con.contract_no,
    isnull(ct.c_first_names,'')+' '+ct.c_surname_company,
    ct.c_phone_day,
    ct.c_phone_night,
    ct.c_mobile,
    con.cust_list_printed,
    con.cust_list_updated from
    region as reg join outlet as "out" on reg.region_id=out.region_id join contract as con on
    ("out".outlet_id = con.con_base_office),
    contractor_renewals as cr join contractor as ct on cr.contractor_supplier_no=ct.contractor_supplier_no where
    cr.contract_no = con.contract_no and
    cr.contract_seq_number = con.con_active_sequence and
    cr.cr_effective_date = (select max(cr_effective_date) from contractor_renewals as cr2 where
      cr2.contract_no = cr.contract_no and
      cr2.contract_seq_number = cr.contract_seq_number and
      cr_effective_date <= getdate()) and
    con.con_date_terminated is null and
    con.cust_list_printed is not null and
    con.cust_list_printed < dateadd(day,-30,@current_date) and
    (con.cust_list_updated is null or
    con.cust_list_updated < con.cust_list_printed)
end
GO
