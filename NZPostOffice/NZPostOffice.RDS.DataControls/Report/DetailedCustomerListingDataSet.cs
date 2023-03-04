using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RDetailedCustomerListing
    {
        public int CustId
        {
            get
            {
                return 0;
            }
        }
        public string CustTitle
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
        public string CustSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustPhoneDay
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustPhoneNight
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustPhoneMobile
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustDirListingInd
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustDirListingText
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime CustDateCommenced
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string CustAdpostQuantity
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute0012
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute0013
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute0014
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute0015
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute0016
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class DetailedCustomerListingDataSet : ReportDataSet<DetailedCustomerListing>
    {

        public DataColumn CustId = new DataColumn("CustId", typeof(int));

        public DataColumn CustTitle = new DataColumn("CustTitle", typeof(string));

        public DataColumn CustInitials = new DataColumn("CustInitials", typeof(string));

        public DataColumn CustSurnameCompany = new DataColumn("CustSurnameCompany", typeof(string));

        public DataColumn CustPhoneDay = new DataColumn("CustPhoneDay", typeof(string));

        public DataColumn CustPhoneNight = new DataColumn("CustPhoneNight", typeof(string));

        public DataColumn CustPhoneMobile = new DataColumn("CustPhoneMobile", typeof(string));

        public DataColumn CustDirListingInd = new DataColumn("CustDirListingInd", typeof(string));

        public DataColumn CustDirListingText = new DataColumn("CustDirListingText", typeof(string));

        public DataColumn CustDateCommenced = new DataColumn("CustDateCommenced", typeof(DateTime));

        public DataColumn CustAdpostQuantity = new DataColumn("CustAdpostQuantity", typeof(string));

        public DataColumn Compute0012 = new DataColumn("Compute0012", typeof(string));

        public DataColumn Compute0013 = new DataColumn("Compute0013", typeof(string));

        public DataColumn Compute0014 = new DataColumn("Compute0014", typeof(string));

        public DataColumn Compute0015 = new DataColumn("Compute0015", typeof(string));

        public DataColumn Compute0016 = new DataColumn("Compute0016", typeof(string));


        public DetailedCustomerListingDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CustId,CustTitle,CustInitials,CustSurnameCompany,CustPhoneDay,CustPhoneNight,CustPhoneMobile,CustDirListingInd,CustDirListingText,CustDateCommenced,CustAdpostQuantity,Compute0012,Compute0013,Compute0014,Compute0015,Compute0016
				});
            CustId.AllowDBNull = true;
            CustDateCommenced.AllowDBNull = true;

        }

        public DetailedCustomerListingDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<DetailedCustomerListing> datas = dataSource as Metex.Core.EntityBindingList<DetailedCustomerListing>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(DetailedCustomerListing data)
        {
            DataRow row = this.NewRow();
            row["CustId"] = GetFieldValue(data.CustId);
            row["CustTitle"] = GetFieldValue(data.CustTitle);
            row["CustInitials"] = GetFieldValue(data.CustInitials);
            row["CustSurnameCompany"] = GetFieldValue(data.CustSurnameCompany);
            row["CustPhoneDay"] = GetFieldValue(data.CustPhoneDay);
            row["CustPhoneNight"] = GetFieldValue(data.CustPhoneNight);
            row["CustPhoneMobile"] = GetFieldValue(data.CustPhoneMobile);
            row["CustDirListingInd"] = GetFieldValue(data.CustDirListingInd);
            row["CustDirListingText"] = GetFieldValue(data.CustDirListingText);
            row["CustDateCommenced"] = GetFieldValue(data.CustDateCommenced);
            row["CustAdpostQuantity"] = GetFieldValue(data.CustAdpostQuantity);
            row["Compute0012"] = GetFieldValue(data.Compute0012);
            row["Compute0013"] = GetFieldValue(data.Compute0013);
            row["Compute0014"] = GetFieldValue(data.Compute0014);
            row["Compute0015"] = GetFieldValue(data.Compute0015);
            row["Compute0016"] = GetFieldValue(data.Compute0016);
            return row;
        }
    }
}
