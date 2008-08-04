using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustCountcriteria
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
    }
    public class CustCountcriteriaDataSet : ReportDataSet<CustCountcriteria>
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


        public CustCountcriteriaDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RegionId,OutletId,OName,OutletPicklist,CtKey,RgCode,SfKey,RgCode1,RgCode2,MailCountDate,Blankforms
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

        }

        public CustCountcriteriaDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustCountcriteria> datas = dataSource as Metex.Core.EntityBindingList<CustCountcriteria>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustCountcriteria data)
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
            return row;
        }
    }
}
