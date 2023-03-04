
CREATE function [rd].[GetConActiveSeqNo] (@contract_no int)
RETURNS int
-- TJB  Frequencies & Vehicles 15-Jan-2021
-- Adapted from GetConSeqNo (which will get pendings if the date is right)
--
-- TJB  RPCR_046  Dec-2012
-- Returns the current sequence number for a contract
-- specifically: the largest sequence number where the start date 
-- for the renewal is less than or equal to the current date
-- and the contract is not pending (con_acceptance_flag = 'Y'
AS
BEGIN
   declare @con_seq_no int
   select @con_seq_no = cr.contract_seq_number
     from rd.contract_renewals  cr
    where cr.contract_no = @contract_no
      and cr.con_acceptance_flag = 'Y'
      and cr.con_start_date 
              = (select max(cr2.con_start_date) from contract_renewals cr2
                  where cr2.contract_no = cr.contract_no
                    and cr2.con_acceptance_flag = 'Y'
                    and cr2.con_start_date <= rd.date(getdate()))
   return @con_seq_no
END