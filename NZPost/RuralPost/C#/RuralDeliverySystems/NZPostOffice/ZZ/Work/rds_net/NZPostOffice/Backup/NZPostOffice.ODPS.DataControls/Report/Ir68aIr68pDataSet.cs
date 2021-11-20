using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RIr68aIr68p
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int REContractNo
        {
            get
            {
                return 0;
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
        public decimal Gptaxable
        {
            get
            {
                return 0;
            }
        }
        public decimal REGptaxable
        {
            get
            {
                return 0;
            }
        }
        public decimal Gpnontaxable
        {
            get
            {
                return 0;
            }
        }
        public decimal REGpnontaxable
        {
            get
            {
                return 0;
            }
        }
        public decimal Paye
        {
            get
            {
                return 0;
            }
        }
        public decimal REPaye
        {
            get
            {
                return 0;
            }
        }
        public decimal Acc
        {
            get
            {
                return 0;
            }
        }
        public decimal REAcc
        {
            get
            {
                return 0;
            }
        }
    }
    public class Ir68aIr68pDataSet : ReportDataSet<Ir68aIr68p>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn Gptaxable = new DataColumn("Gptaxable", typeof(decimal));

        public DataColumn REGptaxable = new DataColumn("REGptaxable", typeof(decimal));

        public DataColumn Gpnontaxable = new DataColumn("Gpnontaxable", typeof(decimal));

        public DataColumn REGpnontaxable = new DataColumn("REGpnontaxable", typeof(decimal));

        public DataColumn Paye = new DataColumn("Paye", typeof(decimal));

        public DataColumn REPaye = new DataColumn("REPaye", typeof(decimal));

        public DataColumn Acc = new DataColumn("Acc", typeof(decimal));

        public DataColumn REAcc = new DataColumn("REAcc", typeof(decimal));


        public Ir68aIr68pDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,CSurnameCompany,CFirstNames,CInitials,Gptaxable,REGptaxable,Gpnontaxable,REGpnontaxable,Paye,REPaye,Acc,REAcc
				});
            ContractNo.AllowDBNull = true;
            Gptaxable.AllowDBNull = true;
            Gpnontaxable.AllowDBNull = true;
            Paye.AllowDBNull = true;
            Acc.AllowDBNull = true;

        }

        public Ir68aIr68pDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Ir68aIr68p> datas = dataSource as Metex.Core.EntityBindingList<Ir68aIr68p>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Ir68aIr68p data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["Gptaxable"] = GetFieldValue(data.Gptaxable);
            row["REGptaxable"] = GetFieldValue(data.REGptaxable);
            row["Gpnontaxable"] = GetFieldValue(data.Gpnontaxable);
            row["REGpnontaxable"] = GetFieldValue(data.REGpnontaxable);
            row["Paye"] = GetFieldValue(data.Paye);
            row["REPaye"] = GetFieldValue(data.REPaye);
            row["Acc"] = GetFieldValue(data.Acc);
            row["REAcc"] = GetFieldValue(data.REAcc);
            return row;
        }
    }
}
