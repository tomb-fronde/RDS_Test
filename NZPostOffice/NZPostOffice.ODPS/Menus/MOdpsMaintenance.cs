using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Menus
{
    public class MOdpsMaintenance : MOdpsFrame
    {

        //?public ToolStrip toolBar;  //add new toolbar

        public ToolStripButton _m_save;
        public ToolStripButton _m_addrow;
        public ToolStripButton _m_insertrow;
        public ToolStripButton _m_deleterow;

        public ToolStripButton _m_cut;
        public ToolStripButton _m_copy;
        public ToolStripButton _m_paste;

        public MOdpsMaintenance(Form form)
            : base(form)
        {
        }

        public override void BuildMenu(Form form)
        {
            base.BuildMenu(form);

            m_dash11.Visible = true;
            m_dash12.Visible = false;

            m_save.Enabled = true;
            m_save.Visible = true;

            m_edit.Enabled = true;
            m_edit.Visible = true;

            m_record.Enabled = true;
            m_record.Visible = true;

            m_insertrow.Visible = false;
            m_insertrow.Enabled = false;

            m_odps.Visible = false;
            m_odps.Enabled = false;

            m_reports.Visible = false;
            m_reports.Enabled = false;

            #region ToolBar

            _m_save = new ToolStripButton("Save", global::NZPostOffice.Shared.Properties.Resources.saveodps, null, "_m_save");
            ToolStrip.Items.Add(_m_save);
            _m_save.Click += new EventHandler(m_save_clicked);

            ToolStripSeparator t1 = new ToolStripSeparator();
            ToolStrip.Items.Add(t1);

            _m_cut = new ToolStripButton("Cut", global::NZPostOffice.Shared.Properties.Resources.cut, null, "_m_cut");
            ToolStrip.Items.Add(_m_cut);
            _m_cut.Click += new EventHandler(m_cut_clicked);

            _m_copy = new ToolStripButton("Copy", global::NZPostOffice.Shared.Properties.Resources.copy, null, "_m_copy");
            ToolStrip.Items.Add(_m_copy);
            _m_copy.Click += new EventHandler(m_copy_clicked);

            _m_paste = new ToolStripButton("Paste", global::NZPostOffice.Shared.Properties.Resources.paste, null, "_m_paste");
            ToolStrip.Items.Add(_m_paste);
            _m_paste.Click += new EventHandler(m_paste_clicked);

            ToolStripSeparator t2 = new ToolStripSeparator();
            ToolStrip.Items.Add(t2);

            _m_addrow = new ToolStripButton("Add", global::NZPostOffice.Shared.Properties.Resources.insertrow, null, "_m_addrow");
            ToolStrip.Items.Add(_m_addrow);
            _m_addrow.Click += new EventHandler(m_addrow_clicked);

            _m_deleterow = new ToolStripButton("Delete", global::NZPostOffice.Shared.Properties.Resources.Delete, null, "_m_deleterow");
            ToolStrip.Items.Add(_m_deleterow);
            _m_deleterow.Click += new EventHandler(m_deleterow_clicked);

            #endregion
        }
            

        public override void m_save_clicked(object sender, EventArgs e)
        {
            //of_sendmessage("pfc_save");
             ((FormBase)StaticVariables.MainMDI.ActiveMdiChild).pfc_save();
        }
    }
}
