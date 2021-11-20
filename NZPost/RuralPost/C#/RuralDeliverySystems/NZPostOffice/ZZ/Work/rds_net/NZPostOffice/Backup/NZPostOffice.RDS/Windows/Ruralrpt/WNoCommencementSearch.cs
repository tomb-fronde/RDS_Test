using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WNoCommencementSearch : WGenericSearch
    {
        public WNoCommencementSearch()
        {
            InitializeComponent();
            this.dw_1.DataObject = new DExtRegion();
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dw_1.Constructor += new UserEventDelegate(dw_1_constructor);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //?dw_1.settransobject(StaticVariables.sqlca);
            dw_1.InsertItem<ExtRegion>(0);
            em_1.Focus();
        }

        public virtual void dw_1_constructor()
        {
            dw_1.of_SetUpdateable(false);
        }  
        
        public virtual void pb_1_clicked(object sender, EventArgs e)
        {
            if (System.Convert.ToInt32(em_1.Text) == 0 || (em_1.Text == null))
            {
                MessageBox.Show("Please enter number of days", "Commencement Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                em_1.Focus();
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = System.Convert.ToInt32(em_1.Text);
                //OpenSheetWithParm(w_no_commencement_report, dw_1.getitemnumber(1, "d_ext_region_id"), w_main_mdi, 0, original!);
                StaticMessage.IntegerParm = dw_1.GetItem<ExtRegion>(0).DExtRegionId.GetValueOrDefault();
                WNoCommencementReport w_no_commencement_report = new WNoCommencementReport();
                w_no_commencement_report.MdiParent = StaticVariables.MainMDI;
                w_no_commencement_report.Show();
            }
        }
    }
}