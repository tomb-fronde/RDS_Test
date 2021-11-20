using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_105  May-2016: NEW
    // Display a list of contract numbers (usually only one) and 
    // return the number selected.
    // See WCustomerSequencer.cb_reassign_Click
    
    public class WReassignContract : WAncestorWindow
    {
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_contractlist;

        private Label label1;
        public Button cb_save;
        public Button cb_cancel;

        private int nContractNo;
        private TextBox TextBox1;
        private string sPostCode;

        public WReassignContract()
        {
            this.InitializeComponent();
            this.dw_contractlist.DataObject = new DReassignContract();
        }

        public override void pfc_preopen()
        {
            sPostCode = StaticVariables.gnv_app.of_get_parameters().stringparm;
            nContractNo = (int)StaticVariables.gnv_app.of_get_parameters().integerparm;
            string ls_Title = "Select New Contract Number";
            this.Text = ls_Title;

            if (dw_contractlist.RowCount <= 0)
            {
                dw_contractlist.DataObject.Reset();
                ((DReassignContract)dw_contractlist.DataObject).Retrieve(sPostCode, nContractNo);
            }
            dw_contractlist.SelectRow(0, false);
        }

        public override void pfc_postopen()
        {
            /************************ Testing ****************************
            MessageBox.Show("Contract " + nContractNo.ToString() + "\n"
                           + "Post Code " + sPostCode
                           , "WReassignContract.pfc_postopen");
            /************************ Testing ****************************/
            int n = dw_contractlist.RowCount;
            if (n == 1)
            {
                TextBox1.Text = "SAVE will reassign the selected addresses to this contract" 
                                 + ", or CANCEL to make no reassignments.";
            }
            else
            {
                TextBox1.Text = "Select one of the contract numbers then Save to reassign the selected Addresses to the selected contract"
                                 + ", or CANCEL to make no reassignments.";
            }
        }

        #region From Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_contractlist = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dw_contractlist
            // 
            this.dw_contractlist.DataObject = null;
            this.dw_contractlist.FireConstructor = false;
            this.dw_contractlist.Location = new System.Drawing.Point(1, 0);
            this.dw_contractlist.Name = "dw_contractlist";
            this.dw_contractlist.Size = new System.Drawing.Size(278, 92);
            this.dw_contractlist.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(113, 223);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 22);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "&Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(193, 223);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 22);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(5, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 9);
            this.label1.TabIndex = 4;
            this.label1.Text = "WReassignContract";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(4, 98);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(264, 117);
            this.TextBox1.TabIndex = 5;
            // 
            // WReassignContract
            // 
            this.AcceptButton = this.cb_save;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(280, 250);
            this.ControlBox = false;
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.dw_contractlist);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = false;
            this.MainMenuStrip = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WReassignContract";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.dw_contractlist, 0);
            this.Controls.SetChildIndex(this.TextBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #region Events
        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            int nSelectedContractNo = 0;
            if (dw_contractlist.RowCount == 1)
            {
                nSelectedContractNo = (int)this.dw_contractlist.GetValue<int?>(0, "ContractNo");
            }
            else
            {
                int nSelectedRow = dw_contractlist.GetSelectedRow(0);
                if (nSelectedRow < 0)
                {
                    MessageBox.Show("Please select one of the contract numbers, \n"
                                    + "or the CANCEL button."
                                    , "Error");
                    return;
                }
                nSelectedContractNo = (int)this.dw_contractlist.GetValue<int?>(nSelectedRow, "ContractNo");
            }

            StaticVariables.gnv_app.of_get_parameters().integerparm = nSelectedContractNo;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().integerparm = 0;
            this.Close();
        }
        #endregion

    }
}
