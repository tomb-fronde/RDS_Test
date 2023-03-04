using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_026  July-2011: New
    // Grid control to display unassigned fixed assets for WAddFixedAssets
    //
    public partial class DFARegisterUnassigned : Metex.Windows.DataUserControl
    {
        public DFARegisterUnassigned()
        {
            InitializeComponent();
            //InitializeDropdown();

            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
            this.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
            
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
            this.Retrieve();
        }

        private void InitializeDropdown()
        {
            d_dddw_fixed_asset_type.AssignDropdownType<DddwFixedAssetType>("FatId", "FatDescription");
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender,e);
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

        public int Retrieve( )
        {
            return RetrieveCore<FARegisterUnassigned>(new List<FARegisterUnassigned>
                (FARegisterUnassigned.GetAllFARegisterUnassigned( )));
        }

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
    }
}
