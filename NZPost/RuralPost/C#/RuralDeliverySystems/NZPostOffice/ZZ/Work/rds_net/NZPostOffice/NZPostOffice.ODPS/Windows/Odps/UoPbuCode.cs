using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NZPostOffice.ODPS.Windows.OdpsLib;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
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
    }
}
