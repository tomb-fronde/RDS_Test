using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehExpRenewReport
    {
        public DateTime Expiry
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int ConNum
        {
            get
            {
                return 0;
            }
        }
        public string Rego
        {
            get
            {
                return string.Empty;
            }
        }
        public string Vmake
        {
            get
            {
                return string.Empty;
            }
        }
        public string Vmodel
        {
            get
            {
                return string.Empty;
            }
        }
        public int Vyear
        {
            get
            {
                return 0;
            }
        }
        public string Vdesc
        {
            get
            {
                return string.Empty;
            }
        }
        public string Vfuel
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegName
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime Month6
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class VehExpRenewReportDataSet : ReportDataSet<VehExpRenewReport>
    {

        public DataColumn Expiry = new DataColumn("Expiry", typeof(DateTime));

        public DataColumn ConNum = new DataColumn("ConNum", typeof(int));

        public DataColumn Rego = new DataColumn("Rego", typeof(string));

        public DataColumn Vmake = new DataColumn("Vmake", typeof(string));

        public DataColumn Vmodel = new DataColumn("Vmodel", typeof(string));

        public DataColumn Vyear = new DataColumn("Vyear", typeof(int));

        public DataColumn Vdesc = new DataColumn("Vdesc", typeof(string));

        public DataColumn Vfuel = new DataColumn("Vfuel", typeof(string));

        public DataColumn RegName = new DataColumn("RegName", typeof(string));

        public DataColumn Month6 = new DataColumn("Month6", typeof(DateTime));


        public VehExpRenewReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Expiry,ConNum,Rego,Vmake,Vmodel,Vyear,Vdesc,Vfuel,RegName,Month6
				});
            Expiry.AllowDBNull = true;
            ConNum.AllowDBNull = true;
            Vyear.AllowDBNull = true;
            Month6.AllowDBNull = true;

        }

        public VehExpRenewReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehExpRenewReport> datas = dataSource as Metex.Core.EntityBindingList<VehExpRenewReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VehExpRenewReport data)
        {
            DataRow row = this.NewRow();
            row["Expiry"] = GetFieldValue(data.Expiry);
            row["ConNum"] = GetFieldValue(data.ConNum);
            row["Rego"] = GetFieldValue(data.Rego);
            row["Vmake"] = GetFieldValue(data.Vmake);
            row["Vmodel"] = GetFieldValue(data.Vmodel);
            row["Vyear"] = GetFieldValue(data.Vyear);
            row["Vdesc"] = GetFieldValue(data.Vdesc);
            row["Vfuel"] = GetFieldValue(data.Vfuel);
            row["RegName"] = GetFieldValue(data.RegName);
            row["Month6"] = GetFieldValue(data.Month6);
            return row;
        }
    }
}
