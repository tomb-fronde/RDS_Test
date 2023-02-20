/****** Object:  StoredProcedure [rd].[sp_Schedule_A]    Script Date: 08/05/2008 10:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_Schedule_A : 
--

create procedure [rd].[sp_Schedule_A](@inContract int,@inSequence int)
-- TJB  Hack  Aug 2006
-- Add the renewal group code to the list of values returned.
-- Wanted for a hack that will determine a contract''s renewal period
-- on the Schedule A report.
--
-- TJB  SR4669  Oct 2005
-- Added email address to returned results.
-- Reformatted and simplified syntax a bit.
--
-- TJB  SR4671  Oct 2005
-- Addded c_primary_contact returned value
--
as -- TJB added Aug 2006
begin
set CONCAT_NULL_YIELDS_NULL off
  select contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_address,
    contractor.c_phone_day,
    contract_renewals.con_relief_driver_name,
    contract_renewals.con_relief_driver_address,
    contract_renewals.con_relief_driver_home_phone,
    contract_renewals.con_start_date,
    outlet_combined=rd.strcat((case when outlet.o_name = 'Non-RD Dummy' then 'n.a.' else outlet.o_name
    end),( case when outlet_type.ot_outlet_type <> 'Other' then ' '+outlet_type.ot_outlet_type else '' end)),
    contract.contract_no,
    contract.con_title,
    lodgement=(select rd.strcat((case when outlet1.o_name = 'Non-RD Dummy' then 'n.a.' else outlet1.o_name end),
	(case when outlet_type1.ot_outlet_type <> 'Other' then ' '+outlet_type1.ot_outlet_type else '' end)) from
      outlet as outlet1,
      outlet_type as outlet_type1 where
      outlet_type1.ot_code = outlet1.ot_code and
      outlet1.outlet_id = contract.con_lodgement_office),
    usah=(select 'User:'+current_user ),
    contract_renewals.contract_seq_number,
    contractor.c_initials,
    contractor.c_title,
    rgn_rcm_manager=region.rgn_rcm_manager+ case when rgn_telephone is null then '' else char(10)+'Telephone: '+rgn_telephone end+
    case when rgn_mobile is null then '' else char(10)+'Mobile: '+rgn_mobile end ,
    contractor.c_phone_night,
    contractor.c_mobile,
    contractor.c_email_address,
    contractor.c_mobile2,
    contractor.c_prime_contact,
    contract.rg_code from
    contract_renewals,
    contractor,
    outlet,
    contract,
    contractor_renewals,
    region,
    outlet_type where
    contract.contract_no = contract_renewals.contract_no and
    outlet_type.ot_code = outlet.ot_code and
    outlet.outlet_id = contract.con_base_office and
    contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
    contract_renewals.contract_no = contractor_renewals.contract_no and
    contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
    contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date and
    region.region_id = outlet.region_id and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence and
    contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date
end
GO
