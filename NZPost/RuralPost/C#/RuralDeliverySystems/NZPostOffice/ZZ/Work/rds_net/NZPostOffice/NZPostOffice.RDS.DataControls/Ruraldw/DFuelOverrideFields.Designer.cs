using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DFuelOverrideFields
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

		private System.Windows.Forms.Label   al_renewal_group_t;
		private Metex.Windows.DataEntityCombo   al_renewal_group;
		private System.Windows.Forms.Label   ad_effective_date_t;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox ad_effective_date;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DFuelOverrideFields";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FuelOverrideFields);
			//
			// ad_effective_date_t
			//
			this.ad_effective_date_t = new System.Windows.Forms.Label();
			this.ad_effective_date_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ad_effective_date_t.ForeColor = System.Drawing.Color.Black;
			this.ad_effective_date_t.Location = new System.Drawing.Point(2, 1);
			this.ad_effective_date_t.Name = "ad_effective_date_t";
			this.ad_effective_date_t.Size = new System.Drawing.Size(78, 13);
			this.ad_effective_date_t.Text = "Effective Date";
			this.ad_effective_date_t.TextAlign = ContentAlignment.MiddleRight;
			this.ad_effective_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(ad_effective_date_t);


			//
			// ad_effective_date
			//
			ad_effective_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
			this.ad_effective_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ad_effective_date.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ad_effective_date.Location = new System.Drawing.Point(81, 1);
			this.ad_effective_date.Name = "ad_effective_date";
			this.ad_effective_date.Size = new System.Drawing.Size(87, 15);
            this.ad_effective_date.TextAlign = HorizontalAlignment.Right;			
            this.ad_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Value",
                this.bindingSource, "AdEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ad_effective_date.TabIndex = 10;
            this.ad_effective_date.Mask = "00/00/0000";
            this.ad_effective_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.ad_effective_date.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ad_effective_date.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            //this.ad_effective_date.PromptChar = '0';
            this.Controls.Add( ad_effective_date );
			//
			// al_renewal_group_t
			//
			this.al_renewal_group_t = new System.Windows.Forms.Label();
			this.al_renewal_group_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.al_renewal_group_t.ForeColor = System.Drawing.Color.Black;
			this.al_renewal_group_t.Location = new System.Drawing.Point(0, 24);
			this.al_renewal_group_t.Name = "al_renewal_group_t";
			this.al_renewal_group_t.Size = new System.Drawing.Size(81, 13);
			this.al_renewal_group_t.Text = "Renewal Group";
			this.al_renewal_group_t.TextAlign = ContentAlignment.MiddleRight;
			this.al_renewal_group_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(al_renewal_group_t);

			//
			// al_renewal_group
			//
			al_renewal_group = new Metex.Windows.DataEntityCombo();
			this.al_renewal_group.AutoRetrieve = true;
			//this.al_renewal_group.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.al_renewal_group.DisplayMember = "RgDescription";
			this.al_renewal_group.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.al_renewal_group.ForeColor = System.Drawing.Color.Black;
			this.al_renewal_group.Location = new System.Drawing.Point(81, 24);
			this.al_renewal_group.Name = "al_renewal_group";
			this.al_renewal_group.Size = new System.Drawing.Size(134, 15);
			this.al_renewal_group.TabIndex = 20;
			this.al_renewal_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.al_renewal_group.Value = null;
			this.al_renewal_group.ValueMember = "RgCode";
			this.al_renewal_group.DropDownWidth = 134;
			this.al_renewal_group.DataBindings.Add(
				new System.Windows.Forms.Binding("Value", this.bindingSource, "AlRenewalGroup", true,
				System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(al_renewal_group);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(79216776);
		}
		#endregion

	}
}
