/****** Object:  UserDefinedFunction [rd].[maxSeqContractor]    Script Date: 08/05/2008 11:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function maxSeqContractor : 
--

create function [rd].[maxSeqContractor](@con_no int,@contractor_no int)
returns int
AS
BEGIN

  declare @max_seq int,
  @active_seq int
  select @max_seq = max(crn.contract_seq_number) 
    from contractor_renewals as crn join contract_renewals as cr on crn.contract_no = cr.contract_no and crn.contract_seq_number = cr.contract_seq_number where
    crn.contract_no = @con_no and
    crn.contractor_supplier_no = @contractor_no and
    -- TWC - 14/10/2003 don''t return seq for pending
    cr.con_acceptance_flag = 'Y'
  select @active_seq = con_active_sequence 
    from contract as con where
    con.contract_no = @con_no
  if @max_seq > @active_seq
    select @max_seq=@active_seq
  return @max_seq
end
GO
