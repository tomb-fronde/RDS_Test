using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RIr66es
    {
        public string CSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string CFirstNames
        {
            get
            {
                return string.Empty;
            }
        }
        public string CInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime Startdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REStartdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime Enddate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REEnddate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string Taxcategory
        {
            get
            {
                return string.Empty;
            }
        }
        public string CIrdNo
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class Ir66esDataSet : ReportDataSet<Ir66es>
    {

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn Startdate = new DataColumn("Startdate", typeof(DateTime));

        public DataColumn REStartdate = new DataColumn("REStartdate", typeof(DateTime));

        public DataColumn Enddate = new DataColumn("Enddate", typeof(DateTime));

        public DataColumn REEnddate = new DataColumn("REEnddate", typeof(DateTime));

        public DataColumn Taxcategory = new DataColumn("Taxcategory", typeof(string));

        public DataColumn CIrdNo = new DataColumn("CIrdNo", typeof(string));


        public Ir66esDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CSurnameCompany,CFirstNames,CInitials,Startdate,REStartdate,Enddate,REEnddate,Taxcategory,CIrdNo
				});
            Startdate.AllowDBNull = true;
            Enddate.AllowDBNull = true;

        }

        public Ir66esDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Ir66es> datas = dataSource as Metex.Core.EntityBindingList<Ir66es>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Ir66es data)
        {
            DataRow row = this.NewRow();
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["Startdate"] = GetFieldValue(data.Startdate);
            row["REStartdate"] = GetFieldValue(data.REStartdate);
            row["Enddate"] = GetFieldValue(data.Enddate);
            row["REEnddate"] = GetFieldValue(data.REEnddate);
            row["Taxcategory"] = GetFieldValue(data.Taxcategory);
            row["CIrdNo"] = GetFieldValue(data.CIrdNo);
            return row;
        }
    }
}
