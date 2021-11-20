using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustCountUnconfirmed
    {
        public string RgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OName
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
        public int REContractNo
        {
            get
            {
                return 0;
            }
        }
        public string ConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public int RECount1
        {
            get
            {
                return 0;
            }
        }
    }
    public class CustCountUnconfirmedDataSet : ReportDataSet<CustCountUnconfirmed>
    {

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn RECount1 = new DataColumn("RECount1", typeof(int));


        public CustCountUnconfirmedDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RgnName,OName,ContractNo,REContractNo,ConTitle,RECount1
				});
            ContractNo.AllowDBNull = true;

        }

        public CustCountUnconfirmedDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustCountUnconfirmed> datas = dataSource as Metex.Core.EntityBindingList<CustCountUnconfirmed>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustCountUnconfirmed data)
        {
            DataRow row = this.NewRow();
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["OName"] = GetFieldValue(data.OName);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["RECount1"] = GetFieldValue(data.RECount1);
            return row;
        }
    }
}
