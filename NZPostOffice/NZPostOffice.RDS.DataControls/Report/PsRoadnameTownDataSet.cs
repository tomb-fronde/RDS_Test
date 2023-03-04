using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPsRoadnameTown
    {
        public string RoadName
        {
            get
            {
                return string.Empty;
            }
        }
        public string RtId
        {
            get
            {
                return string.Empty;
            }
        }
        public string TcName
        {
            get
            {
                return string.Empty;
            }
        }
        public int DelPoints
        {
            get
            {
                return 0;
            }
        }
    }
    public class PsRoadnameTownDataSet : ReportDataSet<PsRoadnameTown>
    {

        public DataColumn RoadName = new DataColumn("RoadName", typeof(string));

        public DataColumn RtId = new DataColumn("RtId", typeof(string));

        public DataColumn TcName = new DataColumn("TcName", typeof(string));

        public DataColumn DelPoints = new DataColumn("DelPoints", typeof(int));


        public PsRoadnameTownDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RoadName,RtId,TcName,DelPoints
				});
            DelPoints.AllowDBNull = true;

        }

        public PsRoadnameTownDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PsRoadnameTown> datas = dataSource as Metex.Core.EntityBindingList<PsRoadnameTown>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PsRoadnameTown data)
        {
            DataRow row = this.NewRow();
            row["RoadName"] = GetFieldValue(data.RoadName);
            row["RtId"] = GetFieldValue(data.RtId);
            row["TcName"] = GetFieldValue(data.TcName);
            row["DelPoints"] = GetFieldValue(data.DelPoints);
            return row;
        }
    }
}
