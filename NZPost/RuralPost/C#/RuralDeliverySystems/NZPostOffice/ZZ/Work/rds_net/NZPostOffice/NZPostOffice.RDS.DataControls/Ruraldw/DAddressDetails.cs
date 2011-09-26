using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DAddressDetails : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_029  Oct-2011
        // Added checkbox for adr_location_ind to window.
        // Also added readonly textbox controls for road_type, road_suffix, 
        // suburb name and town name.  These are used to replace the combo boxes 
        // when NPAD is enabled so the fields look the same as the other header
        // textbox fields.

        // TJB  Sequencing review  Jan-2011
        // Added setDeliveryDays and setTerminalDays procedures

		public DAddressDetails()
		{
			InitializeComponent();
			InitializeDropdown();
        }

		private void InitializeDropdown()
		{
			sl_name.AssignDropdownType<DDddwSuburbNames>();
            rs_id.AssignDropdownType<DDddwRoadSuffix>();
            tc_id.AssignDropdownType<DDddwTownOnly>();
            rt_id.AssignDropdownType<DDddwRoadType>();
		}

		public int Retrieve( int? al_adr_id )
        {
			return RetrieveCore<AddressDetails>(AddressDetails.GetAllAddressDetails(al_adr_id));
		}

        public void setDeliveryDays(string sDelDays)
        {
            this.mon.Text = sDelDays.Substring(0, 1);
            this.tue.Text = sDelDays.Substring(1, 1);
            this.wed.Text = sDelDays.Substring(2, 1);
            this.thur.Text = sDelDays.Substring(3, 1);
            this.fri.Text = sDelDays.Substring(4, 1);
            this.sat.Text = sDelDays.Substring(5, 1);
            this.sunday.Text = sDelDays.Substring(6, 1);
            this.days.Text = sDelDays.Substring(7, 1);
        }

        public void setTerminalDays(string sTermDays)
        {
            this.compute_2.Text = sTermDays.Substring(2, 1);
            this.compute_3.Text = sTermDays.Substring(3, 1);
            this.compute_4.Text = sTermDays.Substring(4, 1);
            this.compute_5.Text = sTermDays.Substring(5, 1);
            this.compute_6.Text = sTermDays.Substring(6, 1);
            this.compute_7.Text = sTermDays.Substring(7, 1);
            this.compute_8.Text = sTermDays.Substring(8, 1);
            this.compute_1.Text = sTermDays.Substring(1, 1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
