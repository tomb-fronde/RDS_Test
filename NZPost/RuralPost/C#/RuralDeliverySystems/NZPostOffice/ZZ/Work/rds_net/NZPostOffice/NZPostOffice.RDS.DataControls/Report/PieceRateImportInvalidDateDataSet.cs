using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPieceRateImportInvalidDate
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
        public decimal Totalcost
        {
            get
            {
                return 0;
            }
        }
    }
    public class PieceRateImportInvalidDateDataSet : ReportDataSet<PieceRateImportInvalidDate>
    {

        public DataColumn Contract = new DataColumn("Contract", typeof(string));

        public DataColumn PrdDate = new DataColumn("PrdDate", typeof(DateTime));

        public DataColumn REPrdDate = new DataColumn("REPrdDate", typeof(DateTime));

        public DataColumn PrtCode = new DataColumn("PrtCode", typeof(string));

        public DataColumn PrdQuantity = new DataColumn("PrdQuantity", typeof(int));

        public DataColumn REPrdQuantity = new DataColumn("REPrdQuantity", typeof(int));

        public DataColumn PrdCost = new DataColumn("PrdCost", typeof(decimal));

        public DataColumn REPrdCost = new DataColumn("REPrdCost", typeof(decimal));

        public DataColumn REPrdRdCost = new DataColumn("REPrdRdCost", typeof(decimal));

        public DataColumn PrtKey = new DataColumn("PrtKey", typeof(int));

        public DataColumn REPrtKey = new DataColumn("REPrtKey", typeof(int));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Errormsg = new DataColumn("Errormsg", typeof(string));

        public DataColumn Totalcost = new DataColumn("Totalcost", typeof(decimal));

        public DataColumn RETotalcost = new DataColumn("RETotalcost", typeof(decimal));


        public PieceRateImportInvalidDateDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Contract,PrdDate,REPrdDate,PrtCode,PrdQuantity,REPrdQuantity,PrdCost,REPrdCost,REPrdRdCost,PrtKey,REPrtKey,ContractNo,REContractNo,Errormsg,Totalcost,RETotalcost
				});
            PrdDate.AllowDBNull = true;
            REPrdDate.AllowDBNull = true;
            PrdQuantity.AllowDBNull = true;
            REPrdQuantity.AllowDBNull = true;
            PrdCost.AllowDBNull = true;
            REPrdCost.AllowDBNull = true;
            REPrdRdCost.AllowDBNull = true;
            PrtKey.AllowDBNull = true;
            REPrtKey.AllowDBNull = true;
            ContractNo.AllowDBNull = true;
            REContractNo.AllowDBNull = true;
            Totalcost.AllowDBNull = true;
            RETotalcost.AllowDBNull = true;

        }

        public PieceRateImportInvalidDateDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PieceRateImportInvalidDate> datas = dataSource as Metex.Core.EntityBindingList<PieceRateImportInvalidDate>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PieceRateImportInvalidDate data)
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
            row["Errormsg"] = GetFieldValue(data.Errormsg);
            row["Totalcost"] = GetFieldValue(data.Totalcost);
            //row["RETotalcost"] = GetFieldValue(data.RETotalcost);
            return row;
        }
    }
}
