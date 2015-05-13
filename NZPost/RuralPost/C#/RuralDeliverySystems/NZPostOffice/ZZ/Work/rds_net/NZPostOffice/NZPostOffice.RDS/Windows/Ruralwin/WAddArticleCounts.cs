using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  May-2015 Tweak
    // Close button asks to save if anything not saved
    // Upper-right "X" button doesn't
    // (13-May-2015: undone - both now ask)
    //
    // TJB  RPCR_093  Feb-2015
    // Changed main entry DW from DRegionalArticalCounts to DRegionalDailyArticalCounts.  
    // Added 'Close' button and single-contract addition.
    //
    // TJB  RPCR_093  Mar-2015
    // Added wait cursor in cb_save_clicked

    public class WAddArticleCounts : WAncestorWindow
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_generic;

        public URdsDw dw_date;

        public Button cb_save;
        public Button cb_close;

        private string dw_generic_DataObject_Name;
        #endregion

        public WAddArticleCounts()
        {
            this.InitializeComponent();

            this.dw_date.DataObject = new DArticalCountDateStart();
            this.dw_date.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_date.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_date_constructor);
            ((DArticalCountDateStart)this.dw_date.DataObject).SelectedItemChanged += new EventHandler(WAddArticleCounts_SelectedItemChanged);

            this.dw_date.DataObject.FilterString = "";
            this.dw_date.DataObject.SortString = "";

            //this.dw_generic.DataObject = new DRegionalArticalCounts();
            //dw_generic_DataObject_Name = "DRegionalArticalCounts";
            this.dw_generic.DataObject = new DRegionalDailyArticalCounts();
            dw_generic_DataObject_Name = "DRegionalDailyArticalCounts";
            this.dw_generic.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_generic.DataObject.FilterString = "";
            this.dw_generic.DataObject.SortString = "";

            ((DArticalCountDateStart)dw_date.DataObject).SelectedItemChanged += new EventHandler(dw_date_itemchanged);
            ((DArticalCountDateStart)dw_date.DataObject).TextBoxLostFocus += new EventHandler(dw_date_itemchanged);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WAddArticleCounts_KeyDown);
        }

        #region Form Design
        private void InitializeComponent()
        {
            this.dw_date = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_generic = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.cb_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_label.Location = new System.Drawing.Point(3, 316);
            this.st_label.Size = new System.Drawing.Size(136, 15);
            this.st_label.Text = "wAddArticleCounts";
            // 
            // dw_date
            // 
            this.dw_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_date.DataObject = null;
            this.dw_date.FireConstructor = false;
            this.dw_date.Location = new System.Drawing.Point(2, 2);
            this.dw_date.Name = "dw_date";
            this.dw_date.Size = new System.Drawing.Size(693, 76);
            this.dw_date.TabIndex = 2;
            // 
            // dw_generic
            // 
            this.dw_generic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_generic.DataObject = null;
            this.dw_generic.FireConstructor = false;
            this.dw_generic.Location = new System.Drawing.Point(2, 80);
            this.dw_generic.Name = "dw_generic";
            this.dw_generic.Size = new System.Drawing.Size(693, 212);
            this.dw_generic.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(534, 305);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_close
            // 
            this.cb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_close.Location = new System.Drawing.Point(625, 305);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 4;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_Click);
            // 
            // WAddArticleCounts
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(712, 332);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_generic);
            this.Controls.Add(this.dw_date);
            this.Controls.Add(this.cb_save);
            this.Name = "WAddArticleCounts";
            this.Text = "Add Article Counts";
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.dw_date, 0);
            this.Controls.SetChildIndex(this.dw_generic, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        ////added by jlwang 
        //public URdsDw t;
        //void DataObject_RetrieveEnd(object sender, EventArgs e)
        //{
        //    for (int i = 1; i < dw_generic.RowCount; i++)
        //    {
        //        t = new URdsDw();
        //        t.DataObject = new DRegionalArticalCounts();
        //        t.Name = i.ToString();
        //        t.Size = new System.Drawing.Size(459, 136);
        //        t.DataObject.BindingSource.DataSource = dw_generic.DataObject.BindingSource.List[i];
        //        //?t.GetControlByName("st_contract").Visible = false;
        //        Console.WriteLine(t.DataObject.BindingSource.DataSource.ToString());

        //        this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        //        tbPanel.SetRow(t, i);
        //        tbPanel.Controls.Add(t, 0, i);
        //    }
        //}

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

        public override void pfc_postopen()
        {
            // TJB  RPI_006  May 2010
            //    Was getting unhandled exception here and in dw_date_ue_getcontracts
            //    - invalid index
            base.pfc_postopen();
            // TJB  RPI_006  May 2010: removed
            //dw_date.InsertItem<ArticalCountDateStart>(0);
            MSheet mCurrent;
            mCurrent = this.m_sheet;
            mCurrent.m_deleterow.Enabled = false;
            mCurrent.m_insertrow.Enabled = false;
            mCurrent.m_updatedatabase.Enabled = false;
            // TJB  RPI_006  May 2010: Added check for RowCount > 0
            if (dw_date.RowCount > 0)
            {
                dw_date.Reset();
            }
            // TJB  RPI_006  May 2010: Changed InsertItem to InsertRow
            dw_date.InsertRow(0);
            //dw_date.InsertItem<ArticalCountDateStart>(0);
            dw_date.Focus();
            this.ib_disableclosequery = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
        }

        public virtual string wf_validate(int arow)
        {
            string sReturn = "";
            if (dw_generic.GetItem<RegionalArticalCounts>(arow).AcRowType == "A")
            {
                dw_generic.GetItem<RegionalArticalCounts>(arow).MarkAsNewAndModified();//dw_generic.SetItemStatus(arow, 0, primary!, newmodified!);
                dw_generic.GetItem<RegionalArticalCounts>(arow).AcRowType = "U";
            }
            return sReturn;
        }

        public virtual void dw_generic_updatestart()
        {
            dw_generic.updatestart();// base.updatestart();
            //dw_generic.updatestart();
            int ll_Row = 0;
            ll_Row = dw_generic.GetNextModified(-1);
            while (ll_Row > 0)
            {
                if (dw_generic.GetItem<RegionalArticalCounts>(ll_Row).AcRowType == "A")
                {
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Row).MarkAsNewAndModified();//dw_generic.SetItemStatus(ll_Row, 0, primary!, newmodified!);
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Row).AcRowType = "U";
                }
                ll_Row = dw_generic.GetNextModified(ll_Row);
            }
            return; //?return 0;
        }

        public virtual void dw_date_ue_getcontracts()
        {
            DateTime? dDate;
            dDate = null;
            int ll_Ctr;
            int? lContract;
            int? lRegion;
            int? lRenewal;
            MMainMenu mCurrent;

            Cursor.Current = Cursors.WaitCursor;

            lContract = dw_date.GetItem<ArticalCountDateStart>(0).ContractNo;
            lRegion = dw_date.GetItem<ArticalCountDateStart>(0).RegionId;
            lRenewal = dw_date.GetItem<ArticalCountDateStart>(0).RgCode;
            string s_weekStart = dw_date.GetControlByName("weekstart").Text;
            if (s_weekStart != "00/00/0000")
            {
                dDate = Convert.ToDateTime(dw_date.GetControlByName("weekstart").Text);
            }
            if ((!(StaticFunctions.f_nempty(lRegion)) && !(StaticFunctions.f_nempty(lRenewal)) && !(dDate == null))
                || (!(StaticFunctions.f_nempty(lContract)) && !(dDate == null)))
            {
                dw_generic.Retrieve(new object[] { lContract, lRegion, lRenewal, dDate });

                mCurrent = this.m_sheet;
                mCurrent.m_updatedatabase.Enabled = true;
            }
            dw_generic.of_SetUpdateable(true);

            for (ll_Ctr = 0; ll_Ctr < dw_generic.RowCount; ll_Ctr++)
            {
                if (dw_generic_DataObject_Name == "DRegionalArticalCounts")
                {
                    if (dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1MediumLetters == 0 &&
                        dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1OtherEnvelopes == 0 &&
                        dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1SmallParcels == 0 &&
                        dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1LargeParcels == 0 &&
                        dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1InwardMail == 0)
                    {
                        dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).MarkAsNewAndModified();
                    }
                }
                else  // dw_generic_DataObject_Name == "DRegionalDailyArticalCounts"
                {
                    if (dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).AcdMonCount == null &&
                        dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).AcdTueCount == null &&
                        dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).AcdWedCount == null &&
                        dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).AcdThuCount == null &&
                        dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).AcdFriCount == null &&
                        dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).AcdSatCount == null)
                    {
                        //dw_generic.SetItemStatus(ll_Ctr, 0, primary!, newmodified!);
                        dw_generic.GetItem<RegionalDailyArticalCounts>(ll_Ctr).MarkAsNewAndModified();
                    }
                }
            }

            // TJB  RPI_006  May 2010: 
            //    Added focus setting to stop tabbing going to <save> button
            //    Tried to get focus on 1st element in dw_generic (didn't work?)
            if (dw_generic.RowCount > 0)
            {
                dw_generic.SelectRow(0, true);
                dw_generic.Focus();
            }
        }
      
        public virtual void dw_date_constructor()
        {
            dw_date.of_SetUpdateable(false);
        }

        #region Events

        private void WAddArticleCounts_SelectedItemChanged(object sender, EventArgs e)
        {
            //dw_date_ue_getcontracts();
            this.dw_generic.Focus();
        }

        public virtual void dw_date_itemchanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                dw_date.URdsDw_Itemchanged(sender, e);
                dw_date_ue_getcontracts();
            }
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            int nSqlCode;
            string sSqlErrText;

            //DWItemStatus l_row_status;
            dw_generic.DataObject.AcceptText();
            if (dw_generic.RowCount > 0)
            {
                // TJB  RPCR_093  Mar-2015
                // Added wait cursor
                Cursor.Current = Cursors.WaitCursor;

                dw_generic.DataObject.Save();
                if (dw_generic_DataObject_Name == "DRegionalArticalCounts")
                {
                    nSqlCode = dw_generic.DataObject.GetItem<RegionalArticalCounts>(0).SQLCode;
                    sSqlErrText = dw_generic.DataObject.GetItem<RegionalArticalCounts>(0).SQLErrText;
                }
                else
                {
                    nSqlCode = dw_generic.DataObject.GetItem<RegionalDailyArticalCounts>(0).SQLCode;
                    sSqlErrText = dw_generic.DataObject.GetItem<RegionalDailyArticalCounts>(0).SQLErrText;
                }

                if ( nSqlCode != 0 )
                {
                    MessageBox.Show("Unable to save.  \n\n"
                                    + "Error Code: " + nSqlCode.ToString() + "\n\n"
                                    + "Error Text: " + sSqlErrText
                                    , "Database Error");
                    return;
                }
            }
            return;
        }

        public void WAddArticleCounts_KeyDown(object sender, KeyEventArgs e)
        {
            // TJB  RPCR_093  Feb-2015
            // Needed to allow <cr> to be used after entering a date 
            // in the contract selection panel
            if (e.KeyValue == 13)
            {
                this.dw_generic.Focus();
                this.dw_date_itemchanged(null, null);
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void cb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
