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
	public partial class DMailmergeOdDownloadData : Metex.Windows.DataUserControl
	{
		public DMailmergeOdDownloadData()
		{
			InitializeComponent();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<MailmergeOdDownloadData>(new List<MailmergeOdDownloadData>
                (MailmergeOdDownloadData.GetAllMailmergeOdDownloadData()));
		}
	}
}
