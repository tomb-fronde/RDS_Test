using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    public partial class WPaymentManualAdjustment : WResponse
    {
        public WPaymentManualAdjustment()
        {
            InitializeComponent();

            this.dw_1.DataObject = new DwPaymentManualAdjustment();
        }

        public override void open()
        {
            base.open();
            //? dw_1.settransobject(StaticVariables.sqlca);
            dw_1.DataObject.Retrieve();
        }

        public virtual void constructor()
        {
            //? dw_1.of_setsort(true);
        }

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            //? dw_1.Print();
        }
        #endregion
    }
}