using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.DataService;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralwin;
using System.Collections.Generic;
using NZPostOffice.Entity;
using Metex.Core;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_060 Feb-2014
    // Adjusted size of window to accommodate additional info
    //
    // TJB  RPCR_060 Jan-2014: NEW
    // Driver info maintenance window
    // Displays driver personal and H&S info in separate panels
    // Editing allowed.
    // Also used to add new drivers

    public class WDriverInfoMaint : WAncestorWindow  //WMaster
    {
        // TJB  RPCR_054  June-2013: NEW
        // Displays the list of defined piece rate types and allows the user 
        // to add a piece rate for that type for one or more renewal groups.
        // Initial values for the rate and effective date can be entered and 
        // apply for all renewal groups.  Only rates for types/renewal groups 
        // that don't already exist in the piece_rate table will be created. 
        // Adding a new rate for a new effective date is done in WShowRates.
        // 
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_close;
        private Button cb_save;

        private Label label1;
        private Label driverinfo_t;
        private Label hsinfo_t;
        private ToolTip toolTip1;

        public URdsDw dw_driverinfo;
        public URdsDw dw_driverhsinfo;

        #endregion

        NCriteria nvCriteria;
        NRdsMsg nvMsg;
        int nContractor;
        string sOptype = "";
        bool inAdminGroup;
        int nDriverNo;
        bool bSomethingSaved;

        public WDriverInfoMaint()
        {
            this.InitializeComponent();
            this.dw_driverinfo.DataObject = new DDriverInfo();
            this.dw_driverhsinfo.DataObject = new DDriverHSInfo();
        }


        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_driverinfo = new NZPostOffice.RDS.Controls.URdsDw();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_save = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.driverinfo_t = new System.Windows.Forms.Label();
            this.hsinfo_t = new System.Windows.Forms.Label();
            this.dw_driverhsinfo = new NZPostOffice.RDS.Controls.URdsDw();
            this.SuspendLayout();
            // 
            // cb_close
            // 
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_close.Location = new System.Drawing.Point(551, 346);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 30;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_driverinfo
            // 
            this.dw_driverinfo.BackColor = System.Drawing.Color.White;
            this.dw_driverinfo.DataObject = null;
            this.dw_driverinfo.FireConstructor = false;
            this.dw_driverinfo.Location = new System.Drawing.Point(6, 40);
            this.dw_driverinfo.Name = "dw_driverinfo";
            this.dw_driverinfo.Size = new System.Drawing.Size(621, 70);
            this.dw_driverinfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(15, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WDriverInfoMaint";
            // 
            // cb_save
            // 
            this.cb_save.Location = new System.Drawing.Point(468, 346);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 25;
            this.cb_save.Text = "Save";
            this.cb_save.UseVisualStyleBackColor = true;
            this.cb_save.Click += new System.EventHandler(this.cb_save_Click);
            // 
            // driverinfo_t
            // 
            this.driverinfo_t.AutoSize = true;
            this.driverinfo_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverinfo_t.Location = new System.Drawing.Point(16, 24);
            this.driverinfo_t.Name = "driverinfo_t";
            this.driverinfo_t.Size = new System.Drawing.Size(67, 13);
            this.driverinfo_t.TabIndex = 31;
            this.driverinfo_t.Text = "Driver Info";
            // 
            // hsinfo_t
            // 
            this.hsinfo_t.AutoSize = true;
            this.hsinfo_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsinfo_t.Location = new System.Drawing.Point(13, 122);
            this.hsinfo_t.Name = "hsinfo_t";
            this.hsinfo_t.Size = new System.Drawing.Size(121, 13);
            this.hsinfo_t.TabIndex = 32;
            this.hsinfo_t.Text = "Health && Safety Info";
            // 
            // dw_driverhsinfo
            // 
            this.dw_driverhsinfo.AutoScroll = true;
            this.dw_driverhsinfo.BackColor = System.Drawing.Color.White;
            this.dw_driverhsinfo.DataObject = null;
            this.dw_driverhsinfo.FireConstructor = false;
            this.dw_driverhsinfo.Location = new System.Drawing.Point(16, 139);
            this.dw_driverhsinfo.Name = "dw_driverhsinfo";
            this.dw_driverhsinfo.Size = new System.Drawing.Size(611, 201);
            this.dw_driverhsinfo.TabIndex = 33;
            // 
            // WDriverInfoMaint
            // 
            this.AcceptButton = this.cb_close;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 374);
            this.Controls.Add(this.dw_driverhsinfo);
            this.Controls.Add(this.hsinfo_t);
            this.Controls.Add(this.driverinfo_t);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_driverinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WDriverInfoMaint";
            this.Text = "Driver Information Maintenance";
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.dw_driverinfo, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.driverinfo_t, 0);
            this.Controls.SetChildIndex(this.hsinfo_t, 0);
            this.Controls.SetChildIndex(this.dw_driverhsinfo, 0);
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

        public override void open()
        {
            DateTime dtEffDate;
            string sRgDescription; 
            string sEffDate;

            base.open();

            nvMsg = (NRdsMsg)StaticMessage.PowerObjectParm;
            nvCriteria = nvMsg.of_getcriteria();

            cb_save.Enabled = true;
        }

        #region Methods
        public override void pfc_postopen()
        {
            base.pfc_postopen();

            NRdsMsg lnv_msg;
            NCriteria lvNCriteria;
            int nDriverinfoRows;
            int nDriverhsinfoRows;

            inAdminGroup = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_ismember("System Administrators");
            bSomethingSaved = false;

            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvNCriteria = lnv_msg.of_getcriteria();
            nDriverNo = System.Convert.ToInt32(lvNCriteria.of_getcriteria("driver_no"));
            nContractor = System.Convert.ToInt32(nvCriteria.of_getcriteria("contractor_no"));
            sOptype = System.Convert.ToString(nvCriteria.of_getcriteria("op_type"));

            if (sOptype == "edit")
            {
                dw_driverinfo.Retrieve(new object[] { nDriverNo });
                nDriverinfoRows = dw_driverinfo.RowCount;
                dw_driverhsinfo.Retrieve(new object[] { nDriverNo });
                nDriverhsinfoRows = dw_driverhsinfo.RowCount;
//                MessageBox.Show("View/Edit driver " + nDriverNo.ToString() + "\n"
//                               + "DriverInfo rowcount = " + nDriverinfoRows.ToString() + "\n"
//                               + "DriverHSInfo rowcount = " + nDriverhsinfoRows.ToString() + "\n");
            }
            else if ( sOptype == "add" )
            {
                RDSDataService DS = RDSDataService.GetNextSequence("DriverNo");
                nDriverNo = DS.intVal;
                dw_driverinfo.InsertRow(0);
                int nRow = dw_driverinfo.GetRow();
                nDriverinfoRows = dw_driverinfo.RowCount;
                dw_driverinfo.InsertItem<DriverInfo>(nRow).DriverNo = nDriverNo;
                dw_driverinfo.GetItem<DriverInfo>(nRow).marknew();
                dw_driverhsinfo.Retrieve(new object[] { nDriverNo });
                nDriverhsinfoRows = dw_driverhsinfo.RowCount;
//                MessageBox.Show("Add new driver "+nDriverNo.ToString()+" \n"
//                               + "DriverInfo rowcount = " + nDriverinfoRows.ToString() + "\n"
//                               + "DriverHSInfo rowcount = " + nDriverhsinfoRows.ToString() + "\n");
            }

        }

        #endregion

        #region Events
        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
