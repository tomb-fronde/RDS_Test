using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Report;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RVehiclePerf : Metex.Windows.DataUserControl
	{
		public RVehiclePerf()
		{
			InitializeComponent();
		}

        public int Retrieve(int? inRegion, int? inOutlet, int? inRengroup, int? inContract_type)
        {
            int ret = 0;// RetrieveCore<VehiclePerf>(new List<VehiclePerf>(VehiclePerf.GetAllVehiclePerf()));

            DataTable ageDT = new NZPostOffice.RDS.DataControls.Report.VehiclePerfAgeDataSet(VehiclePerfAge.GetAllVehiclePerfAge(inRegion, inOutlet, inRengroup, inContract_type));
            //!this.reRVehiclePerf.Subreports["RERVehiclePerfAge.rpt"].SetDataSource(ageDT);

            VehiclePerfFueltype[] fuelTypes = VehiclePerfFueltype.GetAllVehiclePerfFueltype(inRegion, inOutlet, inRengroup, inContract_type);
            List<VehiclePerfFueltype> list = new List<VehiclePerfFueltype>(fuelTypes);
            list.Sort(new Comparison<VehiclePerfFueltype>(this.Sorter));
            DataTable fuelTypeDT = new VehiclePerfFueltypeDataSet(list.ToArray());
            //!this.reRVehiclePerf.Subreports["RERVehiclePerfFueltype.rpt"].SetDataSource(fuelTypeDT);

            DataTable capacityDT = new VehiclePerfCapacityDataSet(VehiclePerfCapacity.GetAllVehiclePerfCapacity(inRegion, inOutlet, inRengroup, inContract_type));
            //!this.reRVehiclePerf.Subreports["RERVehiclePerfCapacity.rpt"].SetDataSource(capacityDT);

            DataTable vehicletypeDT = new VehiclePerfVehicletypeDataSet(VehiclePerfVehicletype.GetAllVehiclePerfVehicletype(inRegion,inOutlet,inRengroup,inContract_type));
            //!this.reRVehiclePerf.Subreports["RERVehiclePerfVehicletype.rpt"].SetDataSource(vehicletypeDT);

            try
            {
                this.reRVehiclePerf.Subreports["RERVehiclePerfAge.rpt"].SetDataSource(ageDT);
            }
            catch (Exception e)
            {

            }
            try{
                this.reRVehiclePerf.Subreports["RERVehiclePerfFueltype.rpt"].SetDataSource(fuelTypeDT);
            }
                catch (Exception e)
            {}
            try
            {
                this.reRVehiclePerf.Subreports["RERVehiclePerfCapacity.rpt"].SetDataSource(capacityDT);
            }
            catch (Exception e) { }
            try
            {
                this.reRVehiclePerf.Subreports["RERVehiclePerfVehicletype.rpt"].SetDataSource(vehicletypeDT);
            }
            catch (Exception e) { }

                viewer.RefreshReport();
           

            return ret;
		}
        private int Sorter(VehiclePerfFueltype s1, VehiclePerfFueltype s2)
        {
            return string.Compare(s1.Fueltype, s2.Fueltype);
        }
	}
}
