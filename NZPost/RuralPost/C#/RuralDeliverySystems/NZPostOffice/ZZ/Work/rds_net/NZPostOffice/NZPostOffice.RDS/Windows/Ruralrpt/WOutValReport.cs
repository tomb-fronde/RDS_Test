using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WOutValReport : WGenericReportPreview
    {
        public WOutValReport()
        {
            InitializeComponent();
            this.Load += new EventHandler(WOutValReport_Load);
            this.Activated += new EventHandler(WOutValReport_Activated);
        }

        #region Methods
        public virtual int of_cleave_recipients()
        {
            //?dw_report.modify("recipients.visible=false");
            return 1;
        }

        public virtual int of_cleave_seq()
        {
            //  dw_report.modify ( "seq_no.visible=false")
            return 1;
        }

        public virtual int of_cleave_category()
        {
            //?dw_report.modify("category.visible=false");
            return 1;
        }

        public virtual int of_cleave_kiwi()
        {
            //?dw_report.modify("kiwimail_qty.visible=false");
            return 1;
        }
        #endregion

        #region Events
        public void WOutValReport_Load(object sender, EventArgs args)
        {
            base.open();
            DateTime tnow = DateTime.Now;
            Cursor.Current = Cursors.WaitCursor;
            //  the type of report this will be decided by li_report_type
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            ((DOutValList)dw_report.DataObject).Retrieve();
            //?SetMicroHelp("Retrieve time: " + String(SecondsAfter(tnow, Now())) + "second ( s)");
        }

        public virtual void WOutValReport_Activated(object sender, EventArgs args)
        {
            base.activate();
            if (m_sheet != null)
            {
                //m_sheet._m_contractors.Visible = false;
                //m_sheet._m_contracts.Visible = false;
                //m_sheet._m_addresses.Visible = false; 
            }
        }
        #endregion
    }
}