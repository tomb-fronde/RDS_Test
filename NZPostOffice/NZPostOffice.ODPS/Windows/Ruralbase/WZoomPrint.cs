using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WZoomPrint : WResponse
    {
        public WZoomPrint()
        {
            this.InitializeComponent();
        }

        public override void open()
        {
            base.open();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            Double TestExpr = StaticMessage.DoubleParm;
            if (TestExpr == 200)
            {
                rb_200.Checked = true;
            }
            else if (TestExpr == 100)
            {
                rb_100.Checked = true;
            }
            else if (TestExpr == 65)
            {
                rb_65.Checked = true;
            }
            else if (TestExpr == 30)
            {
                rb_30.Checked = true;
            }
            else
            {
                rb_custom.Checked = true;
            }
            sle_custom.Text = StaticMessage.DoubleParm.ToString();
            StaticMessage.DoubleParm = -(1);
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            StaticMessage.IntegerParm = -1;
            this.Close();
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int nReturn = 0;
            if (rb_200.Checked)
            {
                nReturn = 200;
            }
            else if (rb_100.Checked)
            {
                nReturn = 100;
            }
            else if (rb_65.Checked)
            {
                nReturn = 65;
            }
            else if (rb_30.Checked)
            {
                nReturn = 30;
            }
            else if (StaticFunctions.IsNumber(sle_custom.Text))
            {
                nReturn = Convert.ToInt32(sle_custom.Text);
                if (nReturn < 0 || nReturn > 500)
                {
                    Console.Beep();
                    sle_custom.Focus();
                    nReturn = -(1);
                }
            }
            else
            {
                Console.Beep();
                sle_custom.Focus();
            }
            if (nReturn > -(1))
            {
                StaticMessage.IntegerParm = nReturn;
                this.Close();
            }
        }
    }
}