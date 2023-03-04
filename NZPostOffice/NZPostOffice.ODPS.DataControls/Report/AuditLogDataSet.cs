using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RAuditLog
    {
        public int AKey
        {
            get
            {
                return 0;
            }
        }
        public int REAKey
        {
            get
            {
                return 0;
            }
        }
        public DateTime ADatetime
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime READatetime
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string AUserid
        {
            get
            {
                return string.Empty;
            }
        }
        public int AContract
        {
            get
            {
                return 0;
            }
        }
        public int REAContract
        {
            get
            {
                return 0;
            }
        }
        public int AContractor
        {
            get
            {
                return 0;
            }
        }
        public int REAContractor
        {
            get
            {
                return 0;
            }
        }
        public string AComment
        {
            get
            {
                return string.Empty;
            }
        }
        public string AOldvalue
        {
            get
            {
                return string.Empty;
            }
        }
        public string ANewvalue
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime Ddate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REDdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class AuditLogDataSet : ReportDataSet<AuditLog>
    {

        public DataColumn AKey = new DataColumn("AKey", typeof(int));

        public DataColumn REAKey = new DataColumn("REAKey", typeof(int));

        public DataColumn ADatetime = new DataColumn("ADatetime", typeof(DateTime));

        public DataColumn READatetime = new DataColumn("READatetime", typeof(DateTime));

        public DataColumn AUserid = new DataColumn("AUserid", typeof(string));

        public DataColumn AContract = new DataColumn("AContract", typeof(int));

        public DataColumn REAContract = new DataColumn("REAContract", typeof(int));

        public DataColumn AContractor = new DataColumn("AContractor", typeof(int));

        public DataColumn REAContractor = new DataColumn("REAContractor", typeof(int));

        public DataColumn AComment = new DataColumn("AComment", typeof(string));

        public DataColumn AOldvalue = new DataColumn("AOldvalue", typeof(string));

        public DataColumn ANewvalue = new DataColumn("ANewvalue", typeof(string));

        public DataColumn Ddate = new DataColumn("Ddate", typeof(DateTime));

        public DataColumn REDdate = new DataColumn("REDdate", typeof(DateTime));


        public AuditLogDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				AKey,REAKey,ADatetime,READatetime,AUserid,AContract,REAContract,AContractor,REAContractor,AComment,AOldvalue,ANewvalue,Ddate,REDdate
				});
            AKey.AllowDBNull = true;
            ADatetime.AllowDBNull = true;
            AContract.AllowDBNull = true;
            AContractor.AllowDBNull = true;
            Ddate.AllowDBNull = true;

        }

        public AuditLogDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<AuditLog> datas = dataSource as Metex.Core.EntityBindingList<AuditLog>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(AuditLog data)
        {
            DataRow row = this.NewRow();
            row["AKey"] = GetFieldValue(data.AKey);
            row["REAKey"] = GetFieldValue(data.REAKey);
            row["ADatetime"] = GetFieldValue(data.ADatetime);
            row["READatetime"] = GetFieldValue(data.READatetime);
            row["AUserid"] = GetFieldValue(data.AUserid);
            row["AContract"] = GetFieldValue(data.AContract);
            row["REAContract"] = GetFieldValue(data.REAContract);
            row["AContractor"] = GetFieldValue(data.AContractor);
            row["REAContractor"] = GetFieldValue(data.REAContractor);
            row["AComment"] = GetFieldValue(data.AComment);
            row["AOldvalue"] = GetFieldValue(data.AOldvalue);
            row["ANewvalue"] = GetFieldValue(data.ANewvalue);
            row["Ddate"] = GetFieldValue(data.Ddate);
            row["REDdate"] = GetFieldValue(data.REDdate);
            return row;
        }
    }
}
