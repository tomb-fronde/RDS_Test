
CREATE PROCEDURE [rd].[sp_AddArticalCountValue](
	@inContractNo int, 
	@inStartWeekPeriod datetime,
	@inColumnName varchar(30),
	@inValue int
	)
AS
-- ========================================================================
-- Author:	Tom Britton
-- Create date: 17-Feb-2015, RPCR_093
-- Description:	
--    Update an artical_count record with the inValue.
--    If the record doesn't exist, insert a new record with 0 values first.
-- ========================================================================
BEGIN
  declare @UpdateQuery varchar(255)
  
  set @UpdateQuery = 'update rd.artical_count set ' + @inColumnName + ' = ' + convert(varchar,@inValue) 
                     + ' where contract_no = ' + convert(varchar,@inContractNo) 
                     + '   and ac_start_week_period = ''' + convert(varchar, @inStartWeekPeriod) + ''';'

  if not exists (select 1 from rd.artical_count 
                  where contract_no = @inContractNo 
                    and ac_start_week_period = @inStartWeekPeriod)
  begin
      insert into rd.artical_count
         (contract_no, ac_start_week_period, 
          ac_w1_medium_letters, ac_w1_other_envelopes, ac_w1_small_parcels, ac_w1_large_parcels, ac_w1_inward_mail,
          ac_w2_medium_letters, ac_w2_other_envelopes, ac_w2_small_parcels, ac_w2_large_parcels, ac_w2_inward_mail)
      values
         (@inContractNo, @inStartWeekPeriod,
          0, 0, 0, 0, 0, 
          0, 0, 0, 0, 0)
  end
  
  exec( @UpdateQuery )
  
END