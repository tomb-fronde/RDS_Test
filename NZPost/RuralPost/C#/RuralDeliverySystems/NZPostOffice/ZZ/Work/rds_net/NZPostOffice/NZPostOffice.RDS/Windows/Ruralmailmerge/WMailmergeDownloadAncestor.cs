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

namespace NZPostOffice.RDS.Windows.Ruralmailmerge
{
    public partial class WMailmergeDownloadAncestor : WMaster
    {
        #region Define
        public NWp inv_wp;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_5;

        public Button cb_4;

        public Button cb_wppath;

        public Button cb_close;

        public Button cb_ok;

        public Label st_5;

        public TextBox sle_oddumpto;

        public TextBox sle_custdumpto;

        public Label st_4;

        public Label st_3;

        public TextBox sle_odtemplate;

        public TextBox sle_custtemplate;

        public Label st_2;

        public Label st_wppath;

        public TextBox sle_wppath;

        public URdsDw dw_download;

        #endregion

        public WMailmergeDownloadAncestor()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_5 = new Button();
            this.cb_4 = new Button();
            this.cb_wppath = new Button();
            this.cb_close = new Button();
            this.cb_ok = new Button();
            this.st_5 = new Label();
            this.sle_oddumpto = new TextBox();
            this.sle_custdumpto = new TextBox();
            this.st_4 = new Label();
            this.st_3 = new Label();
            this.sle_odtemplate = new TextBox();
            this.sle_custtemplate = new TextBox();
            this.st_2 = new Label();
            this.st_wppath = new Label();
            this.sle_wppath = new TextBox();
            this.dw_download = new URdsDw();
            this.dw_download.DataObject = new DMailmergeCustDownloadData();
            Controls.Add(cb_5);
            Controls.Add(cb_4);
            Controls.Add(cb_wppath);
            Controls.Add(cb_close);
            Controls.Add(cb_ok);
            Controls.Add(st_5);
            Controls.Add(sle_oddumpto);
            Controls.Add(sle_custdumpto);
            Controls.Add(st_4);
            Controls.Add(st_3);
            Controls.Add(sle_odtemplate);
            Controls.Add(sle_custtemplate);
            Controls.Add(st_2);
            Controls.Add(st_wppath);
            Controls.Add(sle_wppath);
            Controls.Add(dw_download);
            this.Text = "Mail Merge";
            this.Size = new Size(551, 189);
            this.Location = new Point(235, 120);
          
            // 
            // cb_5
            // 
            cb_5.Text = "Bro&wse...";
            cb_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_5.TabIndex = 4;
            cb_5.Size = new Size(64, 22);
            cb_5.Location=new Point(474,60);
            cb_5.Click += new EventHandler(cb_5_clicked);
         
            // 
            // cb_4
            // 
            cb_4.Text = "B&rowse...";
            cb_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_4.TabIndex = 1;
            cb_4.Size = new Size(64, 22);
            cb_4.Location=new Point(474,35);
            cb_4.Click += new EventHandler(cb_4_clicked);
           
            // 
            // cb_wppath
            // 
            cb_wppath.Text = "&Browse...";
            cb_wppath.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_wppath.TabIndex = 2;
            cb_wppath.Size = new Size(64, 22);
            cb_wppath.Location=new Point(474,10);
            cb_wppath.Click += new EventHandler(cb_wppath_clicked);
          
            // 
            // cb_close
            // 
            this.CancelButton = cb_close;
            cb_close.Text = "&Close";
            cb_close.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_close.TabIndex = 10;
            cb_close.Size = new Size(64, 24);
            cb_close.Location=new Point(312,136);
            cb_close.Click += new EventHandler(cb_close_clicked);
         
            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_ok.TabIndex = 9;
            cb_ok.Size = new Size(64, 24);
            cb_ok.Location = new Point(200, 136);
          
