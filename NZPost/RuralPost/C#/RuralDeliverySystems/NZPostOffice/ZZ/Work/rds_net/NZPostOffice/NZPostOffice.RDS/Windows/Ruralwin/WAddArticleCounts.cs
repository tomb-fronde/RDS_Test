using System;
//using rural32;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddArticleCounts : WAncestorWindow
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_generic;

        public URdsDw dw_date;

        public Button cb_save;
        #endregion

        public WAddArticleCounts()
        {
            this.InitializeComponent();

            //jlwang:moved from IC
            this.dw_date.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_date_constructor);
            ((DArticalCountDateStart)this.dw_date.DataObject).SelectedItemChanged += new EventHandler(WAddArticleCounts_SelectedItemChanged);
            //jlwnag:end
        }

        #region Form Design
        private void InitializeComponent()
        {
            this.dw_generic = new URdsDw();
            this.dw_date = new URdsDw();
            this.dw_date.DataObject = new DArticalCountDateStart();
            this.cb_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_generic
            // 
            this.dw_generic.DataObject = new DRegionalArticalCounts();
            this.dw_generic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_generic.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_generic.DataObject.FilterString = "";
            this.dw_generic.Location = new System.Drawing.Point(2, 80);
            this.dw_generic.Name = "dw_generic";
            this.dw_generic.Size = new System.Drawing.Size(450, 150);
            this.dw_generic.DataObject.SortString = "";
            this.dw_generic.TabIndex = 1;
            // 
            // dw_date
            // 
            this.dw_date.DataObject.FilterString = "";
            this.dw_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_date.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_date.Location = new System.Drawing.Point(2, 2);
            this.dw_date.Name = "dw_date";
            this.dw_date.Size = new System.Drawing.Size(450, 76);
            this.dw_date.DataObject.SortString = "";
            this.dw_date.TabIndex = 2;
            ((DArticalCountDateStart)dw_date.DataObject).SelectedItemChanged += new EventHandler(dw_date_itemchanged);
            ((DArticalCountDateStart)dw_date.DataObject).TextBoxLostFocus += new EventHandler(dw_date_itemchanged);
            //this.dw_date.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_date_constructor);
            //((DArticalCountDateStart)this.dw_date.DataObject).SelectedItemChanged += new EventHandler(WAddArticleCounts_SelectedItemChanged);

            // 
            // cb_save
            // 
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom)));
            this.cb_save.Location = new System.Drawing.Point(376, 233);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);

            // 
            // st_label
            // 
            st_label.Text = "w_add_article_counts";
            st_label.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left);
            st_label.Width = 136;
            st_label.Location = new System.Drawing.Point(3, 248);

            // 
            // WAddArticleCounts
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(469, 270);
            this.Controls.Add(this.dw_generic);
            this.Controls.Add(this.dw_date);
            this.Controls.Add(this.cb_save);

            this.Name = "w_add_article_counts";
            this.Text = "Add Article Counts";
            this.KeyDown += new KeyEventHandler(WAddArticleCounts_KeyDown);
            this.ResumeLayout(false);
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
            base.pfc_postopen();
            dw_date.InsertItem<ArticalCountDateStart>(0);
            MSheet mCurrent;
            mCurrent = this.m_sheet;
            mCurrent.m_deleterow.Enabled = false;
            mCurrent.m_insertrow.Enabled = false;
            mCurrent.m_updatedatabase.Enabled = false;
            dw_date.Reset();
            dw_date.InsertItem<ArticalCountDateStart>(0);
            dw_date.Focus();

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
            bool lb_Null;
            int? lRegion;
            int? lRenewal;
            MMainMenu mCurrent;
            lRegion = dw_date.GetItem<ArticalCountDateStart>(0).RegionId;
            lRenewal = dw_date.GetItem<ArticalCountDateStart>(0).RgCode;
            if (dw_date.GetControlByName("weekstart").Text != "00/00/00")
            {
                dDate = Convert.ToDateTime(dw_date.GetControlByName("weekstart").Text);//dw_date.GetItem<ArticalCountDateStart>(0).Weekstart;
            }
            if (!(StaticFunctions.f_nempty(lRegion)) && !(StaticFunctions.f_nempty(lRenewal)) && !(dDate == null))//if (!(f_nEmpty(lRegion)) && !(f_nEmpty(lRenewal)) && !(IsNull(dDate)))
            {
                dw_generic.Retrieve(new object[] { lRegion, lRenewal, dDate });

                mCurrent = this.m_sheet;
                mCurrent.m_updatedatabase.Enabled = true;
            }
            dw_generic.of_SetUpdateable(true);
            for (ll_Ctr = 0; ll_Ctr < dw_generic.RowCount; ll_Ctr++)
            {
                if (dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1MediumLetters == 0 &&
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1OtherEnvelopes == 0 &&
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1SmallParcels == 0 &&
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1LargeParcels == 0 &&
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).AcW1InwardMail == 0)//if (dw_generic.GetItemNumber(ll_Ctr, "ac_w1_medium_letters") == 0 && dw_generic.GetItemNumber(ll_Ctr, "ac_w1_other_envelopes") == 0 && dw_generic.GetItemNumber(ll_Ctr, "ac_w1_small_parcels") == 0 && dw_generic.GetItemNumber(ll_Ctr, "ac_w1_large_parcels") == 0 && dw_generic.GetItemNumber(ll_Ctr, "ac_w1_inward_mail") == 0)
                {
                    dw_generic.GetItem<RegionalArticalCounts>(ll_Ctr).MarkAsNewAndModified();//dw_generic.SetItemStatus(ll_Ctr, 0, primary!, newmodified!);
                }
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
            dw_date.URdsDw_Itemchanged(sender, e);
            dw_date_ue_getcontracts();//dw_date.PostEvent("ue_getcontracts");
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            int ll_Row;
            int ll_RowCount;
            int ll_contract_no;
            //DWItemStatus l_row_status;
            ll_RowCount = dw_generic.RowCount;
            if (ll_RowCount > 0)
            {
                dw_generic.DataObject.Save();//dw_generic.Update();

                if (dw_generic.DataObject.GetItem<RegionalArticalCounts>(0).SQLCode != 0)//(StaticVariables.sqlca.SQLCode != 0)
                {
                    //MessageBox.Show("Unable to update.  \n\n" + "Error Code: " + String(app.sqlca.SQLCode) + "\n\nError Text: " + app.sqlca.SQLErrText, "Database Error");
                    MessageBox.Show("Unable to update.  \n\n" + "Error Code: " + dw_generic.DataObject.GetItem<RegionalArticalCounts>(0).SQLCode.ToString() + "\n\nError Text: " + dw_generic.DataObject.GetItem<RegionalArticalCounts>(0).SQLErrText, "Database Error");

                    //?RollBack;
                    return;//? return FAILURE;
                }
                else
                {
                    //?COMMIT;
                }
            }
            return;//?return SUCCESS;
        }

        public void WAddArticleCounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.dw_generic.Focus();
                this.dw_date_itemchanged(null, null);
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
