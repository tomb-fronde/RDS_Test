create function [rd].[GetConSeqNo] (@contract_no int)
RETURNS int
-- TJB  RPCR_046  Dec-2012
-- Returns the current sequence number for a contract
-- specifically: the largest sequence number where the start date 
-- for the renewal is less than or equal to the current date.
AS
BEGIN
   declare @con_seq_no int
   select @con_seq_no = contract_seq_number
     from contract_renewals 
    where contract_no = @contract_no
      and con_start_date 
              = (select max(con_start_date) from contract_renewals
                  where contract_no = @contract_no
                    and con_start_date <= rd.date(getdate()))
   return @con_seq_no
END