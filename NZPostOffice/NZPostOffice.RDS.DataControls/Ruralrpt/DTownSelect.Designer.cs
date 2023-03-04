namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DTownSelect
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
            this.Name = "DTownSelect";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.TownSelect);
            #region town_list define
            this.town_list = new Metex.Windows.DataEntityCombo();
            this.town_list.Name = "town_list";
            this.town_list.Location = new System.Drawing.Point(100, 21);
            this.town_list.Size = new System.Drawing.Size(150, 17);
            this.town_list.TabIndex = 10;
            this.town_list.Font = new System.Drawing.Font("Arial", 8);
            //this.town_list.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.town_list.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Town", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.town_list.DisplayMember = "TcName";
            this.town_list.ValueMember = "TcName";
            this.town_list.AutoRetrieve = true;
            #endregion
            this.Controls.Add(town_list);
            this.Size = new System.Drawing.Size(220, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private Metex.Windows.DataEntityCombo town_list;
    }
}
