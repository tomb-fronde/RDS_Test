using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddFixedAsset : WResponse
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_fixedasset;// DAddFixedAsset dw_fixedasset;

        public Button cb_ok;

        public Button cb_cancel;

        #endregion

        public WAddFixedAsset()
        {
            this.InitializeComponent();
            //jlwang:removed from IC
            dw_fixedasset.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        public override void pfc_postopen()
        {
            //?dw_fixedasset.settransobject(StaticVariables.sqlca);
            dw_fixedasset.InsertItem<AddFixedAsset>(0);//dw_fixedasset.insertrow(0);
            dw_fixedasset.GetItem<AddFixedAsset>(0).FaFixedAssetNo = StaticMessage.StringParm;
            StaticVariables.gnv_app.of_get_parameters().stringparm = "Cancelled";
        }

        #region From Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_fixedasset = new URdsDw();
            this.dw_fixedasset.DataObject = new DAddFixedAsset();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_fixedasset);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Fixed Asset";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(326, 177);
            // 
            // dw_fixedasset
            // 
            //dw_fixedasset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_fixedasset.TabIndex = 1;
            dw_fixedasset.Location = new System.Drawing.Point(3, 4);
            dw_fixedasset.Size = new System.Drawing.Size(308, 112);

            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(88, 123);
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(175, 123);
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
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

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            if ((dw_fixedasset.GetItem<AddFixedAsset>(0).FatId == null))
            {
                MessageBox.Show("The fixed asset type has not been defined", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_fixedasset.GetControlByName("fat_id").Focus();
                return;
            }
            dw_fixedasset.Save();//dw_fixedasset.update();
            //?commit;
            StaticVariables.gnv_app.of_get_parameters().stringparm = "OK";
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
