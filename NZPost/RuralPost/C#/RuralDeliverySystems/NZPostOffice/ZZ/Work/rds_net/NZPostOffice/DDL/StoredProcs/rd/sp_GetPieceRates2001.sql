/****** Object:  StoredProcedure [rd].[sp_GetPieceRates2001]    Script Date: 08/05/2008 10:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetPieceRates2001 : 
--

create procedure [rd].[sp_GetPieceRates2001](@inRgCode int,@in_Date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select piece_rate_type.prt_code + ' (' + piece_rate_type.prt_description + ')',
    piece_rate_type.prt_key,
    piece_rate.pr_effective_date,
    piece_rate.rg_code,
    piece_rate.pr_active_status,
    piece_rate.pr_rate from
    piece_rate_type left outer join
    piece_rate on
    (piece_rate_type.prt_key = piece_rate.prt_key and
    piece_rate.pr_effective_date = @in_Date) and
    (piece_rate.rg_code = @inRgCode or @inRgCode is null)
end
GO
