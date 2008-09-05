if exists ( select 1 from sysobjects 
             where name = 'v_cust_interests_occupations' and type = 'V')
begin
    print 'Drop view v_cust_interests_occupations'
    drop view v_cust_interests_occupations
end
go

print 'create view v_cust_interests_occupations'
go

create view v_cust_interests_occupations
as 
    select c.cust_id
         , ci.interest_id as code
         , 'I'            as type
      from rds_customer c
         , address a
         , customer_address_moves cam
         , customer_interest   ci
     where c.master_cust_id is null
       and c.cust_surname_company != 'Dummy'
       and cam.cust_id = c.cust_id
       and cam.move_out_date is null
       and a.adr_id = cam.adr_id
       and a.contract_no < 6000      -- Rural Delivery contracts only
       and a.dp_id is not null
       and ci.cust_id = c.cust_id
  union all
    select c.cust_id
         , co.occupation_id as id
         , 'O'              as type
      from rds_customer c
         , address a
         , customer_address_moves cam
         , customer_occupation co
     where c.master_cust_id is null
       and c.cust_surname_company != 'Dummy'
       and cam.cust_id = c.cust_id
       and cam.move_out_date is null
       and a.adr_id = cam.adr_id
       and a.contract_no < 6000      -- Rural Delivery contracts only
       and a.dp_id is not null
       and co.cust_id = c.cust_id
go

if exists ( select 1 from sysobjects 
             where name = 'v_cust_interests_occupations' and type = 'V')
    print 'View v_cust_interests_occupations created'
go
