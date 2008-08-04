using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using Metex.Windows;
using Metex.Core;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    public partial class WCriteriaSearch : WMaster
    {
        public WCriteriaSearch()
        {
            InitializeComponent();
        }

        public virtual void ue_search()
        {
            dw_search.DataObject.AcceptText();
            dw_results.Reset();
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

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // 	Object:			cs_Template_w_Singledw
            // 	Method:			pfc_PostOpen
            // 	Description:	retrieve the datawindow stuff

            dw_search.InsertRow(0);//dw_search.insertrow(1);
            //?dw_search.Focus();
            //? this.SetMicroHelp("Ready");
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // //	Object:			cs_Template_w_Singledw
            // //	Method:			pfc_PreOpen
            // //	Description:	start any window services desired
            // 
            // //	HELP:	first set the original size of the control before starting the resize service,
            // //	HELP:	use this if you want the datawindow to fill the screen
            // dw_Single.Resize  (  This.WorkSpaceWidth  (  ), This.WorkSpaceHeight  (  ) )
            // 
            // //	HELP:	start any window services desired
            // This.of_SetResize  (  TRUE )
            // 
            //  TJB SR4639 Dec 2004
            //  Disabled all this stuff so windows can be sized via GUI
            //  Especially for w_invoice_search window
            /* 
            dw_search.x = 40
            dw_search.y = 40
            cb_search.x = dw_search.x + dw_search.width + 40
            cb_search.y = 40
            dw_results.x = 40
            dw_results.y = dw_search.y +dw_search.height + 40
            dw_results.width = dw_search.width
            cb_open.x = dw_results.x + dw_results.width + 40
            cb_open.y = dw_results.y
            cb_cancel.x = cb_open.x
            cb_cancel.y = cb_open.y + cb_open.height + 40
            this.width = cb_search.x + cb_search.width + 70
            this.height = dw_results.y + dw_results.height + 320
             */
        }

        public virtual void pfc_retrieve()
        {
            // //	Object:			cs_Template_w_Singledw.dw_Single
            // //	Method:			pfc_Retrieve
            // //	Description:	retrieve the datawindow
            // //	HELP:	you should adjust this if there is any retrieval arguments for this dw
            //? return dw_search.Retrieve();
        }

        public virtual void constructor()
        {
            // 	Object:			cs_w_Template_w_Singledw.dw_Single
            // 	Method:			Constructor
            // 	Description:	start the specific services for the datawindow
            // 	HELP:	make the connection to the database
            //?         dw_results.of_settransobject(StaticVariables.sqlca);
            //?         ib_rmbmenu = false;
            // 	HELP:	start the services for the datawindow
            // 	HELP:	for certain services, you can also disallow updates by calling of_SetUpdateable  (  FALSE )
            // This.of_SetBase  (  TRUE )
            // This.of_SetAutoInstantiate  (  TRUE )
            // This.of_SetBusinessRule  (  TRUE, "YOURBUSINESSRULE", "HANDLENAME" )
            // This.of_SetColorManager  (  TRUE )      			//	this is autoinstantiated if allowed
            // This.of_SetColumnManager  (  TRUE )				//	this is autoinstantiated if allowed
            // This.of_SetDate  (  TRUE )							// this is autoinstantiated if allowed
            // This.of_SetDelete  (  TRUE )
            // This.of_SetDropDownFilter  (  TRUE )
            // This.of_SetDropDownSearch  (  TRUE )			//	this is autoinstantiated if allowed
            // This.of_SetDuplicate  (  TRUE )
            // This.of_SetDynamicCreate  (  TRUE )
            // This.of_SetFilter  (  TRUE )
            // This.of_SetFind  (  TRUE )
            // This.of_SetGenerateUniqueNbr  (  TRUE ) 		//	this is autoinstantiated if allowed
            // This.of_SetMultiTable  (  TRUE )					// this is autoinstantiated if allowed
            // This.of_SetPrintPreview  (  TRUE )
            // This.of_SetQueryMode  (  TRUE )
            // This.of_SetReport  (  TRUE )
            // This.of_SetReqColumn  (  TRUE )
            //?         dw_results.of_setrowmanager(true);
            //?         dw_results.of_setrowselect(true);
            // This.of_SetSort  (  TRUE )
            // This.of_SetValidation  (  TRUE )
            //? dw_results.of_setupdateable(false);
        }

        #region Events
        public virtual void cb_search_clicked(object sender, EventArgs e)
        {
            ue_search();// parent.TriggerEvent("ue_search");
        }

        public virtual void cb_open_clicked(object sender, EventArgs e)
        {
            //? parent.TriggerEvent("ue_open");
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            //parent.TriggerEvent("pfc_close");
            this.Close();
        }
        #endregion
    }
}