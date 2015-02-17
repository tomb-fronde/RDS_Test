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
    // TJB  RPCR_093  Feb-2015: New
    // Created from DRegionalArticalCounts

    // Collect artical count daily figures (instead of weekly)
    // Replaced DRegionalArticalCounts

    public partial class DRegionalDailyArticalCounts : Metex.Windows.DataUserControl
	{
		public DRegionalDailyArticalCounts()
		{
			InitializeComponent();
		}

        public int Retrieve(int? in_Contract, int? in_Region, int? in_RenewalGroup, DateTime? in_Period)
		{
			return RetrieveCore<RegionalDailyArticalCounts>(new List<RegionalDailyArticalCounts>
                (RegionalDailyArticalCounts.GetAllRegionalDailyArticalCounts(in_Contract, in_Region, in_RenewalGroup, in_Period)));
		}

        private void DRegionalDailyArticalCounts_RetrieveEnd(object sender, System.EventArgs e)
        {
            int panelControlsCount = this.panel1.Controls.Count;
            if (panelControlsCount > 1)
                 return;

            this.panel1.Controls.Clear();
            //this.SortString = ""; //"contract_no A";
            //this.Sort<RegionalDailyArticalCounts>();
            for (int i = 0; i < this.bindingSource.Count; i++)
            {
                RegionalDailyArticalCountsPanel panel = new RegionalDailyArticalCountsPanel();
                panel.Name = "RegionalDailyArticalCountsPanel" + i;
                panel.bindingSourcePanel.DataSource = this.BindingSource[i];
                panel.Location = new Point(0, i * panel.Height);
                this.panel1.Controls.Add(panel);
            }

            if (this.RowCount > 2)
            {
                this.panel1.AutoScroll = true;
                this.vScrollBar1.Visible = false;  // true;
                this.vScrollBar1.Maximum = this.RowCount;
                this.vScrollBar1.LargeChange = 2;
            }
            else
            {
                this.vScrollBar1.Visible = false;
            }
        }
    }

    #region RegionalDailyArticalCountsPanel
    public class RegionalDailyArticalCountsPanel : UserControl
    {
        #region Constructor
        public RegionalDailyArticalCountsPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region Fields
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.TextBox contract_no;
        public System.Windows.Forms.TextBox acd_week_no;
        public System.Windows.Forms.TextBox act_description;
        private NumericalMaskedTextBox acd_mon_count;
        private NumericalMaskedTextBox acd_tue_count;
        private NumericalMaskedTextBox acd_wed_count;
        private NumericalMaskedTextBox acd_thu_count;
        private NumericalMaskedTextBox acd_fri_count;
        private NumericalMaskedTextBox acd_sat_count;
        private NumericalMaskedTextBox week_total;
        //public System.Windows.Forms.TextBox week_total;
        public BindingSource bindingSourcePanel;

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
            this.contract_no = new System.Windows.Forms.TextBox();
            this.acd_week_no = new System.Windows.Forms.TextBox();
            this.act_description = new System.Windows.Forms.TextBox();
            this.acd_mon_count = new NumericalMaskedTextBox();
            this.acd_tue_count = new NumericalMaskedTextBox();
            this.acd_wed_count = new NumericalMaskedTextBox();
            this.acd_thu_count = new NumericalMaskedTextBox();
            this.acd_fri_count = new NumericalMaskedTextBox();
            this.acd_sat_count = new NumericalMaskedTextBox();
            this.week_total = new NumericalMaskedTextBox();
            //this.week_total = new System.Windows.Forms.TextBox();
            this.bindingSourcePanel = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).BeginInit();
            this.SuspendLayout();
            this.bindingSourcePanel.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RegionalDailyArticalCounts);

            // 
            // contract_no
            // 
            this.contract_no.BackColor = System.Drawing.SystemColors.Control;
            this.contract_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(0, 2);
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.TabStop = false;
            this.contract_no.Size = new System.Drawing.Size(50, 20);
          //   this.contract_no.TabIndex = 101;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));

            // 
            // acd_week_no
            // 
            this.acd_week_no.BackColor = System.Drawing.SystemColors.Control;
            this.acd_week_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.acd_week_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_week_no.Location = new System.Drawing.Point(50, 2);
            this.acd_week_no.Name = "acd_week_no";
            this.acd_week_no.ReadOnly = true;
            this.acd_week_no.TabStop = false;
            this.acd_week_no.Size = new System.Drawing.Size(20, 20);
          //   this.acd_week_no.TabIndex = 102;
            this.acd_week_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.acd_week_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "AcdWeekNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));

            // 
            // act_description
            // 
            this.act_description.BackColor = System.Drawing.SystemColors.Control;
            this.act_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.act_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.act_description.Location = new System.Drawing.Point(70, 2);
            this.act_description.Name = "act_description";
            this.act_description.ReadOnly = true;
            this.act_description.TabStop = false;
            this.act_description.Size = new System.Drawing.Size(120, 20);
          //   this.act_description.TabIndex = 103;
            this.act_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.act_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "ActDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));

            // 
            // acd_mon_count
            // 
            this.acd_mon_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_mon_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_mon_count.Location = new System.Drawing.Point(190, 2);
            this.acd_mon_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdMonCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_mon_count.Mask = "##,##0";
            this.acd_mon_count.DataBindings[0].FormatString = "##,##0";
            this.acd_mon_count.EditMask = "##,##0";
            this.acd_mon_count.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acd_mon_count.Name = "acd_mon_count";
            this.acd_mon_count.PromptChar = ' ';
            this.acd_mon_count.Size = new System.Drawing.Size(50, 20);
            this.acd_mon_count.TabIndex = 111;
            this.acd_mon_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // acd_tue_count
            // 
            this.acd_tue_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_tue_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_tue_count.Location = new System.Drawing.Point(240, 2);
            this.acd_tue_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdTueCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_tue_count.Mask = "##,##0";
            this.acd_tue_count.DataBindings[0].FormatString = "##,##0";
            this.acd_tue_count.EditMask = "##,##0";
            this.acd_tue_count.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acd_tue_count.Name = "acd_tue_count";
            this.acd_tue_count.PromptChar = ' ';
            this.acd_tue_count.Size = new System.Drawing.Size(50, 20);
            this.acd_tue_count.TabIndex = 112;
            this.acd_tue_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // acd_wed_count
            // 
            this.acd_wed_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_wed_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_wed_count.Location = new System.Drawing.Point(290, 2);
            this.acd_wed_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdWedCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_wed_count.Mask = "##,##0";
            this.acd_wed_count.DataBindings[0].FormatString = "##,##0";
            this.acd_wed_count.EditMask = "##,##0";
            this.acd_wed_count.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acd_wed_count.Name = "acd_wed_count";
            this.acd_wed_count.PromptChar = ' ';
            this.acd_wed_count.Size = new System.Drawing.Size(50, 20);
            this.acd_wed_count.TabIndex = 113;
            this.acd_wed_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // acd_thu_count
            // 
            this.acd_thu_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_thu_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_thu_count.Location = new System.Drawing.Point(340, 2);
            this.acd_thu_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdThuCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_thu_count.Mask = "##,##0";
            this.acd_thu_count.DataBindings[0].FormatString = "##,##0";
            this.acd_thu_count.EditMask = "##,##0";
            this.acd_thu_count.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acd_thu_count.Name = "acd_thu_count";
            this.acd_thu_count.PromptChar = ' ';
            this.acd_thu_count.Size = new System.Drawing.Size(50, 20);
            this.acd_thu_count.TabIndex = 114;
            this.acd_thu_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // acd_fri_count
            // 
            this.acd_fri_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_fri_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_fri_count.Location = new System.Drawing.Point(390, 2);
            this.acd_fri_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdFriCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_fri_count.Mask = "##,##0";
            this.acd_fri_count.DataBindings[0].FormatString = "##,##0";
            this.acd_fri_count.EditMask = "##,##0";
            this.acd_fri_count.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acd_fri_count.Name = "acd_fri_count";
            this.acd_fri_count.PromptChar = ' ';
            this.acd_fri_count.Size = new System.Drawing.Size(50, 20);
            this.acd_fri_count.TabIndex = 115;
            this.acd_fri_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // acd_sat_count
            // 
            this.acd_sat_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_sat_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_sat_count.Location = new System.Drawing.Point(440, 2);
            this.acd_sat_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdSatCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_sat_count.Mask = "##,##0";
            this.acd_sat_count.DataBindings[0].FormatString = "##,##0";
            this.acd_sat_count.EditMask = "##,##0";
            this.acd_sat_count.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acd_sat_count.Name = "acd_sat_count";
            this.acd_sat_count.PromptChar = ' ';
            this.acd_sat_count.Size = new System.Drawing.Size(50, 20);
            this.acd_sat_count.TabIndex = 116;
            this.acd_sat_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // week_total
            // 
            this.acd_sat_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.week_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week_total.Location = new System.Drawing.Point(510, 2);
            this.week_total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "WeekTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.week_total.Mask = "##,##0";
            this.week_total.DataBindings[0].FormatString = "##,##0";
            this.week_total.EditMask = "##,##0";
            this.week_total.InsertKeyMode = InsertKeyMode.Overwrite;
            this.week_total.Name = "week_total";
            this.week_total.PromptChar = ' ';
            //this.week_total.ReadOnly = true;
            this.week_total.Size = new System.Drawing.Size(60, 20);
            this.week_total.TabStop = false;
            this.week_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // RegionalDailyArticalCountsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.acd_week_no);
            this.Controls.Add(this.act_description);
            this.Controls.Add(this.acd_mon_count);
            this.Controls.Add(this.acd_tue_count);
            this.Controls.Add(this.acd_wed_count);
            this.Controls.Add(this.acd_thu_count);
            this.Controls.Add(this.acd_fri_count);
            this.Controls.Add(this.acd_sat_count);
            this.Controls.Add(this.week_total);
            //this.Controls.Add(this.compute_1);
            //this.Controls.Add(this.compute_2);
            this.Name = "RegionalDailyArticalCountsPanel";
            this.Size = new System.Drawing.Size(580, 20);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
    #endregion

}
