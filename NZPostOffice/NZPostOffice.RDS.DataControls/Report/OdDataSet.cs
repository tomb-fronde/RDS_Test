using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class ROd
    {
        public int ContractContractNo
        {
            get
            {
                return 0;
            }
        }
        public string ContractConTitle
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
        public string ContractorCAddress
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class OdDataSet : ReportDataSet<Od>
    {

        public DataColumn ContractContractNo = new DataColumn("ContractContractNo", typeof(int));

        public DataColumn ContractConTitle = new DataColumn("ContractConTitle", typeof(string));

        public DataColumn ContractorCSurnameCompany = new DataColumn("ContractorCSurnameCompany", typeof(string));

        public DataColumn ContractorCAddress = new DataColumn("ContractorCAddress", typeof(string));


        public OdDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractContractNo,ContractConTitle,ContractorCSurnameCompany,ContractorCAddress
				});
            ContractContractNo.AllowDBNull = true;

        }

        public OdDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Od> datas = dataSource as Metex.Core.EntityBindingList<Od>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Od data)
        {
            DataRow row = this.NewRow();
            row["ContractContractNo"] = GetFieldValue(data.ContractContractNo);
            row["ContractConTitle"] = GetFieldValue(data.ContractConTitle);
            row["ContractorCSurnameCompany"] = GetFieldValue(data.ContractorCSurnameCompany);
            row["ContractorCAddress"] = GetFieldValue(data.ContractorCAddress);
            return row;
        }
    }
}
