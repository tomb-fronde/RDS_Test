using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPsUnoccupiedRpt
    {
        public string RoadNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string RoadName
        {
            get
            {
                return string.Empty;
            }
        }
        public string Locality
        {
            get
            {
                return string.Empty;
            }
        }
        public string Town
        {
            get
            {
                return string.Empty;
            }
        }
        public string RdNo
        {
            get
            {
                return string.Empty;
            }
        }
        public int ConNo
        {
            get
            {
                return 0;
            }
        }
        public string ConDet
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class PsUnoccupiedRptDataSet : ReportDataSet<PsUnoccupiedRpt>
    {

        public DataColumn RoadNo = new DataColumn("RoadNo", typeof(string));

        public DataColumn RoadName = new DataColumn("RoadName", typeof(string));

        public DataColumn Locality = new DataColumn("Locality", typeof(string));

        public DataColumn Town = new DataColumn("Town", typeof(string));

        public DataColumn RdNo = new DataColumn("RdNo", typeof(string));

        public DataColumn ConNo = new DataColumn("ConNo", typeof(int));

        public DataColumn ConDet = new DataColumn("ConDet", typeof(string));


        public PsUnoccupiedRptDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RoadNo,RoadName,Locality,Town,RdNo,ConNo,ConDet
				});
            ConNo.AllowDBNull = true;

        }

        public PsUnoccupiedRptDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PsUnoccupiedRpt> datas = dataSource as Metex.Core.EntityBindingList<PsUnoccupiedRpt>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PsUnoccupiedRpt data)
        {
            DataRow row = this.NewRow();
            row["RoadNo"] = GetFieldValue(data.RoadNo);
            row["RoadName"] = GetFieldValue(data.RoadName);
            row["Locality"] = GetFieldValue(data.Locality);
            row["Town"] = GetFieldValue(data.Town);
            row["RdNo"] = GetFieldValue(data.RdNo);
            row["ConNo"] = GetFieldValue(data.ConNo);
            row["ConDet"] = GetFieldValue(data.ConDet);
            return row;
        }
    }
}
