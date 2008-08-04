using System;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.DataService;

namespace NZPostOffice.ODPS.Windows.OdpsRep
{
    public partial class WReportCriteriaCtype : WReportCriteria
    {
        public WReportCriteriaCtype()
        {
            this.InitializeComponent();
        }

        public override void open()
        {
            base.open();
            //  TJB  SR4638  10-Nov-2004
            //  Implements the ability to select the contract type for the
            //  payment summary report.
            //  Note: this extends w_report_criteria - the original.  Both are needed.
            //        This window is based on an earlier w_report_criteria_postie.
            //  Associated changes in 
            // 		w_report
            // 		w_report_criteria   ( to supress its resizing the window)
            // 		dw_payment_summary_ctype
            // 		OD_RPS_Pay_summary_ctype  ( stored procedure)
            string ls_saccess;
            int li_contract_types = 0;
            int li_ct_key;
            string ls_contract_type = "";
            this.Text = "Payment Summary Report";
            is_datawindow_object = "dw_payment_summary";
            ls_saccess = of_getaccess();
            if (!(ls_saccess == "Regional"))
            {
                dw_1.Height = 230;
                //cbx_ctype.y = dw_1.height + 40
                cbx_ctype.Location = new System.Drawing.Point(0, dw_1.Height + 40);
            }
            //  Set up the checkboxes for the contract types.  Get their 
            //  text from the contract_type table.  There's one extra to 
            //  future additional contract types, but more could be needed 
            //  if more than one new one is added.
            cbx_all.Checked = true;
            cbx_1.Visible = false;
            cbx_2.Visible = false;
            cbx_3.Visible = false;
            cbx_4.Visible = false;
            cbx_5.Visible = false;
            cbx_6.Visible = false;
            cbx_7.Visible = false;
            cbx_8.Visible = false;
            cbx_9.Visible = false;
            cbx_10.Visible = false;

            //select count ( *) into :li_contract_types from rd.contract_type using SQLCA;
            ODPSDataService service = ODPSDataService.SelectContractType();
            li_contract_types = service.contractType.Count;

            for (li_ct_key = 0; li_ct_key < li_contract_types; li_ct_key++)
            {
                if (li_ct_key > 10)
                {
                    MessageBox.Show("Too many contract types to display. " + "Current maximum is 10.", "Warning");
                    break;
                }

                //select contract_type into :ls_contract_type from rd.contract_type  where ct_key = :li_ct_key  using SQLCA;
                service = ODPSDataService.SelectContractType2(li_ct_key);
                ls_contract_type = service.contractType.ContractTypeCol;
                switch (li_ct_key)
                {
                    case 1:
                        cbx_1.Text = ls_contract_type;
                        cbx_1.Visible = true;
                        break;
                    case 2:
                        cbx_2.Text = ls_contract_type;
                        cbx_2.Visible = true;
                        break;
                    case 3:
                        cbx_3.Text = ls_contract_type;
                        cbx_3.Visible = true;
                        break;
                    case 4:
                        cbx_4.Text = ls_contract_type;
                        cbx_4.Visible = true;
                        break;
                    case 5:
                        cbx_5.Text = ls_contract_type;
                        cbx_5.Visible = true;
                        break;
                    case 6:
                        cbx_6.Text = ls_contract_type;
                        cbx_6.Visible = true;
                        break;
                    case 7:
                        cbx_7.Text = ls_contract_type;
                        cbx_7.Visible = true;
                        break;
                    case 8:
                        cbx_8.Text = ls_contract_type;
                        cbx_8.Visible = true;
                        break;
                    case 9:
                        cbx_9.Text = ls_contract_type;
                        cbx_9.Visible = true;
                        break;
                    case 10:
                        cbx_10.Text = ls_contract_type;
                        cbx_10.Visible = true;
                        break;
                }
            }
            //  postevent ( "ue_aftershow") 
        }

