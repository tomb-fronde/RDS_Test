using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustlistLabelFast
    {
        public int CustId
        {
            get
            {
                return 0;
            }
        }
        public int CustAdpostQuantity
        {
            get
            {
                return 0;
            }
        }
        public DateTime CustDateFirstLoaded
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime CustDateLastTransfered
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime CustDateLeft
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int ContractNo
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
        public string CustRdNumber
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
        public string CustNadReference
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
        public string CustDirListingText
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustDeliveryDays
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustBusiness
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustRuralResident
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustRuralFarmer
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
        public string ConTitle
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
        public string CustPropertyIdentification
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
        public string Compute0028
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute0029
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class CustlistLabelFastDataSet : ReportDataSet<CustlistLabelFast>
    {

        public DataColumn CustId = new DataColumn("CustId", typeof(int));

        public DataColumn CustAdpostQuantity = new DataColumn("CustAdpostQuantity", typeof(int));

        public DataColumn CustDateFirstLoaded = new DataColumn("CustDateFirstLoaded", typeof(DateTime));

        public DataColumn CustDateLastTransfered = new DataColumn("CustDateLastTransfered", typeof(DateTime));

        public DataColumn CustDateLeft = new DataColumn("CustDateLeft", typeof(DateTime));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn CustTitle = new DataColumn("CustTitle", typeof(string));

        public DataColumn CustSurnameCompany = new DataColumn("CustSurnameCompany", typeof(string));

        public DataColumn CustInitials = new DataColumn("CustInitials", typeof(string));

        public DataColumn CustRdNumber = new DataColumn("CustRdNumber", typeof(string));

        public DataColumn CustMailingAddressNo = new DataColumn("CustMailingAddressNo", typeof(string));

        public DataColumn CustMailingAddressRoad = new DataColumn("CustMailingAddressRoad", typeof(string));

        public DataColumn CustMailingAddressLocality = new DataColumn("CustMailingAddressLocality", typeof(string));

        public DataColumn CustMailTown = new DataColumn("CustMailTown", typeof(string));

        public DataColumn CustNadReference = new DataColumn("CustNadReference", typeof(string));

        public DataColumn CustPhoneDay = new DataColumn("CustPhoneDay", typeof(string));

        public DataColumn CustPhoneNight = new DataColumn("CustPhoneNight", typeof(string));

        public DataColumn CustDirListingText = new DataColumn("CustDirListingText", typeof(string));

        public DataColumn CustDeliveryDays = new DataColumn("CustDeliveryDays", typeof(string));

        public DataColumn CustBusiness = new DataColumn("CustBusiness", typeof(string));

        public DataColumn CustRuralResident = new DataColumn("CustRuralResident", typeof(string));

        public DataColumn CustRuralFarmer = new DataColumn("CustRuralFarmer", typeof(string));

        public DataColumn ConRdRefText = new DataColumn("ConRdRefText", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn CustDirListingInd = new DataColumn("CustDirListingInd", typeof(string));

        public DataColumn CustPropertyIdentification = new DataColumn("CustPropertyIdentification", typeof(string));

        public DataColumn CustPostCode = new DataColumn("CustPostCode", typeof(string));

        public DataColumn Compute0028 = new DataColumn("Compute0028", typeof(string));

        public DataColumn Compute0029 = new DataColumn("Compute0029", typeof(string));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(string));

        public DataColumn Compute2 = new DataColumn("Compute2", typeof(string));

        public CustlistLabelFastDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CustId,CustAdpostQuantity,CustDateFirstLoaded,CustDateLastTransfered,CustDateLeft,ContractNo,CustTitle,CustSurnameCompany,CustInitials,CustRdNumber,CustMailingAddressNo,CustMailingAddressRoad,CustMailingAddressLocality,CustMailTown,CustNadReference,CustPhoneDay,CustPhoneNight,CustDirListingText,CustDeliveryDays,CustBusiness,CustRuralResident,CustRuralFarmer,ConRdRefText,ConTitle,CustDirListingInd,CustPropertyIdentification,CustPostCode,Compute0028,Compute0029,Compute1,Compute2
				});
            CustId.AllowDBNull = true;
            CustAdpostQuantity.AllowDBNull = true;
            CustDateFirstLoaded.AllowDBNull = true;
            CustDateLastTransfered.AllowDBNull = true;
            CustDateLeft.AllowDBNull = true;
            ContractNo.AllowDBNull = true;
            Compute1.AllowDBNull = true;
            Compute2.AllowDBNull = true;
        }

        public CustlistLabelFastDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustlistLabelFast> datas = dataSource as Metex.Core.EntityBindingList<CustlistLabelFast>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustlistLabelFast data)
        {
            DataRow row = this.NewRow();
            row["CustId"] = GetFieldValue(data.CustId);
            row["CustAdpostQuantity"] = GetFieldValue(data.CustAdpostQuantity);
            row["CustDateFirstLoaded"] = GetFieldValue(data.CustDateFirstLoaded);
            row["CustDateLastTransfered"] = GetFieldValue(data.CustDateLastTransfered);
            row["CustDateLeft"] = GetFieldValue(data.CustDateLeft);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["CustTitle"] = GetFieldValue(data.CustTitle);
            row["CustSurnameCompany"] = GetFieldValue(data.CustSurnameCompany);
            row["CustInitials"] = GetFieldValue(data.CustInitials);
            row["CustRdNumber"] = GetFieldValue(data.CustRdNumber);
            row["CustMailingAddressNo"] = GetFieldValue(data.CustMailingAddressNo);
            row["CustMailingAddressRoad"] = GetFieldValue(data.CustMailingAddressRoad);
            row["CustMailingAddressLocality"] = GetFieldValue(data.CustMailingAddressLocality);
            row["CustMailTown"] = GetFieldValue(data.CustMailTown);
            row["CustNadReference"] = GetFieldValue(data.CustNadReference);
            row["CustPhoneDay"] = GetFieldValue(data.CustPhoneDay);
            row["CustPhoneNight"] = GetFieldValue(data.CustPhoneNight);
            row["CustDirListingText"] = GetFieldValue(data.CustDirListingText);
            row["CustDeliveryDays"] = GetFieldValue(data.CustDeliveryDays);
            row["CustBusiness"] = GetFieldValue(data.CustBusiness);
            row["CustRuralResident"] = GetFieldValue(data.CustRuralResident);
            row["CustRuralFarmer"] = GetFieldValue(data.CustRuralFarmer);
            row["ConRdRefText"] = GetFieldValue(data.ConRdRefText);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["CustDirListingInd"] = GetFieldValue(data.CustDirListingInd);
            row["CustPropertyIdentification"] = GetFieldValue(data.CustPropertyIdentification);
            row["CustPostCode"] = GetFieldValue(data.CustPostCode);
            row["Compute0028"] = GetFieldValue(data.Compute0028);
            row["Compute0029"] = GetFieldValue(data.Compute0029);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["Compute2"] = GetFieldValue(data.Compute2);

            return row;
        }
    }
}
