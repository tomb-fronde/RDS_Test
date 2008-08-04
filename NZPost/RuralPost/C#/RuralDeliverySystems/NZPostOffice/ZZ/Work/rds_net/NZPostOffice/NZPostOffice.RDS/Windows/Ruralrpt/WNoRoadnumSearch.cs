using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WNoRoadnumSearch : WAncestorWindow
    {
        public int ii_report_type = 1;

        public WNoRoadnumSearch()
        {
            InitializeComponent();
            this.Load += new EventHandler(WNoRoadnumSearch_Load);
            this.Activated += new EventHandler(WNoRoadnumSearch_Activated);
            dw_select.Constructor += new UserEventDelegate(dw_select_constructor);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname(StaticVariables.gnv_app.of_get_componentopened());
            st_label.Text = "RDRPTRNN";
        }
     
        public virtual void dw_select_constructor()
        {
            dw_select.of_SetUpdateable(false);
            ((DTownSelect)dw_select.DataObject).Retrieve();
        }

        #region Events
        public void WNoRoadnumSearch_Load(object sender, EventArgs args)
        {
            sle_contract_number.Enabled = false;
            //  set focus to the drop down
            //  register component
            //  this.of_set_componentName ( "Road Name Search")
        }

        public void WNoRoadnumSearch_Activated(object sender, EventArgs args)
        {
            base.activate();
            if (m_sheet != null)
            {
                //m_sheet._m_contractors.Visible = false; 
                //m_sheet._m_contracts.Visible = false;
                //m_sheet._m_addresses.Visible = false;
            }
        }

        public virtual void rb_contract_clicked(object sender, EventArgs e)
        {
            dw_select.Enabled = false;
            dw_select.GetControlByName("town_list").BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            this.sle_contract_number.Enabled = true;
            this.ii_report_type = 2;
        }

        public virtual void rb_town_clicked(object sender, EventArgs e)
        {
            //  if this is clicked - disable the other field
            dw_select.Enabled = true;
            this.sle_contract_number.Text = "";
            this.sle_contract_number.Enabled = false;
            dw_select.GetControlByName("town_list").BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.ii_report_type = 1;
        }

        public virtual void dw_select_clicked(object sender, EventArgs e)
        {
            //  Check if the radio buttons have changed and if so - change focus
            // 
            // If this.Object.Town.CheckBox.checked = true and ii_report_type = 2 then
            // 	// make sure that the other one is not checked and disable its field
            // 	this.Object.Contract.CheckBox.checked = false
            // 	this.Object.Contract_number.Enabled = false
            // 	this.Object.Town_list.Enabled = true
            // 
            // elseif this.Object.Contract.CheckBox.checked = true and ii_report_type = 1 then
            // 	// other way around now
            // 	this.object.Town.CheckBox.checked = false
            // 	this.object.Town_List.Enabled = false
            // 	this.object.Contract_number.Enabled = true
            // 	this.object.Contract_number.Edit = true
            // 
            // end if
        }

        public virtual void pb_open_clicked(object sender, EventArgs e)
        {
            //  If contract - check first that is valid number then if it is in the database
            //  TJB  NPAD2 fixup  May 2006
            //  Changed tc_num to Metex.Common.Convert.ToInt32( was integer)
            int? ll_contract_num;
            int ll_tc_num = 0;
            int ll_con_count = 0;
            string ls_con_title = string.Empty;
            string ls_tc_name = string.Empty;
            string ls_contract_num = string.Empty;

            int sqlCode = -1;
            string sqlErrText = "";
            ls_contract_num = this.sle_contract_number.Text;

            ll_contract_num = (ls_contract_num == null || ls_contract_num == "") ? 0 : System.Convert.ToInt32(ls_contract_num);
            // set up the transaction object
            if (ii_report_type == 2)
            {
                if (ll_contract_num > 0)
                {
                    //SELECT count ( *) INTO :ll_con_count FROM Contract WHERE Contract.contract_no = :ll_contract_num USING SQLCA;
                    ll_con_count = RDSDataService.GetContractCount(ll_contract_num);

                    //SELECT con_title INTO :ls_con_title FROM Contract WHERE Contract.contract_no = :ll_contract_num USING SQLCA;
                    ls_con_title = RDSDataService.GetContractValue(ll_contract_num, ref sqlCode, ref sqlErrText);
                    if (sqlCode < 0)  // (StaticVariables.sqlca.SQLCode < 0) 
                    {
                        MessageBox.Show(/*app.sqlca.SQLErrText*/sqlErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (ll_con_count > 0)
                    {
                        StaticMessage.LongParm = (long)ll_contract_num;// StaticVariables.gnv_app.of_get_parameters().longparm = ll_contract_num;
                        StaticMessage.IntegerParm = 2; // StaticVariables.gnv_app.of_get_parameters().integerparm = 2;
                        StaticMessage.StringParm = "Contract Number: " + ll_contract_num.ToString() + "     Title: " + ls_con_title; ; // StaticVariables.gnv_app.of_get_parameters().stringparm = "Contract Number: " + ll_contract_num.ToString() + "     Title: " + ls_con_title;
                        //OpenSheetWithParm(w_nonumber_report, parent, w_main_mdi, 0, original!);
                        StaticMessage.PowerObjectParm = this;
                        WNonumberReport w_nonumber_report = new WNonumberReport();
                        w_nonumber_report.MdiParent = StaticVariables.MainMDI;
                        w_nonumber_report.Show();
                    }
                    else
                    {
                        MessageBox.Show("The contract number entered is invalid. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("The contract number entered is invalid. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //  else is a tc_type - get id and pass on to new window
            }
            else if (ii_report_type == 1)
            {
                //  get tc_id
                //ls_tc_name = this.dw_select.GetValue(this.dw_select.GetRow(), dw_select.GetColumnName()).ToString();
                ls_tc_name = this.dw_select.GetItem<NZPostOffice.RDS.Entity.Ruralrpt.TownSelect>(this.dw_select.GetRow()).Town;

                //SELECT min ( TownCity.tc_id) INTO :ll_tc_num FROM TownCity WHERE TownCity.tc_name = :ls_tc_name USING SQLCA;
                ll_tc_num = RDSDataService.GetTownCityValue2(ls_tc_name, ref sqlCode, ref sqlErrText);
                if (sqlCode < 0) // (StaticVariables.sqlca.SQLCode < 0) 
                {
                    MessageBox.Show(/*app.sqlca.SQLErrText*/sqlErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                StaticVariables.gnv_app.of_get_parameters().stringparm = " " + ls_tc_name;
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_tc_num;
                StaticVariables.gnv_app.of_get_parameters().integerparm = 1;
                //OpenSheetWithParm(w_nonumber_report, parent, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = this;
                WNonumberReport w_nonumber_report = new WNonumberReport();
                w_nonumber_report.MdiParent = StaticVariables.MainMDI;
                w_nonumber_report.Show();
            }
        }
        #endregion
    }
}
