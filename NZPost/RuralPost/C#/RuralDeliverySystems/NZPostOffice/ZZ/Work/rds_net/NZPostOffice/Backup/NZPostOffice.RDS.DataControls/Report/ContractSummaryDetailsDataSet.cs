using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryDetails
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string ConOldMailServiceNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal ConRenewalPaymentValue
        {
            get
            {
                return 0;
            }
        }
        public string RgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string RgnRcmManager
        {
            get
            {
                return string.Empty;
            }
        }
        public string RgnTelephone
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
        public DateTime ConStartDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime ConExpiryDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime ConLastWorkMsrmntCheck
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime ConLastDeliveryCheck
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal ExtAmt
        {
            get
            {
                return 0;
            }
        }
        public string Lodgement
        {
            get
            {
                return string.Empty;
            }
        }
        public int ConActiveSequence
        {
            get
            {
                return 0;
            }
        }
        public string ConRcmPaperFileText
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
        public string ConRdPaperFileText
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConAcceptanceFlag
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime Lastdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class ContractSummaryDetailsDataSet : ReportDataSet<ContractSummaryDetails>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ConOldMailServiceNo = new DataColumn("ConOldMailServiceNo", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn ConRenewalPaymentValue = new DataColumn("ConRenewalPaymentValue", typeof(decimal));

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn RgnRcmManager = new DataColumn("RgnRcmManager", typeof(string));

        public DataColumn RgnTelephone = new DataColumn("RgnTelephone", typeof(string));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn ConStartDate = new DataColumn("ConStartDate", typeof(DateTime));

        public DataColumn ConExpiryDate = new DataColumn("ConExpiryDate", typeof(DateTime));

        public DataColumn ConLastWorkMsrmntCheck = new DataColumn("ConLastWorkMsrmntCheck", typeof(DateTime));

        public DataColumn ConLastDeliveryCheck = new DataColumn("ConLastDeliveryCheck", typeof(DateTime));

        public DataColumn ExtAmt = new DataColumn("ExtAmt", typeof(decimal));

        public DataColumn Lodgement = new DataColumn("Lodgement", typeof(string));

        public DataColumn ConActiveSequence = new DataColumn("ConActiveSequence", typeof(int));

        public DataColumn ConRcmPaperFileText = new DataColumn("ConRcmPaperFileText", typeof(string));

        public DataColumn ConRdRefText = new DataColumn("ConRdRefText", typeof(string));

        public DataColumn ConRdPaperFileText = new DataColumn("ConRdPaperFileText", typeof(string));

        public DataColumn ConAcceptanceFlag = new DataColumn("ConAcceptanceFlag", typeof(string));

        public DataColumn Lastdate = new DataColumn("Lastdate", typeof(DateTime));


        public ContractSummaryDetailsDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ConOldMailServiceNo,ConTitle,ConRenewalPaymentValue,RgnName,RgnRcmManager,RgnTelephone,OName,ConStartDate,ConExpiryDate,ConLastWorkMsrmntCheck,ConLastDeliveryCheck,ExtAmt,Lodgement,ConActiveSequence,ConRcmPaperFileText,ConRdRefText,ConRdPaperFileText,ConAcceptanceFlag,Lastdate
				});
            ContractNo.AllowDBNull = true;
            ConRenewalPaymentValue.AllowDBNull = true;
            ConStartDate.AllowDBNull = true;
            ConExpiryDate.AllowDBNull = true;
            ConLastWorkMsrmntCheck.AllowDBNull = true;
            ConLastDeliveryCheck.AllowDBNull = true;
            ExtAmt.AllowDBNull = true;
            ConActiveSequence.AllowDBNull = true;
            Lastdate.AllowDBNull = true;

        }

        public ContractSummaryDetailsDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryDetails> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryDetails>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryDetailsDataSet(ContractSummaryDetails obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryDetails> list = new Metex.Core.EntityBindingList<ContractSummaryDetails>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryDetailsDataSet(ContractSummaryDetails[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryDetails> list = new Metex.Core.EntityBindingList<ContractSummaryDetails>();
            foreach (ContractSummaryDetails d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryDetails data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ConOldMailServiceNo"] = GetFieldValue(data.ConOldMailServiceNo);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["ConRenewalPaymentValue"] = GetFieldValue(data.ConRenewalPaymentValue);
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["RgnRcmManager"] = GetFieldValue(data.RgnRcmManager);
            row["RgnTelephone"] = GetFieldValue(data.RgnTelephone);
            row["OName"] = GetFieldValue(data.OName);
            row["ConStartDate"] = GetFieldValue(data.ConStartDate);
            row["ConExpiryDate"] = GetFieldValue(data.ConExpiryDate);
            row["ConLastWorkMsrmntCheck"] = GetFieldValue(data.ConLastWorkMsrmntCheck);
            row["ConLastDeliveryCheck"] = GetFieldValue(data.ConLastDeliveryCheck);
            row["ExtAmt"] = GetFieldValue(data.ExtAmt);
            row["Lodgement"] = GetFieldValue(data.Lodgement);
            row["ConActiveSequence"] = GetFieldValue(data.ConActiveSequence);
            row["ConRcmPaperFileText"] = GetFieldValue(data.ConRcmPaperFileText);
            row["ConRdRefText"] = GetFieldValue(data.ConRdRefText);
            row["ConRdPaperFileText"] = GetFieldValue(data.ConRdPaperFileText);
            row["ConAcceptanceFlag"] = GetFieldValue(data.ConAcceptanceFlag);
            row["Lastdate"] = GetFieldValue(data.Lastdate);
            return row;
        }
    }
}
