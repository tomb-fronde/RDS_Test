using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;
using NZPostOffice.ODPS.DataControls.Report;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    public partial class DwGlAccrualsAudit : Metex.Windows.DataUserControl
    {
        public DwGlAccrualsAudit()
        {
            InitializeComponent();

            this.RetrieveEnd += new EventHandler(DwGlAccrualsAudit_RetrieveEnd);
        }

        private DateTime ui_ProcDate = DateTime.MinValue;
        public int Retrieve(DateTime? ProcDate)
        {
            ui_ProcDate = ProcDate.GetValueOrDefault();
            int ret = RetrieveCore<GlAccrualsAudit>(new List<GlAccrualsAudit>
                (GlAccrualsAudit.GetAllGlAccrualsAudit(ProcDate)));
            return ret;
        }

        private void DwGlAccrualsAudit_RetrieveEnd(object sender, EventArgs e)
        {
            this.table = new GlAccrualsAuditDataSet(this.bindingSource.DataSource);
            this.reGlAccrualsAudit.SetDataSource(table);

            this.viewer.RefreshReport();
        }

        private void reGlAccrualsAudit_RefreshReport(object sender, System.EventArgs e)
        {
            if (ui_ProcDate != DateTime.MinValue)
            {
                DateTime temp = ui_ProcDate.AddMonths(1);
                temp = new DateTime(temp.Year, temp.Month, 1);
                this.reGlAccrualsAudit.SetParameterValue("ProcDate", temp.AddDays(-1));
            }
        }
        public CrystalDecisions.CrystalReports.Engine.ReportClass ReportDocument
        {
            get { return this.reGlAccrualsAudit; }
        }
    }
}
