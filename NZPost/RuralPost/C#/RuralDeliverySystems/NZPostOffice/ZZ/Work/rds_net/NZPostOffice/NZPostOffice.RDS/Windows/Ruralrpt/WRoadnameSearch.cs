using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WRoadnameSearch : WAncestorWindow
    {
        public WRoadnameSearch()
        {
            InitializeComponent();
            dw_select.Constructor += new UserEventDelegate(dw_select_constructor);
            this.Load += new EventHandler(WRoadnameSearch_Load);
            this.Activated += new EventHandler(WRoadnameSearch_Activated);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            st_label.Text = "RDRPTRNR";
            //this.of_set_componentname(StaticVariables.gnv_app.of_get_componentopened());
        }
        
        public virtual void dw_select_constructor()
        {

            dw_select.of_SetUpdateable(false);
            ((DTownSelect)dw_select.DataObject).Retrieve();
            idw_select = dw_select;
        }

        #region Events
        public void WRoadnameSearch_Load(object sender, EventArgs args)
        {
            sle_contract_number.Enabled = false;
            //  set focus to the drop down
            //  register component
            //  this.of_set_componentName ( "Road Name Search")
        }

        public void WRoadnameSearch_Activated(object sender, EventArgs args)
        {
            base.activate();
            if (m_sheet != null)
            {
                //        m_sheet._m_contractors.Visible = false;
                //        m_sheet._m_contracts.Visible = false;
                //        m_sheet._m_addresses.Visible = false;
            }
        }

        public virtual void rb_contract_clicked(object sender, EventArgs e)
        {
            idw_select.Enabled = false;
            //? idw_select.(7)DataControl["town_list"].BackColor =\'79741120\'");
            this.sle_contract_number.Enabled = true;
            this.ii_report_type = 2;
        }

        public virtual void rb_town_clicked(object sender, EventArgs e)
        {
            idw_select.Enabled = true;
            this.sle_contract_number.Text = "";
            this.sle_contract_number.Enabled = false;
            //?idw_select.(7)DataControl["town_list"].BackColor =\'16777215\'");
            this.ii_report_type = 1;
        }

        public virtual void dw_select_clicked(object sender, EventArgs e)
        {
            //  Check if the radio buttons have changed and if so - change focus
            // 
            // If this.Object.Town.CheckBox.checked = true and ii_report_type = 2 then
            // 	// make sure that the other one is not checked and disable its field
            // 	this.Object.Contract.CheckBox.checked = false
            // 	this.Object.Contract_number.enabled = false
            // 	this.Object.Town_list.enabled = true
            // 
            // elseif this.Object.Contract.CheckBox.checked = true and ii_report_type = 1 then
            // 	// other way around now
            // 	this.object.Town.CheckBox.checked = false
            // 	this.object.Town_List.enabled = false
            // 	this.object.Contract_number.enabled = true
            // 	this.object.Contract_number.Edit = true
            // 
            // end if
        }

        public virtual void pb_open_clicked(object sender, EventArgs e)
        {
            //  If contract - check first that is valid number then if it is in the database
            //  TJB  NPAD2 fixup BF011  May 2006
            //  Changed tc_num to Metex.Common.Convert.ToInt32( was integer)
            int? ll_contract_num = 0;
            int ll_con_count = 0;
            int ll_tc_num = 0;
            string ls_tc_name = string.Empty;
            string ls_con_title = string.Empty;
            string ls_contract_num = string.Empty;

            int sqlCode = -1;
            string sqlErrText = "";

            ls_contract_num = this.sle_contract_number.Text;
            //  this will return 0 if not a valid number
            int l_temp;
            Int32.TryParse(ls_contract_num, out l_temp);//ll_contract_num = System.Convert.ToInt32(ls_contract_num);
            ll_contract_num = l_temp;

            // set up the transaction object
            if (ii_report_type == 2)
            {
                if (ll_contract_num > 0)
                {
                    //SELECT count(*) INTO :ll_con_count FROM Contract WHERE Contract.contract_no = :ll_contract_num USING SQLCA;
                    ll_con_count = RDSDataService.GetContractCount(ll_contract_num);

                    //SELECT con_title INTO :ls_con_title FROM Contract WHERE Contract.contract_no = :ll_contract_num USING SQLCA;
                    ls_con_title = RDSDataService.GetContractValue(ll_contract_num, ref sqlCode, ref sqlErrText);
                    if (sqlCode < 0) 
                    {
                        MessageBox.Show(sqlErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (ll_con_count > 0)
                    {
                        StaticVariables.gnv_app.of_get_parameters().longparm = ll_contract_num;
                        StaticVariables.gnv_app.of_get_parameters().integerparm = 2;
                        StaticVariables.gnv_app.of_get_parameters().stringparm = "Contract Number: " + ll_contract_num.ToString() + "     Title: " + ls_con_title;
                        // OpenSheetWithParm(w_roadname_report, parent, w_main_mdi, 0, original!);
                        //?StaticMessage.PowerObjectParm = parent;
                        WRoadnameReport w_roadname_report = new WRoadnameReport();
                        w_roadname_report.MdiParent = StaticVariables.MainMDI;
                        w_roadname_report.Show();
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
                ls_tc_name = (string)this.idw_select.GetValue(this.dw_select.GetRow(), "town");// dw_select.GetColumnName());

                //SELECT tc_id INTO :ll_tc_num FROM TownCity WHERE TownCity.tc_name = :ls_tc_name USING SQLCA;
                ll_tc_num = RDSDataService.GetTownCityValue(ls_tc_name, ref sqlCode, ref sqlErrText);
                if (sqlCode < 0) 
                {
                    MessageBox.Show(sqlErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                StaticVariables.gnv_app.of_get_parameters().stringparm = " " + ls_tc_name;
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_tc_num;
                StaticVariables.gnv_app.of_get_parameters().integerparm = 1;
                // OpenSheetWithParm(w_roadname_report, parent, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = this;
                WRoadnameReport w_roadname_report = new WRoadnameReport();
                w_roadname_report.MdiParent = StaticVariables.MainMDI;
                w_roadname_report.Show();
            }
        }
        #endregion
    }
}