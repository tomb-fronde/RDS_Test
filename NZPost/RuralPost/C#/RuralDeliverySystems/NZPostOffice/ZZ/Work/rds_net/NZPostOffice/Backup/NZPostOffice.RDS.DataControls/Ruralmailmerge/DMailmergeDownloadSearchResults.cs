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
	public partial class DMailmergeDownloadSearchResults : Metex.Windows.DataUserControl
	{
		public DMailmergeDownloadSearchResults()
		{
			InitializeComponent();
		}

		public override int Retrieve()
		{
			return RetrieveCore<MailmergeDownloadSearchResults>(new List<MailmergeDownloadSearchResults>
                (MailmergeDownloadSearchResults.GetAllMailmergeDownloadSearchResults()));
		}

        public  int Retrieve(string str_sql)
        {
            int ll_return;
            ll_return = RetrieveCore<MailmergeDownloadSearchResults>(new List<MailmergeDownloadSearchResults>
                (MailmergeDownloadSearchResults.GetAllMailmergeDownloadSearchResultsList(str_sql)));
            this.SortString = "con_title A";
            this.Sort<MailmergeDownloadSearchResults>();
            return ll_return;
        }
	}
}
