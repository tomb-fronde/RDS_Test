using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.Shared.Managers;
using NZPostOffice.RDS.Windows.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WFrequencies2001 : WAncestorWindow
    {
        #region Define
        private WFrequencies2001 iw_this;

        public int il_contract;

        public int il_sf_key;

        public string is_delivery_days = String.Empty;

        public int il_frequency = 0;

        public bool ib_error = false;

        public bool lreset = true;

        public string terminal_point_const = "Terminal";

        public int il_terminal_row = -(1);

        public bool ib_terminalNotChanged = false;

        public URdsDw idw_route_freq;

        public URdsDw idw_header;

        public URdsDw idw_extensions;

        public URdsDw idw_description;

        public URdsDw idw_mail_carried;

        public URdsDw idw_annotation;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public TabControl tab_frequencies;

        public TabPage tabpage_extensions;

        public URdsDw dw_extensions;

        public TabPage tabpage_description;

        public URdsDw dw_frequency_description;

        public TabPage tabpage_mail_carried;

        public URdsDw dw_mail_carried;

        public TabPage tabpage_annotation;

        public TextBox mle_annotation;

        public URdsDw dw_annotation;

        public URdsDw dw_header;

        public UCb cb_seq;

        #endregion

        public WFrequencies2001()
        {
            this.InitializeComponent();

            //jlwang:moved from IC
            dw_extensions.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_extensions_constructor);
            dw_extensions.DataObject.BorderStyle = BorderStyle.Fixed3D;
            ((DFrequenceDistances)dw_extensions.DataObject).CellDoubleClick += new EventHandler(dw_extensions_doubleclicked);

            ((DFreqDescription)dw_frequency_description.DataObject).CellClick += new EventHandler(dw_frequency_description_clicked);
            dw_frequency_description.DataObject.RetrieveEnd += new EventHandler(dw_frequency_description_retrieveend);
            dw_frequency_description.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_frequency_description_constructor);
            dw_frequency_description.PfcDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_frequency_description_pfc_deleterow);
            dw_frequency_description.PfcInsertRow = new NZPostOffice.RDS.Controls.UserEventDelegate(dw_frequency_description_pfc_insertrow);
            dw_frequency_description.PfcPreInsertRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_frequency_description_pfc_preinsertrow);
            dw_frequency_description.PfcPreUpdate += new UserEventDelegate1(dw_frequency_description_pfc_preupdate);
            dw_frequency_description.PfcValidation += new UserEventDelegate1(dw_frequency_description_pfc_validation);

            dw_mail_carried.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_mail_carried_constructor);
            dw_mail_carried.PfcPreUpdate += new UserEventDelegate1(dw_mail_carried_pfc_preupdate);
            dw_mail_carried.PfcValidation += new UserEventDelegate1(dw_mail_carried_pfc_validation);
            dw_mail_carried.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_annotation.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_annotation_constructor);

            dw_header.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_header_constructor);

            //jlwang:end

            //! used to get rfpt_id old value before changing it
            ((DFreqDescription)(dw_frequency_description.DataObject)).Grid.CellEnter += new DataGridViewCellEventHandler(Grid_CellEnter);

        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tab_frequencies = new TabControl();

            dw_header = new URdsDw();
            this.dw_header.DataObject = new DFrequencyTitle();
            this.cb_seq = new UCb();

            Controls.Add(dw_header);
            Controls.Add(tab_frequencies);
            Controls.Add(cb_seq);
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(583, 410);
            // 
            // st_label
            // 
            st_label.Text = "w_frequencies2001";
            st_label.Location = new System.Drawing.Point(5, 359);
            // 
            // tab_frequencies
            // 
            TabPage tabpage_extensions = new TabPage();
            TabPage tabpage_description = new TabPage();
            TabPage tabpage_mail_carried = new TabPage();
            TabPage tabpage_annotation = new TabPage();
            tab_frequencies.Controls.Add(tabpage_extensions);
            tab_frequencies.Controls.Add(tabpage_description);
            tab_frequencies.Controls.Add(tabpage_mail_carried);
            tab_frequencies.Controls.Add(tabpage_annotation);
            tab_frequencies.SelectedIndex = 0;
            tab_frequencies.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_frequencies.TabIndex = 1;
            tab_frequencies.Location = new System.Drawing.Point(3, 6);
            tab_frequencies.Size = new System.Drawing.Size(557, 340);
            tab_frequencies.SelectedIndexChanged += new EventHandler(tab_frequencies_selectionchanging);
            tab_frequencies.SelectedIndexChanged += new EventHandler(tab_frequencies_selectionchanged);
            // 
            // tabpage_extensions
            // 
            dw_extensions = new URdsDw();
            dw_extensions.DataObject = new DFrequenceDistances();
            tabpage_extensions.Controls.Add(dw_extensions);
            tabpage_extensions.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_extensions.Text = "Extensions";
            tabpage_extensions.Size = new System.Drawing.Size(549, 311);
            tabpage_extensions.Top = 25;
            tabpage_extensions.Left = 3;
            tabpage_extensions.Visible = false;
            tabpage_extensions.Tag = "ComponentName=Frequency;";
            // 
            // dw_extensions
            // 
            dw_extensions.TabIndex = 3;
            dw_extensions.Location = new System.Drawing.Point(5, 68);
            //?dw_extensions.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_extensions.Size = new System.Drawing.Size(538, 240);
            dw_extensions.RowFocusChanged += new EventHandler(dw_extensions_rowfocuschanged);
            dw_extensions.GotFocus += new EventHandler(dw_extensions_getfocus);
            //dw_extensions.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_extensions_constructor); 
            //((DFrequenceDistances)dw_extensions.DataObject).CellDoubleClick += new EventHandler(dw_extensions_doubleclicked);
            // 
            // tabpage_description
            // 
            dw_frequency_description = new URdsDw();
            dw_frequency_description.DataObject = new DFreqDescription();
            tabpage_description.Controls.Add(dw_frequency_description);
            tabpage_description.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_description.Text = "Description";
            tabpage_description.Top = 25;
            tabpage_description.Left = 3;
            tabpage_description.Size = new System.Drawing.Size(549, 311);
            tabpage_description.Visible = false;
            tabpage_description.Tag = "ComponentName=Frequency Description;";

            // 
            // dw_frequency_description
            // 
            dw_frequency_description.TabIndex = 2;
            dw_frequency_description.Location = new System.Drawing.Point(5, 70);
            dw_frequency_description.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_frequency_description.Size = new System.Drawing.Size(540, 239);
            dw_frequency_description.ItemChanged += new EventHandler(dw_frequency_description_itemchanged);
            dw_frequency_description.LostFocus += new EventHandler(dw_frequency_description_losefocus);

            //((DFreqDescription)dw_frequency_description.DataObject).CellClick += new EventHandler(dw_frequency_description_clicked);
            //dw_frequency_description.DataObject.RetrieveEnd += new EventHandler(dw_frequency_description_retrieveend);
            //dw_frequency_description.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_frequency_description_constructor);
            //dw_frequency_description.PfcDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_frequency_description_pfc_deleterow);
            //dw_frequency_description.PfcInsertRow = new NZPostOffice.RDS.Controls.UserEventDelegate(dw_frequency_description_pfc_insertrow);
            //dw_frequency_description.PfcPreInsertRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_frequency_description_pfc_preinsertrow);
            //dw_frequency_description.PfcPreUpdate += new UserEventDelegate1(dw_frequency_description_pfc_preupdate);
            //dw_frequency_description.PfcValidation += new UserEventDelegate1(dw_frequency_description_pfc_validation);

            // 
            // tabpage_mail_carried
            // 
            // Gegerated from create event for tabpage_mail_carried
            dw_mail_carried = new URdsDw();
            dw_mail_carried.DataObject = new DMailCarriedForm();
            //dw_mail_carried.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_mail_carried.Controls.Add(dw_mail_carried);
            tabpage_mail_carried.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_mail_carried.Text = "Mail Carried";
            tabpage_mail_carried.Top = 25;
            tabpage_mail_carried.Left = 3;
            tabpage_mail_carried.Size = new System.Drawing.Size(549, 330);
            tabpage_mail_carried.Visible = false;
            tabpage_mail_carried.Tag = "ComponentName=Mail Carried;";

            // 
            // dw_mail_carried
            // 
            dw_mail_carried.TabIndex = 2;
            dw_mail_carried.Location = new System.Drawing.Point(5, 70);
            dw_mail_carried.Size = new System.Drawing.Size(540, 235);
            ((DMailCarriedForm)dw_mail_carried.DataObject).CellButtonClick += new EventHandler(dw_mail_carried_clicked);
            dw_mail_carried.ItemChanged += new EventHandler(dw_mail_carried_itemchanged);
            //?dw_mail_carried.ItemFocusChanged += new Metex.PBLib.Type.DataWindowEventHandler(dw_mail_carried_itemfocuschanged);
            dw_mail_carried.LostFocus += new EventHandler(dw_mail_carried_losefocus);
            //dw_mail_carried.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_mail_carried_constructor);
            //dw_mail_carried.PfcPreUpdate += new UserEventDelegate1(dw_mail_carried_pfc_preupdate);
            //dw_mail_carried.PfcValidation += new UserEventDelegate1(dw_mail_carried_pfc_validation);

            // 
            // tabpage_annotation
            // 
            mle_annotation = new TextBox();
            dw_annotation = new URdsDw();
            dw_annotation.DataObject = new DFrequencyAnnotation();
            tabpage_annotation.Controls.Add(mle_annotation);
            tabpage_annotation.Controls.Add(dw_annotation);
            tabpage_annotation.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_annotation.Text = "Annotation";
            tabpage_annotation.Top = 25;
            tabpage_annotation.Left = 3;
            tabpage_annotation.Size = new System.Drawing.Size(549, 311);
            tabpage_annotation.Visible = false;
            tabpage_annotation.Tag = "ComponentName=Frequency;";

            // 
            // mle_annotation
            // 
            mle_annotation.Multiline = true;
            mle_annotation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            mle_annotation.ForeColor = System.Drawing.SystemColors.WindowText;
            mle_annotation.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            mle_annotation.TabIndex = 3;
            mle_annotation.Location = new System.Drawing.Point(8, 89);
            mle_annotation.Size = new System.Drawing.Size(529, 208);
            mle_annotation.TextChanged += new EventHandler(mle_annotation_modified);
            // 
            // dw_annotation
            // 
            dw_annotation.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_annotation.TabIndex = 2;
            dw_annotation.Location = new System.Drawing.Point(8, 65);
            dw_annotation.Size = new System.Drawing.Size(529, 24);
            dw_annotation.Tag = "ComponentName=Annotation;";
            dw_annotation.LostFocus += new EventHandler(dw_annotation_losefocus);
            //dw_annotation.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_annotation_constructor);
            // 
            // dw_header
            // 
            dw_header.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_header.TabIndex = 3;
            dw_header.Location = new System.Drawing.Point(20, 30);
            dw_header.Size = new System.Drawing.Size(519, 60);
            //dw_header.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_header_constructor);
            // 
            // cb_seq
            // 
            cb_seq.Text = "Address Sequencer";
            cb_seq.TabIndex = 2;
            cb_seq.Location = new System.Drawing.Point(449, 353);
            cb_seq.Size = new System.Drawing.Size(114, 24);
            cb_seq.Click += new EventHandler(cb_seq_clicked);
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

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int ll_Row;
            string ls_Title;
            MMainMenu mCurrent;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = Convert.ToInt32(lvn_Criteria.of_getcriteria("Contract_no"));
            il_sf_key = Convert.ToInt32(lvn_Criteria.of_getcriteria("Sf_key"));
            is_delivery_days = lvn_Criteria.of_getcriteria("Rf_delivery_days").ToString();
            idw_route_freq = (URdsDw)lvn_Criteria.of_getcriteria("Dw_route_freq");
            // Retrieve fisrt dw
            ((DFrequenceDistances)idw_extensions.DataObject).Retrieve(il_contract, il_sf_key, is_delivery_days);
            // Populate dw_header
            ll_Row = idw_route_freq.GetRow();
            //?dw_header.SetPosition(totop!);            
            //dw_header.InsertRow(0);
            dw_header.DataObject.InsertItem<FrequencyTitle>(0);
            dw_header.DataObject.GetItem<FrequencyTitle>(0).ContractNo = il_contract;//setitem(1, "contract_no", il_contract);
            dw_header.DataObject.GetControlByName("st_contract").Text = idw_route_freq.DataObject.GetControlByName("st_contract").Text;//.text") + '\'');
            //dw_header.DataObject.GetItem<FrequencyTitle>(0).SfDescription = idw_route_freq.DataObject.Describe("evaluate ( \'lookupdisplay ( sf_key)\'," + ll_Row.ToString() + ')'));
            dw_header.DataObject.GetItem<FrequencyTitle>(0).SfDescription = Convert.ToString(((Metex.Windows.DataEntityGrid)(idw_route_freq.GetControlByName("grid"))).Rows[ll_Row].Cells[0].FormattedValue);

            dw_header.DataObject.GetItem<FrequencyTitle>(0).Mon = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_monday")) == "Y" ? true : false;
            dw_header.DataObject.GetItem<FrequencyTitle>(0).Tue = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_tuesday")) == "Y" ? true : false;
            dw_header.DataObject.GetItem<FrequencyTitle>(0).Wed = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_wednesday")) == "Y" ? true : false;
            dw_header.DataObject.GetItem<FrequencyTitle>(0).Thu = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_thursday")) == "Y" ? true : false;
            dw_header.DataObject.GetItem<FrequencyTitle>(0).Fri = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_friday")) == "Y" ? true : false;
            dw_header.DataObject.GetItem<FrequencyTitle>(0).Sat = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_saturday")) == "Y" ? true : false;
            dw_header.DataObject.GetItem<FrequencyTitle>(0).Sun = Convert.ToString(idw_route_freq.DataObject.GetValue(ll_Row, "rf_sunday")) == "Y" ? true : false;
            ls_Title = " ( " + il_contract.ToString() + ") " + dw_header.DataObject.GetItem<FrequencyTitle>(0).SfDescription;// "sf_description");
            this.Text = ls_Title;

            dw_header.DataObject.BindingSource.CurrencyManager.Refresh();
            // 
            // //Set customer sequencer access manually
            // Long ll_Temp_ComponenId
            // ll_Temp_ComponenId = gnv_App.of_Get_SecurityManager ( ).of_Get_ComponentId ( 'Customer Sequencer')
            // 
            // If	Not  ( gnv_App.ib_Secure) or gnv_App.of_Get_SecurityManager ( ).of_Get_USer ( ).of_HasPrivilege ( ll_Temp_ComponenId) then
            // 
            // 	mCurrent = menuid
            // 	If isValid ( mCurrent) Then
            // 		mCurrent.m_ruraldelivery.m_customersequencer.visible = true
            // 		mCurrent.m_ruraldelivery.m_customersequencer.Enabled = true
            // 		mCurrent.m_ruraldelivery.m_customersequencer.toolbaritemvisible = true
            // 	End if
            // 
            // End if
            iw_this = this;
        }

        public override void pfc_preopen()
        {
            this.of_set_componentname("Frequency");
        }

        public override int closequery()
        {
            base.closequery();
            //  TJB SR4602 25-Nov-2004
            //  Replaced the annotation text edit field in the datawindow 
            //  with a multi-line edit control, to allow wordwrapping.
            // 
            //  Before closing, check to see whether the user has 
            //  changed the mle annotation.  If so, copy it to the 
            //  datawindow buffer, and let the close function ask 
            //  whether it should be saved.
            // 
            //  See also 
            // 		mle_annotation.modified
            // 		w_frequencies2001.closequery
            // 
            //  This is mostly copied from the tab_frequencies.selectionchanging event
            int ll_row;
            DialogResult ll_ret;
            string ls_mleAnnotation;
            string ls_dwAnnotation;
            ll_row = idw_annotation.GetRow();
            if (ll_row >= 0)
            {
                ls_mleAnnotation = mle_annotation.Text;
                ls_dwAnnotation = Convert.ToString(idw_annotation.DataObject.GetValue(ll_row, "rf_annotation"));
                if (ls_mleAnnotation == null)
                {
                    ls_mleAnnotation = "";
                }
                if (ls_dwAnnotation == null)
                {
                    ls_dwAnnotation = "";
                }
                if (!(ls_dwAnnotation == ls_mleAnnotation))
                {
                    if (uf_copy_annotation(ls_mleAnnotation) == 1)
                    {
                        return 1;
                    }
                    ll_ret = MessageBox.Show("Do you want to save changes?", "Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (ll_ret == DialogResult.Yes)
                    {
                        //  Sometimes the print flag is null when it should be either 'Y' or 'N'
                        if (idw_annotation.DataObject.GetValue(ll_row, "rf_annotation_print") == null)
                        {
                            idw_annotation.DataObject.SetValue(ll_row, "rf_annotation_print", 'N');
                        }
                        int il_ret = pfc_save();
                        if (il_ret < 0)
                        {
                            return 1;
                        }
                    }
                    else if (ll_ret == DialogResult.No)
                    {
                        idw_annotation.DataObject.Reset();
                        //  The user didn't want to save it; put the old annotation text back.
                        mle_annotation.Text = ls_dwAnnotation;
                    }
                    else
                    {
                        //  The user cancelled: don't change anything
                        return 1;
                    }
                }
            }
            return 0;
        }

        #region Methods

        public virtual int wf_get_outlet(string acode)
        {
            string sOutlet;
            //?idw_mail_carried.Modify(acode + "_pcklst_bmp.filename=\'..\\bitmaps\\pcklstdn.bmp\'");
            //?idw_mail_carried.SetColumn(acode + "_picklist");
            sOutlet = Convert.ToString(idw_mail_carried.DataObject.GetValue(idw_mail_carried.GetRow(), "mc_" + acode + "_outlet_name"));
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(this.of_get_componentname());
            StaticVariables.gnv_app.of_get_parameters().integerparm = null;
            //OpenWithParm(w_qs_outlet, sOutlet);
            StaticMessage.StringParm = sOutlet;
            WQsOutlet w_qs_outlet = new WQsOutlet();
            w_qs_outlet.ShowDialog();

            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                idw_mail_carried.DataObject.SetValue(idw_mail_carried.GetRow(), "mc_" + acode + "_outlet", StaticVariables.gnv_app.of_get_parameters().longparm);
                idw_mail_carried.DataObject.SetValue(idw_mail_carried.GetRow(), "mc_" + acode + "_outlet_name", StaticVariables.gnv_app.of_get_parameters().stringparm);
            }
            //?idw_mail_carried.Modify(acode + "_pcklst_bmp.filename=\'..\\bitmaps\\pcklstup.bmp\'");
            //dw_mail_carried.DataObject.BindingSource.CurrencyManager.Refresh();
            for (int i = 0; i < idw_mail_carried.DataObject.RowCount; i++)
            {
                ((DMailCarriedFormTest)(((TableLayoutPanel)idw_mail_carried.GetControlByName("tableLayoutPanel1")).Controls[i])).BindingSource.CurrencyManager.Refresh();
            }
            return 0;
        }

        public virtual int wf_get_outlet2(string acode, string aoutlet)
        {
            int lRegionId;
            string sOutlet;
            // called by rd_description_of_point
            idw_description.DataObject.SetValue(idw_description.GetRow(), "Question_down", 1);
            //  sOutlet = the current value for Route Description
            sOutlet = idw_description.DataObject.GetItem<FreqDescription>(idw_description.GetRow() - 1).RdDescriptionOfPoint;//, "rd_description_of_point");
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().longparm = il_frequency;
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = il_contract;
            //OpenWithParm(w_qs_route_termination, sOutlet);
            StaticMessage.StringParm = sOutlet;
            WQsRouteTermination w_qs_route_termination = new WQsRouteTermination();
            w_qs_route_termination.ShowDialog();
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                idw_description.DataObject.SetValue(idw_description.GetRow(), "rd_description_of_point", StaticVariables.gnv_app.of_get_parameters().stringparm);
                idw_description.DataObject.SetValue(idw_description.GetRow(), "cust_id", StaticVariables.gnv_app.of_get_parameters().longparm);
                idw_description.DataObject.AcceptText();
            }
            idw_description.DataObject.SetValue(idw_description.GetRow(), "Question_down", 0);
            return 0;
        }

        public virtual int wf_recalcrunning(int arow)
        {
            int lLoop;
            int lRowCount;
            System.Decimal? dTotal = 0;
            System.Decimal? dLeg;
            if (arow > 0)
            {
                dTotal = ((DFreqDescription)idw_description.DataObject).GetItem<FreqDescription>(arow - 1).RfRunningTotal;// "rf_running_total");
            }
            else
            {
                dTotal = 0;
            }
            //?w_main_mdi.SetMicroHelp("Updating Running Totals");
            lRowCount = idw_description.RowCount;
            if (arow < lRowCount)
            {
                for (lLoop = arow; lLoop < lRowCount; lLoop++)
                {
                    dLeg = ((DFreqDescription)idw_description.DataObject).GetItem<FreqDescription>(lLoop).RfDistanceOfLeg;// "rf_distance_of_leg");
                    if (dLeg == null)
                    {
                        dLeg = 0;
                    }
                    dTotal = dTotal + dLeg;
                    ((DFreqDescription)idw_description.DataObject).GetItem<FreqDescription>(lLoop).RfRunningTotal = dTotal;
                }
            }
            //?w_main_mdi.SetMicroHelp("");
            return 0;
        }

        public virtual bool wf_isterminal(int? ai_rfpt_id)
        {
            //  Returns TRUE if the row supplied as arg is a TERMINAL row.  
            int rfpt_id;
            string s_rfpt_desc = string.Empty;
            // SELECT route_freq_point_type.rfpt_description  INTO :s_rfpt_desc  FROM route_freq_point_type  WHERE route_freq_point_type.rfpt_id = :ai_rfpt_id   ;
            s_rfpt_desc = RDSDataService.GetRfptDescription(ai_rfpt_id);
            if (s_rfpt_desc == terminal_point_const)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool wf_isterminalpoint(int al_row)
        {
            //  Mike Vautier, 4Dec96
            //  Returns TRUE if the row supplied as arg is a TERMINAL row.  
            bool lb_return;
            int li_rfpt;
            string s_rfpt_desc = string.Empty;
            if (al_row < 1 || al_row > idw_description.DataObject.RowCount)
            {
                lb_return = false;
            }
            else
            {
                li_rfpt = Convert.ToInt32(idw_description.DataObject.GetItem<FreqDescription>(al_row).Test);//, "rfpt_id"));
                // SELECT route_freq_point_type.rfpt_description INTO :s_rfpt_desc FROM route_freq_point_type WHERE route_freq_point_type.rfpt_id = :li_rfpt;
                s_rfpt_desc = RDSDataService.GetRfptDescription(li_rfpt);
                lb_return = s_rfpt_desc == terminal_point_const;
            }
            return lb_return;
        }

        public virtual int of_get_contract_id()
        {
            return il_contract;
        }

        public virtual int uf_copy_annotation(string as_annotation)
        {
            //  tjb SR4602 25 Nov 2004
            //  Copies the annotation string to the datawindow
            //  Called from events:
            // 				mle_annotation.modified
            // 				tab_frequencies.selectionchanging
            // 				w_frequencies.closequery
            //  Returns:
            //     0	OK
            //     1	Annotation string too long
            // 
            int ll_length;
            int ll_row;
            int li_maxlen = 500;
            ll_length = as_annotation.Length;
            if (ll_length > li_maxlen)
            {
                MessageBox.Show("Maximum size of the annotation of " + li_maxlen.ToString() + " characters~r" + "has been exceeded.  Please reword it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }
            ll_row = idw_annotation.GetRow();
            idw_annotation.DataObject.SetValue(ll_row, "rf_annotation", as_annotation);
            return 0;
        }

        private delegate void constructorDelegate();

        public virtual void dw_extensions_constructor()
        {
            //?base.constructor();
            idw_extensions = dw_extensions;
            dw_extensions.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);

            BeginInvoke(new constructorDelegate(dw_extensions_invoke));
        }

        //added by jlwang 
        public virtual void dw_extensions_invoke()
        {
            dw_extensions.of_set_createpriv(false);
            dw_extensions.of_set_deletepriv(false);
        }

        public virtual void dw_frequency_description_ue_deletenext()
        {
            //  TJB SR4706
            //  If the 'Terminal' type of a route entry is changed, the next row
            //  must be deleted.  If the user triggers the change by changing focus 
            //  to a different row  ( eg by tabbing forward), GetRow+1 will not be 
            //  the correct row to delete.  itemchanged sets il_terminal_row to 
            //  the row that has been changed.  Otherwise il_terminal_row is 
            //  initialised to -1.
            if (il_terminal_row < 0)
            {
                dw_frequency_description.DataObject.DeleteItemAt(dw_frequency_description.GetRow() + 1);
            }
            else
            {
                dw_frequency_description.DataObject.DeleteItemAt(il_terminal_row + 1);
            }
        }

        public virtual void dw_frequency_description_constructor()
        {
            idw_description = dw_frequency_description;
            il_terminal_row = -(1);
        }

        public virtual void itemerror()
        {
            if (ib_error)
            {
                // 	This.AcceptText ( )
                ib_error = false;
                return;
            }
        }

        public virtual void dw_frequency_description_pfc_deleterow()
        {
            //?base.pfc_deleterow();
            //  PBY 10/06/2002
            //  Added for SR#4394
            //?if (ancestorreturnvalue == 1) {
            if (true)
            {
                if (dw_frequency_description.RowCount > 0)
                {
                    wf_recalcrunning(dw_frequency_description.GetRow());
                }
            }
            //return ancestorreturnvalue;
            return;
        }

        public virtual void pfc_predeleterow()
        {
            //?base.pfc_predeleterow();
            // if this.getrow ( )<>1 then
            // 	if wf_isterminalpoint ( this.getrow ( ))    then
            // 		MessageBox ( 'Route Description','You may not delete a record that is marked as a terminal point. See previous record.',StopSign!)
            // 		Return -1
            // 	elseif   wf_isterminalpoint ( this.getrow ( ) - 1) then
            // 		MessageBox ( 'Route Description','You may not delete a record that has a Refererence Point of "Terminal".  You must first update the reference point to another value.',StopSign!)
            // 		Return -1
            // 	end if
            // else
            // 	if  wf_isterminalpoint ( 1) then 
            // 		MessageBox ( 'Route Description','You may not delete a record that is marked as a terminal point. See previous record.',StopSign!)
            // 		Return -1
            // 	end if
            // end if
            // 
            //return 1;
            return;
        }

        public virtual int dw_frequency_description_pfc_preinsertrow()
        {
            int li_return;
            System.Decimal dTotal;
            int lrow;
            //  Mike Vautier 4Dec96.  Don't insert if this is between a Terminal point pair record.  
            if (dw_frequency_description.RowCount > 1)
            {
                if (wf_isterminalpoint(dw_frequency_description.GetRow() - 1))
                {
                    if (!(dw_frequency_description.GetRow() == dw_frequency_description.RowCount))
                    {
                        MessageBox.Show("Insert not allowed here", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                }
            }
            return 1;
        }

        public virtual void dw_frequency_description_pfc_insertrow()
        {
            int li_return;
            System.Decimal? dTotal;
            int? lrow = 0;
            //  Mike Vautier 4Dec96.  Don't insert if this is between a Terminal point pair record.  
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = dw_frequency_description.RowCount;
            if (TestExpr == 0)
            {
                dw_frequency_description.InsertItem<FreqDescription>(dw_frequency_description.GetRow());
                lrow = dw_frequency_description.GetRow();
                dw_frequency_description.DataObject.SetCurrent(lrow.Value);
                dw_frequency_description.SetColumn("rd_description_of_point");//.DataObject.GetControlByName("rd_description_of_point").Focus();
                lrow = dw_frequency_description.GetRow();
                if (dw_frequency_description.GetRow() == 0)
                {
                    dTotal = 0;
                }
                else
                {
                    dTotal = dw_frequency_description.DataObject.GetItem<FreqDescription>(dw_frequency_description.GetRow() - 1).RfRunningTotal;//, "rf_running_total");
                }
                dw_frequency_description.DataObject.SetValue(dw_frequency_description.GetRow(), "rf_running_total", dTotal);
            }
            else if (TestExpr == 1)
            {
                dw_frequency_description.InsertItem<FreqDescription>(0);
                dw_frequency_description.SetCurrent(0);
                lrow = dw_frequency_description.GetRow();
                dw_frequency_description.SetCurrent(lrow.Value);
                dw_frequency_description.SetColumn("rd_description_of_point");//.DataObject.GetControlByName("rd_description_of_point").Focus();
                lrow = dw_frequency_description.GetRow();
                if (dw_frequency_description.GetRow() == 0)
                {
                    dTotal = 0;
                }
                else
                {
                    dTotal = dw_frequency_description.DataObject.GetItem<FreqDescription>(dw_frequency_description.GetRow() - 1).RfRunningTotal;
                }
                dw_frequency_description.SetValue(dw_frequency_description.GetRow(), "rf_running_total", dTotal);
            }
            //!else if (dw_frequency_description.GetRow() != 1)
            else if (dw_frequency_description.GetRow() != 0)
            {
                if (!(wf_isterminalpoint(dw_frequency_description.GetRow() - 1)))
                {
                    if (dw_frequency_description.GetRow() == dw_frequency_description.RowCount)
                    {
                        dw_frequency_description.InsertItem<FreqDescription>(0);
                        lrow = dw_frequency_description.GetRow();
                    }
                    else
                    {
                        lrow = dw_frequency_description.InsertRow(dw_frequency_description.GetRow());
                    }
                    dw_frequency_description.SetCurrent(lrow.Value);
                    dw_frequency_description.SetColumn("rd_description_of_point");//.DataObject.GetControlByName("rd_description_of_point").Focus();
                    lrow = dw_frequency_description.GetRow();
                    if (dw_frequency_description.GetRow() == 0)
                    {
                        dTotal = 0;
                    }
                    else
                    {
                        dTotal = dw_frequency_description.DataObject.GetItem<FreqDescription>(dw_frequency_description.GetRow() - 1).RfRunningTotal;
                    }
                    dw_frequency_description.SetValue(dw_frequency_description.GetRow(), "rf_running_total", dTotal);
                }
                else if (dw_frequency_description.GetRow() == dw_frequency_description.RowCount)
                {
                    lrow = dw_frequency_description.InsertRow(0);
                }
                else
                {
                    // messagebox ( "","Insert not allowed here")
                    // RETURN -1
                }
            }
            else
            {
                dw_frequency_description.InsertItem<FreqDescription>(0);
                dw_frequency_description.SetCurrent(0);
                dw_frequency_description.SetColumn("rd_description_of_point");//.DataObject.GetControlByName("rd_description_of_point").Focus();
                lrow = 1;
                dTotal = dw_frequency_description.DataObject.GetItem<FreqDescription>(0).RfRunningTotal;//, "rf_running_total");
                dw_frequency_description.SetValue(dw_frequency_description.GetRow(), "rf_running_total", dTotal);
            }
            //return 1;
            return;
        }

        public virtual int dw_frequency_description_pfc_validation()
        {
            int ll_x;
            string ls_desc;
            for (ll_x = 0; ll_x < dw_frequency_description.RowCount; ll_x++)
            {
                ls_desc = dw_frequency_description.DataObject.GetItem<NZPostOffice.RDS.Entity.Ruraldw.FreqDescription>(ll_x).RdDescriptionOfPoint;//, "rd_description_of_point");
                if (ls_desc == null || ls_desc == "")
                {
                    if (!ib_closestatus)
                    {
                        MessageBox.Show("Route description incomplete.  \nYou must specify a Description of Stage.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dw_frequency_description.SetCurrent(ll_x);
                        dw_frequency_description.SetColumn("rd_description_of_point");
                    }
                    return FAILURE;
                }
            }
            return SUCCESS;
        }

        protected virtual int dw_frequency_description_pfc_preupdate()
        {
            base.pfc_preupdate();
            int ll_GetRow;
            int ll_Row;
            int ll_RowNumber;
            int? ll_null;
            ll_null = null;
            ll_GetRow = idw_description.GetRow();
            for (ll_Row = 0; ll_Row < dw_frequency_description.RowCount; ll_Row++)
            {
                if (dw_frequency_description.DataObject.GetItem<FreqDescription>(ll_Row).RDSequence == 0 || (dw_frequency_description.DataObject.GetItem<FreqDescription>(ll_Row).RDSequence == null))
                {
                    dw_frequency_description.SetValue(ll_Row, "sf_key", il_sf_key);
                    dw_frequency_description.SetValue(ll_Row, "contract_no", il_contract);
                    dw_frequency_description.SetValue(ll_Row, "rf_delivery_days", is_delivery_days);
                }
                if (dw_frequency_description.DataObject.GetItem<FreqDescription>(ll_Row).AdrId <= 0)
                {
                    dw_frequency_description.SetValue(ll_Row, "adr_id", ll_null);
                }
                dw_frequency_description.DataObject.GetItem<FreqDescription>(ll_Row).RDSequence = ll_Row;//.SetValue(ll_Row, "rd_sequence", ll_Row);
            }
            dw_frequency_description.DataObject.AcceptText();
            return 1;
        }

        public virtual void dw_mail_carried_constructor()
        {
            idw_mail_carried = dw_mail_carried;
        }

        public virtual void scrollvertical()
        {
            string sRow = string.Empty;
            int iRow = 0;
            //?sRow = dw_mail_carried.Describe("DataWindow.FirstRowOnPage");
            //if (IsNumber(sRow)) {
            if (true)
            {
                iRow = Convert.ToInt32(sRow);
                dw_mail_carried.SetCurrent(iRow);
            }
        }

        public virtual int dw_mail_carried_pfc_validation()
        {
            int lMaxSeq;
            int ll_Row;
            for (ll_Row = 0; ll_Row < dw_mail_carried.RowCount; ll_Row++)
            {
                if (dw_mail_carried.uf_not_entered(ll_Row, "mc_dispatch_carried", "dispatch carried"))
                {
                    dw_mail_carried.isErrorColumn = "mc_dispatch_carried";
                    return -(1);
                }
                //PP! added a function for this form only - just check for repititions in "dispatch carried" field through D_Window records
                //!else if (dw_mail_carried.uf_not_unique(ll_Row, "mc_dispatch_carried", "dispatch carried")) {
                else if (this.uf_not_unique())
                {
                    //! aded instead of calling from parent forms or classes
                    MessageBox.Show("The current dispatch carried already has been defined.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dw_mail_carried.isErrorColumn = "mc_dispatch_carried";
                    return -(1);
                }
                else if (dw_mail_carried.uf_not_entered(ll_Row, "mc_uplift_time", "uplift time"))
                {
                    dw_mail_carried.isErrorColumn = "mc_uplift_time";
                    return -(1);
                }
                else if (dw_mail_carried.uf_not_entered(ll_Row, "mc_up_outlet_name", "uplift outlet"))
                {
                    dw_mail_carried.isErrorColumn = "mc_up_outlet_name";
                    return -(1);
                }
                else if (dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).McUpOutlet == null)
                {
                    MessageBox.Show("The uplift outlet does not exist on the database.", "Frequency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_mail_carried.isErrorColumn = "mc_up_outlet_name";
                    return -(1);
                }
                else if (dw_mail_carried.uf_not_entered(ll_Row, "mc_set_down_time", "set down time"))
                {
                    dw_mail_carried.isErrorColumn = "mc_set_down_time";
                    return -(1);
                }
                else if (dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).McSetDownTime/*.TimeOfDay*/ <= dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).McUpliftTime/*.TimeOfDay*/ && !dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).NextDay/* == "N"*/)
                {
                    MessageBox.Show("The set down time must be greater then the uplift time.", "Frequency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_mail_carried.isErrorColumn = "mc_set_down_time";
                    return -(1);
                }
                else if (dw_mail_carried.uf_not_entered(ll_Row, "mc_dn_outlet_name", "set down outlet"))
                {
                    dw_mail_carried.isErrorColumn = "mc_dn_outlet_name";
                    return -(1);
                }
                else if (dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).McDnOutlet == null)
                {
                    MessageBox.Show("The set down outlet does not exist on the database.", "Frequency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_mail_carried.isErrorColumn = "mc_dn_outlet_name";
                    return -(1);
                }
                else if (dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).IsNew && dw_mail_carried.GetItem<MailCarriedForm>(ll_Row).IsDirty)
                {
                    lMaxSeq = Convert.ToInt32(dw_mail_carried.DataObject.GetValue(ll_Row, "mc_sequence_no"));
                    //?if (lMaxSeq == null)
                    //{
                    //    lMaxSeq = 0;
                    //}
                    lMaxSeq++;
                    dw_mail_carried.SetValue(ll_Row, "mc_sequence_no", lMaxSeq);
                }
            }
            return 1;
        }

        private bool uf_not_unique()
        {
            //! just searching for repition of dispatch_carried field
            for (int i = 0; i < dw_mail_carried.RowCount; i++)
            {
                MailCarriedForm searchedFor = dw_mail_carried.DataObject.GetItem<MailCarriedForm>(i);
                for (int j = i + 1; j < dw_mail_carried.RowCount; j++)
                {
                    MailCarriedForm recordToBeSearched = dw_mail_carried.DataObject.GetItem<MailCarriedForm>(j);
                    if (searchedFor.McDispatchCarried == recordToBeSearched.McDispatchCarried)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual int dw_mail_carried_pfc_preupdate()
        {
            base.pfc_preupdate();
            int ll_row;
            for (ll_row = 0; ll_row < dw_mail_carried.RowCount; ll_row++)
            {
                if ((dw_mail_carried.DataObject.GetValue(ll_row, "sf_key") == null))
                {
                    dw_mail_carried.SetValue(ll_row, "sf_key", il_sf_key);
                    dw_mail_carried.SetValue(ll_row, "contract_no", il_contract);
                    dw_mail_carried.SetValue(ll_row, "rf_delivery_days", is_delivery_days);
                }
            }
            // return ancestorreturnvalue;
            return 1;
        }

        public virtual void dw_annotation_constructor()
        {
            idw_annotation = dw_annotation;
            //dw_annotation.of_set_createpriv(false);
            //dw_annotation.of_set_deletepriv(false);
            BeginInvoke(new constructorDelegate(dw_annotation_invoke));
        }

        //added by jlwang
        public virtual void dw_annotation_invoke()
        {
            dw_annotation.of_set_createpriv(false);
            dw_annotation.of_set_deletepriv(false);
        }

        public virtual void dw_header_constructor()
        {
            idw_header = dw_header;
            dw_header.of_SetUpdateable(false);
        }

        #endregion

        #region Events

        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i_rfptItemNo = (dw_frequency_description.DataObject.Current as FreqDescription).Test;//, "rfpt_id");
        }

        public override void resize(object sender, EventArgs args)
        {
            // Ancestor overridden
        }

        public virtual void tab_frequencies_selectionchanged(object sender, EventArgs e)
        {
            int ll_return;
            int ll_row;
            MMainMenu mCurrent;
            //?mCurrent = base.Menu;//Parent.MenuId
            // Menu items not needed across all tabs
            // mCurrent.m_Edit.m_Edit_line1.enabled = False	
            // mCurrent.m_Edit.m_Edit_line1.visible = False	
            // mCurrent.m_Edit.m_resetrows.enabled = False
            // mCurrent.m_Edit.m_resetrows.visible = False
            // mCurrent.m_Edit.m_search.enabled = False
            // mCurrent.m_Edit.m_search.visible = False	
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = tab_frequencies.SelectedIndex;
            if (TestExpr == 0)
            {
                idw_extensions.URdsDw_GetFocus(null, null);//added by jlwang

                // ist_maintenance.dwCurrent = idw_extensions
            }
            else if (TestExpr == 1)
            {
                idw_description.URdsDw_GetFocus(null, null); //added by jlwang

                if (idw_description.RowCount == 0)
                {
                    ((DFreqDescription)idw_description.DataObject).Retrieve(il_contract, il_sf_key, is_delivery_days);
                    idw_description.Show();
                    if (idw_description.RowCount == 0)
                    {
                        idw_description.DataObject.InsertItem<FreqDescription>(0);
                    }
                }
                // ist_maintenance.dwCurrent = idw_description
            }
            else if (TestExpr == 2)
            {
                idw_mail_carried.URdsDw_GetFocus(null, null); //added by jlwang
                if (idw_mail_carried.RowCount == 0)
                {
                    ((DMailCarriedForm)idw_mail_carried.DataObject).Retrieve(il_contract, il_sf_key, is_delivery_days);
                    if (idw_mail_carried.RowCount == 0)
                    {
                        idw_mail_carried.DataObject.InsertItem<MailCarriedForm>(0);
                    }
                }
                // ist_maintenance.dwCurrent = idw_mail_carried
            }
            else if (TestExpr == 3)
            {
                idw_annotation.URdsDw_GetFocus(null, null); //added by jlwang
                if (idw_annotation.RowCount == 0)
                {
                    ((DFrequencyAnnotation)idw_annotation.DataObject).Retrieve(il_contract, il_sf_key, is_delivery_days);
                    //  TJB SR4602 23-Nov-2004
                    //  Replaced the annotation text edit field in the datawindow 
                    //  with a multi-line edit control, to allow wordwrapping.
                    // 
                    //  When the annotation is retrieved, copy the annotation text  ( if any) 
                    //  from the datawindow to the mle.
                    ll_row = idw_annotation.GetRow();
                    mle_annotation.Text = idw_annotation.DataObject.GetItem<FrequencyAnnotation>(ll_row).RfAnnotation;//, "rf_annotation");
                }
                // ist_maintenance.dwCurrent = idw_annotation
            }
        }

        public virtual void tab_frequencies_selectionchanging(object sender, EventArgs e)
        {
            //  TJB SR4602 23-Nov-2004
            //  Replaced the annotation text edit field in the datawindow 
            //  with a multi-line edit control, to allow wordwrapping.
            // 
            //  see code dealing with annotation tab below
            int ll_Ret;
            int ll_Row;
            string ls_dwAnnotation;
            string ls_mleAnnotation;
            DialogResult ret;
            int oldindex = 0;
            //?idw_description.DataObject.AcceptText();
            if (idw_description.DataObject.DeletedCount > 0 || StaticFunctions.IsDirty(idw_description.DataObject)/*.ModifiedCount() > 0*/)
            {
                ret = MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_description.DataObject.GetRow();
                if (ret == DialogResult.Yes)
                {
                    ll_Ret = idw_description.Save();// ll_Ret = base.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_description.DataObject.Reset();
                }
            }
            //?idw_mail_carried.DataObject.AcceptText();
            if (idw_mail_carried.DataObject.DeletedCount > 0 || StaticFunctions.IsDirty(idw_mail_carried.DataObject)/*.ModifiedCount() > 0*/)
            {
                ret = MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_mail_carried.GetRow();
                if (ret == DialogResult.Yes)
                {
                    ll_Ret = idw_mail_carried.Save();// ll_Ret = base.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_mail_carried.DataObject.Reset();
                }
            }
            //  TJB SR4602 23-Nov-2004
            //  If switching tabs, the modified event on the MLE isn't fired,
            //  so we check to see if we're switching away from the annotation 
            //  tab, and if so, check to see if the string in the MLE is the 
            //  same as that in the datawindow.  If not, update the datawindow
            //  then carry on.
            //  See also 
            // 		mle_annotation.modified
            // 		w_frequencies2001.closequery
            // 		w_frequencies2001.closequery
            // 
            // If idw_annotation.DeletedCount ( )  > 0  or idw_annotation.ModifiedCount ( ) > 0  then
            if (oldindex == 4)
            {
                ll_Row = idw_annotation.GetRow();
                ls_mleAnnotation = mle_annotation.Text;
                ls_dwAnnotation = idw_annotation.DataObject.GetItem<FrequencyAnnotation>(ll_Row).RfAnnotation;//, "rf_annotation");
                if (ls_mleAnnotation == null)
                {
                    ls_mleAnnotation = "";
                }
                if (ls_dwAnnotation == null)
                {
                    ls_dwAnnotation = "";
                }
                if (!(ls_dwAnnotation == ls_mleAnnotation))
                {
                    if (uf_copy_annotation(ls_mleAnnotation) == 1)
                    {
                        return;
                    }
                }
                if (idw_annotation.DataObject.DeletedCount > 0 || StaticFunctions.IsDirty(idw_annotation.DataObject)/*.ModifiedCount() > 0*/)
                {
                    //  TJB SR4602 23-Nov-2004: Added cancel option
                    ret = MessageBox.Show("Update", "Do you want to update database?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        //  TJB SR4602 23-Nov-2004
                        //  Sometimes the print flag is null when it should be either 'Y' or 'N'
                        if (idw_annotation.DataObject.GetValue(ll_Row, "rf_annotation_print") == null)
                        {
                            idw_annotation.DataObject.SetValue(ll_Row, "rf_annotation_print", 'N');
                        }
                        ll_Ret = idw_annotation.Save();// ll_Ret = base.pfc_save();
                        if (ll_Ret < 0)
                        {
                            return;
                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        idw_annotation.DataObject.Reset();
                        //  TJB SR4602 23-Nov-2004
                        //  the user didn't want to save it; put the old annotation text back.
                        mle_annotation.Text = ls_dwAnnotation;
                        //  TJB SR4602 23-Nov-2004: Added cancel option
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public virtual void dw_extensions_doubleclicked(object sender, EventArgs e)
        {
            dw_extensions.URdsDw_DoubleClick(sender, e);
            if (dw_extensions.DataObject.GetRow() >= 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                //open(w_freq_distances);
                StaticMessage.PowerObjectParm = dw_extensions;//ttjin
                WFreqDistances w_freq_distances = new WFreqDistances();
                w_freq_distances.Show();
            }
        }

        public virtual void dw_extensions_rowfocuschanged(object sender, EventArgs e)
        {
            //?base.rowfocuschanged();
            dw_extensions.SelectRow(0, false);
            dw_extensions.SelectRow(dw_extensions.GetRow() + 1, true);
        }

        public virtual void dw_extensions_getfocus(object sender, EventArgs e)
        {
            //?base.getfocus();
            // if g_security.u_usergroup = 'National Operations Manager' then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // elseif g_security.u_usergroup = 'Regional Contracts Managers' then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // elseif g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" then
            // 	wf_set_security ( 'insert','delete','update')
            // elseif g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GARDINERE" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // elseif g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "SHOTTERI" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // elseif g_security.u_usergroup = 'HO Staff' and g_security.userid = "MCKAYT" or g_security.userid = "HOCKLYJ" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // else
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // end if			
            // 
        }

        public virtual void dw_frequency_description_clicked(object sender, EventArgs e)
        {
            string sObjectAtPointer = string.Empty;
            string ls_address = string.Empty;
            int ll_adr_id = 0;
            NRdsMsg lnv_msg;
            NCriteria lnv_Criteria;
            WAddressSearchSelect lw_search = new WAddressSearchSelect();
            sObjectAtPointer = dw_frequency_description.DataObject.GetColumnName();// dw_frequency_description.DataObject.GetObjectAtPointer();
            // /////OLD//////////////////////////
            // if left ( sObjectAtPointer, 10) = "dos_button" and KeyDown ( KeyShift!) then
            // 	scrolltorow ( row)
            // 	wf_Get_Outlet2 ( "blah", "dos")
            // end if
            // 
            // //////////////////////////////////
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_object, ds_contract
                ds_object = sObjectAtPointer
                if isnull ( sObjectAtPointer) then	ds_object = 'NULL'
                ds_contract = il_contract.ToString()
                if isnull ( il_contract) then ds_contract = 'NULL'
                MessageBox.Show (  & 'sObjectAtPointer = '+ds_object +'\n'  & +'il_contract     = '+ds_contract ,  'w_frequencies2001.dw_frequency_description.clicked' )
                // --------------------------------------------------------------------  */
            //if (sObjectAtPointer.Substring(0, 10) == "dos_button")
            //{
            dw_frequency_description.SetCurrent(dw_frequency_description.GetRow());
            //  TJB  Release 6.8.11 fixup
            //  Need to pass the flag that says whether this is a
            //  RD contract or not.
            if (!(il_contract == null) && il_contract < 6000 && il_contract >= 5000)
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 1;
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            }
            //OpenWithParm(lw_search, iw_this);
            StaticMessage.PowerObjectParm = iw_this;
            lw_search.ShowDialog();

            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            if ((lnv_msg == null) || !(lnv_msg != null))
            {
                //  User cancelled out of the window
                return;
            }
            lnv_Criteria = lnv_msg.of_getcriteria();
            ll_adr_id = Convert.ToInt32(lnv_Criteria.of_getcriteria("adr_id"));
            ls_address = lnv_Criteria.of_getcriteria("address").ToString();
            if (ll_adr_id > 0)
            {
                dw_frequency_description.DataObject.SetValue(dw_frequency_description.DataObject.GetRow(), "adr_id", ll_adr_id);
                dw_frequency_description.DataObject.SetValue(dw_frequency_description.DataObject.GetRow(), "rd_description_of_point", ls_address);
            }
            dw_frequency_description.DataObject.AcceptText();
            // }
        }

        int? i_rfptItemNo = null;
        public virtual void dw_frequency_description_itemchanged(object sender, EventArgs e)
        {
            // base.itemchanged();
            dw_frequency_description.URdsDw_Itemchanged(sender, e);
            System.Decimal dTotal;
            System.Decimal dLeg;
            bool was_terminal = false;
            bool is_terminal = false;
            int lRow;
            int lLoop;
            int lRowCount;
            string sPoint = string.Empty;
            int l_thisRow;
            //!int? i_rfptItemNo;
            il_terminal_row = -(1);
            string columnName = ((Metex.Windows.DataEntityGrid)dw_frequency_description.GetControlByName("grid")).CurrentColumnName;
            if (columnName == "rf_distance_of_leg")
            {
                //  PBY 10/06/2002
                //  Added for SR#4394
                dw_frequency_description.DataObject.AcceptText();
                wf_recalcrunning(dw_frequency_description.GetRow());
                dw_frequency_description.Refresh();

                //  PBY 10/06/2002 SR#4394
                //  Commented out the following block of code
                // 
                //  with the two lines above.
                // 	w_main_mdi.setmicrohelp ( "Updating Running Totals")
                //  lRow = this.GetRow ( )
                // 
                // 	If lRow > 1 Then
                // 		dTotal = This.GetItemSystem.Conver.ToDouble (  lRow - 1, 'rf_running_total' )
                // 	Else
                // 		dTotal = 0
                // 	End If
                // 
                // 	dLeg = Dec ( this.gettext ( ))
                // 
                // 	If isnull ( dLeg) Then dLeg = 0
                // 	dTotal = dTotal + dLeg
                // 
                // 	This.setitem ( this.getrow ( ), "rf_running_total", dTotal)
                // 	wf_recalcrunning ( lRow)
                // 	w_main_mdi.setmicrohelp ( "")
            }
            //  Mike Vautier, 4 Dec 96.  Route termination points.  
            if (columnName == "rfpt_id")
            {
                // 	sPoint = String ( this.getitemnumber ( this.getrow ( ),"rfpt_id"))
                // 	was_terminal = wf_isterminal ( this.getitemnumber ( this.getrow ( ),"rfpt_id"))
                // 	is_terminal = wf_isterminal ( integer ( this.gettext ( )))
                l_thisRow = dw_frequency_description.GetRow();

                //! is assigned in CellEnter of dw_frequency_description
                //!                i_rfptItemNo = dw_frequency_description.DataObject.GetItem<FreqDescription>(l_thisRow).Test;//, "rfpt_id");

                if (i_rfptItemNo.HasValue)
                {
                    sPoint = i_rfptItemNo.ToString();
                    was_terminal = wf_isterminal(i_rfptItemNo);
                }

                //!is_terminal = wf_isterminal(Convert.ToInt32(dw_frequency_description.DataObject.GetValue(dw_frequency_description.GetRow(),
                //!    dw_frequency_description.GetColumnName())));
                is_terminal = wf_isterminal(Convert.ToInt32(dw_frequency_description.DataObject.GetItem<FreqDescription>(l_thisRow).Test));


                //  TJB 16Mar04 - ib_TerminalNotChanged set to True if the user selects a
                //       changed value for a 'Terminal' point, then says 'No' to the delete
                //       messagebox.  When the user moves to a new column/row, itemchanged 
                //       is called with is_terminal 'true', resembling a situation where 
                //       the user changed the column value to 'Terminal'.  
                //       ib_TerminalNotChanged distinguishes the two situations and prevents
                //       the insertion of an extra row.
                if (ib_terminalNotChanged)
                {
                    ib_terminalNotChanged = false;
                }
                else if (is_terminal)
                {
                    dw_frequency_description.InsertRow(dw_frequency_description.GetRow() + 1);
                    dw_frequency_description.DataObject.SetValue(dw_frequency_description.GetRow() + 1, "show_question", 1);
                }
                else if (was_terminal && !is_terminal)
                {
                    //  Delete the following terminal point record
                    if (MessageBox.Show("This will delete the following record - Continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        il_terminal_row = dw_frequency_description.GetRow();
                        ib_error = false;
                        dw_frequency_description_ue_deletenext(); //dw_frequency_description.PostEvent("ue_deletenext");
                        return;
                    }
                    else
                    {
                        dw_frequency_description.SetValue(dw_frequency_description.GetRow(), dw_frequency_description.GetColumnName(), sPoint);
                        //dw_frequency_description.SetItem(dw_frequency_description.GetRow(), "rfpt_id", sPoint);
                        ib_error = true;
                        ib_terminalNotChanged = true;
                        return;
                    }
                }
            }
        }

        public virtual void dw_frequency_description_retrieveend(object sender, EventArgs e)
        {
            int ll_rowCount;
            int ll_count;
            ll_rowCount = dw_frequency_description.RowCount;
            for (ll_count = 1; ll_count < ll_rowCount; ll_count++) //for ll_count = 2 to ll_RowCount step 1
            {
                if (dw_frequency_description.DataObject.GetItem<FreqDescription>(ll_count - 1).PointType == "Terminal")
                {
                    dw_frequency_description.DataObject.SetValue(ll_count, "show_question", 1);
                }
            }
        }

        public virtual void dw_frequency_description_losefocus(object sender, EventArgs e)
        {
            dw_frequency_description.DataObject.AcceptText();
        }

        public virtual void dw_mail_carried_clicked(object sender, EventArgs e)
        {
            string sObjectAtPointer = string.Empty;
            string sOutlet;
            sObjectAtPointer = ((Button)sender).Name;//sObjectAtPointer = dw_mail_carried.DataObject.ActiveControl.Name;// dw_mail_carried.GetObjectAtPointer();
            if (sObjectAtPointer.Length >= 13 && sObjectAtPointer.Substring(0, 13) == "up_pcklst_bmp")
            {
                wf_get_outlet("up");
                //idw_mail_carried.GetControlByName("mc_up_outlet_name").Text = idw_mail_carried.GetValue(0, "mc_up_outlet_name").ToString();//add by mkwang
            }
            else if (sObjectAtPointer.Length >= 13 && sObjectAtPointer.Substring(0, 13) == "dn_pcklst_bmp")
            {
                wf_get_outlet("dn");
                //idw_mail_carried.GetControlByName("mc_dn_outlet_name").Text = idw_mail_carried.GetValue(0, "mc_dn_outlet_name").ToString();//add by mkwang
            }
        }

        public virtual void dw_mail_carried_itemchanged(object sender, EventArgs e)
        {
            // base.itemchanged();
            dw_mail_carried.URdsDw_Itemchanged(sender, e);
            string sOutlet;
            int? lOutletCode = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if (dw_mail_carried.GetColumnName().Length > 9 && dw_mail_carried.GetColumnName().Substring(3) == "_picklist")
            {
                if (dw_mail_carried.GetColumnName().Substring(3) == "_picklist")
                {
                    if (dw_mail_carried.GetColumnName().Substring(0, 2) == "up")
                    {
                        wf_get_outlet("up");
                    }
                    else
                    {
                        wf_get_outlet("dn");
                    }
                }
                else if (dw_mail_carried.GetColumnName() == "mc_up_outlet_name")
                {
                    sOutlet = dw_mail_carried.DataObject.GetItem<MailCarriedForm>(dw_mail_carried.GetRow()).McUpOutletName;//, "mc_up_outlet_name");
                    if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                    {
                        //select outlet_id into :lOutletCode from outlet where o_name = :sOutlet;
                        lOutletCode = RDSDataService.GetOutletOutletId(sOutlet, ref SQLCode, ref SQLErrText);
                        if (SQLCode != 0)
                        {
                            lOutletCode = null;
                        }
                    }
                    else
                    {
                        lOutletCode = null;
                    }
                    dw_mail_carried.DataObject.SetValue(dw_mail_carried.GetRow(), "mc_up_outlet", lOutletCode);
                }
                else if (dw_mail_carried.GetColumnName() == "mc_dn_outlet_name")
                {
                    sOutlet = dw_mail_carried.DataObject.GetItem<MailCarriedForm>(dw_mail_carried.GetRow()).McDnOutletName;//, "mc_dn_outlet_name"); 
                    if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                    {
                        // select outlet_id into :lOutletCode from outlet where o_name = :sOutlet;
                        lOutletCode = RDSDataService.GetOutletOutletId(sOutlet, ref SQLCode, ref SQLErrText);
                        if (SQLCode != 0)
                        {
                            lOutletCode = null;
                        }
                    }
                    else
                    {
                        lOutletCode = null;
                    }
                    dw_mail_carried.DataObject.SetValue(dw_mail_carried.GetRow(), "mc_dn_outlet", lOutletCode);
                }
            }
        }

        public virtual void dw_mail_carried_itemfocuschanged(object sender, EventArgs e)
        {
            if (dw_mail_carried.GetColumnName() == "up_picklist")
            {
                //?dw_mail_carried.Modify("up_pcklst_rect.pen.color=0");
            }
            else
            {
                //?dw_mail_carried.Modify("up_pcklst_rect.pen.color=8421504");
            }
            if (dw_mail_carried.GetColumnName() == "dn_picklist")
            {
                //?dw_mail_carried.Modify("dn_pcklst_rect.pen.color=0");
            }
            else
            {
                //?dw_mail_carried.Modify("dn_pcklst_rect.pen.color=8421504");
            }
        }

        public virtual void dw_mail_carried_losefocus(object sender, EventArgs e)
        {
            dw_mail_carried.DataObject.AcceptText();
        }

        public virtual void mle_annotation_modified(object sender, EventArgs e)
        {
            //  TJB SR4602  23-Nov-2004
            //  Replaced the annotation text edit field in the datawindow 
            //  with a multi-line edit control, to allow wordwrapping.
            // 
            //  If the MLE is modified, copy the new text into the datawindow.
            //  The database field is 500 characters and is unlikely to 
            //  change, so the hard-coded 500 should be OK.
            // 
            //  See also
            // 		tab_frequencies.selectionchanging
            // 		tab_frequencies.selectionchanged
            // 		w_frequencies.closequery
            if (uf_copy_annotation(mle_annotation.Text) == 1)
            {
                mle_annotation.Focus();
            }
            return;
        }

        public virtual void dw_annotation_losefocus(object sender, EventArgs e)
        {
            dw_annotation.DataObject.AcceptText();
        }

        protected virtual void cb_seq_clicked(object sender, EventArgs e)
        {
            NParameters lnv_Parameters;
            Cursor.Current = Cursors.WaitCursor;
            lnv_Parameters = new NParameters();
            lnv_Parameters.longparm = il_contract;
            lnv_Parameters.integerparm = il_sf_key;
            lnv_Parameters.stringparm = is_delivery_days;
            lnv_Parameters.anyparm = dw_header;
            //OpenSheetWithParm(w_customer_sequencer, lnv_Parameters, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_Parameters;
            WCustomerSequencer w_customer_sequencer = OpenSheet<WCustomerSequencer>(StaticVariables.MainMDI);
        }
        #endregion
    }
}