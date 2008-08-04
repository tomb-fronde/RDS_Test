using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class ROutletLabel
    {
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string OManager
        {
            get
            {
                return string.Empty;
            }
        }
        public string OtOutletType
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class OutletLabelDataSet : ReportDataSet<OutletLabel>
    {

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn OAddress = new DataColumn("OAddress", typeof(string));

        public DataColumn OManager = new DataColumn("OManager", typeof(string));

        public DataColumn OtOutletType = new DataColumn("OtOutletType", typeof(string));


        public OutletLabelDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				OName,OAddress,OManager,OtOutletType
				});

        }

        public OutletLabelDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<OutletLabel> datas = dataSource as Metex.Core.EntityBindingList<OutletLabel>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(OutletLabel data)
        {
            DataRow row = this.NewRow();
            row["OName"] = GetFieldValue(data.OName);
            row["OAddress"] = GetFieldValue(data.OAddress);
            row["OManager"] = GetFieldValue(data.OManager);
            row["OtOutletType"] = GetFieldValue(data.OtOutletType);
            return row;
        }
    }
}
