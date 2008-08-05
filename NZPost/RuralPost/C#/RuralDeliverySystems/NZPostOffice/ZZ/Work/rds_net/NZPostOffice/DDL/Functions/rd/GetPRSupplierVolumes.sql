/****** Object:  UserDefinedFunction [rd].[GetPRSupplierVolumes]    Script Date: 08/05/2008 11:24:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function GetPRSupplierVolumes : 
--

create function [rd].[GetPRSupplierVolumes](@inRegion int,@inSupplier int,@inFromDate datetime,@inToDate datetime)
returns int
AS
BEGIN

  declare @iVolume int
  select @iVolume = sum(piece_rate_delivery.prd_quantity) 
    from piece_rate_delivery join
    contract on
    piece_rate_delivery.contract_no = contract.contract_no and
    piece_rate_delivery.prd_date between @inFromDate and @inToDate join
    piece_rate_type on
    piece_rate_delivery.prt_key = piece_rate_type.prt_key and
    piece_rate_type.prs_key = @inSupplier
  return @iVolume
end
GO
