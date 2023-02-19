

create view v_Move_In
as
---move ins---
select 
(ct.contract_no + 10000) as courier_id, 
ct.contract_no, 
ct.con_title, 
replace(ct.con_rd_ref_text,',',' ') as con_rd_ref_text, 
ltrim(ISNULL(replace(c.c_title,',',' '),'') + ' ' + isnull(replace(c.c_initials,',',' '),'') + ' ' + replace(c.c_surname_company,',',' ')) AS contractor_name,
(replace((o.o_name),',',' ')) + ' ' +(replace('(ot.ot_outlet_type)',',',' ')) as contractor_outlet, 
(replace(c.c_email_address,',',' ')) as 'contractor_email',
(replace(va.delivery_address,',',' ')) as 'customer_delivery_address', 
(replace(va.sl_name,',',' ')) as 'cust_sl_name', 
(replace(va.rd_label,',',' ')) as 'cust_rd_label', 
(replace(va.post_code,',',' ')) as 'cust_post_code',
(replace(cm.move_in_date,',',' ')) as  move_in_date,
(replace(cm.move_out_date,',',' ')) as move_out_date, 
(replace(cm.move_out_source,',',' ')) as move_out_source, 
(replace(cm.move_out_user,',',' ')) as move_out_user, 
(replace(cm.adr_id,',',' ')) as adr_id,
(replace(cu.cust_title,',',' ')) as cust_title, 
(replace(cu.cust_initials,',',' ')) as cust_initials, 
(replace(cu.cust_surname_company,',',' ')) as cust_surname_company, 
(replace(cu.cust_phone_day,',',' ')) as cust_phone_day, 
(replace(cu.cust_phone_mobile,',',' ')) as cust_phone_mobile, 
(replace(cu.cust_dir_listing_text,',',' ')) as cust_dir_listing_text, 
(replace(cu.cust_business,',',' ')) as cust_business, 
(replace(cu.cust_rural_resident,',',' ')) as cust_rural_resident, 
(replace(cu.cust_rural_farmer,',',' ')) as cust_rural_farmer,
(replace(cu.master_cust_id,',',' ')) as master_cust_id, 
(replace(cu.cust_adpost_quantity,',',' ')) as cust_adpost_quantity
from rd.contractor_renewals cr1
join rd.contractor_renewals cr2 on cr1.contract_no = cr2.contract_no
join rd.contractor c on c.contractor_supplier_no = cr2.contractor_supplier_no
join rd.contract ct on cr1.contract_no = ct.contract_no
left outer join rd.contractor_procurement cp on cp.contractor_supplier_no = c.contractor_supplier_no
join rd.outlet o on o.outlet_id = ct.con_base_office
join rd.region r on r.region_id = o.region_id
join rd.outlet_type ot on ot.ot_code = o.ot_code
join odps.pbu_code p on p.PBU_ID = ct.PBU_ID
join rd.v_address va on ct.contract_no = va.contract_no
join rd.customer_address_moves cm on va.adr_id = cm.adr_id 
join rd.rds_customer cu on cm.cust_id = cu.cust_id
where ct.con_date_terminated is null
and ct.contract_no < 6000
and cm.move_in_date >= getdate()-1 
--and cm.move_in_date >= '2018-08-28'
and cust_surname_company <> '.' 
group by cr1.contract_no, cr2.contractor_supplier_no, cr2.cr_effective_date, o.o_name,ot.ot_outlet_type,r.rgn_name,
c.c_surname_company, c.c_initials, c.c_title, c.c_salutation, ct.contract_no, ct.con_title,p.pbu_description,
c.c_address, c.c_phone_day, c.c_phone_night, c.c_mobile, c.c_prime_contact, ct.con_rd_ref_text, c.c_email_address,
va.delivery_address, va.sl_name, va.rd_label, va.post_code, va.adr_date_loaded,
cm.move_in_date, cm.move_out_date, cm.move_out_source, cm.move_out_user, cm.adr_id,
cu.cust_title, cu.cust_initials, cu.cust_surname_company, cu.cust_phone_day, cu.cust_dir_listing_text, cu.cust_business, 
cu.cust_rural_resident, cu.cust_rural_farmer,cu.cust_phone_mobile,
cu.master_cust_id, cu.cust_phone_mobile, cu.cust_adpost_quantity
having max(cr1.cr_effective_date)=cr2.cr_effective_date