/****** Object:  StoredProcedure [odps].[OD_RPS_Pay_Summary_ctype]    Script Date: 08/05/2008 10:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [odps].[OD_RPS_Pay_Summary_ctype](@sdate datetime,@edate datetime,@inregion int,@inctype char(63))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  begin TRANSACTION
  -- TJB  SR4684  June-2006
  -- Added ParcelPost
  --
  -- 18/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
  -- sql code.  Used the corresponding payment_component_type.prs_key instead.
  declare @l_region_id int,
  @l_supplier_no int,
  @l_contract_no int,
  @l_contract_seq int,
  @l_invoice_id int,
  @l_ct_key int,
  @l_contractor_supplier_no int,
  @l_contract_seq_no int,
  @l_region_name char(40),
  @l_contract_type char(40),
  @l_co_surname char(52),
  @l_standard numeric(18,2),
  @l_allowance numeric(18,2),
  @l_extension numeric(18,2),
  @l_contract_adjustment numeric(18,2),
  @l_Adpost numeric(18,2),
  @l_CourierPost numeric(18,2),
  @l_Skyroad numeric(18,2),
  @l_ParcelPost numeric(18,2),
  @l_GST_value numeric(18,2),
  @l_wtax_value numeric(18,2),
  @l_adj_notax numeric(18,2),
  @cmd char(1280)
  declare c1 cursor for select region_name,
      region_id,
      contractor_supplier_no,
      contract_no,
      contract_seq_number,
      invoice_id,
      ct_key,
      co_surname,
      contract_type from
      odps.t_pay_summary_contracts
  delete from odps.t_pay_summary_contracts
  --select @cmd='insert into odps.t_pay_summary_contracts'+' select distinct(select region.rgn_name from rd.region'+' where region.region_id = outlet.region_id),'+' outlet.region_id,'+' payment.contractor_supplier_no,'+' payment.contract_no,'+' payment.contract_seq_number,'+' payment.invoice_id,'+' contract.con_base_cont_type,'+' contractor.c_surname_company + isnull(contractor.c_initials,''''),'+' contract_type.contract_type'+' from rd.contract,'+' rd.outlet,'+' rd.contractor,'+' rd.contractor_renewals,'+' rd.contract_type,'+' odps.payment'+' where contract.con_base_office = outlet.outlet_id'+' and contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no'+' and contract.contract_no = contractor_renewals.contract_no'+' and contract.con_base_cont_type in ('+
--    @inctype+')'+' and contract_type.ct_key = contract.con_base_cont_type'+' and ( ( outlet.region_id = '+CONVERT(varchar,@inregion) + 'and '+CONVERT(varchar,@inregion)+' > 0) or ('+CONVERT(varchar,@inregion)+' = 0) )'+' and payment.contract_no = contractor_renewals.contract_no'+' and payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no'+' and payment.contract_seq_number = contractor_renewals.contract_seq_number'+' and payment.invoice_date between '+''''+CONVERT(varchar,@sdate)+''''+' and '+''''+CONVERT(varchar,@edate)+''''
  select @cmd='insert into odps.t_pay_summary_contracts'+' select distinct(select region.rgn_name from rd.region'+' where region.region_id = outlet.region_id),'+' outlet.region_id,'+' payment.contractor_supplier_no,'+' payment.contract_no,'+' payment.contract_seq_number,'+' payment.invoice_id,'+' contract.con_base_cont_type,'+' contractor.c_surname_company + (case when contractor.c_initials is  null then '''' else '',''+ contractor.c_initials end),'+' contract_type.contract_type'+' from rd.contract,'+' rd.outlet,'+' rd.contractor,'+' rd.contractor_renewals,'+' rd.contract_type,'+' odps.payment'+' where contract.con_base_office = outlet.outlet_id'+' and contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no'+' and contract.contract_no = contractor_renewals.contract_no'+' and contract.con_base_cont_type in ('+
    @inctype+')'+' and contract_type.ct_key = contract.con_base_cont_type'+' and ( ( outlet.region_id = '+CONVERT(varchar,@inregion) + 'and '+CONVERT(varchar,@inregion)+' > 0) or ('+CONVERT(varchar,@inregion)+' = 0) )'+' and payment.contract_no = contractor_renewals.contract_no'+' and payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no'+' and payment.contract_seq_number = contractor_renewals.contract_seq_number'+' and payment.invoice_date between '+''''+CONVERT(varchar,@sdate)+''''+' and '+''''+CONVERT(varchar,@edate)+''''
  execute(@cmd)
  delete from odps.t_pay_summary
  open c1
  if @@error <> 0
    begin
      rollback transaction
	  close c1
      return(-1)
    end
  /* Watcom only
  MAINLOOP98:
  */while 1=1 
    begin
      fetch next from c1 into @l_region_name,
        @l_region_id,
        @l_supplier_no,
        @l_contract_no,
        @l_contract_seq,
        @l_invoice_id,
        @l_ct_key,
        @l_co_surname,
        @l_contract_type 
      --!if sqlcode < 0
      --!if sqlstate = '02000'
		if @@FETCH_STATUS <> 0
        BEGIN
        break
        END
        /* Watcom only
        MAINLOOP98
        */
      select @l_standard = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        (payment_component_type.pct_description like 'Contract payment value%' or
        payment_component_type.pct_description like 'Frequency Adjustment%') and
        left(payment_component.comments,6) <> 'Arrear' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_allowance = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.pct_description like 'Contract allowance%' and
        left(payment_component.comments,6) <> 'Arrear' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_extension = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        left(payment_component.comments,6) = 'Arrear' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_Skyroad = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.prs_key = 3 and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_contract_adjustment = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.pct_description like 'Contract Adjustment%' and
        left(payment_component.comments,6) <> 'Arrear' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_Adpost = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.prs_key = 1 and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_CourierPost = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.prs_key = 2 and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_ParcelPost = isnull(sum(pc_amount),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.prs_key = 4 and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_GST_value = isnull(sum(pc_amount*-1),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.pct_description like 'GST%' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_wtax_value = isnull(sum(pc_amount*-1),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.pct_description like 'Withholding Tax%' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      select @l_adj_notax = isnull(sum(pc_amount*-1),0) 
        from odps.payment,odps.payment_component,odps.payment_component_type where
        payment.invoice_id = @l_invoice_id and
        payment_component.invoice_id = payment.invoice_id and
        payment_component_type.pct_id = payment_component.pct_id and
        payment_component_type.pct_description like 'Post-Tax Adjustments%' and
        payment.contractor_supplier_no = @l_supplier_no and
        payment.contract_no = @l_contract_no and
        payment.contract_seq_number = @l_contract_seq
      insert into odps.t_pay_summary(region,
        contract_no,name,
        m_standard,m_allowance,m_extension,m_contract_adjustment,
        m_Adpost,m_CourierPost,m_GST_value,m_wtax_value,m_adj_notax,
        contract_type,m_ParcelPost,m_Skyroad) values(
        @l_region_name,@l_contract_no,@l_co_surname,
        @l_standard,@l_allowance,@l_extension,@l_contract_adjustment,
        @l_Adpost,@l_CourierPost,@l_GST_value,@l_wtax_value,@l_adj_notax,
        @l_contract_type,@l_ParcelPost,@l_Skyroad)
 
    end
  close c1
  DEALLOCATE c1
  commit transaction
  select* from odps.t_pay_summary
end
GO
