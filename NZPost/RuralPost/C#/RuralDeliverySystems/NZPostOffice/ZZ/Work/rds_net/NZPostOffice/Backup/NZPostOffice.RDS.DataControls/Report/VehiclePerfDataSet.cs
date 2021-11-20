using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehiclePerf
    {
        public string A
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class VehiclePerfDataSet : ReportDataSet<VehiclePerf>
    {

        public DataColumn A = new DataColumn("A", typeof(string));


        public VehiclePerfDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				A
				});

        }

        public VehiclePerfDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerf> datas = dataSource as Metex.Core.EntityBindingList<VehiclePerf>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VehiclePerf data)
        {
            DataRow row = this.NewRow();
            row["A"] = GetFieldValue(data.A);
            return row;
        }
    }
}
