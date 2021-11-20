using System;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddressMoveoutOccupants :WAddressTransferOccupants
    {
        #region Define
        public string is_source = String.Empty;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public RadioButton rb_rmd;

        public RadioButton rb_po;

        public RadioButton rb_validation;

        public RadioButton rb_duplication;

        public RadioButton rb_other;

        public TextBox sle_other;

        public GroupBox gb_source;

        #endregion

        public WAddressMoveoutOccupants()
        {
            this.InitializeComponent();
            dw_select.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //jlwang:end
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.rb_rmd = new RadioButton();
            this.rb_po = new RadioButton();
            this.rb_validation = new RadioButton();
            this.rb_duplication = new RadioButton();
            this.rb_other = new RadioButton();
            this.sle_other = new TextBox();
            this.gb_source = new GroupBox();
           
            this.Text = "Address Move Out: Select Customers";
            this.Height = 282;
            this.Width = 421;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // dw_select
            // 
            dw_select.Width = 233;
            dw_select.Top = 38;
            //!dw_select.DataObject.BorderStyle = BorderStyle.Fixed3D;
            // 
            // cb_ok
            // 
            cb_ok.Left = 248;
            // 
            // cb_cancel
            // 
            cb_cancel.Left = 331;
            // 
            // st_title
            // 
            st_title.Text = "The customer ( s) selected below will be moved off Rural Delivery.";
            st_title.Width = 243;
            // 
            // rb_rmd
            // 
            rb_rmd.Text = "RMD3/5";
            rb_rmd.BackColor = System.Drawing.SystemColors.Control;
            rb_rmd.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_rmd.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_rmd.Height = 16;
            rb_rmd.Width = 136;
            rb_rmd.Top = 62;
            rb_rmd.Left = 264;
            rb_rmd.Click += new EventHandler(rb_rmd_clicked);
            // 
            // rb_po
            // 
            rb_po.Text = "PO126";
            rb_po.BackColor = System.Drawing.SystemColors.Control;
            rb_po.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_po.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_po.Height = 16;
            rb_po.Width = 136;
            rb_po.Top = 86;
            rb_po.Left = 264;
            rb_po.Click += new EventHandler(rb_po_clicked);
            // 
            // rb_validation
            // 
            rb_validation.Text = "O/D Validation";
            rb_validation.BackColor = System.Drawing.SystemColors.Control;
            rb_validation.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_validation.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_validation.Height = 16;
            rb_validation.Width = 136;
            rb_validation.Top = 110;
            rb_validation.Left = 264;
            rb_validation.Click += new EventHandler(rb_validation_clicked);
            // 
            // rb_duplication
            // 
            rb_duplication.Text = "Duplication";
            rb_duplication.BackColor = System.Drawing.SystemColors.Control;
            rb_duplication.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_duplication.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_duplication.Height = 16;
            rb_duplication.Width = 136;
            rb_duplication.Top = 134;
            rb_duplication.Left = 264;
            rb_duplication.Click += new EventHandler(rb_duplication_clicked);
            // 
            // rb_other
            // 
            rb_other.Text = "Other";
            rb_other.BackColor = System.Drawing.SystemColors.Control;
            rb_other.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_other.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_other.Height = 16;
            rb_other.Width = 136;
            rb_other.Top = 158;
            rb_other.Left = 264;
            rb_other.Click += new EventHandler(rb_other_clicked);
            // 
            // sle_other
            // 
            sle_other.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_other.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_other.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_other.TabIndex = 3;
            sle_other.Height = 16;
            sle_other.Width = 136;
            sle_other.Top = 184;
            sle_other.Left = 264;
            // 
            // gb_source
            // 
            gb_source.Text = "Source";
            gb_source.BackColor = System.Drawing.SystemColors.Control;
            gb_source.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_source.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_source.TabIndex = 2;
            gb_source.Height = 176;
            gb_source.Width = 160;
            gb_source.Top = 38;
            gb_source.Left = 248;


            Controls.Add(rb_rmd);
            Controls.Add(rb_po);
            Controls.Add(rb_validation);
            Controls.Add(rb_duplication);
            Controls.Add(rb_other);
            Controls.Add(sle_other);
            Controls.Add(gb_source);
            this.ResumeLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        public override void pfc_default()
        {
            DialogResult ll_rc;
            int ll_row;
            int ll_rows;
            string ls_userID = string.Empty;
            if ((is_source == null) || is_source == "") 
            {
                MessageBox.Show("Please select a source for the move-out", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ll_rc = MessageBox.Show("Are you sure you wish to permanently remove the \n" + "selected customers from the Rural Delivery System?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);//,  question!, yesno!, 2);
            if (ll_rc == DialogResult.No)
            {
                return;
            }
            dw_select.DataObject.AcceptText();
            if (is_source == "Other")
            {
                if (!((sle_other.Text == null)) && !(sle_other.Text.Trim() == "")) 
                {
                    is_source = is_source + ": " + sle_other.Text.Trim();
                }
            }
            ls_userID = StaticVariables.gnv_app.of_getuserid();
            ll_rows = dw_select.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                dw_select.GetItem<AddressSelectOccupants>(ll_row).MoveOutSource = is_source;
                dw_select.GetItem<AddressSelectOccupants>(ll_row).MoveOutUser = ls_userID;
            }
            base.pfc_default();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            sle_other.Enabled = false;
        }

        #region Events
        public virtual void rb_rmd_clicked(object sender, EventArgs e)
        {
            sle_other.Enabled = false;
            is_source = "RMD3/5";
        }

        public virtual void rb_po_clicked(object sender, EventArgs e)
        {
            sle_other.Enabled = false;
            is_source = "PO126";
        }

        public virtual void rb_validation_clicked(object sender, EventArgs e)
        {
            sle_other.Enabled = false;
            is_source = "O/D Validation";
        }

        public virtual void rb_duplication_clicked(object sender, EventArgs e)
        {
            sle_other.Enabled = false;
            is_source = "Duplication";
        }

        public virtual void rb_other_clicked(object sender, EventArgs e)
        {
            sle_other.Enabled = true;
            is_source = "Other";
        }
        #endregion
    }
}
