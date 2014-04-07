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
    // TJB  RPCR_060 Mar-2014
    // Added cb_check_dup button and functionality
    // Misc refinements
    //
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
        private Button cb_check_dup;

        private Label label1;
        private Label driverinfo_t;
        private Label hsinfo_t;

        public URdsDw dw_driverinfo;
        public URdsDw dw_driverhsinfo;

        #endregion

        NCriteria nvCriteria;
        NRdsMsg nvMsg;
        int nContractor;
        string sOptype = "";
        bool inAdminGroup;
        bool bSomethingSaved;
        bool bClosing;
        int nDriverNo;
        string sDriverTitle;
        string sDriverFirstnames;
        string sDriverSurname;


        public WDriverInfoMaint()
        {
            this.InitializeComponent();
            this.dw_driverinfo.DataObject = new DDriverInfo();
            this.dw_driverhsinfo.DataObject = new DDriverHSInfo();

            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            this.cb_save.Click += new System.EventHandler(this.cb_save_Click);
        }


        #region Form Design
        private void InitializeComponent()
        {
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_driverinfo = new NZPostOffice.RDS.Controls.URdsDw();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_save = new System.Windows.Forms.Button();
            this.driverinfo_t = new System.Windows.Forms.Label();
            this.hsinfo_t = new System.Windows.Forms.Label();
            this.dw_driverhsinfo = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_check_dup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(186, 346);
            this.st_label.Size = new System.Drawing.Size(113, 23);
            this.st_label.Visible = false;
            // 
            // cb_close
            // 
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_close.Location = new System.Drawing.Point(551, 346);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 30;
            this.cb_close.Text = "Close";
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
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
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
            this.dw_driverhsinfo.DoubleClick += new System.EventHandler(this.dw_driverhsinfo_DoubleClick);
            this.dw_driverhsinfo.Click += new System.EventHandler(this.dw_driverhsinfo_Click);
            // 
            // cb_check_dup
            // 
            this.cb_check_dup.Enabled = false;
            this.cb_check_dup.Location = new System.Drawing.Point(508, 33);
            this.cb_check_dup.Name = "cb_check_dup";
            this.cb_check_dup.Size = new System.Drawing.Size(118, 23);
            this.cb_check_dup.TabIndex = 34;
            this.cb_check_dup.Text = "Check for Duplicate";
            this.cb_check_dup.UseVisualStyleBackColor = true;
            this.cb_check_dup.Visible = false;
            this.cb_check_dup.Click += new System.EventHandler(this.cb_check_dup_Click);
            // 
            // WDriverInfoMaint
            // 
            this.AcceptButton = this.cb_close;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 374);
            this.Controls.Add(this.cb_check_dup);
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
            this.Controls.SetChildIndex(this.cb_check_dup, 0);
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
            base.open();

            nvMsg = (NRdsMsg)StaticMessage.PowerObjectParm;
            nvCriteria = nvMsg.of_getcriteria();

            cb_save.Enabled = true;
        }

        #region Methods

        Object wContractorWindow;

        public override void pfc_postopen()
        {
            base.pfc_postopen();

            NRdsMsg lnv_msg;
            NCriteria lvNCriteria;
            int nDriverinfoRows;
            int nDriverhsinfoRows;

            set_disableclosequery(true);

            inAdminGroup = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_ismember("System Administrators");
            bSomethingSaved = false;

            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvNCriteria = lnv_msg.of_getcriteria();
            nDriverNo = System.Convert.ToInt32(lvNCriteria.of_getcriteria("driver_no"));
            nContractor = System.Convert.ToInt32(nvCriteria.of_getcriteria("contractor_no"));
            sOptype = System.Convert.ToString(nvCriteria.of_getcriteria("op_type"));

            wContractorWindow = StaticVariables.window;

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
                dw_driverinfo.GetItem<DriverInfo>(nRow).MarkClean();
                dw_driverhsinfo.Retrieve(new object[] { nDriverNo });
                nDriverhsinfoRows = dw_driverhsinfo.RowCount;
//                MessageBox.Show("Add new driver "+nDriverNo.ToString()+" \n"
//                               + "DriverInfo rowcount = " + nDriverinfoRows.ToString() + "\n"
//                               + "DriverHSInfo rowcount = " + nDriverhsinfoRows.ToString() + "\n");
                this.cb_check_dup.Enabled = true;
                this.cb_check_dup.Visible = true;
            }

        }

        #endregion

        #region Events
        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            int nRow = dw_driverinfo.GetRow();
            int nRows = dw_driverhsinfo.RowCount;
            bool bSomethingToSave = false;

