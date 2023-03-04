using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    public partial class RVehicleAge : Metex.Windows.DataUserControl
    {
        public RVehicleAge()
        {
            InitializeComponent();
        }

        public int Retrieve(int? inRegion, int? inOutlet, int? inRenewalGroup, int? inContractType)
        {
            DataTable table2;
            DataTable multiDT = new DataTable();

            List<VehicleAge> list = new List<VehicleAge>(VehicleAge.GetAllVehicleAge(inRegion, inOutlet, inRenewalGroup, inContractType));
            int ret = RetrieveCore<VehicleAge>(list);

            foreach (VehicleAge vAge in list)
            {
                table2 = new NZPostOffice.RDS.DataControls.Report.VehicleAgedetailsDataSet(VehicleAgedetails.GetAllVehicleAgedetails(vAge.ContractNo, vAge.ConActiveSequence, vAge.VehicleNo));
                multiDT.Merge(table2);
            }

            if (multiDT.Rows.Count > 0)
            {
                this.reRVehicleAge.Subreports["RERVehicleAgedetails.rpt"].SetDataSource(multiDT);
                this.viewer.RefreshReport();
            }
            return ret;
        }

        public void RVehicleAge_RetrieveEnd(object sender, System.EventArgs e)
        {
            table = new NZPostOffice.RDS.DataControls.Report.VehicleAgeDataSet(this.bindingSource.DataSource);
            this.reRVehicleAge.SetDataSource(table);

            //this.viewer.RefreshReport();
        }
    }
}
