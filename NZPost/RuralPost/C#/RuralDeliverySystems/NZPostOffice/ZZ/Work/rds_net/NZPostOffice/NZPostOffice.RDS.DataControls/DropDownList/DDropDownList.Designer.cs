namespace NZPostOffice.RDS.DataControls.DropDownList
{
    partial class DDropDownList
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

        private Metex.Windows.DataEntityListBox listBox;

        private void InitializeComponent()
        {
            this.listBox = new Metex.Windows.DataEntityListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.DataControls.DropDownList.DropDownList);
            // 
            // listBox
            // 
            this.listBox.DataSource = this.bindingSource;
            this.listBox.DisplayMember = "DisplayValue";
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(199, 173);
            this.listBox.TabIndex = 0;
            // 
            // DDropDownList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox);
            this.Name = "DDropDownList";
            this.Size = new System.Drawing.Size(199, 176);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
