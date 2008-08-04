using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using System.IO;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralmailmerge;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralmailmerge
{
    public partial class WMailmergeDownloadOwnerdriver : WMailmergeDownloadAncestor
    {
        public WMailmergeDownloadOwnerdriver()
        {
            this.InitializeComponent();
        }

        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_current_directory;

        public ListBox lb_dirlist;

        public CheckBox cbx_auto;

        #endregion

        public override void open()
        {
            base.open();
            /* if (!(lb_dirlist.DirList("*.*", 0, this.st_current_directory))) 
             {
                 st_current_directory.Text = "";
             }*/
            try
            {
                lb_dirlist.Items.AddRange(Directory.GetFiles(this.st_current_directory.Text, "*.*", SearchOption.TopDirectoryOnly));
            }
            catch (Exception e)
            {
                st_current_directory.Text = "";
            }
            // sle_oddumpto.Text='c:\OwnerDriverData.xls'
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.st_current_directory = new Label();
            this.lb_dirlist = new ListBox();
            this.cbx_auto = new CheckBox();
            Controls.Add(st_current_directory);
            Controls.Add(lb_dirlist);
            Controls.Add(cbx_auto);
            // 
            // cb_5
            // 
            this.cb_5.Top = 5;
            // 
            // cb_4
            // 
            this.cb_4.Top = 75;
            cb_4.Visible = false;
            // 
            // cb_wppath
            // 
            this.cb_wppath.Top = 55;
            // 
            // cb_close
            // 
            this.cb_close.Top = 84;
            // 
            // cb_ok
            // 
            this.cb_ok.Top = 84;
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // st_5
            // 
            this.st_5.Top = 35;
            this.st_5.Width = 120;
            this.st_5.Left = 13;
            // 
            // sle_oddumpto
            // 
            this.sle_oddumpto.Top = 35;
            // 
            // sle_custdumpto
            // 
            this.sle_custdumpto.Top = 183;
            this.sle_custdumpto.Left = 108;
            sle_custdumpto.Visible = false;
            // 
            // st_4
            // 
            this.st_4.Top = 186;
            this.st_4.Left = 30;
            st_4.Visible = false;
            // 
            // st_3
            // 
            st_3.Enabled = true;
            this.st_3.Top = 10;
            this.st_3.Width = 135;
            this.st_3.Left = -1;
            // 
            // sle_odtemplate
            // 
            this.sle_odtemplate.Top = 10;
            // 
            // sle_custtemplate
            // 
            this.sle_custtemplate.Top = 135;
            this.sle_custtemplate.Left = 140;
            sle_custtemplate.Visible = false;
            // 
            // st_2
            // 
            this.st_2.Top = 139;
            this.st_2.Left = 31;
            st_2.Visible = false;
            // 
            // st_wppath
            // 
            this.st_wppath.Top = 59;
            this.st_wppath.Width = 120;
            this.st_wppath.Left = 13;
            // 
            // sle_wppath
            // 
            this.sle_wppath.Top = 62;
            // 
            // dw_download
            // 

            this.dw_download.HorizontalScroll.Visible = true;
            this.dw_download.Height = 326;
            this.dw_download.Width = 503;
            this.dw_download.Top = 259;
            this.dw_download.Left = 69;
            // 
            // st_current_directory
            // 
            st_current_directory.TabStop = false;
            st_current_directory.Text = "none";
            st_current_directory.BackColor = System.Drawing.Color.White;
            st_current_directory.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            this.st_current_directory.Height = 18;
            this.st_current_directory.Width = 217;
            this.st_current_directory.Top = 149;
            this.st_current_directory.Left = 21;
            st_current_directory.Visible = false;
            // 
            // lb_dirlist
            // 
            lb_dirlist.BackColor = System.Drawing.Color.White;
            lb_dirlist.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            lb_dirlist.TabIndex = 12;
            this.lb_dirlist.Height = 46;
            this.lb_dirlist.Width = 110;
            this.lb_dirlist.Top = 181;
            this.lb_dirlist.Left = 125;
            lb_dirlist.Visible = false;
            // 
            // cbx_auto
            // 
            cbx_auto.Text = "Automatic Merging";
            cbx_auto.ForeColor = System.Drawing.SystemColors.WindowText;
            cbx_auto.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.cbx_auto.Height = 19;
            this.cbx_auto.Width = 137;
            this.cbx_auto.Top = 89;
            this.cbx_auto.Left = 10;

            this.sle_oddumpto.Location = new System.Drawing.Point(137, 35);
            this.sle_wppath.Location = new System.Drawing.Point(137, 62);
            this.sle_odtemplate.Location = new System.Drawing.Point(137, 10);
            this.cb_5.Location = new System.Drawing.Point(491, 5);
            this.cb_wppath.Location = new System.Drawing.Point(491, 55);

            this.Height = 136;
            this.Width = 555;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new System.Drawing.Size(571, 109);
            //?this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ResumeLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        public virtual int uf_update_printedon()
        {
            int i;
            int? lCustID;
            for (i = 0; i < dw_download.RowCount; i++)
            {
                lCustID = dw_download.GetItem<MailmergeCustDownloadData>(i).RDSCustomerCustId;
                /* UPDATE rds_customer SET printedon =  ( select today ( *) from sys.dummy  ) WHERE customer.cust_id = :lCustId ;*/
                bool update_customer = RDSDataService.UpdatePrintedon(lCustID);
            }
            return 1;
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            if (!(inv_wp.uf_wp_path_set(sle_wppath.Text)))
            {
                MessageBox.Show("Please check path and filename of word processor", "Word Processor Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_wppath.Visible = true;
                sle_wppath.Visible = true;
                st_wppath.Visible = true;
                return;
                // else
                // 	cb_wppath.Visible=false
                // 	sle_wppath.Visible=false
                // 	st_wppath.Visible=false
            }
            Cursor.Current = Cursors.WaitCursor;
            if (!(wf_check_od_files()))
            {
                return;
            }
            int lll;
            string sss;
            sss = dw_download.GetSqlSelect();
            lll = dw_download.Retrieve(new object[] { });
            Cursor.Current = Cursors.WaitCursor;
            if (lll > 0)
            {
                int ls = 0;
                int li;
                string sseq;
                sseq = "";
                //? ls = dw_download.saveas(sle_oddumpto.Text + sseq, excel5, true);
                if (ls != 1)
                {
                    MessageBox.Show("There may be an open form letter in your word processor ~r\nusing " + sle_oddumpto.Text + "  ( or some other problem).~r\nPlease close it then try again", "Non-fatal DDE error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!cbx_auto.Checked)
                {
                    this.Close();
                    return;
                }
                if (ls == 1)
                {
                    if (inv_wp.uf_open_channel() == 1)
                    {
                        if (inv_wp.uf_doc_create(sle_odtemplate.Text) < 1)
                        {
                            if (inv_wp.uf_close_channel() != 1)
                            {
                                // messagebox ( "Non-fatal DDE Error","Unable to close link with the word processor\r\n ( probably because your PC is very slow or there's too much data) but it's OK")
                            }
                            // return
                        }
                        inv_wp.uf_macro_run("mmerge");
                        if (inv_wp.uf_close_channel() != 1)
                        {
                            // messagebox ( "Non-fatal DDE Error","Unable to close link with the word processor\r\n ( probably because your PC is very slow or there's too much data) but it's OK")
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            //?int l;
            if (st_current_directory.Text != "")
            {
                lb_dirlist.Items.AddRange(Directory.GetFiles(this.st_current_directory.Text, "*.*", SearchOption.TopDirectoryOnly));// lb_dirlist.DirList(st_current_directory.Text + "\\*.*", 0);
            }
            StaticFunctions.SetConfigString(StaticVariables.gnv_app.of_getappinifile(), "WordProcessor", "WordProcessorPath", sle_wppath.Text);
            StaticFunctions.SetConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles", "OwnerDriverTemplate", sle_odtemplate.Text);
            StaticFunctions.SetConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles", "OwnerDriverMailMergeDumpFile", sle_oddumpto.Text);
            StaticVariables.gnv_app.ist_dde_parameters.wordprocessorpath = sle_wppath.Text;
            StaticVariables.gnv_app.ist_dde_parameters.ownerdrivermailmergedumpfile = sle_oddumpto.Text;
            StaticVariables.gnv_app.ist_dde_parameters.ownerdrivertemplate = sle_odtemplate.Text;
            this.Close();
        }
    }
}