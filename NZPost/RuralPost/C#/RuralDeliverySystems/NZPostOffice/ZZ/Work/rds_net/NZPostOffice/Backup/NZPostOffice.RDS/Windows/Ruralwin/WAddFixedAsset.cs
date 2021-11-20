using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_026 July-2011: New
    // Displays the list of fixed assets that aren't assigned to a contract.
    // The 'Save' button (cb_save) saves the selected asset to te current contract.
    // Called from the Fixed Assets tab of WContract2001.
    // 
    public class WAddFixedAsset : WAncestorWindow
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_fixedasset;

        private Label label1;
        public Button cb_save;
        public Button cb_cancel;
        private Button cb_delete;
        private Button cb_sort_no;
        private Button cb_sort_type;

        private int il_Contract_no;

        #endregion

        public WAddFixedAsset()
        {
            this.InitializeComponent();
            //this.dw_fixedasset.DataObject = new DAddFixedAsset();
            this.dw_fixedasset.DataObject = new DFARegisterUnassigned();
        }

        public override void pfc_preopen()
        {
            int nContractNo = (int)StaticVariables.gnv_app.of_get_parameters().integerparm;
            string sConTitle = StaticVariables.gnv_app.of_get_parameters().stringparm;
            string ls_Title = "Contract: (" + nContractNo.ToString() + ") " + sConTitle;
            this.Text = ls_Title;
            il_Contract_no = nContractNo;

            if (dw_fixedasset.RowCount <= 0)
            {
                dw_fixedasset.DataObject.Reset();
                dw_fixedasset.DataObject.Retrieve();
            }

            dw_fixedasset.URdsDw_GetFocus(null, null);
            //idw_contract.GetControlByName("con_title").Focus();
        }

        public override void pfc_postopen()
        {
            //dw_fixedasset.InsertItem<AddFixedAsset>(0);
            //dw_fixedasset.GetItem<AddFixedAsset>(0).FaFixedAssetNo = StaticMessage.StringParm;
            //StaticVariables.gnv_app.of_get_parameters().stringparm = "Cancelled";
        }

        #region From Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_fixedasset = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_delete = new System.Windows.Forms.Button();
            this.cb_sort_no = new System.Windows.Forms.Button();
            this.cb_sort_type = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_fixedasset
            // 
            this.dw_fixedasset.DataObject = null;
            this.dw_fixedasset.FireConstructor = false;
            this.dw_fixedasset.Location = new System.Drawing.Point(0, 2);
            this.dw_fixedasset.Name = "dw_fixedasset";
            this.dw_fixedasset.Size = new System.Drawing.Size(635, 340);
            this.dw_fixedasset.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(467, 353);
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
            this.cb_cancel.Location = new System.Drawing.Point(547, 353);
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
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(5, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "WAddFixedAsset";
            // 
            // cb_delete
            // 
            this.cb_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_delete.Enabled = false;
            this.cb_delete.Location = new System.Drawing.Point(329, 352);
            this.cb_delete.Name = "cb_delete";
            this.cb_delete.Size = new System.Drawing.Size(75, 23);
            this.cb_delete.TabIndex = 5;
            this.cb_delete.Text = "&Delete";
            this.cb_delete.UseVisualStyleBackColor = true;
            this.cb_delete.Visible = false;
            this.cb_delete.Click += new System.EventHandler(this.cb_delete_clicked);
            // 
            // cb_sort_no
            // 
            this.cb_sort_no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_sort_no.Location = new System.Drawing.Point(110, 352);
            this.cb_sort_no.Name = "cb_sort_no";
            this.cb_sort_no.Size = new System.Drawing.Size(75, 23);
            this.cb_sort_no.TabIndex = 6;
            this.cb_sort_no.Text = "Sort by &No";
            this.cb_sort_no.UseVisualStyleBackColor = true;
            this.cb_sort_no.Click += new System.EventHandler(this.cb_cort_no_Click);
            // 
            // cb_sort_type
            // 
            this.cb_sort_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_sort_type.Location = new System.Drawing.Point(191, 352);
            this.cb_sort_type.Name = "cb_sort_type";
            this.cb_sort_type.Size = new System.Drawing.Size(91, 23);
            this.cb_sort_type.TabIndex = 7;
            this.cb_sort_type.Text = "Group by &Type";
            this.cb_sort_type.UseVisualStyleBackColor = true;
            this.cb_sort_type.Click += new System.EventHandler(this.cb_sort_type_Click);
            // 
            // WAddFixedAsset
            // 
            this.AcceptButton = this.cb_save;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(634, 380);
            this.Controls.Add(this.cb_sort_type);
            this.Controls.Add(this.cb_sort_no);
            this.Controls.Add(this.cb_delete);
            this.Controls.Add(this.dw_fixedasset);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_save);
            this.Name = "WAddFixedAsset";
            this.Text = "Fixed Asset";
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.dw_fixedasset, 0);
            this.Controls.SetChildIndex(this.cb_delete, 0);
            this.Controls.SetChildIndex(this.cb_sort_no, 0);
            this.Controls.SetChildIndex(this.cb_sort_type, 0);
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
            int nRow = dw_fixedasset.GetRow();
            int nSelectedRow = dw_fixedasset.GetSelectedRow(0);
            string sFixedAsset = "";
            if (nRow >= 0) sFixedAsset = dw_fixedasset.GetItem<FARegisterUnassigned>(nRow).FaFixedAssetNo;
            DialogResult ans;
            ans = MessageBox.Show("Please confirm: save asset " + sFixedAsset + " to contract " + il_Contract_no.ToString() + "\n"
                            , ""
                            , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                            , MessageBoxDefaultButton.Button1);
            if (ans == DialogResult.Yes)
            {
                int sqlErrNo = 0;
                string sqlErrMsg = "";
                int? rc = RDSDataService.AssignFixedAssetToContract(sFixedAsset, il_Contract_no, ref sqlErrNo, ref sqlErrMsg);
                if (rc != 0)
                {
                    MessageBox.Show("Error assigning asset to contract"
                                    + sqlErrMsg + "\n"
                                    , "Error");
                    return;
                }
                StaticVariables.gnv_app.of_get_parameters().booleanparm = true;
            }
            else if (ans == DialogResult.Cancel)
            {
                return;
            }
            else
                StaticVariables.gnv_app.of_get_parameters().booleanparm = false;

            //dw_fixedasset.Save();
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_delete_clicked(object sender, EventArgs e)
        {
            int nRow = dw_fixedasset.GetRow();
            int nSelectedRow = dw_fixedasset.GetSelectedRow(0);
            string sFixedAsset = "";
            if (nRow >= 0) sFixedAsset = dw_fixedasset.GetItem<FARegisterUnassigned>(nRow).FaFixedAssetNo;
            DialogResult ans;
            ans = MessageBox.Show("Please confirm: delete asset " + sFixedAsset + " \n"
                            , ""
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            , MessageBoxDefaultButton.Button1);
            if (ans == DialogResult.Yes)
            {
                dw_fixedasset.DeleteItemAt(nRow);
                dw_fixedasset.Save();
                dw_fixedasset.Refresh();
            }
        }
        #endregion

        private string no_seq = "desc";

        private void cb_cort_no_Click(object sender, EventArgs e)
        {
            if (no_seq == "desc")
                no_seq = "asc";
            else
                no_seq = "desc";

            dw_fixedasset.SortString( "fa_fixed_asset_no " + no_seq );
            dw_fixedasset.Sort<FARegisterUnassigned>();
            //lds_user_Contract_Types.SortString = "ct_key A";
            //lds_user_Contract_Types.Sort<FilteredContractTypes>();
        }

        private string type_seq = "desc";

        private void cb_sort_type_Click(object sender, EventArgs e)
        {
            if (type_seq == "desc")
                type_seq = "asc";
            else
                type_seq = "desc";

            dw_fixedasset.SortString("fat_id " + type_seq);
            dw_fixedasset.Sort<FARegisterUnassigned>();
        }
    }
}
