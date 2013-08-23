using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Windows.OdpsLib;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    // TJB  RPCR_054  July-2013
    // Added ue_save

    public partial class UoPbuCode : UDrilldownList
    {
        public UoPbuCode()
        {
            InitializeComponent();
        }

        public UoPbuCode(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //added by jlwang
        public override void ue_new()
        {
            //base.ue_new();
            this.dw_selection.InsertItem<PbuCode>(this.dw_selection.RowCount);
            this.dw_selection.Focus();
            this.dw_selection.SetCurrent(this.dw_selection.RowCount);
        }

        // TJB  RPCR_054  July-2013: Added
        public override void ue_save()
        {
            MessageBox.Show("Save", "UoPbuCode");
            this.dw_selection.Save();
        }
    }
}
