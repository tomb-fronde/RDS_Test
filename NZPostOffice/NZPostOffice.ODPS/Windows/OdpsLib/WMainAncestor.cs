using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    public partial class WMainAncestor : FormBase
    {
        public WstInstances ist_Instances;

        public WMainAncestor()
        {
            InitializeComponent();
        }
    }

    public struct WstInstances
    {
        public const int Window_Access_Code = 0;
        public const int Window_Access_Group = 0;
    }
}