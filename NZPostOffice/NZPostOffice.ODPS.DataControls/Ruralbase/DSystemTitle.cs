using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Ruralbase;
//?using NZPostOffice.Odps.DataControls.EpDropdowns;

namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
    public partial class DSystemTitle : Metex.Windows.DataUserControl
    {
        public DSystemTitle()
        {
            InitializeComponent();

            this.systemtitle.BorderStyle = BorderStyle.None;
            this.compute_1.BorderStyle = BorderStyle.None;
        }

        public override int Retrieve()
        {
            //?return RetrieveCore<SystemTitle>(SystemTitle.GetAllSystemTitle());

            List<SystemTitle> list = new List<SystemTitle>();
            SystemTitle item = new SystemTitle();
            list.Add(item);
            return RetrieveCore<SystemTitle>(list);
        }
    }
}
