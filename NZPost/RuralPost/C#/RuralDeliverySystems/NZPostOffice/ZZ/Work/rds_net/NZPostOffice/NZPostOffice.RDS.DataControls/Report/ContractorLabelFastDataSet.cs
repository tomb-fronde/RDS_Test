using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractorLabelFast
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
        public string CAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string Label
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class ContractorLabelFastDataSet : ReportDataSet<ContractorLabelFast>
    {

        public DataColumn CTitle = new DataColumn("CTitle", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn CAddress = new DataColumn("CAddress", typeof(string));

        public DataColumn Label = new DataColumn("Label", typeof(string));


        public ContractorLabelFastDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CTitle,CSurnameCompany,CFirstNames,CInitials,CAddress,Label
				});

        }

        public ContractorLabelFastDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractorLabelFast> datas = dataSource as Metex.Core.EntityBindingList<ContractorLabelFast>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ContractorLabelFast data)
        {
            DataRow row = this.NewRow();
            row["CTitle"] = GetFieldValue(data.CTitle);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["CAddress"] = GetFieldValue(data.CAddress);
            row["Label"] = GetFieldValue(data.Label);
            return row;
        }
    }
}
