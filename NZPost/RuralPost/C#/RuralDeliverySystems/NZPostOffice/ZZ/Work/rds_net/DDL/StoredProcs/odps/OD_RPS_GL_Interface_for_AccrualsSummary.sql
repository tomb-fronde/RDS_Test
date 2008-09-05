/****** Object:  StoredProcedure [odps].[OD_RPS_GL_Interface_for_AccrualsSummary]    Script Date: 08/05/2008 10:13:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_GL_Interface_for_AccrualsSummary : 
--

create procedure [odps].[OD_RPS_GL_Interface_for_AccrualsSummary](@ProcDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4684  June-2006
  -- (reformatted for ledgibility)
  -- Apr05 MRB 
  -- Changed accrual ratio from 0.3548387 (11/31sts) to 0.3333333 (10/30ths)
  -- and removed absolute values as incorectly adding negative allowances.
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from sql code.
  -- Used the corresponding payment_component_type.prs_key instead (same as used in
  -- OD_RPS_GL_Interface_for_Accruals stored procedure) for consistency.
  select pbu_code=pbu_code.pbu_code,
    account_number=account_codes.ac_code,
    transaction_amount=sum(pc_amount)*.3333333333333,description='RD Accruals - Contract Price',drcr='D',
    trans=0,
    trans2=0 from
    rd.contract,
    payment,
    payment_component,
    payment_component_group,
    payment_component_type,
    account_codes,
    pbu_code where
    contract.contract_no = payment.contract_no and
    payment_component.invoice_id = payment.invoice_id and
    payment_component_type.pcg_id = payment_component_group.pcg_id and
    payment_component_type.pct_id = payment_component.pct_id and
    pbu_code.pbu_id = contract.pbu_id and
    account_codes.ac_id = payment_component_type.ac_id and
    -- and ( (payment_component_group.pcg_short_code = 'GP'
    --        or payment_component_group.pcg_short_code ='OGP')
    --      and payment_component_type.pct_id <> 4)
    payment_component_group.pcg_short_code in('GP','OGP') and
    payment_component_type.pct_id <> 4 and
    payment_component_type.prs_key is null and
    -- and (payment_component_type.pct_description not like 'Kiwimail%'
    --      and payment_component_type.pct_description not like 'CourierPos%'
    --      and payment_component_type.pct_description not like 'XP%')
    payment.invoice_date = @procdate
    group by pbu_code.pbu_code,
    account_codes.ac_code
end
GO
