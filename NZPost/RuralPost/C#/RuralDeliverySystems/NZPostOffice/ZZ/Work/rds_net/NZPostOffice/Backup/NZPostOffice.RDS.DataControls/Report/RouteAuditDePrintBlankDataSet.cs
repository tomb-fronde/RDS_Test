using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RRouteAuditDePrintBlank
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public DateTime RaDateOfCheck
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeStartedSort
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeFinishedSort
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeReturned
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeDeparted
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTotalHours
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaMealBreaks
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaExtraTime
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaFinalHours
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal RaFinishOdometer
        {
            get
            {
                return 0;
            }
        }
        public decimal RaStartOdometer
        {
            get
            {
                return 0;
            }
        }
        public decimal RaExtraDistance
        {
            get
            {
                return 0;
            }
        }
        public DateTime RaOthrGdsBefore
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaOthrGdsDuring
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaOthrGdsAfter
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaPrBefore
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaPrDuring
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaPrAfter
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal RaTotalDistance
        {
            get
            {
                return 0;
            }
        }
        public decimal RaFinalDistance
        {
            get
            {
                return 0;
            }
        }
        public string RaFrequency
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaContractor
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaEmployee
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaVehicleMake
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaVehicleModel
        {
            get
            {
                return string.Empty;
            }
        }
        public int RaYear
        {
            get
            {
                return 0;
            }
        }
        public string RaRegistrationNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaFuel
        {
            get
            {
                return string.Empty;
            }
        }
        public int RaCcRating
        {
            get
            {
                return 0;
            }
        }
        public string RaCondition
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime RaRecReplace
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string RaTyreSize
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaGdsService
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaGdsServiceSighted
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaMvInsurance
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaCrInsurance
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaPlInsurance
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaInsuranceSighted
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaNewVehicle
        {
            get
            {
                return string.Empty;
            }
        }
        public int RaVehiclePrice
        {
            get
            {
                return 0;
            }
        }
        public DateTime RaVehiclePurchased
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string RaMailVolume
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaMvComments
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaAdpostVolume
        {
            get
            {
                return string.Empty;
            }
        }
        public int RaNoCircularDrops
        {
            get
            {
                return 0;
            }
        }
        public string RaCourierpostVolume
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaCpComments
        {
            get
            {
                return string.Empty;
            }
        }
        public int RaNoRegCusts
        {
            get
            {
                return 0;
            }
        }
        public int RaNoRegCustsCoreProds
        {
            get
            {
                return 0;
            }
        }
        public int RaOtherCusts
        {
            get
            {
                return 0;
            }
        }
        public int RaRuralPrivateBags
        {
            get
            {
                return 0;
            }
        }
        public int RaPrivateBags
        {
            get
            {
                return 0;
            }
        }
        public int RaClosedMails
        {
            get
            {
                return 0;
            }
        }
        public int RaPostShops
        {
            get
            {
                return 0;
            }
        }
        public int RaPostCentres
        {
            get
            {
                return 0;
            }
        }
        public int RaNoCmbs
        {
            get
            {
                return 0;
            }
        }
        public int RaNoCmbCusts
        {
            get
            {
                return 0;
            }
        }
        public int RaTotalDelPoints
        {
            get
            {
                return 0;
            }
        }
        public string RaSortingFacilities
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaSortingCase
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaSortingComments
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal RaLengthSealed
        {
            get
            {
                return 0;
            }
        }
        public decimal RaLenthUnsealed
        {
            get
            {
                return 0;
            }
        }
        public decimal RaTotalLength
        {
            get
            {
                return 0;
            }
        }
        public string RaRoadConditions
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaSuggestedImprovements
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaCommencementOk
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaCommencementReason
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaTimetableChange
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaRouteOk
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaRouteReason
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaDeviations
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaDeviationInDesc
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaDeviationReason
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaDescriptionUotdated
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaSaftyAccessAddresses
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime RaSaftyAccessResolvedDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string RaSafteyAccessActions
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaSaftyPlanCompleted
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime RaSaftyPlanCompletedDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string RaSaftyPlanActions
        {
            get
            {
                return string.Empty;
            }
        }
        public string RaSaftyPracticesExists
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime RaSaftyPracticesResolvedDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string RaSaftyPracticesActions
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Compute1
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute2
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute3
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute4
        {
            get
            {
                return 0;
            }
        }
    }
    public class RouteAuditDePrintBlankDataSet : ReportDataSet<RouteAuditDePrintBlank>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn RaDateOfCheck = new DataColumn("RaDateOfCheck", typeof(DateTime));

        public DataColumn RaTimeStartedSort = new DataColumn("RaTimeStartedSort", typeof(DateTime));

        public DataColumn RaTimeFinishedSort = new DataColumn("RaTimeFinishedSort", typeof(DateTime));

        public DataColumn RaTimeReturned = new DataColumn("RaTimeReturned", typeof(DateTime));

        public DataColumn RaTimeDeparted = new DataColumn("RaTimeDeparted", typeof(DateTime));

        public DataColumn RaTotalHours = new DataColumn("RaTotalHours", typeof(DateTime));

        public DataColumn RaMealBreaks = new DataColumn("RaMealBreaks", typeof(DateTime));

        public DataColumn RaExtraTime = new DataColumn("RaExtraTime", typeof(DateTime));

        public DataColumn RaFinalHours = new DataColumn("RaFinalHours", typeof(DateTime));

        public DataColumn RaFinishOdometer = new DataColumn("RaFinishOdometer", typeof(decimal));

        public DataColumn RaStartOdometer = new DataColumn("RaStartOdometer", typeof(decimal));

        public DataColumn RaExtraDistance = new DataColumn("RaExtraDistance", typeof(decimal));

        public DataColumn RaOthrGdsBefore = new DataColumn("RaOthrGdsBefore", typeof(DateTime));

        public DataColumn RaOthrGdsDuring = new DataColumn("RaOthrGdsDuring", typeof(DateTime));

        public DataColumn RaOthrGdsAfter = new DataColumn("RaOthrGdsAfter", typeof(DateTime));

        public DataColumn RaPrBefore = new DataColumn("RaPrBefore", typeof(DateTime));

        public DataColumn RaPrDuring = new DataColumn("RaPrDuring", typeof(DateTime));

        public DataColumn RaPrAfter = new DataColumn("RaPrAfter", typeof(DateTime));

        public DataColumn RaTotalDistance = new DataColumn("RaTotalDistance", typeof(decimal));

        public DataColumn RaFinalDistance = new DataColumn("RaFinalDistance", typeof(decimal));

        public DataColumn RaFrequency = new DataColumn("RaFrequency", typeof(string));

        public DataColumn RaContractor = new DataColumn("RaContractor", typeof(string));

        public DataColumn RaEmployee = new DataColumn("RaEmployee", typeof(string));

        public DataColumn RaVehicleMake = new DataColumn("RaVehicleMake", typeof(string));

        public DataColumn RaVehicleModel = new DataColumn("RaVehicleModel", typeof(string));

        public DataColumn RaYear = new DataColumn("RaYear", typeof(int));

        public DataColumn RaRegistrationNo = new DataColumn("RaRegistrationNo", typeof(string));

        public DataColumn RaFuel = new DataColumn("RaFuel", typeof(string));

        public DataColumn RaCcRating = new DataColumn("RaCcRating", typeof(int));

        public DataColumn RaCondition = new DataColumn("RaCondition", typeof(string));

        public DataColumn RaRecReplace = new DataColumn("RaRecReplace", typeof(DateTime));

        public DataColumn RaTyreSize = new DataColumn("RaTyreSize", typeof(string));

        public DataColumn RaGdsService = new DataColumn("RaGdsService", typeof(string));

        public DataColumn RaGdsServiceSighted = new DataColumn("RaGdsServiceSighted", typeof(string));

        public DataColumn RaMvInsurance = new DataColumn("RaMvInsurance", typeof(string));

        public DataColumn RaCrInsurance = new DataColumn("RaCrInsurance", typeof(string));

        public DataColumn RaPlInsurance = new DataColumn("RaPlInsurance", typeof(string));

        public DataColumn RaInsuranceSighted = new DataColumn("RaInsuranceSighted", typeof(string));

        public DataColumn RaNewVehicle = new DataColumn("RaNewVehicle", typeof(string));

        public DataColumn RaVehiclePrice = new DataColumn("RaVehiclePrice", typeof(int));

        public DataColumn RaVehiclePurchased = new DataColumn("RaVehiclePurchased", typeof(DateTime));

        public DataColumn RaMailVolume = new DataColumn("RaMailVolume", typeof(string));

        public DataColumn RaMvComments = new DataColumn("RaMvComments", typeof(string));

        public DataColumn RaAdpostVolume = new DataColumn("RaAdpostVolume", typeof(string));

        public DataColumn RaNoCircularDrops = new DataColumn("RaNoCircularDrops", typeof(int));

        public DataColumn RaCourierpostVolume = new DataColumn("RaCourierpostVolume", typeof(string));

        public DataColumn RaCpComments = new DataColumn("RaCpComments", typeof(string));

        public DataColumn RaNoRegCusts = new DataColumn("RaNoRegCusts", typeof(int));

        public DataColumn RaNoRegCustsCoreProds = new DataColumn("RaNoRegCustsCoreProds", typeof(int));

        public DataColumn RaOtherCusts = new DataColumn("RaOtherCusts", typeof(int));

        public DataColumn RaRuralPrivateBags = new DataColumn("RaRuralPrivateBags", typeof(int));

        public DataColumn RaPrivateBags = new DataColumn("RaPrivateBags", typeof(int));

        public DataColumn RaClosedMails = new DataColumn("RaClosedMails", typeof(int));

        public DataColumn RaPostShops = new DataColumn("RaPostShops", typeof(int));

        public DataColumn RaPostCentres = new DataColumn("RaPostCentres", typeof(int));

        public DataColumn RaNoCmbs = new DataColumn("RaNoCmbs", typeof(int));

        public DataColumn RaNoCmbCusts = new DataColumn("RaNoCmbCusts", typeof(int));

        public DataColumn RaTotalDelPoints = new DataColumn("RaTotalDelPoints", typeof(int));

        public DataColumn RaSortingFacilities = new DataColumn("RaSortingFacilities", typeof(string));

        public DataColumn RaSortingCase = new DataColumn("RaSortingCase", typeof(string));

        public DataColumn RaSortingComments = new DataColumn("RaSortingComments", typeof(string));

        public DataColumn RaLengthSealed = new DataColumn("RaLengthSealed", typeof(decimal));

        public DataColumn RaLenthUnsealed = new DataColumn("RaLenthUnsealed", typeof(decimal));

        public DataColumn RaTotalLength = new DataColumn("RaTotalLength", typeof(decimal));

        public DataColumn RaRoadConditions = new DataColumn("RaRoadConditions", typeof(string));

        public DataColumn RaSuggestedImprovements = new DataColumn("RaSuggestedImprovements", typeof(string));

        public DataColumn RaCommencementOk = new DataColumn("RaCommencementOk", typeof(string));

        public DataColumn RaCommencementReason = new DataColumn("RaCommencementReason", typeof(string));

        public DataColumn RaTimetableChange = new DataColumn("RaTimetableChange", typeof(string));

        public DataColumn RaRouteOk = new DataColumn("RaRouteOk", typeof(string));

        public DataColumn RaRouteReason = new DataColumn("RaRouteReason", typeof(string));

        public DataColumn RaDeviations = new DataColumn("RaDeviations", typeof(string));

        public DataColumn RaDeviationInDesc = new DataColumn("RaDeviationInDesc", typeof(string));

        public DataColumn RaDeviationReason = new DataColumn("RaDeviationReason", typeof(string));

        public DataColumn RaDescriptionUotdated = new DataColumn("RaDescriptionUotdated", typeof(string));

        public DataColumn RaSaftyAccessAddresses = new DataColumn("RaSaftyAccessAddresses", typeof(string));

        public DataColumn RaSaftyAccessResolvedDate = new DataColumn("RaSaftyAccessResolvedDate", typeof(DateTime));

        public DataColumn RaSafteyAccessActions = new DataColumn("RaSafteyAccessActions", typeof(string));

        public DataColumn RaSaftyPlanCompleted = new DataColumn("RaSaftyPlanCompleted", typeof(string));

        public DataColumn RaSaftyPlanCompletedDate = new DataColumn("RaSaftyPlanCompletedDate", typeof(DateTime));

        public DataColumn RaSaftyPlanActions = new DataColumn("RaSaftyPlanActions", typeof(string));

        public DataColumn RaSaftyPracticesExists = new DataColumn("RaSaftyPracticesExists", typeof(string));

        public DataColumn RaSaftyPracticesResolvedDate = new DataColumn("RaSaftyPracticesResolvedDate", typeof(DateTime));

        public DataColumn RaSaftyPracticesActions = new DataColumn("RaSaftyPracticesActions", typeof(string));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(decimal));

        public DataColumn Compute2 = new DataColumn("Compute2", typeof(decimal));

        public DataColumn Compute3 = new DataColumn("Compute3", typeof(decimal));

        public DataColumn Compute4 = new DataColumn("Compute4", typeof(decimal));


        public RouteAuditDePrintBlankDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,RaDateOfCheck,RaTimeStartedSort,RaTimeFinishedSort,RaTimeReturned,RaTimeDeparted,RaTotalHours,RaMealBreaks,RaExtraTime,RaFinalHours,RaFinishOdometer,RaStartOdometer,RaExtraDistance,RaOthrGdsBefore,RaOthrGdsDuring,RaOthrGdsAfter,RaPrBefore,RaPrDuring,RaPrAfter,RaTotalDistance,RaFinalDistance,RaFrequency,RaContractor,RaEmployee,RaVehicleMake,RaVehicleModel,RaYear,RaRegistrationNo,RaFuel,RaCcRating,RaCondition,RaRecReplace,RaTyreSize,RaGdsService,RaGdsServiceSighted,RaMvInsurance,RaCrInsurance,RaPlInsurance,RaInsuranceSighted,RaNewVehicle,RaVehiclePrice,RaVehiclePurchased,RaMailVolume,RaMvComments,RaAdpostVolume,RaNoCircularDrops,RaCourierpostVolume,RaCpComments,RaNoRegCusts,RaNoRegCustsCoreProds,RaOtherCusts,RaRuralPrivateBags,RaPrivateBags,RaClosedMails,RaPostShops,RaPostCentres,RaNoCmbs,RaNoCmbCusts,RaTotalDelPoints,RaSortingFacilities,RaSortingCase,RaSortingComments,RaLengthSealed,RaLenthUnsealed,RaTotalLength,RaRoadConditions,RaSuggestedImprovements,RaCommencementOk,RaCommencementReason,RaTimetableChange,RaRouteOk,RaRouteReason,RaDeviations,RaDeviationInDesc,RaDeviationReason,RaDescriptionUotdated,RaSaftyAccessAddresses,RaSaftyAccessResolvedDate,RaSafteyAccessActions,RaSaftyPlanCompleted,RaSaftyPlanCompletedDate,RaSaftyPlanActions,RaSaftyPracticesExists,RaSaftyPracticesResolvedDate,RaSaftyPracticesActions,Compute1,Compute2,Compute3,Compute4
				});
            ContractNo.AllowDBNull = true;
            RaDateOfCheck.AllowDBNull = true;
            RaTimeStartedSort.AllowDBNull = true;
            RaTimeFinishedSort.AllowDBNull = true;
            RaTimeReturned.AllowDBNull = true;
            RaTimeDeparted.AllowDBNull = true;
            RaTotalHours.AllowDBNull = true;
            RaMealBreaks.AllowDBNull = true;
            RaExtraTime.AllowDBNull = true;
            RaFinalHours.AllowDBNull = true;
            RaFinishOdometer.AllowDBNull = true;
            RaStartOdometer.AllowDBNull = true;
            RaExtraDistance.AllowDBNull = true;
            RaOthrGdsBefore.AllowDBNull = true;
            RaOthrGdsDuring.AllowDBNull = true;
            RaOthrGdsAfter.AllowDBNull = true;
            RaPrBefore.AllowDBNull = true;
            RaPrDuring.AllowDBNull = true;
            RaPrAfter.AllowDBNull = true;
            RaTotalDistance.AllowDBNull = true;
            RaFinalDistance.AllowDBNull = true;
            RaYear.AllowDBNull = true;
            RaCcRating.AllowDBNull = true;
            RaRecReplace.AllowDBNull = true;
            RaVehiclePrice.AllowDBNull = true;
            RaVehiclePurchased.AllowDBNull = true;
            RaNoCircularDrops.AllowDBNull = true;
            RaNoRegCusts.AllowDBNull = true;
            RaNoRegCustsCoreProds.AllowDBNull = true;
            RaOtherCusts.AllowDBNull = true;
            RaRuralPrivateBags.AllowDBNull = true;
            RaPrivateBags.AllowDBNull = true;
            RaClosedMails.AllowDBNull = true;
            RaPostShops.AllowDBNull = true;
            RaPostCentres.AllowDBNull = true;
            RaNoCmbs.AllowDBNull = true;
            RaNoCmbCusts.AllowDBNull = true;
            RaTotalDelPoints.AllowDBNull = true;
            RaLengthSealed.AllowDBNull = true;
            RaLenthUnsealed.AllowDBNull = true;
            RaTotalLength.AllowDBNull = true;
            RaSaftyAccessResolvedDate.AllowDBNull = true;
            RaSaftyPlanCompletedDate.AllowDBNull = true;
            RaSaftyPracticesResolvedDate.AllowDBNull = true;
            Compute1.AllowDBNull = true;
            Compute2.AllowDBNull = true;
            Compute3.AllowDBNull = true;
            Compute4.AllowDBNull = true;

        }

        public RouteAuditDePrintBlankDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<RouteAuditDePrintBlank> datas = dataSource as Metex.Core.EntityBindingList<RouteAuditDePrintBlank>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(RouteAuditDePrintBlank data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["RaDateOfCheck"] = GetFieldValue(data.RaDateOfCheck);
            row["RaTimeStartedSort"] = GetFieldValue(data.RaTimeStartedSort);
            row["RaTimeFinishedSort"] = GetFieldValue(data.RaTimeFinishedSort);
            row["RaTimeReturned"] = GetFieldValue(data.RaTimeReturned);
            row["RaTimeDeparted"] = GetFieldValue(data.RaTimeDeparted);
            row["RaTotalHours"] = GetFieldValue(data.RaTotalHours);
            row["RaMealBreaks"] = GetFieldValue(data.RaMealBreaks);
            row["RaExtraTime"] = GetFieldValue(data.RaExtraTime);
            row["RaFinalHours"] = GetFieldValue(data.RaFinalHours);
            row["RaFinishOdometer"] = GetFieldValue(data.RaFinishOdometer);
            row["RaStartOdometer"] = GetFieldValue(data.RaStartOdometer);
            row["RaExtraDistance"] = GetFieldValue(data.RaExtraDistance);
            row["RaOthrGdsBefore"] = GetFieldValue(data.RaOthrGdsBefore);
            row["RaOthrGdsDuring"] = GetFieldValue(data.RaOthrGdsDuring);
            row["RaOthrGdsAfter"] = GetFieldValue(data.RaOthrGdsAfter);
            row["RaPrBefore"] = GetFieldValue(data.RaPrBefore);
            row["RaPrDuring"] = GetFieldValue(data.RaPrDuring);
            row["RaPrAfter"] = GetFieldValue(data.RaPrAfter);
            row["RaTotalDistance"] = GetFieldValue(data.RaTotalDistance);
            row["RaFinalDistance"] = GetFieldValue(data.RaFinalDistance);
            row["RaFrequency"] = GetFieldValue(data.RaFrequency);
            row["RaContractor"] = GetFieldValue(data.RaContractor);
            row["RaEmployee"] = GetFieldValue(data.RaEmployee);
            row["RaVehicleMake"] = GetFieldValue(data.RaVehicleMake);
            row["RaVehicleModel"] = GetFieldValue(data.RaVehicleModel);
            row["RaYear"] = GetFieldValue(data.RaYear);
            row["RaRegistrationNo"] = GetFieldValue(data.RaRegistrationNo);
            row["RaFuel"] = GetFieldValue(data.RaFuel);
            row["RaCcRating"] = GetFieldValue(data.RaCcRating);
            row["RaCondition"] = GetFieldValue(data.RaCondition);
            row["RaRecReplace"] = GetFieldValue(data.RaRecReplace);
            row["RaTyreSize"] = GetFieldValue(data.RaTyreSize);
            row["RaGdsService"] = GetFieldValue(data.RaGdsService);
            row["RaGdsServiceSighted"] = GetFieldValue(data.RaGdsServiceSighted);
            row["RaMvInsurance"] = GetFieldValue(data.RaMvInsurance);
            row["RaCrInsurance"] = GetFieldValue(data.RaCrInsurance);
            row["RaPlInsurance"] = GetFieldValue(data.RaPlInsurance);
            row["RaInsuranceSighted"] = GetFieldValue(data.RaInsuranceSighted);
            row["RaNewVehicle"] = GetFieldValue(data.RaNewVehicle);
            row["RaVehiclePrice"] = GetFieldValue(data.RaVehiclePrice);
            row["RaVehiclePurchased"] = GetFieldValue(data.RaVehiclePurchased);
            row["RaMailVolume"] = GetFieldValue(data.RaMailVolume);
            row["RaMvComments"] = GetFieldValue(data.RaMvComments);
            row["RaAdpostVolume"] = GetFieldValue(data.RaAdpostVolume);
            row["RaNoCircularDrops"] = GetFieldValue(data.RaNoCircularDrops);
            row["RaCourierpostVolume"] = GetFieldValue(data.RaCourierpostVolume);
            row["RaCpComments"] = GetFieldValue(data.RaCpComments);
            row["RaNoRegCusts"] = GetFieldValue(data.RaNoRegCusts);
            row["RaNoRegCustsCoreProds"] = GetFieldValue(data.RaNoRegCustsCoreProds);
            row["RaOtherCusts"] = GetFieldValue(data.RaOtherCusts);
            row["RaRuralPrivateBags"] = GetFieldValue(data.RaRuralPrivateBags);
            row["RaPrivateBags"] = GetFieldValue(data.RaPrivateBags);
            row["RaClosedMails"] = GetFieldValue(data.RaClosedMails);
            row["RaPostShops"] = GetFieldValue(data.RaPostShops);
            row["RaPostCentres"] = GetFieldValue(data.RaPostCentres);
            row["RaNoCmbs"] = GetFieldValue(data.RaNoCmbs);
            row["RaNoCmbCusts"] = GetFieldValue(data.RaNoCmbCusts);
            row["RaTotalDelPoints"] = GetFieldValue(data.RaTotalDelPoints);
            row["RaSortingFacilities"] = GetFieldValue(data.RaSortingFacilities);
            row["RaSortingCase"] = GetFieldValue(data.RaSortingCase);
            row["RaSortingComments"] = GetFieldValue(data.RaSortingComments);
            row["RaLengthSealed"] = GetFieldValue(data.RaLengthSealed);
            row["RaLenthUnsealed"] = GetFieldValue(data.RaLenthUnsealed);
            row["RaTotalLength"] = GetFieldValue(data.RaTotalLength);
            row["RaRoadConditions"] = GetFieldValue(data.RaRoadConditions);
            row["RaSuggestedImprovements"] = GetFieldValue(data.RaSuggestedImprovements);
            row["RaCommencementOk"] = GetFieldValue(data.RaCommencementOk);
            row["RaCommencementReason"] = GetFieldValue(data.RaCommencementReason);
            row["RaTimetableChange"] = GetFieldValue(data.RaTimetableChange);
            row["RaRouteOk"] = GetFieldValue(data.RaRouteOk);
            row["RaRouteReason"] = GetFieldValue(data.RaRouteReason);
            row["RaDeviations"] = GetFieldValue(data.RaDeviations);
            row["RaDeviationInDesc"] = GetFieldValue(data.RaDeviationInDesc);
            row["RaDeviationReason"] = GetFieldValue(data.RaDeviationReason);
            row["RaDescriptionUotdated"] = GetFieldValue(data.RaDescriptionUotdated);
            row["RaSaftyAccessAddresses"] = GetFieldValue(data.RaSaftyAccessAddresses);
            row["RaSaftyAccessResolvedDate"] = GetFieldValue(data.RaSaftyAccessResolvedDate);
            row["RaSafteyAccessActions"] = GetFieldValue(data.RaSafteyAccessActions);
            row["RaSaftyPlanCompleted"] = GetFieldValue(data.RaSaftyPlanCompleted);
            row["RaSaftyPlanCompletedDate"] = GetFieldValue(data.RaSaftyPlanCompletedDate);
            row["RaSaftyPlanActions"] = GetFieldValue(data.RaSaftyPlanActions);
            row["RaSaftyPracticesExists"] = GetFieldValue(data.RaSaftyPracticesExists);
            row["RaSaftyPracticesResolvedDate"] = GetFieldValue(data.RaSaftyPracticesResolvedDate);
            row["RaSaftyPracticesActions"] = GetFieldValue(data.RaSaftyPracticesActions);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["Compute2"] = GetFieldValue(data.Compute2);
            row["Compute3"] = GetFieldValue(data.Compute3);
            row["Compute4"] = GetFieldValue(data.Compute4);
            return row;
        }
    }
}
