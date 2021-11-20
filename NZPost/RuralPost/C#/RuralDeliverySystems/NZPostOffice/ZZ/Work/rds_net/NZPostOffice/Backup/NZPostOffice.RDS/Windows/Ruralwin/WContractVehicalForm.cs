using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public partial class WContractVehicalForm : WMaster
    {
        #region Define
        public URdsDw idwParent;

        public int ilRow;
        #endregion

        public WContractVehicalForm()
        {
            this.InitializeComponent();

            this.ShowInTaskbar = false;

            dw_1.DataObject = new DContractVehicalForm();
        }

        public override void pfc_postopen()
        {
            //? dw_1.settransobject(StaticVariables.sqlca);
            dw_1.InsertItem<ContractVehicalForm>(dw_1.RowCount);
            dw_1.Reset();
            idwParent.DataObject = (DataUserControl)StaticMessage.PowerObjectParm;
            ilRow = idwParent.GetRow();
            //? idwParent.RowCopy<>(ilRow, ilRow, primary!, dw_1, 1, primary!);
        }

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int lLoop;
            dw_1.AcceptText();
            if (dw_1.uf_not_entered(1, "vehicle_v_vehicle_registration_number", "registration number"))
            {
                dw_1.Controls["vehicle_v_vehicle_registration_number"].Focus();
                return;
            }
            if (dw_1.uf_not_entered(1, "vehicle_vt_key", "vehicle type"))
            {
                dw_1.Controls["vehicle_vt_key"].Focus();
                return;
            }
            if (dw_1.uf_not_entered(1, "vehicle_v_vehicle_make", "make"))
            {
                dw_1.Controls["vehicle_v_vehicle_make"].Focus();
                return;
            }
            if (dw_1.uf_not_entered(1, "vehicle_v_vehicle_model", "model"))
            {
                dw_1.Controls["vehicle_v_vehicle_model"].Focus();
                return;
            }
            if (dw_1.uf_not_entered(1, "vehicle_ft_key", "fuel type"))
            {
                dw_1.Controls["vehicle_ft_key"].Focus();
                return;
            }
            for (lLoop = 0; lLoop <= 15; lLoop++)
            {
                if (lLoop == 4)
                {
                    idwParent.SetValue(ilRow, lLoop, dw_1.GetValue(0, lLoop));
                }
                else if (lLoop < 7 || lLoop > 9 && lLoop < 12 || lLoop == 14)
                {
                    idwParent.SetValue(ilRow, lLoop, dw_1.GetValue(0, lLoop));
                }
                else if (lLoop == 13)
                {
                    idwParent.SetValue(ilRow, lLoop, dw_1.GetValue(0, lLoop));
                }
                else
                {
                    idwParent.SetValue(ilRow, lLoop, dw_1.GetValue(0, lLoop));
                }
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}