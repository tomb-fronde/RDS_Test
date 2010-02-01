using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DDddwSuburbNames : Metex.Windows.DataUserControl
	{
		public DDddwSuburbNames()
		{
			InitializeComponent();
		}
        
        List<DddwSuburbNames> stringSource = null;
		public override int Retrieve()
        {		   
            DddwSuburbNames [] entitySource = DddwSuburbNames.GetAllDddwSuburbNames();
            List<string> stringSource = new List<string>();

            if (entitySource.Length > 0)
            {
                stringSource = new List<string>();
            }

            foreach (DddwSuburbNames item in entitySource)
            {
                stringSource.Add(item.SlName);
            }
            //! add an empty string at end of the list
            stringSource.Add("");
            this.bindingSource.DataSource = stringSource;
            return stringSource.Count;
		}
	}
}
