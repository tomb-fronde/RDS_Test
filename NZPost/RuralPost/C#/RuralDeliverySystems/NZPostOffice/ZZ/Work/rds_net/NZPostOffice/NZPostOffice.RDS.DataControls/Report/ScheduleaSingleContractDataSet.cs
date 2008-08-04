using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RScheduleaSingleContract
    {
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
        public string CAddress
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
        public string ConReliefDriverName
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConReliefDriverAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConReliefDriverHomePhone
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
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractNo
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
        public string Lodgement
        {
            get
            {
                return string.Empty;
            }
        }
        public string Usah
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractSeqNumber
        {
            get
            {
                return 0;
            }
        }
        public string CInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public string CTitle
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
        public string CEmailAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string ContractorCMobile2
        {
            get
            {
                return string.Empty;
            }
        }
        public int CPrimeContact
        {
            get
            {
                return 0;
            }
        }
        public int RgCode
        {
            get
            {
                return 0;
            }
        }
        public string Compute1
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute2
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute3
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute4
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute5
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute6
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute7
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class ScheduleaSingleContractDataSet : ReportDataSet<ScheduleaSingleContract>
    {

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CAddress = new DataColumn("CAddress", typeof(string));

        public DataColumn CPhoneDay = new DataColumn("CPhoneDay", typeof(string));

        public DataColumn ConReliefDriverName = new DataColumn("ConReliefDriverName", typeof(string));

        public DataColumn ConReliefDriverAddress = new DataColumn("ConReliefDriverAddress", typeof(string));

        public DataColumn ConReliefDriverHomePhone = new DataColumn("ConReliefDriverHomePhone", typeof(string));

        public DataColumn ConStartDate = new DataColumn("ConStartDate", typeof(DateTime));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn Lodgement = new DataColumn("Lodgement", typeof(string));

        public DataColumn Usah = new DataColumn("Usah", typeof(string));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn CTitle = new DataColumn("CTitle", typeof(string));

        public DataColumn RgnRcmManager = new DataColumn("RgnRcmManager", typeof(string));

        public DataColumn CPhoneNight = new DataColumn("CPhoneNight", typeof(string));

        public DataColumn CMobile = new DataColumn("CMobile", typeof(string));

        public DataColumn CEmailAddress = new DataColumn("CEmailAddress", typeof(string));

        public DataColumn ContractorCMobile2 = new DataColumn("ContractorCMobile2", typeof(string));

        public DataColumn CPrimeContact = new DataColumn("CPrimeContact", typeof(int));

        public DataColumn RgCode = new DataColumn("RgCode", typeof(int));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(string));

        public DataColumn Compute2 = new DataColumn("Compute2", typeof(string));

        public DataColumn Compute3 = new DataColumn("Compute3", typeof(string));

        public DataColumn Compute4 = new DataColumn("Compute4", typeof(string));

        public DataColumn Compute5 = new DataColumn("Compute5", typeof(string));

        public DataColumn Compute6 = new DataColumn("Compute6", typeof(string));

        public DataColumn Compute7 = new DataColumn("Compute7", typeof(string));


        public ScheduleaSingleContractDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CSurnameCompany,CFirstNames,CAddress,CPhoneDay,ConReliefDriverName,ConReliefDriverAddress,ConReliefDriverHomePhone,ConStartDate,OName,ContractNo,ConTitle,Lodgement,Usah,ContractSeqNumber,CInitials,CTitle,RgnRcmManager,CPhoneNight,CMobile,CEmailAddress,ContractorCMobile2,CPrimeContact,RgCode,Compute1,Compute2,Compute3,Compute4,Compute5,Compute6,Compute7
				});
            ConStartDate.AllowDBNull = true;
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            CPrimeContact.AllowDBNull = true;
            RgCode.AllowDBNull = true;

        }

        public ScheduleaSingleContractDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ScheduleaSingleContract> datas = dataSource as Metex.Core.EntityBindingList<ScheduleaSingleContract>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ScheduleaSingleContract data)
        {
            DataRow row = this.NewRow();
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CAddress"] = GetFieldValue(data.CAddress);
            row["CPhoneDay"] = GetFieldValue(data.CPhoneDay);
            row["ConReliefDriverName"] = GetFieldValue(data.ConReliefDriverName);
            row["ConReliefDriverAddress"] = GetFieldValue(data.ConReliefDriverAddress);
            row["ConReliefDriverHomePhone"] = GetFieldValue(data.ConReliefDriverHomePhone);
            row["ConStartDate"] = GetFieldValue(data.ConStartDate);
            row["OName"] = GetFieldValue(data.OName);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["Lodgement"] = GetFieldValue(data.Lodgement);
            row["Usah"] = GetFieldValue(data.Usah);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["CTitle"] = GetFieldValue(data.CTitle);
            row["RgnRcmManager"] = GetFieldValue(data.RgnRcmManager);
            row["CPhoneNight"] = GetFieldValue(data.CPhoneNight);
            row["CMobile"] = GetFieldValue(data.CMobile);
            row["CEmailAddress"] = GetFieldValue(data.CEmailAddress);
            row["ContractorCMobile2"] = GetFieldValue(data.ContractorCMobile2);
            row["CPrimeContact"] = GetFieldValue(data.CPrimeContact);
            row["RgCode"] = GetFieldValue(data.RgCode);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["Compute2"] = GetFieldValue(data.Compute2);
            row["Compute3"] = GetFieldValue(data.Compute3);
            row["Compute4"] = GetFieldValue(data.Compute4);
            row["Compute5"] = GetFieldValue(data.Compute5);
            row["Compute6"] = GetFieldValue(data.Compute6);
            row["Compute7"] = GetFieldValue(data.Compute7);
            return row;
        }
    }
}
