using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehiclePerfFueltype
    {
        public string Fueltype
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
    public class VehiclePerfFueltypeDataSet : ReportDataSet<VehiclePerfFueltype>
    {

        public DataColumn Fueltype = new DataColumn("Fueltype", typeof(string));

        public DataColumn Novehicles = new DataColumn("Novehicles", typeof(int));


        public VehiclePerfFueltypeDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Fueltype,Novehicles
				});
            Novehicles.AllowDBNull = true;

        }

        public VehiclePerfFueltypeDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfFueltype> datas = dataSource as Metex.Core.EntityBindingList<VehiclePerfFueltype>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public VehiclePerfFueltypeDataSet(VehiclePerfFueltype obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<VehiclePerfFueltype> list = new Metex.Core.EntityBindingList<VehiclePerfFueltype>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public VehiclePerfFueltypeDataSet(VehiclePerfFueltype[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfFueltype> list = new Metex.Core.EntityBindingList<VehiclePerfFueltype>();
            foreach (VehiclePerfFueltype d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(VehiclePerfFueltype data)
        {
            DataRow row = this.NewRow();
            row["Fueltype"] = GetFieldValue(data.Fueltype);
            row["Novehicles"] = GetFieldValue(data.Novehicles);
            return row;
        }
    }
}
