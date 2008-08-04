using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.Ruralbase;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WPrintOptions : WMaster
    {
        //? public DataWindow i_dwParent;
        public DPrintOptions dw_options;

        public WPrintOptions()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            //  26/04/2002 PBY Added - bypass the security
            this.of_bypass_security(true);
            //? i_dwParent = StaticMessage.PowerObjectParm;
            //? st_printer.Text = i_dwParent.Describe("DataWindow.Printer");
            dw_options.InsertItem<NZPostOffice.ODPS.Entity.Ruralbase.PrintOptions>(0);
            StaticMessage.StringParm = "None";
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            StaticMessage.StringParm = "None";
            this.Close();
        }

        public virtual void cb_select_printer_clicked(object sender, EventArgs e)
        {
            //? PrintSetup();
            //? st_printer.Text = i_dwParent.Describe("DataWindow.Printer");
        }

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            string sReturn = "";
            string sRow;
            if (!dw_options.AcceptText())
            {
                return;
            }
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            String TestExpr = dw_options.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.PrintOptions>(0).Pagerange;
            if (TestExpr == "A")
            {
                sReturn = "1:99999";
            }
            else if (TestExpr == "C")
            {
                //? sRow = i_dwParent.Describe("DataWindow.FirstRowOnPage");
                //? sReturn = i_dwParent.Describe("Evaluate ( \'Page ( )\', " + sRow + ')');
                sReturn = sReturn + ':' + sReturn;
            }
            else if (TestExpr == "R")
            {
                sReturn = dw_options.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.PrintOptions>(1).Pagefrom.ToString() + ":" + dw_options.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.PrintOptions>(0).Pageto.ToString();
            }
            sReturn = sReturn + ";" + dw_options.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.PrintOptions>(0).Copys;
            StaticMessage.StringParm = sReturn;
            this.Close();
        }
    }
}
