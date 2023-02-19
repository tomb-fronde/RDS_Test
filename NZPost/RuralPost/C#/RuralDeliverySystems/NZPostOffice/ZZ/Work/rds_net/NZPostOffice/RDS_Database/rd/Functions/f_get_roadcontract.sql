
CREATE FUNCTION [rd].[f_get_roadcontract]( @in_road_id int, @in_post_code varchar(4))
returns int
-- TJB  RPCR_105  May-2016
-- Function to return the contract number of the road (@in_road_id) 
-- in the post code (@in_post_code) which has the most addresses 
-- associated with it.
AS
BEGIN
  declare @i int, @j int
  declare @contract_no int
  declare @post_code varchar(4)
  declare @s_contract varchar(10)

  select @i = count(*) from rd.post_code
   where post_code = @in_post_code

  if ( @i > 1 )
  begin
    set @contract_no = (select top(1) adr.contract_no
      from rd.[address] adr, rd.post_code pc
     where road_id = @in_road_id
       and adr.post_code_id = pc.post_code_id
       and pc.post_code = @in_post_code
     group by adr.contract_no
     order by count(adr.contract_no) desc)
  end
  else
  begin
    select @contract_no = contract_no
	  from rd.post_code
	 where post_code = @in_post_code
  end

  return @contract_no

END