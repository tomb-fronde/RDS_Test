
CREATE FUNCTION [rd].[GetRateReturn](
	@inNomVehicle decimal(10,2),
	@inRateReturn decimal(10,2),
	@inSalvage decimal(10,2))
returns real
--
-- Modifications
-- 22-Mar-2022  TJB  Frequencies & Allowances
--                   Encountered overflows converting some real values to decimal. Changed several
--                   decimal variables to real.
-- 16-Apr-2009  TJB  Returns 0 if result is null or negative
-- 20-Jun-2010  TJB  RPCR_0016: Changed calculation
--                   The NPV calculation is based on the Excel function's formula
--                   The Payment formula is based on the Excel PMT function's formula
AS
BEGIN

  declare @VYear1 decimal(10,2),       -- Yearly vehicle value
          @VYear2 decimal(10,2),
          @VYear3 decimal(10,2),
          @VYear4 decimal(10,2),
          @VYear5 decimal(10,2),
          @IYear1 decimal(10,2),       -- Yearly Capital Charge (Interest)
          @IYear2 decimal(10,2),
          @IYear3 decimal(10,2),
          @IYear4 decimal(10,2),
          @IYear5 decimal(10,2),
          @Deprec decimal(10,2),       -- Depreciation
          @DeprecYr decimal(10,2),     -- Pro-rated depreciation
		  @OnePlusRateRetPCT real, -- decimal(10,6),
          @SalvagePCT  real,       -- decimal(10,6),
          @Payments    real,       -- decimal(10,6),
          @RateRetPCT  real,       -- decimal(10,6),
          @NPVAmount   real,        -- decimal(10,6)
          @ReturnValue real
          
  if not(@inRateReturn is null or @inRateReturn = 0)
  begin
      select @RateRetPCT        = @inRateReturn/100
      select @OnePlusRateRetPCT = 1 + @RateRetPCT
      select @SalvagePCT        = @inSalvage/100
      select @Deprec            = @inNomVehicle * @SalvagePCT
      select @DeprecYr          = (@inNomVehicle - @Deprec)/5
      -- Calculate the vehicle value over 5 years
      select @VYear1 = @inNomVehicle
      select @VYear2 = @VYear1 - @DeprecYr
      select @VYear3 = @VYear2 - @DeprecYr
      select @VYear4 = @VYear3 - @DeprecYr
      select @VYear5 = @VYear4 - @DeprecYr
      -- Calculate the Capital Charge on the vehicle value over 5 years
      select @IYear1 = @VYear1 * @RateRetPCT
      select @IYear2 = @VYear2 * @RateRetPCT
      select @IYear3 = @VYear3 * @RateRetPCT
      select @IYear4 = @VYear4 * @RateRetPCT
      select @IYear5 = @VYear5 * @RateRetPCT
      
      -- Calculate the NPV (Nominal Present Value) of the 5 years Capital Charge
      select @NPVAmount = @IYear1/POWER(@OnePlusRateRetPCT,1) 
                          + @IYear2/POWER(@OnePlusRateRetPCT,2)
                          + @IYear3/POWER(@OnePlusRateRetPCT,3)
                          + @IYear4/POWER(@OnePlusRateRetPCT,4)
                          + @IYear5/POWER(@OnePlusRateRetPCT,5)
      
      -- Calculate the PMT (Period payment amount) of the NPV amount over 5 periods (1 per year)
      select @Payments = (@NPVAmount * @RateRetPCT * POWER(@OnePlusRateRetPCT,5))
                                     / (POWER(@OnePlusRateRetPCT,5) - 1)
      
  end

  if (@Payments is null or @Payments < 0)
      set @Payments = 0
      
  set @ReturnValue = round(@Payments,2)
  
  return(@ReturnValue)
end