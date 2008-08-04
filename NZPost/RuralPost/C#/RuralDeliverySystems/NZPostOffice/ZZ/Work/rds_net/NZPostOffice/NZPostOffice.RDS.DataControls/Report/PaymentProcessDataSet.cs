using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPaymentProcess
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int ContractSeqNumber
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
        public int ContractorSupplierNo
        {
            get
            {
                return 0;
            }
        }
        public string ContractorName
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal ConRenewalPaymentValue
        {
            get
            {
                return 0;
            }
        }
        public decimal Adjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal Oldextn
        {
            get
            {
                return 0;
            }
        }
        public decimal Newextn
        {
            get
            {
                return 0;
            }
        }
        public decimal Allowances
        {
            get
            {
                return 0;
            }
        }
        public decimal Piecerates
        {
            get
            {
                return 0;
            }
        }
    }
    public class PaymentProcessDataSet : ReportDataSet<PaymentProcess>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn ContractorSupplierNo = new DataColumn("ContractorSupplierNo", typeof(int));

        public DataColumn ContractorName = new DataColumn("ContractorName", typeof(string));

        public DataColumn ConRenewalPaymentValue = new DataColumn("ConRenewalPaymentValue", typeof(decimal));

        public DataColumn Adjustments = new DataColumn("Adjustments", typeof(decimal));

        public DataColumn Oldextn = new DataColumn("Oldextn", typeof(decimal));

        public DataColumn Newextn = new DataColumn("Newextn", typeof(decimal));

        public DataColumn Allowances = new DataColumn("Allowances", typeof(decimal));

        public DataColumn Piecerates = new DataColumn("Piecerates", typeof(decimal));


        public PaymentProcessDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ContractSeqNumber,ConTitle,ContractorSupplierNo,ContractorName,ConRenewalPaymentValue,Adjustments,Oldextn,Newextn,Allowances,Piecerates
				});
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            ContractorSupplierNo.AllowDBNull = true;
            ConRenewalPaymentValue.AllowDBNull = true;
            Adjustments.AllowDBNull = true;
            Oldextn.AllowDBNull = true;
            Newextn.AllowDBNull = true;
            Allowances.AllowDBNull = true;
            Piecerates.AllowDBNull = true;

        }

        public PaymentProcessDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PaymentProcess> datas = dataSource as Metex.Core.EntityBindingList<PaymentProcess>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PaymentProcess data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["ContractorSupplierNo"] = GetFieldValue(data.ContractorSupplierNo);
            row["ContractorName"] = GetFieldValue(data.ContractorName);
            row["ConRenewalPaymentValue"] = GetFieldValue(data.ConRenewalPaymentValue);
            row["Adjustments"] = GetFieldValue(data.Adjustments);
            row["Oldextn"] = GetFieldValue(data.Oldextn);
            row["Newextn"] = GetFieldValue(data.Newextn);
            row["Allowances"] = GetFieldValue(data.Allowances);
            row["Piecerates"] = GetFieldValue(data.Piecerates);
            return row;
        }
    }
}
