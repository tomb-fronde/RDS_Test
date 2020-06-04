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
    // TJB RPCR_151 May-2020
    // Added pay_related_Enter() and pay_related_Leave()
    // These set/clear the checkBox1 which is bound to InPayRelated in entity ContractorFull
    // The state of this checkbox is examined by dw_owner_driver_ItemFocusChanged 
    // in WContractor2001 to determine if focus is on the pay-related group of fields.
    // NOTE:
    // CheckBox1 added in designer.  It's 'visible' property must be 'true', but it
    // is hidded by placing it off the displayed part of the DContractorFull window.

    public partial class DContractorFull : Metex.Windows.DataUserControl
    {
        public DContractorFull()
        {
            InitializeComponent();
            //InitializeDropdown();
            this.c_phone_day.LostFocus += new System.EventHandler(this.c_phone_day_LostFocus);
            this.c_phone_night.LostFocus += new System.EventHandler(this.c_phone_night_LostFocus);
            this.c_ird_no.LostFocus += new System.EventHandler(this.c_ird_no_LostFocus);
            this.c_gst_number.LostFocus += new System.EventHandler(this.c_gst_number_LostFocus);

            this.c_bank_account_no.Enter += new EventHandler(pay_related_Enter);
            this.c_bank_account_no.Leave += new EventHandler(pay_related_Leave);
            this.c_ird_no.Enter += new EventHandler(pay_related_Enter);
            this.c_ird_no.Leave += new EventHandler(pay_related_Leave);
            this.c_gst_number.Enter += new EventHandler(pay_related_Enter);
            this.c_gst_number.Leave += new EventHandler(pay_related_Leave);
            this.c_tax_rate.Enter += new EventHandler(pay_related_Enter);
            this.c_tax_rate.Leave += new EventHandler(pay_related_Leave);
            this.c_witholding_tax_certificate.Enter += new EventHandler(pay_related_Enter);
            this.c_witholding_tax_certificate.Leave += new EventHandler(pay_related_Leave);

            // TJB  RD7_0034   21-July-2009
            //    Changed type of c_salutation and c_address controls to Textbox from RichTextbos
            //    - done to enable cut/copy/paste right-click menu
            //    - no features of the RichTextbox appear to be used, so there's no need to retain in
            //    Changes initially in DContractorFull.designer.cs but file rewritten by designer
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
            #region c_witholding_tax_certificate
            System.Data.DataTable sourceTable1 = new System.Data.DataTable();
            sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(string))
			});
            sourceTable1.Rows.Add(new object[] { "Yes", "Y" });
            sourceTable1.Rows.Add(new object[] { "No", "N" });
            sourceTable1.Rows.Add(new object[] { "Exempt", "X" });
            this.c_witholding_tax_certificate.DataSource = sourceTable1;
            this.c_witholding_tax_certificate.DisplayMember = "Display";
            this.c_witholding_tax_certificate.ValueMember = "Value";
            #endregion

        }

        public event EventHandler TextBoxLostFocus;

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }

		public int Retrieve( int? in_contractor )
        {
            int rc;
            rc = RetrieveCore<ContractorFull>(ContractorFull.GetAllContractorFull(in_contractor));
            return rc;
        }

        // TJB RPCR_151 May-2020: NEW
        private void pay_related_Enter(object sender, System.EventArgs e)
        {
            //MessageBox.Show("pay_related_Enter");
            this.checkBox1.Checked = true;
        }

        // TJB RPCR_151 May-2020: NEW
        private void pay_related_Leave(object sender, System.EventArgs e)
        {
            //MessageBox.Show("pay_related_Leave");
            this.checkBox1.Checked = false;
        }

       private void c_ird_no_LostFocus(object sender, System.EventArgs e)
        {
            string ls_temp = this.c_ird_no.Text;
            if (ls_temp.Length > 8)
            {
                this.c_ird_no.Mask = "000-000-009";
            }
            else
            {
                this.c_ird_no.Mask = "00-000-0009";
            }
        }
        private void c_gst_number_LostFocus(object sender, System.EventArgs e)
        {
            string ls_temp = this.c_gst_number.Text;
            if (ls_temp.Length > 8)
            {
                this.c_gst_number.Mask = "000-000-009";
            }
            else
            {
                this.c_gst_number.Mask = "00-000-0009";
            }
        }
        private void c_phone_day_LostFocus(object sender, System.EventArgs e)
        {
            string ls_temp = this.c_phone_day.Text;
            if (ls_temp != null && ls_temp.Length > 1 && ls_temp.Substring(0, 2) == "02")
            {
                this.c_phone_day.Mask = "(000) 000-0009";
            }
            else
            {
                this.c_phone_day.Mask = "(00) 000-00009";
            }
        }
        private void c_phone_night_LostFocus(object sender, System.EventArgs e)
        {
            string ls_temp = this.c_phone_night.Text;
            if (ls_temp != null && ls_temp.Length > 1 && ls_temp.Substring(0, 2) == "02")
            {
                this.c_phone_night.Mask = "(000) 000-0009";
            }
            else
            {
                this.c_phone_night.Mask = "(00) 000-00009";
            }
        }
    }
}
