/****** Object:  StoredProcedure [odps].[OD_RPS_VolumesValues_Detail]    Script Date: 08/05/2008 10:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_VolumesValues_Detail : 
--

create procedure [odps].[OD_RPS_VolumesValues_Detail](@sdate datetime,@edate datetime,@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select region.rgn_name,
    contractor.c_surname_company,
    contractor.c_first_names,
    piece_rate_supplier.prs_description,
    piece_rate_type.prt_code + ' (' + prt_description + ')',
    payment_component_piece_rates.pcpr_volume,
    payment_component_piece_rates.pcpr_value,
    contract.contract_no from
    payment,
    payment_component,
    rd.piece_rate_supplier,
    payment_component_piece_rates,
    rd.piece_rate_type,
    rd.contractor,
    rd.contract,
    rd.outlet,
    rd.region where
    (payment_component.invoice_id = payment.invoice_id) and
    (payment_component_piece_rates.pc_id = payment_component.pc_id) and
    (piece_rate_type.prs_key = piece_rate_supplier.prs_key) and
    (piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and
    (payment.contractor_supplier_no = contractor.contractor_supplier_no) and
    (payment.contract_no = contract.contract_no) and
    (region.region_id = outlet.region_id) and
    (contract.con_base_office = outlet.outlet_id) and
    ((outlet.region_id = @inregion and
    @inregion > 0) or
    (@inregion = 0)) and
    payment.invoice_date between @sdate and @edate order by
    region.rgn_name asc,
    contract.contract_no asc,
    contractor.c_surname_company asc,
    contractor.c_first_names asc,
    piece_rate_supplier.prs_description asc,
    piece_rate_type.prt_description asc
end
GO
