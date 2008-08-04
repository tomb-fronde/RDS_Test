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
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DwNationalFuelOverride : Metex.Windows.DataUserControl
    {
        public DwNationalFuelOverride()
        {
            InitializeComponent();
        }

        public int Retrieve(int? al_region_id)
        {
            return RetrieveCore<NationalFuelOverride>(NationalFuelOverride.GetAllNationalFuelOverride(al_region_id));
        }

        private void DwNationalFuelOverride_RetrieveEnd(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.bindingSource.Count; i++)
            {
                DwNationalFuelOverridePanel panel = new DwNationalFuelOverridePanel();
                panel.Name = "DwNationalFuelOverridePanel" + i;
                panel.bindingSourcePanel.DataSource = this.BindingSource[i];
                panel.Location = new Point(0, i * panel.Height);
                this.panel1.Controls.Add(panel);
            }
        }
    }
    #region RegionalArticalCountsPanel
    public class DwNationalFuelOverridePanel : UserControl
    {
        #region Constructor
        public DwNationalFuelOverridePanel()
        {
            InitializeComponent();
        }
        #endregion

        #region Fields
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private NumericalMaskedTextBox fuel_rate;
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
            this.bindingSourcePanel = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).BeginInit();
            this.SuspendLayout();
            this.bindingSourcePanel.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NationalFuelOverride);
            //
            //fuel_rate
            //
            fuel_rate = new NumericalMaskedTextBox();
            this.fuel_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourcePanel, "FuelRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.fuel_rate.DataPropertyName = "FuelRate";
            //this.fuel_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //this.fuel_rate.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            //this.fuel_rate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.fuel_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.fuel_rate.HeaderText = "";
            this.fuel_rate.TextAlign = HorizontalAlignment.Right;
            this.fuel_rate.Name = "fuel_rate";
            this.fuel_rate.Width = 85;
            this.fuel_rate.Height = 23;
            this.fuel_rate.EditMask = "###0.00";
            this.fuel_rate.DataBindings[0].FormatString = "###0.00";
            this.fuel_rate.PromptChar = ' ';
            this.fuel_rate.InsertKeyMode = InsertKeyMode.Overwrite;
            // 
            // RegionalArticalCountsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fuel_rate);
            this.Name = "DwNationalFuelOverridePanel";
            this.Size = new System.Drawing.Size(85, 23);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
    #endregion

}
