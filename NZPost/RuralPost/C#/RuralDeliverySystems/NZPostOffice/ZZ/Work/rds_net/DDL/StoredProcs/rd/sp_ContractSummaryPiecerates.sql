/****** Object:  StoredProcedure [rd].[sp_ContractSummaryPiecerates]    Script Date: 08/05/2008 10:18:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_ContractSummaryPiecerates : 
--

create procedure [rd].[sp_ContractSummaryPiecerates](@inContract int,@mo int,@yr int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select piece_rate_supplier.prs_description,
    mo1=(select rd.f_piecerate(@incontract,@mo+1,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key))),
    mo2=(select rd.f_piecerate(@incontract,@mo+2,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo3=(select rd.f_piecerate(@incontract,@mo+3,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo4=(select rd.f_piecerate(@incontract,@mo+4,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key))),
    mo5=(select rd.f_piecerate(@incontract,@mo+5,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key))),
    mo6=(select rd.f_piecerate(@incontract,@mo+6,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo7=(select rd.f_piecerate(@incontract,@mo+7,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo8=(select rd.f_piecerate(@incontract,@mo+8,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key))),
    mo9=(select rd.f_piecerate(@incontract,@mo+9,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo10=(select rd.f_piecerate(@incontract,@mo+10,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo11=(select rd.f_piecerate(@incontract,@mo+11,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ),
    mo12=(select rd.f_piecerate(@incontract,@mo+12,@yr-1,(select prs.prs_key from piece_rate_supplier as prs where prs.prs_key = piece_rate_supplier.prs_key)) ) from
    piece_rate_supplier
end
GO
