using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DCustSequenceSearch
    {
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
            this.st_report = new System.Windows.Forms.Label();
            this.sortorder1 = new System.Windows.Forms.RadioButton();
            this.sortorder2 = new System.Windows.Forms.RadioButton();
            this.n_30778037 = new System.Windows.Forms.Label();
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.freq_picklist = new System.Windows.Forms.CheckBox();
            this.summaryreport = new System.Windows.Forms.CheckBox();
            this.compute_1 = new Label();// System.Windows.Forms.Panel();
            this.n_9993078 = new System.Windows.Forms.Label();
            this.n_22828842 = new System.Windows.Forms.Label();
            this.freq_bmp = new System.Windows.Forms.PictureBox();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustSequenceSearch);
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(5, 0);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(265, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Customer Counter by Delivery Days";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sortorder1
            // 
            this.sortorder1.AutoSize = true;
            this.sortorder1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sortorder1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Sortorder1", true));
            this.sortorder1.Location = new System.Drawing.Point(105, 147);
            this.sortorder1.Name = "sortorder1";
            this.sortorder1.Size = new System.Drawing.Size(140, 17);
            this.sortorder1.TabIndex = 41;
            this.sortorder1.TabStop = true;
            this.sortorder1.Text = "Sort by Sequence          ";
            this.sortorder1.UseVisualStyleBackColor = true;

            // 
            // sortorder2
            // 
            this.sortorder2.AutoSize = true;
            this.sortorder2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sortorder2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Sortorder2", true));
            this.sortorder2.Location = new System.Drawing.Point(104, 172);
            this.sortorder2.Name = "sortorder2";
            this.sortorder2.Size = new System.Drawing.Size(136, 17);
            this.sortorder2.TabIndex = 42;
            this.sortorder2.TabStop = true;
            this.sortorder2.Text = "Sort by Customer Name";
            this.sortorder2.UseVisualStyleBackColor = true;
            // 
            // n_30778037
            // 
            this.n_30778037.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_30778037.Location = new System.Drawing.Point(114, 16);
            this.n_30778037.Name = "n_30778037";
            this.n_30778037.Size = new System.Drawing.Size(113, 13);
            this.n_30778037.TabIndex = 0;
            this.n_30778037.Text = "Search Criteria";
            this.n_30778037.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sf_key
            // 
            this.sf_key.AutoRetrieve = true;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.Enabled = false;
            this.sf_key.BackColor = System.Drawing.SystemColors.Control;
            this.sf_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sf_key.ForeColor = System.Drawing.Color.Black;
            this.sf_key.Location = new System.Drawing.Point(104, 78);
            this.sf_key.Name = "sf_key";
            this.sf_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.sf_key.DataBindings[0].DataSourceNullValue = null;
            this.sf_key.Size = new System.Drawing.Size(100, 21);
            this.sf_key.TabIndex = 0;
            this.sf_key.Value = null;
            this.sf_key.ValueMember = "SfKey";
            // 
            // freq_picklist
            // 
            this.freq_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.freq_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.freq_picklist.Location = new System.Drawing.Point(179, 198);
            this.freq_picklist.Name = "freq_picklist";
            this.freq_picklist.Size = new System.Drawing.Size(26, 20);
            this.freq_picklist.TabIndex = 30;
            this.freq_picklist.Visible = false;
            // 
            // summaryreport
            // 
            this.summaryreport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.summaryreport.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Summaryreport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.summaryreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.summaryreport.Location = new System.Drawing.Point(8, 195);
            this.summaryreport.Name = "summaryreport";
            this.summaryreport.Size = new System.Drawing.Size(108, 17);
            this.summaryreport.TabIndex = 40;
            this.summaryreport.Text = "Summary Report";
            // 
            // compute_1
            // 
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.TabIndex = 0;
            this.compute_1.Location = new System.Drawing.Point(104, 101);
            this.compute_1.Name = "compute_1";
            //?this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.BackColor = System.Drawing.SystemColors.Control;
            //this.compute_1.DataBindings[0].DataSourceNullValue = null;
            this.compute_1.Size = new System.Drawing.Size(165, 40);
            this.compute_1.TabIndex = 0;
            // 
            // n_9993078
            // 
            this.n_9993078.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_9993078.Location = new System.Drawing.Point(41, 151);
            this.n_9993078.Name = "n_9993078";
            this.n_9993078.Size = new System.Drawing.Size(56, 13);
            this.n_9993078.TabIndex = 0;
            this.n_9993078.Text = "Sort Order";
            this.n_9993078.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_22828842
            // 
            this.n_22828842.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_22828842.Location = new System.Drawing.Point(61, 60);
            this.n_22828842.Name = "n_22828842";
            this.n_22828842.Size = new System.Drawing.Size(94, 13);
            this.n_22828842.TabIndex = 0;
            this.n_22828842.Text = "Select Frequency";
            this.n_22828842.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // freq_bmp
            // 
            this.freq_bmp.Location = new System.Drawing.Point(159, 59);
            this.freq_bmp.Name = "freq_bmp";
            this.freq_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            this.freq_bmp.Size = new System.Drawing.Size(17, 15);
            this.freq_bmp.TabIndex = 20;
            this.freq_bmp.TabStop = true;
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no_t.Location = new System.Drawing.Point(32, 39);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(65, 13);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Text = "Contract No";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(105, 36);
            //this.contract_no.Mask = "000000";
            //this.contract_no.DataBindings[0].FormatString = "######";
            //this.contract_no.PromptChar = ' ';
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(50, 20);
            this.contract_no.TabIndex = 10;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DCustSequenceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sortorder1);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.n_30778037);
            this.Controls.Add(this.sf_key);
            this.Controls.Add(this.freq_picklist);
            this.Controls.Add(this.summaryreport);
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.n_9993078);
            this.Controls.Add(this.n_22828842);
            this.Controls.Add(this.freq_bmp);
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.sortorder2);
            this.Name = "DCustSequenceSearch";
            this.Size = new System.Drawing.Size(608, 218);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label n_30778037;
        private Metex.Windows.DataEntityCombo sf_key;
        private System.Windows.Forms.CheckBox freq_picklist;
        private System.Windows.Forms.CheckBox summaryreport;
        private Label compute_1;// System.Windows.Forms.Panel compute_1;
        private System.Windows.Forms.Label n_9993078;
        private System.Windows.Forms.Label n_22828842;
        private System.Windows.Forms.PictureBox freq_bmp;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.RadioButton sortorder1;
        private System.Windows.Forms.RadioButton sortorder2;
    }
}

