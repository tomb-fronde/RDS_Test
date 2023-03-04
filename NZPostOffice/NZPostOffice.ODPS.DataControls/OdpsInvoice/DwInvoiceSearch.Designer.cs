using NZPostOffice.Shared.VisualComponents;
namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceSearch
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
            this.Name = "DwInvoiceSearch";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceSearch);

            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Name = "t_1";
            this.t_1.Location = new System.Drawing.Point(187, 10);
            this.t_1.Size = new System.Drawing.Size(22, 14);
            this.t_1.TabIndex = 0;
            this.t_1.Font = new System.Drawing.Font("Arial", 8);
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_1.Text = "To:";
            this.Controls.Add(t_1);

            this.end_date = new DateTimeMaskedTextBox();
            this.end_date.Name = "end_date";
            this.end_date.Location = new System.Drawing.Point(214, 7);
            this.end_date.Size = new System.Drawing.Size(68, 20);
            this.end_date.TabIndex = 10;
            this.end_date.Font = new System.Drawing.Font("Arial", 8);
            this.end_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.end_date.Mask = "00/00/0000";
            this.end_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.end_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.end_date.DataBindings[0].DataSourceNullValue = null;
            this.Controls.Add(end_date);

            this.region_id = new Metex.Windows.DataEntityCombo();
            this.region_id.Name = "region_id";
            this.region_id.Location = new System.Drawing.Point(104, 30);
            this.region_id.Size = new System.Drawing.Size(179, 22);
            this.region_id.TabIndex = 20;
            this.region_id.Font = new System.Drawing.Font("Arial", 8);
            //this.region_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.ValueMember = "RegionId";
            this.region_id.AutoRetrieve = true;
            this.Controls.Add(region_id);

            this.owner_driver = new System.Windows.Forms.TextBox();
            this.owner_driver.Name = "owner_driver";
            this.owner_driver.Location = new System.Drawing.Point(104, 55);
            this.owner_driver.Size = new System.Drawing.Size(179, 20);
            this.owner_driver.TabIndex = 30;
            this.owner_driver.Font = new System.Drawing.Font("Arial", 8);
            this.owner_driver.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.owner_driver.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OwnerDriver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(owner_driver);

            this.contract_no_1 = new System.Windows.Forms.TextBox();
            this.contract_no_1.Name = "contract_no_1";
            this.contract_no_1.Location = new System.Drawing.Point(104, 78);
            this.contract_no_1.Size = new System.Drawing.Size(68, 20);
            this.contract_no_1.TabIndex = 40;
            this.contract_no_1.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.contract_no_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(contract_no_1);

            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.ct_key.Name = "ct_key";
            this.ct_key.Location = new System.Drawing.Point(104, 101);
            this.ct_key.Size = new System.Drawing.Size(179, 22);
            this.ct_key.TabIndex = 50;
            this.ct_key.Font = new System.Drawing.Font("Arial", 8);
            //this.ct_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.AutoRetrieve = true;
            this.Controls.Add(ct_key);

            this.start_date = new DateTimeMaskedTextBox();
            this.start_date.Name = "start_date";
            this.start_date.Location = new System.Drawing.Point(104, 7);
            this.start_date.Size = new System.Drawing.Size(68, 20);
            this.start_date.TabIndex = 0;
            //?this.start_date.Enabled = false;
            this.start_date.ReadOnly = true;
            this.start_date.Font = new System.Drawing.Font("Arial", 8);
            this.start_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.start_date.Mask = "00/00/0000";
            this.start_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.start_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.start_date.DataBindings[0].DataSourceNullValue = null;
            this.Controls.Add(start_date);

            this.start_date_t = new System.Windows.Forms.Label();
            this.start_date_t.Name = "start_date_t";
            this.start_date_t.Location = new System.Drawing.Point(67, 10);
            this.start_date_t.Size = new System.Drawing.Size(35, 14);
            this.start_date_t.TabIndex = 0;
            this.start_date_t.Font = new System.Drawing.Font("Arial", 8);
            this.start_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.start_date_t.Text = "From:";
            this.Controls.Add(start_date_t);

            this.t_2 = new System.Windows.Forms.Label();
            this.t_2.Name = "t_2";
            this.t_2.Location = new System.Drawing.Point(58, 35);
            this.t_2.Size = new System.Drawing.Size(44, 14);
            this.t_2.TabIndex = 0;
            this.t_2.Font = new System.Drawing.Font("Arial", 8);
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_2.Text = "Region:";
            this.Controls.Add(t_2);

            this.owner_driver_t = new System.Windows.Forms.Label();
            this.owner_driver_t.Name = "owner_driver_t";
            this.owner_driver_t.Location = new System.Drawing.Point(24, 58);
            this.owner_driver_t.Size = new System.Drawing.Size(78, 14);
            this.owner_driver_t.TabIndex = 0;
            this.owner_driver_t.Font = new System.Drawing.Font("Arial", 8);
            this.owner_driver_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.owner_driver_t.Text = "Owner Driver:";
            this.Controls.Add(owner_driver_t);

            this.t_3 = new System.Windows.Forms.Label();
            this.t_3.Name = "t_3";
            this.t_3.Location = new System.Drawing.Point(21, 82);
            this.t_3.Size = new System.Drawing.Size(81, 14);
            this.t_3.TabIndex = 0;
            this.t_3.Font = new System.Drawing.Font("Arial", 8);
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_3.Text = "Contract No:";
            this.Controls.Add(t_3);

            this.t_4 = new System.Windows.Forms.Label();
            this.t_4.Name = "t_4";
            this.t_4.Location = new System.Drawing.Point(21, 106);
            this.t_4.Size = new System.Drawing.Size(81, 14);
            this.t_4.TabIndex = 0;
            this.t_4.Font = new System.Drawing.Font("Arial", 8);
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_4.Text = "Contract Type:";
            this.Controls.Add(t_4);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label t_1;
        private DateTimeMaskedTextBox end_date;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.TextBox owner_driver;
        private System.Windows.Forms.TextBox contract_no_1;
        private Metex.Windows.DataEntityCombo ct_key;
        private DateTimeMaskedTextBox start_date;
        private System.Windows.Forms.Label start_date_t;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label owner_driver_t;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_4;
    }
}


