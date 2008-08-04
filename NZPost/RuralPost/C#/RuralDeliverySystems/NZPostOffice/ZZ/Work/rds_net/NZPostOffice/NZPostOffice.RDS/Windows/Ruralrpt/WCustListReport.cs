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

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustListReport : WGenericReportPreview
    {
        #region Define
        public int? il_id;

        public int? ii_report_parm;

        #endregion

        public WCustListReport()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            string ls_header;
            int? ll_id;
            int? li_report_type;
            //  int 		li_freq
            DateTime tnow;
            tnow = DateTime.Now;
            Cursor.Current = Cursors.WaitCursor;
            //  The type of report this will be decided by the
            //  passed IntegerParm value
            // 		1		Town/City 
            // 		2		Contract
            // 		4		Any Town/City
            ll_id = StaticVariables.gnv_app.of_get_parameters().longparm;
            ls_header = StaticVariables.gnv_app.of_get_parameters().stringparm;
            li_report_type = StaticVariables.gnv_app.of_get_parameters().integerparm;
            ii_report_parm = li_report_type;
            //  li_freq = gnv_App.of_Get_Parameters ( ).doubleParm
            il_id = ll_id;
            //  set the correct datawindow and do retrieve
            if (li_report_type == 1)
            {
                dw_report.DataObject = new RPsCustListTown();
                //  this.of_cleave_seq ( )
            }
            else if (li_report_type == 2)
            {
                dw_report.DataObject = new RPsCustListCon();
            }
            else if (li_report_type == 4)
            {
                dw_report.DataObject = new RPsCustListAny();
                //  this.of_cleave_seq ( )
            }
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            if (li_report_type == 4)
            {
                ((RPsCustListAny)dw_report.DataObject).Retrieve();
            }
            else
            {
                dw_report.Retrieve(new object[] { ll_id }); //?((RPsCustListCon)dw_report.DataObject).Retrieve(ll_id);
            }
            //  do modify to introduce the string for the contract details
            //?dw_report.GetControlByName("st_header_text").Text = ls_header;// dw_report.Object.st_header_text.text = ls_header;
            //? SetMicroHelp("Retrieve time: " + String(SecondsAfter(tnow, Now())) + "second ( s)");
            //  check to see if there are any rows - set message if none
            if (dw_report.RowCount == 0)
            {
                if (!(dw_report.DataObject is RPsCustListTown))
                {
                    dw_report.InsertItem<PsCustListTown>(0);
                    dw_report.GetItem<PsCustListTown>(0).Locality = "No Records Found";
                }
                if (!(dw_report.DataObject is RPsCustListCon))
                {
                    dw_report.InsertItem<PsCustListCon>(0);
                    dw_report.GetItem<PsCustListCon>(0).Locality = "No Records Found";
                }
                if (!(dw_report.DataObject is RPsCustListAny))
                {
                    dw_report.InsertItem<PsCustListAny>(0);
                    dw_report.GetItem<PsCustListAny>(0).Locality = "No Records Found";
                }
            }
            else
            {
                //  do modify for sorting and getting rid of unneeded rows
                //  get handle to parent and get sort and miss parameters
                int ll_t1 = 0;
                string ls_temp_sort;
                ls_temp_sort = StaticVariables.gs_cust_list_sort;
                ll_t1 = ls_temp_sort.IndexOf("contract_no A,");
                if (ll_t1 > 0)
                {
                    //  cleave off any contract component of the string
                    //ls_temp_sort = Trim(Replace(ls_temp_sort, ll_t1, 14, ' '));
                    if (ls_temp_sort.Length > ll_t1 + 14)
                    {
                        ls_temp_sort = ((string)(ls_temp_sort.Substring(0, ll_t1 + 1) + " " + ls_temp_sort.Substring(ll_t1 + 1 + 14))).Trim();
                    }
                    else
                    {
                        ls_temp_sort = ((string)(ls_temp_sort.Substring(0, ll_t1 + 1) + " ")).Trim();
                    }
                }
                /*  ----------------------- Debugging ----------------------- //
                messagebox ( 'w_cust_list_report.open', & 'Sort string:  ( '+string ( lenw ( ls_temp_sort))+')~r' & +mid ( ls_temp_sort,1,50)                    +'~r'  & +mid ( ls_temp_sort,51)                      +'~r'  & +'Report type = '+string ( li_report_type)   +'~r'  & +'Report object = '+dw_report.DataObject      )

                // ---------------------------------------------------------  */
                if (!(dw_report.DataObject is RPsCustListTown))
                {
                    // dw_report.setsort(ls_temp_sort);
                    dw_report.DataObject.SortString = ls_temp_sort;
                    //dw_report.sort();
                    dw_report.Sort<PsCustListTown>();
                }
                if (!(dw_report.DataObject is RPsCustListCon))
                {
                    // dw_report.setsort(ls_temp_sort);
                    dw_report.DataObject.SortString = ls_temp_sort;
                    //dw_report.sort();
                    dw_report.Sort<PsCustListCon>();
                }
                if (!(dw_report.DataObject is RPsCustListAny))
                {
                    // dw_report.setsort(ls_temp_sort);
                    dw_report.DataObject.SortString = ls_temp_sort;
                    //dw_report.sort();
                    dw_report.Sort<PsCustListAny>();
                }
                //  disable unneeded rows
                if (StaticVariables.gb_cust_list_recip == false)
                {
                    if (dw_report.GetControlByName("recipients_t") != null)
                    {
                        dw_report.GetControlByName("recipients_t").Visible = false;
                    }
                    if (dw_report.GetControlByName("recipients") != null)
                    {
                        dw_report.GetControlByName("recipients").Visible = false;
                    }
                    //?dw_report.modify("recipients.height.autosize=no");
                }
                // if gb_cust_list_seq = false then
                // 	dw_report.modify ( "seq_no_t.visible=false")
                // 	dw_report.modify ( "seq_no.visible=false")
                // end if
                if (StaticVariables.gb_cust_list_cat == false)
                {
                    if (dw_report.GetControlByName("categories_t") != null)
                    {
                        dw_report.GetControlByName("categories_t").Visible = false;
                    }
                    if (dw_report.GetControlByName("categories") != null)
                    {
                        dw_report.GetControlByName("categories").Visible = false;
                    }
                }
                if (StaticVariables.gb_cust_list_kiwi == false)
                {
                    //  dw_report.modify("kiwimail_qty_t.visible=false");
                    if (dw_report.GetControlByName("kiwimail_qty_t") != null)
                    {
                        dw_report.GetControlByName("kiwimail_qty_t").Visible = false;
                    }
                    //  dw_report.modify("kiwimail_qty.visible=false");
                    if (dw_report.GetControlByName("kiwimail_qty") != null)
                    {
                        dw_report.GetControlByName("kiwimail_qty").Visible = false;
                    }
                }
            }
            //  TJB  SR4683  Aug 2006
            //  Set the BooleanParm to the ib_abort value to signal that
            //  the user wants to abort generating further reports.
            //StaticVariables.gnv_app.of_get_parameters().booleanparm = ib_Abort; // modify wjtang SR4703
        }

        public override void activate()
        {
            //? base.activate();
            if (m_sheet != null)
            {
                m_sheet._m_contractors.Visible = false;
                m_sheet._m_contracts.Visible = false;
                m_sheet._m_addresses.Visible = false;
            }
        }

        public virtual int pfc_print()
        {
            //?base.pfc_print();
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            //  TJB  SR4657  June05
            //  If the list has been printed, update the list printed date
            //  Only update if the report was produced by contract
            if (ii_report_parm == 2)
            {
                //  Ask user to confirm they want the cust_list_printed value updated
                if (MessageBox.Show("Do you wish to update the customer list printed date?", "Question", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    //  Update the contract's cust_list_printed value
                    // UPDATE contract set cust_list_printed = today() where contract_no = :il_id using SQLCA;
                    RDSDataService.UpdateCustListPrinted(il_id, ref SQLCode, ref SQLErrText);
                    if (SQLCode < 0)
                    {
                        string ls_id;
                        //? rollback;
                        if (il_id == null)
                        {
                            ls_id = "NULL";
                        }
                        else
                        {
                            ls_id = il_id.ToString();
                        }
                        MessageBox.Show("Error updating cust_list_printed column~r" + "Contract No = " + ls_id + "~r~r" + SQLErrText, "ERROR - w_cust_list_report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return FAILURE;
                    }
                    else
                    {
                        //?  commit;
                    }
                }
            }
            return SUCCESS;
        }

        #region Methods
        public virtual int of_cleave_recipients()
        {
            //  this function will get rid of the recipients column
            dw_report.GetControlByName("recipients").Visible = false;
            return 1;
        }

        public virtual int of_cleave_seq()
        {
            //  dw_report.modify ( "seq_no.visible=false")
            return 1;
        }

        public virtual int of_cleave_category()
        {
            dw_report.GetControlByName("category_v").Visible = false;
            return 1;
        }

        public virtual int of_cleave_kiwi()
        {
            dw_report.GetControlByName("kiwimail_qty").Visible = false;
            return 1;
        }
        #endregion
    }
}