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
        
        
        //public void FilterMisc(string lsFilter) 
        //{           

        //    DddwSuburbNames[] entitySource = DddwSuburbNames.GetAllDddwSuburbNames();
        //    stringSource.Clear();
        //    foreach (DddwSuburbNames item in entitySource)
        //    {
        //        stringSource.Add(item.SlName);
        //    }


        //    if (!string.IsNullOrEmpty(lsFilter))
        //    {
        //        List<string> filteredStringSource = new List<string>();

        //        string[] items = lsFilter.Split(new char[] { ',' });

        //        foreach (string item in stringSource)
        //        {
        //            foreach (string s in items)//! allow the empty value added 
        //            {
        //                if (item == s && this.NotRepeatedItem(filteredStringSource, item))//! do not add one item more than once
        //                {
        //                    filteredStringSource.Add(item);
        //                }
        //            }
        //        }
        //        filteredStringSource.Add("");//! add an empty string at end of the list

        //        this.bindingSource.CurrencyManager.SuspendBinding();
        //        this.bindingSource.DataSource = filteredStringSource;//! filter
        //        this.bindingSource.CurrencyManager.ResumeBinding();
        //        //! stringSource = filteredStringSource;
        //    }           
        //}

        //private bool NotRepeatedItem(List<string> filteredStringSource, string item) 
        //{
        //    foreach (string i in filteredStringSource)
        //    {
        //        if (i == item)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

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
            stringSource.Add("");//! add an empty string at end of the list

            this.bindingSource.DataSource = stringSource;

            return stringSource.Count;
          
            //!return RetrieveCore<DddwSuburbNames>(DddwSuburbNames.GetAllDddwSuburbNames());
		}
	}
}
