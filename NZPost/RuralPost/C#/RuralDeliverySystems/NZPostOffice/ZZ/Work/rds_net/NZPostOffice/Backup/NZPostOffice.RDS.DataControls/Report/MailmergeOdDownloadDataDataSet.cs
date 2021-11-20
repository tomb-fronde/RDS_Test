using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RMailmergeOdDownloadData
    {
        public int ContractorContractorSupplierNo
        {
            get
            {
                return 0;
            }
        }
        public string ContractorCTitle
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
        public string DriverName
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string CPhoneDay
        {
            get
            {
                return string.Empty;
            }
        }
        public string CPhoneNight
        {
            get
            {
                return string.Empty;
            }
        }
        public string CMobile
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
        public string CEmailAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCTaxRate
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCIrdNo
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal CTaxRate
        {
            get
            {
                return 0;
            }
        }
        public string ContractorCIrdNo1
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime ContractorRenewalsCrEffectiveDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime ContractRenewalsConStartDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime ContractRenewalsConExpiryDate
        {
            get
            {
                return DateTime.MinValue;
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
        public string ContractorCSalutation
        {
            get
            {
                return string.Empty;
            }
        }
        public string CcSalutation
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
    }
    public class MailmergeOdDownloadDataDataSet : ReportDataSet<MailmergeOdDownloadData>
    {

        public DataColumn ContractorContractorSupplierNo = new DataColumn("ContractorContractorSupplierNo", typeof(int));

        public DataColumn ContractorCTitle = new DataColumn("ContractorCTitle", typeof(string));

        public DataColumn ContractorCInitials = new DataColumn("ContractorCInitials", typeof(string));

        public DataColumn ContractorCFirstNames = new DataColumn("ContractorCFirstNames", typeof(string));

        public DataColumn ContractorCSurnameCompany = new DataColumn("ContractorCSurnameCompany", typeof(string));

        public DataColumn DriverName = new DataColumn("DriverName", typeof(string));

        public DataColumn ContractorCAddress = new DataColumn("ContractorCAddress", typeof(string));

        public DataColumn CPhoneDay = new DataColumn("CPhoneDay", typeof(string));

        public DataColumn CPhoneNight = new DataColumn("CPhoneNight", typeof(string));

        public DataColumn CMobile = new DataColumn("CMobile", typeof(string));

        public DataColumn CMobile2 = new DataColumn("CMobile2", typeof(string));

        public DataColumn PrimaryContact = new DataColumn("PrimaryContact", typeof(string));

        public DataColumn CEmailAddress = new DataColumn("CEmailAddress", typeof(string));

        public DataColumn ContractorCTaxRate = new DataColumn("ContractorCTaxRate", typeof(string));

        public DataColumn ContractorCIrdNo = new DataColumn("ContractorCIrdNo", typeof(string));

        public DataColumn CTaxRate = new DataColumn("CTaxRate", typeof(decimal));

        public DataColumn ContractorCIrdNo1 = new DataColumn("ContractorCIrdNo1", typeof(string));

        public DataColumn ContractConTitle = new DataColumn("ContractConTitle", typeof(string));

        public DataColumn ContractorRenewalsCrEffectiveDate = new DataColumn("ContractorRenewalsCrEffectiveDate", typeof(DateTime));

        public DataColumn ContractRenewalsConStartDate = new DataColumn("ContractRenewalsConStartDate", typeof(DateTime));

        public DataColumn ContractRenewalsConExpiryDate = new DataColumn("ContractRenewalsConExpiryDate", typeof(DateTime));

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

        public DataColumn ContractorCSalutation = new DataColumn("ContractorCSalutation", typeof(string));

        public DataColumn CcSalutation = new DataColumn("CcSalutation", typeof(string));

        public DataColumn ContractContractNo = new DataColumn("ContractContractNo", typeof(int));


        public MailmergeOdDownloadDataDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractorContractorSupplierNo,ContractorCTitle,ContractorCInitials,ContractorCFirstNames,ContractorCSurnameCompany,DriverName,ContractorCAddress,CPhoneDay,CPhoneNight,CMobile,CMobile2,PrimaryContact,CEmailAddress,ContractorCTaxRate,ContractorCIrdNo,CTaxRate,ContractorCIrdNo1,ContractConTitle,ContractorRenewalsCrEffectiveDate,ContractRenewalsConStartDate,ContractRenewalsConExpiryDate,OutletOName,OutletOAddress,OutletOTelephone,OutletOFax,OutletOManager,RegionRgnName,RegionRgnRcmManager,RegionRgnFax,RegionRgnTelephone,RegionRgnAddress,ContractorCSalutation,CcSalutation,ContractContractNo
				});
            ContractorContractorSupplierNo.AllowDBNull = true;
            CTaxRate.AllowDBNull = true;
            ContractorRenewalsCrEffectiveDate.AllowDBNull = true;
            ContractRenewalsConStartDate.AllowDBNull = true;
            ContractRenewalsConExpiryDate.AllowDBNull = true;
            ContractContractNo.AllowDBNull = true;

        }

        public MailmergeOdDownloadDataDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<MailmergeOdDownloadData> datas = dataSource as Metex.Core.EntityBindingList<MailmergeOdDownloadData>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(MailmergeOdDownloadData data)
        {
            DataRow row = this.NewRow();
            row["ContractorContractorSupplierNo"] = GetFieldValue(data.ContractorContractorSupplierNo);
            row["ContractorCTitle"] = GetFieldValue(data.ContractorCTitle);
            row["ContractorCInitials"] = GetFieldValue(data.ContractorCInitials);
            row["ContractorCFirstNames"] = GetFieldValue(data.ContractorCFirstNames);
            row["ContractorCSurnameCompany"] = GetFieldValue(data.ContractorCSurnameCompany);
            row["DriverName"] = GetFieldValue(data.DriverName);
            row["ContractorCAddress"] = GetFieldValue(data.ContractorCAddress);
            row["CPhoneDay"] = GetFieldValue(data.CPhoneDay);
            row["CPhoneNight"] = GetFieldValue(data.CPhoneNight);
            row["CMobile"] = GetFieldValue(data.CMobile);
            row["CMobile2"] = GetFieldValue(data.CMobile2);
            row["PrimaryContact"] = GetFieldValue(data.PrimaryContact);
            row["CEmailAddress"] = GetFieldValue(data.CEmailAddress);
            row["ContractorCTaxRate"] = GetFieldValue(data.ContractorCTaxRate);
            row["ContractorCIrdNo"] = GetFieldValue(data.ContractorCIrdNo);
            row["CTaxRate"] = GetFieldValue(data.CTaxRate);
            row["ContractorCIrdNo1"] = GetFieldValue(data.ContractorCIrdNo1);
            row["ContractConTitle"] = GetFieldValue(data.ContractConTitle);
            row["ContractorRenewalsCrEffectiveDate"] = GetFieldValue(data.ContractorRenewalsCrEffectiveDate);
            row["ContractRenewalsConStartDate"] = GetFieldValue(data.ContractRenewalsConStartDate);
            row["ContractRenewalsConExpiryDate"] = GetFieldValue(data.ContractRenewalsConExpiryDate);
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
            row["ContractorCSalutation"] = GetFieldValue(data.ContractorCSalutation);
            row["CcSalutation"] = GetFieldValue(data.CcSalutation);
            row["ContractContractNo"] = GetFieldValue(data.ContractContractNo);
            return row;
        }
    }
}
