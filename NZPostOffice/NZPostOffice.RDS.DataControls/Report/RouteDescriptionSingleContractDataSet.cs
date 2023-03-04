using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RRouteDescriptionSingleContract
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
        public int SfKey
        {
            get
            {
                return 0;
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
        public string RfptDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string RdTimeAtPoint
        {
            get
            {
                return string.Empty;
            }
        }
        public string RdDescriptionOfPoint
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal RfDistanceOfLeg
        {
            get
            {
                return 0;
            }
        }
        public string RfvDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string RfvDescription2
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal RfRunningTotal
        {
            get
            {
                return 0;
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
        public string ConRdRefText
        {
            get
            {
                return string.Empty;
            }
        }
        public string RfAnnotation
        {
            get
            {
                return string.Empty;
            }
        }
        public string RfAnnotationPrint
        {
            get
            {
                return string.Empty;
            }
        }
        public int CustId
        {
            get
            {
                return 0;
            }
        }
    }
    public class RouteDescriptionSingleContractDataSet : ReportDataSet<RouteDescriptionSingleContract>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn ConStartDate = new DataColumn("ConStartDate", typeof(DateTime));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn SfDescription = new DataColumn("SfDescription", typeof(string));

        public DataColumn RfDeliveryDays = new DataColumn("RfDeliveryDays", typeof(string));

        public DataColumn RfptDescription = new DataColumn("RfptDescription", typeof(string));

        public DataColumn RdTimeAtPoint = new DataColumn("RdTimeAtPoint", typeof(string));

        public DataColumn RdDescriptionOfPoint = new DataColumn("RdDescriptionOfPoint", typeof(string));

        public DataColumn RfDistanceOfLeg = new DataColumn("RfDistanceOfLeg", typeof(decimal));

        public DataColumn RfvDescription = new DataColumn("RfvDescription", typeof(string));

        public DataColumn RfvDescription2 = new DataColumn("RfvDescription2", typeof(string));

        public DataColumn RfRunningTotal = new DataColumn("RfRunningTotal", typeof(decimal));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn ConRdRefText = new DataColumn("ConRdRefText", typeof(string));

        public DataColumn RfAnnotation = new DataColumn("RfAnnotation", typeof(string));

        public DataColumn RfAnnotationPrint = new DataColumn("RfAnnotationPrint", typeof(string));

        public DataColumn CustId = new DataColumn("CustId", typeof(int));


        public RouteDescriptionSingleContractDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ContractSeqNumber,ConTitle,ConStartDate,CSurnameCompany,CFirstNames,CInitials,SfKey,SfDescription,RfDeliveryDays,RfptDescription,RdTimeAtPoint,RdDescriptionOfPoint,RfDistanceOfLeg,RfvDescription,RfvDescription2,RfRunningTotal,OName,RgnName,ConRdRefText,RfAnnotation,RfAnnotationPrint,CustId
				});
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            ConStartDate.AllowDBNull = true;
            SfKey.AllowDBNull = true;
            RfDistanceOfLeg.AllowDBNull = true;
            RfRunningTotal.AllowDBNull = true;
            CustId.AllowDBNull = true;

        }

        public RouteDescriptionSingleContractDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<RouteDescriptionSingleContract> datas = dataSource as Metex.Core.EntityBindingList<RouteDescriptionSingleContract>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(RouteDescriptionSingleContract data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["ConStartDate"] = GetFieldValue(data.ConStartDate);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["SfDescription"] = GetFieldValue(data.SfDescription);
            row["RfDeliveryDays"] = GetFieldValue(data.RfDeliveryDays);
            row["RfptDescription"] = GetFieldValue(data.RfptDescription);
            row["RdTimeAtPoint"] = GetFieldValue(data.RdTimeAtPoint);
            row["RdDescriptionOfPoint"] = GetFieldValue(data.RdDescriptionOfPoint);
            row["RfDistanceOfLeg"] = GetFieldValue(data.RfDistanceOfLeg);
            row["RfvDescription"] = GetFieldValue(data.RfvDescription);
            row["RfvDescription2"] = GetFieldValue(data.RfvDescription2);
            row["RfRunningTotal"] = GetFieldValue(data.RfRunningTotal);
            row["OName"] = GetFieldValue(data.OName);
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["ConRdRefText"] = GetFieldValue(data.ConRdRefText);
            row["RfAnnotation"] = GetFieldValue(data.RfAnnotation);
            row["RfAnnotationPrint"] = GetFieldValue(data.RfAnnotationPrint);
            row["CustId"] = GetFieldValue(data.CustId);
            return row;
        }
    }
}
