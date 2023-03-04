using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RMailCarriedSingleContract
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
        public DateTime ConStartDate
        {
            get
            {
                return DateTime.MinValue;
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
        public string SfDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string RfDeliveryDays
        {
            get
            {
                return string.Empty;
            }
        }
        public string McDispatchCarried
        {
            get
            {
                return string.Empty;
            }
        }
        public string UpliftOutletName
        {
            get
            {
                return string.Empty;
            }
        }
        public string McUpliftTime
        {
            get
            {
                return string.Empty;
            }
        }
        public string SetDownOutletNamec
        {
            get
            {
                return string.Empty;
            }
        }
        public string McSetDownTime
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
        public string OName
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
    }
    public class MailCarriedSingleContractDataSet : ReportDataSet<MailCarriedSingleContract>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn ConStartDate = new DataColumn("ConStartDate", typeof(DateTime));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn SfDescription = new DataColumn("SfDescription", typeof(string));

        public DataColumn RfDeliveryDays = new DataColumn("RfDeliveryDays", typeof(string));

        public DataColumn McDispatchCarried = new DataColumn("McDispatchCarried", typeof(string));

        public DataColumn UpliftOutletName = new DataColumn("UpliftOutletName", typeof(string));

        public DataColumn McUpliftTime = new DataColumn("McUpliftTime", typeof(string));

        public DataColumn SetDownOutletNamec = new DataColumn("SetDownOutletNamec", typeof(string));

        public DataColumn McSetDownTime = new DataColumn("McSetDownTime", typeof(string));

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn ConRdRefText = new DataColumn("ConRdRefText", typeof(string));


        public MailCarriedSingleContractDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ContractSeqNumber,ConTitle,ConStartDate,CSurnameCompany,CFirstNames,CInitials,SfDescription,RfDeliveryDays,McDispatchCarried,UpliftOutletName,McUpliftTime,SetDownOutletNamec,McSetDownTime,RgnName,OName,ConRdRefText
				});
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            ConStartDate.AllowDBNull = true;

        }

        public MailCarriedSingleContractDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<MailCarriedSingleContract> datas = dataSource as Metex.Core.EntityBindingList<MailCarriedSingleContract>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(MailCarriedSingleContract data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["ConStartDate"] = GetFieldValue(data.ConStartDate);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["SfDescription"] = GetFieldValue(data.SfDescription);
            row["RfDeliveryDays"] = GetFieldValue(data.RfDeliveryDays);
            row["McDispatchCarried"] = GetFieldValue(data.McDispatchCarried);
            row["UpliftOutletName"] = GetFieldValue(data.UpliftOutletName);
            row["McUpliftTime"] = GetFieldValue(data.McUpliftTime);
            row["SetDownOutletNamec"] = GetFieldValue(data.SetDownOutletNamec);
            row["McSetDownTime"] = GetFieldValue(data.McSetDownTime);
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["OName"] = GetFieldValue(data.OName);
            row["ConRdRefText"] = GetFieldValue(data.ConRdRefText);
            return row;
        }
    }
}
