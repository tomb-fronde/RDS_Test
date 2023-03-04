using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataService;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralrpt;
using System.Collections.Generic;
using NZPostOffice.Entity;
using Metex.Core;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WPvtBagsUpdate : WMaster
    {
        #region Define
        public int il_open_report = 0;

        public int? il_region;

        public bool ib_retrieved = false;

        public string is_1 = String.Empty;

        public string is_2 = String.Empty;

        public string is_3 = String.Empty;

        public string is_4 = String.Empty;

        public string is_5 = String.Empty;

        public string is_6 = String.Empty;

        //  whether or not the user has rights to modify the figures 
        public bool ib_modify = false;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_update;

        public TextBox sle_5;

        public TextBox sle_6;

        public TextBox sle_4;

        public TextBox sle_2;

        public TextBox sle_3;

        public TextBox sle_1;

        public Label st_5;

        public Label st_6;

        public Label st_4;

        public Label st_3;

        public Label st_2;

        public Label st_1;

        public Label st_bag_count;

        public Label st_freq_header;

        public URdsDw dw_regions;

        public Label st_region;

        #endregion

        public WPvtBagsUpdate()
        {
            this.InitializeComponent();
            this.dw_regions.DataObject = new DDddwRegionList();
            dw_regions.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            //jlwang;moved from IC
            ((Metex.Windows.DataEntityCombo)dw_regions.GetControlByName("region_list")).GotFocus += new EventHandler(dw_regions_got_focus);
            ((Metex.Windows.DataEntityCombo)dw_regions.GetControlByName("region_list")).LostFocus += new EventHandler(dw_regions_LostFocus);
            ((DDddwRegionList)dw_regions.DataObject).DDDwItemChanged += new EventHandler(dw_regions_itemchanged);
            dw_regions.Constructor += new UserEventDelegate(dw_regions_constructor);

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
            this.cb_update = new Button();
            this.sle_5 = new TextBox();
            this.sle_6 = new TextBox();
            this.sle_4 = new TextBox();
            this.sle_2 = new TextBox();
            this.sle_3 = new TextBox();
            this.sle_1 = new TextBox();
            this.st_5 = new Label();
            this.st_6 = new Label();
            this.st_4 = new Label();
            this.st_3 = new Label();
            this.st_2 = new Label();
            this.st_1 = new Label();
            this.st_bag_count = new Label();
            this.st_freq_header = new Label();
            this.dw_regions = new URdsDw();
            //!this.dw_regions.DataObject = new DDddwRegionList();
            this.st_region = new Label();
            Controls.Add(cb_update);
            Controls.Add(sle_5);
            Controls.Add(sle_6);
            Controls.Add(sle_4);
            Controls.Add(sle_2);
            Controls.Add(sle_3);
            Controls.Add(sle_1);
            Controls.Add(st_5);
            Controls.Add(st_6);
            Controls.Add(st_4);
            Controls.Add(st_3);
            Controls.Add(st_2);
            Controls.Add(st_1);
            Controls.Add(st_bag_count);
            Controls.Add(st_freq_header);
            Controls.Add(dw_regions);
            Controls.Add(st_region);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(228, 309);
            this.Text = StaticVariables.DisplayName;//ttjin
            // 
            // cb_update
            // 
            this.AcceptButton = cb_update;
            cb_update.Text = "Update";
            cb_update.Enabled = false;
            cb_update.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_update.TabIndex = 8;
            cb_update.Location = new System.Drawing.Point(86, 252);
            cb_update.Size = new System.Drawing.Size(54, 27);
            cb_update.Click += new EventHandler(cb_update_clicked);
            // 
            // sle_5
            // 
            //?sle_5.RightToLeft = RightToLeft.Yes;
            sle_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_5.Enabled = false;
            sle_5.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_5.TabIndex = 3;
            sle_5.Location = new System.Drawing.Point(124, 105);
            sle_5.Size = new System.Drawing.Size(54, 23);
            sle_5.TextAlign = HorizontalAlignment.Right;
            // 
            // sle_6
            // 
            //?sle_6.RightToLeft = RightToLeft.Yes;
            sle_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_6.Enabled = false;
            sle_6.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_6.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_6.TabIndex = 1;
            sle_6.Location = new System.Drawing.Point(124, 77);
            sle_6.Size = new System.Drawing.Size(54, 23);
            sle_6.TextAlign = HorizontalAlignment.Right;
            // 
            // sle_4
            // 
            //?sle_4.RightToLeft = RightToLeft.Yes;
            sle_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_4.Enabled = false;
            sle_4.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_4.TabIndex = 4;
            sle_4.Location = new System.Drawing.Point(124, 133);
            sle_4.Size = new System.Drawing.Size(54, 23);
            sle_4.TextAlign = HorizontalAlignment.Right;
            // 
            // sle_2
            // 
            //?sle_2.RightToLeft = RightToLeft.Yes;
            sle_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_2.Enabled = false;
            sle_2.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_2.TabIndex = 6;
            sle_2.Location = new System.Drawing.Point(124, 189);
            sle_2.Size = new System.Drawing.Size(54, 23);
            sle_2.TextAlign = HorizontalAlignment.Right;

            // 
            // sle_3
            // 
            //?sle_3.RightToLeft = RightToLeft.Yes;
            sle_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_3.Enabled = false;
            sle_3.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_3.TabIndex = 5;
            sle_3.Location = new System.Drawing.Point(124, 161);
            sle_3.Size = new System.Drawing.Size(54, 23);
            sle_3.TextAlign = HorizontalAlignment.Right;
            // 
            // sle_1
            // 
            //?sle_1.RightToLeft = RightToLeft.Yes;
            sle_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_1.Enabled = false;
            sle_1.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_1.TabIndex = 7;
            sle_1.Location = new System.Drawing.Point(124, 217);
            sle_1.Size = new System.Drawing.Size(54, 23);
            sle_1.TextAlign = HorizontalAlignment.Right;
            // 
            // st_5
            // 
            st_5.TabStop = false;
            st_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_5.Text = "5 days/week";
            st_5.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_5.ForeColor = System.Drawing.SystemColors.WindowText;
            st_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_5.Location = new System.Drawing.Point(16, 107);
            st_5.Size = new System.Drawing.Size(77, 19);
            // 
            // st_6
            // 
            st_6.TabStop = false;
            st_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_6.Text = "6 days/week";
            st_6.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_6.ForeColor = System.Drawing.SystemColors.WindowText;
            st_6.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_6.Location = new System.Drawing.Point(16, 79);
            st_6.Size = new System.Drawing.Size(77, 19);
            // 
            // st_4
            // 
            st_4.TabStop = false;
            st_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_4.Text = "4 days/week";
            st_4.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_4.ForeColor = System.Drawing.SystemColors.WindowText;
            st_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_4.Location = new System.Drawing.Point(16, 135);
            st_4.Size = new System.Drawing.Size(77, 19);
            // 
            // st_3
            // 
            st_3.TabStop = false;
            st_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_3.Text = "3 days/week";
            st_3.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_3.ForeColor = System.Drawing.SystemColors.WindowText;
            st_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_3.Location = new System.Drawing.Point(16, 163);
            st_3.Size = new System.Drawing.Size(77, 19);
            // 
            // st_2
            // 
            st_2.TabStop = false;
            st_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_2.Text = "2 days/week";
            st_2.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_2.Location = new System.Drawing.Point(16, 191);
            st_2.Size = new System.Drawing.Size(77, 19);
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_1.Text = "1 days/week";
            st_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_1.Location = new System.Drawing.Point(16, 219);
            st_1.Size = new System.Drawing.Size(77, 19);
            // 
            // st_bag_count
            // 
            st_bag_count.TabStop = false;
            st_bag_count.Text = "Private Bag Count";
            st_bag_count.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_bag_count.ForeColor = System.Drawing.SystemColors.WindowText;
            st_bag_count.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            st_bag_count.Location = new System.Drawing.Point(102, 47);
            st_bag_count.Size = new System.Drawing.Size(115, 19);
            // 
            // st_freq_header
            // 
            st_freq_header.TabStop = false;
            st_freq_header.Text = "Frequency";
            st_freq_header.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_freq_header.ForeColor = System.Drawing.SystemColors.WindowText;
            st_freq_header.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            st_freq_header.Location = new System.Drawing.Point(16, 47);
            st_freq_header.Size = new System.Drawing.Size(78, 19);
            // 
            // dw_regions
            // 
            //!dw_regions.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_regions.VerticalScroll.Visible = false;
            dw_regions.TabIndex = 2;
            dw_regions.Location = new System.Drawing.Point(84, 17);
            dw_regions.Size = new System.Drawing.Size(139, 27);
            //dw_regions.ItemChanged += new EventHandler(dw_regions_itemchanged);

            //((DDddwRegionList)dw_regions.DataObject).DDDwItemChanged += new EventHandler(dw_regions_itemchanged);
            //dw_regions.Constructor += new UserEventDelegate(dw_regions_constructor);
            // 
            // st_region
            // 
            st_region.TabStop = false;
            st_region.Text = "Region";
            st_region.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_region.ForeColor = System.Drawing.SystemColors.WindowText;
            st_region.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_region.Location = new System.Drawing.Point(16, 18);
            st_region.Size = new System.Drawing.Size(65, 19);
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

        public override void open()
        {
            base.open();
            string ls_userid = string.Empty;
            int li_rights_region = 0;
            //  get the parm 
            //  il_open_report = gnv_App.of_Get_Parameters ( ).LongParm
            //  for now - leave this as 0
            il_open_report = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            ls_userid = StaticVariables.gnv_app.of_getuserid();
            if (StaticVariables.gnv_app.of_get_securitymanager().of_getmodifyprivilege(ls_userid, "Private Bags"))
            {
                ib_modify = true;
            }
            else
            {
                ib_modify = false;
            }
            //  see if the user has only one region
            il_region = 0;
            //  TJB  SR4645  Feb 2005
            // select ru.region_id
            //   into :il_region
            //   from rds_user ru
            //  where u_name = :ls_userid
            //  using sqlca;

            // select ru.region_id into :il_region from rds_user ru, rds_user_id rui where rui.ui_userid = :ls_userid and ru.u_id = rui.u_id using sqlca;
            il_region = RDSDataService.GetRegionId(ls_userid, ref SQLCode);
            if (SQLCode != 0 && SQLCode != 100)
            {
                MessageBox.Show("There was an error retrieving your regional data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            //  check the user rights region
            /*select first region_id into :li_rights_region 
                from rds_user_rights rur, rds_user_id_group rui,rds_component rc, rds_user_id rid 
                where rc.rc_name = 'Private Bags' and rid.ui_userid = :ls_userid and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id
                and rc.rc_id = rur.rc_id and rur.rur_read = 'Y' and rur.ug_id = rui.ug_id using sqlca;*/
            li_rights_region = RDSDataService.GetFirstRegionId(ls_userid, ref SQLCode);
            if (SQLCode != 0 && SQLCode != 100)
            {
                MessageBox.Show("There was an error retrieving your regional data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            if (li_rights_region != 0)
            {
                il_region = li_rights_region;
            }
            //  if the user is from a specific region then set up data accordingly
            if (!(il_region == null) && il_region > 0)
            {
                this.of_setregion();
            }
        }

        public virtual void dw_regions_constructor()
        {
            //?base.constructor();
            ((DDddwRegionList)dw_regions.DataObject).Retrieve();
            //  set the first item to be : "Select Region"
            dw_regions.DataObject.InsertItem<DddwRegionList>(0);
            ((TextBox)dw_regions.GetControlByName("region_list1")).Text = "Select Region";
            dw_regions.SetCurrent(0);
            dw_regions.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_regions.of_SetUpdateable(false);
        }

        public virtual void ue_postitemchanged()
        {
            //?base.ue_postitemchanged();
            int li_error;
            int li_1 = int.MinValue;
            int li_2 = int.MinValue;
            int li_3 = int.MinValue;
            int li_4 = int.MinValue;
            int li_5 = int.MinValue;
            int li_6 = int.MinValue;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if (dw_regions.RowCount < 0)
                return;
            try
            {
                il_region = System.Convert.ToInt32(dw_regions.DataObject.GetItem<DddwRegionList>(dw_regions.GetRow()).RegionList1);
                if (il_region == 0)
                    il_region = null;
            }
            catch (Exception e)
            {
                return;
            }
            if (dw_regions.DataObject.GetItem<DddwRegionList>(dw_regions.GetRow()).RegionList == null)
            {
                il_region = null;
            }
            //il_region = ((Metex.Windows.DataEntityCombo)(dw_regions.GetControlByName("region_list"))).InnerDataUserControl.Find(new KeyValuePair<string, object>("RgnName", dw_regions.DataObject.GetItem<DddwRegionList>(dw_regions.GetRow()).RegionList));
            //il_region = (((Metex.Windows.DataEntityCombo)(dw_regions.GetControlByName("region_list"))).InnerDataUserControl.GetItem<DddwRegions>(il_region).RegionId).Value;

            li_error = 1;
            //  do retrieval of the data
            //select top 1 pvt_bag_count into :li_1 from private_bags where pvt_frequency = 1 and region_id = :il_region order by pvt_date desc using sqlca;
            li_1 = RDSDataService.GetTop1PvtBagCount(1, il_region, ref SQLCode, ref SQLErrText);
            //  ignore sqlcode 100 - as this only means that there is no row found
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_2 from private_bags where pvt_frequency = 2 and region_id = :il_region order by pvt_date desc using sqlca;
            li_2 = RDSDataService.GetTop1PvtBagCount(2, il_region, ref SQLCode, ref SQLErrText);
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            // select top 1 pvt_bag_count into :li_3 from private_bags where pvt_frequency = 3 and region_id = :il_region order by pvt_date desc using sqlca;
            li_3 = RDSDataService.GetTop1PvtBagCount(3, il_region, ref SQLCode, ref SQLErrText);

            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_4 from private_bags where pvt_frequency = 4 and region_id = :il_region order by pvt_date desc using sqlca;
            li_4 = RDSDataService.GetTop1PvtBagCount(4, il_region, ref SQLCode, ref SQLErrText);

            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_5 from private_bags where pvt_frequency = 5 and region_id = :il_region order by pvt_date desc using sqlca;
            li_5 = RDSDataService.GetTop1PvtBagCount(5, il_region, ref SQLCode, ref SQLErrText);

            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_6 from private_bags where pvt_frequency = 6 and region_id = :il_region order by pvt_date desc using sqlca;
            li_6 = RDSDataService.GetTop1PvtBagCount(6, il_region, ref SQLCode, ref SQLErrText);

            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            if (li_error == 1)
            {
                //  populate fields with data
                sle_1.Text = li_1.ToString();
                sle_2.Text = li_2.ToString();
                sle_3.Text = li_3.ToString();
                sle_4.Text = li_4.ToString();
                sle_5.Text = li_5.ToString();
                sle_6.Text = li_6.ToString();
                //  save these values
                is_1 = sle_1.Text;
                is_2 = sle_2.Text;
                is_3 = sle_3.Text;
                is_4 = sle_4.Text;
                is_5 = sle_5.Text;
                is_6 = sle_6.Text;
            }
            else
            {
                //  kick off error message
                MessageBox.Show("There was an error retrieving the private bag counts", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //return 1;
            return;
        }

        #region Methods
        public virtual int of_validate()
        {
            //  TWC - 06/06/2003 - initial version
            //  This function will make sure that all the values 
            //  entered are valid positive integers.
            int ll_return;
            ll_return = 1;
            //  testing twc
            int li_test;
            int li_len;
            li_test = Convert.ToInt32(sle_1.Text);
            li_len = sle_1.Text.Length;
            //  make sure that the integer returned is > 0  ( 0 means string is not valid integer)
            int il_res;
            if ((int.TryParse(sle_1.Text, out il_res) == true && Convert.ToInt32(sle_1.Text) >= 0 || sle_1.Text.Length == 0) &&
                (int.TryParse(sle_2.Text, out il_res) == true && Convert.ToInt32(sle_2.Text) >= 0 || sle_2.Text.Length == 0) &&
                (int.TryParse(sle_3.Text, out il_res) == true && Convert.ToInt32(sle_3.Text) >= 0 || sle_3.Text.Length == 0) &&
                (int.TryParse(sle_4.Text, out il_res) == true && Convert.ToInt32(sle_4.Text) >= 0 || sle_4.Text.Length == 0) &&
                (int.TryParse(sle_5.Text, out il_res) == true && Convert.ToInt32(sle_5.Text) >= 0 || sle_5.Text.Length == 0) &&
                (int.TryParse(sle_6.Text, out il_res) == true && Convert.ToInt32(sle_6.Text) >= 0 || sle_6.Text.Length == 0))
            {
                ll_return = 1;
            }
            else
            {
                ll_return = -(1);
            }
            //  make sure the number has no decimal places
            if (sle_1.Text.IndexOf('.') != -1 || sle_2.Text.IndexOf('.') != -1 || sle_3.Text.IndexOf('.') != -1 || sle_4.Text.IndexOf('.') != -1 || sle_5.Text.IndexOf('.') != -1 || sle_6.Text.IndexOf('.') != -1)
            {
                ll_return = -(1);
            }
            return ll_return;
        }

        public virtual int of_update()
        {
            //  Tim Chan 06/06/2003
            //  initial version
            int ll_return = 1;
            int ll_1;
            int ll_2;
            int ll_3;
            int ll_4;
            int ll_5;
            int ll_6;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            //  get the data and do the update 
            if (sle_1.Text.Length > 0)
            {
                ll_1 = System.Convert.ToInt32(sle_1.Text);
                //insert into rd.private_bags (pvt_frequency, pvt_bag_count, region_id)  values  ( 1, :ll_1, :il_region);
                RDSDataService.InsertIntoPRivateBages(1, ll_1, il_region, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to insert into the private bags table.\n\n" + "Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //?ROLLBACK;
                return -(1);
            }
            if (sle_2.Text.Length > 0)
            {
                ll_2 = System.Convert.ToInt32(sle_2.Text);
                //insert into rd.private_bags ( pvt_frequency, pvt_bag_count, region_id) values ( 2, :ll_2, :il_region);
                RDSDataService.InsertIntoPRivateBages(2, ll_2, il_region, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to insert into the private bags table.\n\n" + "Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //?ROLLBACK;
                return -(1);
            }
            if (sle_3.Text.Length > 0)
            {
                ll_3 = System.Convert.ToInt32(sle_3.Text);
                //insert into rd.private_bags ( pvt_frequency, pvt_bag_count, region_id) values ( 3, :ll_3, :il_region);
                RDSDataService.InsertIntoPRivateBages(3, ll_3, il_region, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to insert into the private bags table.\n\n" + "Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //?ROLLBACK;
                return -(1);
            }
            if (sle_4.Text.Length > 0)
            {
                ll_4 = System.Convert.ToInt32(sle_4.Text);
                //insert into rd.private_bags ( pvt_frequency, pvt_bag_count, region_id) values ( 4, :ll_4, :il_region);
                RDSDataService.InsertIntoPRivateBages(4, ll_4, il_region, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to insert into the private bags table.\n\n" + "Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //?ROLLBACK;
                return -(1);
            }
            if (sle_5.Text.Length > 0)
            {
                ll_5 = System.Convert.ToInt32(sle_5.Text);
                //insert into rd.private_bags ( pvt_frequency, pvt_bag_count, region_id) values ( 5, :ll_5, :il_region);
                RDSDataService.InsertIntoPRivateBages(5, ll_5, il_region, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to insert into the private bags table.\n\n" + "Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //?ROLLBACK;
                return -(1);
            }
            if (sle_6.Text.Length > 0)
            {
                ll_6 = System.Convert.ToInt32(sle_6.Text);
                //insert into rd.private_bags ( pvt_frequency, pvt_bag_count, region_id) values ( 6, :ll_6, :il_region);
                RDSDataService.InsertIntoPRivateBages(6, ll_6, il_region, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to insert into the private bags table.\n\n" + "Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //?ROLLBACK;
                return -(1);
            }
            //  do commit
            if (ll_return == 1)
            {
                //? commit;
            }
            return ll_return;
        }

        public virtual int of_setregion()
        {
            //  Tim Chan - 29/01/2004
            //  Initial version
            //  This function will set the region drop down item to be correct.
            //  When the user has a specified region  ( not national)
            //  then retrieve the data for that region.
            sle_1.Enabled = ib_modify;
            sle_2.Enabled = ib_modify;
            sle_3.Enabled = ib_modify;
            sle_4.Enabled = ib_modify;
            sle_5.Enabled = ib_modify;
            sle_6.Enabled = ib_modify;
            //  enable the update button
            cb_update.Enabled = ib_modify;
            cb_update.Visible = ib_modify;
            //  get the data
            int li_error;
            int li_1 = 0;
            int li_2 = 0;
            int li_3 = 0;
            int li_4 = 0;
            int li_5 = 0;
            int li_6 = 0;
            li_error = 1;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            //  do retrieval of the data
            //select top 1 pvt_bag_count into :li_1 from private_bags where pvt_frequency = 1 and region_id = :il_region order by pvt_date desc using sqlca; 
            li_1 = RDSDataService.GetTop1PvtBagCount(1, il_region, ref SQLCode, ref SQLErrText);
            //  ignore sqlcode 100 - as this only means that there is no row found
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_2 from private_bags where pvt_frequency = 2 and region_id = :il_region order by pvt_date desc using sqlca;
            li_2 = RDSDataService.GetTop1PvtBagCount(2, il_region, ref SQLCode, ref SQLErrText);
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            // select top 1 pvt_bag_count into :li_3 from private_bags where pvt_frequency = 3 and region_id = :il_region order by pvt_date desc using sqlca;
            li_3 = RDSDataService.GetTop1PvtBagCount(3, il_region, ref SQLCode, ref SQLErrText);
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            // select top 1 pvt_bag_count into :li_4 from private_bags where pvt_frequency = 4 and region_id = :il_region order by pvt_date desc using sqlca;
            li_4 = RDSDataService.GetTop1PvtBagCount(4, il_region, ref SQLCode, ref SQLErrText);
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_5 from private_bags where pvt_frequency = 5 and region_id = :il_region order by pvt_date desc using sqlca;
            li_5 = RDSDataService.GetTop1PvtBagCount(5, il_region, ref SQLCode, ref SQLErrText);
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            //select top 1 pvt_bag_count into :li_6 from private_bags where pvt_frequency = 6 and region_id = :il_region order by pvt_date desc using sqlca;
            li_6 = RDSDataService.GetTop1PvtBagCount(6, il_region, ref SQLCode, ref SQLErrText);
            if (li_error == 1 && SQLCode != 0 && SQLCode != 100)
            {
                li_error = -(1);
            }
            if (li_error == 1)
            {
                //  populate fields with data
                sle_1.Text = li_1.ToString();
                sle_2.Text = li_2.ToString();
                sle_3.Text = li_3.ToString();
                sle_4.Text = li_4.ToString();
                sle_5.Text = li_5.ToString();
                sle_6.Text = li_6.ToString();
                //  save these values
                is_1 = sle_1.Text;
                is_2 = sle_2.Text;
                is_3 = sle_3.Text;
                is_4 = sle_4.Text;
                is_5 = sle_5.Text;
                is_6 = sle_6.Text;
            }
            else
            {
                //  kick off error message
                MessageBox.Show("There was an error retrieving the private bag counts.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //  insert correct region disable the dropdown
            string ls_region;
            //select rgn_name into :ls_region from region where region_id = :il_region using sqlca;
            ls_region = RDSDataService.GetRegionValue(il_region, ref SQLCode);
            if (SQLCode != 0 && SQLCode != 100)
            {
                MessageBox.Show("There was an error retrieving your regional data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.TriggerEvent("close");
                this.Close();
            }
            else
            {
                dw_regions.DataObject.InsertItem<DddwRegionList>(1);
                dw_regions.DataObject.GetItem<DddwRegionList>(1).RegionList = ls_region;
                dw_regions.SetCurrent(1);
                dw_regions.Enabled = false;
            }
            //  change the background colour of the regions dropdown item
            //?dw_regions.(7)DataControl["region_list"].BackColor =79741120");
            return 1;
        }
        #endregion

        #region Events
        public virtual void dw_regions_got_focus(object sender, EventArgs e)
        {
            if (!(((Metex.Windows.DataEntityCombo)dw_regions.GetControlByName("region_list")).SelectedIndex < 0))
            {
                ((TextBox)dw_regions.GetControlByName("region_list1")).Visible = false;
            }
        }

        public virtual void dw_regions_LostFocus(object sender, EventArgs e)
        {
            if (!(((Metex.Windows.DataEntityCombo)dw_regions.GetControlByName("region_list")).SelectedIndex < 0))
            {
                this.sle_5.Focus();
            }
        }

        public virtual void dw_regions_itemchanged(object sender, EventArgs e)
        {
            //?base.itemchanged();
            //  enable the data entry fields as a region is now selected
            //  also - clear all data
            dw_regions.AcceptText();
            DialogResult li_answer;
            if (cb_update.Enabled == true)
            {
                if (is_1 != sle_1.Text || is_2 != sle_2.Text || is_3 != sle_3.Text || is_4 != sle_4.Text || is_5 != sle_5.Text || is_6 != sle_6.Text)
                {
                    li_answer = MessageBox.Show("Do you wish to update the database?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (li_answer == DialogResult.Yes)
                    {
                        of_update();
                    }
                }
            }
            sle_1.Enabled = this.ib_modify;
            sle_2.Enabled = this.ib_modify;
            sle_3.Enabled = this.ib_modify;
            sle_4.Enabled = this.ib_modify;
            sle_5.Enabled = this.ib_modify;
            sle_6.Enabled = this.ib_modify;
            sle_1.Text = "";
            sle_2.Text = "";
            sle_3.Text = "";
            sle_4.Text = "";
            sle_5.Text = "";
            sle_6.Text = "";
            //  enable the update button
            cb_update.Enabled = this.ib_modify;
            ue_postitemchanged();
        }

        public virtual void cb_update_clicked(object sender, EventArgs e)
        {
            //  want this done in the post changed event of region now
            //  il_region = Metex.Common.Convert.ToInt32( dw_regions.getitemstring ( dw_regions.getrow ( ), "region_list"))
            if (of_validate() == -(1))
            {
                MessageBox.Show("The data entered is not valid - the update will not proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //  do update
                if (of_update() == -(1))
                {
                    MessageBox.Show("There was a problem updating the new private bag counts.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Private bag counts successfully updated.", "Update Private Bags", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (il_open_report == 1)
                    {
                        // open the deed compliance report                    
                        OpenSheet<WDeedComp>(StaticVariables.MainMDI);
                    }
                    this.Close();
                }
            }
        }
        #endregion
    }
}