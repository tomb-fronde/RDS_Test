using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Entity;

namespace NZPostOffice.DataControls
{
    public partial class DDddwContractTypes : Metex.Windows.DataUserControl
    {
        public DDddwContractTypes()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<DddwContractTypes>(new List<DddwContractTypes>(DddwContractTypes.GetAllDddwContractTypes()), new Comparison<DddwContractTypes>(contract_type_asc), null);
        }
        private int contract_type_asc<T>(T x, T y)
        {
            DddwContractTypes X = x as DddwContractTypes;
            DddwContractTypes Y = y as DddwContractTypes;
            return String.Compare(X.ContractType, Y.ContractType, StringComparison.Ordinal);
        }
    }
}
