using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractorLabel
    {
        public string CTitle
        {
            get
            {
                return string.Empty;
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
        public string ContractorCAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string Clabel
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class ContractorLabelDataSet : ReportDataSet<ContractorLabel>
    {

        public DataColumn CTitle = new DataColumn("CTitle", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn ContractorCAddress = new DataColumn("ContractorCAddress", typeof(string));

        public DataColumn Clabel = new DataColumn("Clabel", typeof(string));


        public ContractorLabelDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CTitle,CSurnameCompany,CFirstNames,CInitials,ContractorCAddress,Clabel
				});

        }

        public ContractorLabelDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractorLabel> datas = dataSource as Metex.Core.EntityBindingList<ContractorLabel>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ContractorLabel data)
        {
            DataRow row = this.NewRow();
            row["CTitle"] = GetFieldValue(data.CTitle);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["ContractorCAddress"] = GetFieldValue(data.ContractorCAddress);
            row["Clabel"] = GetFieldValue(data.Clabel);
            return row;
        }
    }
}
