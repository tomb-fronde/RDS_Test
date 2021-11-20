using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsInvoice;
namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DDddwRegions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox rgn_name;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDddwRegions";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwRegions);
            //
            // rgn_name
            //
            rgn_name = new System.Windows.Forms.TextBox();
            this.rgn_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rgn_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rgn_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rgn_name.Location = new System.Drawing.Point(0, 1);
            this.rgn_name.MaxLength = 40;
            this.rgn_name.Name = "rgn_name";
            this.rgn_name.Size = new System.Drawing.Size(246, 13);
            this.rgn_name.TextAlign = HorizontalAlignment.Left;
            this.rgn_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "RgnName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rgn_name.TabIndex = 20;
            this.Controls.Add(rgn_name);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          
        }
        #endregion

    }
}
