using System.Windows.Forms;
using System.Drawing;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DQsContractorCriteria
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

        private System.Windows.Forms.MaskedTextBox suppno;
        private System.Windows.Forms.Label suppno_t;
        private System.Windows.Forms.Label suppname_t;
        private System.Windows.Forms.TextBox suppname;
        private System.Windows.Forms.Label t_1;
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DQsContractorCriteria";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsContractorCriteria);
            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(72, 0);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(80, 13);
            this.t_1.Text = "Search Criteria";            
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_1);
			//
			// suppno_t
			//
			this.suppno_t = new System.Windows.Forms.Label();
			this.suppno_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.suppno_t.ForeColor = System.Drawing.Color.Black;
			this.suppno_t.Location = new System.Drawing.Point(1, 17);
			this.suppno_t.Name = "suppno_t";
			this.suppno_t.Size = new System.Drawing.Size(70, 13);
			this.suppno_t.Text = "Supplier No";
            this.suppno_t.TextAlign = ContentAlignment.MiddleRight;
			this.suppno_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(suppno_t);

			//
			// suppname_t
			//
			this.suppname_t = new System.Windows.Forms.Label();
			this.suppname_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.suppname_t.ForeColor = System.Drawing.Color.Black;
			this.suppname_t.Location = new System.Drawing.Point(1, 37);
			this.suppname_t.Name = "suppname_t";
			this.suppname_t.Size = new System.Drawing.Size(70, 13);
			this.suppname_t.Text = "Owner Driver";
			this.suppname_t.TextAlign = ContentAlignment.MiddleRight;
			this.suppname_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(suppname_t);


			//
			// suppno
			//
			suppno = new System.Windows.Forms.MaskedTextBox();
			this.suppno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.suppno.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.suppno.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
			this.suppno.Location = new System.Drawing.Point(74, 17);
			this.suppno.Name = "suppno";
			this.suppno.Size = new System.Drawing.Size(40, 13);
            this.suppno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;// ContentAlignment.MiddleRight;
			//this.suppno.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.suppno.Mask = "";
			this.suppno.DataBindings.Add(new System.Windows.Forms.Binding( "Text", 
				this.bindingSource, "Suppno", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.suppno.TabIndex = 10;
			this.Controls.Add( suppno );
			//
			// suppname
			//
			suppname = new System.Windows.Forms.TextBox();
			this.suppname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.suppname.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.suppname.ForeColor = System.Drawing.Color.Black;
			this.suppname.Location = new System.Drawing.Point(74, 37);
			this.suppname.MaxLength = 40;
			this.suppname.Name = "suppname";
			this.suppname.Size = new System.Drawing.Size(200, 13);
			this.suppname.TextAlign = HorizontalAlignment.Left;
			//this.suppname.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.suppname.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "Suppname", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.suppname.TabIndex = 20;
			this.Controls.Add(suppname);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
		}
        #endregion

	}
}
