using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RNoCommencement
    {
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
        public DateTime CustDateFirstLoaded
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string ContractorCSurnameCompany
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
        public string ContractorCPhoneDay
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class NoCommencementDataSet : ReportDataSet<NoCommencement>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn CustTitle = new DataColumn("CustTitle", typeof(string));

        public DataColumn CustSurnameCompany = new DataColumn("CustSurnameCompany", typeof(string));

        public DataColumn CustInitials = new DataColumn("CustInitials", typeof(string));

        public DataColumn CustDateFirstLoaded = new DataColumn("CustDateFirstLoaded", typeof(DateTime));

        public DataColumn ContractorCSurnameCompany = new DataColumn("ContractorCSurnameCompany", typeof(string));

        public DataColumn ContractorCInitials = new DataColumn("ContractorCInitials", typeof(string));

        public DataColumn ContractorCPhoneDay = new DataColumn("ContractorCPhoneDay", typeof(string));


        public NoCommencementDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,CustTitle,CustSurnameCompany,CustInitials,CustDateFirstLoaded,ContractorCSurnameCompany,ContractorCInitials,ContractorCPhoneDay
				});
            ContractNo.AllowDBNull = true;
            CustDateFirstLoaded.AllowDBNull = true;

        }

        public NoCommencementDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<NoCommencement> datas = dataSource as Metex.Core.EntityBindingList<NoCommencement>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(NoCommencement data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["CustTitle"] = GetFieldValue(data.CustTitle);
            row["CustSurnameCompany"] = GetFieldValue(data.CustSurnameCompany);
            row["CustInitials"] = GetFieldValue(data.CustInitials);
            row["CustDateFirstLoaded"] = GetFieldValue(data.CustDateFirstLoaded);
            row["ContractorCSurnameCompany"] = GetFieldValue(data.ContractorCSurnameCompany);
            row["ContractorCInitials"] = GetFieldValue(data.ContractorCInitials);
            row["ContractorCPhoneDay"] = GetFieldValue(data.ContractorCPhoneDay);
            return row;
        }
    }
}
