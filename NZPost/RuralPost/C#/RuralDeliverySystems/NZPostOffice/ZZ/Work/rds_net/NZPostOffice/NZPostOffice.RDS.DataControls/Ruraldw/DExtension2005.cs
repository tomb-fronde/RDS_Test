using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DExtension2005 : Metex.Windows.DataUserControl
	{
		public DExtension2005()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_contract )
		{
			return RetrieveCore<Extension2005>(new List<Extension2005>
				(Extension2005.GetAllExtension2005( in_contract )));
		}

        public event EventHandler TextBoxLostFocus;

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                //Control c = this.ActiveControl;
                //extn_reason.Focus();
                TextBoxLostFocus(sender, e);
                //if (c != null)
                //{
                //    c.Focus();
                //}
            }
            //string name = ((TextBoxBase)sender).Name;
        }
        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
	}
}
