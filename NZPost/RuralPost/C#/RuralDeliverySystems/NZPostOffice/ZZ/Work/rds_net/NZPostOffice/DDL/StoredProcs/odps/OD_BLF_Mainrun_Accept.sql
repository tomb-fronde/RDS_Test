/****** Object:  StoredProcedure [odps].[OD_BLF_Mainrun_Accept]    Script Date: 08/05/2008 10:13:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [odps].[OD_BLF_Mainrun_Accept] @enddat DATETIME ,@SWP_Re INT OUTPUT 
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
   declare @v_payment_count INT
   declare @v_payment_component_count INT
   declare @v_payment_pr_count INT
   declare @v_max_invoice_no INT
   declare @v_max_invoice_id INT
   declare @v_max_pc_id INT
   declare @v_max_pcpr_id INT
   declare @v_contractor INT
   declare @v_contract INT
   DECLARE @SWV_er INT
BEGIN TRANSACTION
	  set @v_max_pc_id =0

      update odps.t_payment_component set pc_amount = odps.t_payment_component.pc_amount*-1  where
      odps.t_payment_component.pct_id =(select max(odps.Payment_Component_Type.pct_id) from
      odps.payment_component_group,
      odps.Payment_Component_Type where
      odps.Payment_Component_Type.pcg_id = odps.payment_component_group.pcg_id and
      odps.payment_component_group.pcg_short_code = 'GST' and
      odps.Payment_Component_Type.pct_description like 'GST%')
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2000
         RETURN 
      end
  -- get contractor and contract no for date validations
      select  top 1 @v_contractor = contractor_supplier_no,@v_contract = contract_no  from odps.t_payment
  -- TWC - 15/09/2003 - check date against contractor tenure dates.
      update rd.contract_adjustments set ca_date_paid = @enddat  where
      exists(select odps.t_payment.contract_no from
      odps.t_payment where
      odps.t_payment.contract_no = rd.contract_adjustments.contract_no and
      rd.contract_adjustments.ca_date_occured <= rd.getContractorEnd(odps.t_payment.contract_no,odps.t_payment.contractor_supplier_no) and -- end date of contractor
      rd.contract_adjustments.ca_date_occured >= rd.getContractorStart(odps.t_payment.contract_no,odps.t_payment.contractor_supplier_no)) and -- start date of contractor 
    --and t_payment.contract_seq_number=contract_adjustments.contract_seq_number
      ca_confirmed = 'Y' and
      ca_date_occured <= @enddat and
      ca_date_paid is null
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2005
         RETURN 
      end
      update rd.frequency_adjustments set fd_paid_to_date = @enddat  where
      exists(select odps.t_payment.contract_no from
      odps.t_payment where
      odps.t_payment.contract_no = rd.frequency_adjustments.contract_no and
      odps.t_payment.contract_seq_number = rd.frequency_adjustments.contract_seq_number) and
      fd_paid_to_date is null and
      fd_confirmed = 'Y' and
      fd_effective_date <=(select max(invoice_date) from odps.t_payment)
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2010
         RETURN
      end
      update rd.contract_allowance set ca_paid_to_date = @enddat  where
      exists(select odps.t_payment.contract_no from odps.t_payment where odps.t_payment.contract_no = rd.contract_allowance.contract_no) and
      ca_effective_date <=(select max(invoice_date) from odps.t_payment) and
      ca_paid_to_date is null
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2020
         RETURN
      end
      --!update odps.t_payment_runs set pr_id =(select isnull(max(pr_id),0)+1 from odps.payment_runs)
      /*Cannot update identity column 'pr_id' in MSSQL */
		---changed to:
		delete odps.t_payment_runs_2
		insert into odps.t_payment_runs_2 select * from odps.t_payment_runs 
		update odps.t_payment_runs_2 set pr_id =(select isnull(max(pr_id),0)+1 from odps.payment_runs)
		ALTER TABLE odps.t_payment NOCHECK CONSTRAINT FK_t_payment_runs
		delete odps.t_payment_runs 
		SET IDENTITY_INSERT odps.t_payment_runs On
		insert into odps.t_payment_runs(pr_id,pr_date,gl_posted,pr_ap_posted,pr_contract_no,pots) select * from odps.t_payment_runs_2 
			  if @@error <> 0
			  begin
				 rollback 
				ALTER TABLE odps.t_payment CHECK CONSTRAINT FK_t_payment_runs
				SET IDENTITY_INSERT odps.t_payment_runs Off
				 set @SWP_Re = -2030
				 RETURN
			  end
		ALTER TABLE odps.t_payment CHECK CONSTRAINT FK_t_payment_runs
		SET IDENTITY_INSERT odps.t_payment_runs Off
		---end changed
      insert into odps.payment_runs select (select isnull(max(pr_id),0)+1 from odps.payment_runs),
      pr_date,gl_posted,pr_ap_posted,pr_contract_no,POTS from odps.t_payment_runs
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2040
         RETURN
      end
      select @v_payment_count = 1   where exists(select 1 from odps.Payment)
      if @v_payment_count = 0 or @v_payment_count is null
      begin
         insert into odps.Payment select contractor_supplier_no,contract_no,contract_seq_number,invoice_id,pr_id,invoice_date,Witholding_tax_rate_applied,invoice_id,case_no,
         POTS from odps.t_payment
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2050
            RETURN
         end
         insert into odps.post_tax_deductions_applied(pcd_amount,ded_id,pcd_date,invoice_id) 
