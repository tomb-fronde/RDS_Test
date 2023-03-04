using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using NZPostOffice.ODPS.DataControls.OdpsRep;
using NZPostOffice.ODPS.Menus;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    // TJB  RPCR_094  Mar-2015 - NEW

    public partial class WNegativePayReport : WMaster
    {
        #region Define
        public bool ib_canexit = true;

        public MOdpsReport m_report;

        #endregion

        public WNegativePayReport()
        {
            m_report = new MOdpsReport(this);
            InitializeComponent();

            dw_1.DataObject = new DwPayrunNegativepay();
        }

        public override void pfc_preopen()
        {
            DateTime? sdate, edate;

            base.pfc_preopen();
            Cursor.Current = Cursors.WaitCursor;

            sdate = DateTime.MinValue;
            edate = DateTime.MinValue;
            edate = StaticVariables.gnv_app.of_get_parameters().dateparm;

            dw_1.SuspendLayout();
            //((DwNegativepay)dw_1.DataObject).Retrieve(sdate, edate);
            ((DwPayrunNegativepay)dw_1.DataObject).Retrieve();
            dw_1.ResumeLayout();
        }

        public virtual void pfc_pagesetup()
        {
            //? return dw_1.pfc_pagesetup();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
        }

        public override void open()
        {
            base.open();
        }

        public virtual void constructor()
        {
        }

        public virtual void retrieverow()
        {
        }

        public virtual void pfc_printpreview()
        {
            return;
        }

        #region Events

        public override void resize(object sender, EventArgs args)
        {
            base.resize(this, new EventArgs());
            //dw_1.Height = this.Height - 100;
            //dw_1.Width = this.Width - 20;
        }

        public virtual void dw_1_retrieveend(object sender, EventArgs e)
        {
            ib_canexit = true;
        }

        private void cb_close_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}