//            MessageBox.Show("Close Clicked\n", "cb_save_clicked");
            Close();
        }

        #endregion

        private bool validate_effective_date(string sInDate)
        {
            return true;
        }

        private bool validate_rate(string sInRate)
        {
            return true;
        }

        private void cb_save_Click(object sender, EventArgs e)
        {
            int nRow = dw_driverinfo.GetRow();
            int nRows = dw_driverhsinfo.RowCount;

//            MessageBox.Show("Save Clicked\n", "cb_save_clicked");

            if (sOptype == "edit")
            {
                if (dw_driverinfo.GetItem<DriverInfo>(nRow).IsDirty)
                {
//                    MessageBox.Show("Saving driver info; Row " + nRow.ToString());
                    dw_driverinfo.Save();
                    bSomethingSaved = true;
                }
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    if (dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).IsDirty)
                    {
//                        MessageBox.Show("Saving driver H&S info; Row " + nRow.ToString());
                        dw_driverhsinfo.Save();
                        bSomethingSaved = true;
                    }
                }
            }
            else if (sOptype == "add")
            {
                if (dw_driverinfo.GetItem<DriverInfo>(nRow).IsDirty)
                {
//                    MessageBox.Show("Saving driver "+nDriverNo.ToString()+" info; Row " + nRow.ToString());
                    dw_driverinfo.Save();
                    bSomethingSaved = true;
                }
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    if (dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).IsDirty)
                    {
//                        MessageBox.Show("Saving driver H&S info; Row " + nRow.ToString());
                        dw_driverhsinfo.Save();
                        bSomethingSaved = true;
                    }
                }
                RDSDataService.AddContractorDriver(nContractor, nDriverNo);
            }
            else
            {
                MessageBox.Show("Saving for optype "+sOptype+"not yet implemented \n"
                                , "Warning");
            }
/*
            if (bSomethingSaved)
            {
                string msg;
                if (sOptype == "edit")
                    msg = "     Changes saved      \n";
                else
                    msg = "     Driver added       \n";
                MessageBox.Show(msg);
            }
            else
                MessageBox.Show("No changes made - nothing to save");
*/
            Close();
            
        }

        public override void close()
        {
            if (bSomethingSaved)
            {
                //  Tell the parent to refresh
                ((WContractor2001)StaticVariables.window).dw_drivers.Reset();
                ((WContractor2001)StaticVariables.window).dw_drivers.Retrieve(new object[] { nContractor });
            }
            StaticVariables.window = null;
        }
    }
}