select /*null,*/pcd_amount,ded_id,pcd_date,invoice_id from odps.t_post_tax_deductions_applied
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2051
            RETURN
         end
      end
      else
      begin
         select @v_max_invoice_no = max(invoice_no)  from odps.Payment where invoice_date = @enddat
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2051
            RETURN
         end
         select @v_max_invoice_id = max(invoice_id)  from odps.Payment
         if @v_max_invoice_no = 0 or @v_max_invoice_no is null
         begin
            set @v_max_invoice_no = 0
         end
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2055
            RETURN
         end

         insert into odps.Payment select contractor_supplier_no,contract_no,contract_seq_number,invoice_id+@v_max_invoice_id,pr_id,invoice_date,Witholding_tax_rate_applied,/*number(*)*/ (ROW_NUMBER()  OVER (ORDER BY contract_no ASC)) +@v_max_invoice_no,
         case_no,POTS from odps.t_payment
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2080
            RETURN
         end
           insert into odps.post_tax_deductions_applied(pcd_amount,ded_id,pcd_date,invoice_id)
			 select /*null,*/pcd_amount,ded_id,pcd_date,invoice_id+@v_max_invoice_id 
				from odps.t_post_tax_deductions_applied

      end

      select @v_payment_component_count = 1   where exists(select 1 from odps.Payment_Component)
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2085
         RETURN
      end

      if @v_payment_component_count = 0 or @v_payment_component_count is null
      begin
         insert into odps.Payment_Component select* from odps.t_payment_component where pc_amount <> 0
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2090
            RETURN
         end
      end
      else
      begin
         select @v_max_pc_id = max(pc_id)+1  from odps.Payment_Component
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2095
            RETURN 

         end
         --!update odps.t_payment_component set pc_id =(pc_id+@v_max_pc_id)*-1
