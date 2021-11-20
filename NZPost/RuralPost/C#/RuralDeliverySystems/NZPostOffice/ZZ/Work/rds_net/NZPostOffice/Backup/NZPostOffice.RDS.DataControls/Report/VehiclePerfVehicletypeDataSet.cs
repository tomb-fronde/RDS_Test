using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehiclePerfVehicletype
    {
        public string Vehicletype
        {
            get
            {
                return string.Empty;
            }
        }
        public int Novehicles
        {
            get
            {
                return 0;
            }
        }
    }
    public class VehiclePerfVehicletypeDataSet : ReportDataSet<VehiclePerfVehicletype>
    {

        public DataColumn Vehicletype = new DataColumn("Vehicletype", typeof(string));

        public DataColumn Novehicles = new DataColumn("Novehicles", typeof(int));


        public VehiclePerfVehicletypeDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Vehicletype,Novehicles
				});
            Novehicles.AllowDBNull = true;

        }

        public VehiclePerfVehicletypeDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfVehicletype> datas = dataSource as Metex.Core.EntityBindingList<VehiclePerfVehicletype>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public VehiclePerfVehicletypeDataSet(VehiclePerfVehicletype obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<VehiclePerfVehicletype> list = new Metex.Core.EntityBindingList<VehiclePerfVehicletype>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public VehiclePerfVehicletypeDataSet(VehiclePerfVehicletype[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfVehicletype> list = new Metex.Core.EntityBindingList<VehiclePerfVehicletype>();
            foreach (VehiclePerfVehicletype d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(VehiclePerfVehicletype data)
        {
            DataRow row = this.NewRow();
            row["Vehicletype"] = GetFieldValue(data.Vehicletype);
            row["Novehicles"] = GetFieldValue(data.Novehicles);
            return row;
        }
    }
}
