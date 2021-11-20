using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class ROutletReportCriteria
    {
        public int Regionid
        {
            get
            {
                return 0;
            }
        }
        public string RgnName
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class OutletReportCriteriaDataSet : ReportDataSet<OutletReportCriteria>
    {

        public DataColumn Regionid = new DataColumn("Regionid", typeof(int));

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));


        public OutletReportCriteriaDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Regionid,RgnName
				});
            Regionid.AllowDBNull = true;

        }

        public OutletReportCriteriaDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<OutletReportCriteria> datas = dataSource as Metex.Core.EntityBindingList<OutletReportCriteria>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(OutletReportCriteria data)
        {
            DataRow row = this.NewRow();
            row["Regionid"] = GetFieldValue(data.Regionid);
            row["RgnName"] = GetFieldValue(data.RgnName);
            return row;
        }
    }
}
