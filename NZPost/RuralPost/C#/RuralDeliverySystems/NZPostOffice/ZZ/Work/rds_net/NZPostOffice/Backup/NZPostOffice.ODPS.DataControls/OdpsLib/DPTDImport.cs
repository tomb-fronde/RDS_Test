using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsLib;

namespace NZPostOffice.ODPS.DataControls.OdpsLib
{
    // TJB  RPCR_098  Jan-2016: NEW
    // Created from DShellImport

    public partial class DPTDImport : Metex.Windows.DataUserControl
    {
        public DPTDImport()
        {
            InitializeComponent();

            // These are here because they get overwritten in DPTDImport.Designer.cs 
            // if the designer is used to make any changes
            this.contractNoDataGridViewTextBoxColumn.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.amountDataGridViewTextBoxColumn.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.descriptionDataGridViewTextBoxColumn.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.referenceDataGridViewTextBoxColumn.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        }

        public override int Retrieve()
        {
            return RetrieveCore<PTDImport>(new List<PTDImport>
                (PTDImport.GetAllPTDImport()));
        }
    }
}
