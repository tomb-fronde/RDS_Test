using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    public partial class DMailListResult : Metex.Windows.DataUserControl
    {
        public DMailListResult()
        {
            InitializeComponent();
        }

        public int Retrieve(string inPost, string inOcc, string inInterest, DateTime? inDate1, DateTime? inDate2,int? ll_or)
        {
            return RetrieveCore<MailListResult>(new List<MailListResult>
                (MailListResult.GetAllMailListResult(inPost, inOcc, inInterest, inDate1, inDate2,ll_or)));
        }
    }
}
