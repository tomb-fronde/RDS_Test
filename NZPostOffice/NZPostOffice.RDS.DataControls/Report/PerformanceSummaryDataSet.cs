using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPerformanceSummary
    {
        public string Detailtype
        {
            get
            {
                return string.Empty;
            }
        }
        public string Datagroup
        {
            get
            {
                return string.Empty;
            }
        }
        public int Sortorder
        {
            get
            {
                return 0;
            }
        }
        public int Monthact
        {
            get
            {
                return 0;
            }
        }
        public int Monthbud
        {
            get
            {
                return 0;
            }
        }
        public string Description
        {
            get
            {
                return string.Empty;
            }
        }
        public int Ytdact
        {
            get
            {
                return 0;
            }
        }
        public int Ytdbud
        {
            get
            {
                return 0;
            }
        }
    }
    public class PerformanceSummaryDataSet : ReportDataSet<PerformanceSummary>
    {

        public DataColumn Detailtype = new DataColumn("Detailtype", typeof(string));

        public DataColumn Datagroup = new DataColumn("Datagroup", typeof(string));

        public DataColumn Sortorder = new DataColumn("Sortorder", typeof(int));

        public DataColumn Monthact = new DataColumn("Monthact", typeof(int));

        public DataColumn Monthbud = new DataColumn("Monthbud", typeof(int));

        public DataColumn Description = new DataColumn("Description", typeof(string));

        public DataColumn Ytdact = new DataColumn("Ytdact", typeof(int));

        public DataColumn Ytdbud = new DataColumn("Ytdbud", typeof(int));


        public PerformanceSummaryDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Detailtype,Datagroup,Sortorder,Monthact,Monthbud,Description,Ytdact,Ytdbud
				});
            Sortorder.AllowDBNull = true;
            Monthact.AllowDBNull = true;
            Monthbud.AllowDBNull = true;
            Ytdact.AllowDBNull = true;
            Ytdbud.AllowDBNull = true;

        }

        public PerformanceSummaryDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PerformanceSummary> datas = dataSource as Metex.Core.EntityBindingList<PerformanceSummary>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PerformanceSummary data)
        {
            DataRow row = this.NewRow();
            row["Detailtype"] = GetFieldValue(data.Detailtype);
            row["Datagroup"] = GetFieldValue(data.Datagroup);
            row["Sortorder"] = GetFieldValue(data.Sortorder);
            row["Monthact"] = GetFieldValue(data.Monthact);
            row["Monthbud"] = GetFieldValue(data.Monthbud);
            row["Description"] = GetFieldValue(data.Description);
            row["Ytdact"] = GetFieldValue(data.Ytdact);
            row["Ytdbud"] = GetFieldValue(data.Ytdbud);
            return row;
        }
    }
}
