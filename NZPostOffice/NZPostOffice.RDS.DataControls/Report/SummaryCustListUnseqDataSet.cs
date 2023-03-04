using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RSummaryCustListUnseq
    {
        public int SeqNum
        {
            get
            {
                return 0;
            }
        }
        public string AdrNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string RoadName
        {
            get
            {
                return string.Empty;
            }
        }
        public string RtName
        {
            get
            {
                return string.Empty;
            }
        }
        public string Locality
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public string AdrAlpha
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class SummaryCustListUnseqDataSet : ReportDataSet<SummaryCustListUnseq>
    {

        public DataColumn SeqNum = new DataColumn("SeqNum", typeof(int));

        public DataColumn AdrNo = new DataColumn("AdrNo", typeof(string));

        public DataColumn RoadName = new DataColumn("RoadName", typeof(string));

        public DataColumn RtName = new DataColumn("RtName", typeof(string));

        public DataColumn Locality = new DataColumn("Locality", typeof(string));

        public DataColumn CustTitle = new DataColumn("CustTitle", typeof(string));

        public DataColumn CustSurnameCompany = new DataColumn("CustSurnameCompany", typeof(string));

        public DataColumn CustInitials = new DataColumn("CustInitials", typeof(string));

        public DataColumn AdrAlpha = new DataColumn("AdrAlpha", typeof(string));


        public SummaryCustListUnseqDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				SeqNum,AdrNo,RoadName,RtName,Locality,CustTitle,CustSurnameCompany,CustInitials,AdrAlpha
				});
            SeqNum.AllowDBNull = true;

        }

        public SummaryCustListUnseqDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<SummaryCustListUnseq> datas = dataSource as Metex.Core.EntityBindingList<SummaryCustListUnseq>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(SummaryCustListUnseq data)
        {
            DataRow row = this.NewRow();
            row["SeqNum"] = GetFieldValue(data.SeqNum);
            row["AdrNo"] = GetFieldValue(data.AdrNo);
            row["RoadName"] = GetFieldValue(data.RoadName);
            row["RtName"] = GetFieldValue(data.RtName);
            row["Locality"] = GetFieldValue(data.Locality);
            row["CustTitle"] = GetFieldValue(data.CustTitle);
            row["CustSurnameCompany"] = GetFieldValue(data.CustSurnameCompany);
            row["CustInitials"] = GetFieldValue(data.CustInitials);
            row["AdrAlpha"] = GetFieldValue(data.AdrAlpha);
            return row;
        }
    }
}
