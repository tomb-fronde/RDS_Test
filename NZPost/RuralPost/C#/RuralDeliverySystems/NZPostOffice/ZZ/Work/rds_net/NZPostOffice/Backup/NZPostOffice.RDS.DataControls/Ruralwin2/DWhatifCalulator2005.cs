using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin2;

namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
	public partial class DWhatifCalulator2005 : Metex.Windows.DataUserControl
	{
		public DWhatifCalulator2005()
		{
			InitializeComponent();
            //this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

        private Metex.Core.EntityBindingList<WhatifCalulator2005> l_source_temp = new Metex.Core.EntityBindingList<WhatifCalulator2005>();

        public int Retrieve(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
		{
            if (this.bindingSource.DataSource is Metex.Core.EntityBindingList<WhatifCalulator2005>)
                l_source_temp = this.bindingSource.DataSource as Metex.Core.EntityBindingList<WhatifCalulator2005>;
            WhatifCalulator2005[] temp = WhatifCalulator2005.GetAllWhatifCalulator2005( inContract, inSequence, inRGCode, inEffectDate, inVolumeSource );
			int li_return = RetrieveCore<WhatifCalulator2005>(new List<WhatifCalulator2005>(temp));
            
            l_source_temp.AddRange(temp);
            this.bindingSource.DataSource = l_source_temp;

            //table = new NZPostOffice.RDS.DataControls.Report.WhatifCalulator2005DataSet(this.bindingSource.DataSource);
            //this.reWhatifCalulator2005.SetDataSource(table);
            //this.viewer.RefreshReport();

            return l_source_temp.Count;
        }

        public event EventHandler CellDoubleClick;

        public void Print()
        {
            this.viewer.PrintReport();
        }
	}
}
