
--
-- Definition for stored procedure cust_survey : 
--

create procedure [rd].[cust_survey]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select surname_or_company=cust_surname_company,
    first_name=cust_initials,
    title=cust_title,
    street_or_road_number=cust_mailing_address_no,
    road_name=cust_mailing_address_road,
    area_locality=cust_mailing_address_locality,RD_number='RD ' + 
    cust_rd_number,
    town_or_city=cust_mail_town,
    contact_phone_day=cust_phone_day,
    contact_phone_night=cust_phone_night,
    cust_id,
    contractor=(select c_survey_name from
      contractor,contractor_renewals,contract as c where
      contractor.contractor_supplier_no = 
      contractor_renewals.contractor_supplier_no and
      contractor_renewals.contract_no = customer.contract_no and
      contractor_renewals.contract_no = c.contract_no and
      contractor_renewals.contract_seq_number = c.con_active_sequence and
      contractor_renewals.cr_effective_date = 
      (select max(cr2.cr_effective_date) from
        contractor_renewals as cr2 where
        cr2.contract_no = contractor_renewals.contract_no and
        cr2.contract_seq_number = contractor_renewals.contract_seq_number)) from
    customer where
    contract_no > 0
end