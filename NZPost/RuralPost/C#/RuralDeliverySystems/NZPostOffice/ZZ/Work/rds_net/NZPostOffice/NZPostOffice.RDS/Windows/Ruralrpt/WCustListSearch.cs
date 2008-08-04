using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;
using Metex.Core;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustListSearch : WAncestorWindow
    {
        #region Define
        public int ii_report_type = 1;

        public bool ib_seq_checked = false;

        public bool ib_seq_sort = false;

        public bool ib_disp_recip = true;

        public bool ib_disp_seq = false;

        public bool ib_disp_cat = true;

        public bool ib_disp_kiwi = true;

        public int? il_long_parm;

        public int ii_number_parm;

        public int ii_report_parm;

        public string is_header_parm = String.Empty;

        public string is_sort_string = String.Empty;

        public string is_sort_header = String.Empty;

        public int il_last_post_click;

        #endregion

        public WCustListSearch()
        {
            InitializeComponent();

            //jlwang:moved from IC
            this.dw_town.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_town_constructor);
            ((DConCriteria)dw_contract.DataObject).CellDoubleClick += new EventHandler(dw_contract_doubleclicked);
            dw_contract.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_contract_constructor);
            //jlwang:end
        }
      
        #region Methods
        public override void open()
        {
            this.rb_contract_clicked(null, null);
        }

        public override void activate()
        {
            base.activate();
            if (m_sheet != null)
            {
                m_sheet._m_contractors.Visible = false;
                m_sheet._m_contracts.Visible = false;
                m_sheet._m_addresses.Visible = false;
            }
        }

        private void insertRow(DataUserControl dw, int row)
        {
            //string typeName = dw.BindingSource.DataSource.GetType().ToString();
            //typeName = typeName.Substring(typeName.LastIndexOf("[") + 1);
            //typeName = typeName.Substring(0, typeName.Length - 1);
            //string st = dw.GetType().Assembly.ToString();
            //st = st.Replace("DataControls", "Entity");

            string typeName = dw.GetType().FullName.Replace("DataControls", "Entity");
            typeName = typeName.Replace(".D", ".");
            string st = dw.GetType().Assembly.ToString();
            st = st.Replace("DataControls", "Entity");

            System.Reflection.Assembly dll = System.Reflection.Assembly.Load(st);
            object obj = Activator.CreateInstance(dll.GetType(typeName));
            dw.BindingSource.List.Insert(row, (EntityBase)obj);
        }

        //public override void pfc_postopen()
        //{
        //    base.pfc_postopen();
        //    DataUserControl dwChild;
        //    int? lNull;
        //    lNull = null;
        //    if (dw_town.GetControlByName("town_list") is DataEntityCombo)
        //    {
        //        dwChild = dw_town.GetChild("town_list");
        //        dwChild.Retrieve();
        //        // insertRow(dwChild, 0);
        //        insertRow(dwChild, 0);
        //        dwChild.SetValue(0, "tc_name", lNull);
        //        dwChild.SetValue(0, "tc_name", "Any");
        //        insertRow(dwChild, 0);
        //        dwChild.DeleteItemAt(0);
        //        ((Metex.Windows.DataEntityCombo)(dw_town.GetControlByName("town_list"))).SelectedIndex = 0;
        //    }
        //    //dw_town.GetItem<CustListTown>(0).Town = "Any"; //dw_town.SetItem(1, "town_list", "Any");
        //    //((Metex.Windows.DataEntityCombo)(dw_town.GetControlByName("town_list"))).SelectedIndex = 0;
        //    dw_town.DataObject.BindingSource.CurrencyManager.Refresh();

        //}

        public virtual void dw_town_constructor()
        {
            //? base.constructor();
            DataUserControl dwChild;
            int? lNull;
            lNull = null;
            //?((DCustListTown)dw_town.DataObject).Retrieve();
            //  put "Any" into first slot
            //? dw_town.InsertItem<CustListTown>(0);
            dw_town.InsertRow(0);
            if (dw_town.GetControlByName("town_list") is DataEntityCombo)
            {
                dwChild = dw_town.GetChild("town_list");
                dwChild.Retrieve();
                // insertRow(dwChild, 0);
                insertRow(dwChild, 0);
                //dwChild.SetValue(0, "tc_name", lNull);
                dwChild.SetValue(0, "tc_name", "Any");
                insertRow(dwChild, 0);
                dwChild.DeleteItemAt(0);
                //? ((Metex.Windows.DataEntityCombo)(dw_town.GetControlByName("town_list"))).SelectedIndex = 0;
            }
            //?dw_town.GetItem<CustListTown>(0).Town = "Any"; //dw_town.SetItem(1, "town_list", "Any");
            dw_town.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_town.of_SetUpdateable(false);
        }

        public virtual void cbx_recipients_constructor()
        {
            StaticVariables.gb_cust_list_recip = false;
            cbx_recipients.Checked = false;
        }

        public virtual void cbx_category_constructor()
        {
            StaticVariables.gb_cust_list_cat = true;
            cbx_category.Checked = true;
        }

        public virtual void cbx_kiwi_constructor()
        {
            StaticVariables.gb_cust_list_kiwi = true;
            cbx_kiwi.Checked = true;
        }

        public virtual void dw_contract_constructor()
        {
            //?base.constructor();
            ((DConCriteria)dw_contract.DataObject).Retrieve();
            dw_contract.of_SetUpdateable(false);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  register component
            this.of_set_componentname(StaticVariables.gnv_app.of_get_componentopened());
        }

        public virtual int of_set_sort()
        {
            //  This function will create a sort string to pass into the report window
            //  TJB  Oct 2005  NPAD2 Address schema changes
            //  Added road_unit sort field  ( ls_street_sort4)
            int li_cust_sort;
            int li_street_sort;
            int li_cat_sort;
            string ls_cust_sort1;
            string ls_cust_sort2;
            string ls_street_sort1;
            string ls_street_sort2;
            string ls_street_sort3;
            string ls_street_sort4;
            string ls_cat_sort;
            string ls_sort_header;
            string ls_cust_header;
            string ls_street_header;
            Dictionary<int, string> ls_sort_build = new Dictionary<int, string>(4);
            string ls_temp_sort;
            ls_sort_header = "Sorted by : ";
            ls_cust_header = "Customer Name";
            ls_street_header = "Address";
            //  ls_seq_sort     = "seq_no"
            ls_street_sort1 = "road_name";
            ls_street_sort2 = "road_no";
            ls_street_sort3 = "road_alpha";
            ls_street_sort4 = "road_unit";
            ls_cust_sort1 = "sur_comp_name";
            ls_cust_sort2 = "initials";
            ls_cat_sort = "categories";
            ls_temp_sort = "";
            //  add contract to beginning if report type = 2
            if (ii_report_type == 2)
            {
                ls_temp_sort = "contract_no A";
            }
            li_cust_sort = Convert.ToInt32(sle_customer.Text);
            li_street_sort = Convert.ToInt32(sle_street.Text);
            //  li_seq_sort    = integer ( sle_seq.Text)
            li_cat_sort = Convert.ToInt32(sle_cat.Text);
            //  first see if there is a descending checked without a priority
            if (cbx_cust.Checked && li_cust_sort == 0 || cbx_street.Checked && li_street_sort == 0 || cbx_cat.Checked && li_cat_sort == 0)
            {
                //  kick off message and return 01
                MessageBox.Show("The appropriate sort priority must be entered " + "if a descending option is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            if (li_cust_sort < 0 || li_cust_sort > 3 || li_street_sort < 0 || li_street_sort > 3 || li_cat_sort < 0 || li_cat_sort > 3)
            {
                //  is not valid
                MessageBox.Show("Your sort criteria was invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            else if (li_cust_sort == li_street_sort && li_cust_sort != 0 || li_cust_sort == li_cat_sort && li_cust_sort != 0 || li_street_sort == li_cat_sort && li_street_sort != 0)
            {
                //  or see if have duplicate values	
                MessageBox.Show("You have duplicate priorties selected for sorting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            //  build sort string
            if (cbx_cust.Checked)
            {
                ls_sort_build[li_cust_sort + 1] = ls_cust_sort1 + " D, " + ls_cust_sort2 + " D";
            }
            else
            {
                ls_sort_build[li_cust_sort + 1] = ls_cust_sort1 + " A, " + ls_cust_sort2 + " A";
            }
            if (cbx_cat.Checked)
            {
                ls_sort_build[li_cat_sort + 1] = ls_cat_sort + " D";
            }
            else
            {
                ls_sort_build[li_cat_sort + 1] = ls_cat_sort + " A";
            }
            // if cbx_seq.Checked then
            // ls_sort_build[li_seq_sort + 1] = ls_seq_sort + " D"
            // else
            // ls_sort_build[li_seq_sort + 1] = ls_seq_sort + " A"
            // end if
            if (cbx_street.Checked)
            {
                ls_sort_build[li_street_sort + 1] = ls_street_sort1 + " D, " + ls_street_sort2 + " A, " + ls_street_sort3 + " A, " + ls_street_sort4 + " A";
            }
            else
            {
                ls_sort_build[li_street_sort + 1] = ls_street_sort1 + " A, " + ls_street_sort2 + " A, " + ls_street_sort3 + " A, " + ls_street_sort4 + " A";
            }
            int count;
            for (count = 2; count <= 4; count++)//for count = 2 to 4
            {
                if (ls_temp_sort.Length > 1 && ls_temp_sort.Substring(ls_temp_sort.Length - 2, 2) != ", ")
                {
                    ls_temp_sort = ls_temp_sort + ", ";
                }
                ls_temp_sort = ls_temp_sort + ls_sort_build[count];
                if (ls_sort_build[count].IndexOf("road") != 0)
                {
                    if (ls_sort_header.Length > 13)
                    {
                        ls_sort_header = ls_sort_header + ',';
                    }
                    ls_sort_header = ls_sort_header + ' ' + ls_street_header;
                    if (ls_sort_build[count].IndexOf('D') != 0)
                    {
                        ls_sort_header = ls_sort_header + " Descending";
                    }
                }
                else if (ls_sort_build[count].IndexOf("initials") != 0)
                {
                    if (ls_sort_header.Length > 13)
                    {
                        ls_sort_header = ls_sort_header + ',';
                    }
                    ls_sort_header = ls_sort_header + ' ' + ls_cust_header;
                    if (ls_sort_build[count].IndexOf('D') != 0)
                    {
                        ls_sort_header = ls_sort_header + " Descending";
                    }
                }
            }
            //  if no sort criteria - append none to the sort header
            if (ls_sort_header.Length < 13)
            {
                ls_sort_header = "";
            }
            is_sort_header = ls_sort_header;
            //  cleave off the last comma from the temp sort string
            if (ls_temp_sort.Substring(ls_temp_sort.Length - 2, 2) == ", ")
            {
                ls_temp_sort = ls_temp_sort.Substring(1, ls_temp_sort.Length - 2);
            }
            //  TJB  SR4659  July 2005
            //  Add CMB seq sort option, to put the CMBs at the bottom
            //  is_sort_string = ls_temp_sort
            is_sort_string = "cmb_seq A, " + ls_temp_sort;
            /*  ----------------------- Debugging ----------------------- //
            messagebox ( 'w_cust_list_search.of_set_search', & 'Sort string:  ( '+string ( lenw ( is_sort_string))+')~r'  & +mid ( is_sort_string,1,50)+'~r'   & +mid ( is_sort_string,51)     )

            // ---------------------------------------------------------  */
            //  set global sort pass
            StaticVariables.gs_cust_list_sort = is_sort_string;
            return 1;
        }

        public virtual int of_export()
        {
            //  Open the file dialog
            dw_export.of_SetUpdateable(false);
            //  TWC - 17/09/2003
            //  Construct the file name
            // string ls_filename
            // ls_filename = "pronto" + string ( year ( today ( ))) + string ( month ( today ( ))) + string ( daynumber ( today ( ))) + ".PSR"
            return dw_export.SaveAs("", "psreport"); ;//?dw_export.SaveAs("", psreport, true);
        }

        public virtual int of_set_sequence()
        {
            // // check to see if the value is any
            // if	dw_frequency.getitemstring ( dw_frequency.getrow ( ), "freq_list") = "All"	 or rb_town.Checked = true then
            // 
            // cbx_sequence.Enabled = false
            // ib_seq_checked = cbx_sequence.Checked 
            // cbx_sequence.Checked = false
            // 
            // st_sequence.Enabled = false
            // sle_seq.Enabled = false
            // cbx_seq.Enabled = false
            // cbx_seq.Checked = false
            // gb_cust_list_seq = false
            // 
            // else
            // 
            // // send cbx_sequence back to whatever it was and enable it
            // cbx_sequence.Enabled = true
            // cbx_sequence.Checked = ib_seq_checked
            // 
            // st_sequence.Enabled = true
            // sle_seq.Enabled = true
            // cbx_seq.Enabled = true
            // cbx_seq.Checked = ib_seq_sort
            // 
            // gb_cust_list_seq = false
            // 
            // end if
            return 1;
        }

        public virtual int of_disable_buttons()
        {
            //  disable other buttons
            pb_open.Enabled = false;
            pb_export.Enabled = false;
            pb_open.Visible = false;
            pb_export.Visible = false;
            return 1;
        }

        public virtual int count_rows()
        {
            //  Count the number of rows that would be returned from the query
            int row_count;
            row_count = 1;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            if (ii_report_parm == 1)
            {
                //  do count
                /* select count(*) into :row_count from address addr where addr.tc_id = :il_long_parm  USING SQLCA;*/
                row_count = RDSDataService.GetAddrTcId(il_long_parm, ref SQLCode, ref SQLErrText);
            }
            else if (ii_report_parm == 2)
            {
                //  do count
                /*  select count(*) into :row_count from address addr where addr.contract_no = :il_long_parm  USING SQLCA;*/
                row_count = RDSDataService.GetAddrContractNo(il_long_parm, ref SQLCode, ref SQLErrText);
            }
            if (SQLCode < 0)
            {
                MessageBox.Show(SQLErrText, "SQL ERROR - w_cust_list_search.count_rows", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            return row_count;
        }

        public virtual int of_write_contracts()
        {
            //  TWC -- 17/09/2003 
            //  This funtion will retrieve all the contract numbers 
            //  and write them to the rds_temp table
            int ll_selectedrow;
            int? ll_recip;
            int? ll_selected_contracts;
            int ll_contract_written = 0;
            bool lb_proceed;
            DateTime? ld_con_actioned;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            //  Get the recipients flag
            ll_recip = 0;
            if (cbx_recipients.Checked == true)
            {
                ll_recip = 1;
            }
            //  Clear the rds_temp table
            //  delete from rds_temp using sqlca;
            RDSDataService.DeleteRdsTemp(ref SQLCode, ref SQLErrText);
            if (SQLCode < 0)
            {
                MessageBox.Show("Error clearing temporary table\r\r" + SQLErrText, "SQL ERROR - w_cust_list_search.of_write_contracts", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            //  Get the first selected row
            ll_selectedrow = dw_contract.GetSelectedRow(0);
            //  If none were found tell the user
            if (ll_selectedrow == -1)
            {
                MessageBox.Show("Please select at least one contract for report.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            while (ll_selectedrow != -1)
            {
                ll_selected_contracts = dw_contract.GetItem<ConCriteria>(ll_selectedrow).ContractNo;
                //  TWC - 17/09/2003 - check the last actioned details
                ld_con_actioned = null;
                /* select cust_list_updated into :ld_con_actioned  from rd.contract where contract_no = :ll_selected_contracts and cust_list_updated is not null using sqlca;*/
                ld_con_actioned = RDSDataService.GetLdConActioned(ll_selected_contracts);
                lb_proceed = true;
                if (ld_con_actioned != null && ld_con_actioned != DateTime.MinValue && ((TimeSpan)(DateTime.Today - ld_con_actioned)).Days > 30)
                {
                    if (MessageBox.Show("Contract No " + ll_selected_contracts.ToString() + " has yet to be returned!\r" + "Do you wish to export the report for this contract?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    {
                        lb_proceed = false;
                    }
                }
                if (lb_proceed)
                {
                    /* insert into rds_temp	(rds_id, rds_code)  values ( :ll_selected_contracts, :ll_recip) using sqlca;*/
                    RDSDataService.InsertRdsTemp(ll_selected_contracts, ll_recip);
                    ll_contract_written++;
                }
                //  Get the next selected row
                ll_selectedrow = dw_contract.GetSelectedRow(ll_selectedrow + 1);//dw_contract.GetSelectedRow(ll_selectedrow);
            }
            if (ll_contract_written == 0)
            {
                return -(1);
            }
            return 1;
        }

        #endregion

        #region Events

        public virtual void pb_open_clicked(object sender, EventArgs e)
        {
            //  TJB  10-Mar-2005
            //  The contract title was left off the report header line by mistake.
            //  Put back.
            int? ll_selected_contracts;
            string ls_selected_contracts;
            //  check for the sort
            if (of_set_sort() == -(1))
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            //  Report type  ( ii_report_parm)
            // 		1		Town/City 
            // 		2		Contract
            // 		4		Any Town/City
            if (ii_report_parm == 2)
            {
                int ll_selectedrow;
                int ll_selected_count;
                int ll_win_counter = 0;
                Dictionary<int, WCustListReport> lw_temp = new Dictionary<int, WCustListReport>();//Cl_w_cust_list_reportArray lw_temp = new Cl_w_cust_list_reportArray();
                //? ll_selected_count = Convert.ToInt32(dw_contract.describe("evaluate ( \'sum (  if ( IsSelected ( ), 1, 0) for all)\',1)"));
                ll_win_counter = 1;
                ll_selectedrow = ((Metex.Windows.DataEntityGrid)(dw_contract.GetControlByName("grid"))).SelectedRows[0].Index;//dw_contract.GetSelectedRow(0);--add mkwang
                // 	ll_selectedrow = dw_contract.getselectedrow ( ll_selectedrow)
                if (ll_selectedrow == -1)
                {
                    MessageBox.Show("Please select at least one contract for report.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                for (int i = 0; i < ((DConCriteria)dw_contract.DataObject).ConCriteriaGrid.SelectedRows.Count; i++) //while (ll_selectedrow != -1){--add mkwang 
                {
                    ll_selected_contracts = dw_contract.GetItem<ConCriteria>(ll_selectedrow).ContractNo;
                    ls_selected_contracts = dw_contract.GetItem<ConCriteria>(ll_selectedrow).ConTitle;
                    //  get the next selected row
                    ll_selectedrow = ((Metex.Windows.DataEntityGrid)(dw_contract.GetControlByName("grid"))).SelectedRows[i].Index;//dw_contract.GetSelectedRow(ll_selectedrow);--add mkwang
                    StaticVariables.gnv_app.of_get_parameters().longparm = ll_selected_contracts;
                    StaticVariables.gnv_app.of_get_parameters().integerparm = ii_report_parm;
                    //  TJB  10-Mar-2005
                    //  The contract title was left off the report header line by mistake.
                    StaticVariables.gnv_app.of_get_parameters().stringparm = "Contract Number: " + ll_selected_contracts.ToString() + "     Title: " + ls_selected_contracts;
                    //  open the report
                    // OpenSheetWithParm(lw_temp[ll_win_counter], parent, w_main_mdi, 0, original);
                    StaticMessage.PowerObjectParm = this;
                    lw_temp[ll_win_counter] = new WCustListReport();
                    lw_temp[ll_win_counter].MdiParent = StaticVariables.MainMDI;
                    lw_temp[ll_win_counter].Show();
                    ll_win_counter++;
                    //  TJB  SR4683  Aug 2006
                    //  If the user presses the Abort button stop processing 
                    //  selected contracts.  This window doesn't have ready 
                    //  access to the flag that is set, so the called window 
                    //   ( w_cust_list_report) returns its value in BooleanParm.
                    //if (StaticVariables.gnv_app.of_get_parameters().booleanparm)
                    //{
                    //    break;
                    //}            //modify wjtang SR4703
                }
            }
            else if (ii_report_parm != 0 && ii_report_parm != 2)
            {
                //  kick off the new report
                StaticVariables.gnv_app.of_get_parameters().longparm = il_long_parm;
                StaticVariables.gnv_app.of_get_parameters().integerparm = ii_report_parm;
                StaticVariables.gnv_app.of_get_parameters().stringparm = is_header_parm + "     " + is_sort_header;
                //  gnv_App.of_Get_Parameters ( ).DoubleParm = ii_number_parm
                //  open the report
                // OpenSheetWithParm(w_cust_list_report, parent, w_main_mdi, 0, original);
                StaticMessage.PowerObjectParm = this;
                OpenSheet<WCustListReport>(StaticVariables.MainMDI);
            }
            else
            {
                MessageBox.Show("Unrecognised report type  ( " + Convert.ToString(ii_report_parm) + ")??", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public virtual void rb_town_clicked(object sender, EventArgs e)
        {
            //  If this is clicked - disable the other fields
            dw_town.Enabled = true;
            // sle_contract_number.Text = ""
            dw_contract.Enabled = false;
            //  dw_frequency.Enabled = false
            //  make the other 2 button face and town white
            dw_town.GetControlByName("town_list").BackColor = System.Drawing.Color.FromArgb(255, 255, 255);//dw_town.(7)DataControl["town_list"].BackColor =\'16777215\'");
            //  dw_frequency.modify ( "freq_list.BackGround.Color='79741120'")
            //  set the report type
            ii_report_type = 1;
            //  disable stuff
            of_disable_buttons();
            //  TJB  SR4657  June05  - added
            //  unselect all contracts
            dw_contract.SelectAllRows(false);//SelectRow(0, false);
        }

        public virtual void rb_contract_clicked(object sender, EventArgs e)
        {
            //  disable buttons
            of_disable_buttons();
            //  if this is clicked - disable the other fields
            //  trigger the item changed event in dw_frequency
            //  dw_frequency.triggerevent ( itemchanged!)
            dw_town.Enabled = false;
            dw_contract.Enabled = true;
            ((DConCriteria)(dw_contract.DataObject)).Grid.Enabled = true;
            //  dw_frequency.Enabled = false
            //  make the other 2 button face and town white
            dw_town.DataObject.GetControlByName("town_list").BackColor = System.Drawing.Color.FromArgb(192, 192, 192);//dw_town.(7)DataControl["town_list"].BackColor =\'79741120\'");
            //  dw_frequency.modify ( "freq_list.BackGround.Color='79741120'")
            //  set the report type
            ii_report_type = 2;
            //  send cbx_sequence back to whatever it was and enable it
            // if dw_frequency.getitemstring ( dw_frequency.getrow ( ), "freq_list") <> "All" then
            // 
            // cbx_sequence.Enabled = true
            // cbx_sequence.Checked = ib_seq_checked 
            // gb_cust_list_seq = ib_seq_checked
            // 
            // st_sequence.Enabled = true
            // sle_seq.Enabled = true
            // cbx_seq.Enabled = true
            // cbx_seq.Checked = ib_seq_sort
            // 
            // end if
            //  disable stuff
            of_disable_buttons();
            //  unselect all contracts
            //dw_contract.SelectRow(0, false);
            dw_contract.SelectAllRows(false);
        }

        public virtual void dw_town_itemchanged(object sender, EventArgs e)
        {
            dw_town.URdsDw_Itemchanged(sender, e);
            //  disable stuff
            of_disable_buttons();
        }

        public virtual void cbx_recipients_clicked(object sender, EventArgs e)
        {
            ib_disp_recip = cbx_recipients.Checked;
            StaticVariables.gb_cust_list_recip = cbx_recipients.Checked;
            //  disable the buttons until search done
            of_disable_buttons();
        }

        public virtual void cbx_category_clicked(object sender, EventArgs e)
        {
            ib_disp_cat = cbx_category.Checked;
            StaticVariables.gb_cust_list_cat = cbx_category.Checked;
            //  disable the buttons until search done
            of_disable_buttons();
        }

        public virtual void cbx_kiwi_clicked(object sender, EventArgs e)
        {
            ib_disp_kiwi = cbx_kiwi.Checked;
            StaticVariables.gb_cust_list_kiwi = cbx_kiwi.Checked;
            //  disable the buttons until search done
            of_disable_buttons();
        }

        public virtual void pb_search_clicked(object sender, EventArgs e)
        {
            //  TJB June 2005  - Note
            //  This seems to be incomplete, with a lot of redundant, unused code
            // set the sequence 
            //  gb_cust_list_seq = cbx_sequence.Checked
            //  check the sorting criteria are valid
            if (of_set_sort() == -(1))
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            //  Report type  ( used elsewhere as ii_report_parm)
            // 		1		Town/City 
            // 		2		Contract
            // 		4		Any Town/City  ( set within ii_report_type = 1 code)
            if (ii_report_type == 1)
            {
                //  get the tc_id and set up the parms
                string ls_town;
                int ll_tc_id;
                ls_town = dw_town.GetItem<CustListTown>(dw_town.GetRow()).Town;
                if (ls_town == "Any")
                {
                    ll_tc_id = 0;
                }
                else
                {
                    /* select min(tc_id) into :ll_tc_id from towncity where towncity.tc_name = :ls_town using SQLCA;*/
                    ll_tc_id = RDSDataService.GetTowncityLlTcId(ls_town);
                }
                il_long_parm = ll_tc_id;
                ii_report_parm = 1;
                is_header_parm = "Town/City: " + ls_town;
                //  if set to any - set the report type to be 4
                if (ll_tc_id == 0)
                {
                    //  ii_report_type = 4
                    ii_report_parm = 4;
                }
                if (ii_report_parm != 4 && count_rows() == 0)
                {
                    MessageBox.Show("This search returned no rows. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  Enable the open and export buttons
                pb_open.Enabled = true;
                pb_open.Visible = true;
                pb_export.Enabled = true;
                pb_export.Visible = true;
            }
            else if (ii_report_type == 2)
            {
                //  firstly validate the contract number	
                string ls_contract_num;
                int li_contract_num = 0;
                int counter;
                int li_selected_contracts = 0;
                int ll_selectedrow;
                int ll_recip_check = 0;
                //  see if need to set recipients
                if (cbx_recipients.Checked == true)
                {
                    ll_recip_check = 1;
                }
                ll_selectedrow = dw_contract.GetSelectedRow(0);
                //  ll_selectedrow = dw_contract.getselectedrow ( ll_selectedrow)
                if (ll_selectedrow == -1)
                {
                    MessageBox.Show("Please select at least one contract for report.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                il_long_parm = li_contract_num;
                ii_report_parm = 2;
                //  enable the open and export buttons
                pb_open.Enabled = true;
                pb_open.Visible = true;
                pb_export.Enabled = true;
                pb_export.Visible = true;
            }
        }

        public virtual void pb_export_clicked(object sender, EventArgs e)
        {
            //Not parsed PB function body

            // Open the correct report type
            // Report type  ( ii_report_parm)
            //		1		Town/City 
            //		2		Contract
            //		4		Any Town/City
            // check for the sort
            int SQLCode = 0;
            String SQLErrText = string.Empty;
            if (of_set_sort() == -1)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            // Set the datawindow according to the report type
            if (ii_report_parm == 1)
            {// Specific town
                dw_export.DataObject = new RPsCustListTown();
            }
            else if (ii_report_parm == 2)
            {// Contract
                dw_export.DataObject = new RPsCustListConExport();

                // TWC - 17/09/2003 - put all the contract numbers in the database in temp table
                if (of_write_contracts() == -1)
                {
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            else if (ii_report_parm == 4)
            {// Any town
                dw_export.DataObject = new RPsCustListAny();
            }
            //?dw_export.Modify ( "DataWindow.Print.Preview=Yes")
            // Retrieve the report data
            // if ii_report_type = 4 or ii_report_type = 2 then
            if (ii_report_parm == 4 || ii_report_parm == 2)
            {

                dw_export.DataObject.Retrieve();
            }
            else
            {
                dw_export.Retrieve(new object[] { il_long_parm });
            }
            // do modify for sorting and getting rid of unneeded rows
            // get handle to parent and get sort and miss parameters
            if (is_sort_string.Length > 1)
            {
                /*  dw_export.setsort ( is_sort_string)
                  dw_export.sort ( )*/
                if (!(dw_export.DataObject is RPsCustListTown))
                {
                    dw_export.DataObject.SortString = is_sort_string;
                    dw_export.Sort<PsCustListTown>();
                }
                if (!(dw_export.DataObject is RPsCustListConExport))
                {
                    dw_export.DataObject.SortString = is_sort_string;
                    dw_export.Sort<PsCustListConExport>();
                }
                if (!(dw_export.DataObject is RPsCustListAny))
                {
                    dw_export.DataObject.SortString = is_sort_string;
                    dw_export.Sort<PsCustListAny>();
                }
            }
            // disable unneeded rows
            if (cbx_recipients.Checked == false)
            {
                //dw_export.modify ( "recipients.Visible=false")
                //? dw_export.DataObject.GetControlByName("recipients").Visible = false;
                // dw_export.modify ( "recipients_t.Visible=false")
            }
            if (cbx_category.Checked == false)
            {
                dw_export.GetControlByName("categories").Visible = false;
                // dw_export.modify ( "categories_t.Visible=false")
            }
            if (cbx_kiwi.Checked == false)
            {
                dw_export.GetControlByName("kiwimail_qty").Visible = false;
                // dw_export.modify ( "kiwimail_qty_t.Visible=false")	
            }
            // prompt user
            DialogResult li_response;
            li_response = MessageBox.Show(dw_export.RowCount.ToString() + " customer records found.\r" + "Do you wish to export?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (li_response == DialogResult.No)
            {
                return;
            }
            // make a call to export
            if (of_export() == 1)
            {
                MessageBox.Show("Customer Listing file exported successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TWC - 17/09/2003 - see if the user wants to update the list printed date
                if (ii_report_parm == 2)
                {
                    if ((MessageBox.Show("Do you wish to update the customer list printed date?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        // update the database
                        /* update rd.contract set cust_list_printed = today ( *) where contract_no in (select rds_id from rds_temp) using sqlca;*/
                        RDSDataService.UpdateRdContract(ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            MessageBox.Show("Error updating cust_list_printed column\r\r" + SQLErrText, "SQL ERROR - w_cust_list_search.pb_export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return; //FAILURE;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Export Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool KeyShift = false;

        public void WCustListSearch_KeyUp(object sender, KeyEventArgs e)
        {
            KeyShift = false;
        }

        public void WCustListSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                KeyShift = true;
            }
            else
            {
                KeyShift = false;
            }
        }

        public virtual void dw_contract_clicked(object sender, EventArgs e)
        {
            //? base.clicked();
            int ll_start;
            int ll_end;
            int ll_count;
            //  disable buttons - as things have changed
            of_disable_buttons();
            /*  if (dw_contract.GetRow() != 0)*/
            if (dw_contract.GetRow() >= 0)
            {
                //? dw_contract.SelectRow(dw_contract.GetRow(), !(dw_contract.IsSelected(dw_contract.GetRow())));
            }
            if (KeyShift)//if (KeyDown(keyshift!)) {
            {
                //  only undertake the scrolling routine if the last row clicked was a real row number
                if (il_last_post_click == 0)
                {
                    il_last_post_click = dw_contract.GetRow();
                }
                else
                {
                    //  do scroll select
                    if (il_last_post_click < dw_contract.GetRow())
                    {
                        ll_start = il_last_post_click;
                        ll_end = dw_contract.GetRow();
                    }
                    else
                    {
                        ll_start = dw_contract.GetRow();
                        ll_end = il_last_post_click;
                    }
                    for (ll_count = ll_start; ll_count <= ll_end; ll_count++)
                    {
                        dw_contract.SelectRow(ll_count, true);
                    }
                    il_last_post_click = dw_contract.GetRow();
                }
            }
            else
            {
                il_last_post_click = 0;
            }
        }

        public virtual void dw_contract_doubleclicked(object sender, EventArgs e)
        {
            //?base.doubleclicked();
            //  TJB  SR4657  June05   Added
            //  If the user double-clicks a contract, trigger the search.
            //  If the user has first single-clicked the contract, the
            //  doubleclick deselects it; so set it selected just in case.
            dw_contract.SelectRow(dw_contract.GetRow() + 1, true);
            BeginInvoke(new EventHandler(pb_search_clicked));
        }

        public virtual void rb_allcontract_clicked(object sender, EventArgs e)
        {
            //  disable buttons
            of_disable_buttons();
            //  if this is clicked - disable the other fields
            //  trigger the item changed event in dw_frequency
            //  dw_frequency.triggerevent ( itemchanged!)
            dw_town.Enabled = false;
            dw_contract.Enabled = true;
            ((DConCriteria)dw_contract.DataObject).Grid.Enabled = true;
            //  dw_frequency.Enabled = false
            //  make the other 2 button face and town white
            dw_town.GetControlByName("town_list").BackColor = System.Drawing.Color.FromArgb(192, 192, 192);//dw_town.(7)DataControl["town_list"].BackColor =\'79741120\'");
            //  dw_frequency.modify ( "freq_list.BackGround.Color='79741120'")
            //  set the report type
            ii_report_type = 2;
            //  disable stuff
            of_disable_buttons();
            //  highlight all contracts
            //  select all rows
            dw_contract.SelectAllRows(true);//dw_contract.SelectRow(0, true);
        }

        #endregion
    }
}
