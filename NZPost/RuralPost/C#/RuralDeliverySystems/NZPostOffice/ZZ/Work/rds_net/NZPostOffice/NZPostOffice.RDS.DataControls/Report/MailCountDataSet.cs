using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RMailCount
    {
        public string RenewalGroupRgDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractContractNo
        {
            get
            {
                return 0;
            }
        }
        public string ContractConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime MailCountDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string Cname
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractConRdRefText
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class MailCountDataSet : ReportDataSet<MailCount>
    {

        public DataColumn RenewalGroupRgDescription = new DataColumn("RenewalGroupRgDescription", typeof(string));

        public DataColumn ContractContractNo = new DataColumn("ContractContractNo", typeof(int));

        public DataColumn ContractConTitle = new DataColumn("ContractConTitle", typeof(string));

        public DataColumn MailCountDate = new DataColumn("MailCountDate", typeof(DateTime));

        public DataColumn Cname = new DataColumn("Cname", typeof(string));

        public DataColumn ContractConRdRefText = new DataColumn("ContractConRdRefText", typeof(string));


        public MailCountDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RenewalGroupRgDescription,ContractContractNo,ContractConTitle,MailCountDate,Cname,ContractConRdRefText
				});
            ContractContractNo.AllowDBNull = true;
            MailCountDate.AllowDBNull = true;

        }

        public MailCountDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<MailCount> datas = dataSource as Metex.Core.EntityBindingList<MailCount>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(MailCount data)
        {
            DataRow row = this.NewRow();
            row["RenewalGroupRgDescription"] = GetFieldValue(data.RenewalGroupRgDescription);
            row["ContractContractNo"] = GetFieldValue(data.ContractContractNo);
            row["ContractConTitle"] = GetFieldValue(data.ContractConTitle);
            row["MailCountDate"] = GetFieldValue(data.MailCountDate);
            row["Cname"] = GetFieldValue(data.Cname);
            row["ContractConRdRefText"] = GetFieldValue(data.ContractConRdRefText);
            return row;
        }
    }
}
