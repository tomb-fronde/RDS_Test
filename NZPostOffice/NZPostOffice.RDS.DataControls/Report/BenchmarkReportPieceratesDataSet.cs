using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Report
{
    // TJB  RPCR_054 Aug-2013:  NEW

    public class RBenchmarkReportPiecerates
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int PrsKey
        {
            get
            {
                return 0;
            }
        }
        public string PrsDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal YtdPaid
        {
            get
            {
                return 0;
            }
        }
    }
    public class BenchmarkReportPieceratesDataSet : ReportDataSet<BenchmarkReportPiecerates>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn PrsKey = new DataColumn("PrsKey", typeof(int));

        public DataColumn PrsDescription = new DataColumn("PrsDescription", typeof(string));

        public DataColumn YtdPaid = new DataColumn("YtdPaid", typeof(decimal));


        public BenchmarkReportPieceratesDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,PrsKey,PrsDescription,YtdPaid
				});
            YtdPaid.AllowDBNull = true;

        }

        public BenchmarkReportPieceratesDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<BenchmarkReportPiecerates> datas = dataSource as Metex.Core.EntityBindingList<BenchmarkReportPiecerates>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public BenchmarkReportPieceratesDataSet(BenchmarkReportPiecerates obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<BenchmarkReportPiecerates> list = new Metex.Core.EntityBindingList<BenchmarkReportPiecerates>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public BenchmarkReportPieceratesDataSet(BenchmarkReportPiecerates[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<BenchmarkReportPiecerates> list = new Metex.Core.EntityBindingList<BenchmarkReportPiecerates>();
            foreach(BenchmarkReportPiecerates d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(BenchmarkReportPiecerates data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["PrsKey"] = GetFieldValue(data.PrsKey);
            row["PrsDescription"] = GetFieldValue(data.PrsDescription);
            row["YtdPaid"] = GetFieldValue(data.YtdPaid);
            return row;
        }
    }
}
