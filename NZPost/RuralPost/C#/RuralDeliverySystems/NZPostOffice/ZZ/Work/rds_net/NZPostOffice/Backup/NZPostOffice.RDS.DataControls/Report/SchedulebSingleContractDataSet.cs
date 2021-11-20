using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{
    // TJB Release 7.1.10.3 Sep-2013
    // Added PrsKey

    public class RSchedulebSingleContract
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
        public decimal ConRenewalPaymentValue
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
        public string GstNumber
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal PieceRatePrRate
        {
            get
            {
                return 0;
            }
        }
        public string PieceRateTypePrtDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string PieceRateSupplierPrsDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string PieceRateTypePrtCode
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrsKey
        {
            get
            {
                return 0;
            }
        }
    }
    public class SchedulebSingleContractDataSet : ReportDataSet<SchedulebSingleContract>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn ConRenewalPaymentValue = new DataColumn("ConRenewalPaymentValue", typeof(decimal));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn GstNumber = new DataColumn("GstNumber", typeof(string));

        public DataColumn PieceRatePrRate = new DataColumn("PieceRatePrRate", typeof(decimal));

        public DataColumn PieceRateTypePrtDescription = new DataColumn("PieceRateTypePrtDescription", typeof(string));

        public DataColumn PieceRateSupplierPrsDescription = new DataColumn("PieceRateSupplierPrsDescription", typeof(string));

        public DataColumn PieceRateTypePrtCode = new DataColumn("PieceRateTypePrtCode", typeof(string));

        public DataColumn PrsKey = new DataColumn("PrsKey", typeof(int));


        public SchedulebSingleContractDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ContractSeqNumber,ConRenewalPaymentValue,ConTitle,GstNumber,PieceRatePrRate,PieceRateTypePrtDescription,PieceRateSupplierPrsDescription,PieceRateTypePrtCode,PrsKey
				});
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            ConRenewalPaymentValue.AllowDBNull = true;
            PieceRatePrRate.AllowDBNull = true;

        }

        public SchedulebSingleContractDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<SchedulebSingleContract> datas = dataSource as Metex.Core.EntityBindingList<SchedulebSingleContract>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(SchedulebSingleContract data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["ConRenewalPaymentValue"] = GetFieldValue(data.ConRenewalPaymentValue);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["GstNumber"] = GetFieldValue(data.GstNumber);
            row["PieceRatePrRate"] = GetFieldValue(data.PieceRatePrRate);
            row["PieceRateTypePrtDescription"] = GetFieldValue(data.PieceRateTypePrtDescription);
            row["PieceRateSupplierPrsDescription"] = GetFieldValue(data.PieceRateSupplierPrsDescription);
            row["PieceRateTypePrtCode"] = GetFieldValue(data.PieceRateTypePrtCode);
            row["PrsKey"] = GetFieldValue(data.PrsKey);
            return row;
        }
    }
}
