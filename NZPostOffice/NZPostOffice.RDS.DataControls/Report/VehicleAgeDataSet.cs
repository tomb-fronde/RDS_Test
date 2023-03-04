using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehicleAge
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string RgnName
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
        public int VehicleNo
        {
            get
            {
                return 0;
            }
        }
        public string RgDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public int ConActiveSequence
        {
            get
            {
                return 0;
            }
        }
        public string ContractType
        {
            get
            {
                return string.Empty;
            }
        }
        public int Vage
        {
            get
            {
                return 0;
            }
        }
    }
    public class VehicleAgeDataSet : ReportDataSet<VehicleAge>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn ConExpiryDate = new DataColumn("ConExpiryDate", typeof(DateTime));

        public DataColumn ConDistanceAtRenewal = new DataColumn("ConDistanceAtRenewal", typeof(decimal));

        public DataColumn VehicleNo = new DataColumn("VehicleNo", typeof(int));

        public DataColumn RgDescription = new DataColumn("RgDescription", typeof(string));

        public DataColumn ConActiveSequence = new DataColumn("ConActiveSequence", typeof(int));

        public DataColumn ContractType = new DataColumn("ContractType", typeof(string));

        public DataColumn Vage = new DataColumn("Vage", typeof(int));


        public VehicleAgeDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,RgnName,ConExpiryDate,ConDistanceAtRenewal,VehicleNo,RgDescription,ConActiveSequence,ContractType,Vage
				});
            ContractNo.AllowDBNull = true;
            ConExpiryDate.AllowDBNull = true;
            ConDistanceAtRenewal.AllowDBNull = true;
            VehicleNo.AllowDBNull = true;
            ConActiveSequence.AllowDBNull = true;
            Vage.AllowDBNull = true;

        }

        public VehicleAgeDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehicleAge> datas = dataSource as Metex.Core.EntityBindingList<VehicleAge>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VehicleAge data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["ConExpiryDate"] = GetFieldValue(data.ConExpiryDate);
            row["ConDistanceAtRenewal"] = GetFieldValue(data.ConDistanceAtRenewal);
            row["VehicleNo"] = GetFieldValue(data.VehicleNo);
            row["RgDescription"] = GetFieldValue(data.RgDescription);
            row["ConActiveSequence"] = GetFieldValue(data.ConActiveSequence);
            row["ContractType"] = GetFieldValue(data.ContractType);
            row["Vage"] = GetFieldValue(data.Vage);
            return row;
        }
    }
}
