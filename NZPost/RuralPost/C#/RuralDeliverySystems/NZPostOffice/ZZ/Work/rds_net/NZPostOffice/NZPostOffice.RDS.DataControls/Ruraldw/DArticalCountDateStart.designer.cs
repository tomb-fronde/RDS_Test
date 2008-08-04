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
            components = new System.ComponentModel.Container();
            this.Name = "DArticalCountDateStart";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ArticalCountDateStart);
            #region region_id define
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.Name = "region_id";
            this.region_id.Location = new System.Drawing.Point(190, 2);
            this.region_id.Size = new System.Drawing.Size(182, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.region_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.ValueMember = "RegionId";
            this.region_id.AutoRetrieve = true;
            #endregion
            this.Controls.Add(region_id);
            #region rg_code define
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.rg_code.Name = "rg_code";
            this.rg_code.Location = new System.Drawing.Point(190, 26);
            this.rg_code.Size = new System.Drawing.Size(182, 21);
            this.rg_code.TabIndex = 20;
            this.rg_code.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.rg_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.AutoRetrieve = true;
            
            #endregion
            this.Controls.Add(rg_code);
            #region weekstart define
            this.weekstart = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.weekstart.Name = "weekstart";
            this.weekstart.Location = new System.Drawing.Point(190, 50);
            this.weekstart.Size = new System.Drawing.Size(52, 20);
            this.weekstart.TabIndex = 30;
            this.weekstart.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.weekstart.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.weekstart.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Weekstart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.weekstart.Mask = "00/00/00";
            //this.weekstart.PromptChar = '0';
            //this.weekstart.ValidatingType = typeof(System.DateTime);
            //this.weekstart.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.weekstart.DataBindings[0].FormatString = "dd/MM/yy";
            this.weekstart.Validating += new CancelEventHandler(TextBox_Validating);
            #endregion
            this.Controls.Add(weekstart);
            #region n_34565022 define
            this.n_34565022 = new System.Windows.Forms.Label();
            this.n_34565022.Name = "n_34565022";
            this.n_34565022.Location = new System.Drawing.Point(140, 6);
            this.n_34565022.Size = new System.Drawing.Size(43, 13);
            this.n_34565022.TabIndex = 0;
            this.n_34565022.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_34565022.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_34565022.Text = "Region";
            #endregion
            this.Controls.Add(n_34565022);
            #region n_42649746 define
            this.n_42649746 = new System.Windows.Forms.Label();
            this.n_42649746.Name = "n_42649746";
            this.n_42649746.Location = new System.Drawing.Point(99, 29);
            this.n_42649746.Size = new System.Drawing.Size(84, 13);
            this.n_42649746.TabIndex = 0;
            this.n_42649746.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_42649746.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.n_42649746.Text = "Renewal Group";
            #endregion
            this.Controls.Add(n_42649746);
            #region weekstart_t define
            this.weekstart_t = new System.Windows.Forms.Label();
            this.weekstart_t.Name = "weekstart_t";
            this.weekstart_t.Location = new System.Drawing.Point(2, 53);
            this.weekstart_t.Size = new System.Drawing.Size(181, 13);
            this.weekstart_t.TabIndex = 0;
            this.weekstart_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.weekstart_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.weekstart_t.Text = "Enter the commencing week date";
            #endregion
            this.Controls.Add(weekstart_t);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo rg_code;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox weekstart;
        private System.Windows.Forms.Label n_34565022;
        private System.Windows.Forms.Label n_42649746;
        private System.Windows.Forms.Label weekstart_t;
    }
}
