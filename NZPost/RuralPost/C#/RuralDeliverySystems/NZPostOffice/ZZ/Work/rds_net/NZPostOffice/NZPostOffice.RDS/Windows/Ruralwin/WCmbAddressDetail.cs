using System;
using System.Windows.Forms;
using System.Collections.Generic;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruralwin;
using System.Text.RegularExpressions;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WCmbAddressDetail : WAncestorWindow
    {
        #region Define

        public int? il_contract;

        public int? il_cmb_id;

        public int il_rd_no;

        public string is_rd_no = String.Empty;

        public bool ib_insert;

        public bool ib_validated_ok;

        public bool ib_changed;

        public Metex.Windows.DataUserControl idw_town;

        public Metex.Windows.DataUserControl idw_rdno;

        public URdsDw idw_cmb;

        private System.ComponentModel.IContainer components = null;

        public Button cb_save;

        public Button cb_cancel;

        public URdsDw dw_cmb_detail;

        public Button cb_add;

        #endregion

        public WCmbAddressDetail()
        {
            this.InitializeComponent();
            //idw_cmb = dw_cmb_detail;

            //jlwang:moved from IC
            dw_cmb_detail.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_cmb_detail_constructor);
            dw_cmb_detail.PfcValidation += new UserEventDelegate1(dw_cmb_detail_pfc_validation);

            this.FormClosing -= new FormClosingEventHandler(FormBase_FormClosing);
            this.FormClosed -= new FormClosedEventHandler(FormBase_FormClosed);
            //jlwang:end
        }

        #region FormDesign
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_save = new Button();
            this.cb_cancel = new Button();
            this.dw_cmb_detail = new URdsDw();
            this.dw_cmb_detail.DataObject = new DCmbAddressDetail();
            this.cb_add = new Button();
            Controls.Add(cb_save);
            Controls.Add(cb_cancel);
            Controls.Add(dw_cmb_detail);
            Controls.Add(cb_add);
            this.Location = new System.Drawing.Point(46, 55);
            this.Size = new System.Drawing.Size(433, 309);
            // 
            // st_label
            // 

            st_label.Text = "w_cmb_address_details";
            st_label.Width = 155;
            st_label.Location = new System.Drawing.Point(10, 250);
            // 
            // cb_save
            // 
            cb_save.Text = "Save";
            cb_save.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_save.TabIndex = 1;
            cb_save.Location = new System.Drawing.Point(256, 232);
            cb_save.Size = new System.Drawing.Size(75, 23);
            cb_save.Click += new EventHandler(cb_save_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(344, 232);
            cb_cancel.Size = new System.Drawing.Size(75, 23);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // dw_cmb_detail
            // 
            dw_cmb_detail.VerticalScroll.Visible = false;
            dw_cmb_detail.TabIndex = 0;
            dw_cmb_detail.Location = new System.Drawing.Point(8, 8);
            dw_cmb_detail.Size = new System.Drawing.Size(408, 216);
            dw_cmb_detail.ItemChanged += new EventHandler(dw_cmb_detail_itemchanged);

            //dw_cmb_detail.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_cmb_detail_constructor);
            //dw_cmb_detail.PfcValidation += new UserEventDelegate1(dw_cmb_detail_pfc_validation);
            // 
            // cb_add
            // 
            cb_add.Text = "Add";
            cb_add.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_add.TabIndex = 4;
            cb_add.Location = new System.Drawing.Point(168, 232);
            cb_add.Size = new System.Drawing.Size(75, 23);
            cb_add.Click += new EventHandler(cb_add_clicked);
            this.Name = "w_cmb_address_details";
            //this.FormClosing -= new FormClosingEventHandler(FormBase_FormClosing);
            //this.FormClosed -= new FormClosedEventHandler(FormBase_FormClosed);
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
            int? ll_tcid;
            int? ll_pcid;
            int ll_mailtown_id;
            string ls_con_title;
            string ls_mailtown;
            string ls_rdno;
            string ls_postcode = "";
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;
            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_cmb_id = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("cmb_id"));
            ll_tcid = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("tc_id"));
            ll_pcid = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("post_code_id"));
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            ls_con_title = lvn_Criteria.of_getcriteria("contract_title") as string;
            ls_rdno = lvn_Criteria.of_getcriteria("adr_rd_no") as string;
            Text = "Contract: " + il_contract.ToString() + " - " + ls_con_title;
            if ((il_cmb_id == null) || il_cmb_id == 0)
            {
                idw_cmb.DataObject.AddItem<CmbAddressDetail>(new CmbAddressDetail());
                idw_cmb.GetItem<CmbAddressDetail>(0).ContractNo = il_contract;
                idw_cmb.GetItem<CmbAddressDetail>(0).TcId = ll_tcid;
                idw_cmb.GetItem<CmbAddressDetail>(0).PostCodeId = il_contract;
                idw_cmb.GetItem<CmbAddressDetail>(0).RdNo = ls_rdno;
                ib_insert = true;
            }
            else
            {
                idw_cmb.Retrieve(new object[] { il_cmb_id });
                idw_cmb.GetControlByName("cmb_box_no").BackColor = System.Drawing.Color.FromArgb(255, 255, 255); ;
                //?idw_cmb.Modify("cmb_box_no.Border=\'0\'");
                idw_cmb.GetControlByName("cmb_box_no").Enabled = false;
                il_contract = idw_cmb.GetItem<CmbAddressDetail>(0).ContractNo;
                ll_tcid = idw_cmb.GetItem<CmbAddressDetail>(0).TcId;
                ll_pcid = idw_cmb.GetItem<CmbAddressDetail>(0).PostCodeId;
                ls_rdno = idw_cmb.GetItem<CmbAddressDetail>(0).RdNo;
                ib_insert = false;
            }
            idw_town = idw_cmb.GetChild("tc_id");
            idw_rdno = idw_cmb.GetChild("rd_no");
            if (wf_filter_town(il_contract, ll_tcid) == SUCCESS)
            {
                try
                {
                    ll_tcid = idw_town.GetItem<DddwContractMailtown>(idw_town.GetRow()).TcId;
                }
                catch
                { }
                if (wf_filter_rdno(il_contract, ll_tcid, ls_rdno) == SUCCESS)
                {
                    try
                    {
                        ll_pcid = idw_rdno.GetItem<DddwContractRd>(idw_rdno.GetRow()).PostCodeId;
                        ls_postcode = idw_rdno.GetItem<DddwContractRd>(idw_rdno.GetRow()).PostCode;
                    }
                    catch
                    { }
                    idw_cmb.GetItem<CmbAddressDetail>(0).PostCode = ls_postcode;
                    idw_cmb.GetItem<CmbAddressDetail>(0).PostCodeId = ll_pcid; ;
                    idw_cmb.DataObject.BindingSource.CurrencyManager.Refresh();
                }
                else
                {
                    MessageBox.Show("Failed to find the RD number associated with the mailtown.", "Error?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The Towncity ID in the CMB record doesn\'t match\r" + " any towns associated with the contract.", "Error?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ib_changed = false;
            idw_cmb.Focus();
        }

        public override void close()
        {
            base.close();
            int ll_sheetcount;
            int ll_row;
            FormBase lw_frame;//WFrame lw_frame;
            Dictionary<int, WContract2001> lw_opensheets = new Dictionary<int, WContract2001>();
            lw_frame = StaticVariables.gnv_app.of_getframe();
            //?if (IsValid(lw_frame.inv_sheetmanager) == false) {
            //    lw_frame.inv_sheetmanager = new n_cst_winsrv_sheetmanager();
            //}
            //?ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_contract2001");
            //if (ll_sheetcount > 0) {
            //    for (ll_row = 1; ll_row <= ll_sheetcount; ll_row++) {
            //        lw_opensheets[ll_row].idw_cmb.Retrieve(new object[]{il_contract});
            //        lw_opensheets[ll_row].idw_cmb.Focus( );
            //    }
            //}
        }

        public override int pfc_preclose()
        {
            base.pfc_preclose();
            if (!ib_changed)
            {
                idw_cmb.Reset();
            }
            return SUCCESS;
        }

        #region Methods

        public virtual int dw_cmb_detail_pfc_validation()
        {
            if (wf_validate(0) == SUCCESS)
            {
                return 1;
            }//return wf_validate(1);
            return -1;
        }

        public virtual int wf_validate(int al_row)
        {
            int? ll_cmb_id;
            int? ll_cmb_id2;
            int? ll_pcid;
            int? ll_contract;
            string ls_box_no;
            string ls_customer;
            string ls_initials;
            string ls_temp;
            if (ib_insert)
            {
                ls_temp = "Insert";
            }
            else
            {
                ls_temp = "Update";
            }
            ls_box_no = idw_cmb.GetItem<CmbAddressDetail>(al_row).CmbBoxNo.ToUpper();
            ls_customer = idw_cmb.GetItem<CmbAddressDetail>(0).CmbCustSurname;
            ls_initials = idw_cmb.GetItem<CmbAddressDetail>(0).CmbCustInitials;
            if ((ls_box_no == null) || ls_box_no == "")
            {
                MessageBox.Show(ls_temp + " Validation FAILED - you must specify a box number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ib_validated_ok = false;
                return FAILURE;
            }
            if (ls_customer == "")
            {
                ls_customer = null;
                idw_cmb.GetItem<CmbAddressDetail>(0).CmbCustSurname = ls_customer;
            }
            if (ls_initials == "")
            {
                ls_initials = null;
                idw_cmb.GetItem<CmbAddressDetail>(0).CmbCustInitials = ls_initials;
            }
            idw_cmb.GetItem<CmbAddressDetail>(al_row).CmbBoxNo = ls_box_no;
            ll_cmb_id = idw_cmb.GetItem<CmbAddressDetail>(al_row).CmbId;
            ll_contract = idw_cmb.GetItem<CmbAddressDetail>(al_row).ContractNo;
            ll_pcid = idw_cmb.GetItem<CmbAddressDetail>(al_row).PostCodeId;
            if (ib_insert)
            {
                /*select first cmb_id into :ll_cmb_id2 from cmb_address where contract_no  = :il_contract and post_code_id = :ll_pcid and cmb_box_no   = :ls_box_no using SQLCA;*/
                ll_cmb_id2 = RDSDataService.GetCmbAddressCmbIdFirst(il_contract, ll_pcid, ls_box_no);
            }
            else
            {
                /*select first cmb_id into :ll_cmb_id2 from cmb_address where contract_no  = :il_contract and post_code_id = :ll_pcid and cmb_box_no   = :ls_box_no and not cmb_id   = :ll_cmb_id using SQLCA;*/
                ll_cmb_id2 = RDSDataService.GetCmbAddressCmbIdFirst1(il_contract, ll_pcid, ls_box_no, ll_cmb_id);
            }
            //?commit;
            if (!((ll_cmb_id2 == null)) && ll_cmb_id2 > 0)
            {
                MessageBox.Show(ls_temp + " Validation FAILED - box number exists" + "\r\r" + "cmb_id = " + ll_cmb_id2.ToString() + '~', "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ib_validated_ok = false;
                return FAILURE;
            }
            if (ib_insert)
            {
                if (!((ll_cmb_id == null) || ll_cmb_id == 0))
                {
                    MessageBox.Show("Inserting new record: cmb_id found when it hasn\'t been assigned yet?\r" + "- Using the current one", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if ((ll_cmb_id == null) || ll_cmb_id == 0)
            {
                MessageBox.Show("Updating record: cmb_id not found?\r" + "- An ID will be assigned", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //  If the record doesn't have an ID, give it one
            if ((ll_cmb_id == null) || ll_cmb_id == 0)
            {
                ll_cmb_id = of_get_nextsequence("cmb_id");//StaticVariables.gnv_app.of_get_nextsequence("cmb_id");
                idw_cmb.GetItem<CmbAddressDetail>(al_row).CmbId = ll_cmb_id;
                ib_changed = true;
            }
            if (ib_insert)
            {
                idw_cmb.GetItem<CmbAddressDetail>(0).CmbDateAdded = DateTime.Today;
            }
            else
            {
                idw_cmb.GetItem<CmbAddressDetail>(0).CmbLastAmendedDate = DateTime.Today;
            }
            idw_cmb.GetItem<CmbAddressDetail>(0).CmbLastAmendedUser = StaticVariables.gnv_app.of_getuserid();
            ib_validated_ok = true;
            return SUCCESS;
        }

        public virtual int? wf_contract_rdno(int al_contract, int al_pcid)
        {
            int? ll_rd_no;
            /*select first adr_rd_no into :ll_rd_no from address where contract_no  = :al_contract and post_code_id = :al_pcid using SQLCA;*/
            ll_rd_no = RDSDataService.GetAddressAdrRdNoFirst(al_contract, al_pcid);
            if ((ll_rd_no == null) || ll_rd_no == 0)
            {
                ll_rd_no = -(1);
            }
            return ll_rd_no;
        }

        public virtual int wf_filter_town(int? al_contract, int? al_tcid)
        {
            int ll_row;
            int ll_rows;
            int? ll_tcid;
            int li_rc;
            string ls_filter;
            ls_filter = "contract_no = " + al_contract.ToString() + "";
            //idw_town.FilterString = ls_filter;//idw_town.SetFilter(ls_filter);
            //idw_town.Filter<DddwContractMailtown>();
            idw_town.FilterString = al_contract.ToString();//FilterOnce user the  idw_town_filter function
            idw_town.FilterOnce<DddwContractMailtown>(idw_town_filter);
            ll_rows = idw_town.RowCount;
            ll_row = 0;
            if ((al_tcid == null) || al_tcid < 1)
            {
                li_rc = SUCCESS;
            }
            else
            {
                li_rc = FAILURE;
                for (ll_row = 0; ll_row < ll_rows; ll_row++)
                {
                    ll_tcid = idw_town.GetItem<DddwContractMailtown>(ll_row).TcId;
                    if (ll_tcid == al_tcid)
                    {
                        li_rc = SUCCESS;
                        break;
                    }
                }
            }
            idw_town.SetCurrent(ll_row);
            return li_rc;
        }

        private bool idw_town_filter<T>(T t) where T : DddwContractMailtown
        {
            if (t.ContractNo == null || t.ContractNo.GetValueOrDefault() != System.Convert.ToInt32(idw_town.FilterString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public virtual string wf_get_town(int al_tcid)
        {
            string ls_town;
            /*select tc_name into :ls_town from towncity where tc_id = :al_tcid;*/
            ls_town = RDSDataService.GetTowncityTcName(al_tcid);
            return ls_town;
        }

        public virtual string wf_get_postcode(int al_pcid)
        {
            string ls_postcode;
            /*select post_code into :ls_postcode from post_code where post_code_id = :al_pcid;*/
            ls_postcode = RDSDataService.GetPostCodePostCode(al_pcid);
            return ls_postcode;
        }

        public virtual int wf_filter_rdno(int? al_contract, int? al_tcid, string as_rdno)
        {
            int ll_row;
            int ll_rows;
            int li_rc;
            int li_rc1;
            int li_rc2;
            string ls_filter;
            string ls_rdno;
            ls_filter = "contract_no = " + al_contract.ToString() + " and  tc_id = " + al_tcid.ToString();
            //idw_rdno.FilterString = ls_filter;//li_rc1 = idw_rdno.SetFilter(ls_filter);
            idw_rdno.FilterString = al_contract.ToString() + ":" + al_tcid.ToString();
            //idw_rdno.Filter<DddwContractRd>();//li_rc2 = idw_rdno.Filter();
            idw_rdno.FilterOnce<DddwContractRd>(idw_rdno_filter);
            ll_rows = idw_rdno.RowCount;
            li_rc = FAILURE;
            ll_row = 1;
            if ((as_rdno == null) || as_rdno == "")
            {
                li_rc = SUCCESS;
            }
            else
            {
                for (ll_row = 0; ll_row < ll_rows; ll_row++)
                {
                    ls_rdno = idw_rdno.GetItem<DddwContractRd>(ll_row).RdNo;
                    if (ls_rdno == as_rdno)
                    {
                        li_rc = SUCCESS;
                        break;
                    }
                }
            }
            if (li_rc == FAILURE)
            {
                ll_row = 1;
            }
            idw_rdno.SetCurrent(ll_row);
            return li_rc;
        }

        private bool idw_rdno_filter<T>(T t) where T : DddwContractRd
        {
            if (t.ContractNo == null || t.TcId == null)
            {
                return false;
            }
            else
            {
                if (t.ContractNo == System.Convert.ToInt32(idw_rdno.FilterString.Split(':')[0]) && t.TcId == System.Convert.ToInt32(idw_rdno.FilterString.Split(':')[1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual void dw_cmb_detail_constructor()
        {
            idw_cmb = dw_cmb_detail;
        }

        public virtual int of_get_nextsequence(string sequencename)
        {

            int nReturn;
            int nNextValue;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            if (StaticVariables.gnv_app.of_isempty(sequencename))
            {
                nReturn = -(1);
            }
            else
            {
                /*select next_value into :nNextValue from id_codes where sequence_name = :sequencename ;*/
                nNextValue = RDSDataService.GetIdCodesNextValue(sequencename, ref SQLCode, ref SQLErrText);
                if (SQLCode != 0)
                {
                    /*insert into id_codes ( sequence_name, next_value) values  ( :sequencename, 2) ;*/
                    RDSDataService.InsertIdCodes(sequencename);
                    nReturn = 1;
                }
                else
                {
                    nReturn = nNextValue;
                    /*UPDATE id_codes set next_value = :nNextValue + 1 where sequence_name = :sequencename ;*/
                    RDSDataService.UpdateIdCodes(nNextValue, sequencename);
                }
            }
            //commit;
            return nReturn;
        }

        #endregion

        #region Events

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            bool lb_updated_ok;
            lb_updated_ok = true;
            idw_cmb.AcceptText();
            if (ib_insert)
            {
                //this.pfc_save();//parent.pfc_save();
                idw_cmb.Save();
            }
            else
            {
                if (wf_validate(1) == SUCCESS)
                {
                    //if (idw_cmb.update() == 1) //if (idw_cmb.update() == 1) {
                    idw_cmb.Save();
                    if (0 == 0)
                    {
                        lb_updated_ok = true;
                    }
                    else
                    {
                        lb_updated_ok = false;
                    }
                }
            }
            if (ib_validated_ok && lb_updated_ok)
            {
                //?commit;
                this.Close();
            }
            else
            {
                //?rollback;
                if (ib_insert)
                {
                    //il_cmb_id = null;
                    idw_cmb.GetItem<CmbAddressDetail>(0).CmbId = null;//idw_cmb.setitem(1, "cmb_id", il_cmb_id);
                }
                //  Set the focus on the CMB record
                idw_cmb.Focus();
            }
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            //?rollback;
            idw_cmb.Reset();
            this.Close();
        }

        public virtual void dw_cmb_detail_itemchanged(object sender, EventArgs e)
        {
            int? ll_tcid;
            int? ll_pcid;
            int ll_row;
            string ls_rdno;
            string ls_dwoname;
            string ls_mailtown;
            string ls_postcode;
            ls_dwoname = dw_cmb_detail.GetColumnName();// dwo.name;
            string TestExpr = ls_dwoname;
            if (TestExpr == "tc_id")
            {
                ll_row = idw_town.GetRow();
                ll_tcid = idw_town.GetItem<DddwContractMailtown>(ll_row).TcId;
                ls_rdno = null;
                if (wf_filter_rdno(il_contract, ll_tcid, ls_rdno) == SUCCESS)
                {
                    ll_row = idw_rdno.GetRow();
                    ls_rdno = idw_rdno.GetItem<DddwContractRd>(ll_row).RdNo;
                    ll_pcid = idw_rdno.GetItem<DddwContractRd>(ll_row).PostCodeId;
                    ls_postcode = idw_rdno.GetItem<DddwContractRd>(ll_row).PostCode;
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCode = ls_postcode;
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCodeId = ll_pcid;
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).RdNo = ls_rdno;
                }
                else
                {
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCode = "xxxx";
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCodeId = 0;
                }
            }
            else if (TestExpr == "rd_no")
            {
                ll_row = idw_rdno.GetRow();
                ls_rdno = idw_rdno.GetItem<DddwContractRd>(ll_row).RdNo;
                idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).RdNo = ls_rdno;
                ll_tcid = idw_rdno.GetItem<DddwContractRd>(ll_row).TcId;
                ls_postcode = idw_rdno.GetItem<DddwContractRd>(ll_row).PostCode;
                ll_pcid = idw_rdno.GetItem<DddwContractRd>(ll_row).PostCodeId;
                if (wf_filter_town(il_contract, ll_tcid) == SUCCESS)
                {
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCode = ls_postcode;
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCodeId = ll_pcid;
                }
                else
                {
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCode = "xxxx";
                    idw_cmb.GetItem<CmbAddressDetail>(idw_cmb.GetRow()).PostCodeId = 0;
                }
            }
            ib_changed = true;
        }

        public virtual void cb_add_clicked(object sender, EventArgs e)
        {
            int? ll_tcid;
            int? ll_pcid;
            string ls_postcode;
            string ls_rdno;
            bool lb_updated_ok;
            idw_cmb.AcceptText();
            lb_updated_ok = true;
            if (ib_insert)
            {
                idw_cmb.Save();//parent.pfc_save();
            }
            else
            {
                if (wf_validate(1) == SUCCESS)
                {
                    idw_cmb.Save();
                    //if (!(idw_cmb.update() == 1))
                    //{
                    //    lb_updated_ok = false;
                    //}
                }
            }
            if (ib_validated_ok && lb_updated_ok)
            {
                //?commit;
                ll_tcid = idw_cmb.GetItem<CmbAddressDetail>(0).TcId;
                ll_pcid = idw_cmb.GetItem<CmbAddressDetail>(0).PostCodeId;
                ls_postcode = idw_cmb.GetItem<CmbAddressDetail>(0).PostCode;
                ls_rdno = idw_cmb.GetItem<CmbAddressDetail>(0).RdNo;
                idw_cmb.Reset();
                idw_cmb.GetControlByName("cmb_box_no").BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                //?idw_cmb.Modify("cmb_box_no.Border=\'5\'");
                idw_cmb.GetControlByName("cmb_box_no").Enabled = true;//idw_cmb.Modify("cmb_box_no.Protect=\'0\'");
                idw_cmb.DataObject.AddItem<CmbAddressDetail>(new CmbAddressDetail());
                idw_cmb.GetItem<CmbAddressDetail>(0).ContractNo = il_contract;
                idw_cmb.GetItem<CmbAddressDetail>(0).TcId = ll_tcid;
                idw_cmb.GetItem<CmbAddressDetail>(0).PostCodeId = ll_pcid;
                idw_cmb.GetItem<CmbAddressDetail>(0).PostCode = ls_postcode;
                idw_cmb.GetItem<CmbAddressDetail>(0).RdNo = ls_rdno;
                //il_cmb_id = null;
                ib_insert = true;
                ib_changed = false;
                idw_cmb.DataObject.BindingSource.CurrencyManager.Refresh();

            }
            else
            {
                //?rollback;
                if (ib_insert)
                {
                    //il_cmb_id = null;
                    idw_cmb.GetItem<CmbAddressDetail>(0).CmbId = null;
                }
            }
            idw_cmb.Focus();
        }

        #endregion
    }
}