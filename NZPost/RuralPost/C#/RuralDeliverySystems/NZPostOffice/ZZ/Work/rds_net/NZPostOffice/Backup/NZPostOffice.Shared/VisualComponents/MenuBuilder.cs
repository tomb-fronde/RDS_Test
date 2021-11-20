using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;

namespace NZPostOffice.Shared.VisualComponents
{
    public abstract class MenuBuilder
    {
        public abstract void BuildMenu(System.Windows.Forms.Form form);

        private MenuStrip _menuStrip;

        public MenuStrip MenuStrip
        {
            get
            {
                return _menuStrip;
            }
            set
            {
                _menuStrip = value;
            }
        }

        private ToolStrip _toolStrip;

        private static Hashtable attachedFormTable = new Hashtable();

        protected ToolStrip ToolStrip
        {
            get
            {
                return _toolStrip;
            }
            set
            {
                _toolStrip = value;
                Form hostForm = _toolStrip.FindForm();

                if (hostForm != null)
                {
                    if (hostForm.IsMdiContainer)
                    {
                        hostForm.MdiChildActivate += new EventHandler(hostForm_MdiChildActivate);
                    }


                    //if (hostForm.MdiParent != null && !attachedFormTable.ContainsKey(hostForm))
                    //{
                    //    hostForm.MdiParent.MdiChildActivate -= new EventHandler(DoMdiChildActive);
                    //    hostForm.MdiParent.MdiChildActivate += new EventHandler(DoMdiChildActive);
                    //    attachedFormTable.Add(hostForm, true);
                    //}
                    //else
                    //{
                    //    hostForm.Load += new EventHandler(DoLoad);
                    //    hostForm.Disposed += new EventHandler(OnDisposed);
                    //}
                }
            }
        }

        void hostForm_MdiChildActivate(object sender, EventArgs e)
        {
            Form hostMdi = sender as Form;
            MergeToolTrip(hostMdi, hostMdi.ActiveMdiChild);
        }

        //private void DoLoad(object sender, EventArgs e)
        //{
        //    Form hostForm = sender as Form;
        //    if (hostForm.MdiParent != null && !attachedFormTable.ContainsKey(hostForm))
        //    {                
        //        hostForm.MdiParent.MdiChildActivate += new EventHandler(DoMdiChildActive);
        //        attachedFormTable.Add(hostForm, true);
        //    }
        //}

        //private void DoMdiChildActive(object sender, EventArgs e)
        //{
        //    Form hostMdi = sender as Form;
        //    MergeToolTrip(hostMdi, hostMdi.ActiveMdiChild);
        //}

        protected ToolStrip GetToolStripInControl(Control c)
        {
            if (c == null)
            {
                return null;
            }
            if (c is ToolStrip && !(c is StatusStrip))
            {
                return c as ToolStrip;
            }
            else
            {
                foreach (Control cc in c.Controls)
                {
                    ToolStrip t = GetToolStripInControl(cc);
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        protected MenuStrip GetMenuStripInControl(Control c)
        {
            if (c == null)
                return null;
            foreach (Control cc in c.Controls)
            {
                MenuStrip t = cc as MenuStrip;
                if (t != null)
                {
                    //string pbname=Functions.GetPBName(t.GetType().Name);
                    //if(t.Name == pbname)
                    return t;
                }
            }

            return null;
        }

        private void MergeToolTrip(Form mdiParent, Form mdiChild)
        {
            ToolStrip parentToolStrip = GetToolStripInControl(mdiParent);
            ToolStrip childToolStrip = GetToolStripInControl(mdiChild);

            MenuStrip parentMenuStrip = GetMenuStripInControl(mdiParent);
            MenuStrip childMenuStrip = GetMenuStripInControl(mdiChild);

            if (childToolStrip != null)
            {
                childToolStrip.Visible = false;
                parentToolStrip.SuspendLayout();
                ToolStripManager.RevertMerge(parentToolStrip);
                ToolStripManager.Merge(childToolStrip, parentToolStrip);
                ToolStripMenuItem showExit = ((FramPopMenus)ToolStrip.ContextMenuStrip).Items["frameBarToolStripMenuItem"] as ToolStripMenuItem;
                if (showExit != null)
                {
                    if (showExit.CheckState == CheckState.Checked)
                    {
                        parentToolStrip.Items["m_exit"].Visible = true;
                    }
                    else
                    {
                        parentToolStrip.Items["m_exit"].Visible = false;
                    }
                }
                parentToolStrip.ResumeLayout(true);
            }
            else if (parentToolStrip != null)
            {
                parentToolStrip.SuspendLayout();
                ToolStripManager.RevertMerge(parentToolStrip);
                parentToolStrip.Items["m_exit"].Visible = true;
                parentToolStrip.ResumeLayout(true);
            }
            if (childMenuStrip != null)
            {
                parentMenuStrip.SuspendLayout();
                ToolStripManager.RevertMerge(parentMenuStrip);
                ToolStripManager.Merge(childMenuStrip, parentMenuStrip);
                parentMenuStrip.ResumeLayout(true);
            }
            else if (parentMenuStrip != null)
            {
                parentMenuStrip.SuspendLayout();
                ToolStripManager.RevertMerge(parentMenuStrip);
                parentMenuStrip.ResumeLayout(true);
            }



        }
    }
}
