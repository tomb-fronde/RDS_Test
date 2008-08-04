using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DSetScalingFactor
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label acdate_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox scaling_factor;
        private System.Windows.Forms.MaskedTextBox acdate;
        private System.Windows.Forms.Label scaling_factor_t;
        private System.Windows.Forms.CheckBox updateall;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DSetScalingFactor";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.SetScalingFactor);
            //
            // acdate_t
            //
            this.acdate_t = new System.Windows.Forms.Label();
            this.acdate_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.acdate_t.ForeColor = System.Drawing.Color.Black;
            this.acdate_t.Location = new System.Drawing.Point(0, 6);
            this.acdate_t.Name = "acdate_t";
            this.acdate_t.Size = new System.Drawing.Size(95, 13);
            this.acdate_t.Text = "Article Count Date";
            this.acdate_t.TextAlign = ContentAlignment.MiddleRight;
            this.acdate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(acdate_t);

            //
            // scaling_factor_t
            //
            this.scaling_factor_t = new System.Windows.Forms.Label();
            this.scaling_factor_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.scaling_factor_t.ForeColor = System.Drawing.Color.Black;
            this.scaling_factor_t.Location = new System.Drawing.Point(15, 28);
            this.scaling_factor_t.Name = "scaling_factor_t";
            this.scaling_factor_t.Size = new System.Drawing.Size(80, 13);
            this.scaling_factor_t.Text = "Scaling Factor";
            this.scaling_factor_t.TextAlign = ContentAlignment.MiddleRight;
            this.scaling_factor_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(scaling_factor_t);
            //
            // updateall
            //
            updateall = new System.Windows.Forms.CheckBox();
            this.updateall.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Updateall", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateall.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            //?this.updateall.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.updateall.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.updateall.ForeColor = System.Drawing.Color.Black;
            this.updateall.Location = new System.Drawing.Point(1, 45);
            this.updateall.Name = "updateall";
            this.updateall.Text = "Update All Counts";
            this.updateall.Size = new System.Drawing.Size(112, 15);
            this.updateall.TabIndex = 30;
            this.Controls.Add(updateall);

            //
            // acdate
            //
            acdate = new System.Windows.Forms.MaskedTextBox();
            this.acdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.acdate.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //?this.acdate.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
            this.acdate.Location = new System.Drawing.Point(97, 4);
            this.acdate.Name = "acdate";
            this.acdate.Size = new System.Drawing.Size(62, 13);
            //?this.acdate.TextAlign = ContentAlignment.MiddleLeft;
            //?this.acdate.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);

            this.acdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Acdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.acdate.Mask = "00/00/00";
            this.acdate.DataBindings[0].FormatString = "dd/MM/yy";
            this.acdate.InsertKeyMode = InsertKeyMode.Overwrite;
            this.acdate.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            this.acdate.PromptChar = '0';
            this.acdate.DataBindings[0].DataSourceNullValue = null;
            this.acdate.TabIndex = 10;
            this.Controls.Add(acdate);

            //
            // scaling_factor
            //
            scaling_factor = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.scaling_factor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scaling_factor.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //?this.scaling_factor.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
            this.scaling_factor.Location = new System.Drawing.Point(97, 24);
            this.scaling_factor.Name = "scaling_factor";
            this.scaling_factor.Size = new System.Drawing.Size(62, 13);
            //?this.scaling_factor.TextAlign = ContentAlignment.MiddleRight;
            //?this.scaling_factor.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.scaling_factor.EditMask = "##.000000";
            this.scaling_factor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ScalingFactor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.scaling_factor.DataBindings[0].FormatString = "##.000000";
            this.scaling_factor.InsertKeyMode = InsertKeyMode.Overwrite;
            this.scaling_factor.TextAlign = HorizontalAlignment.Right;
            this.scaling_factor.PromptChar = ' ';
            //this.scaling_factor.DataBindings[0].DataSourceNullValue = null;
            this.scaling_factor.TabIndex = 20;
            this.Controls.Add(scaling_factor);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
        }
        #endregion

    }
}

