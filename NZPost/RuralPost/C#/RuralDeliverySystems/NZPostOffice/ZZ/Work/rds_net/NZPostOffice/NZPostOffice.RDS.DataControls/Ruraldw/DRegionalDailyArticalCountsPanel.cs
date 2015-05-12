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
    // TJB  RPCR_093  Bugfix
    // NEW - code moved from DRegionalDailyArticalCounts
    // (allows designer editing)
    // Added enter and leave event handlers for daily count fields
    //    - blank field on entry and replace original content on exit if unaltered
    // Removed field masks from daily and weekly fields

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
            this.bindingSourcePanel = new System.Windows.Forms.BindingSource(this.components);
            this.acd_week_no = new System.Windows.Forms.TextBox();
            this.act_description = new System.Windows.Forms.TextBox();
            this.acd_mon_count = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.acd_tue_count = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.acd_wed_count = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.acd_thu_count = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.acd_fri_count = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.acd_sat_count = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.week_total = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).BeginInit();
            this.SuspendLayout();
            // 
            // contract_no
            // 
            this.contract_no.BackColor = System.Drawing.SystemColors.Control;
            this.contract_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(0, 2);
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Size = new System.Drawing.Size(50, 13);
            this.contract_no.TabIndex = 0;
            this.contract_no.TabStop = false;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bindingSourcePanel
            // 
            this.bindingSourcePanel.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RegionalDailyArticalCounts);
            // 
            // acd_week_no
            // 
            this.acd_week_no.BackColor = System.Drawing.SystemColors.Control;
            this.acd_week_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.acd_week_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "AcdWeekNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.acd_week_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.acd_week_no.Location = new System.Drawing.Point(50, 2);
            this.acd_week_no.Name = "acd_week_no";
            this.acd_week_no.ReadOnly = true;
            this.acd_week_no.Size = new System.Drawing.Size(20, 13);
            this.acd_week_no.TabIndex = 1;
            this.acd_week_no.TabStop = false;
            this.acd_week_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // act_description
            // 
            this.act_description.BackColor = System.Drawing.SystemColors.Control;
            this.act_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.act_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourcePanel, "ActDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.act_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.act_description.Location = new System.Drawing.Point(70, 2);
            this.act_description.Name = "act_description";
            this.act_description.ReadOnly = true;
            this.act_description.Size = new System.Drawing.Size(120, 13);
            this.act_description.TabIndex = 2;
            this.act_description.TabStop = false;
            // 
            // acd_mon_count
            // 
            this.acd_mon_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_mon_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdMonCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_mon_count.EditMask = "##,##0";
            this.acd_mon_count.EditMask = "#####";
            this.acd_mon_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.acd_mon_count.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.acd_mon_count.Location = new System.Drawing.Point(190, 2);
            //this.acd_mon_count.Mask = "##,##0";
            this.acd_mon_count.Name = "acd_mon_count";
            //this.acd_mon_count.PromptChar = ' ';
            this.acd_mon_count.Size = new System.Drawing.Size(50, 20);
            this.acd_mon_count.TabIndex = 111;
            this.acd_mon_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acd_mon_count.Value = "";
            this.acd_mon_count.Leave += new System.EventHandler(this.acd_mon_count_Leave);
            this.acd_mon_count.Enter += new System.EventHandler(this.acd_mon_count_Enter);
            // 
            // acd_tue_count
            // 
            this.acd_tue_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_tue_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdTueCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_tue_count.EditMask = "##,##0";
            this.acd_tue_count.EditMask = "#####";
            this.acd_tue_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.acd_tue_count.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.acd_tue_count.Location = new System.Drawing.Point(240, 2);
            this.acd_tue_count.Name = "acd_tue_count";
            //this.acd_tue_count.PromptChar = ' ';
            this.acd_tue_count.Size = new System.Drawing.Size(50, 20);
            this.acd_tue_count.TabIndex = 112;
            this.acd_tue_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acd_tue_count.Value = "";
            this.acd_tue_count.Leave += new System.EventHandler(this.acd_tue_count_Leave);
            this.acd_tue_count.Enter += new System.EventHandler(this.acd_tue_count_Enter);
            // 
            // acd_wed_count
            // 
            this.acd_wed_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_wed_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdWedCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_wed_count.EditMask = "##,##0";
            this.acd_wed_count.EditMask = "#####";
            this.acd_wed_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.acd_wed_count.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.acd_wed_count.Location = new System.Drawing.Point(290, 2);
            this.acd_wed_count.Name = "acd_wed_count";
            //this.acd_wed_count.PromptChar = ' ';
            this.acd_wed_count.Size = new System.Drawing.Size(50, 20);
            this.acd_wed_count.TabIndex = 113;
            this.acd_wed_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acd_wed_count.Value = "";
            this.acd_wed_count.Leave += new System.EventHandler(this.acd_wed_count_Leave);
            this.acd_wed_count.Enter += new System.EventHandler(this.acd_wed_count_Enter);
            // 
            // acd_thu_count
            // 
            this.acd_thu_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_thu_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdThuCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_thu_count.EditMask = "##,##0";
            this.acd_thu_count.EditMask = "#####";
            this.acd_thu_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.acd_thu_count.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.acd_thu_count.Location = new System.Drawing.Point(340, 2);
            this.acd_thu_count.Name = "acd_thu_count";
            //this.acd_thu_count.PromptChar = ' ';
            this.acd_thu_count.Size = new System.Drawing.Size(50, 20);
            this.acd_thu_count.TabIndex = 114;
            this.acd_thu_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acd_thu_count.Value = "";
            this.acd_thu_count.Leave += new System.EventHandler(this.acd_thu_count_Leave);
            this.acd_thu_count.Enter += new System.EventHandler(this.acd_thu_count_Enter);
            // 
            // acd_fri_count
            // 
            this.acd_fri_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_fri_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdFriCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_fri_count.EditMask = "##,##0";
            this.acd_fri_count.EditMask = "#####";
            this.acd_fri_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.acd_fri_count.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.acd_fri_count.Location = new System.Drawing.Point(390, 2);
            this.acd_fri_count.Name = "acd_fri_count";
            //this.acd_fri_count.PromptChar = ' ';
            this.acd_fri_count.Size = new System.Drawing.Size(50, 20);
            this.acd_fri_count.TabIndex = 115;
            this.acd_fri_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acd_fri_count.Value = "";
            this.acd_fri_count.Leave += new System.EventHandler(this.acd_fri_count_Leave);
            this.acd_fri_count.Enter += new System.EventHandler(this.acd_fri_count_Enter);
            // 
            // acd_sat_count
            // 
            this.acd_sat_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acd_sat_count.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "AcdSatCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.acd_sat_count.EditMask = "##,##0";
            this.acd_sat_count.EditMask = "#####";
            this.acd_sat_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            //this.acd_sat_count.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.acd_sat_count.Location = new System.Drawing.Point(440, 2);
            this.acd_sat_count.Name = "acd_sat_count";
            //this.acd_sat_count.PromptChar = ' ';
            this.acd_sat_count.Size = new System.Drawing.Size(50, 20);
            this.acd_sat_count.TabIndex = 116;
            this.acd_sat_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.acd_sat_count.Value = "";
            this.acd_sat_count.Leave += new System.EventHandler(this.acd_sat_count_Leave);
            this.acd_sat_count.Enter += new System.EventHandler(this.acd_sat_count_Enter);
            // 
            // week_total
            // 
            this.week_total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "WeekTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week_total.EditMask = "##,##0";
            this.week_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week_total.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.week_total.Location = new System.Drawing.Point(510, 2);
            //this.week_total.Mask = "##,###";
            this.week_total.Name = "week_total";
            this.week_total.PromptChar = ' ';
            this.week_total.Size = new System.Drawing.Size(60, 20);
            this.week_total.TabIndex = 117;
            this.week_total.TabStop = false;
            this.week_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.week_total.Value = "";
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
            this.Name = "RegionalDailyArticalCountsPanel";
            this.Size = new System.Drawing.Size(580, 20);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private string sInitialValue, sInitialText;

        private void acd_mon_count_Enter(object sender, EventArgs e)
        {
            sInitialValue = acd_mon_count.Value;
            sInitialText = acd_mon_count.Text;
            acd_mon_count.Value = null;
            acd_mon_count.Text = null;
        }

        private void acd_mon_count_Leave(object sender, EventArgs e)
        {
            if (acd_mon_count.Value == "" || acd_mon_count.Value == null || acd_mon_count.Value == sInitialValue)
            {
                acd_mon_count.Modified = false;
                acd_mon_count.Value = sInitialValue;
                acd_mon_count.Text = sInitialText;
            }
            else
                acd_mon_count.Modified = true;

        }

        private void acd_tue_count_Enter(object sender, EventArgs e)
        {
            sInitialValue = acd_tue_count.Value;
            sInitialText = acd_tue_count.Text;
            acd_tue_count.Value = null;
            acd_tue_count.Text = null;
        }

        private void acd_tue_count_Leave(object sender, EventArgs e)
        {
            if (acd_tue_count.Value == "" || acd_tue_count.Value == null || acd_tue_count.Value == sInitialValue)
            {
                acd_tue_count.Modified = false;
                acd_tue_count.Value = sInitialValue;
                acd_tue_count.Text = sInitialText;
            }
            else
                acd_tue_count.Modified = true;

        }

        private void acd_wed_count_Enter(object sender, EventArgs e)
        {
            sInitialValue = acd_wed_count.Value;
            sInitialText = acd_wed_count.Text;
            acd_wed_count.Value = null;
            acd_wed_count.Text = null;
        }

        private void acd_wed_count_Leave(object sender, EventArgs e)
        {
            if (acd_wed_count.Value == "" || acd_wed_count.Value == null || acd_wed_count.Value == sInitialValue)
            {
                acd_wed_count.Modified = false;
                acd_wed_count.Value = sInitialValue;
                acd_wed_count.Text = sInitialText;
            }
            else
                acd_wed_count.Modified = true;

        }

        private void acd_thu_count_Enter(object sender, EventArgs e)
        {
            sInitialValue = acd_thu_count.Value;
            sInitialText = acd_thu_count.Text;
            acd_thu_count.Value = null;
            acd_thu_count.Text = null;
        }

        private void acd_thu_count_Leave(object sender, EventArgs e)
        {
            if (acd_thu_count.Value == "" || acd_thu_count.Value == null || acd_thu_count.Value == sInitialValue)
            {
                acd_thu_count.Modified = false;
                acd_thu_count.Value = sInitialValue;
                acd_thu_count.Text = sInitialText;
            }
            else
                acd_thu_count.Modified = true;

        }

        private void acd_fri_count_Enter(object sender, EventArgs e)
        {
            sInitialValue = acd_fri_count.Value;
            sInitialText = acd_fri_count.Text;
            acd_fri_count.Value = null;
            acd_fri_count.Text = null;
        }

        private void acd_fri_count_Leave(object sender, EventArgs e)
        {
            if (acd_fri_count.Value == "" || acd_fri_count.Value == null || acd_fri_count.Value == sInitialValue)
            {
                acd_fri_count.Modified = false;
                acd_fri_count.Value = sInitialValue;
                acd_fri_count.Text = sInitialText;
            }
            else
                acd_fri_count.Modified = true;

        }

        private void acd_sat_count_Enter(object sender, EventArgs e)
        {
            sInitialValue = acd_sat_count.Value;
            sInitialText = acd_sat_count.Text;
            acd_sat_count.Value = null;
            acd_sat_count.Text = null;
        }

        private void acd_sat_count_Leave(object sender, EventArgs e)
        {
            if (acd_sat_count.Value == "" || acd_sat_count.Value == null || acd_sat_count.Value == sInitialValue)
            {
                acd_sat_count.Modified = false;
                acd_sat_count.Value = sInitialValue;
                acd_sat_count.Text = sInitialText;
            }
            else
                acd_sat_count.Modified = true;

        }
    }
}
