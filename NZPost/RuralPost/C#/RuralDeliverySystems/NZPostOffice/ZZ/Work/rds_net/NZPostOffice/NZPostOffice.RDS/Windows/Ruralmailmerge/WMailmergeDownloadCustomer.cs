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
    public partial class WMailmergeDownloadCustomer : WMailmergeDownloadAncestor
    {
        #region Define

        public int ilparm;

        public bool ibUpdatePrintedOn;

        private System.ComponentModel.IContainer components = null;

        public Label st_current_directory;

        public ListBox lb_dirlist;

        public CheckBox cbx_auto;

        #endregion

        public WMailmergeDownloadCustomer()
        {
            this.InitializeComponent();

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.st_current_directory = new System.Windows.Forms.Label();
            this.lb_dirlist = new System.Windows.Forms.ListBox();
            this.cbx_auto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cb_5
            // 
            this.cb_5.Visible = false;
            // 
            // cb_4
            // 
            this.cb_4.Location = new System.Drawing.Point(474, 5);
            // 
            // cb_wppath
            // 
            this.cb_wppath.Location = new System.Drawing.Point(474, 55);
            // 
            // cb_close
            // 
            this.cb_close.Location = new System.Drawing.Point(312, 83);
            // 
            // cb_ok
            // 
            this.cb_ok.Location = new System.Drawing.Point(200, 83);
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // st_5
            // 
            this.st_5.Visible = false;
            // 
            // sle_oddumpto
            // 
            this.sle_oddumpto.Visible = false;
            // 
            // sle_custdumpto
            // 
            this.sle_custdumpto.Location = new System.Drawing.Point(125, 32);
            this.sle_custdumpto.Size = new System.Drawing.Size(342, 20);
            // 
            // st_4
            // 
            this.st_4.Location = new System.Drawing.Point(36, 34);
            this.st_4.Size = new System.Drawing.Size(83, 15);
            // 
            // st_3
            // 
            this.st_3.Visible = false;
            // 
            // sle_odtemplate
            // 
            this.sle_odtemplate.Visible = false;
            // 
            // sle_custtemplate
            // 
            this.sle_custtemplate.Location = new System.Drawing.Point(125, 7);
            // 
            // st_2
            // 
            this.st_2.Location = new System.Drawing.Point(7, 10);
            this.st_2.Size = new System.Drawing.Size(113, 14);
            // 
            // st_wppath
            // 
            this.st_wppath.Location = new System.Drawing.Point(6, 58);
            this.st_wppath.Size = new System.Drawing.Size(113, 18);
            // 
            // sle_wppath
            // 
            this.sle_wppath.Location = new System.Drawing.Point(125, 57);
            // 
            // dw_download
            // 
            this.dw_download.FireConstructor = true;
            this.dw_download.Location = new System.Drawing.Point(17, 142);
            this.dw_download.Size = new System.Drawing.Size(503, 326);
            // 
            // st_current_directory
            // 
            this.st_current_directory.BackColor = System.Drawing.Color.White;
            this.st_current_directory.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.st_current_directory.Location = new System.Drawing.Point(21, 149);
            this.st_current_directory.Name = "st_current_directory";
            this.st_current_directory.Size = new System.Drawing.Size(217, 18);
            this.st_current_directory.TabIndex = 14;
            this.st_current_directory.Text = "none";
            this.st_current_directory.Visible = false;
            // 
            // lb_dirlist
            // 
            this.lb_dirlist.BackColor = System.Drawing.Color.White;
            this.lb_dirlist.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lb_dirlist.ItemHeight = 14;
            this.lb_dirlist.Location = new System.Drawing.Point(125, 181);
            this.lb_dirlist.Name = "lb_dirlist";
            this.lb_dirlist.Size = new System.Drawing.Size(110, 46);
            this.lb_dirlist.TabIndex = 12;
            this.lb_dirlist.Visible = false;
            // 
            // cbx_auto
            // 
            this.cbx_auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cbx_auto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_auto.Location = new System.Drawing.Point(12, 85);
            this.cbx_auto.Name = "cbx_auto";
            this.cbx_auto.Size = new System.Drawing.Size(143, 19);
            this.cbx_auto.TabIndex = 15;
            this.cbx_auto.Text = "Automatic Merging";
            // 
            // WMailmergeDownloadCustomer
            // 
            this.ClientSize = new System.Drawing.Size(547, 117);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Controls.Add(this.st_current_directory);
            this.Controls.Add(this.lb_dirlist);
            this.Controls.Add(this.cbx_auto);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "WMailmergeDownloadCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public override void open()
        {
            base.open();
            ibUpdatePrintedOn = StaticVariables.gnv_app.of_get_parameters().printedonparm.GetValueOrDefault();
            ilparm = (int)StaticMessage.DoubleParm;
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

            //!sle_custdumpto.Text = "C:\\CustomerData.xls";
            sle_custdumpto.Text =  StaticFunctions.ConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles",
                "CustMailMergeDumpFile", "C:\\CustomerData.xls");
        }

        public virtual int uf_update_printedon()
        {
            Cursor.Current = Cursors.WaitCursor;
            int i;
            int? lCustID = 0;
            for (i = 0; i < dw_download.RowCount; i++)
            {
                lCustID = dw_download.GetItem<MailmergeCustDownloadData>(i).RDSCustomerCustId;
                //? UPDATE rds_customer SET printedon =  ( select today ( *) from sys.dummy ) WHERE customer.cust_id = :lCustId ;
            }
            //? Commit;
            bool update_customer = RDSDataService.UpdatePrintedon(lCustID);
            // if (StaticVariables.sqlca.SQLCode == -(1)) 
            if (!update_customer)
            {
                MessageBox.Show("Cannot update customer printed date", "Date Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return 1;
        }

        #region Events
        public override void cb_close_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Changed related data window  ( d_mailmerge_cust_download_data)
            //  to include unit number and road suffix changes.
            if (!(inv_wp.uf_wp_path_set(sle_wppath.Text)))
            {
                MessageBox.Show("Please check path and filename of word processor", "Word Processor Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_wppath.Visible = true;
                sle_wppath.Visible = true;
                st_wppath.Visible = true;
                return;
            }
            else
            {
                cb_wppath.Visible = false;
                sle_wppath.Visible = false;
                st_wppath.Visible = false;
            }
            Cursor.Current = Cursors.WaitCursor;
            if (!(wf_check_cust_files()))
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            if (dw_download.Retrieve(new object[] { StaticVariables.gnv_app.of_get_parameters().stringparm }) > 0)
            {
                int ls = 0;
                int li;
                string sseq;
                sseq = "";
                ls = dw_download.SaveAs(sle_custdumpto.Text, "excel5");//, true);
                if (ls != 1)
                {
                    MessageBox.Show("There may be an open form letter in your word processor \n" + "using " + sle_custdumpto.Text + "  ( or some other problem).\n" + "Please close it then try again", "Non-fatal DDE error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        //!pp! this line hangs
                        if (inv_wp.uf_doc_create(sle_custtemplate.Text) < 1)
                        {
                            if (inv_wp.uf_close_channel() != 1)
                            {
                                // messagebox ( "Non-fatal DDE Error", &
                                // 			"Unable to close link with the word processor \n" &
                                // 			+" ( probably because your PC is very slow or there's too much data) but it's OK")
                            }
                            // return
                        }
                        inv_wp.uf_macro_run("mmerge");
                        if (inv_wp.uf_close_channel() != 1)
                        {
                            // messagebox ( "Non-fatal DDE Error", &
                            // 			"Unable to close link with the word processor \n" &
                            // 			+" ( probably because your PC is very slow or there's too much data) but it's OK")
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            int l;
            if (st_current_directory.Text != "")
            {
                //?lb_dirlist.DirList(st_current_directory.Text + "\\*.*", 0);
            }
            StaticFunctions.SetConfigString(StaticVariables.gnv_app.of_getappinifile(), "WordProcessor", "WordProcessorPath", sle_wppath.Text);
            StaticFunctions.SetConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles", "CustomerTemplate", sle_custtemplate.Text);
            StaticFunctions.SetConfigString(StaticVariables.gnv_app.of_getappinifile(), "MailMergeFiles", "CustMailMergeDumpFile", sle_custdumpto.Text);
            StaticVariables.gnv_app.ist_dde_parameters.wordprocessorpath = sle_wppath.Text;
            StaticVariables.gnv_app.ist_dde_parameters.customertemplate = sle_custtemplate.Text;
            StaticVariables.gnv_app.ist_dde_parameters.custmailmergedumpfile = sle_custdumpto.Text;
            Cursor.Current = Cursors.WaitCursor;
            if (ibUpdatePrintedOn)
            {
                uf_update_printedon();
            }
            this.Close();
        }
        #endregion
    }
}