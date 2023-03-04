using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RPsNonumberCon
    {
        public string CustSurname
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
        public string Towncity
        {
            get
            {
                return string.Empty;
            }
        }
        public string RdId
        {
            get
            {
                return string.Empty;
            }
        }
        public string PhoneDay
        {
            get
            {
                return string.Empty;
            }
        }
        public string PhoneNight
        {
            get
            {
                return string.Empty;
            }
        }
        public string PhoneMob
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class PsNonumberConDataSet : ReportDataSet<PsNonumberCon>
    {

        public DataColumn CustSurname = new DataColumn("CustSurname", typeof(string));

        public DataColumn RoadName = new DataColumn("RoadName", typeof(string));

        public DataColumn Locality = new DataColumn("Locality", typeof(string));

        public DataColumn Towncity = new DataColumn("Towncity", typeof(string));

        public DataColumn RdId = new DataColumn("RdId", typeof(string));

        public DataColumn PhoneDay = new DataColumn("PhoneDay", typeof(string));

        public DataColumn PhoneNight = new DataColumn("PhoneNight", typeof(string));

        public DataColumn PhoneMob = new DataColumn("PhoneMob", typeof(string));


        public PsNonumberConDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CustSurname,RoadName,Locality,Towncity,RdId,PhoneDay,PhoneNight,PhoneMob
				});

        }

        public PsNonumberConDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PsNonumberCon> datas = dataSource as Metex.Core.EntityBindingList<PsNonumberCon>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PsNonumberCon data)
        {
            DataRow row = this.NewRow();
            row["CustSurname"] = GetFieldValue(data.CustSurname);
            row["RoadName"] = GetFieldValue(data.RoadName);
            row["Locality"] = GetFieldValue(data.Locality);
            row["Towncity"] = GetFieldValue(data.Towncity);
            row["RdId"] = GetFieldValue(data.RdId);
            row["PhoneDay"] = GetFieldValue(data.PhoneDay);
            row["PhoneNight"] = GetFieldValue(data.PhoneNight);
            row["PhoneMob"] = GetFieldValue(data.PhoneMob);
            return row;
        }
    }
}
