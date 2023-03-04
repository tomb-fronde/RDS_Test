using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RWithholdingTax
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
        public decimal Yearamount
        {
            get
            {
                return 0;
            }
        }
        public decimal REYearamount
        {
            get
            {
                return 0;
            }
        }
    }
    public class WithholdingTaxDataSet : ReportDataSet<WithholdingTax>
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

        public DataColumn Yearamount = new DataColumn("Yearamount", typeof(decimal));

        public DataColumn REYearamount = new DataColumn("REYearamount", typeof(decimal));


        public WithholdingTaxDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,CSurnameCompany,CFirstNames,CInitials,PbuCode,AcCode,Amount,REAmount,Yearamount,REYearamount
				});
            ContractNo.AllowDBNull = true;
            Amount.AllowDBNull = true;
            Yearamount.AllowDBNull = true;

        }

        public WithholdingTaxDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<WithholdingTax> datas = dataSource as Metex.Core.EntityBindingList<WithholdingTax>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(WithholdingTax data)
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
            row["Yearamount"] = GetFieldValue(data.Yearamount);
            row["REYearamount"] = GetFieldValue(data.REYearamount);
            return row;
        }
    }
}
