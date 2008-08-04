using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    public partial class WEmergency : WMaster
    {
        public WEmergency()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            //? dw_1.SETTRANSOBJECT(StaticVariables.sqlca);
        }

        #region Events
        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            //?dw_1.Retrieve(System.Convert.ToDateTime(sle_1.Text), StaticFunctions.ToInt32(sle_2.Text));
        }

        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
            dw_1.DataObject.Save();
        }
        #endregion
    }
}