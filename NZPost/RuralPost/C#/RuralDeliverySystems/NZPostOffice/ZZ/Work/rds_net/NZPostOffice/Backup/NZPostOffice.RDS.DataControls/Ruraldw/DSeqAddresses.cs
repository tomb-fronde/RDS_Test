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
    // TJB  RPCR_077  May-2016
    // Added cust_stripmaker_seq to sort string
    //
    // TJB  Jan-2011  Sequencing Review
    // Modified retrieval - removed frequency details (since now sequencing
    // is by contract, not contract+frequency.

    public partial class DSeqAddresses : Metex.Windows.DataUserControl
    {
        public DSeqAddresses()
        {
            InitializeComponent();

            grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            grid.CellMouseDown += new DataGridViewCellMouseEventHandler(grid_CellMouseDown);
        }

        void grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CellMouseDown != null)
                CellMouseDown(sender, e);
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
                CellClick(sender, e);
        }

        // TJB  RPCR_077  May-2016
        // Added cust_stripmaker_seq to sort string
        public int Retrieve(int? al_contract_no)
        {
            int rowCount = RetrieveCore<SeqAddresses>(new List<SeqAddresses>
                            (SeqAddresses.GetAllSeqAddresses(al_contract_no)));
            if (rowCount > 0)
                this.SortString = "seq_num A, cust_stripmaker_seq A, customer A";
            this.Sort<SeqAddresses>();
            return rowCount;
        }

        public event EventHandler CellClick;
        public event DataGridViewCellMouseEventHandler CellMouseDown;
    }
}
