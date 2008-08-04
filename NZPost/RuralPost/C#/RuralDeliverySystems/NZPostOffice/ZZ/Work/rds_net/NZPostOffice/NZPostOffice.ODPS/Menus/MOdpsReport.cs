using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Menus
{
    public class MOdpsReport : MOdpsFrame
    {
        public ToolStrip toolBar;
       //? public ToolStripButton m_print;
       //? public ToolStripButton m_printpreview;
       //? public ToolStripButton m_zoom;
       //? public ToolStripButton m_firstpage;
       //? public ToolStripButton m_priorpage;
       //? public ToolStripButton m_nextpage;
       //? public ToolStripButton m_lastpage;

        public MOdpsReport(Form form)
            : base(form)
        {
        }

        public override void BuildMenu(Form form)
        {
            base.BuildMenu(form);
          
            m_print.Enabled = true;
            m_print.Visible = true;


            m_odps.Visible = false;
            m_odps.Enabled = false;

            m_replace.Visible = false;
            m_replace.Enabled = false;

        }
    }
}
