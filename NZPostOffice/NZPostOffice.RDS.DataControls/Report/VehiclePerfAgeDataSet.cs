using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RVehiclePerfAge
    {
        public int Ageupto5years
        {
            get
            {
                return 0;
            }
        }
        public int Age5to10years
        {
            get
            {
                return 0;
            }
        }
        public int Ageover10years
        {
            get
            {
                return 0;
            }
        }
        public int Ageunknown
        {
            get
            {
                return 0;
            }
        }
    }
    public class VehiclePerfAgeDataSet : ReportDataSet<VehiclePerfAge>
    {

        public DataColumn Ageupto5years = new DataColumn("Ageupto5years", typeof(int));

        public DataColumn Age5to10years = new DataColumn("Age5to10years", typeof(int));

        public DataColumn Ageover10years = new DataColumn("Ageover10years", typeof(int));

        public DataColumn Ageunknown = new DataColumn("Ageunknown", typeof(int));


        public VehiclePerfAgeDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Ageupto5years,Age5to10years,Ageover10years,Ageunknown
				});
            Ageupto5years.AllowDBNull = true;
            Age5to10years.AllowDBNull = true;
            Ageover10years.AllowDBNull = true;
            Ageunknown.AllowDBNull = true;

        }

        public VehiclePerfAgeDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfAge> datas = dataSource as Metex.Core.EntityBindingList<VehiclePerfAge>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public VehiclePerfAgeDataSet(VehiclePerfAge obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<VehiclePerfAge> list = new Metex.Core.EntityBindingList<VehiclePerfAge>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public VehiclePerfAgeDataSet(VehiclePerfAge[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<VehiclePerfAge> list = new Metex.Core.EntityBindingList<VehiclePerfAge>();
            foreach (VehiclePerfAge d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(VehiclePerfAge data)
        {
            DataRow row = this.NewRow();
            row["Ageupto5years"] = GetFieldValue(data.Ageupto5years);
            row["Age5to10years"] = GetFieldValue(data.Age5to10years);
            row["Ageover10years"] = GetFieldValue(data.Ageover10years);
            row["Ageunknown"] = GetFieldValue(data.Ageunknown);
            return row;
        }
    }
}
