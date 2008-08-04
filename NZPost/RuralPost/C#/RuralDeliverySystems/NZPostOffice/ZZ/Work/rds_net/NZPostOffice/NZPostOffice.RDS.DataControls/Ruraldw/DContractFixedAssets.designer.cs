using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractFixedAssetsTest
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
            this.n_39995586 = new System.Windows.Forms.Label();
            this.fa_fixed_asset_no_t = new System.Windows.Forms.Label();
            this.fat_id_t = new System.Windows.Forms.Label();
            this.fa_owner_t = new System.Windows.Forms.Label();
            this.fa_fixed_asset_no = new System.Windows.Forms.TextBox();
            this.fa_owner = new System.Windows.Forms.TextBox();
            this.fa_purchase_date_t = new System.Windows.Forms.Label();
            this.fa_purchase_price_t = new System.Windows.Forms.Label();
            this.fat_id = new Metex.Windows.DataEntityCombo();
            this.n_24415962 = new Metex.Windows.DataEntityCombo();
            this.fa_purchase_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// System.Windows.Forms.MaskedTextBox();
            this.fa_purchase_price = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.l_2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractFixedAssets);
            this.bindingSource.ListChanged +=new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            // 
            // fa_fixed_asset_no_t
            // 
            this.fa_fixed_asset_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_fixed_asset_no_t.Location = new System.Drawing.Point(0, 5);
            this.fa_fixed_asset_no_t.Name = "fa_fixed_asset_no_t";
            this.fa_fixed_asset_no_t.Size = new System.Drawing.Size(90, 13);
            this.fa_fixed_asset_no_t.TabIndex = 0;
            this.fa_fixed_asset_no_t.Text = "Fixed Asset No";
            this.fa_fixed_asset_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fat_id_t
            // 
            this.fat_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fat_id_t.Location = new System.Drawing.Point(0, 29);
            this.fat_id_t.Name = "fat_id_t";
            this.fat_id_t.Size = new System.Drawing.Size(90, 13);
            this.fat_id_t.TabIndex = 0;
            this.fat_id_t.Text = "Fixed Asset Type";
            this.fat_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fa_owner_t
            // 
            this.fa_owner_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_owner_t.Location = new System.Drawing.Point(49, 53);
            this.fa_owner_t.Name = "fa_owner_t";
            this.fa_owner_t.Size = new System.Drawing.Size(41, 13);
            this.fa_owner_t.TabIndex = 0;
            this.fa_owner_t.Text = "Owner";
            this.fa_owner_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fa_fixed_asset_no
            // 
            this.fa_fixed_asset_no.BackColor = System.Drawing.Color.Aqua;
            this.fa_fixed_asset_no.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fa_fixed_asset_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FaFixedAssetNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_fixed_asset_no.Enabled = true;
            this.fa_fixed_asset_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_fixed_asset_no.Location = new System.Drawing.Point(92, 2);
            this.fa_fixed_asset_no.MaxLength = 10;
            this.fa_fixed_asset_no.Name = "fa_fixed_asset_no";
            this.fa_fixed_asset_no.Size = new System.Drawing.Size(80, 20);
            this.fa_fixed_asset_no.TabIndex = 10;
            this.fa_fixed_asset_no.ReadOnly = true;
            this.fa_fixed_asset_no.Validating += new System.ComponentModel.CancelEventHandler(TextBox_Validating);
            // 
            // fa_owner
            // 
            this.fa_owner.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FaOwner", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_owner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_owner.Location = new System.Drawing.Point(92, 51);
            this.fa_owner.MaxLength = 40;
            this.fa_owner.Name = "fa_owner";
            this.fa_owner.Size = new System.Drawing.Size(205, 20);
            this.fa_owner.TabIndex = 40;
            // 
            // fa_purchase_date_t
            // 
            this.fa_purchase_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_purchase_date_t.Location = new System.Drawing.Point(318, 6);
            this.fa_purchase_date_t.Name = "fa_purchase_date_t";
            this.fa_purchase_date_t.Size = new System.Drawing.Size(81, 13);
            this.fa_purchase_date_t.TabIndex = 0;
            this.fa_purchase_date_t.Text = "Purchase Date";
            this.fa_purchase_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fa_purchase_price_t
            // 
            this.fa_purchase_price_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_purchase_price_t.Location = new System.Drawing.Point(317, 30);
            this.fa_purchase_price_t.Name = "fa_purchase_price_t";
            this.fa_purchase_price_t.Size = new System.Drawing.Size(82, 13);
            this.fa_purchase_price_t.TabIndex = 0;
            this.fa_purchase_price_t.Text = "Purchase Price";
            this.fa_purchase_price_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fat_id
            // 
            this.fat_id.AutoRetrieve = true;
            this.fat_id.BackColor = System.Drawing.Color.Aqua;
            this.fat_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FatId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fat_id.DisplayMember = "FatDescription";
            this.fat_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fat_id.Location = new System.Drawing.Point(92, 27);
            this.fat_id.Name = "fat_id";
            this.fat_id.Size = new System.Drawing.Size(156, 21);
            this.fat_id.TabIndex = 20;
            this.fat_id.Value = null;
            this.fat_id.ValueMember = "FatId";
            this.fat_id.DataBindings[0].DataSourceNullValue = null;
            this.fat_id.DataBindings[0].NullValue = null;
            this.fat_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fat_id.SelectedIndexChanged += new System.EventHandler(fat_id_SelectedIndexChanged);
             //
             //n_24415962
             //
            this.n_24415962.AutoRetrieve = true;
            this.n_24415962.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FatId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_24415962.DisplayMember = "FatDescription";
            this.n_24415962.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_24415962.Location = new System.Drawing.Point(92, 27);
            this.n_24415962.Name = "n_24415962";
            this.n_24415962.Size = new System.Drawing.Size(156, 21);
            this.n_24415962.TabIndex = 30;
            this.n_24415962.Value = null;
            this.n_24415962.ValueMember = "FatId";
            // 
            // fa_purchase_date
            // 
            this.fa_purchase_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FaPurchaseDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_purchase_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_purchase_date.Location = new System.Drawing.Point(406, 5);
            this.fa_purchase_date.Mask = "00/00/0000";
            this.fa_purchase_date.Name = "fa_purchase_date";
            this.fa_purchase_date.Size = new System.Drawing.Size(72, 20);
            this.fa_purchase_date.TabIndex = 50;
            this.fa_purchase_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fa_purchase_date.ValidatingType = typeof(System.DateTime);
            //this.fa_purchase_date.PromptChar = '0';
            this.fa_purchase_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            //this.fa_purchase_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.fa_purchase_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            //this.fa_purchase_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // fa_purchase_price
            // 
            this.fa_purchase_price.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "FaPurchasePrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_purchase_price.DataBindings[0].FormatString = "###,###.00";
            this.fa_purchase_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fa_purchase_price.Location = new System.Drawing.Point(406, 29);
            this.fa_purchase_price.EditMask = "###,###.00";
            this.fa_purchase_price.Name = "fa_purchase_price";
            this.fa_purchase_price.Size = new System.Drawing.Size(72, 20);
            this.fa_purchase_price.TabIndex = 60;
            this.fa_purchase_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fa_purchase_price.PromptChar = ' ';
            //this.fa_purchase_price.ValidatingType = typeof(System.Int32);
            this.fa_purchase_price.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fa_purchase_price.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // l_2
            // 
            this.l_2.Location = new System.Drawing.Point(7, 77);
            this.l_2.Name = "l_2";
            this.l_2.Size = new System.Drawing.Size(547, 1);
            this.l_2.TabIndex = 62;
            this.l_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // DContractFixedAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_2);
            this.Controls.Add(this.fa_fixed_asset_no_t);
            this.Controls.Add(this.fat_id_t);
            this.Controls.Add(this.fa_owner_t);
            this.Controls.Add(this.fa_fixed_asset_no);
            this.Controls.Add(this.fa_owner);
            this.Controls.Add(this.fa_purchase_date_t);
            this.Controls.Add(this.fa_purchase_price_t);
            
            this.Controls.Add(this.fat_id);
            //?this.Controls.Add(this.n_24415962);
            this.Controls.Add(this.fa_purchase_date);
            this.Controls.Add(this.fa_purchase_price);
            this.Name = "DContractFixedAssets";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void fat_id_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.AcceptText();
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                return;
            }

            if(e.NewIndex >= 0)
            {
                if (((ContractFixedAssets)(bindingSource.List[e.NewIndex])).IsNew)
                {
                    fa_fixed_asset_no.ReadOnly = false;
                }
                else
                {
                    fa_fixed_asset_no.ReadOnly = true;
                }
            }
        }

        #endregion

        private System.Windows.Forms.Label n_39995586;
        private System.Windows.Forms.Label fa_fixed_asset_no_t;
        private System.Windows.Forms.Label fat_id_t;
        private System.Windows.Forms.Label fa_owner_t;
        private System.Windows.Forms.TextBox fa_fixed_asset_no;
        private System.Windows.Forms.TextBox fa_owner;
        private System.Windows.Forms.Label fa_purchase_date_t;
        private System.Windows.Forms.Label fa_purchase_price_t;
        private Metex.Windows.DataEntityCombo fat_id;
        private Metex.Windows.DataEntityCombo n_24415962;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox fa_purchase_date;// System.Windows.Forms.MaskedTextBox fa_purchase_date;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox fa_purchase_price;
        private System.Windows.Forms.Panel l_2;
    }
}
