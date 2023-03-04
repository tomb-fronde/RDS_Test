using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WUnoccupiedSearch : WGenericReportSearch
    {
        public WUnoccupiedSearch()
        {
            InitializeComponent();
            dw_criteria.DataObject = new DUnoccupiedCriteria();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_results.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;


            //jlwang:
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            //jlwang:end
        }

        public override void dw_results_constructor()
        {
            //?base.constructor();
            dw_results.of_SetRowSelect(true);
            dw_results.of_SetStyle(0);//? inv_rowselect.of_SetStyle(0);
        }

        #region Events
        public override void pb_search_clicked(object sender, EventArgs e)
        {
            base.pb_search_clicked(sender, e);
            //  testing twc - get rid of the <all contracts>
            if (dw_results.DataObject.RowCount != 0)
            {
                dw_results.DataObject.DeleteItemAt(0);//.deleterow(1);
            }
            dw_results.DataObject.SortString = "contract_no A";
            dw_results.DataObject.Sort<ReportGenericResults>();//.sort();
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            base.pb_open_clicked(null, null);
            //?base.clicked();
            //?StaticVariables.gs_report_sort = "road_name A, road_no A";
        }
        #endregion
    }
}