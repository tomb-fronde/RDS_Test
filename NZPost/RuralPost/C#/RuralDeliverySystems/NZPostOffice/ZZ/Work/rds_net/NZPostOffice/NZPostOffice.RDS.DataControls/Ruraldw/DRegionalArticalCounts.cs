using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  RPCR_093  Feb 2015
    // Obsolete: replaced with DRegionalDailyArticalCounts

    public partial class DRegionalArticalCounts : Metex.Windows.DataUserControl
	{
		public DRegionalArticalCounts()
		{
			InitializeComponent();
		}

        public int Retrieve(int? in_Contract, int? in_Region, int? in_RenewalGroup, DateTime? in_Period)
		{
			return RetrieveCore<RegionalArticalCounts>(new List<RegionalArticalCounts>
                (RegionalArticalCounts.GetAllRegionalArticalCounts(in_Contract, in_Region, in_RenewalGroup, in_Period)));
		}

        private void DRegionalArticalCounts_RetrieveEnd(object sender, System.EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.SortString = "contract_no A";
            this.Sort<RegionalArticalCounts>();
            for (int i = 0; i < this.bindingSource.Count; i++)
            {
                RegionalArticalCountsPanel panel = new RegionalArticalCountsPanel();
                panel.Name = "RegionalArticalCountsPanel" + i;
                panel.bindingSourcePanel.DataSource = this.BindingSource[i];
                panel.Location = new Point(0, i * panel.Height);
                this.panel1.Controls.Add(panel);
            }

            if (this.RowCount > 2)
            {
                this.panel1.AutoScroll = true;
                this.vScrollBar1.Visible = true;
                this.vScrollBar1.Maximum = this.RowCount;
                this.vScrollBar1.LargeChange = 2;
            }
            else
            {
                this.vScrollBar1.Visible = false;
            }
        }
    }

    #region RegionalArticalCountsPanel
    public class RegionalArticalCountsPanel : UserControl
    {
        #region Constructor
        public RegionalArticalCountsPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region Fields
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private NumericalMaskedTextBox ac_w2_medium_letters;
        private NumericalMaskedTextBox ac_w2_other_envelopes;
        private NumericalMaskedTextBox ac_w2_small_parcels;
        private System.Windows.Forms.Label t_5;
        public System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label t_6;
        private NumericalMaskedTextBox ac_w1_medium_letters;
        private NumericalMaskedTextBox ac_w1_other_envelopes;
        private NumericalMaskedTextBox ac_w1_small_parcels;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.TextBox compute_1;
        private NumericalMaskedTextBox ac_w2_inward_mail;
        private NumericalMaskedTextBox ac_w1_inward_mail;
        private NumericalMaskedTextBox ac_w1_large_parcels;
        public BindingSource bindingSourcePanel;
        private NumericalMaskedTextBox ac_w2_large_parcels;

        #endregion

        #region Dispose
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
        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ac_w2_medium_letters = new NumericalMaskedTextBox();
            this.ac_w2_other_envelopes = new NumericalMaskedTextBox();
            this.ac_w2_small_parcels = new NumericalMaskedTextBox();
            this.t_5 = new System.Windows.Forms.Label();
            this.contract_no = new System.Windows.Forms.TextBox();
            this.t_6 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters = new NumericalMaskedTextBox();
            this.ac_w1_other_envelopes = new NumericalMaskedTextBox();
            this.ac_w1_small_parcels = new NumericalMaskedTextBox();
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.compute_1 = new System.Windows.Forms.TextBox();
            this.ac_w2_inward_mail = new NumericalMaskedTextBox();
            this.ac_w1_inward_mail = new NumericalMaskedTextBox();
            this.ac_w1_large_parcels = new NumericalMaskedTextBox();
            this.ac_w2_large_parcels = new NumericalMaskedTextBox();
            this.bindingSourcePanel = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).BeginInit();
            this.SuspendLayout();
            this.bindingSourcePanel.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RegionalArticalCounts);
            // 
            // ac_w2_medium_letters
            // 
            this.ac_w2_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_medium_letters.Location = new System.Drawing.Point(106, 21);
            this.ac_w2_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW2MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.ac_w2_medium_letters.Mask = "##,###";
            this.ac_w2_medium_letters.DataBindings[0].FormatString = "##,###";
            this.ac_w2_medium_letters.EditMask = "##,###";
            this.ac_w2_medium_letters.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_medium_letters.Name = "ac_w2_medium_letters";
            this.ac_w2_medium_letters.PromptChar = ' ';
            this.ac_w2_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_medium_letters.TabIndex = 111;
            this.ac_w2_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w2_other_envelopes
            // 
            this.ac_w2_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_other_envelopes.Location = new System.Drawing.Point(150,21);//(169, 24);
            //this.ac_w2_other_envelopes.Mask = "##,###";
            this.ac_w2_other_envelopes.Name = "ac_w2_other_envelopes";
            this.ac_w2_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW2OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_other_envelopes.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_other_envelopes.PromptChar = ' ';
            this.ac_w2_other_envelopes.DataBindings[0].FormatString = "##,###";
            this.ac_w2_other_envelopes.EditMask = "##,###";
            this.ac_w2_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_other_envelopes.TabIndex = 112;
            this.ac_w2_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w2_small_parcels
            // 
            this.ac_w2_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_small_parcels.Location = new System.Drawing.Point(195,21);//(225, 24);
            //this.ac_w2_small_parcels.Mask = "##,###";
            this.ac_w2_small_parcels.Name = "ac_w2_small_parcels";
            this.ac_w2_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW2SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_small_parcels.PromptChar = ' ';
            this.ac_w2_small_parcels.DataBindings[0].FormatString = "##,###";
            this.ac_w2_small_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_small_parcels.EditMask = "##,###";
            this.ac_w2_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_small_parcels.TabIndex = 113;
            this.ac_w2_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // t_5
            // 
            this.t_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_5.Location = new System.Drawing.Point(70, 27);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(29, 13);
            this.t_5.TabIndex = 104;
            this.t_5.Text = "Two";
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // contract_no
            // 
            this.contract_no.BackColor = System.Drawing.SystemColors.Control;
            this.contract_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(0 , 2);
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.TabStop = false;
            this.contract_no.Size = new System.Drawing.Size(50, 13);
            this.contract_no.TabIndex = 101;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));

            // 
            // t_6
            // 
            this.t_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_6.Location = new System.Drawing.Point(70 , 3);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(28, 13);
            this.t_6.TabIndex = 102;
            this.t_6.Text = "One";
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // ac_w1_medium_letters
            // 
            this.ac_w1_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_medium_letters.Location = new System.Drawing.Point(106  , 0);
            //this.ac_w1_medium_letters.Mask = "##,###";
            this.ac_w1_medium_letters.Name = "ac_w1_medium_letters";
            this.ac_w1_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW1MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_medium_letters.PromptChar = ' ';
            this.ac_w1_medium_letters.DataBindings[0].FormatString = "##,###";
            this.ac_w1_medium_letters.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_medium_letters.EditMask = "##,###";
            this.ac_w1_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_medium_letters.TabIndex = 106;
            this.ac_w1_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w1_other_envelopes
            // 
            this.ac_w1_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_other_envelopes.Location = new System.Drawing.Point(150,0);//169, 0);
            //this.ac_w1_other_envelopes.Mask = "##,###";
            this.ac_w1_other_envelopes.Name = "ac_w1_other_envelopes";
            this.ac_w1_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW1OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_other_envelopes.PromptChar = ' ';
            this.ac_w1_other_envelopes.DataBindings[0].FormatString = "##,###";
            this.ac_w1_other_envelopes.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_other_envelopes.EditMask = "##,###";
            this.ac_w1_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_other_envelopes.TabIndex = 107;
            this.ac_w1_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w1_small_parcels
            // 
            this.ac_w1_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_small_parcels.Location = new System.Drawing.Point(195,0);//(225, 0);
            //this.ac_w1_small_parcels.Mask = "##,###";
            this.ac_w1_small_parcels.Name = "ac_w1_small_parcels";
            this.ac_w1_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW1SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_small_parcels.PromptChar = ' ';
            this.ac_w1_small_parcels.DataBindings[0].FormatString = "##,###";
            this.ac_w1_small_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_small_parcels.EditMask = "##,###";
            this.ac_w1_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_small_parcels.TabIndex = 108;
            this.ac_w1_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // compute_2
            // 
            this.compute_2.BorderStyle = BorderStyle.None;
            this.compute_2.ReadOnly = true;
            this.compute_2.BackColor = System.Drawing.SystemColors.Control;
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_2.Location = new System.Drawing.Point(240,0);//(347, 0);
            this.compute_2.Name = "compute_2";
            this.compute_2.TabStop = false;
            this.compute_2.Size = new System.Drawing.Size(51, 20);
            this.compute_2.TabIndex = 103;
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.DataBindings[0].FormatString = "#,##0";
            // 
            // compute_1
            // 
            this.compute_1.BorderStyle = BorderStyle.None;
            this.compute_1.ReadOnly = true;
            this.compute_1.TabStop = false;
            this.compute_1.BackColor = System.Drawing.SystemColors.Control;
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.Location = new System.Drawing.Point(240,21);//(347, 24);
            this.compute_1.Name = "compute_1";
            this.compute_1.Size = new System.Drawing.Size(51, 20);
            this.compute_1.TabIndex = 105;
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_1.DataBindings[0].FormatString = "#,##0";
            // 
            // ac_w2_inward_mail
            // 
            this.ac_w2_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_inward_mail.Location = new System.Drawing.Point(350,21);//(403, 24);
            //this.ac_w2_inward_mail.Mask = "##,###";
            this.ac_w2_inward_mail.Name = "ac_w2_inward_mail";
            this.ac_w2_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW2InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_inward_mail.PromptChar = ' ';
            this.ac_w2_inward_mail.DataBindings[0].FormatString = "##,###";
            this.ac_w2_inward_mail.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_inward_mail.EditMask = "##,###";
            this.ac_w2_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_inward_mail.TabIndex = 115;
            this.ac_w2_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w1_inward_mail
            // 
            this.ac_w1_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_inward_mail.Location = new System.Drawing.Point(350,0);//(403, 0);
            //this.ac_w1_inward_mail.Mask = "##,###";
            this.ac_w1_inward_mail.Name = "ac_w1_inward_mail";
            this.ac_w1_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW1InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_inward_mail.PromptChar = ' ';
            this.ac_w1_inward_mail.DataBindings[0].FormatString = "##,###";
            this.ac_w1_inward_mail.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_inward_mail.EditMask = "##,###";
            this.ac_w1_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_inward_mail.TabIndex = 110;
            this.ac_w1_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w1_large_parcels
            // 
            this.ac_w1_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_large_parcels.Location = new System.Drawing.Point(300,0);//(282, 0);
            //this.ac_w1_large_parcels.Mask = "##,###";
            this.ac_w1_large_parcels.Name = "ac_w1_large_parcels";
            this.ac_w1_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW1LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_large_parcels.PromptChar = ' ';
            this.ac_w1_large_parcels.DataBindings[0].FormatString = "##,###";
            this.ac_w1_large_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_large_parcels.EditMask = "##,###";
            this.ac_w1_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_large_parcels.TabIndex = 109;
            this.ac_w1_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // ac_w2_large_parcels
            // 
            this.ac_w2_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_large_parcels.Location = new System.Drawing.Point(300,21);//(282, 24);
            //this.ac_w2_large_parcels.Mask = "##,###";
            this.ac_w2_large_parcels.Name = "ac_w2_large_parcels";
            this.ac_w2_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcW2LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_large_parcels.PromptChar = ' ';
            this.ac_w2_large_parcels.DataBindings[0].FormatString = "##,###";
            this.ac_w2_large_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_large_parcels.EditMask = "##,###";
            this.ac_w2_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_large_parcels.TabIndex = 114;
            this.ac_w2_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // RegionalArticalCountsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ac_w2_medium_letters);
            this.Controls.Add(this.ac_w2_other_envelopes);
            this.Controls.Add(this.ac_w2_small_parcels);
            this.Controls.Add(this.t_5);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.t_6);
            this.Controls.Add(this.ac_w1_medium_letters);
            this.Controls.Add(this.ac_w1_other_envelopes);
            this.Controls.Add(this.ac_w1_small_parcels);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.ac_w2_inward_mail);
            this.Controls.Add(this.ac_w1_inward_mail);
            this.Controls.Add(this.ac_w1_large_parcels);
            this.Controls.Add(this.ac_w2_large_parcels);
            this.Name = "RegionalArticalCountsPanel";
            this.Size = new System.Drawing.Size(400, 44);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
    #endregion

}
