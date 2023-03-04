using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class WDateSearch : WMaster
    {
        public WDateSearch()
        {
            InitializeComponent();

            dw_search.DataObject = new DwDateSearch();
            dw_search.DataObject.BorderStyle = BorderStyle.Fixed3D;
        }
    }
}