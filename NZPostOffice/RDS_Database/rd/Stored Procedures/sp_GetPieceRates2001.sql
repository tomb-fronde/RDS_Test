
--
-- Definition for stored procedure sp_GetPieceRates2001 : 
--

CREATE procedure [rd].[sp_GetPieceRates2001](
	@inRgCode int,
	@in_Date datetime)
AS
-- TJB  RPCR_054  June-2013: Modified
-- Get most-recent piece rates for the renewal group
-- Called from RDS.Entity.Ruraldw.Piecerates2001.cs
BEGIN
  set CONCAT_NULL_YIELDS_NULL off
  select piece_rate_type.prt_code + ' (' + piece_rate_type.prt_description + ')',
         piece_rate_type.prt_key,
         pr1.pr_effective_date,
         pr1.rg_code,
         pr1.pr_active_status,
         pr1.pr_rate 
    from piece_rate_type left outer join piece_rate pr1 
                    on piece_rate_type.prt_key = pr1.prt_key 
                    and (pr1.rg_code = @inRgCode or @inRgCode is null)
   where pr1.pr_effective_date 
               = (select max(pr_effective_date) 
                    from piece_rate pr2
                   where pr2.prt_key = piece_rate_type.prt_key
                    and (pr2.rg_code = @inRgCode or @inRgCode is null))
end