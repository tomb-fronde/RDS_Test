using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared.VisualComponents;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractFreightAllocations
    {
        // TJB  RPCR_025  8-June-2011: New
        // See also  RDS/Windows/Ruralwin/WContract2001
        //      and  Entity/Ruraldw/FreightAllocations
        // TJB 9-June-2011: Changed layout to more-closely match spec
        //
        // All event handling except PBU moved to DFreightAllocations
        // PBU-handling code copied from DContract.  Provides drop-down
        // list of PBU codes.

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        
        private void InitializeComponent()
        {
            this.n_39995586 = new System.Windows.Forms.Label();
            this.pbu_id = new Metex.Windows.DataEntityCombo();
            this.pbu_code_t = new System.Windows.Forms.Label();
            this.active_ind = new System.Windows.Forms.CheckBox();
            this.pct4 = new System.Windows.Forms.Label();
            this.tot_pct = new System.Windows.Forms.TextBox();
            this.ecl_t = new System.Windows.Forms.Label();
            this.reachmedia_t = new System.Windows.Forms.Label();
            this.psg_t = new System.Windows.Forms.Label();
            this.ecl_pct = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.reachmedia_pct = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.psg_pct = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.pct1 = new System.Windows.Forms.Label();
            this.pct2 = new System.Windows.Forms.Label();
            this.pct3 = new System.Windows.Forms.Label();
            this.totmsg = new System.Windows.Forms.TextBox();
            this.allocations_t = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = false;
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FreightAllocations);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // n_39995586
            // 
            this.n_39995586.Location = new System.Drawing.Point(0, 0);
            this.n_39995586.Name = "n_39995586";
            this.n_39995586.Size = new System.Drawing.Size(100, 23);
            this.n_39995586.TabIndex = 0;
            // 
            // pbu_id
            // 
            this.pbu_id.AutoRetrieve = true;
            this.pbu_id.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbu_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PbuId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pbu_id.DisplayMember = "PbuCode";
            this.pbu_id.DropDownWidth = 240;
            this.pbu_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pbu_id.Location = new System.Drawing.Point(182, 142);
            this.pbu_id.Name = "pbu_id";
            this.pbu_id.Size = new System.Drawing.Size(82, 21);
            this.pbu_id.TabIndex = 4;
            this.pbu_id.Value = null;
            this.pbu_id.ValueMember = "PbuId";
            this.pbu_id.LostFocus += new System.EventHandler(this.pbu_id_LostFocus);
            this.pbu_id.SelectedIndexChanged += new System.EventHandler(this.pbu_id_SelectedIndexChanged);
            this.pbu_id.Click += new System.EventHandler(this.pbu_id_Click);
            // 
            // pbu_code_t
            // 
            this.pbu_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pbu_code_t.Location = new System.Drawing.Point(108, 146);
            this.pbu_code_t.Name = "pbu_code_t";
            this.pbu_code_t.Size = new System.Drawing.Size(67, 13);
            this.pbu_code_t.TabIndex = 180;
            this.pbu_code_t.Text = "PBU Code";
            this.pbu_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // active_ind
            // 
            this.active_ind.AutoSize = true;
            this.active_ind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "FrActiveInd", true));
            this.active_ind.Location = new System.Drawing.Point(44, 26);
            this.active_ind.Name = "active_ind";
            this.active_ind.Size = new System.Drawing.Size(100, 17);
            this.active_ind.TabIndex = 0;
            this.active_ind.Text = "Active Indicator";
            this.active_ind.UseVisualStyleBackColor = true;
            // 
            // pct4
            // 
            this.pct4.AutoSize = true;
            this.pct4.Location = new System.Drawing.Point(334, 145);
            this.pct4.Name = "pct4";
            this.pct4.Size = new System.Drawing.Size(15, 13);
            this.pct4.TabIndex = 171;
            this.pct4.Text = "%";
            // 
            // tot_pct
            // 
            this.tot_pct.BackColor = System.Drawing.SystemColors.Control;
            this.tot_pct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tot_pct.Location = new System.Drawing.Point(287, 145);
            this.tot_pct.Name = "tot_pct";
            this.tot_pct.Size = new System.Drawing.Size(41, 13);
            this.tot_pct.TabIndex = 172;
            this.tot_pct.TabStop = false;
            this.tot_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ecl_t
            // 
            this.ecl_t.Location = new System.Drawing.Point(102, 57);
            this.ecl_t.Name = "ecl_t";
            this.ecl_t.Size = new System.Drawing.Size(27, 13);
            this.ecl_t.TabIndex = 173;
            this.ecl_t.Text = "ECL";
            this.ecl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // reachmedia_t
            // 
            this.reachmedia_t.Location = new System.Drawing.Point(102, 85);
            this.reachmedia_t.Name = "reachmedia_t";
            this.reachmedia_t.Size = new System.Drawing.Size(71, 13);
            this.reachmedia_t.TabIndex = 174;
            this.reachmedia_t.Text = "Reach Media";
            this.reachmedia_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // psg_t
            // 
            this.psg_t.Location = new System.Drawing.Point(102, 114);
            this.psg_t.Name = "psg_t";
            this.psg_t.Size = new System.Drawing.Size(29, 13);
            this.psg_t.TabIndex = 175;
            this.psg_t.Text = "PSG";
            this.psg_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ecl_pct
            // 
            this.ecl_pct.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FrEclPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ecl_pct.EditMask = "###";
            this.ecl_pct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ecl_pct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ecl_pct.Location = new System.Drawing.Point(291, 53);
            this.ecl_pct.Mask = "990";
            this.ecl_pct.Name = "ecl_pct";
            this.ecl_pct.PromptChar = ' ';
            this.ecl_pct.Size = new System.Drawing.Size(41, 20);
            this.ecl_pct.TabIndex = 1;
            this.ecl_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ecl_pct.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ecl_pct.Value = "";
            // 
            // reachmedia_pct
            // 
            this.reachmedia_pct.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FrReachmediaPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.reachmedia_pct.EditMask = "###";
            this.reachmedia_pct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.reachmedia_pct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.reachmedia_pct.Location = new System.Drawing.Point(291, 81);
            this.reachmedia_pct.Mask = "990";
            this.reachmedia_pct.Name = "reachmedia_pct";
            this.reachmedia_pct.PromptChar = ' ';
            this.reachmedia_pct.Size = new System.Drawing.Size(41, 20);
            this.reachmedia_pct.TabIndex = 2;
            this.reachmedia_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.reachmedia_pct.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.reachmedia_pct.Value = "";
            // 
            // psg_pct
            // 
            this.psg_pct.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FrPsgPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.psg_pct.EditMask = "###";
            this.psg_pct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.psg_pct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.psg_pct.Location = new System.Drawing.Point(291, 110);
            this.psg_pct.Mask = "990";
            this.psg_pct.Name = "psg_pct";
            this.psg_pct.PromptChar = ' ';
            this.psg_pct.Size = new System.Drawing.Size(41, 20);
            this.psg_pct.TabIndex = 3;
            this.psg_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.psg_pct.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.psg_pct.Value = "";
            // 
            // pct1
            // 
            this.pct1.AutoSize = true;
            this.pct1.Location = new System.Drawing.Point(335, 57);
            this.pct1.Name = "pct1";
            this.pct1.Size = new System.Drawing.Size(15, 13);
            this.pct1.TabIndex = 176;
            this.pct1.Text = "%";
            // 
            // pct2
            // 
            this.pct2.AutoSize = true;
            this.pct2.Location = new System.Drawing.Point(335, 85);
            this.pct2.Name = "pct2";
            this.pct2.Size = new System.Drawing.Size(15, 13);
            this.pct2.TabIndex = 177;
            this.pct2.Text = "%";
            // 
            // pct3
            // 
            this.pct3.AutoSize = true;
            this.pct3.Location = new System.Drawing.Point(335, 114);
            this.pct3.Name = "pct3";
            this.pct3.Size = new System.Drawing.Size(15, 13);
            this.pct3.TabIndex = 178;
            this.pct3.Text = "%";
            // 
            // totmsg
            // 
            this.totmsg.BackColor = System.Drawing.SystemColors.Control;
            this.totmsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totmsg.ForeColor = System.Drawing.Color.Red;
            this.totmsg.Location = new System.Drawing.Point(361, 102);
            this.totmsg.Multiline = true;
            this.totmsg.Name = "totmsg";
            this.totmsg.Size = new System.Drawing.Size(155, 37);
            this.totmsg.TabIndex = 179;
            this.totmsg.TabStop = false;
            this.totmsg.Text = "The total allocation must add \r\nup to exactly 100%";
            // 
            // allocations_t
            // 
            this.allocations_t.AutoSize = true;
            this.allocations_t.Location = new System.Drawing.Point(281, 34);
            this.allocations_t.Name = "allocations_t";
            this.allocations_t.Size = new System.Drawing.Size(64, 13);
            this.allocations_t.TabIndex = 181;
            this.allocations_t.Text = "Allocation %";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(281, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 183;
            this.label2.Text = "======";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DContractFreightAllocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allocations_t);
            this.Controls.Add(this.totmsg);
            this.Controls.Add(this.pct3);
            this.Controls.Add(this.pct2);
            this.Controls.Add(this.pct1);
            this.Controls.Add(this.psg_t);
            this.Controls.Add(this.reachmedia_t);
            this.Controls.Add(this.ecl_t);
            this.Controls.Add(this.tot_pct);
            this.Controls.Add(this.pct4);
            this.Controls.Add(this.psg_pct);
            this.Controls.Add(this.reachmedia_pct);
            this.Controls.Add(this.ecl_pct);
            this.Controls.Add(this.active_ind);
            this.Controls.Add(this.pbu_code_t);
            this.Controls.Add(this.pbu_id);
            this.Controls.Add(this.label2);
            this.Name = "DContractFreightAllocations";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void pbu_id_LostFocus(object sender, System.EventArgs e)
        {
            this.pbu_id.DisplayMember = "PbuCode";
        }

        void pbu_id_Click(object sender, System.EventArgs e)
        {
            if (this.pbu_id.DroppedDown)
            {
                this.pbu_id.DisplayMember = "";
            }
            else
            {
                this.pbu_id.DisplayMember = "PbuCode";
            }
        }

        void pbu_id_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int li_index = this.pbu_id.SelectedIndex;
            this.pbu_id.DisplayMember = "PbuCode";
            this.pbu_id.SelectedIndex = li_index;
            this.AcceptText();

            // if the column is not checked in itemchanged event below is not needed
            if (this.RowCount > 0)
            {
                this.OnItemChanged(this.pbu_id, new System.EventArgs());
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                return;
            }

            if(e.NewIndex >= 0)
            {
                if (((FreightAllocations)(bindingSource.List[e.NewIndex])).IsNew)
                {
                }
            }
        }

        #endregion

        private System.Windows.Forms.Label n_39995586;
        private Metex.Windows.DataEntityCombo pbu_id;
        private System.Windows.Forms.Label pbu_code_t;
        private System.Windows.Forms.CheckBox active_ind;
        private System.Windows.Forms.Label pct4;
        private System.Windows.Forms.TextBox tot_pct;
        private System.Windows.Forms.Label ecl_t;
        private System.Windows.Forms.Label reachmedia_t;
        private System.Windows.Forms.Label psg_t;
        //private System.Windows.Forms.TextBox ecl_pct;
        //private System.Windows.Forms.TextBox reachmedia_pct;
        //private System.Windows.Forms.TextBox psg_pct;
        private NumericalMaskedTextBox ecl_pct;
        private NumericalMaskedTextBox reachmedia_pct;
        private NumericalMaskedTextBox psg_pct;
        private System.Windows.Forms.Label pct1;
        private System.Windows.Forms.Label pct2;
        private System.Windows.Forms.Label pct3;
        private System.Windows.Forms.TextBox totmsg;
        private System.Windows.Forms.Label allocations_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
