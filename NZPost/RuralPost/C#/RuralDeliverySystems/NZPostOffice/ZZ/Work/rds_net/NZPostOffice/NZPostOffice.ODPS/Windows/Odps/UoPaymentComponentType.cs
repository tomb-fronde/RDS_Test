using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NZPostOffice.ODPS.Windows.OdpsLib;
using NZPostOffice.ODPS.Entity.OdpsRep;
using Metex.Windows;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class UoPaymentComponentType : UDrilldownList
    {
        public UoPaymentComponentType()
        {
            InitializeComponent();
        }

        public UoPaymentComponentType(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public override void constructor()
        {
            base.constructor();
            //jlwang:does not use
            //?DataUserControl dw_child;
            //dw_child = dw_selection.GetChild("pcg_id");//dw_selection.GetChild("pcg_id", dw_child);
            ////  Set the transaction object for the child
            //dw_child.Retrieve();
            //dw_child = dw_selection.GetChild("ac_id");// dw_selection.GetChild("ac_id", dw_child);
            ////  Set the transaction object for the child
            //dw_child.Retrieve();
        }

        //added by jlwang
        public override void ue_new()
        {
            //base.ue_new();
            this.dw_selection.InsertItem<PaymentComponentType>(this.dw_selection.RowCount);
            this.dw_selection.Focus();
            this.dw_selection.SetCurrent(this.dw_selection.RowCount);
        }
    }
}
