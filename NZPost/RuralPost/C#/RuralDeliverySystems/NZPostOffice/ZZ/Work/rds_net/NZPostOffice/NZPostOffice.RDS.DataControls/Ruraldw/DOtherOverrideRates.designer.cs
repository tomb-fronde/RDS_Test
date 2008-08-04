using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DOtherOverrideRates
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
            this.Name = "DOtherOverrideRates";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.OtherOverrideRates);
            #region st_renewal define
            this.st_renewal = new System.Windows.Forms.Label();
            this.st_renewal.Name = "st_renewal";
            this.st_renewal.Location = new System.Drawing.Point(5, 6);
            this.st_renewal.Size = new System.Drawing.Size(281, 14);
            this.st_renewal.TabIndex = 0;
            this.st_renewal.Font = new System.Drawing.Font("Arial", 8,System.Drawing.FontStyle.Bold);
            this.st_renewal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_renewal.Text = "There are no 'other'  rates to display";
            #endregion
            this.Controls.Add(st_renewal);
            #region mor_name_t define
            this.mor_name_t = new System.Windows.Forms.Label();
            this.mor_name_t.Name = "mor_name_t";
            this.mor_name_t.Location = new System.Drawing.Point(31, 26);
            this.mor_name_t.Size = new System.Drawing.Size(77, 14);
            this.mor_name_t.TabIndex = 0;
            this.mor_name_t.Font = new System.Drawing.Font("Arial", 8);
            this.mor_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mor_name_t.Text = "Name:";
            #endregion
            //this.Controls.Add(mor_name_t);
            #region mor_value_t define
            this.mor_value_t = new System.Windows.Forms.Label();
            this.mor_value_t.Name = "mor_value_t";
            this.mor_value_t.Location = new System.Drawing.Point(31, 55);
            this.mor_value_t.Size = new System.Drawing.Size(77, 14);
            this.mor_value_t.TabIndex = 0;
            this.mor_value_t.Font = new System.Drawing.Font("Arial", 8);
            this.mor_value_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mor_value_t.Text = "Value:";
            #endregion
            //this.Controls.Add(mor_value_t);
            #region mor_km_flag_t define
            this.mor_km_flag_t = new System.Windows.Forms.Label();
            this.mor_km_flag_t.Name = "mor_km_flag_t";
            this.mor_km_flag_t.Location = new System.Drawing.Point(31, 84);
            this.mor_km_flag_t.Size = new System.Drawing.Size(77, 14);
            this.mor_km_flag_t.TabIndex = 0;
            this.mor_km_flag_t.Font = new System.Drawing.Font("Arial", 8);
            this.mor_km_flag_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mor_km_flag_t.Text = "Km Flag:";
            #endregion
            //this.Controls.Add(mor_km_flag_t);
            #region mor_annual_flag_t define
            this.mor_annual_flag_t = new System.Windows.Forms.Label();
            this.mor_annual_flag_t.Name = "mor_annual_flag_t";
            this.mor_annual_flag_t.Location = new System.Drawing.Point(31, 114);
            this.mor_annual_flag_t.Size = new System.Drawing.Size(77, 14);
            this.mor_annual_flag_t.TabIndex = 0;
            this.mor_annual_flag_t.Font = new System.Drawing.Font("Arial", 8);
            this.mor_annual_flag_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mor_annual_flag_t.Text = "Annual Flag:";
            #endregion
            //this.Controls.Add(mor_annual_flag_t);
            #region mor_km_flag define
            this.mor_km_flag = new System.Windows.Forms.CheckBox();
            this.mor_km_flag.Name = "mor_km_flag";
            this.mor_km_flag.Location = new System.Drawing.Point(113, 84);
            this.mor_km_flag.Size = new System.Drawing.Size(16, 14);
            this.mor_km_flag.TabIndex = 30;
            this.mor_km_flag.Font = new System.Drawing.Font("Arial", 8);
            this.mor_km_flag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mor_km_flag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mor_km_flag.Text = "";
            this.mor_km_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mor_km_flag.ThreeState = true;
            #endregion
            //this.Controls.Add(mor_km_flag);
            #region mor_annual_flag define
            this.mor_annual_flag = new System.Windows.Forms.CheckBox();
            this.mor_annual_flag.Name = "mor_annual_flag";
            this.mor_annual_flag.Location = new System.Drawing.Point(113, 114);
            this.mor_annual_flag.Size = new System.Drawing.Size(16, 13);
            this.mor_annual_flag.TabIndex = 40;
            this.mor_annual_flag.Font = new System.Drawing.Font("Arial", 8);
            this.mor_annual_flag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mor_annual_flag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mor_annual_flag.Text = "";
            this.mor_annual_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mor_annual_flag.ThreeState = true;
            #endregion
            //this.Controls.Add(mor_annual_flag);
            #region mor_name define
            this.mor_name = new System.Windows.Forms.TextBox();
            this.mor_name.Name = "mor_name";
            this.mor_name.Location = new System.Drawing.Point(113, 26);
            this.mor_name.Size = new System.Drawing.Size(196, 20);
            this.mor_name.TabIndex = 10;
            this.mor_name.Font = new System.Drawing.Font("Arial", 8);
            this.mor_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mor_name.MaxLength = 50;
            this.mor_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "MorName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            //this.Controls.Add(mor_name);
            #region mor_value define
            this.mor_value = new System.Windows.Forms.MaskedTextBox();
            this.mor_value.Name = "mor_value";
            this.mor_value.Location = new System.Drawing.Point(113, 55);
            this.mor_value.Size = new System.Drawing.Size(196, 20);
            this.mor_value.TabIndex = 20;
            this.mor_value.Font = new System.Drawing.Font("Arial", 8);
            this.mor_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mor_value.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "MorValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mor_value.Mask = "#######.00";
            #endregion
            //this.Controls.Add(mor_value);
            // 
            // panel1
            // 
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.Controls.Add(this.mor_name);
            this.panel1.Controls.Add(this.mor_value);
            this.panel1.Controls.Add(this.mor_name_t);
            this.panel1.Controls.Add(this.mor_annual_flag);
            this.panel1.Controls.Add(this.mor_value_t);
            this.panel1.Controls.Add(this.mor_km_flag);
            this.panel1.Controls.Add(this.mor_km_flag_t);
            this.panel1.Controls.Add(this.mor_annual_flag_t);
            this.panel1.Location = new System.Drawing.Point(31, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 157);
            this.panel1.TabIndex = 41;
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(650, 300);
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RetrieveEnd += new System.EventHandler(DOtherOverrideRates_RetrieveEnd);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ActiveEvent();
        }

        private void ActiveEvent()
        {
            foreach (Control var in this.Controls)
            {
                var.GotFocus += new System.EventHandler(var_GotFocus);
            }
        }

        void var_GotFocus(object sender, System.EventArgs e)
        {
            this.OnGotFocus(e);
        }

        #endregion

        private System.Windows.Forms.Label st_renewal;
        private System.Windows.Forms.Label mor_name_t;
        private System.Windows.Forms.Label mor_value_t;
        private System.Windows.Forms.Label mor_km_flag_t;
        private System.Windows.Forms.Label mor_annual_flag_t;
        private System.Windows.Forms.CheckBox mor_km_flag;
        private System.Windows.Forms.CheckBox mor_annual_flag;
        private System.Windows.Forms.TextBox mor_name;
        private System.Windows.Forms.MaskedTextBox mor_value;
        private System.Windows.Forms.Panel panel1;
    }
}
