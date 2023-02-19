
CREATE PROCEDURE [rd].[sp_getUnseqAddresses] (
	@al_contract_no int)
AS
BEGIN
	select adr.adr_id, 
	       (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'-' END)  
		     + adr.adr_no as adr_num, 
	       adr.adr_alpha as adr_alpha, 
	       (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'-' END)  
		     + adr.adr_no + isnull(adr.adr_alpha,'') as adr_num_alpha, 
	       road.road_name 
		       + (CASE WHEN road_type.rt_name is null   THEN '' ELSE ' '+road_type.rt_name end)  
		       + (CASE WHEN road_suffix.rs_name is null THEN '' ELSE ' '+road_suffix.rs_name END) 
		    as road_name, 
	       (CASE WHEN rc.cust_surname_company is null 
		     THEN rc.cust_initials 
		     ELSE (CASE WHEN rc.cust_initials is null  OR rc.cust_initials = ''  
				THEN rc.cust_surname_company  
				ELSE rc.cust_surname_company + ', '+rc.cust_initials END)  
		     END)   as customer, 
	       rc.cust_surname_company as cust_surname_company, 
	       rc.cust_initials as cust_initials, 
	       adr.seq_num as seq_num, 
	       sequence = null, 
	       0 as road_name_id, 
	       adr.adr_unit as adr_unit, 
	       convert(int,adr.adr_no) as adr_no, 
	       adr.contract_no as contract_no 
	     , rc.cust_case_name 
	     , rc.cust_slot_allocation 
	     , rc.cust_id 
	     , rc.cust_stripmaker_seq 
	  from address adr  
		       left outer join customer_address_moves cam 
			    on cam.adr_id = adr.adr_id 
			   and cam.move_out_date is null 
		       left outer join rds_customer rc 
			    on rc.cust_id = cam.cust_id 
	      , road LEFT OUTER JOIN road_type 
			  ON road_type.rt_id = road.rt_id 
		     LEFT OUTER JOIN road_suffix 
			  ON road_suffix.rs_id = road.rs_id 
	 where adr.seq_num is null 
	   and adr.road_id = road.road_id 
	   and (cam.cust_id is not null  
		and (rc.cust_surname_company != 'Dummy' OR rc.cust_initials is not null)) 
	   and rc.master_cust_id is null 
	   and adr.contract_no = @al_contract_no 
    UNION 
    select adr.adr_id, 
           (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'-' END)  
                 + adr.adr_no as adr_num, 
           adr.adr_alpha as adr_alpha, 
           (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'-' END)  
                 + adr.adr_no + isnull(adr.adr_alpha,'') as adr_num_alpha, 
           road.road_name 
                   + (CASE WHEN road_type.rt_name is null   THEN '' ELSE ' '+road_type.rt_name end)  
                   + (CASE WHEN road_suffix.rs_name is null THEN '' ELSE ' '+road_suffix.rs_name END) 
                as road_name, 
           null as customer, 
           rc.cust_surname_company as cust_surname_company, 
           rc.cust_initials as cust_initials, 
           adr.seq_num as seq_num, 
           sequence = null, 
           0 as road_name_id, 
           adr.adr_unit as adr_unit, 
           convert(int,adr.adr_no) as adr_no, 
           adr.contract_no as contract_no 
         , rc.cust_case_name 
         , rc.cust_slot_allocation 
         , rc.cust_id 
         , rc.cust_stripmaker_seq 
      from rd.address adr  
                   left outer join rd.customer_address_moves cam 
                        on cam.adr_id = adr.adr_id 
                        and cam.move_out_date is null 
                   left outer join rd.rds_customer rc 
                        on rc.cust_id = cam.cust_id 
         , rd.road LEFT OUTER JOIN rd.road_type 
                        ON road_type.rt_id = road.rt_id 
                   LEFT OUTER JOIN rd.road_suffix 
                        ON road_suffix.rs_id = road.rs_id 
     where adr.seq_num is null 
       and adr.road_id = road.road_id 
       and (cam.cust_id is null or rc.cust_surname_company = 'Dummy') 
       and adr.contract_no = @al_contract_no 
END