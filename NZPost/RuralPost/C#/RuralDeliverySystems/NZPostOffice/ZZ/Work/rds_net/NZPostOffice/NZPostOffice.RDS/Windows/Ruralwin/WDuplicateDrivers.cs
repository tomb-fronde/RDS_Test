using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WDuplicateDrivers : WMaster
    {

        #region Define
        public int il_contract;
        public int il_altKey;
        public int il_caRow;
        public Button cb_cancel;
        public URdsDw dwdriver;
        public Button cb_save;
        private System.ComponentModel.IContainer components = null;
        #endregion

        public WDuplicateDrivers()
        {
            m_sheet = new MSheet(this);
            this.InitializeComponent();
            dwdriver.DataObject = new DDuplicateDrivers();
            this.dwdriver.DataObject.BorderStyle = BorderStyle.None;

//            dwdriver.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dwdriver_constructor);
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_cancel = new System.Windows.Forms.Button();
            this.dwdriver = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_cancel
            // 
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(559, 141);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(72, 20);
            this.cb_cancel.TabIndex = 1;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // dwdriver
            // 
            this.dwdriver.DataObject = null;
            this.dwdriver.FireConstructor = false;
            this.dwdriver.Location = new System.Drawing.Point(0, 0);
            this.dwdriver.Name = "dwdriver";
            this.dwdriver.Size = new System.Drawing.Size(631, 132);
            this.dwdriver.TabIndex = 2;
            this.dwdriver.RowFocusChanged += new System.EventHandler(this.dwdriver_rowfocuschanged);
            // 
            // cb_save
            // 
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(481, 141);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(72, 20);
            this.cb_save.TabIndex = 3;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_Click);
            // 
            // WDuplicateDrivers
            // 
            this.AcceptButton = this.cb_cancel;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(635, 165);
            this.ControlBox = false;
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.dwdriver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(182, 89);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WDuplicateDrivers";
            this.Controls.SetChildIndex(this.dwdriver, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
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

        int inContractorNo;
        string isFirstnames, isSurname;

        public override void pfc_preopen()
        {
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvn_Criteria = lnv_msg.of_getcriteria();
            inContractorNo = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("ContractorNo"));
            isFirstnames = System.Convert.ToString(lvn_Criteria.of_getcriteria("Firstnames"));
            isSurname = System.Convert.ToString(lvn_Criteria.of_getcriteria("Surname"));

            dwdriver.DataObject.Reset();
            ((DDuplicateDrivers)dwdriver.DataObject).Retrieve(isFirstnames, isSurname);
/*
            MessageBox.Show("Entered WDuplicateDrivers with \n"
                           + "Contractor No = " + inContractorNo.ToString() + "\n"
                           + "First names = " + isFirstnames + "\n"
                           + "Surname = " + isSurname + "\n"
                           + (dwdriver.RowCount).ToString() + " rows found."
                           , "Testing: WDuplicateDrivers: Entered"
                           );
*/
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            dwdriver.Focus();
        }

        public override int pfc_save()
        {
            int nRow = dwdriver.GetRow();
            int nDriverNo = (int)dwdriver.GetItem<DuplicateDrivers>(nRow).DriverNo;
            string sFirstnames = dwdriver.GetItem<DuplicateDrivers>(nRow).Firstnames;
            string sSurname = dwdriver.GetItem<DuplicateDrivers>(nRow).Surname;
            string sPhoneDay = dwdriver.GetItem<DuplicateDrivers>(nRow).PhoneDay;
            string sPhoneNight = dwdriver.GetItem<DuplicateDrivers>(nRow).PhoneNight;
            string sMobile = dwdriver.GetItem<DuplicateDrivers>(nRow).Mobile;
            string sMobile2 = dwdriver.GetItem<DuplicateDrivers>(nRow).Mobile2;
/*
            MessageBox.Show("Row "+nRow.ToString()+" selected.\n\n"
                           + "Driver No = " + nDriverNo.ToString() + "\n"
                           + "First names = " + sFirstnames + "\n"
                           + "Surname = " + sSurname + "\n"
                           + "Phone Day = " + sPhoneDay + "\n"
                           , "Testing: WDuplicateDrivers: pfc_save"
                           );
*/
            RDSDataService DS = RDSDataService.AddContractorDriver(inContractorNo, nDriverNo);

            ((WDriverInfoMaint)StaticVariables.window).dw_driverinfo.Reset();
            ((WDriverInfoMaint)StaticVariables.window).dw_driverinfo.Retrieve(new object[] { nDriverNo });
            ((WDriverInfoMaint)StaticVariables.window).dw_driverhsinfo.Reset();
            ((WDriverInfoMaint)StaticVariables.window).dw_driverhsinfo.Retrieve(new object[] { nDriverNo });

            StaticVariables.window = null;

            this.Close();
            return 1;
        }

        public override void close()
        {
            base.close();
        }

        public virtual void dwdriver_constructor()
        {
            dwdriver.of_SetUpdateable(true);
        }

        #region Events

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void dwdriver_rowfocuschanged(object sender, EventArgs e)
        {
            dwdriver.SelectRow(0, false);
            dwdriver.SelectRow(dwdriver.GetRow() + 1, true);
        }
        #endregion

        private void cb_save_Click(object sender, EventArgs e)
        {
//            MessageBox.Show("cb_save clicked","Testing: WDuplicateDrivers");
            pfc_save();
        }

    }
}
