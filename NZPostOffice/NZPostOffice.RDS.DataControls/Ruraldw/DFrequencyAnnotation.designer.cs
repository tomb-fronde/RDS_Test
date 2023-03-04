using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DFrequencyAnnotation
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.CheckBox   rf_annotation_print;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DFrequencyAnnotation";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FrequencyAnnotation);

			//
			// rf_annotation_print
			//
			rf_annotation_print = new System.Windows.Forms.CheckBox();
			this.rf_annotation_print.DataBindings.Add(new System.Windows.Forms.Binding("Checked",
				this.bindingSource, "RfAnnotationPrint", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.rf_annotation_print.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//this.rf_annotation_print.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rf_annotation_print.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rf_annotation_print.ForeColor = System.Drawing.Color.Black;
			this.rf_annotation_print.Location = new System.Drawing.Point(3, 3);
			this.rf_annotation_print.Name = "rf_annotation_print";
			this.rf_annotation_print.Text = "Print Annotation with Route Description";
			this.rf_annotation_print.Size = new System.Drawing.Size(220, 18);
            this.rf_annotation_print.CheckAlign = ContentAlignment.MiddleRight;
			this.rf_annotation_print.TabIndex = 10;
			this.Controls.Add(rf_annotation_print);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;//ColorTranslator.FromWin32(80269524);
		}
		#endregion

	}
}
