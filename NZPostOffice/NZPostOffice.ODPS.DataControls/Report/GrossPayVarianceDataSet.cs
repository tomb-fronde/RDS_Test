using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.ODPS.Entity.OdpsRep;
using System.Data;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RGrossPayVariance
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int REContractNo
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
        public decimal Lastmonth
        {
            get
            {
                return 0;
            }
        }
        public decimal RELastmonth
        {
            get
            {
                return 0;
            }
        }
        public decimal Thismonth
        {
            get
            {
                return 0;
            }
        }
        public decimal REThismonth
        {
            get
            {
                return 0;
            }
        }
        public int Wrate
        {
            get
            {
                return 0;
            }
        }
        public int REWrate
        {
            get
            {
                return 0;
            }
        }
    }
    public class GrossPayVarianceDataSet : ReportDataSet<Grosspayvariance>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn Lastmonth = new DataColumn("Lastmonth", typeof(decimal));

        public DataColumn RELastmonth = new DataColumn("RELastmonth", typeof(decimal));

        public DataColumn Thismonth = new DataColumn("Thismonth", typeof(decimal));

        public DataColumn REThismonth = new DataColumn("REThismonth", typeof(decimal));

        public DataColumn Wrate = new DataColumn("Wrate", typeof(int));

        public DataColumn REWrate = new DataColumn("REWrate", typeof(int));


        public GrossPayVarianceDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,CSurnameCompany,CFirstNames,CInitials,Lastmonth,RELastmonth,Thismonth,REThismonth,Wrate,REWrate
				});
            ContractNo.AllowDBNull = true;
            Lastmonth.AllowDBNull = true;
            Thismonth.AllowDBNull = true;
            Wrate.AllowDBNull = true;
        }

        public GrossPayVarianceDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Grosspayvariance> datas = dataSource as Metex.Core.EntityBindingList<Grosspayvariance>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Grosspayvariance data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["Lastmonth"] = GetFieldValue(data.Lastmonth);
            row["RELastmonth"] = GetFieldValue(data.RELastmonth);
            row["Thismonth"] = GetFieldValue(data.Thismonth);
            row["REThismonth"] = GetFieldValue(data.REThismonth);
            row["Wrate"] = GetFieldValue(data.Wrate);
            row["REWrate"] = GetFieldValue(data.REWrate);
            return row;
        }
    }
}
