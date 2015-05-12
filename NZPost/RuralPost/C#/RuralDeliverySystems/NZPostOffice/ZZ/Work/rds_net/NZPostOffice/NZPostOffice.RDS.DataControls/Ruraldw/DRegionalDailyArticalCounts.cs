using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  May-2015  RPCR_093 Bugfix
    // Moved panel to separate file DRegionalDailyArticalCountsPanel
    // Renamed panel DRegionalDailyArticalCountsPanel (was RegionalDailyArticalCountsPanel)
    //
    // TJB  RPCR_093  Feb-2015: New
    // Created from DRegionalArticalCounts
    //
    // Collect artical count daily figures (instead of weekly)
    // Replaced DRegionalArticalCounts

    public partial class DRegionalDailyArticalCounts : Metex.Windows.DataUserControl
	{
		public DRegionalDailyArticalCounts()
		{
			InitializeComponent();
		}

        public int Retrieve(int? in_Contract, int? in_Region, int? in_RenewalGroup, DateTime? in_Period)
		{
			return RetrieveCore<RegionalDailyArticalCounts>(new List<RegionalDailyArticalCounts>
                (RegionalDailyArticalCounts.GetAllRegionalDailyArticalCounts(in_Contract, in_Region, in_RenewalGroup, in_Period)));
		}

        private void DRegionalDailyArticalCounts_RetrieveEnd(object sender, System.EventArgs e)
        {
            int panelControlsCount = this.panel1.Controls.Count;
            if (panelControlsCount > 1)
                 return;

            this.panel1.Controls.Clear();
            //this.SortString = ""; //"contract_no A";
            //this.Sort<RegionalDailyArticalCounts>();
            for (int i = 0; i < this.bindingSource.Count; i++)
            {
                DRegionalDailyArticalCountsPanel panel = new DRegionalDailyArticalCountsPanel();
                panel.Name = "RegionalDailyArticalCountsPanel" + i;
                panel.bindingSourcePanel.DataSource = this.BindingSource[i];
                panel.Location = new Point(0, i * panel.Height);
                this.panel1.Controls.Add(panel);
            }

            if (this.RowCount > 2)
            {
                this.panel1.AutoScroll = true;
                this.vScrollBar1.Visible = false;  // true;
                this.vScrollBar1.Maximum = this.RowCount;
                this.vScrollBar1.LargeChange = 2;
            }
            else
            {
                this.vScrollBar1.Visible = false;
            }
        }
    }
}
