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
using System.Reflection;
using NZPostOffice.RDS.Entity.Ruralsec;
using Metex.Core;
using NZPostOffice.Entity;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    // TJB  RPCR_057  Jan-2014
    // Added bAllowAll parameter to wf_gosearch()

    public partial class WGenericReportSearch : WAncestorWindow
    {
        #region Define
        // string isDataWindow 
        public string isReportWindow = "w_generic_report_preview";
        #endregion

        public WGenericReportSearch()
        {
            InitializeComponent();

            this.dw_criteria.DataObject = new DReportGenericCriteria();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_results.DataObject = new DReportGenericResults();
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
            dw_criteria.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_criteria_itemfocuschanged);
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);

            ((DReportGenericResults)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            //jlwang:end
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            string ls_Parm;
            DataUserControl dwChild;
            int? lNull;
            Dictionary<int, string> sNull = new Dictionary<int, string>();
            ls_Parm = StaticMessage.StringParm;
            if (ls_Parm != null && ls_Parm.Length > 0)
            {
                this.Text = ls_Parm;
            }
            lNull = null;
            isDataWindow = StaticVariables.gnv_app.of_get_parameters().stringparm;
            // dw_criteria.Modify("st_report.text=\'" + StaticMessage.StringParm + '\'');
            if (dw_criteria.GetControlByName("st_report") != null)
            {
                dw_criteria.DataObject.GetControlByName("st_report").Text = StaticMessage.StringParm;
            }
            if (of_findcolumn("RegionId"))
            {
                // if (dw_criteria.Describe("region_id.dddw.Name") != '?') 
                if (dw_criteria.GetControlByName("region_id") is DataEntityCombo)
                {
                    dwChild = dw_criteria.GetChild("region_id");
                    dwChild.Retrieve();
                    if (StaticVariables.gnv_app.of_get_numregions() == dwChild.RowCount - 1)  //dwChild has a blank row
                    {
                        dwChild.FilterString = "0";//dwChild.FilterString = "region_id > 0";
                        dwChild.FilterOnce<DddwRegions>(dwchild_filter);
                        insertRow(dwChild, 0);
                        dwChild.SetValue(0, "region_id", lNull);
                        dwChild.SetValue(0, "rgn_name", "<All Regions>");
                        ((Metex.Windows.DataEntityCombo)(dw_criteria.GetControlByName("region_id"))).SelectedIndex = 0;
                    }
                    insertRow(dwChild, 0);
                    dwChild.DeleteItemAt(0);
                }
            }
            if (of_findcolumn("RegionIdRo"))
            {
                // if (dw_criteria.Describe("region_id_ro.dddw.Name") != '?') {
                if (dw_criteria.GetControlByName("region_id_ro") is DataEntityCombo)
                {
                    dwChild = dw_criteria.GetChild("region_id_ro");
                    dwChild.Retrieve();
                    dwChild.FilterString = "0";//dwChild.FilterString = "region_id > 0";
                    dwChild.FilterOnce<DddwRegions>(dwchild_filter);
                    insertRow(dwChild, 0);
                    dwChild.SetValue(0, "region_id", lNull);
                    dwChild.SetValue(0, "rgn_name", "<All Regions>");
                    ((Metex.Windows.DataEntityCombo)(dw_criteria.GetControlByName("region_id_ro"))).SelectedIndex = 0;
                    insertRow(dwChild, 0);
                    dwChild.DeleteItemAt(0);
                }
            }
            if (of_findcolumn("RgCode"))
            {
                //if (dw_criteria.Describe("rg_code.dddw.Name") != '?') {
                if (dw_criteria.GetControlByName("rg_code") is DataEntityCombo)
                {
                    dwChild = dw_criteria.GetChild("rg_code");
                    dwChild.Retrieve();
                    // insertRow(dwChild, 0);
                    insertRow(dwChild, 0);
                    dwChild.SetValue(0, "rg_code", lNull);
                    dwChild.SetValue(0, "rg_description", "<All Renewal Groups>");
                    //mkwang --- add 08/01/2007
                    insertRow(dwChild, 0);
                    dwChild.DeleteItemAt(0);
                    ((Metex.Windows.DataEntityCombo)(dw_criteria.GetControlByName("rg_code"))).SelectedIndex = 0;
                }
            }
            if (of_findcolumn("SfKey"))
            {
                // if (dw_criteria.Describe("sf_key.dddw.Name") != '?') {
                if (dw_criteria.GetControlByName("sf_key") is DataEntityCombo)
                {
                    dwChild = dw_criteria.GetChild("sf_key");
                    dwChild.Retrieve();
                    insertRow(dwChild, 0);
                    dwChild.SetValue(1, "sf_key", lNull);
                    dwChild.SetValue(1, "sf_description", "<All Frequencies>");
                    //mkwang --- add 08/02/2007
                    insertRow(dwChild, 0);
                    dwChild.DeleteItemAt(0);
                    //((Metex.Windows.DataEntityCombo)(dw_criteria.GetControlByName("sf_key"))).SelectedIndex = 0;
                }
            }
            if (of_findcolumn("CtKey"))
            {
                // if (dw_criteria.Describe("ct_key.dddw.Name") != '?') {
                if (dw_criteria.GetControlByName("ct_key") is DataEntityCombo)
                {
                    Metex.Windows.DataUserControl lds_user_Contract_Types;
                    int ll_Row;
                    lds_user_Contract_Types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
                    dwChild = dw_criteria.GetChild("ct_key");
                    dwChild.Reset();

                    // lds_user_Contract_Types.RowCopy<DddwContractTypes>(0, lds_user_Contract_Types.RowCount - 1, dwChild);
                    for (int i = 0; i < lds_user_Contract_Types.RowCount; i++)
                    {
                        addRow(dwChild);// dwChild.AddItem<DddwContractTypes>(new DddwContractTypes());
                        dwChild.SetValue(i, "contract_type", lds_user_Contract_Types.GetValue(i, "contract_type"));
                        dwChild.SetValue(i, "ct_key", lds_user_Contract_Types.GetValue(i, "ct_key"));
                        dwChild.SetValue(i, "ct_rd_ref_mandatory", lds_user_Contract_Types.GetValue(i, "ct_rd_ref_mandatory"));
                    }
                    addRow(dwChild);

                    if (lds_user_Contract_Types.RowCount == StaticVariables.gnv_app.of_gettotalcontracttypes())
                    {
                        insertRow(dwChild, 0);
                        dwChild.SetValue(0, "ct_key", lNull);
                        dwChild.SetValue(0, "contract_type", "<All Contract Types>");
                        //jlwang
                        insertRow(dwChild, 0);
                        dwChild.DeleteItemAt(0);
                    }
                    ll_Row = dwChild.Find("ct_key", 1);
                    if (ll_Row > 0)
                    {
                        BeginInvoke(new InvokeDelegate(dwCriteriaSetValue));
                    }
                }
            }
            dw_criteria.InsertRow(0);
            //? dw_results.SetRowFocusIndicator(focusrect);
            dw_criteria.URdsDw_GetFocus(null, null);
            dw_results.URdsDw_GetFocus(null, null);
        }
       
        public virtual void dw_criteria_constructor()
        {
            if (this.DesignMode)
            {
                return;
            }
            dw_criteria.of_SetUpdateable(false);
        }
  
        public virtual void dw_results_constructor()
        {
            if (this.DesignMode)
            {
                return;
            }
            dw_results.of_SetUpdateable(false);
            dw_results.of_SetRowSelect(true);
            dw_results.of_SetStyle(1);//.inv_rowselect.of_SetStyle(1);
        }

        #region Methods
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

        private void addRow(DataUserControl dw)
        {
            string typeName = dw.GetType().FullName.Replace("DataControls", "Entity");
            typeName = typeName.Replace(".D", ".");
            string st = dw.GetType().Assembly.ToString();
            st = st.Replace("DataControls", "Entity");

            System.Reflection.Assembly dll = System.Reflection.Assembly.Load(st);
            object obj = Activator.CreateInstance(dll.GetType(typeName));
            dw.BindingSource.List.Add((EntityBase)obj);
        }

        public delegate void InvokeDelegate();
        public virtual void dwCriteriaSetValue()
        {
            dw_criteria.SetValue(0, "ct_key", 1);
            //? dw_criteria.SetValue(0, "rg_code", null);
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        private bool dwchild_filter<T>(T t) where T : DddwRegions
        {
            if (t.RegionId == null || t.RegionId.GetValueOrDefault() <= System.Convert.ToInt32(dw_criteria.GetChild("region_id").FilterString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            string ls_Parm = string.Empty;
            int? lNull;
            ls_Parm = StaticMessage.StringParm;
            if (ls_Parm != null && ls_Parm.Length > 0)
            {
                this.Text = ls_Parm;
            }
            lNull = null;
            isDataWindow = StaticVariables.gnv_app.of_get_parameters().stringparm;
            // dw_criteria.Modify("st_report.text=\'" + StaticMessage.StringParm + '\'');
            if (dw_criteria.GetControlByName("st_report") != null)
            {
                dw_criteria.GetControlByName("st_report").Text = StaticMessage.StringParm;
            }
            this.of_set_componentname(StaticVariables.gnv_app.of_get_componentopened());
        }

        public virtual int wf_getoutlet()
        {
            string sOutlet;
            int? lregionx;
            //?dw_criteria.Modify("outlet_bmp.filename=\'..\\bitmaps\\pcklstdn.bmp\'");
            dw_criteria.GetControlByName("outlet_picklist").Focus();
            dw_criteria.GetControlByName("outlet_bmp").Focus();
            sOutlet = dw_criteria.GetValue<string>(0, "o_name");
            if (sOutlet == "<All Outlets>")
            {
                sOutlet = "";
            }
            lregionx = dw_criteria.GetValue<int?>(0, "region_id");
            StaticVariables.gnv_app.of_get_parameters().integerparm = null;
            StaticVariables.gnv_app.of_get_parameters().longparm = null;
            StaticVariables.gnv_app.of_get_parameters().integerparm = lregionx;
            StaticVariables.gnv_app.of_set_componenttoopen(this.of_get_componentname());
            Cursor.Current = Cursors.WaitCursor;
            //OpenWithParm(w_qs_outlet, sOutlet);
            StaticMessage.StringParm = sOutlet;
            WQsOutlet w_qs_outlet = new WQsOutlet();
            w_qs_outlet.ShowDialog();
            // opensheetwithParm ( w_qs_outlet,sOutlet, w_main_mdi, 0, originaL!)
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                dw_criteria.SetValue(0, "outlet_id", StaticVariables.gnv_app.of_get_parameters().longparm);
                dw_criteria.SetValue(0, "region_id", StaticVariables.gnv_app.of_get_parameters().integerparm);
                dw_criteria.SetValue(0, "o_name", StaticVariables.gnv_app.of_get_parameters().stringparm);

                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            //? dw_criteria.Modify("outlet_bmp.filename=\'..\\bitmaps\\pcklstup.bmp\'");
            return 0;
        }

        // TJB  RPCR_057  Jan-2014
        // Added bAllowAll parameter
        // - Make <All Contracts> in results optional
        //   (set to false in WGenericReportSearchWithDate and ...WithMthYr)
        public virtual int wf_gosearch(bool bAllowAll)
        {
            int? lRegionId;
            int? lOutletId;
            int? lRgCode;
            int? lSfKey;
            int? lCtKey;
            int? lNull;
            dw_criteria.AcceptText();

            lRegionId = dw_criteria.DataObject.GetValue<int?>(0, "region_id");
            lOutletId = dw_criteria.GetValue<int?>(0, "outlet_id");
            lRgCode = dw_criteria.GetValue<int?>(0, "rg_code");
            lSfKey = dw_criteria.GetValue<int?>(0, "sf_key");
            lCtKey = dw_criteria.GetValue<int?>(0, "ct_key");

            ((DReportGenericResults)dw_results.DataObject).Retrieve(lRegionId, lOutletId, lRgCode, lSfKey, lCtKey);
            if (dw_results.RowCount == 0)
            {
                MessageBox.Show("Search Unsuccessful", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_criteria.Focus();
            }
            else if (bAllowAll)
            {
                dw_results.InsertItem<ReportGenericResults>(0);
                lNull = null;
                dw_results.SetValue(0, "Con_title", "<All Contracts>");
                dw_results.SetValue(0, "contract_no", 0);
                dw_results.SetValue(0, "con_active_sequence", 0);
                dw_results.SetCurrent(0);
                ((Metex.Windows.DataEntityGrid)dw_results.GetControlByName("grid")).Rows[0].Selected = false;
                dw_results.Focus();
            }
            return 1;
        }

        public virtual bool of_findcolumn(string as_Columnname)
        {
            string sObjectList = string.Empty;
            string sObject = string.Empty;
            string sTab = "~";
            /*sObjectList = dw_criteria.Describe("Datawindow.Objects");
            while ( sObjectList.Length > 0) 
            {
               if (Pos(sObjectList, sTab) > 0) 
                {
                    sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
                    sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
                }
                else 
                {
                    sObject = sObjectList;
                    sObjectList = "";
                }
                if (as_Columnname.Trim().ToUpper() == sObject.Trim().ToUpper())
                {
                    return true;
                }
            }*/

            //string typeName = dw_criteria.DataObject.GetType().FullName.Replace("DataControls", "Entity");
            //typeName = typeName.Replace(".D", ".");

            //string st = dw_criteria.DataObject.GetType().Assembly.ToString();
            //st = st.Replace("DataControls", "Entity");

            //System.Reflection.Assembly dll = System.Reflection.Assembly.Load(st);
            //PropertyInfo[] l_temp = dll.GetType(typeName).GetProperties();

            //foreach (PropertyInfo var in l_temp)
            //{
            //    Console.WriteLine(var.Name);
            //    if (var.Name == as_Columnname)
            //    {
            //        return true;
            //    }
            //}
            string typeName = dw_criteria.DataObject.GetType().FullName.Replace("DataControls", "Entity");

            foreach (Control var in dw_criteria.DataObject.Controls)
            {
                if (StaticFunctions.migrateName(var.Name) == StaticFunctions.migrateName(as_Columnname))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual int of_get_outlet(int ai_region, int al_outlet, string as_name)
        {
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                dw_criteria.SetValue(0, "outlet_id", al_outlet);
                dw_criteria.SetValue(0, "region_id", ai_region);
                dw_criteria.SetValue(0, "o_name", as_name);
            }
            //? dw_criteria.Modify("outlet_bmp.filename=\'..\\bitmaps\\pcklstup.bmp\'");
            return 1;
        }

        public virtual void ue_deleteitem()
        {
            //?base.ue_deleteitem();
            int? lNull;
            lNull = null;
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyDelete))
            {
                if (dw_criteria.GetColumnName() == "o_name")
                {
                    dw_criteria.GetControlByName(dw_criteria.GetColumnName()).Text = "<<All Outlets>";
                    dw_criteria.SetValue(0, "outlet_id", lNull);
                    //? return 1;
                }
            }
        }
        #endregion

        #region Events
        public virtual void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            //  base.itemchanged();
            dw_criteria.URdsDw_Itemchanged(sender, e);
            string sOutlet;
            int? lOutletId;
            int lActionCode = 0;
            if (dw_criteria.GetColumnName() == "outlet_picklist")
            {
                wf_getoutlet();
            }
            else if (dw_criteria.GetColumnName() == "o_name")
            {
                sOutlet = dw_criteria.GetControlByName(dw_criteria.GetColumnName()).Text;
                if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                {
                    if (sOutlet == "<All Outlets>")
                    {
                        lOutletId = null;
                    }
                    else
                    {
                        // select outlet_id  into :lOutletId  from outlet  where o_name = :sOutlet;
                        int SQLCode = 0;
                        lOutletId = RDSDataService.GetOutlet(sOutlet, ref SQLCode);
                        if (SQLCode != 0)
                        {
                            lOutletId = null;
                            dw_criteria.SetValue(0, "o_name", "<All Outlets>");
                            lActionCode = 2;
                        }
                    }
                }
                else
                {
                    lOutletId = null;
                    dw_criteria.SetValue(0, "o_name", "<All Outlets>");
                    lActionCode = 2;
                }
                dw_criteria.SetValue(dw_criteria.GetRow(), "outlet_id", lOutletId);
            }
            //?return lActionCode;
        }

        public virtual void dw_criteria_itemfocuschanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //?URdsDw.itemfocuschanged();
            if (dw_criteria.GetColumnName() == "outlet_picklist")
            {
                //?  dw_criteria.Modify("outlet_rect.pen.color=0");
            }
            else
            {
                //? dw_criteria.Modify("outlet_rect.pen.color=8421504");
            }
        }

        public virtual void dw_criteria_getfocus(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //?URdsDw.getfocus();
            //  pb_open.Default = false;
            //pb_search.Default = true;
            this.AcceptButton = pb_search;
        }

        public virtual void dw_criteria_clicked(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //? URdsDw.clicked();
            string sObjectAtPointer;
            string sOutlet;
            // sObjectAtPointer = dw_criteria.GetObjectAtPointer();

            sObjectAtPointer = "outlet_bmp"; //dw_criteria.DataObject.GetColumnName();
            // if (Left(sObjectAtPointer, 10) == "outlet_bmp") 
            if ((sObjectAtPointer != null) && (sObjectAtPointer.Length >= 10) && sObjectAtPointer.Substring(0, 10) == "outlet_bmp")
            {
                wf_getoutlet();
            }
        }

        public virtual void dw_results_clicked(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            //? base.doubleclicked();
            //  TJB  SR4684  June06   Added
            //  If the user double-clicks a contract, trigger the search.
            //  If the user has first single-clicked the contract, the
            //  doubleclick deselects it; so set it selected just in case.
            int row = dw_results.GetRow();
            dw_results.SelectRow(row + 1, true);
            BeginInvoke(new EventHandler(pb_open_clicked));
        }

        public virtual void dw_results_getfocus(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //? URdsDw.getfocus();
            // pb_search.Default = false;
            // pb_open.Default = true;
            this.AcceptButton = pb_open;
        }

        public virtual void pb_search_clicked(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            wf_gosearch(true);
        }

        public virtual void pb_open_clicked(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            string sTitle;
            WGenericReportPreview wNewWindow;
            Form lw_FindWindow;
            if (dw_results.GetSelectedRow(0) >= 0)
            {
                //  sTitle = dw_criteria.Describe("st_report.text");
                sTitle = dw_criteria.GetControlByName("st_report").Text;
                StaticVariables.gnv_app.of_get_parameters().stringparm = isDataWindow;
                //StaticVariables.gnv_app.of_get_parameters().dwparm = dw_results.DataObject;
                StaticVariables.window = dw_results;
                Cursor.Current = Cursors.WaitCursor;
                // OpenSheetWithParm(wNewWindow, sTitle, w_main_mdi, 0, original);
                //StaticMessage.PowerObjectParm = sTitle;
                wNewWindow = new WGenericReportPreview();
                wNewWindow.MdiParent = StaticVariables.MainMDI;
                wNewWindow.Show();
            }
        }
        #endregion
    }
}
