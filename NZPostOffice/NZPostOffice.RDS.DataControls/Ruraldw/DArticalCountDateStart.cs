using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.DataControls;
//?////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DArticalCountDateStart : Metex.Windows.DataUserControl
	{
        // TJB  May-2015: RPCR_093 bugfix (tweak)
        // Modified contractno to be blank when empty (in designer)
        //
        // TJB  RPCR_093  30-Mar-2015
        // [Re-]Added Contract_no to designer.
        //
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

        private int regionIDLastSelectedIndex = -1;
        private int rgcodeLastSelectedIndex = -1;

        public event EventHandler SelectedItemChanged;
 
        public DArticalCountDateStart()
        {
            InitializeComponent();
            //!InitializeDropdown();

            //!this.Load += new EventHandler(DArticalCountDateStart_Load);
            //this.RetrieveEnd += new EventHandler(DArticalCountDateStart_Load);
            
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
                this.Load += new EventHandler(DArticalCountDateStart_Load);
            }

            base.OnHandleCreated(e);
        }

        private void DArticalCountDateStart_Load(object sender, EventArgs e)
        {
            this.region_id.DropDownStyle = ComboBoxStyle.DropDownList;
            this.rg_code.DropDownStyle = ComboBoxStyle.DropDownList;

            this.region_id.SelectedIndexChanged += new EventHandler(region_id_SelectedIndexChanged);
            this.rg_code.SelectedIndexChanged += new EventHandler(rg_code_SelectedIndexChanged);
        }

		private void InitializeDropdown()
		{
			region_id.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

        void rg_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemChanged != null && this.rg_code.SelectedIndex != -1 && this.rg_code.SelectedIndex != rgcodeLastSelectedIndex)
            {
                region_id.Focus();
                SelectedItemChanged(sender, e);

                rgcodeLastSelectedIndex = this.rg_code.SelectedIndex;
            }
        }

        void region_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemChanged != null && this.region_id.SelectedIndex != -1 && this.region_id.SelectedIndex != regionIDLastSelectedIndex)
            {
                rg_code.Focus();
                SelectedItemChanged(sender, e);

                regionIDLastSelectedIndex = this.region_id.SelectedIndex;
            } 
        }

        public event EventHandler TextBoxLostFocus;
        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }

		public override int Retrieve( )
        {
			return RetrieveCore<ArticalCountDateStart>(ArticalCountDateStart.GetAllArticalCountDateStart());
		}
	}
}
