using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPieceRateImportExeptionReport
    {
        public string Contract
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime PrdDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string PrtCode
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrdQuantity
        {
            get
            {
                return 0;
            }
        }
        public decimal PrdCost
        {
            get
            {
                return 0;
            }
        }
        public decimal PrdRdCost
        {
            get
            {
                return 0;
            }
        }
        public int PrtKey
        {
            get
            {
                return 0;
            }
        }
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string Errormsg
        {
            get
            {
                return string.Empty;
            }
        }

        public string PrtDescription
        {
            get
            {
                return string.Empty;
            }
        }
    }

    public class PieceRateImportExeptionReportDataSet : ReportDataSet<PieceRateImportExeptionReport>
    {

        public DataColumn Contract = new DataColumn("Contract", typeof(string));

        public DataColumn PrdDate = new DataColumn("PrdDate", typeof(DateTime));

        public DataColumn REPrdDate = new DataColumn("REPrdDate", typeof(DateTime));

        public DataColumn PrtCode = new DataColumn("PrtCode", typeof(string));

        public DataColumn PrdQuantity = new DataColumn("PrdQuantity", typeof(int));

        public DataColumn REPrdQuantity = new DataColumn("REPrdQuantity", typeof(int));

        public DataColumn PrdCost = new DataColumn("PrdCost", typeof(decimal));

        public DataColumn REPrdCost = new DataColumn("REPrdCost", typeof(decimal));

        public DataColumn PrdRdCost = new DataColumn("PrdRdCost", typeof(decimal));

        public DataColumn REPrdRdCost = new DataColumn("REPrdRdCost", typeof(decimal));

        public DataColumn PrtDescription = new DataColumn("PrtDescription", typeof(string));

        public DataColumn PrtKey = new DataColumn("PrtKey", typeof(int));

        public DataColumn REPrtKey = new DataColumn("REPrtKey", typeof(int));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Errormsg = new DataColumn("Errormsg", typeof(string));


        public PieceRateImportExeptionReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Contract,PrdDate,REPrdDate,PrtCode,PrdQuantity,REPrdQuantity,PrdCost,REPrdCost,PrdRdCost,REPrdRdCost,PrtKey,REPrtKey,ContractNo,REContractNo,PrtDescription,Errormsg
				});
            PrdDate.AllowDBNull = true;
            REPrdDate.AllowDBNull = true;
            PrdQuantity.AllowDBNull = true;
            REPrdQuantity.AllowDBNull = true;
            PrdCost.AllowDBNull = true;
            REPrdCost.AllowDBNull = true;
            PrdRdCost.AllowDBNull = true;
            REPrdRdCost.AllowDBNull = true;
            PrtKey.AllowDBNull = true;
            REPrtKey.AllowDBNull = true;
            ContractNo.AllowDBNull = true;
            REContractNo.AllowDBNull = true;
            PrtDescription.AllowDBNull = true;

        }

        public PieceRateImportExeptionReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PieceRateImportExeptionReport> datas = dataSource as Metex.Core.EntityBindingList<PieceRateImportExeptionReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PieceRateImportExeptionReport data)
        {
            DataRow row = this.NewRow();
            row["Contract"] = GetFieldValue(data.Contract);
            row["PrdDate"] = GetFieldValue(data.PrdDate);
            //row["REPrdDate"] = GetFieldValue(data.REPrdDate);
            row["PrtCode"] = GetFieldValue(data.PrtCode);
            row["PrdQuantity"] = GetFieldValue(data.PrdQuantity);
            //row["REPrdQuantity"] = GetFieldValue(data.REPrdQuantity);
            row["PrdCost"] = GetFieldValue(data.PrdCost);
            //row["REPrdCost"] = GetFieldValue(data.REPrdCost);
            row["PrdRdCost"] = GetFieldValue(data.PrdRdCost);
            //row["REPrdRdCost"] = GetFieldValue(data.REPrdRdCost);
            row["PrtKey"] = GetFieldValue(data.PrtKey);
            //row["REPrtKey"] = GetFieldValue(data.REPrtKey);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            //row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["PrtDescription"] = GetFieldValue(data.PrtDescription);
            row["Errormsg"] = GetFieldValue(data.Errormsg);

            return row;
        }
    }
}
