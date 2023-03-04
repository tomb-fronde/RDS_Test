using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RReportGenericRegOutletCriteria
    {
        public int RegionId
        {
            get
            {
                return 0;
            }
        }
        public int OutletId
        {
            get
            {
                return 0;
            }
        }
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public int OutletPicklist
        {
            get
            {
                return 0;
            }
        }
        public int CtKey
        {
            get
            {
                return 0;
            }
        }
        public int RgCode
        {
            get
            {
                return 0;
            }
        }
        public int SfKey
        {
            get
            {
                return 0;
            }
        }
        public int RgCode1
        {
            get
            {
                return 0;
            }
        }
        public int RgCode2
        {
            get
            {
                return 0;
            }
        }
        public DateTime MailCountDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int Blankforms
        {
            get
            {
                return 0;
            }
        }
        public bool Checked1
        {
            get
            {
                return false;
            }
        }
        public bool Checked2
        {
            get
            {
                return false;
            }
        }
    }
    public class ReportGenericRegOutletCriteriaDataSet : ReportDataSet<ReportGenericRegOutletCriteria>
    {

        public DataColumn RegionId = new DataColumn("RegionId", typeof(int));

        public DataColumn OutletId = new DataColumn("OutletId", typeof(int));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn OutletPicklist = new DataColumn("OutletPicklist", typeof(int));

        public DataColumn CtKey = new DataColumn("CtKey", typeof(int));

        public DataColumn RgCode = new DataColumn("RgCode", typeof(int));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn RgCode1 = new DataColumn("RgCode1", typeof(int));

        public DataColumn RgCode2 = new DataColumn("RgCode2", typeof(int));

        public DataColumn MailCountDate = new DataColumn("MailCountDate", typeof(DateTime));

        public DataColumn Blankforms = new DataColumn("Blankforms", typeof(int));

        public DataColumn Checked1 = new DataColumn("Checked1", typeof(bool));

        public DataColumn Checked2 = new DataColumn("Checked2", typeof(bool));


        public ReportGenericRegOutletCriteriaDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RegionId,OutletId,OName,OutletPicklist,CtKey,RgCode,SfKey,RgCode1,RgCode2,MailCountDate,Blankforms,Checked1,Checked2
				});
            RegionId.AllowDBNull = true;
            OutletId.AllowDBNull = true;
            OutletPicklist.AllowDBNull = true;
            CtKey.AllowDBNull = true;
            RgCode.AllowDBNull = true;
            SfKey.AllowDBNull = true;
            RgCode1.AllowDBNull = true;
            RgCode2.AllowDBNull = true;
            MailCountDate.AllowDBNull = true;
            Blankforms.AllowDBNull = true;
            Checked1.AllowDBNull = true;
            Checked2.AllowDBNull = true;

        }

        public ReportGenericRegOutletCriteriaDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ReportGenericRegOutletCriteria> datas = dataSource as Metex.Core.EntityBindingList<ReportGenericRegOutletCriteria>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ReportGenericRegOutletCriteria data)
        {
            DataRow row = this.NewRow();
            row["RegionId"] = GetFieldValue(data.RegionId);
            row["OutletId"] = GetFieldValue(data.OutletId);
            row["OName"] = GetFieldValue(data.OName);
            row["OutletPicklist"] = GetFieldValue(data.OutletPicklist);
            row["CtKey"] = GetFieldValue(data.CtKey);
            row["RgCode"] = GetFieldValue(data.RgCode);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["RgCode1"] = GetFieldValue(data.RgCode1);
            row["RgCode2"] = GetFieldValue(data.RgCode2);
            row["MailCountDate"] = GetFieldValue(data.MailCountDate);
            row["Blankforms"] = GetFieldValue(data.Blankforms);
            row["Checked1"] = GetFieldValue(data.Checked1);
            row["Checked2"] = GetFieldValue(data.Checked2);
            return row;
        }
    }
}
