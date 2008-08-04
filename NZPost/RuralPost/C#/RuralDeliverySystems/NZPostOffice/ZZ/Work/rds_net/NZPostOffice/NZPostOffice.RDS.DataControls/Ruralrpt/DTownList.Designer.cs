using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DTownList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn tc_name;
        private TextBox tc_name;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //?private Metex.Windows.DataEntityGrid grid;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DTownList";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(TownList);
            //
            // tc_name
            //
            tc_name = new System.Windows.Forms.TextBox();
            this.tc_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tc_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.tc_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tc_name.Location = new System.Drawing.Point(0, 1);
            this.tc_name.MaxLength = 40;
            this.tc_name.Name = "tc_name";
            this.tc_name.Size = new System.Drawing.Size(246, 13);
            this.tc_name.TextAlign = HorizontalAlignment.Left;
            //this.tc_name.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.tc_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TcName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tc_name.TabIndex = 20;
            this.Controls.Add(tc_name);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion

    }
}
