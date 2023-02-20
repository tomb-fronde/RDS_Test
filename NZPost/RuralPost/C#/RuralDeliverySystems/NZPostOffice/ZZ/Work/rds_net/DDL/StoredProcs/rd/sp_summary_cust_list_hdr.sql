/****** Object:  StoredProcedure [rd].[sp_summary_cust_list_hdr]    Script Date: 08/05/2008 10:22:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_summary_cust_list_hdr : 
--

create procedure [rd].[sp_summary_cust_list_hdr](@in_contract_no int,@in_sf_key int,@in_rd_del_days char(7),@in_sortorder char(1))
-- TJB  SR4664  July 2005  - new
-- Replaces the select in r_summary_customer_listing datawindow
-- Dropped use of v_customers view (huge performance improvement)
-- and added union to append unsequenced customers.
-- This is one of three: this one generates the heading details
-- The others are:
--          sp_summary_cust_list_seq
--          sp_summary_cust_list_unseq
-----------------------------------------------------------------
-- TJB Release 6.8.9 fixup  Nov 2005
-- Added sort order parameter; there is only ever one result set 
-- returned, so they/it doesn''t need to be sorted.  The parameter
as -- is for consistency with the others.
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @l_contract_seq_number integer,
  @l_effective_date datetime,
  @l_c_title char(12),
  @l_c_surname_company char(40),
  @l_c_first_names char(40),
  @l_c_initials char(40)
  select @l_contract_seq_number=max(contract_seq_number)  
    from contract_renewals where
    contract_no = @in_contract_no
  select @l_effective_date=max(cr_effective_date)  
    from contractor_renewals where
    contract_no = @in_contract_no
  select @l_c_title=contractor.c_title,
    @l_c_surname_company=contractor.c_surname_company,
    @l_c_first_names=contractor.c_first_names,
    @l_c_initials=contractor.c_initials
     from contractor,
    contractor_renewals where
    contractor_renewals.contract_no = @in_contract_no and
    contractor_renewals.contract_seq_number = @l_contract_seq_number and
    contractor_renewals.cr_effective_date = @l_effective_date and
    contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no
  select @in_contract_no,
    @l_contract_seq_number,
    contract.con_title,
    contract.con_rd_ref_text,
    @l_c_title,
    @l_c_surname_company,
    @l_c_first_names,
    @l_c_initials,
    outlet.o_name,
    region.rgn_name,
    @in_sf_key,
    @in_rd_del_days,
    standard_frequency.sf_description from
    contract,
    outlet,
    region,
    standard_frequency,
    route_frequency where
    route_frequency.contract_no = @in_contract_no and
    route_frequency.sf_key = @in_sf_key and
    route_frequency.rf_delivery_days = @in_rd_del_days and
    outlet.outlet_id = contract.con_lodgement_office and
    region.region_id = outlet.region_id and
    standard_frequency.sf_key = @in_sf_key and
    contract.contract_no = @in_contract_no
end
GO
