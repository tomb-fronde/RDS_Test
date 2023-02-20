/****** Object:  StoredProcedure [odps].[OD_RPS_NationalChangesHistory]    Script Date: 08/05/2008 10:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_NationalChangesHistory : 
--

create procedure [odps].[OD_RPS_NationalChangesHistory](@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select nat_ac_id_gst_gl,
    nat_ac_id_whtax_gl,
    nat_ac_id_postax_adj_gl,
    nat_rural_post_gst_no,
    nat_gst_rate,
    nat_ird_no,
    nat_rural_post_address,
    nat_rural_post_payer_name,
    nat_acc_percentage,
    nat_standard_tax_rate,
    nat_day_of_month,
    nat_message_for_invoice,
    nat_net_pct_change_warn,
    nat_seq_no_for_keys,
    nat_od_standard_gst_rate,
    nat_od_tax_rate_ir13,
    nat_od_tax_rate_no_ir13,
    ap_net_pay_clearing_account,
    nat_effective_date,
    nat_ac_id_contprice_gl,
    nat_ac_id_netpay_gl,
    nat_ac_id_accrualbalance_gl,
    nat_pbu_code_postax_gl,
    nat_pbu_code_whtax_gl,
    nat_pbu_code_gst_gl,
    nat_pbu_code_netpay_gl,
    nat_invoice_number_prefix from
    [national] where
    nat_effective_date = (select max(nat_effective_date) from
      [national] where
      nat_effective_date between @Sdate and @Edate) union
  select nat_ac_id_gst_gl,
    nat_ac_id_whtax_gl,
    nat_ac_id_postax_adj_gl,
    nat_rural_post_gst_no,
    nat_gst_rate,
    nat_ird_no,
    nat_rural_post_address,
    nat_rural_post_payer_name,
    nat_acc_percentage,
    nat_standard_tax_rate,
    nat_day_of_month,
    nat_message_for_invoice,
    nat_net_pct_change_warn,
    nat_seq_no_for_keys,
    nat_od_standard_gst_rate,
    nat_od_tax_rate_ir13,
    nat_od_tax_rate_no_ir13,
    ap_net_pay_clearing_account,
    nat_effective_date,
    nat_ac_id_contprice_gl,
    nat_ac_id_netpay_gl,
    nat_ac_id_accrualbalance_gl,
    nat_pbu_code_postax_gl,
    nat_pbu_code_whtax_gl,
    nat_pbu_code_gst_gl,
    nat_pbu_code_netpay_gl,
    nat_invoice_number_prefix from
    [national] where
    nat_effective_date = (select max(nat_effective_date) from
      [national] where
      nat_effective_date < (select max(nat_effective_date) from
        [national] where
        nat_effective_date between @Sdate and @Edate))
end
GO
