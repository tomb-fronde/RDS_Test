using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RMailmergeCustDownloadData
    {
        public int RDSCustomerCustId
        {
            get
            {
                return 0;
            }
        }
        public string RDSCustomerCustSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string RDSCustomerCustInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustName
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustAddressRoad
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustAddressLocality
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustAddressTown
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime RDSCustomerCustDateFirstLoaded
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int CustDateLeft
        {
            get
            {
                return 0;
            }
        }
        public string RDSCustomerCustDirListingInd
        {
            get
            {
                return string.Empty;
            }
        }
        public string RDSCustomerCustDirListingText
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCFirstNames
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string OwnerdriverName
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCPhoneDay
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCPhoneNight
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCMobile
        {
            get
            {
                return string.Empty;
            }
        }
        public string CMobile2
        {
            get
            {
                return string.Empty;
            }
        }
        public string PrimaryContact
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCEmailAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCSalutation
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOTelephone
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOFax
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOManager
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnRcmManager
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnFax
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnTelephone
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string CcontractNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string AddressCustRdNumber
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
        public string CustDeliverydays
        {
            get
            {
                return string.Empty;
            }
        }
        public string CustCategory
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletTypeOtOutletType
        {
            get
            {
                return string.Empty;
            }
        }
        public string RDSCustomerCustTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string AddressAdrNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string AdrPostCode
        {
            get
            {
                return string.Empty;
            }
        }
        public string AddressAdrAlpha
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
        public int AddressDpId
        {
            get
            {
                return 0;
            }
        }
    }
    public class MailmergeCustDownloadDataDataSet : ReportDataSet<MailmergeCustDownloadData>
    {

        public DataColumn RDSCustomerCustId = new DataColumn("RDSCustomerCustId", typeof(int));

        public DataColumn RDSCustomerCustSurnameCompany = new DataColumn("RDSCustomerCustSurnameCompany", typeof(string));

        public DataColumn RDSCustomerCustInitials = new DataColumn("RDSCustomerCustInitials", typeof(string));

        public DataColumn CustName = new DataColumn("CustName", typeof(string));

        public DataColumn CustAddressRoad = new DataColumn("CustAddressRoad", typeof(string));

        public DataColumn CustAddressLocality = new DataColumn("CustAddressLocality", typeof(string));

        public DataColumn CustAddressTown = new DataColumn("CustAddressTown", typeof(string));

        public DataColumn RDSCustomerCustDateFirstLoaded = new DataColumn("RDSCustomerCustDateFirstLoaded", typeof(DateTime));

        public DataColumn CustDateLeft = new DataColumn("CustDateLeft", typeof(int));

        public DataColumn RDSCustomerCustDirListingInd = new DataColumn("RDSCustomerCustDirListingInd", typeof(string));

        public DataColumn RDSCustomerCustDirListingText = new DataColumn("RDSCustomerCustDirListingText", typeof(string));

        public DataColumn ContractorCTitle = new DataColumn("ContractorCTitle", typeof(string));

        public DataColumn ContractorCFirstNames = new DataColumn("ContractorCFirstNames", typeof(string));

        public DataColumn ContractorCSurnameCompany = new DataColumn("ContractorCSurnameCompany", typeof(string));

        public DataColumn OwnerdriverName = new DataColumn("OwnerdriverName", typeof(string));

        public DataColumn ContractorCPhoneDay = new DataColumn("ContractorCPhoneDay", typeof(string));

        public DataColumn ContractorCPhoneNight = new DataColumn("ContractorCPhoneNight", typeof(string));

        public DataColumn ContractorCMobile = new DataColumn("ContractorCMobile", typeof(string));

        public DataColumn CMobile2 = new DataColumn("CMobile2", typeof(string));

        public DataColumn PrimaryContact = new DataColumn("PrimaryContact", typeof(string));

        public DataColumn ContractorCEmailAddress = new DataColumn("ContractorCEmailAddress", typeof(string));

        public DataColumn ContractorCSalutation = new DataColumn("ContractorCSalutation", typeof(string));

        public DataColumn OutletOName = new DataColumn("OutletOName", typeof(string));

        public DataColumn OutletOAddress = new DataColumn("OutletOAddress", typeof(string));

        public DataColumn OutletOTelephone = new DataColumn("OutletOTelephone", typeof(string));

        public DataColumn OutletOFax = new DataColumn("OutletOFax", typeof(string));

        public DataColumn OutletOManager = new DataColumn("OutletOManager", typeof(string));

        public DataColumn RegionRgnName = new DataColumn("RegionRgnName", typeof(string));

        public DataColumn RegionRgnRcmManager = new DataColumn("RegionRgnRcmManager", typeof(string));

        public DataColumn RegionRgnFax = new DataColumn("RegionRgnFax", typeof(string));

        public DataColumn RegionRgnTelephone = new DataColumn("RegionRgnTelephone", typeof(string));

        public DataColumn RegionRgnAddress = new DataColumn("RegionRgnAddress", typeof(string));

        public DataColumn CcontractNo = new DataColumn("CcontractNo", typeof(string));

        public DataColumn AddressCustRdNumber = new DataColumn("AddressCustRdNumber", typeof(string));

        public DataColumn CustDeliveryDays = new DataColumn("CustDeliveryDays", typeof(string));

        public DataColumn CustDeliverydays = new DataColumn("CustDeliverydays", typeof(string));

        public DataColumn CustCategory = new DataColumn("CustCategory", typeof(string));

        public DataColumn ContractorCInitials = new DataColumn("ContractorCInitials", typeof(string));

        public DataColumn OutletTypeOtOutletType = new DataColumn("OutletTypeOtOutletType", typeof(string));

        public DataColumn RDSCustomerCustTitle = new DataColumn("RDSCustomerCustTitle", typeof(string));

        public DataColumn AddressAdrNo = new DataColumn("AddressAdrNo", typeof(string));

        public DataColumn AdrPostCode = new DataColumn("AdrPostCode", typeof(string));

        public DataColumn AddressAdrAlpha = new DataColumn("AddressAdrAlpha", typeof(string));

        public DataColumn CustMailingAddressNo = new DataColumn("CustMailingAddressNo", typeof(string));

        public DataColumn AddressDpId = new DataColumn("AddressDpId", typeof(int));


        public MailmergeCustDownloadDataDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RDSCustomerCustId,RDSCustomerCustSurnameCompany,RDSCustomerCustInitials,CustName,CustAddressRoad,CustAddressLocality,CustAddressTown,RDSCustomerCustDateFirstLoaded,CustDateLeft,RDSCustomerCustDirListingInd,RDSCustomerCustDirListingText,ContractorCTitle,ContractorCFirstNames,ContractorCSurnameCompany,OwnerdriverName,ContractorCPhoneDay,ContractorCPhoneNight,ContractorCMobile,CMobile2,PrimaryContact,ContractorCEmailAddress,ContractorCSalutation,OutletOName,OutletOAddress,OutletOTelephone,OutletOFax,OutletOManager,RegionRgnName,RegionRgnRcmManager,RegionRgnFax,RegionRgnTelephone,RegionRgnAddress,CcontractNo,AddressCustRdNumber,CustDeliveryDays,CustDeliverydays,CustCategory,ContractorCInitials,OutletTypeOtOutletType,RDSCustomerCustTitle,AddressAdrNo,AdrPostCode,AddressAdrAlpha,CustMailingAddressNo,AddressDpId
				});
            RDSCustomerCustId.AllowDBNull = true;
            RDSCustomerCustDateFirstLoaded.AllowDBNull = true;
            CustDateLeft.AllowDBNull = true;
            AddressDpId.AllowDBNull = true;

        }

        public MailmergeCustDownloadDataDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<MailmergeCustDownloadData> datas = dataSource as Metex.Core.EntityBindingList<MailmergeCustDownloadData>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(MailmergeCustDownloadData data)
        {
            DataRow row = this.NewRow();
            row["RDSCustomerCustId"] = GetFieldValue(data.RDSCustomerCustId);
            row["RDSCustomerCustSurnameCompany"] = GetFieldValue(data.RDSCustomerCustSurnameCompany);
            row["RDSCustomerCustInitials"] = GetFieldValue(data.RDSCustomerCustInitials);
            row["CustName"] = GetFieldValue(data.CustName);
            row["CustAddressRoad"] = GetFieldValue(data.CustAddressRoad);
            row["CustAddressLocality"] = GetFieldValue(data.CustAddressLocality);
            row["CustAddressTown"] = GetFieldValue(data.CustAddressTown);
            row["RDSCustomerCustDateFirstLoaded"] = GetFieldValue(data.RDSCustomerCustDateFirstLoaded);
            row["CustDateLeft"] = GetFieldValue(data.CustDateLeft);
            row["RDSCustomerCustDirListingInd"] = GetFieldValue(data.RDSCustomerCustDirListingInd);
            row["RDSCustomerCustDirListingText"] = GetFieldValue(data.RDSCustomerCustDirListingText);
            row["ContractorCTitle"] = GetFieldValue(data.ContractorCTitle);
            row["ContractorCFirstNames"] = GetFieldValue(data.ContractorCFirstNames);
            row["ContractorCSurnameCompany"] = GetFieldValue(data.ContractorCSurnameCompany);
            row["OwnerdriverName"] = GetFieldValue(data.OwnerdriverName);
            row["ContractorCPhoneDay"] = GetFieldValue(data.ContractorCPhoneDay);
            row["ContractorCPhoneNight"] = GetFieldValue(data.ContractorCPhoneNight);
            row["ContractorCMobile"] = GetFieldValue(data.ContractorCMobile);
            row["CMobile2"] = GetFieldValue(data.CMobile2);
            row["PrimaryContact"] = GetFieldValue(data.PrimaryContact);
            row["ContractorCEmailAddress"] = GetFieldValue(data.ContractorCEmailAddress);
            row["ContractorCSalutation"] = GetFieldValue(data.ContractorCSalutation);
            row["OutletOName"] = GetFieldValue(data.OutletOName);
            row["OutletOAddress"] = GetFieldValue(data.OutletOAddress);
            row["OutletOTelephone"] = GetFieldValue(data.OutletOTelephone);
            row["OutletOFax"] = GetFieldValue(data.OutletOFax);
            row["OutletOManager"] = GetFieldValue(data.OutletOManager);
            row["RegionRgnName"] = GetFieldValue(data.RegionRgnName);
            row["RegionRgnRcmManager"] = GetFieldValue(data.RegionRgnRcmManager);
            row["RegionRgnFax"] = GetFieldValue(data.RegionRgnFax);
            row["RegionRgnTelephone"] = GetFieldValue(data.RegionRgnTelephone);
            row["RegionRgnAddress"] = GetFieldValue(data.RegionRgnAddress);
            row["CcontractNo"] = GetFieldValue(data.CcontractNo);
            row["AddressCustRdNumber"] = GetFieldValue(data.AddressCustRdNumber);
            row["CustDeliveryDays"] = GetFieldValue(data.CustDeliveryDays);
            row["CustDeliverydays"] = GetFieldValue(data.CustDeliverydays1);
            row["CustCategory"] = GetFieldValue(data.CustCategory);
            row["ContractorCInitials"] = GetFieldValue(data.ContractorCInitials);
            row["OutletTypeOtOutletType"] = GetFieldValue(data.OutletTypeOtOutletType);
            row["RDSCustomerCustTitle"] = GetFieldValue(data.RDSCustomerCustTitle);
            row["AddressAdrNo"] = GetFieldValue(data.AddressAdrNo);
            row["AdrPostCode"] = GetFieldValue(data.AdrPostCode);
            row["AddressAdrAlpha"] = GetFieldValue(data.AddressAdrAlpha);
            row["CustMailingAddressNo"] = GetFieldValue(data.CustMailingAddressNo);
            row["AddressDpId"] = GetFieldValue(data.AddressDpId);
            return row;
        }
    }
}
