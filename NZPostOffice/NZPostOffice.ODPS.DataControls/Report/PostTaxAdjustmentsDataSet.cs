using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RPostTaxAdjustments
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
        public string PbuCode
        {
            get
            {
                return string.Empty;
            }
        }
        public string AcCode
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Amount
        {
            get
            {
                return 0;
            }
        }
        public decimal REAmount
        {
            get
            {
                return 0;
            }
        }
    }
    public class PostTaxAdjustmentsDataSet : ReportDataSet<PostTaxAdjustments>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn PbuCode = new DataColumn("PbuCode", typeof(string));

        public DataColumn AcCode = new DataColumn("AcCode", typeof(string));

        public DataColumn Amount = new DataColumn("Amount", typeof(decimal));

        public DataColumn REAmount = new DataColumn("REAmount", typeof(decimal));


        public PostTaxAdjustmentsDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,CSurnameCompany,CFirstNames,CInitials,PbuCode,AcCode,Amount,REAmount
				});
            ContractNo.AllowDBNull = true;
            Amount.AllowDBNull = true;

        }

        public PostTaxAdjustmentsDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PostTaxAdjustments> datas = dataSource as Metex.Core.EntityBindingList<PostTaxAdjustments>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PostTaxAdjustments data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["PbuCode"] = GetFieldValue(data.PbuCode);
            row["AcCode"] = GetFieldValue(data.AcCode);
            row["Amount"] = GetFieldValue(data.Amount);
            row["REAmount"] = GetFieldValue(data.REAmount);
            return row;
        }
    }
}
