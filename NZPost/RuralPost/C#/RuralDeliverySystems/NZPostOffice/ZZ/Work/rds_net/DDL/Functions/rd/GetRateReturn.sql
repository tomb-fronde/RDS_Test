/****** Object:  UserDefinedFunction [rd].[GetRateReturn]    Script Date: 08/05/2008 11:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function GetRateReturn : 
--

create function [rd].[GetRateReturn](@inNomVehicle decimal(10,2),@inRateReturn decimal(10,2),@inSalvage decimal(10,2))
returns real
AS
BEGIN

  declare @Year1To4 real,
  @Year5 real,
  @RateRetPCT decimal(10,4),
  @SalvagePCT decimal(10,4),
  @NPVAmount real,
  @Payments real
  if not(@inRateReturn is null or @inRateReturn = 0)
    begin
      select @RateRetPCT=@inRateReturn/100
      select @SalvagePCT=@inSalvage/100
      select @Year1To4=@inNomVehicle*@RateRetPCT
      if not(@inSalvage is null or @inSalvage = 0)
        select @Year5=@Year1To4-(@inNomVehicle*@SalvagePCT)
      else
        select @Year5=@Year1To4
      select @NPVAmount=(@Year1To4/Power((1+@RateRetPCT),1))+
        (@Year1To4/Power((1+@RateRetPCT),2))+
        (@Year1To4/Power((1+@RateRetPCT),3))+
        (@Year1To4/Power((1+@RateRetPCT),4))+
        (@Year5/Power((1+@RateRetPCT),5))
      select @Payments=(((0-@NPVAmount)*Power((1+@RateRetPCT),5))*-1)/
        (Power((1+@RateRetPCT),5)-1)*@RateRetPCT
    end
  return(@Payments)
end
GO
