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
	public partial class DMailCountSearchResults : Metex.Windows.DataUserControl
	{
		public DMailCountSearchResults()
		{
			InitializeComponent();
		}

        public int Retrieve(int? rgroup1, int? rgroup2, int? region, int? outlet)
		{
            int retval = 0;
            List<MailCountSearchResults> source = new List<MailCountSearchResults>
                (MailCountSearchResults.GetAllMailCountSearchResults(rgroup1, rgroup2, region, outlet));
            
            retval = this.RetrieveCore<MailCountSearchResults>(source);

            this.SortOnce<MailCountSearchResults>(new Comparison<MailCountSearchResults>(this.defaultSorter));
            
            return retval;
		}

        private int defaultSorter(MailCountSearchResults s1, MailCountSearchResults s2)
        {
            return string.Compare(s1.ConTitle, s2.ConTitle);
        }
	}
}
