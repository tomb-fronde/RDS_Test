using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehicleAgedetails
    {
        public int StartKms
        {
            get
            {
                return 0;
            }
        }
        public string VVehicleMake
        {
            get
            {
                return string.Empty;
            }
        }
        public string VVehicleModel
        {
            get
            {
                return string.Empty;
            }
        }
        public int VVehicleYear
        {
            get
            {
                return 0;
            }
        }
        public string VVehicleRegistrationNumber
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime VPurchasedDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int ContractSeqNumber
        {
            get
            {
                return 0;
            }
        }
        public int VehicleNumber
        {
            get
            {
                return 0;
            }
        }
        public string CvVehicalStatus
        {
            get
            {
                return string.Empty;
            }
        }
        public string Purchasestatus
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime ConExpiryDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal ConDistanceAtRenewal
        {
            get
            {
                return 0;
            }
        }
        public DateTime ConStartDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class VehicleAgedetailsDataSet : ReportDataSet<VehicleAgedetails>
    {

        public DataColumn StartKms = new DataColumn("StartKms", typeof(int));

        public DataColumn VVehicleMake = new DataColumn("VVehicleMake", typeof(string));

        public DataColumn VVehicleModel = new DataColumn("VVehicleModel", typeof(string));

        public DataColumn VVehicleYear = new DataColumn("VVehicleYear", typeof(int));

        public DataColumn VVehicleRegistrationNumber = new DataColumn("VVehicleRegistrationNumber", typeof(string));

        public DataColumn VPurchasedDate = new DataColumn("VPurchasedDate", typeof(DateTime));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn VehicleNumber = new DataColumn("VehicleNumber", typeof(int));

        public DataColumn CvVehicalStatus = new DataColumn("CvVehicalStatus", typeof(string));

        public DataColumn Purchasestatus = new DataColumn("Purchasestatus", typeof(string));

        public DataColumn ConExpiryDate = new DataColumn("ConExpiryDate", typeof(DateTime));

        public DataColumn ConDistanceAtRenewal = new DataColumn("ConDistanceAtRenewal", typeof(decimal));

        public DataColumn ConStartDate = new DataColumn("ConStartDate", typeof(DateTime));


        public VehicleAgedetailsDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				StartKms,VVehicleMake,VVehicleModel,VVehicleYear,VVehicleRegistrationNumber,VPurchasedDate,ContractNo,ContractSeqNumber,VehicleNumber,CvVehicalStatus,Purchasestatus,ConExpiryDate,ConDistanceAtRenewal,ConStartDate
				});
            StartKms.AllowDBNull = true;
            VVehicleYear.AllowDBNull = true;
            VPurchasedDate.AllowDBNull = true;
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            VehicleNumber.AllowDBNull = true;
            ConExpiryDate.AllowDBNull = true;
            ConDistanceAtRenewal.AllowDBNull = true;
            ConStartDate.AllowDBNull = true;

        }

        public VehicleAgedetailsDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehicleAgedetails> datas = dataSource as Metex.Core.EntityBindingList<VehicleAgedetails>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public VehicleAgedetailsDataSet(VehicleAgedetails obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<VehicleAgedetails> list = new Metex.Core.EntityBindingList<VehicleAgedetails>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public VehicleAgedetailsDataSet(VehicleAgedetails[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<VehicleAgedetails> list = new Metex.Core.EntityBindingList<VehicleAgedetails>();
            foreach (VehicleAgedetails d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(VehicleAgedetails data)
        {
            DataRow row = this.NewRow();
            row["StartKms"] = GetFieldValue(data.StartKms);
            row["VVehicleMake"] = GetFieldValue(data.VVehicleMake);
            row["VVehicleModel"] = GetFieldValue(data.VVehicleModel);
            row["VVehicleYear"] = GetFieldValue(data.VVehicleYear);
            row["VVehicleRegistrationNumber"] = GetFieldValue(data.VVehicleRegistrationNumber);
            row["VPurchasedDate"] = GetFieldValue(data.VPurchasedDate);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["VehicleNumber"] = GetFieldValue(data.VehicleNumber);
            row["CvVehicalStatus"] = GetFieldValue(data.CvVehicalStatus);
            row["Purchasestatus"] = GetFieldValue(data.Purchasestatus);
            row["ConExpiryDate"] = GetFieldValue(data.ConExpiryDate);
            row["ConDistanceAtRenewal"] = GetFieldValue(data.ConDistanceAtRenewal);
            row["ConStartDate"] = GetFieldValue(data.ConStartDate);
            return row;
        }
    }
}