        #region Events
        public override void cb_ok_clicked(object sender, EventArgs e)
        {
            WReport w_window = new WReport();
            DateTime dt_sdate = new DateTime();
            int? lregion_id;
            string ctype;
            bnational = false;
            ctype = "";
            if (!dw_1.AcceptText())
            {
                return;
            }
            //lregion_id = dw_1.getitemnumber(1, "region_id");
            lregion_id = dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).RegionId;
            // 	CASE 'PaymentSummary'
            //  This report requires payperiod dates
            if (lregion_id == null)
            {
                lregion_id = 0;
            }
            //  If the 'All' contract types checkbox is ticked, use the
            //  original report datawindow  ( its faster).  
            is_datawindow_object = "dw_payment_summary_ctype";
            if (cbx_all.Checked)
            {
                is_datawindow_object = "dw_payment_summary";
            }
            //  Build a list of the contract types  ( their ct_key values)
            //  for use in a 'where ... between ...' clause.  If any contract 
            //  types are deleted leaving a discontinuous set of key values,
            //  this will fail since it is assumed the ct_key values match the 
            //  checkbox sequence numbers.
            if (cbx_1.Checked)
            {
                ctype = ctype + "1,";
            }
            if (cbx_2.Checked)
            {
                ctype = ctype + "2,";
            }
            if (cbx_3.Checked)
            {
                ctype = ctype + "3,";
            }
            if (cbx_4.Checked)
            {
                ctype = ctype + "4,";
            }
            if (cbx_5.Checked)
            {
                ctype = ctype + "5,";
            }
            if (cbx_6.Checked)
            {
                ctype = ctype + "6,";
            }
            if (cbx_7.Checked)
            {
                ctype = ctype + "7,";
            }
            if (cbx_8.Checked)
            {
                ctype = ctype + "8,";
            }
            if (cbx_9.Checked)
            {
                ctype = ctype + "9,";
            }
            if (cbx_10.Checked)
            {
                ctype = ctype + "10,";
            }
            //  If one or more contract types have been selected, 
            //  remove the trailing comma.
            if (ctype.Length > 0)
            {
                //ctype = TextUtil.Left(ctype, ctype.Length - 1);
                ctype = ctype.Substring(0, ctype.Length - 1);
            }
            //  TJB  SR4684  June-2006
            //  Not actually part of the SR but avoids a less-friendly error message
            if (!cbx_all.Checked && ctype.Length < 1)
            {
                MessageBox.Show("Please select a contract type for the report.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            /*?
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "DatawindowObject", is_datawindow_object);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "StartDate", String(dw_1.GetItemDateTime(1, "sdate").Date, "yyyy-mm-dd"));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "EndDate", String(dw_1.GetItemDateTime(1, "edate").Date, "yyyy-mm-dd"));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "FinStartDate", String(dw_1.GetItemDateTime(1, "fsdate").Date, "yyyy-mm-dd"));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "FinEndDate", String(dw_1.GetItemDateTime(1, "fedate").Date, "yyyy-mm-dd"));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Title", parent.Title + ' ');
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "National", bnational);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Region", lregion_id);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Ctype", ctype);

            if (!(StaticVariables.gnv_app.of_getframe().menuid.mf_check_window(parent.Title + ' ')))
            {
                Cursor.Current = Cursors.WaitCursor;
                OpenSheet(w_window, gnv_app.of_getframe(), 0, original!);
            }
            */
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "DatawindowObject", is_datawindow_object);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "StartDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "sdate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "EndDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "edate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "FinStartDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "fsdate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "FinEndDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "fedate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Title", this.Text + " ");
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "National", bnational);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Region", lregion_id);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Ctype", ctype);

            // if (!(StaticVariables.gnv_app.of_getframe().menuid.mf_check_window(parent.Title + ' ')))
            foreach (Form frm in StaticVariables.MainMDI.MdiChildren)
            {
                if ((frm is WReport) && (frm.Text.Trim() == this.Text.Trim()))
                {
                    frm.Activate();
                    return;
                }
            }
            Cursor.Current = Cursors.WaitCursor;
            w_window.MdiParent = StaticVariables.MainMDI;
            w_window.Show();

        }

        public virtual void cbx_1_clicked(object sender, EventArgs e)
        {
            if (cbx_1.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_2_clicked(object sender, EventArgs e)
        {
            if (cbx_2.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_3_clicked(object sender, EventArgs e)
        {
            if (cbx_3.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_4_clicked(object sender, EventArgs e)
        {
            if (cbx_4.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_5_clicked(object sender, EventArgs e)
        {
            if (cbx_5.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_6_clicked(object sender, EventArgs e)
        {
            if (cbx_6.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_7_clicked(object sender, EventArgs e)
        {
            if (cbx_7.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_8_clicked(object sender, EventArgs e)
        {
            if (cbx_8.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_9_clicked(object sender, EventArgs e)
        {
            if (cbx_9.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_10_clicked(object sender, EventArgs e)
        {
            if (cbx_10.Checked == true)
            {
                cbx_all.Checked = false;
            }
        }

        public virtual void cbx_all_clicked(object sender, EventArgs e)
        {
            if (cbx_all.Checked == true)
            {
                cbx_1.Checked = false;
                cbx_2.Checked = false;
                cbx_3.Checked = false;
                cbx_4.Checked = false;
                cbx_5.Checked = false;
                cbx_6.Checked = false;
                cbx_7.Checked = false;
                cbx_8.Checked = false;
                cbx_9.Checked = false;
                cbx_10.Checked = false;
            }
        }
        #endregion
    }
}
