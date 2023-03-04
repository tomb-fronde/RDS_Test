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

        public UCb cb_sequence;

        public UCb cb_unsequence;

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
            this.components = new System.ComponentModel.Container();
            this.dw_unseq = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_seq = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_sequence = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_unsequence = new NZPostOffice.Shared.VisualComponents.UCb();
            this.gb_seq = new System.Windows.Forms.GroupBox();
            this.gb_unseq = new System.Windows.Forms.GroupBox();
            this.cb_reverse = new System.Windows.Forms.Button();
            this.cb_addseq = new System.Windows.Forms.Button();
            this.cb_close = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_save = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_stripmaker = new System.Windows.Forms.Button();
            this.dw_addr_sequence_ind = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_seq_arrow = new System.Windows.Forms.Button();
            this.cb_unseq_arrow = new System.Windows.Forms.Button();
            this.cb_up_arrow = new System.Windows.Forms.Button();
            this.cb_down_arrow = new System.Windows.Forms.Button();
            this.rightarrow_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.leftarrow_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.uparrow_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.cb_cust_seq_up = new System.Windows.Forms.Button();
            this.downarrow_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.cb_cust_seq_down = new System.Windows.Forms.Button();
            this.cb_reassign = new System.Windows.Forms.Button();
            this.CustSeq_t = new System.Windows.Forms.Label();
            this.cb_debug = new System.Windows.Forms.Button();
            this.gb_unseq.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(3, 502);
            this.st_label.Text = "WCustomerSequencer";
            // 
            // dw_unseq
            // 
            this.dw_unseq.DataObject = null;
            this.dw_unseq.FireConstructor = false;
            this.dw_unseq.Location = new System.Drawing.Point(10, 48);
            this.dw_unseq.Name = "dw_unseq";
            this.dw_unseq.Size = new System.Drawing.Size(373, 412);
            this.dw_unseq.TabIndex = 1;
            // 
            // dw_seq
            // 
            this.dw_seq.AllowDrop = true;
            this.dw_seq.DataObject = null;
            this.dw_seq.FireConstructor = false;
            this.dw_seq.Location = new System.Drawing.Point(449, 48);
            this.dw_seq.Name = "dw_seq";
            this.dw_seq.Size = new System.Drawing.Size(373, 412);
            this.dw_seq.TabIndex = 7;
            // 
            // cb_sequence
            // 
            this.cb_sequence.Enabled = false;
            this.cb_sequence.Location = new System.Drawing.Point(260, 465);
            this.cb_sequence.Name = "cb_sequence";
            this.cb_sequence.Size = new System.Drawing.Size(123, 23);
            this.cb_sequence.TabIndex = 5;
            this.cb_sequence.Text = "Sequence Addresses";
            // 
            // cb_unsequence
            // 
            this.cb_unsequence.Enabled = false;
            this.cb_unsequence.Location = new System.Drawing.Point(701, 465);
            this.cb_unsequence.Name = "cb_unsequence";
            this.cb_unsequence.Size = new System.Drawing.Size(123, 23);
            this.cb_unsequence.TabIndex = 4;
            this.cb_unsequence.Text = "Unsequence Addresses";
            // 
            // gb_seq
            // 
            this.gb_seq.BackColor = System.Drawing.SystemColors.Control;
            this.gb_seq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_seq.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_seq.Location = new System.Drawing.Point(442, 32);
            this.gb_seq.Name = "gb_seq";
            this.gb_seq.Size = new System.Drawing.Size(387, 463);
            this.gb_seq.TabIndex = 6;
            this.gb_seq.TabStop = false;
            this.gb_seq.Text = "Sequenced Addresses";
            // 
            // gb_unseq
            // 
            this.gb_unseq.BackColor = System.Drawing.SystemColors.Control;
            this.gb_unseq.Controls.Add(this.cb_reverse);
            this.gb_unseq.Controls.Add(this.cb_addseq);
            this.gb_unseq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_unseq.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_unseq.Location = new System.Drawing.Point(3, 32);
            this.gb_unseq.Name = "gb_unseq";
            this.gb_unseq.Size = new System.Drawing.Size(387, 463);
            this.gb_unseq.TabIndex = 3;
            this.gb_unseq.TabStop = false;
            this.gb_unseq.Text = "Unsequenced Addresses";
            // 
            // cb_reverse
            // 
            this.cb_reverse.Enabled = false;
            this.cb_reverse.Location = new System.Drawing.Point(143, 433);
            this.cb_reverse.Name = "cb_reverse";
            this.cb_reverse.Size = new System.Drawing.Size(91, 22);
            this.cb_reverse.TabIndex = 1;
            this.cb_reverse.Text = "Reverse order";
            this.cb_reverse.UseVisualStyleBackColor = true;
            // 
            // cb_addseq
            // 
            this.cb_addseq.Enabled = false;
            this.cb_addseq.Location = new System.Drawing.Point(9, 433);
            this.cb_addseq.Name = "cb_addseq";
            this.cb_addseq.Size = new System.Drawing.Size(101, 23);
            this.cb_addseq.TabIndex = 0;
            this.cb_addseq.Text = "Sequence at End";
            this.cb_addseq.UseVisualStyleBackColor = true;
            // 
            // cb_close
            // 
            this.cb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_close.Location = new System.Drawing.Point(752, 8);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 2;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // cb_save
            // 
            this.cb_save.Location = new System.Drawing.Point(666, 8);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(79, 23);
            this.cb_save.TabIndex = 1;
            this.cb_save.Text = "&Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_stripmaker
            // 
            this.cb_stripmaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_stripmaker.Location = new System.Drawing.Point(583, 8);
            this.cb_stripmaker.Name = "cb_stripmaker";
            this.cb_stripmaker.Size = new System.Drawing.Size(75, 23);
            this.cb_stripmaker.TabIndex = 3;
            this.cb_stripmaker.Text = "Strip&maker";
            // 
            // dw_addr_sequence_ind
            // 
            this.dw_addr_sequence_ind.DataObject = null;
            this.dw_addr_sequence_ind.FireConstructor = false;
            this.dw_addr_sequence_ind.Location = new System.Drawing.Point(12, 8);
            this.dw_addr_sequence_ind.Name = "dw_addr_sequence_ind";
            this.dw_addr_sequence_ind.Size = new System.Drawing.Size(519, 24);
            this.dw_addr_sequence_ind.TabIndex = 1;
            // 
            // cb_seq_arrow
            // 
            this.cb_seq_arrow.Enabled = false;
            this.cb_seq_arrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_seq_arrow.Location = new System.Drawing.Point(402, 128);
            this.cb_seq_arrow.Name = "cb_seq_arrow";
            this.cb_seq_arrow.Size = new System.Drawing.Size(30, 23);
            this.cb_seq_arrow.TabIndex = 10;
            this.cb_seq_arrow.Text = ">";
            this.rightarrow_tooltip.SetToolTip(this.cb_seq_arrow, "Sequence addresses");
            this.cb_seq_arrow.UseVisualStyleBackColor = true;
            // 
            // cb_unseq_arrow
            // 
            this.cb_unseq_arrow.Enabled = false;
            this.cb_unseq_arrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_unseq_arrow.Location = new System.Drawing.Point(402, 166);
            this.cb_unseq_arrow.Name = "cb_unseq_arrow";
            this.cb_unseq_arrow.Size = new System.Drawing.Size(30, 23);
            this.cb_unseq_arrow.TabIndex = 11;
            this.cb_unseq_arrow.Text = "<";
            this.leftarrow_tooltip.SetToolTip(this.cb_unseq_arrow, "Unsequence addresses");
            this.cb_unseq_arrow.UseVisualStyleBackColor = true;
            // 
            // cb_up_arrow
            // 
            this.cb_up_arrow.Enabled = false;
            this.cb_up_arrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_up_arrow.Location = new System.Drawing.Point(401, 255);
            this.cb_up_arrow.Name = "cb_up_arrow";
            this.cb_up_arrow.Size = new System.Drawing.Size(30, 23);
            this.cb_up_arrow.TabIndex = 13;
            this.cb_up_arrow.Text = "٨";
            this.uparrow_tooltip.SetToolTip(this.cb_up_arrow, "Move up");
            this.cb_up_arrow.UseVisualStyleBackColor = true;
            // 
            // cb_down_arrow
            // 
            this.cb_down_arrow.Enabled = false;
            this.cb_down_arrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_down_arrow.Location = new System.Drawing.Point(401, 286);
            this.cb_down_arrow.Name = "cb_down_arrow";
            this.cb_down_arrow.Size = new System.Drawing.Size(30, 23);
            this.cb_down_arrow.TabIndex = 14;
            this.cb_down_arrow.Text = "v";
            this.downarrow_tooltip.SetToolTip(this.cb_down_arrow, "Move down");
            this.cb_down_arrow.UseVisualStyleBackColor = true;
            // 
            // cb_cust_seq_up
            // 
            this.cb_cust_seq_up.Enabled = false;
            this.cb_cust_seq_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cust_seq_up.Location = new System.Drawing.Point(666, 502);
            this.cb_cust_seq_up.Name = "cb_cust_seq_up";
            this.cb_cust_seq_up.Size = new System.Drawing.Size(30, 23);
            this.cb_cust_seq_up.TabIndex = 17;
            this.cb_cust_seq_up.Text = "٨";
            this.uparrow_tooltip.SetToolTip(this.cb_cust_seq_up, "Move customer up");
            this.cb_cust_seq_up.UseVisualStyleBackColor = true;
            this.cb_cust_seq_up.Click += new System.EventHandler(this.cb_cust_seq_up_Click);
            // 
            // cb_cust_seq_down
            // 
            this.cb_cust_seq_down.Enabled = false;
            this.cb_cust_seq_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cust_seq_down.Location = new System.Drawing.Point(701, 502);
            this.cb_cust_seq_down.Name = "cb_cust_seq_down";
            this.cb_cust_seq_down.Size = new System.Drawing.Size(30, 23);
            this.cb_cust_seq_down.TabIndex = 18;
            this.cb_cust_seq_down.Text = "v";
            this.downarrow_tooltip.SetToolTip(this.cb_cust_seq_down, "Move customer down");
            this.cb_cust_seq_down.UseVisualStyleBackColor = true;
            this.cb_cust_seq_down.Click += new System.EventHandler(this.cb_cust_seq_down_Click);
            // 
            // cb_reassign
            // 
            this.cb_reassign.Location = new System.Drawing.Point(180, 498);
            this.cb_reassign.Name = "cb_reassign";
            this.cb_reassign.Size = new System.Drawing.Size(110, 23);
            this.cb_reassign.TabIndex = 15;
            this.cb_reassign.Text = "Re-assign contract";
            this.cb_reassign.UseVisualStyleBackColor = true;
            // 
            // CustSeq_t
            // 
            this.CustSeq_t.AutoSize = true;
            this.CustSeq_t.Enabled = false;
            this.CustSeq_t.Location = new System.Drawing.Point(531, 508);
            this.CustSeq_t.Name = "CustSeq_t";
            this.CustSeq_t.Size = new System.Drawing.Size(123, 13);
            this.CustSeq_t.TabIndex = 19;
            this.CustSeq_t.Text = "Move selected customer";
            // 
            // cb_debug
            // 
            this.cb_debug.Location = new System.Drawing.Point(442, 501);
            this.cb_debug.Name = "cb_debug";
            this.cb_debug.Size = new System.Drawing.Size(75, 23);
            this.cb_debug.TabIndex = 20;
            this.cb_debug.Text = "Debug";
            this.cb_debug.UseVisualStyleBackColor = true;
            this.cb_debug.Click += new System.EventHandler(this.cb_debug_Click);
            // 
            // WCustomerSequencer
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(833, 533);
            this.Controls.Add(this.cb_debug);
            this.Controls.Add(this.CustSeq_t);
            this.Controls.Add(this.cb_cust_seq_down);
            this.Controls.Add(this.cb_cust_seq_up);
            this.Controls.Add(this.cb_reassign);
            this.Controls.Add(this.cb_down_arrow);
            this.Controls.Add(this.cb_up_arrow);
            this.Controls.Add(this.cb_unsequence);
            this.Controls.Add(this.cb_seq_arrow);
            this.Controls.Add(this.dw_unseq);
            this.Controls.Add(this.dw_seq);
            this.Controls.Add(this.cb_sequence);
            this.Controls.Add(this.cb_unseq_arrow);
            this.Controls.Add(this.gb_seq);
            this.Controls.Add(this.gb_unseq);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_stripmaker);
            this.Controls.Add(this.dw_addr_sequence_ind);
            this.Name = "WCustomerSequencer";
            this.Text = "Address Sequencer";
            this.Controls.SetChildIndex(this.dw_addr_sequence_ind, 0);
            this.Controls.SetChildIndex(this.cb_stripmaker, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.gb_unseq, 0);
            this.Controls.SetChildIndex(this.gb_seq, 0);
            this.Controls.SetChildIndex(this.cb_unseq_arrow, 0);
            this.Controls.SetChildIndex(this.cb_sequence, 0);
            this.Controls.SetChildIndex(this.dw_seq, 0);
            this.Controls.SetChildIndex(this.dw_unseq, 0);
            this.Controls.SetChildIndex(this.cb_seq_arrow, 0);
            this.Controls.SetChildIndex(this.cb_unsequence, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_up_arrow, 0);
            this.Controls.SetChildIndex(this.cb_down_arrow, 0);
            this.Controls.SetChildIndex(this.cb_reassign, 0);
            this.Controls.SetChildIndex(this.cb_cust_seq_up, 0);
            this.Controls.SetChildIndex(this.cb_cust_seq_down, 0);
            this.Controls.SetChildIndex(this.CustSeq_t, 0);
            this.Controls.SetChildIndex(this.cb_debug, 0);
            this.gb_unseq.ResumeLayout(false);
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

        private Button cb_seq_arrow;
        private Button cb_unseq_arrow;
        private Button cb_addseq;
        private Button cb_up_arrow;
        private Button cb_down_arrow;
        private ToolTip rightarrow_tooltip;
        private ToolTip leftarrow_tooltip;
        private ToolTip uparrow_tooltip;
        private ToolTip downarrow_tooltip;
        private Button cb_reverse;
        private Button cb_reassign;
        private Button cb_cust_seq_up;
        private Button cb_cust_seq_down;
        private Label CustSeq_t;
        private Button cb_debug;

    }
}
