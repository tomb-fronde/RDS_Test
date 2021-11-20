using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehiclePerfCapacity
    {
        public int Upto2litres
        {
            get
            {
                return 0;
            }
        }
        public int At2litres
        {
            get
            {
                return 0;
            }
        }
        public int At2litres23litres
        {
            get
            {
                return 0;
            }
        }
        public int Over3litres
        {
            get
            {
                return 0;
            }
        }
        public int Unknown
        {
            get
            {
                return 0;
            }
        }
    }
    public class VehiclePerfCapacityDataSet : ReportDataSet<VehiclePerfCapacity>
    {

        public DataColumn Upto2litres = new DataColumn("Upto2litres", typeof(int));

        public DataColumn At2litres = new DataColumn("At2litres", typeof(int));

        public DataColumn At2litres23litres = new DataColumn("At2litres23litres", typeof(int));

        public DataColumn Over3litres = new DataColumn("Over3litres", typeof(int));

        public DataColumn Unknown = new DataColumn("Unknown", typeof(int));


        public VehiclePerfCapacityDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Upto2litres,At2litres,At2litres23litres,Over3litres,Unknown
				});
            Upto2litres.AllowDBNull = true;
            At2litres.AllowDBNull = true;
            At2litres23litres.AllowDBNull = true;
            Over3litres.AllowDBNull = true;
            Unknown.AllowDBNull = true;

        }

        public VehiclePerfCapacityDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfCapacity> datas = dataSource as Metex.Core.EntityBindingList<VehiclePerfCapacity>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public VehiclePerfCapacityDataSet(VehiclePerfCapacity obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<VehiclePerfCapacity> list = new Metex.Core.EntityBindingList<VehiclePerfCapacity>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public VehiclePerfCapacityDataSet(VehiclePerfCapacity[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfCapacity> list = new Metex.Core.EntityBindingList<VehiclePerfCapacity>();
            foreach (VehiclePerfCapacity d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(VehiclePerfCapacity data)
        {
            DataRow row = this.NewRow();
            row["Upto2litres"] = GetFieldValue(data.Upto2litres);
            row["At2litres"] = GetFieldValue(data.At2litres);
            row["At2litres23litres"] = GetFieldValue(data.At2litres23litres);
            row["Over3litres"] = GetFieldValue(data.Over3litres);
            row["Unknown"] = GetFieldValue(data.Unknown);
            return row;
        }
    }
}
