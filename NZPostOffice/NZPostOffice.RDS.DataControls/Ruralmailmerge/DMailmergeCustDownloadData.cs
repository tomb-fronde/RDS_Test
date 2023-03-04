using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralmailmerge;

namespace NZPostOffice.RDS.DataControls.Ruralmailmerge
{
	public partial class DMailmergeCustDownloadData : Metex.Windows.DataUserControl
	{
		public DMailmergeCustDownloadData()
		{
			InitializeComponent();
		}

        public int Retrieve(string sqlSyntax)
		{
			return RetrieveCore<MailmergeCustDownloadData>(new List<MailmergeCustDownloadData>
                (MailmergeCustDownloadData.GetAllMailmergeCustDownloadData(sqlSyntax)));
		}
	}
}
