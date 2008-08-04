using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.RDS.Menus
{
    public class MSheet : MMainMenu
    {
        

        public MSheet(Form form)
            : base(form)
        {
        }

        public override void BuildMenu(Form form)
        {
            base.BuildMenu(form);

            m_print.Visible = true;
            m_window.Visible = true;

            #region toolbar

            _m_print.Visible = true;

            #endregion
        }

    }
}
