
--
-- Definition for user-defined function get_prev_bench : 
--

--
-- Definition for user-defined function get_prev_bench : 
--

create function [rd].[get_prev_bench](@con_no int)
returns numeric(10,2)
AS
BEGIN

  declare @former_bench numeric(10,2),
  @active_con_seq int,
  @latest_con_seq int,
  @latest_uni_seq int
  -- get latest contract_sequence number
  select @latest_con_seq=max(fa.contract_seq_number) 
    from frequency_adjustments as fa where
    fa.contract_no = @con_no
  -- if is zero - set former to zero
  if @latest_con_seq is null or @latest_con_seq = 0
    select @former_bench=0
  else
    begin
      -- get the latest unique sequence number
      select @latest_uni_seq= max(fa.fd_unique_seq_number)
        from frequency_adjustments as fa where
        fa.contract_no = @con_no and
        fa.contract_seq_number = @latest_con_seq
      -- get the latest benchmark figure from the table
      select @former_bench=max(fd_bm_after_extn) 
        from frequency_adjustments as fa where
        fa.contract_no = @con_no and
        fa.contract_seq_number = @latest_con_seq and
        fa.fd_unique_seq_number = @latest_uni_seq
    end
  if @former_bench is null
    select @former_bench=0
  return @former_bench
end