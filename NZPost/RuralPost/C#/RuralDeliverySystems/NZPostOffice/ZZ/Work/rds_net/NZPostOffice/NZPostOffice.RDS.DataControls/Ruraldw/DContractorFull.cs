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
    public partial class DContractorFull : Metex.Windows.DataUserControl
    {
        public DContractorFull()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            #region c_witholding_tax_certificate
            System.Data.DataTable sourceTable1 = new System.Data.DataTable();
            sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(string))
			});
            sourceTable1.Rows.Add(new object[] { "Yes", "Y" });
            sourceTable1.Rows.Add(new object[] { "No", "N" });
            sourceTable1.Rows.Add(new object[] { "Exempt", "X" });
            this.c_witholding_tax_certificate.DataSource = sourceTable1;
            this.c_witholding_tax_certificate.DisplayMember = "Display";
            this.c_witholding_tax_certificate.ValueMember = "Value";
            #endregion

        }

        public event EventHandler TextBoxLostFocus;

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }

		public int Retrieve( int? in_contractor )
        {
            return RetrieveCore<ContractorFull>(ContractorFull.GetAllContractorFull(in_contractor));
        }
    }
}