            // 
            // st_5
            // 
            st_5.TabStop = false;
            st_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_5.Text = "Dump Data to:";
            st_5.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
            st_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_5.Size = new Size(71, 18);
            st_5.Location = new Point(47, 114) ;
          
            // 
            // sle_oddumpto
            // 
            sle_oddumpto.ReadOnly = true;
            sle_oddumpto.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
            sle_oddumpto.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_oddumpto.TabIndex = 8;
            sle_oddumpto.Size = new Size(343, 19);
            sle_oddumpto.Location = new Point(125, 110); 
            
            // 
            // sle_custdumpto
            // 
            sle_custdumpto.ReadOnly = true;
            sle_custdumpto.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
            sle_custdumpto.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_custdumpto.TabIndex = 5;
            sle_custdumpto.Size = new Size(343, 19);
            sle_custdumpto.Location=new Point(125,86);
           
            // 
            // st_4
            // 
            st_4.TabStop = false;
            st_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_4.Text = "Dump Data to:";
            st_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_4.Size = new Size(71, 18);
            st_4.Location=new Point( 47,89);
           
            // 
            // st_3
            // 
            st_3.TabStop = false;
            st_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_3.Text = "Owner Driver Document:";
            //?st_3.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_3.Size = new Size(119, 18);
            st_3.Top = 66;
           
            // 
            // sle_odtemplate
            // 
            sle_odtemplate.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_odtemplate.TabIndex = 7;
            sle_odtemplate.Size = new Size(343, 20);
            sle_odtemplate.Location = new Point(125, 61);
           
            // 
            // sle_custtemplate
            // 
            sle_custtemplate.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_custtemplate.TabIndex = 3;
            sle_custtemplate.Size = new Size(343, 19);
            sle_custtemplate.Location = new Point(125, 37);
            
            // 
            // st_2
            // 
            st_2.TabStop = false;
            st_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_2.Text = "Customer Document:";
            //?st_2.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_2.Width = 102;
            st_2.Location = new Point(16, 41);

            // 
            // st_wppath
            // 
            st_wppath.TabStop = false;
            st_wppath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_wppath.Text = "Word Processor Path:";
            //?st_wppath.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_wppath.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_wppath.Size = new Size(106, 18);
            st_wppath.Location = new Point(12, 15);
           
            // 
            // sle_wppath
            // 
            sle_wppath.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_wppath.TabIndex = 6;
            sle_wppath.Size = new Size(343, 19);
            sle_wppath.Location = new Point(125, 12);
           
            // 
            // dw_download
            // 
            dw_download.TabIndex = 11;
            dw_download.Size = new Size(108, 90);
            dw_download.Location = new Point(32, 176);
            dw_download.Visible = false;
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

        #region Methods
        public override void pfc_preopen()
        {
            inv_wp = new NWp();
            sle_wppath.Text = StaticVariables.gnv_app.ist_dde_parameters.wordprocessorpath;


            sle_custtemplate.Text = StaticVariables.gnv_app.ist_dde_parameters.customertemplate;
            //pp! added
            //!sle_custtemplate.Text = "C:\\Program Files\\Rural Post\\RDS.NET\\CustomerTemplate.dot";
            sle_custtemplate.Text = StaticFunctions.ConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles",
                "CustomerTemplate", "C:\\Program Files\\Rural Post\\RDS.NET\\CustomerTemplate.dot");
                ;


            sle_odtemplate.Text = StaticVariables.gnv_app.ist_dde_parameters.ownerdrivertemplate;
            //pp! added
            //!sle_odtemplate.Text = "C:\\Program Files\\Rural Post\\RDS.NET\\OwnerDriverTemplate.dot";
            sle_odtemplate.Text = StaticFunctions.ConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles",
                "OwnerDriverTemplate", "C:\\Program Files\\Rural Post\\RDS.NET\\OwnerDriverTemplate.dot");


