using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    public partial class WSimpleSearch : WMaster
    {
        public WSimpleSearch()
        {
            InitializeComponent();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // //	Object:			cs_Template_w_Singledw
            // //	Method:			pfc_PostOpen
            // //	Description:	retrieve the datawindow stuff
            // //	HELP:	 perform the retrieval after the initial window display
            // This.SetMicroHelp  (  "Retrieving Information . . ." )
            // dw_Single.Event pfc_Retrieve  (  )
            // dw_Single.Focus( )
            // This.SetMicroHelp  (  "Ready" )
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
            //dw_search.x = 40;
            //dw_search.y = 40;
            dw_search.Location = new Point(40, 40);
            //cb_ok.x = dw_search.x + dw_search.width + 40;
            //cb_ok.y = 40;
            cb_ok.Location = new Point(dw_search.Location.X + dw_search.Width + 40, 40);
            //cb_cancel.x = cb_ok.x;
            //cb_cancel.y = cb_ok.y + cb_ok.height + 40;
            cb_cancel.Location = new Point(cb_ok.Location.X, cb_ok.Location.Y + cb_ok.Height + 40);
            this.Width = cb_ok.Location.X + cb_ok.Width + 70;
            this.Height = dw_search.Location.Y + dw_search.Height + 140;
        }

        public virtual void pfc_retrieve()
        {
            // //	Object:			cs_Template_w_Singledw.dw_Single
            // //	Method:			pfc_Retrieve
            // //	Description:	retrieve the datawindow
            // //	HELP:	you should adjust this if there is any retrieval arguments for this dw
            //? return dw_search.Retrieve();
        }

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //? parent.TriggerEvent("ue_ok");
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            //parent.TriggerEvent("pfc_close");
            this.Close();
        }
        #endregion
    }
}