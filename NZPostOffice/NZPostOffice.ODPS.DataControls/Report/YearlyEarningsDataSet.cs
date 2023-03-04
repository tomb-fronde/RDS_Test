using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RYearlyEarnings
    {
        public string Region
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string CSurnameCompany
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
        public decimal Grossearnings
        {
            get
            {
                return 0;
            }
        }
        public decimal Withholdingtax
        {
            get
            {
                return 0;
            }
        }
        public decimal Gst
        {
            get
            {
                return 0;
            }
        }
    }
    public class YearlyEarningsDataSet : ReportDataSet<YearlyEarnings>
    {

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CIrdNo = new DataColumn("CIrdNo", typeof(string));

        public DataColumn Grossearnings = new DataColumn("Grossearnings", typeof(decimal));

        public DataColumn Withholdingtax = new DataColumn("Withholdingtax", typeof(decimal));

        public DataColumn Gst = new DataColumn("Gst", typeof(decimal));


        public YearlyEarningsDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Region,ContractNo,CSurnameCompany,CIrdNo,Grossearnings,Withholdingtax,Gst
				});
            ContractNo.AllowDBNull = true;
            Grossearnings.AllowDBNull = true;
            Withholdingtax.AllowDBNull = true;
            Gst.AllowDBNull = true;

        }

        public YearlyEarningsDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<YearlyEarnings> datas = dataSource as Metex.Core.EntityBindingList<YearlyEarnings>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(YearlyEarnings data)
        {
            DataRow row = this.NewRow();
            row["Region"] = GetFieldValue(data.Region);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CIrdNo"] = GetFieldValue(data.CIrdNo);
            row["Grossearnings"] = GetFieldValue(data.Grossearnings);
            row["Withholdingtax"] = GetFieldValue(data.Withholdingtax);
            row["Gst"] = GetFieldValue(data.Gst);
            return row;
        }
    }
}
