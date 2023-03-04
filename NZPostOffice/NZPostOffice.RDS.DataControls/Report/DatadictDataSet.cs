using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralbase;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RDatadict
    {
        public string Tname
        {
            get
            {
                return string.Empty;
            }
        }
        public string Cname
        {
            get
            {
                return string.Empty;
            }
        }
        public string Coltype
        {
            get
            {
                return string.Empty;
            }
        }
        public int Length
        {
            get
            {
                return 0;
            }
        }
        public int Syslength
        {
            get
            {
                return 0;
            }
        }
        public string Nulls
        {
            get
            {
                return string.Empty;
            }
        }
        public string InPrimaryKey
        {
            get
            {
                return string.Empty;
            }
        }
        public int Colno
        {
            get
            {
                return 0;
            }
        }
    }
    public class DatadictDataSet : ReportDataSet<Datadict>
    {

        public DataColumn Tname = new DataColumn("Tname", typeof(string));

        public DataColumn Cname = new DataColumn("Cname", typeof(string));

        public DataColumn Coltype = new DataColumn("Coltype", typeof(string));

        public DataColumn Length = new DataColumn("Length", typeof(int));

        public DataColumn Syslength = new DataColumn("Syslength", typeof(int));

        public DataColumn Nulls = new DataColumn("Nulls", typeof(string));

        public DataColumn InPrimaryKey = new DataColumn("InPrimaryKey", typeof(string));

        public DataColumn Colno = new DataColumn("Colno", typeof(int));


        public DatadictDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Tname,Cname,Coltype,Length,Syslength,Nulls,InPrimaryKey,Colno
				});
            Length.AllowDBNull = true;
            Syslength.AllowDBNull = true;
            Colno.AllowDBNull = true;

        }

        public DatadictDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Datadict> datas = dataSource as Metex.Core.EntityBindingList<Datadict>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Datadict data)
        {
            DataRow row = this.NewRow();
            row["Tname"] = GetFieldValue(data.Tname);
            row["Cname"] = GetFieldValue(data.Cname);
            row["Coltype"] = GetFieldValue(data.Coltype);
            row["Length"] = GetFieldValue(data.Length);
            row["Syslength"] = GetFieldValue(data.Syslength);
            row["Nulls"] = GetFieldValue(data.Nulls);
            row["InPrimaryKey"] = GetFieldValue(data.InPrimaryKey);
            row["Colno"] = GetFieldValue(data.Colno);
            return row;
        }
    }
}
