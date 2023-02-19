CREATE PROCEDURE [rd].[sp_GetAddressFrequency](
	@in_contractno INT, 
	@in_adrid INT)
AS
BEGIN
  -- TJB  Sequencing Review  Jan 2011: NEW
  -- Return list of frequencies for contract with rf_selected = 'Y' 
  -- when the address is associated with the frequency or 'N' if not
  
  CREATE TABLE #adr_freq_selected (
						contract_no INT, 
						sf_key INT, 
						rf_delivery_days CHAR(7), 
						rf_selected CHAR(1) NULL,
						rf_distance NUMERIC(10, 2) NULL
				)

  INSERT INTO #adr_freq_selected (
         contract_no, sf_key, rf_delivery_days, rf_selected, rf_distance)
  SELECT contract_no,
         sf_key,
         rf_delivery_days,
         (SELECT 'Y' FROM address_frequency af
                               WHERE af.contract_no = rf.contract_no
                                 AND af.sf_key = rf.sf_key
                                 AND af.rf_delivery_days = rf.rf_delivery_days
                                 AND af.adr_id = @in_adrid),
		 rf_distance 
    FROM route_frequency rf
   WHERE contract_no = @in_contractno
     AND rf_active = 'Y'

  SELECT contract_no,
         sf_key,
         rf_delivery_days,
         rf_selected = (CASE rf_selected
                         WHEN 'Y' THEN 'Y'
                         ELSE 'N'
                         END
                       ),
         rf_monday=substring(rf_delivery_days,1,1),
         rf_tuesday=substring(rf_delivery_days,2,1),
         rf_wednesday=substring(rf_delivery_days,3,1),
         rf_thursday=substring(rf_delivery_days,4,1),
         rf_friday=substring(rf_delivery_days,5,1),
         rf_saturday=substring(rf_delivery_days,6,1),
         rf_sunday=substring(rf_delivery_days,7,1),
         rf_distance
    FROM #adr_freq_selected

  DROP TABLE #adr_freq_selected
END