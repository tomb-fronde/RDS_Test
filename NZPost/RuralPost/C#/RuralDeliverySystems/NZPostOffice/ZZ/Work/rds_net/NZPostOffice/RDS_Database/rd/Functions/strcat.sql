
--
-- Definition for user-defined function Date : 
--

create function [rd].[strcat] (@input1 varchar(4000),@input2 varchar(4000))

RETURNS varchar(8000)
AS
BEGIN

 declare  @return varchar(8000)
  select @return=@input1+@input2
	return @return
END