            sle_custdumpto.Text = StaticVariables.gnv_app.ist_dde_parameters.custmailmergedumpfile;
            sle_oddumpto.Text = StaticVariables.gnv_app.ist_dde_parameters.ownerdrivermailmergedumpfile;
            //?dw_download.settransobject(StaticVariables.sqlca);
            dw_download.SetSqlSelect(StaticVariables.gnv_app.of_get_parameters().stringparm);
            // dw_download.retrieve ( )
            //? inv_wp.uf_set_dde_name(StaticVariables.gnv_app.ist_dde_parameters.ddetopicname);
            if (!(inv_wp.uf_wp_path_set(sle_wppath.Text)))
            {
                cb_wppath.Visible = true;
                sle_wppath.Visible = true;
                st_wppath.Visible = true;
            }
            else
            {
                cb_wppath.Visible = false;
                sle_wppath.Visible = false;
                st_wppath.Visible = false;
            }
        }

        public override void show()
        {
            //? this.PostEvent("ue_aftershow");
        }

        public virtual bool wf_check_cust_files()
        {
            string sfile;
            sfile = sle_custtemplate.Text;
            if (!(File.Exists(sfile)))
            {
                MessageBox.Show("Mail merge template " + sfile + " does not exist", "Customer Mail Merge Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        public virtual bool wf_check_od_files()
        {
            string sfile;
            sfile = sle_odtemplate.Text;
            if (!(File.Exists(sle_odtemplate.Text)))
            {
                MessageBox.Show("Mail merge template " + sfile + " does not exist", "Customer Mail Merge Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        public virtual void ue_afterclicked()
        {
        }

        #endregion

        #region Events
        public virtual void cb_5_clicked(object sender, EventArgs e)
        {
            string sPathName = string.Empty;
            string sFileName = string.Empty;
            DialogResult li_ret;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Document|*.doc|Word Template|*.dot|All Files|*.*";
            openFileDialog.Title = "Document  for Owner Driver Mail Merge";
            openFileDialog.DefaultExt = "DOC";
            openFileDialog.InitialDirectory = sPathName;
            openFileDialog.FileName = sFileName;
            li_ret = openFileDialog.ShowDialog();
            if (li_ret == DialogResult.OK)
            {
                sPathName = openFileDialog.FileName;
                // GetFileOpenName("Document  for Owner Driver Mail Merge", sPathName, sFileName, "DOC", "Word Document,*.doc,Word Template,*.dot,All Files,*.*");
                if (sPathName != "")
                {
                    sle_odtemplate.Text = sPathName;
                }
            }
        }

        public virtual void cb_4_clicked(object sender, EventArgs e)
        {
            string sPathName = string.Empty;
            string sFileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Document|*.doc|Word Template|*.dot|All Files|*.*";
            openFileDialog.Title = "Document  for Customer Mail Merge";
            openFileDialog.DefaultExt = "DOC";
            openFileDialog.InitialDirectory = sPathName;
            openFileDialog.FileName = sFileName;
            // GetFileOpenName("Document  for Customer Mail Merge", sPathName, sFileName, "DOC", "Word Document,*.doc,Word Template,*.dot,All Files,*.*");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sPathName = openFileDialog.FileName;
                sle_custtemplate.Text = sPathName;
            }
        }

        public virtual void cb_wppath_clicked(object sender, EventArgs e)
        {
            string sPathName = string.Empty;
            string sFileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Programs| *.exe;*.pif;*.com;*.bat";
            openFileDialog.Title = "Word Processor";
            openFileDialog.DefaultExt = "EXE";
            openFileDialog.InitialDirectory = sPathName;
            openFileDialog.FileName = sFileName;
            // GetFileOpenName("Word Processor", sPathName, sFileName, "EXE", "Programs, *.exe;*.pif;*.com;*.bat");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sPathName = openFileDialog.FileName;
                sle_wppath.Text = sPathName;
            }
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Close();
        }
        #endregion
    }
}