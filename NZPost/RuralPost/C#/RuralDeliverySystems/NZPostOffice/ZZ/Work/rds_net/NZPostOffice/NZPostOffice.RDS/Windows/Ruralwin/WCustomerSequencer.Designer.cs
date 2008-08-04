using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WCustomerSequencer
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_unseq;

        public URdsDw dw_seq;

        public UCb cb_seq;

        public UCb cb_unseq;

        public GroupBox gb_seq;

        public GroupBox gb_unseq;

        public UCb cb_close;

        public UCb cb_save;

        public Button cb_stripmaker;

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_unseq = new URdsDw();
            this.dw_unseq.DataObject = new DUnseqAddresses();
            this.dw_seq = new URdsDw();
            this.dw_seq.DataObject = new DSeqAddresses();
            this.cb_seq = new UCb();
            this.cb_unseq = new UCb();
            this.gb_seq = new GroupBox();
            this.gb_unseq = new GroupBox();
            this.cb_close = new UCb();
            this.cb_save = new UCb();
            this.cb_stripmaker = new Button();
            this.dw_addr_sequence_ind = new URdsDw();
            this.dw_addr_sequence_ind.DataObject = new DAddrSequenceInd();
            Controls.Add(dw_unseq);
            Controls.Add(dw_seq);
            Controls.Add(cb_seq);
            Controls.Add(cb_unseq);
            Controls.Add(gb_seq);
            Controls.Add(gb_unseq);
            Controls.Add(cb_close);
            Controls.Add(cb_save);
            Controls.Add(cb_stripmaker);
            Controls.Add(dw_addr_sequence_ind);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Address Sequencer";
            this.Height = 567;
            this.Width = 798;
            this.Top = 1;
            this.Left = 1;
            this.Name = "w_customer_sequencer";
            // 
            // st_label
            // 
            st_label.Text = "w_customer_sequencer";
            st_label.Top = 502;
            st_label.Left = 3;
            // 
            // dw_unseq
            // 

            dw_unseq.TabIndex = 1;
            dw_unseq.Height = 412;
            dw_unseq.Width = 373;
            dw_unseq.Top = 48;
            dw_unseq.Left = 10;
            dw_unseq.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //dw_unseq.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_unseq_constructor);
            //((DUnseqAddresses)dw_unseq.DataObject).CellClick += new EventHandler(dw_unseq_clicked);
            //((DUnseqAddresses)dw_unseq.DataObject).CellMouseEnter += new DataGridViewCellEventHandler(dw_unseq_CellMouseEnter);
            // 
            // dw_seq
            // 

            //? dw_seq.hscrollbar = true;

            dw_seq.TabIndex = 7;
            dw_seq.Height = 412;
            dw_seq.Width = 373;
            dw_seq.Top = 48;
            dw_seq.Left = 403;
            dw_seq.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //dw_seq.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_seq_constructor);
            //((DSeqAddresses)dw_seq.DataObject).CellClick += new EventHandler(dw_seq_clicked);
            // 
            // cb_seq
            // 
            cb_seq.Text = "Sequence Addresses";
            cb_seq.Enabled = false;
            cb_seq.TabIndex = 5;
            cb_seq.Width = 123;
            cb_seq.Top = 465;
            cb_seq.Left = 260;
            cb_seq.Click += new EventHandler(cb_seq_clicked);
            // 
            // cb_unseq
            // 
            cb_unseq.Text = "Unsequence Addresses";
            cb_unseq.Enabled = false;
            cb_unseq.TabIndex = 4;
            cb_unseq.Width = 123;
            cb_unseq.Top = 465;
            cb_unseq.Left = 655;
            cb_unseq.Click += new EventHandler(cb_unseq_clicked);
            // 
            // gb_seq
            // 
            gb_seq.Text = "Sequenced Addresses";
            gb_seq.BackColor = System.Drawing.SystemColors.Control;
            gb_seq.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_seq.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_seq.TabIndex = 6;
            gb_seq.Height = 463;
            gb_seq.Width = 387;
            gb_seq.Top = 32;
            gb_seq.Left = 396;
            // 
            // gb_unseq
            // 
            gb_unseq.Text = "Unsequenced Addresses";
            gb_unseq.BackColor = System.Drawing.SystemColors.Control;
            gb_unseq.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_unseq.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_unseq.TabIndex = 3;
            gb_unseq.Height = 463;
            gb_unseq.Width = 387;
            gb_unseq.Top = 32;
            gb_unseq.Left = 3;
            // 
            // cb_close
            // 
            this.CancelButton = cb_close;
            cb_close.Text = "&Close";
            cb_close.TabIndex = 2;
            cb_close.Top = 8;
            cb_close.Left = 706;
            cb_close.Click += new EventHandler(cb_close_clicked);
            // 
            // cb_save
            // 
            this.AcceptButton = cb_save;
            cb_save.Text = "&Save";
            cb_save.TabIndex = 1;
            cb_save.Width = 79;
            cb_save.Top = 8;
            cb_save.Left = 620;
            cb_save.Click += new EventHandler(cb_save_clicked);
            // 
            // cb_stripmaker
            // 
            cb_stripmaker.Text = "Strip&maker";
            cb_stripmaker.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_stripmaker.TabIndex = 3;
            cb_stripmaker.Height = 23;
            cb_stripmaker.Width = 75;
            cb_stripmaker.Top = 8;
            cb_stripmaker.Left = 537;
            cb_stripmaker.Click += new EventHandler(cb_stripmaker_clicked);
            // 
            // dw_addr_sequence_ind
            // 
            dw_addr_sequence_ind.TabIndex = 1;
            dw_addr_sequence_ind.Height = 24;
            dw_addr_sequence_ind.Width = 519;
            dw_addr_sequence_ind.Top = 8;
            dw_addr_sequence_ind.Left = 12;
            //dw_addr_sequence_ind.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_addr_sequence_ind_constructor);
            //((DAddrSequenceInd)dw_addr_sequence_ind.DataObject).CheckedChanged += new EventHandler(dw_addr_sequence_ind_itemchanged);
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

    }
}
