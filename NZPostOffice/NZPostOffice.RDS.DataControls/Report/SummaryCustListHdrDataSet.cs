using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RSummaryCustListHdr
    {
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
        public string ConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConRdRefText
        {
            get
            {
                return string.Empty;
            }
        }
        public string CTitle
        {
            get
            {
                return string.Empty;
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
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public string RgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public int SfKey
        {
            get
            {
                return 0;
            }
        }
        public string RfDeliveryDays
        {
            get
            {
                return string.Empty;
            }
        }
        public string SfDescription
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class SummaryCustListHdrDataSet : ReportDataSet<SummaryCustListHdr>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn ConRdRefText = new DataColumn("ConRdRefText", typeof(string));

        public DataColumn CTitle = new DataColumn("CTitle", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn RfDeliveryDays = new DataColumn("RfDeliveryDays", typeof(string));

        public DataColumn SfDescription = new DataColumn("SfDescription", typeof(string));


        public SummaryCustListHdrDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ContractSeqNumber,ConTitle,ConRdRefText,CTitle,CSurnameCompany,CFirstNames,CInitials,OName,RgnName,SfKey,RfDeliveryDays,SfDescription
				});
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            SfKey.AllowDBNull = true;

        }

        public SummaryCustListHdrDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<SummaryCustListHdr> datas = dataSource as Metex.Core.EntityBindingList<SummaryCustListHdr>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(SummaryCustListHdr data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["ConRdRefText"] = GetFieldValue(data.ConRdRefText);
            row["CTitle"] = GetFieldValue(data.CTitle);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["OName"] = GetFieldValue(data.OName);
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["RfDeliveryDays"] = GetFieldValue(data.RfDeliveryDays);
            row["SfDescription"] = GetFieldValue(data.SfDescription);
            return row;
        }
    }
}
