using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustlistRandomLabel
    {
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
        public string CustMailingAddressNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustMailingAddressRoad
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustMailingAddressLocality
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustMailTown
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustRdNumber
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
        public string CustPostCode
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class CustlistRandomLabelDataSet : ReportDataSet<CustlistRandomLabel>
    {

        public DataColumn CustTitle = new DataColumn("CustTitle", typeof(string));

        public DataColumn CustSurnameCompany = new DataColumn("CustSurnameCompany", typeof(string));

        public DataColumn CustInitials = new DataColumn("CustInitials", typeof(string));

        public DataColumn CustMailingAddressNo = new DataColumn("CustMailingAddressNo", typeof(string));

        public DataColumn CustMailingAddressRoad = new DataColumn("CustMailingAddressRoad", typeof(string));

        public DataColumn CustMailingAddressLocality = new DataColumn("CustMailingAddressLocality", typeof(string));

        public DataColumn CustMailTown = new DataColumn("CustMailTown", typeof(string));

        public DataColumn CustRdNumber = new DataColumn("CustRdNumber", typeof(string));

        public DataColumn ConRdRefText = new DataColumn("ConRdRefText", typeof(string));

        public DataColumn CustPostCode = new DataColumn("CustPostCode", typeof(string));


        public CustlistRandomLabelDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CustTitle,CustSurnameCompany,CustInitials,CustMailingAddressNo,CustMailingAddressRoad,CustMailingAddressLocality,CustMailTown,CustRdNumber,ConRdRefText,CustPostCode
				});

        }

        public CustlistRandomLabelDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustlistRandomLabel> datas = dataSource as Metex.Core.EntityBindingList<CustlistRandomLabel>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustlistRandomLabel data)
        {
            DataRow row = this.NewRow();
            row["CustTitle"] = GetFieldValue(data.CustTitle);
            row["CustSurnameCompany"] = GetFieldValue(data.CustSurnameCompany);
            row["CustInitials"] = GetFieldValue(data.CustInitials);
            row["CustMailingAddressNo"] = GetFieldValue(data.CustMailingAddressNo);
            row["CustMailingAddressRoad"] = GetFieldValue(data.CustMailingAddressRoad);
            row["CustMailingAddressLocality"] = GetFieldValue(data.CustMailingAddressLocality);
            row["CustMailTown"] = GetFieldValue(data.CustMailTown);
            row["CustRdNumber"] = GetFieldValue(data.CustRdNumber);
            row["ConRdRefText"] = GetFieldValue(data.ConRdRefText);
            row["CustPostCode"] = GetFieldValue(data.CustPostCode);
            return row;
        }
    }
}
