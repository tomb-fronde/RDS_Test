using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.RDS.Controls
{
    public class NWp
    {
        public string icWpPath = String.Empty;
        
        public string icDDEName = String.Empty;
        
        public string icInifile = String.Empty;
        
        public int i_iHandle;
        
        public int i_iHandle2;

        public Microsoft.Office.Interop.Word.Application app;

        public NWp()
        {
        }
        
        public virtual bool uf_wp_path_set(string awppath) 
        {
            bool lReturn;
            icWpPath = awppath;
            if (icWpPath == "") {
                lReturn = false;
            }
            else if (System.IO.File.Exists(icWpPath)) 
            {
                lReturn = true;
            }
            else {
                lReturn = false;
            }
            return lReturn;
        }  

        public virtual int uf_set_dde_name(string a_ddename)
        {
            icDDEName = a_ddename;
            return 1;
        }

        public virtual int uf_close_channel()
        {
            int lcn = 0;
            DateTime tm;
            tm = DateTime.Now;
           //? lcn = CloseChannel(i_iHandle);
            Cursor.Current = Cursors.WaitCursor;
            if (app != null)
            {
                object oMissing = System.Reflection.Missing.Value;
                try
                {
                    // user may have closed the application manually
                    app.Quit(ref oMissing, ref oMissing, ref oMissing);
                }
                catch (Exception ex)
                {
                }
                app = null;
            }
           /*? while (SecondsAfter(tm, Now()) < 300)
            {
                if (lcn > 0)
                {
                    break;
                }
                lcn = CloseChannel(i_iHandle);
                if (lcn > 0)
                {
                    break;
                }
            }*/
            Cursor.Current = Cursors.Arrow;
            return lcn;
        }

        public virtual int uf_doc_create(string atemplate)
        {
            string strTemp;
            int iRes = 0;
            DateTime tm;
            tm = DateTime.Now;
            // Use .net COM interop to replace the obsolete DDE techonology
            if (app != null)
            {
                object oVisible = true;
                object oTemplate = atemplate;
                object oMissing = System.Reflection.Missing.Value;
                app.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oVisible);
                iRes = 1;
            }
            /*? strTemp = "[FileNew.Template = \"" + atemplate + "\"]";
            // iRes = ExecRemote ( strTemp, icddename, 'system')
            //?iRes = ExecRemote(strTemp, i_iHandle);
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = iRes;
            if (TestExpr == -(1))
            {
                MessageBox.Show("DDE link with " + icDDEName + " not started", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (TestExpr == -(2))
            {
                // 	messagebox ( "Error", "DDE server denies DDE link with Quals")
            }
            else if (TestExpr == -(3))
            {
                MessageBox.Show("Could not terminate DDE server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } */
            return iRes;
        }

        public virtual int uf_macro_run(string amacroname)
        {
            string amac;
            amac = amacroname;
            string strTemp;
            int iRes = 0;
            if (app != null)
            {
                object oMissing = System.Reflection.Missing.Value;
                try
                {
                    app.Run(amacroname, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            /*? strTemp = "[Call " + amacroname + ']';
            // iRes = ExecRemote ( strTemp,i_ihandle) */
            return iRes;
        }

        public virtual int uf_open_channel() {
            //  this function opens a channel to the word processing package
            int iRes;
            // Use .net COM interop to replace the obsolete  DDE techonology
            try
            {
                app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = true;
                iRes = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot connect to the word processor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iRes = -1;
            }
            /*?
            DialogResult iretry;
           //? i_iHandle = OpenChannel(icDDEName, "system");
            // debug
            int ih;
            ih = i_iHandle;
            //  if not found, then try starting it first
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            long TestExpr = i_iHandle;
            if (TestExpr == -(1)) {
                iRes = uf_wp_start();
                if (iRes != -(1)) {
                  //?  i_iHandle = OpenChannel(icDDEName, "system");
                    DateTime tm;
                    tm = DateTime.Now;
                    Cursor.Current = Cursors.WaitCursor;
                   /*? while (SecondsAfter(tm, Now()) < 300) 
                    {
                        if (i_iHandle > 0) {
                            break;
                        }
                        i_iHandle = OpenChannel(icDDEName, "system");
                        if (i_iHandle > 0) {
                            break;
                        }
                    }* /
                    if (i_iHandle < 0) {
                        MessageBox.Show("Cannot connect to the word processor", "Word Processor Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    Cursor.Current = Cursors.WaitCursor;
                    while (1 == 1) {
                        iretry = MessageBox.Show("Word Processing Start", "Do you want to retry?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (iretry == DialogResult.Yes) {
                            iRes = uf_wp_start();
                            if (iRes != -(1)) {
                                //?i_iHandle = OpenChannel(icDDEName, "system");
                                if (i_iHandle > 0) {
                                    break;
                                }
                            }
                        }
                        else {
                            break;
                        }
                    }
                }
            }
            else if (TestExpr == -(9)) {
                iRes = uf_wp_start();
                if (iRes != -(1)) {
                    //?i_iHandle = OpenChannel(icDDEName, "system");
                    while (1 == 1) {
                        if (i_iHandle < 0) {
                            iretry = MessageBox.Show("Word Processor Connection", "Cannot connect to the word processor. Do you want to retry?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        else {
                            break;
                        }
                        if (iretry == DialogResult.Yes) {
                            iRes = uf_wp_start();
                            if (iRes != -(1)) {
                                //?i_iHandle = OpenChannel(icDDEName, "system");
                            }
                        }
                        else {
                            break;
                        }
                    }
                }
                else {
                    while (1 == 1) {
                        iretry = MessageBox.Show("Word Processing Start", "Do you want to retry?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (iretry == DialogResult.Yes) {
                            iRes = uf_wp_start();
                            if (iRes != -(1)) {
                              //?  i_iHandle = OpenChannel(icDDEName, "system");
                                if (i_iHandle > 0) {
                                    break;
                                }
                            }
                        }
                        else {
                            break;
                        }
                    }
                }
            }
            if (i_iHandle < 0) {
                iRes = -(1);
            }
            else {
                iRes = 1;
            } */
            return iRes;
        }

        public virtual int uf_wp_start()
        {
            //  this function starts the word processing package
            int iRes = 0;
            string wp;
            wp = icWpPath;
           //? iRes = Run(icWpPath);
            if (iRes != 1)
            {
                MessageBox.Show("Error trying to start the word processing package " + icWpPath, "Word Processing Start", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return iRes;
        }
    }
}