//            MessageBox.Show("Close Clicked\n", "cb_close_clicked");

            dw_driverinfo.AcceptText();
            dw_driverhsinfo.AcceptText();
            
            // First, check to see if there's anything to be saved
            bSomethingToSave = dw_driverinfo.GetItem<DriverInfo>(nRow).IsDirty;

            if (bSomethingToSave == false)
            {
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    if (dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).IsDirty)
                    {
                        bSomethingToSave = true;
                    }
                }
            }
            // If there is something to be saved, ask if the user wants to
            if (bSomethingToSave)
            {
                DialogResult ans = MessageBox.Show("Do you want to save your changes?"
                                                    , "cb_close_clicked"
                                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                                    , MessageBoxDefaultButton.Button2);
                // If not, close immediately
                if (ans == DialogResult.No)
                {
                    close();
                    return;
                }
            }
            // Otherwise, save whatever is to be saved
            if (do_save())
            {
                //reset_parent();
                //Close();
                //return;
                close();
            }
            else
                return;
        }

        #endregion

        private bool validate_driver(int nRow)
        {
            string sSurname = (string)dw_driverinfo.GetItem<DriverInfo>(nRow).DSurname;
            if (sSurname == null || sSurname.Trim() == "")
            {
                MessageBox.Show("The driver's surname must be specified!"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool validate_HS_item(int nRow)
        {
            int nRows = dw_driverhsinfo.RowCount;
            DateTime? thisDateChecked, prevDateChecked;
            DateTime? thisAdditionalDate, prevAdditionalDate;
            string thisPassfailInd, prevPassfailInd;
            string thisNotes, prevNotes;
            string sErrMsg, sHstName;
            string sAdditionalDateErrmsg, sNotesErrmsg;

            sErrMsg = "";
            if (dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).IsDirty)
            {
                sHstName = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HstName;
                thisDateChecked = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HsiDateChecked;
                prevDateChecked = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).prevHsiDateChecked;
                if (prevDateChecked == null && thisDateChecked == null)
                {
                    sErrMsg += sHstName + ": The date checked must be entered.\n";
                }
                thisPassfailInd = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HsiPassfailInd;
                prevPassfailInd = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).prevHsiPassfailInd;
                if (prevPassfailInd == null && thisPassfailInd == null)
                {
                    sErrMsg += sHstName + ": A pass/fail status must be entered.\n";
                }
                if (thisPassfailInd != null
                    && thisPassfailInd != "P"
                    && thisPassfailInd != "F")
                {
                    sErrMsg += sHstName + ": The pass/fail indicator must be either P or F\n";
                }
                thisAdditionalDate = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HsiAdditionalDate;
                prevAdditionalDate = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).prevHsiAdditionalDate;
                sAdditionalDateErrmsg = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HstAdditionalDateErrmsg;
                if ((prevAdditionalDate == null && thisAdditionalDate == null) && sAdditionalDateErrmsg != null)
                {
                    sErrMsg += sHstName + ": " + sAdditionalDateErrmsg + "\n";
                }

                thisNotes = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HsiNotes;
                prevNotes = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).prevHsiNotes;
                sNotesErrmsg = dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).HstNotesErrmsg;
                if ((prevNotes == null && thisNotes == null) && sNotesErrmsg != null)
                {
                    sErrMsg += sHstName + ": " + sNotesErrmsg + "\n";
                }
            }
            if (sErrMsg != "")
            {
                sErrMsg += "                                                                ";
                MessageBox.Show(sErrMsg, "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool do_save()
        {
            //if (bClosing)
            //    return true;

            int nRow = dw_driverinfo.GetRow();
            int nRows = dw_driverhsinfo.RowCount;
            bool bValidated = true;

            if (sOptype == "edit")
            {
                if (dw_driverinfo.GetItem<DriverInfo>(nRow).IsDirty)
                {
//                    MessageBox.Show("Saving driver info; Row " + nRow.ToString());
                    if (validate_driver(nRow))
                    {
                        dw_driverinfo.Save();
                        bSomethingSaved = true;
                    }
                    else
                        bValidated = false;
                }
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    if (dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).IsDirty)
                    {
//                        MessageBox.Show("Saving driver H&S info; Row " + nRow.ToString());
                        if (validate_HS_item(nRow))
                        {
                            if (bValidated)
                            {
                                dw_driverhsinfo.Save();
                                bSomethingSaved = true;
                            }
                        }
                        else
                            bValidated = false;
                    }
                }
            }
            else if (sOptype == "add")
            {
                if (dw_driverinfo.GetItem<DriverInfo>(nRow).IsDirty)
                {
//                    MessageBox.Show("Saving driver "+nDriverNo.ToString()+" info; Row " + nRow.ToString());
                    if (validate_driver(nRow))
                    {
                        dw_driverinfo.Save();
                        bSomethingSaved = true;
                    }
                    else
                        bValidated = false;
                }
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    if (dw_driverhsinfo.GetItem<DriverHSInfo>(nRow).IsDirty)
                    {
//                        MessageBox.Show("Saving driver H&S info; Row " + nRow.ToString());
                        if (validate_HS_item(nRow))
                        {
                            if (bValidated)
                            {
                                dw_driverhsinfo.Save();
                                bSomethingSaved = true;
                            }
                        }
                        else
                            bValidated = false;
                    }
                }
                RDSDataService.AddContractorDriver(nContractor, nDriverNo);
            }
            else
            {
                MessageBox.Show("Saving for optype " + sOptype + " not yet implemented \n"
                                , "Warning");
            }
            return bValidated;
        }

        private void cb_save_Click(object sender, EventArgs e)
        {
//            MessageBox.Show("Save Clicked\n", "cb_save_clicked");
            if (do_save())
            {
                //reset_parent();
                //Close();
                //return;
                close();
                return;
            }
            else
                return;
        }

        private void reset_parent()
        {
            //  Tell the parent to refresh
            StaticVariables.window = wContractorWindow;

            ((WContractor2001)StaticVariables.window).dw_driversHSInfo.Reset();
            ((WContractor2001)StaticVariables.window).dw_driversHSInfo.Retrieve(new object[] { nContractor });

            StaticVariables.window = null;
            bClosing = true;
        }
       private void close()
        {
            reset_parent();
            Close();
        }

        private void dw_driverhsinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dw_driverhsinfo_Click");
        }

        private void dw_driverhsinfo_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("dw_driverhsinfo_DoubleClick");
        }

        private void cb_check_dup_Click(object sender, EventArgs e)
        {
            int nRow = dw_driverinfo.GetRow();
            sDriverFirstnames = dw_driverinfo.GetItem<DriverInfo>(nRow).DFirstNames;
            sDriverSurname = dw_driverinfo.GetItem<DriverInfo>(nRow).DSurname;

            RDSDataService DS = RDSDataService.LookForDuplicateDriver(sDriverFirstnames, sDriverSurname);
            int n = DS.intVal;
            if (n > 0)
            {
                string s = (n > 1) ? "s" : "";
                MessageBox.Show(n.ToString() + " matching driver name " + s + " found.");

                showduplicates(sDriverFirstnames, sDriverSurname);
            }
            else if (n == 0)
            {
                MessageBox.Show("No matching driver names found.");
            }
            else
            {
                int sqlcode = DS.SQLCode;
                string sqlerrtxt = DS.SQLErrText;
                MessageBox.Show("SQL Error code = " + sqlcode.ToString() + "\n"
                                + "Error text = " + sqlerrtxt
                                , "SQL Error");
            }
        }

        private void showduplicates( string spFirstnames, string spSurname)
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();

            lnv_Criteria.of_addcriteria("ContractorNo", nContractor);
            lnv_Criteria.of_addcriteria("Firstnames", spFirstnames);
            lnv_Criteria.of_addcriteria("Surname", spSurname);
            lnv_msg.of_addcriteria(lnv_Criteria);
/*
            MessageBox.Show("Calling WDuplicateDrivers with \n"
                           + "Contractor No = " + nContractor.ToString() + "\n"
                           + "First names = " + spFirstnames + "\n"
                           + "Surname = " + spSurname + "\n"
                           , "Testing: WDriverInfoMaint"
                           );
*/
            StaticMessage.PowerObjectParm = lnv_msg;
            StaticVariables.window = this;
            WDuplicateDrivers wDupDrivers = new WDuplicateDrivers();
            wDupDrivers.MdiParent = StaticVariables.MainMDI;
            wDupDrivers.Show();
        }
    }
}