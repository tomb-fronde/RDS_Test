
-- select rd.f_getChangeDelHrsWeek( 5000, 1, 2 )

CREATE function [rd].[f_getChangeDelHrsWeek](
	@inContract int,
	@inOldSfKey int,
	@inNewSfKey int)
returns numeric(6,3)
-----------------------------------------------------------------
-- TJB  Frequency Change  Dec 2013: NEW                        --
-- This function calculates the change in the delivery hours   --
-- per week when a frequency is changed.  Initially (Dec-2013) --
-- only does so when changing contracts that have a single     --
-- frequency.                                                  --
-- See freq_change_single                                      --
-----------------------------------------------------------------
begin
    declare @old_delivery_hrs_per_week numeric(6,3)
    declare @diff_delivery_hrs_per_week numeric(6,3)
    declare @old_delivery_hrs_adjustment numeric(6,3)
    declare @num_contracts  int
    declare @old_days_week int
    declare @new_days_week int
    declare @diff_days_week numeric(6,3)
    declare @con_rates_effective_date datetime

    select @num_contracts = count(*) 
      from route_frequency
     where contract_no = @inContract
       and rf_active = 'Y'     

    if (@num_contracts = 1)
    begin
        select @old_days_week = sf_days_week 
          from standard_frequency
         where sf_key = @inOldSfKey

        select @new_days_week = sf_days_week 
          from standard_frequency
         where sf_key = @inNewSfKey

        select @diff_days_week = (@new_days_week - @old_days_week)

        select @old_delivery_hrs_per_week = cr.con_del_hrs_week_at_renewal
             , @con_rates_effective_date = cr.con_rates_effective_date
          from contract_renewals cr
         where cr.contract_no = @inContract
           and cr.contract_seq_number = rd.GetConSeqNo(@inContract)

        select @old_delivery_hrs_adjustment 
                    = sum(isnull(fd.fd_delivery_hrs_per_week,0))
          from frequency_distances fd
         where fd.contract_no = @inContract
           and fd.sf_key = @inOldSfKey
           and fd.fd_effective_date >= @con_rates_effective_date
         group by fd.contract_no, fd.fd_delivery_hrs_per_week

        select  @diff_delivery_hrs_per_week = @old_delivery_hrs_per_week
                                              * (@diff_days_week/@old_days_week)
    end

    return isnull(@diff_delivery_hrs_per_week,0)
end