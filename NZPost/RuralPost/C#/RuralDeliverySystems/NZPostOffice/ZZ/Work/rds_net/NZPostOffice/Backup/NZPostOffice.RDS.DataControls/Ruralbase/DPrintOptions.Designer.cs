namespace NZPostOffice.RDS.DataControls.Ruralbase
{
    partial class DPrintOptions
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
            this.Name = "DPrintOptions";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralbase.PrintOptions);
            #region pagerange_t define
            this.pagerange_t = new System.Windows.Forms.GroupBox();
            this.pagerange_t.Name = "pagerange_t";
            this.pagerange_t.Location = new System.Drawing.Point(10, 33);
            this.pagerange_t.Size = new System.Drawing.Size(207, 88);
            this.pagerange_t.TabIndex = 0;
            this.pagerange_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.pagerange_t.Text = "Page Range";
            #endregion
            this.Controls.Add(pagerange_t);
            this.pagerange_3 = new System.Windows.Forms.RadioButton();
            this.pagerange_2 = new System.Windows.Forms.RadioButton();
            this.pagerange_1 = new System.Windows.Forms.RadioButton();
            // 
            // pagerange_3
            // 
            this.pagerange_3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PageRange3", false, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagerange_3.AutoSize = true;
            this.pagerange_3.Location = new System.Drawing.Point(16, 61);
            this.pagerange_3.Name = "pagerange_3";
            this.pagerange_3.Size = new System.Drawing.Size(48, 17);
            this.pagerange_3.TabIndex = 43;
            this.pagerange_3.TabStop = true;
            this.pagerange_3.Text = "From";
            this.pagerange_3.UseVisualStyleBackColor = true;
            this.pagerange_t.Controls.Add(this.pagerange_3);
            // 
            // pagerange_2
            // 
            this.pagerange_2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PageRange2", false, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagerange_2.AutoSize = true;
            this.pagerange_2.Location = new System.Drawing.Point(16, 38);
            this.pagerange_2.Name = "pagerange_2";
            this.pagerange_2.Size = new System.Drawing.Size(87, 17);
            this.pagerange_2.TabIndex = 42;
            this.pagerange_2.TabStop = true;
            this.pagerange_2.Text = "Current Page";
            this.pagerange_2.UseVisualStyleBackColor = true;
            this.pagerange_t.Controls.Add(this.pagerange_2);
            // 
            // pagerange_1
            // 
            this.pagerange_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PageRange1", false, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagerange_1.AutoSize = true;
            this.pagerange_1.Location = new System.Drawing.Point(16, 17);
            this.pagerange_1.Name = "pagerange_1";
            this.pagerange_1.Size = new System.Drawing.Size(36, 17);
            this.pagerange_1.TabIndex = 41;
            this.pagerange_1.TabStop = true;
            this.pagerange_1.Text = "All";
            this.pagerange_1.UseVisualStyleBackColor = true;
            this.pagerange_t.Controls.Add(this.pagerange_1);

            #region pagefrom define
            this.pagefrom = new System.Windows.Forms.MaskedTextBox();
            this.pagefrom.Name = "pagefrom";
            this.pagefrom.Location = new System.Drawing.Point(65, 60);
            this.pagefrom.Size = new System.Drawing.Size(47, 20);
            this.pagefrom.TabIndex = 30;
            this.pagefrom.Enabled = false;
            this.pagefrom.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.pagefrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pagefrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Pagefrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagefrom.Mask = "#####";
            #endregion
            this.pagerange_t.Controls.Add(this.pagefrom);
            #region pageto_t define
            this.pageto_t = new System.Windows.Forms.Label();
            this.pageto_t.Name = "pageto_t";
            this.pageto_t.Location = new System.Drawing.Point(118, 64);
            this.pageto_t.Size = new System.Drawing.Size(22, 13);
            this.pageto_t.TabIndex = 0;
            this.pageto_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.pageto_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pageto_t.Text = "To";
            #endregion
            this.pagerange_t.Controls.Add(this.pageto_t);
            #region pageto define
            this.pageto = new System.Windows.Forms.MaskedTextBox();
            this.pageto.Name = "pageto";
            this.pageto.Location = new System.Drawing.Point(146, 60);
            this.pageto.Size = new System.Drawing.Size(46, 20);
            this.pageto.TabIndex = 40;
            this.pageto.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.pageto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pageto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Pageto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pageto.Mask = "#####";
            #endregion
            this.pagerange_t.Controls.Add(this.pageto);
            #region copys_t define
            this.copys_t = new System.Windows.Forms.Label();
            this.copys_t.Name = "copys_t";
            this.copys_t.Location = new System.Drawing.Point(0, 9);
            this.copys_t.Size = new System.Drawing.Size(56, 13);
            this.copys_t.TabIndex = 0;
            this.copys_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.copys_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.copys_t.Text = "Copies:";
            #endregion
            this.Controls.Add(copys_t);
            #region copys define
            this.copys = new System.Windows.Forms.MaskedTextBox();
            this.copys.Name = "copys";
            this.copys.Location = new System.Drawing.Point(64, 5);
            this.copys.Size = new System.Drawing.Size(52, 20);
            this.copys.TabIndex = 10;
            this.copys.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.copys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.copys.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Copys", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.copys.Mask = "###";
            #endregion
            this.Controls.Add(copys);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.GroupBox pagerange_t;
        private System.Windows.Forms.MaskedTextBox pagefrom;
        private System.Windows.Forms.Label pageto_t;
        private System.Windows.Forms.MaskedTextBox pageto;
        private System.Windows.Forms.Label copys_t;
        private System.Windows.Forms.MaskedTextBox copys;
        private System.Windows.Forms.RadioButton pagerange_3;
        private System.Windows.Forms.RadioButton pagerange_2;
        private System.Windows.Forms.RadioButton pagerange_1;

    }
}
