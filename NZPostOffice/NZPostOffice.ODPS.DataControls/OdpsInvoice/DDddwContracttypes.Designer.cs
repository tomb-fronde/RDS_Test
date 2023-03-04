using NZPostOffice.ODPS.Entity.OdpsInvoice;
using System.Windows.Forms;
namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DDddwContracttypes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox contract_type;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDddwContracttypes";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwContracttypes);
            //
            // contract_type
            //
            contract_type = new System.Windows.Forms.TextBox();
            this.contract_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contract_type.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.contract_type.ForeColor = System.Drawing.SystemColors.WindowText;
            this.contract_type.Location = new System.Drawing.Point(0, 1);
            this.contract_type.MaxLength = 40;
            this.contract_type.Name = "contract_type";
            this.contract_type.Size = new System.Drawing.Size(246, 13);
            this.contract_type.TextAlign = HorizontalAlignment.Left;
            this.contract_type.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.contract_type.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ContractType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_type.TabIndex = 20;
            this.Controls.Add(contract_type);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          
        }
        #endregion

    }
}
