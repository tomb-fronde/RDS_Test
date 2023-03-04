using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPsCustListTown
    {
        public string SurCompName
        {
            get
            {
                return string.Empty;
            }
        }
        public string Initials
        {
            get
            {
                return string.Empty;
            }
        }
        public string PropTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string RoadNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string RoadAlpha
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
        public string RdNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string MailTown
        {
            get
            {
                return string.Empty;
            }
        }
        public string Recipients
        {
            get
            {
                return string.Empty;
            }
        }
        public string Categories
        {
            get
            {
                return string.Empty;
            }
        }
        public int KiwimailQty
        {
            get
            {
                return 0;
            }
        }
        public int Business
        {
            get
            {
                return 0;
            }
        }
        public int Residential
        {
            get
            {
                return 0;
            }
        }
        public int Farmer
        {
            get
            {
                return 0;
            }
        }
        public int CustCounter
        {
            get
            {
                return 0;
            }
        }
        public int DelCounter
        {
            get
            {
                return 0;
            }
        }
        public int CmbSeq
        {
            get
            {
                return 0;
            }
        }
        public string RoadUnit
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class PsCustListTownDataSet : ReportDataSet<PsCustListTown>
    {

        public DataColumn SurCompName = new DataColumn("SurCompName", typeof(string));

        public DataColumn Initials = new DataColumn("Initials", typeof(string));

        public DataColumn PropTitle = new DataColumn("PropTitle", typeof(string));

        public DataColumn RoadNo = new DataColumn("RoadNo", typeof(string));

        public DataColumn RoadAlpha = new DataColumn("RoadAlpha", typeof(string));

        public DataColumn RoadName = new DataColumn("RoadName", typeof(string));

        public DataColumn Locality = new DataColumn("Locality", typeof(string));

        public DataColumn RdNo = new DataColumn("RdNo", typeof(string));

        public DataColumn MailTown = new DataColumn("MailTown", typeof(string));

        public DataColumn Recipients = new DataColumn("Recipients", typeof(string));

        public DataColumn Categories = new DataColumn("Categories", typeof(string));

        public DataColumn KiwimailQty = new DataColumn("KiwimailQty", typeof(int));

        public DataColumn Business = new DataColumn("Business", typeof(int));

        public DataColumn Residential = new DataColumn("Residential", typeof(int));

        public DataColumn Farmer = new DataColumn("Farmer", typeof(int));

        public DataColumn CustCounter = new DataColumn("CustCounter", typeof(int));

        public DataColumn DelCounter = new DataColumn("DelCounter", typeof(int));

        public DataColumn CmbSeq = new DataColumn("CmbSeq", typeof(int));

        public DataColumn RoadUnit = new DataColumn("RoadUnit", typeof(string));


        public PsCustListTownDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				SurCompName,Initials,PropTitle,RoadNo,RoadAlpha,RoadName,Locality,RdNo,MailTown,Recipients,Categories,KiwimailQty,Business,Residential,Farmer,CustCounter,DelCounter,CmbSeq,RoadUnit
				});
            KiwimailQty.AllowDBNull = true;
            Business.AllowDBNull = true;
            Residential.AllowDBNull = true;
            Farmer.AllowDBNull = true;
            CustCounter.AllowDBNull = true;
            DelCounter.AllowDBNull = true;
            CmbSeq.AllowDBNull = true;

        }

        public PsCustListTownDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PsCustListTown> datas = dataSource as Metex.Core.EntityBindingList<PsCustListTown>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PsCustListTown data)
        {
            DataRow row = this.NewRow();
            row["SurCompName"] = GetFieldValue(data.SurCompName);
            row["Initials"] = GetFieldValue(data.Initials);
            row["PropTitle"] = GetFieldValue(data.PropTitle);
            row["RoadNo"] = GetFieldValue(data.RoadNo);
            row["RoadAlpha"] = GetFieldValue(data.RoadAlpha);
            row["RoadName"] = GetFieldValue(data.RoadName);
            row["Locality"] = GetFieldValue(data.Locality);
            row["RdNo"] = GetFieldValue(data.RdNo);
            row["MailTown"] = GetFieldValue(data.MailTown);
            row["Recipients"] = GetFieldValue(data.Recipients);
            row["Categories"] = GetFieldValue(data.Categories);
            row["KiwimailQty"] = GetFieldValue(data.KiwimailQty);
            row["Business"] = GetFieldValue(data.Business);
            row["Residential"] = GetFieldValue(data.Residential);
            row["Farmer"] = GetFieldValue(data.Farmer);
            row["CustCounter"] = GetFieldValue(data.CustCounter);
            row["DelCounter"] = GetFieldValue(data.DelCounter);
            row["CmbSeq"] = GetFieldValue(data.CmbSeq);
            row["RoadUnit"] = GetFieldValue(data.RoadUnit);
            return row;
        }
    }
}
