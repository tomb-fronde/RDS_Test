using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class ROutletBaseOfficeReport
    {
        public int OutletOutletId
        {
            get
            {
                return 0;
            }
        }
        public int OutletOtCode
        {
            get
            {
                return 0;
            }
        }
        public int OutletRegionId
        {
            get
            {
                return 0;
            }
        }
        public string OutletOName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOTelephone
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOFax
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOManager
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletOResponsibilityCode
        {
            get
            {
                return string.Empty;
            }
        }
        public string OutletType
        {
            get
            {
                return string.Empty;
            }
        }
        public string RegionRgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OPhyAddress
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class OutletBaseOfficeReportDataSet : ReportDataSet<OutletBaseOfficeReport>
    {

        public DataColumn OutletOutletId = new DataColumn("OutletOutletId", typeof(int));

        public DataColumn OutletOtCode = new DataColumn("OutletOtCode", typeof(int));

        public DataColumn OutletRegionId = new DataColumn("OutletRegionId", typeof(int));

        public DataColumn OutletOName = new DataColumn("OutletOName", typeof(string));

        public DataColumn OutletOAddress = new DataColumn("OutletOAddress", typeof(string));

        public DataColumn OutletOTelephone = new DataColumn("OutletOTelephone", typeof(string));

        public DataColumn OutletOFax = new DataColumn("OutletOFax", typeof(string));

        public DataColumn OutletOManager = new DataColumn("OutletOManager", typeof(string));

        public DataColumn OutletOResponsibilityCode = new DataColumn("OutletOResponsibilityCode", typeof(string));

        public DataColumn OutletType = new DataColumn("OutletType", typeof(string));

        public DataColumn RegionRgnName = new DataColumn("RegionRgnName", typeof(string));

        public DataColumn OPhyAddress = new DataColumn("OPhyAddress", typeof(string));


        public OutletBaseOfficeReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				OutletOutletId,OutletOtCode,OutletRegionId,OutletOName,OutletOAddress,OutletOTelephone,OutletOFax,OutletOManager,OutletOResponsibilityCode,OutletType,RegionRgnName,OPhyAddress
				});
            OutletOutletId.AllowDBNull = true;
            OutletOtCode.AllowDBNull = true;
            OutletRegionId.AllowDBNull = true;

        }

        public OutletBaseOfficeReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<OutletBaseOfficeReport> datas = dataSource as Metex.Core.EntityBindingList<OutletBaseOfficeReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(OutletBaseOfficeReport data)
        {
            DataRow row = this.NewRow();
            row["OutletOutletId"] = GetFieldValue(data.OutletOutletId);
            row["OutletOtCode"] = GetFieldValue(data.OutletOtCode);
            row["OutletRegionId"] = GetFieldValue(data.OutletRegionId);
            row["OutletOName"] = GetFieldValue(data.OutletOName);
            row["OutletOAddress"] = GetFieldValue(data.OutletOAddress);
            row["OutletOTelephone"] = GetFieldValue(data.OutletOTelephone);
            row["OutletOFax"] = GetFieldValue(data.OutletOFax);
            row["OutletOManager"] = GetFieldValue(data.OutletOManager);
            row["OutletOResponsibilityCode"] = GetFieldValue(data.OutletOResponsibilityCode);
            row["OutletType"] = GetFieldValue(data.OutletType);
            row["RegionRgnName"] = GetFieldValue(data.RegionRgnName);
            row["OPhyAddress"] = GetFieldValue(data.OPhyAddress);
            return row;
        }
    }
}
