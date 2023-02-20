/****** Object:  UserDefinedFunction [rd].[get_number_delivery_days]    Script Date: 08/05/2008 11:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function get_number_delivery_days : 
--

--
-- Definition for user-defined function get_number_delivery_days : 
--

create function [rd].[get_number_delivery_days](@pcust_id int)
returns int 
AS
BEGIN

  declare @ccust_delivery_days char(7),
  @temp int
  select @ccust_delivery_days=customer.cust_delivery_days from customer where customer.cust_id = @pcust_id
  select @temp
    =case substring(@ccust_delivery_days,1,1) when 'y' then 1 else 0 end +
    case substring(@ccust_delivery_days,2,1) when  'y' then 1 else 0 end+
    case substring(@ccust_delivery_days,3,1) when  'y' then 1 else 0 end+
    case substring(@ccust_delivery_days,4,1) when 'y' then 1 else 0 end+
    case substring(@ccust_delivery_days,5,1) when 'y' then 1 else 0 end+
    case substring(@ccust_delivery_days,6,1) when 'y' then 1 else 0 end

  return @temp
end
GO
