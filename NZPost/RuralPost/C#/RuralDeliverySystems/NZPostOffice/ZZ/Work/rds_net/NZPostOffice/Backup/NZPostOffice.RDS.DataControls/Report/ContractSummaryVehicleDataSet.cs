using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryVehicle
    {
        public string Make
        {
            get
            {
                return string.Empty;
            }
        }
        public string Model
        {
            get
            {
                return string.Empty;
            }
        }
        public int Modelyear
        {
            get
            {
                return 0;
            }
        }
        public int Odometer
        {
            get
            {
                return 0;
            }
        }
        public int CcRating
        {
            get
            {
                return 0;
            }
        }
        public string RegNumber
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime DatePurchased
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string Ruc
        {
            get
            {
                return string.Empty;
            }
        }
        public int PurchaseValue
        {
            get
            {
                return 0;
            }
        }
        public string FtDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string VtDescription
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class ContractSummaryVehicleDataSet : ReportDataSet<ContractSummaryVehicle>
    {

        public DataColumn Make = new DataColumn("Make", typeof(string));

        public DataColumn Model = new DataColumn("Model", typeof(string));

        public DataColumn Modelyear = new DataColumn("Modelyear", typeof(int));

        public DataColumn Odometer = new DataColumn("Odometer", typeof(int));

        public DataColumn CcRating = new DataColumn("CcRating", typeof(int));

        public DataColumn RegNumber = new DataColumn("RegNumber", typeof(string));

        public DataColumn DatePurchased = new DataColumn("DatePurchased", typeof(DateTime));

        public DataColumn Ruc = new DataColumn("Ruc", typeof(string));

        public DataColumn PurchaseValue = new DataColumn("PurchaseValue", typeof(int));

        public DataColumn FtDescription = new DataColumn("FtDescription", typeof(string));

        public DataColumn VtDescription = new DataColumn("VtDescription", typeof(string));


        public ContractSummaryVehicleDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Make,Model,Modelyear,Odometer,CcRating,RegNumber,DatePurchased,Ruc,PurchaseValue,FtDescription,VtDescription
				});
            Modelyear.AllowDBNull = true;
            Odometer.AllowDBNull = true;
            CcRating.AllowDBNull = true;
            DatePurchased.AllowDBNull = true;
            PurchaseValue.AllowDBNull = true;

        }

        public ContractSummaryVehicleDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryVehicle> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryVehicle>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryVehicleDataSet(ContractSummaryVehicle obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryVehicle> list = new Metex.Core.EntityBindingList<ContractSummaryVehicle>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryVehicleDataSet(ContractSummaryVehicle[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryVehicle> list = new Metex.Core.EntityBindingList<ContractSummaryVehicle>();
            foreach (ContractSummaryVehicle d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryVehicle data)
        {
            DataRow row = this.NewRow();
            row["Make"] = GetFieldValue(data.Make);
            row["Model"] = GetFieldValue(data.Model);
            row["Modelyear"] = GetFieldValue(data.Modelyear);
            row["Odometer"] = GetFieldValue(data.Odometer);
            row["CcRating"] = GetFieldValue(data.CcRating);
            row["RegNumber"] = GetFieldValue(data.RegNumber);
            row["DatePurchased"] = GetFieldValue(data.DatePurchased);
            row["Ruc"] = GetFieldValue(data.Ruc);
            row["PurchaseValue"] = GetFieldValue(data.PurchaseValue);
            row["FtDescription"] = GetFieldValue(data.FtDescription);
            row["VtDescription"] = GetFieldValue(data.VtDescription);
            return row;
        }
    }
}
