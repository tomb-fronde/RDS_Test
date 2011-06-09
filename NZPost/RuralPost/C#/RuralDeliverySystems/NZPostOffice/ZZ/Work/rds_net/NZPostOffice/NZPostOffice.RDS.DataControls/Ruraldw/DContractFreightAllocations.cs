using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_025  8-June-2011: New
    // See also  RDS/Windows/Ruralwin/WContract2001
    //      and  Entity/Ruraldw/FreightAllocations
    // TJB 9-June-2011: Changed layout to more-closely match spec

    public partial class DContractFreightAllocations : Metex.Windows.DataUserControl
    {
        public DContractFreightAllocations()
        {
            InitializeComponent();

            this.ecl_pct.DataBindings[0].FormatString = this.ecl_pct.EditMask;
            this.reachmedia_pct.DataBindings[0].FormatString = this.reachmedia_pct.EditMask;
            this.psg_pct.DataBindings[0].FormatString = this.psg_pct.EditMask;

            this.ecl_pct.Leave += new System.EventHandler(this.pct_Leave);
            this.reachmedia_pct.Leave += new System.EventHandler(this.pct_Leave);
            this.psg_pct.Leave += new System.EventHandler(this.pct_Leave);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            base.OnHandleCreated(e);
        }

        private void InitializeDropdown()
        {
            pbu_id.AssignDropdownType<DDddwPbuCodes>();
        }

        public int Retrieve(int? contract_no)
        {
            int rc = RetrieveCore<FreightAllocations>(new List<FreightAllocations>
                        (FreightAllocations.GetAllFreightAllocations( contract_no )));
            calc_total_pct();
            return rc;
        }

        private void pct_Leave(object sender, EventArgs e)
        {
            calc_total_pct();
        }

        // Dynamically updates the Total PCT value 
        // as entries are made to the individual percentages.
        // If the total is not == 100 display a warning message.
        private void calc_total_pct()
        {
            int nTotPct = 0;
            char [] space = { ' ' };

            string vEclPct = ecl_pct.Value.Trim(space);
            string vRchPct = reachmedia_pct.Value.Trim(space);
            string vPsgPct = psg_pct.Value.Trim(space);

            if ( vEclPct != null && vEclPct != "")
                nTotPct += Int32.Parse(vEclPct);

            if (vRchPct != null && vRchPct != "")
                nTotPct += Int32.Parse(vRchPct);

            if (vPsgPct != null && vPsgPct != "")
                nTotPct += Int32.Parse(vPsgPct);

            string sTotPct = nTotPct.ToString();
            tot_pct.Text = sTotPct;

            if (nTotPct == 100)
                totmsg.Visible = false;
            else
                totmsg.Visible = true;
        }

        // Called from wContract2001 when a new Freight Allowance 
        // record is created.  Sets a default PBU value.
        public void set_selected_pbu(int? pbuID)
        {
            if (pbuID == null)
                this.pbu_id.SelectedIndex = -1;
            else
                this.pbu_id.Value = pbuID;

            this.AcceptText();
        }

    }
}