--         --!update odps.t_payment_component set pc_id = pc_id*-1
--         if @@error <> 0
--         begin
--            rollback 
--            set @SWP_Re = -2120
--            RETURN 
--         end
		---changed to:
		delete odps.t_payment_component_2

		insert into odps.t_payment_component_2 select pc_id+@v_max_pc_id , pct_id,invoice_id,pc_amount,comments,misc_date,misc_string,misc_decimal from odps.t_payment_component
		ALTER TABLE odps.t_payment_component_piece_rates NOCHECK CONSTRAINT FK_t_payment_component
		delete odps.t_payment_component
		SET IDENTITY_INSERT odps.t_payment_component On
		insert into odps.t_payment_component(pc_id, pct_id,invoice_id,pc_amount,comments,misc_date,misc_string,misc_decimal) 
			select * from odps.t_payment_component_2

		ALTER TABLE odps.t_payment_component_piece_rates CHECK CONSTRAINT FK_t_payment_component
		SET IDENTITY_INSERT odps.t_payment_component Off
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2100
            RETURN 
         end
		---end changed
  --jlwang
           --set @v_max_pc_id= @v_max_pc_id+2
           --DBCC CHECKIDENT ('odps.t_payment_component', RESEED,  @v_max_pc_id)
           --insert into t_payment_component(pct_id,invoice_id,pc_amount,comments,misc_date,misc_string,misc_decimal) select pct_id,invoice_id,pc_amount,comments,misc_date,misc_string,misc_decimal from t_payment_component
           --delete from t_payment_component where pc_id < @v_max_pc_id-2
   --jlwang:end
         insert into Payment_Component(pc_id,pct_id,invoice_id,pc_amount,comments,misc_date,misc_string,misc_decimal) select pc_id,pct_id,invoice_id+@v_max_invoice_id,pc_amount,comments,misc_date,misc_String,misc_decimal from odps.t_payment_component where pc_amount <> 0
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2130
            RETURN 
         end

      end
      select @v_payment_pr_count = 1   where exists(select 1 from odps.Payment_component_piece_rates)
      if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2140
         RETURN
      end
      if @v_payment_pr_count = 0 or @v_payment_pr_count is null
      begin
         if ((select count(*) from odps.t_payment_component_piece_rates) >0) --added
         begin  --added
			 insert into odps.Payment_component_piece_rates(prt_key,pc_id,pcpr_volume,pcpr_value) select prt_key,pc_id +@v_max_pc_id,pcpr_volume,pcpr_value from odps.t_payment_component_piece_rates
			 if @@error <> 0
				 begin
					rollback 
					set @SWP_Re = -2150
					RETURN
				 end

         end --added
      end
      else
      begin
         select @v_max_pcpr_id = max(pcpr_id)+1  from odps.Payment_component_piece_rates
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2160
            RETURN
         end
         --!update odps.t_payment_component_piece_rates set pcpr_id =(pcpr_id+@v_max_pcpr_id)*-1
		---changed to:
		delete odps.t_payment_component_piece_rates_2
		insert into odps.t_payment_component_piece_rates_2 
			select pcpr_id+@v_max_pcpr_id, prt_key, pc_id +@v_max_pc_id ,pcpr_volume, pcpr_value from odps.t_payment_component_piece_rates

		delete odps.t_payment_component_piece_rates
		SET IDENTITY_INSERT odps.t_payment_component_piece_rates on
		insert into odps.t_payment_component_piece_rates (pcpr_id,prt_key,pc_id,pcpr_volume,pcpr_value) 
			select * from odps.t_payment_component_piece_rates_2 
		SET IDENTITY_INSERT odps.t_payment_component_piece_rates off
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2170
            RETURN 
         end
         --!update odps.t_payment_component_piece_rates set pcpr_id = pcpr_id*-1
		---end changed
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2180
            RETURN 
         end
         insert into odps.Payment_component_piece_rates(prt_key,pc_id,pcpr_volume,pcpr_value) select prt_key,pc_id,pcpr_volume,pcpr_value from odps.t_payment_component_piece_rates
         if @@error <> 0
         begin
            rollback 
            set @SWP_Re = -2190
            RETURN
         end
		--if @@rowcount >0
			delete odps.t_payment_component_piece_rates
      end
  -- TWC - 15/09/2003 check prd_date against contractors tenure dates
      update rd.piece_rate_delivery set prd_paid_to_date = @enddat  where
      exists(select odps.Payment.contract_no from odps.Payment where
      odps.Payment.contract_no = rd.piece_rate_delivery.contract_no and
      rd.piece_rate_delivery.prd_date <= rd.getContractorEnd(odps.Payment.contract_no,odps.Payment.contractor_supplier_no) and -- end date
      rd.piece_rate_delivery.prd_date >= rd.getContractorStart(odps.Payment.contract_no,odps.Payment.contractor_supplier_no)) and -- start date
      prd_paid_to_date is null and
      prd_date between(select min(sdate) from odps.t_piecerate_tracker where odps.t_piecerate_tracker.contract_no = rd.piece_rate_delivery.contract_no)
      and(select max(edate) from odps.t_piecerate_tracker where odps.t_piecerate_tracker.contract_no = rd.piece_rate_delivery.contract_no)
	if @@error <> 0
      begin
         rollback 
         set @SWP_Re = -2191
         RETURN
      end
      commit work
      set @SWP_Re = 1

      RETURN



end
GO
