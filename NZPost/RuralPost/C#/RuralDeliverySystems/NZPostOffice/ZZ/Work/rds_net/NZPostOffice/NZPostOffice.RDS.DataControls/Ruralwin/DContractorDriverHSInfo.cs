using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Jan-2014:  NEW
    // Displays summary H&S information about a contractor's drivers
    // Displayed as a (new) tab in the WContractor2001 window
    // Contains Add and Remove buttons to add and remove drivers
    
	public partial class DContractorDriverHSInfo : Metex.Windows.DataUserControl
	{
		public DContractorDriverHSInfo()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_contractor )
		{
            return RetrieveCore<ContractorDriverHSInfo>(new List<ContractorDriverHSInfo>
				(ContractorDriverHSInfo.GetAllContractorDriverHSInfo( in_contractor )));
		}

        private void cb_view_Click(object sender, EventArgs e)
        {
/*
            WDriverInfoMaint wDriverInfo;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            int nDriverNo;
*/
            int? nSelectedDriver;
            string sSelectedDriver;

            nSelectedDriver = (int?)this.grid.SelectedRows[0].Cells["driver_no"].Value;
            sSelectedDriver = (nSelectedDriver == null) ? "NULL" : nSelectedDriver.ToString();
            MessageBox.Show("cb_view Clicked \n\n"
                            + "nSelectedDriver = " + sSelectedDriver);
/*
            nDriverNo = (int)nSelectedDriver;

            Cursor.Current = Cursors.WaitCursor;

            // Create criteria
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("driver_no", nDriverNo);
            lnv_msg.of_addcriteria(lnv_Criteria);
            // Build title
            //            string sTitle = "Driver: " + nDriverNo.ToString()+" Maintenance";
            //            // Open contract window if contract with title=ls_title not open
            //            if (!(StaticVariables.gnv_app.of_findwindow(ls_title, "w_contract2001") != null))
            //            {
            StaticMessage.PowerObjectParm = lnv_msg;
            wDriverInfo = new WDriverInfoMaint();
            wDriverInfo.MdiParent = StaticVariables.MainMDI;
            wDriverInfo.Show();
 */
         }

        private void cb_add_Click(object sender, EventArgs e)
        {
            MessageBox.Show("cb_add Clicked");
        }

        private void cb_remove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("cb_remove Clicked");
        }
	}
}
