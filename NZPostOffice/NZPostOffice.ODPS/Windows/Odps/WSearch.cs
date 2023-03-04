using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class WSearch : WMaster
    {
        public WSearch()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            String TestExpr = StaticMessage.StringParm;
            if (TestExpr == "CONTRACT SEARCH")
            {
                of_set_search("CONTRACT SEARCH");
                of_set_search_dataobject("d_contract_search");
                of_set_result_dataobject("d_contract_listing");
                of_set_dddw_column("region_id");
                of_set_column("region_id", 0);
                of_set_column("contract_no", 0);
                of_set_column("con_title", "");
                of_set_column("con_old_mail_service_no", "");
                of_set_column("con_last_work_msr_1", "1900-01-01");
                of_set_column("con_last_work_msr_2", DateTime.Now);
                of_set_column("con_last_service_review_1", "1900-01-01");
                of_set_column("con_last_service_review_2", DateTime.Now);
                of_set_column("con_last_delivery_check_1", "1900-01-01");
                of_set_column("con_last_delivery_check_2", DateTime.Now);
                of_set_window_to_open("TESTwindow");
                of_set_id("TEST 01");
            }
            else if (TestExpr == "CONTRACTOR SEARCH")
            {
            }
            else
            {
                return;
            }
            //? dw_search.insertrow(1);
            //? dw_result.of_SetRowSelect(true);
        }

        #region Methods
        public virtual void of_set_search(string a_search)
        {
            istr_search_details.search = a_search;
            return;
        }

        public virtual void of_set_search_dataobject(string a_search_dataobject)
        {
            istr_search_details.search_dataobject = a_search_dataobject;
            //? dw_search.DataObject = a_search_dataobject;
            return;
        }

        public virtual void of_set_result_dataobject(string a_result_dataobject)
        {
            istr_search_details.result_dataobject = a_result_dataobject;
            //? dw_result.DataObject = a_result_dataobject;
            return;
        }

        public virtual void of_set_id(string a_id)
        {
            st_id.Text = a_id;
        }

        public virtual void of_set_window_to_open(string a_window_name)
        {
            istr_search_details.window_to_open = a_window_name;
            return;
        }

        public virtual void of_search()
        {
            //string ls_coltype;
            //int li_i;
            //int li_cols;
            //int li_dummy;
            //Cl_anyArray lany_args = new Cl_anyArray();
            //li_cols = istr_search_details.columns.Length;//.UpperBound;
            //for (li_i = 1; li_i <= li_cols; li_i++)
            //{
            //    ls_coltype = dw_search.Describe(istr_search_details.columns[li_i] + ".ColType");
            //    li_dummy = lany_args.UpperBound + 1;
            //    // PowerBuilder 'Choose Case' statement converted into 'if' statement
            //    string TestExpr = Upper(ls_coltype);
            //    if (TestExpr == "DATE")
            //    {
            //        lany_args[li_dummy] = dw_search.GetItemDateTime(1, istr_search_details.columns[li_i]).Date;
            //        if (IsNull(lany_args[li_dummy]))
            //        {
            //            lany_args[li_dummy] = System.Convert.ToDateTime(istr_search_details.columns_default[li_dummy]);
            //        }
            //    }
            //    else if (TestExpr == "DATETIME")
            //    {
            //        lany_args[li_dummy] = dw_search.getitemdatetime(1, istr_search_details.columns[li_i]);
            //        if (IsNull(lany_args[li_dummy]))
            //        {
            //            lany_args[li_dummy] = System.Convert.ToDateTime(istr_search_details.columns_default[li_dummy]);
            //        }
            //    }
            //    else if (TestExpr == "DECIMAL")
            //    {
            //        lany_args[li_dummy] = dw_search.getitemSystem.Conver.ToDouble(1, istr_search_details.columns[li_i]);
            //        if (IsNull(lany_args[li_dummy]))
            //        {
            //            lany_args[li_dummy] = Dec(istr_search_details.columns_default[li_dummy]);
            //        }
            //    }
            //    else if (TestExpr == "NUMBER")
            //    {
            //        lany_args[li_dummy] = dw_search.getitemnumber(1, istr_search_details.columns[li_i]);
            //        if (IsNull(lany_args[li_dummy]))
            //        {
            //            lany_args[li_dummy] = Metex.Common.Convert.ToInt32(istr_search_details.columns_default[li_dummy]);
            //        }
            //    }
            //    else if (TestExpr == "TIME")
            //    {
            //        lany_args[li_dummy] = dw_search.GetItemDateTime(1, istr_search_details.columns[li_i]).TimeOfDay;
            //        if (IsNull(lany_args[li_dummy]))
            //        {
            //            lany_args[li_dummy] = Time(istr_search_details.columns_default[li_dummy]);
            //        }
            //    }
            //    else
            //    {
            //        lany_args[li_dummy] = dw_search.getitemstring(1, istr_search_details.columns[li_i]);
            //        if (IsNull(lany_args[li_dummy]))
            //        {
            //            lany_args[li_dummy] = istr_search_details.columns_default[li_dummy];
            //        }
            //    }
            //}
            //dw_result.retrieve(lany_args[1], lany_args[2], lany_args[3], lany_args[4], lany_args[5], lany_args[6], lany_args[7], lany_args[8], lany_args[9], lany_args[10]);
            //return;
        }

        public virtual void of_set_column(string a_column_name, object a_default_value)
        {
            int ll_cols;
            ll_cols = istr_search_details.columns.Length;//.UpperBound;
            istr_search_details.columns[ll_cols + 1] = a_column_name;
            istr_search_details.columns_default[ll_cols + 1] = a_default_value.ToString();
            return;
        }

        public virtual void of_set_dddw_column(string a_column_name)
        {
            //DataControlBuilder ldwc_child;
            int li_rtncode = -1;
            int ll_cols;
            //? li_rtncode = dw_search.GetChild(a_column_name, ldwc_child);

            if (li_rtncode == -1)
            {
                MessageBox.Show("Not a DataWindowChild", "Error in W_SEARCH", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //? ldwc_child.Retrieve();
            return;
        }
        #endregion

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            of_search();
        }

        public virtual void constructor()
        {
            //? base.constructor();
            //  Set the transaction object for the datawindow and turn off the rmb
            //dw_search.of_settransobject(StaticVariables.sqlca);
            //? ib_rmbmenu = false;
        }

        //public virtual void dw_search_sqlpreview(object sender, SqlEventArgs e)
        //{
        //    base.sqlpreview();
        //    MessageBox.Show(sqlsyntax, "TEST");
        //}
    }

    public struct str_search_details
    {
        public string[] dddw_columns;
        public string[] window_param;
        public string window_to_open;
        public string[] columns_default;
        public string[] columns;
        public string result_dataobject;
        public string search_dataobject;
        public string search;
    }
}