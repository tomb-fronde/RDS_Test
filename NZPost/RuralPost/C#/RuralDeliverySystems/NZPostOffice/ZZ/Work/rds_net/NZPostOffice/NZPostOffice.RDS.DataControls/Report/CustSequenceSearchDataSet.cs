using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustSequenceSearch
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string Frequency
        {
            get
            {
                return string.Empty;
            }
        }
        public string Sortorder
        {
            get
            {
                return string.Empty;
            }
        }
        public bool Sortorder1
        {
            get
            {
                return false;
            }
        }
        public bool Sortorder2
        {
            get
            {
                return false;
            }
        }
        public bool Summaryreport
        {
            get
            {
                return false;
            }
        }
        public int SfKey
        {
            get
            {
                return 0;
            }
        }
        public string DeliveryDays
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqPicklist
        {
            get
            {
                return string.Empty;
            }
        }
        public int RegionIdRo
        {
            get
            {
                return 0;
            }
        }
        public string Compute1
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class CustSequenceSearchDataSet : ReportDataSet<CustSequenceSearch>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn Frequency = new DataColumn("Frequency", typeof(string));

        public DataColumn Sortorder = new DataColumn("Sortorder", typeof(string));

        public DataColumn Sortorder1 = new DataColumn("Sortorder1", typeof(bool));

        public DataColumn Sortorder2 = new DataColumn("Sortorder2", typeof(bool));

        public DataColumn Summaryreport = new DataColumn("Summaryreport", typeof(bool));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn DeliveryDays = new DataColumn("DeliveryDays", typeof(string));

        public DataColumn FreqPicklist = new DataColumn("FreqPicklist", typeof(string));

        public DataColumn RegionIdRo = new DataColumn("RegionIdRo", typeof(int));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(string));


        public CustSequenceSearchDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,Frequency,Sortorder,Sortorder1,Sortorder2,Summaryreport,SfKey,DeliveryDays,FreqPicklist,RegionIdRo,Compute1
				});
            ContractNo.AllowDBNull = true;
            Summaryreport.AllowDBNull = true;
            SfKey.AllowDBNull = true;
            RegionIdRo.AllowDBNull = true;

        }

        public CustSequenceSearchDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustSequenceSearch> datas = dataSource as Metex.Core.EntityBindingList<CustSequenceSearch>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustSequenceSearch data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["Frequency"] = GetFieldValue(data.Frequency);
            row["Sortorder"] = GetFieldValue(data.Sortorder);
            row["Sortorder1"] = GetFieldValue(data.Sortorder1);
            row["Sortorder2"] = GetFieldValue(data.Sortorder2);
            row["Summaryreport"] = GetFieldValue(data.Summaryreport);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["DeliveryDays"] = GetFieldValue(data.DeliveryDays);
            row["FreqPicklist"] = GetFieldValue(data.FreqPicklist);
            row["RegionIdRo"] = GetFieldValue(data.RegionIdRo);
            row["Compute1"] = GetFieldValue(data.Compute1);
            return row;
        }
    }
}
