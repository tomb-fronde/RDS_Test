using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehicleScheduleSingleContractv2
    {
        public int ContractContractNo
        {
            get
            {
                return 0;
            }
        }
        public string ContractConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOName
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCFirstNames
        {
            get
            {
                return string.Empty;
            }
        }
        public int VehicleVehicleNumber
        {
            get
            {
                return 0;
            }
        }
        public int VehicleVVehicleYear
        {
            get
            {
                return 0;
            }
        }
        public string VehicleStyleVsDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string VehicleVVehicleModel
        {
            get
            {
                return string.Empty;
            }
        }
        public int VehicleVVehicleCcRating
        {
            get
            {
                return 0;
            }
        }
        public string CvVehicleTransmission
        {
            get
            {
                return string.Empty;
            }
        }
        public string VehicleVVehicleRegistrationNumber
        {
            get
            {
                return string.Empty;
            }
        }
        public int VehicleVPurchaseValue
        {
            get
            {
                return 0;
            }
        }
        public DateTime VehicleVPurchasedDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string ContractConRdRefText
        {
            get
            {
                return string.Empty;
            }
        }
        public string VehicleVVehicleMake
        {
            get
            {
                return string.Empty;
            }
        }
        public string FuelTypeFtDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractVehicalStartKms
        {
            get
            {
                return 0;
            }
        }
        public DateTime ContractRenewalsConStartDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int VehicleVVehicleMonth
        {
            get
            {
                return 0;
            }
        }
    }
    public class VehicleScheduleSingleContractv2DataSet : ReportDataSet<VehicleScheduleSingleContractv2>
    {

        public DataColumn ContractContractNo = new DataColumn("ContractContractNo", typeof(int));

        public DataColumn ContractConTitle = new DataColumn("ContractConTitle", typeof(string));

        public DataColumn RegionRgnName = new DataColumn("RegionRgnName", typeof(string));

        public DataColumn OutletOName = new DataColumn("OutletOName", typeof(string));

        public DataColumn ContractorCSurnameCompany = new DataColumn("ContractorCSurnameCompany", typeof(string));

        public DataColumn ContractorCFirstNames = new DataColumn("ContractorCFirstNames", typeof(string));

        public DataColumn VehicleVehicleNumber = new DataColumn("VehicleVehicleNumber", typeof(int));

        public DataColumn VehicleVVehicleYear = new DataColumn("VehicleVVehicleYear", typeof(int));

        public DataColumn VehicleStyleVsDescription = new DataColumn("VehicleStyleVsDescription", typeof(string));

        public DataColumn VehicleVVehicleModel = new DataColumn("VehicleVVehicleModel", typeof(string));

        public DataColumn VehicleVVehicleCcRating = new DataColumn("VehicleVVehicleCcRating", typeof(int));

        public DataColumn CvVehicleTransmission = new DataColumn("CvVehicleTransmission", typeof(string));

        public DataColumn VehicleVVehicleRegistrationNumber = new DataColumn("VehicleVVehicleRegistrationNumber", typeof(string));

        public DataColumn VehicleVPurchaseValue = new DataColumn("VehicleVPurchaseValue", typeof(int));

        public DataColumn VehicleVPurchasedDate = new DataColumn("VehicleVPurchasedDate", typeof(DateTime));

        public DataColumn ContractConRdRefText = new DataColumn("ContractConRdRefText", typeof(string));

        public DataColumn VehicleVVehicleMake = new DataColumn("VehicleVVehicleMake", typeof(string));

        public DataColumn FuelTypeFtDescription = new DataColumn("FuelTypeFtDescription", typeof(string));

        public DataColumn ContractorCInitials = new DataColumn("ContractorCInitials", typeof(string));

        public DataColumn ContractVehicalStartKms = new DataColumn("ContractVehicalStartKms", typeof(int));

        public DataColumn ContractRenewalsConStartDate = new DataColumn("ContractRenewalsConStartDate", typeof(DateTime));

        public DataColumn VehicleVVehicleMonth = new DataColumn("VehicleVVehicleMonth", typeof(int));


        public VehicleScheduleSingleContractv2DataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractContractNo,ContractConTitle,RegionRgnName,OutletOName,ContractorCSurnameCompany,ContractorCFirstNames,VehicleVehicleNumber,VehicleVVehicleYear,VehicleStyleVsDescription,VehicleVVehicleModel,VehicleVVehicleCcRating,CvVehicleTransmission,VehicleVVehicleRegistrationNumber,VehicleVPurchaseValue,VehicleVPurchasedDate,ContractConRdRefText,VehicleVVehicleMake,FuelTypeFtDescription,ContractorCInitials,ContractVehicalStartKms,ContractRenewalsConStartDate,VehicleVVehicleMonth
				});
            ContractContractNo.AllowDBNull = true;
            VehicleVehicleNumber.AllowDBNull = true;
            VehicleVVehicleYear.AllowDBNull = true;
            VehicleVVehicleCcRating.AllowDBNull = true;
            VehicleVPurchaseValue.AllowDBNull = true;
            VehicleVPurchasedDate.AllowDBNull = true;
            ContractVehicalStartKms.AllowDBNull = true;
            ContractRenewalsConStartDate.AllowDBNull = true;
            VehicleVVehicleMonth.AllowDBNull = true;

        }

        public VehicleScheduleSingleContractv2DataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehicleScheduleSingleContractv2> datas = dataSource as Metex.Core.EntityBindingList<VehicleScheduleSingleContractv2>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VehicleScheduleSingleContractv2 data)
        {
            DataRow row = this.NewRow();
            row["ContractContractNo"] = GetFieldValue(data.ContractContractNo);
            row["ContractConTitle"] = GetFieldValue(data.ContractConTitle);
            row["RegionRgnName"] = GetFieldValue(data.RegionRgnName);
            row["OutletOName"] = GetFieldValue(data.OutletOName);
            row["ContractorCSurnameCompany"] = GetFieldValue(data.ContractorCSurnameCompany);
            row["ContractorCFirstNames"] = GetFieldValue(data.ContractorCFirstNames);
            row["VehicleVehicleNumber"] = GetFieldValue(data.VehicleVehicleNumber);
            row["VehicleVVehicleYear"] = GetFieldValue(data.VehicleVVehicleYear);
            row["VehicleStyleVsDescription"] = GetFieldValue(data.VehicleStyleVsDescription);
            row["VehicleVVehicleModel"] = GetFieldValue(data.VehicleVVehicleModel);
            row["VehicleVVehicleCcRating"] = GetFieldValue(data.VehicleVVehicleCcRating);
            row["CvVehicleTransmission"] = GetFieldValue(data.CvVehicleTransmission);
            row["VehicleVVehicleRegistrationNumber"] = GetFieldValue(data.VehicleVVehicleRegistrationNumber);
            row["VehicleVPurchaseValue"] = GetFieldValue(data.VehicleVPurchaseValue);
            row["VehicleVPurchasedDate"] = GetFieldValue(data.VehicleVPurchasedDate);
            row["ContractConRdRefText"] = GetFieldValue(data.ContractConRdRefText);
            row["VehicleVVehicleMake"] = GetFieldValue(data.VehicleVVehicleMake);
            row["FuelTypeFtDescription"] = GetFieldValue(data.FuelTypeFtDescription);
            row["ContractorCInitials"] = GetFieldValue(data.ContractorCInitials);
            row["ContractVehicalStartKms"] = GetFieldValue(data.ContractVehicalStartKms);
            row["ContractRenewalsConStartDate"] = GetFieldValue(data.ContractRenewalsConStartDate);
            row["VehicleVVehicleMonth"] = GetFieldValue(data.VehicleVVehicleMonth);
            return row;
        }
    }
}
