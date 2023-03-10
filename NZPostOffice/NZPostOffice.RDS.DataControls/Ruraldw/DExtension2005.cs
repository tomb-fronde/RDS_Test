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
    // TJB  Feb-2012  RPI_036
    //    Changed mask for Frequency Distances to allow negative numbers
    //    This is a partial fix in that I've found some situations where 
    //    the application will crash (unhandled exception), especially if
    //    the window is closed while entering a value.
    //
    // TJB  15-July-2009  RD7_0033
    //    Added to fix problem with extentions:
    //    Itemchanged event not being triggered.

	public partial class DExtension2005 : Metex.Windows.DataUserControl
	{
		public DExtension2005()
		{
			InitializeComponent();

            this.extn_rural_bags.Validated += new System.EventHandler(this.TextBox_LostFocus);
            this.extn_other_bags.Validated += new System.EventHandler(this.TextBox_LostFocus);
            this.extn_private_bags.Validated += new System.EventHandler(this.TextBox_LostFocus);
            this.extn_post_offices.Validated += new System.EventHandler(this.TextBox_LostFocus);
            this.extn_no_cmbs.Validated += new System.EventHandler(this.TextBox_LostFocus);
            // this.extn_del_hrs.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            this.extn_del_hrs.Validated += new System.EventHandler(this.TextBox_LostFocus);
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

        private void extn_boxes_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
	}
}
