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
    public partial class DContractFixedAssetsTest : Metex.Windows.DataUserControl
	{
        public DContractFixedAssetsTest()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			fat_id.AssignDropdownType<DDddwFixedAssetType>();
		}

		public int Retrieve( int? contract_no )
		{
			return RetrieveCore<ContractFixedAssets>(new List<ContractFixedAssets>
				(ContractFixedAssets.GetAllContractFixedAssets( contract_no )));
		}

        public event EventHandler TextBoxLostFocus;

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
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
