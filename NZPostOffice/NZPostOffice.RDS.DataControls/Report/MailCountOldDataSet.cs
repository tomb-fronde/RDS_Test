using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RMailCountOld
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
        public DateTime MailCountDateMailCountDate
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
    }
    public class MailCountOldDataSet : ReportDataSet<MailCountOld>
    {

        public DataColumn RenewalGroupRgDescription = new DataColumn("RenewalGroupRgDescription", typeof(string));

        public DataColumn ContractContractNo = new DataColumn("ContractContractNo", typeof(int));

        public DataColumn ContractConTitle = new DataColumn("ContractConTitle", typeof(string));

        public DataColumn MailCountDateMailCountDate = new DataColumn("MailCountDateMailCountDate", typeof(DateTime));

        public DataColumn Cname = new DataColumn("Cname", typeof(string));


        public MailCountOldDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RenewalGroupRgDescription,ContractContractNo,ContractConTitle,MailCountDateMailCountDate,Cname
				});
            ContractContractNo.AllowDBNull = true;
            MailCountDateMailCountDate.AllowDBNull = true;

        }

        public MailCountOldDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<MailCountOld> datas = dataSource as Metex.Core.EntityBindingList<MailCountOld>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(MailCountOld data)
        {
            DataRow row = this.NewRow();
            row["RenewalGroupRgDescription"] = GetFieldValue(data.RenewalGroupRgDescription);
            row["ContractContractNo"] = GetFieldValue(data.ContractContractNo);
            row["ContractConTitle"] = GetFieldValue(data.ContractConTitle);
            row["MailCountDateMailCountDate"] = GetFieldValue(data.MailCountDateMailCountDate);
            row["Cname"] = GetFieldValue(data.Cname);
            return row;
        }
    }
}
