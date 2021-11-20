using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;

namespace NZPostOffice.RDS.DataControls.DropDownList
{
    public partial class DDropDownList : DataUserControl
    {
        public DDropDownList()
        {
            InitializeComponent();
        }

        public void SetDataSource(DropDownList[] item)
        {
            this.bindingSource.DataSource = item;
        }
    }
}
