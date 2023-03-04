using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPieceRateReport
    {
        public string PrsDescription
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
        public string PrtCode
        {
            get
            {
                return string.Empty;
            }
        }
        public int Monthvol
        {
            get
            {
                return 0;
            }
        }
        public decimal Monthcost
        {
            get
            {
                return 0;
            }
        }
        public int Ytdvol
        {
            get
            {
                return 0;
            }
        }
        public decimal Ytdcost
        {
            get
            {
                return 0;
            }
        }
    }
    public class PieceRateReportDataSet : ReportDataSet<PieceRateReport>
    {

        public DataColumn PrsDescription = new DataColumn("PrsDescription", typeof(string));

        public DataColumn PrtDescription = new DataColumn("PrtDescription", typeof(string));

        public DataColumn PrtCode = new DataColumn("PrtCode", typeof(string));

        public DataColumn Monthvol = new DataColumn("Monthvol", typeof(int));

        public DataColumn Monthcost = new DataColumn("Monthcost", typeof(decimal));

        public DataColumn Ytdvol = new DataColumn("Ytdvol", typeof(int));

        public DataColumn Ytdcost = new DataColumn("Ytdcost", typeof(decimal));


        public PieceRateReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				PrsDescription,PrtDescription,PrtCode,Monthvol,Monthcost,Ytdvol,Ytdcost
				});
            Monthvol.AllowDBNull = true;
            Monthcost.AllowDBNull = true;
            Ytdvol.AllowDBNull = true;
            Ytdcost.AllowDBNull = true;

        }

        public PieceRateReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PieceRateReport> datas = dataSource as Metex.Core.EntityBindingList<PieceRateReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PieceRateReport data)
        {
            DataRow row = this.NewRow();
            row["PrsDescription"] = GetFieldValue(data.PrsDescription);
            row["PrtDescription"] = GetFieldValue(data.PrtDescription);
            row["PrtCode"] = GetFieldValue(data.PrtCode);
            row["Monthvol"] = GetFieldValue(data.Monthvol);
            row["Monthcost"] = GetFieldValue(data.Monthcost);
            row["Ytdvol"] = GetFieldValue(data.Ytdvol);
            row["Ytdcost"] = GetFieldValue(data.Ytdcost);
            return row;
        }
    }
}
