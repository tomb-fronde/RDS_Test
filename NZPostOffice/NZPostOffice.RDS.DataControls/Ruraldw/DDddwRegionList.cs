using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DDddwRegionList : Metex.Windows.DataUserControl
    {
        public DDddwRegionList()
        {
            InitializeComponent();
           // InitializeDropdown();
            this.region_list.SelectedValueChanged += new EventHandler(region_list_SelectedIndexChanged);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

        void region_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDDwItemChanged != null)
                DDDwItemChanged(sender, e);
        }


        private void InitializeDropdown()
        {
            region_list.AssignDropdownType<DDddwRegions>();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwRegionList>(DddwRegionList.GetAllDddwRegionList());
        }
        public event EventHandler DDDwItemChanged;
    }
}
