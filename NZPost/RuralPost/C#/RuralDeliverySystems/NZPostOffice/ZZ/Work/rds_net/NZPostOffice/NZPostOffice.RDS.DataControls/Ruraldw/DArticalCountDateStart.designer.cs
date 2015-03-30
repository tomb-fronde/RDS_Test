using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DArticalCountDateStart
    {
        // TJB  RPCR_093  30-Mar-2015
        // [Re-]Added Contract_No and fiddled tab sequence (date last)
        //
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

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
            NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox contractno;
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.weekstart = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.n_34565022 = new System.Windows.Forms.Label();
            this.n_42649746 = new System.Windows.Forms.Label();
            this.weekstart_t = new System.Windows.Forms.Label();
            this.contract_t = new System.Windows.Forms.Label();
            contractno = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ArticalCountDateStart);
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownHeight = 150;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.IntegralHeight = false;
            this.region_id.Location = new System.Drawing.Point(190, 2);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(182, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.DropDownHeight = 150;
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.IntegralHeight = false;
            this.rg_code.Location = new System.Drawing.Point(190, 26);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(182, 21);
            this.rg_code.TabIndex = 20;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // weekstart
            // 
            this.weekstart.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Weekstart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.weekstart.EditMask = "";
            this.weekstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.weekstart.Location = new System.Drawing.Point(190, 50);
            this.weekstart.Mask = "00/00/0000";
            this.weekstart.Name = "weekstart";
            this.weekstart.Size = new System.Drawing.Size(68, 20);
            this.weekstart.TabIndex = 40;
            this.weekstart.Text = "00000000";
            this.weekstart.ValidatingType = typeof(System.DateTime);
            this.weekstart.Value = null;
            this.weekstart.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // n_34565022
            // 
            this.n_34565022.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_34565022.Location = new System.Drawing.Point(140, 6);
            this.n_34565022.Name = "n_34565022";
            this.n_34565022.Size = new System.Drawing.Size(43, 13);
            this.n_34565022.TabIndex = 0;
            this.n_34565022.Text = "Region";
            this.n_34565022.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_42649746
            // 
            this.n_42649746.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_42649746.Location = new System.Drawing.Point(99, 29);
            this.n_42649746.Name = "n_42649746";
            this.n_42649746.Size = new System.Drawing.Size(84, 13);
            this.n_42649746.TabIndex = 0;
            this.n_42649746.Text = "Renewal Group";
            this.n_42649746.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // weekstart_t
            // 
            this.weekstart_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.weekstart_t.Location = new System.Drawing.Point(2, 53);
            this.weekstart_t.Name = "weekstart_t";
            this.weekstart_t.Size = new System.Drawing.Size(181, 13);
            this.weekstart_t.TabIndex = 0;
            this.weekstart_t.Text = "Enter the commencing week date";
            this.weekstart_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contractno
            // 
            contractno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            contractno.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            contractno.EditMask = "";
            contractno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            contractno.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            contractno.Location = new System.Drawing.Point(535, 2);
            contractno.Mask = "99999";
            contractno.Name = "contractno";
            contractno.PromptChar = ' ';
            contractno.Size = new System.Drawing.Size(100, 20);
            contractno.TabIndex = 30;
            contractno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            contractno.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            contractno.Value = null;
            // 
            // contract_t
            // 
            this.contract_t.AutoSize = true;
            this.contract_t.Location = new System.Drawing.Point(465, 6);
            this.contract_t.Name = "contract_t";
            this.contract_t.Size = new System.Drawing.Size(64, 13);
            this.contract_t.TabIndex = 0;
            this.contract_t.Text = "Contract No";
            // 
            // DArticalCountDateStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contract_t);
            this.Controls.Add(contractno);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.weekstart);
            this.Controls.Add(this.n_34565022);
            this.Controls.Add(this.n_42649746);
            this.Controls.Add(this.weekstart_t);
            this.Name = "DArticalCountDateStart";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo rg_code;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox weekstart;
        private System.Windows.Forms.Label n_34565022;
        private System.Windows.Forms.Label n_42649746;
        private System.Windows.Forms.Label weekstart_t;
        private Label contract_t;
    }
}
