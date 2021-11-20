using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NZPostOffice.ODPS.Windows.OdpsLib;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class UoNational : UDrilldownList
    {
        public UoNational()
        {
            InitializeComponent();
            ((Metex.Windows.DataEntityGrid)dw_selection.DataObject.GetControlByName("grid")).CellMouseDoubleClick
                += new DataGridViewCellMouseEventHandler(UoNational_CellMouseDoubleClick);
        }

        void UoNational_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ue_open();
        }

        public UoNational(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public override void ue_open()
        {
            //base.ue_open();
            int ll_natID;                                           // tjb
            int ll_row;

            ll_row = this.dw_selection.GetSelectedRow(0);

            if (ll_row >= 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                //?gnv_app.inv_ObjectMsg.of_addmsg("uo", "callinguo", this);
                StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("uo", "callinguo", this);

                //OpenSheetWithParm(w_national_maintenance, dw_selection.getitemnumber(ll_row, "nat_id"), gnv_app.of_getframe(), 0, original!);
                //StaticMessage.IntegerParm = this.dw_selection.GetValue<int>(ll_row, "nat_id");
                ll_natID = this.dw_selection.GetValue<int>(ll_row, "nat_id");                      // tjb
                StaticMessage.IntegerParm = ll_natID;                                              // tjb
                WNationalMaintenance w_national_maintenance = new WNationalMaintenance();
                w_national_maintenance.MdiParent = StaticVariables.MainMDI;
                w_national_maintenance.Show();
            }
        }

        public override void ue_new()
        {
            int ll_natID;                                           // tjb
            int ll_row = this.dw_selection.GetSelectedRow(0);       // tjb
            ll_row = (ll_row >= 0) ? ll_row : 0;                    // tjb

            Cursor.Current = Cursors.WaitCursor;
            //OpenSheetWithParm(w_national_maintenance, "New", gnv_app.of_getframe(), 0, original!);
            //StaticMessage.IntegerParm = 0; //added by jlwang
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("uo", "callinguo", this);          // tjb
            ll_natID = this.dw_selection.GetValue<int>(ll_row, "nat_id");                      // tjb
            StaticMessage.IntegerParm = ll_natID;                                              // tjb
            StaticMessage.StringParm = "New";
            WNationalMaintenance w_national_maintenance = new WNationalMaintenance();
            w_national_maintenance.MdiParent = StaticVariables.MainMDI;
            w_national_maintenance.Show();
        }

        public virtual void pfc_retrieve()
        {
            //base.pfc_retrieve();
            //// 	Object:			cs_Template_w_Singledw.dw_Single
            //// 	Method:			pfc_Retrieve
            //// 	Description:	retrieve the datawindow
            //// 	HELP:	you should adjust this if there is any retrieval arguments for this dw
            //return dw_selection.Retrieve();
        }

        public virtual void constructor()
        {
            //base.constructor();
            //dw_selection.of_SetRowSelect(true);
        }
    }
}
