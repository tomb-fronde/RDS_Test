using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DAddFixedAsset
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

        private System.Windows.Forms.Label fat_id_t;
        private System.Windows.Forms.Label fa_purchase_date_t;
        private System.Windows.Forms.Label fa_fixed_asset_no_t;
        private System.Windows.Forms.Label fa_purchase_price_t;
        private System.Windows.Forms.TextBox fa_owner;
        private System.Windows.Forms.TextBox fa_fixed_asset_no;
        private System.Windows.Forms.MaskedTextBox fa_purchase_date;
        private System.Windows.Forms.Label fa_owner_t;
        private System.Windows.Forms.MaskedTextBox fa_purchase_price;
        private Metex.Windows.DataEntityCombo fat_id;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DAddFixedAsset";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddFixedAsset);
            //
            // fa_fixed_asset_no
            //
            fa_fixed_asset_no = new System.Windows.Forms.TextBox();
            this.fa_fixed_asset_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fa_fixed_asset_no.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fa_fixed_asset_no.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fa_fixed_asset_no.Location = new System.Drawing.Point(92, 2);
            this.fa_fixed_asset_no.MaxLength = 10;
            this.fa_fixed_asset_no.Name = "fa_fixed_asset_no";
            this.fa_fixed_asset_no.Size = new System.Drawing.Size(55, 20);
            this.fa_fixed_asset_no.TextAlign = HorizontalAlignment.Left;
            //?this.fa_fixed_asset_no.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.fa_fixed_asset_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FaFixedAssetNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_fixed_asset_no.ReadOnly = true;
            this.Controls.Add(fa_fixed_asset_no);

            //
            // fat_id
            //
            fat_id = new Metex.Windows.DataEntityCombo();
            this.fat_id.AutoRetrieve = true;
            //?this.fat_id.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.fat_id.DisplayMember = "FatDescription";
            this.fat_id.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fat_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fat_id.Location = new System.Drawing.Point(92, 22);
            this.fat_id.Name = "fat_id";
            this.fat_id.Size = new System.Drawing.Size(156, 21);
            this.fat_id.TabIndex = 10;
            this.fat_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fat_id.Value = null;
            this.fat_id.ValueMember = "FatId";
            this.fat_id.DropDownWidth = 156;
            this.fat_id.DataBindings.Add(
                new System.Windows.Forms.Binding("Value", this.bindingSource, "FatId", true,
                System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(fat_id);

            //
            // fa_owner
            //
            fa_owner = new System.Windows.Forms.TextBox();
            this.fa_owner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fa_owner.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fa_owner.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fa_owner.Location = new System.Drawing.Point(92, 43);
            this.fa_owner.MaxLength = 40;
            this.fa_owner.Name = "fa_owner";
            this.fa_owner.Size = new System.Drawing.Size(205, 20);
            this.fa_owner.TextAlign = HorizontalAlignment.Left;
            //?this.fa_owner.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.fa_owner.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FaOwner", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_owner.TabIndex = 20;
            this.Controls.Add(fa_owner);


            //
            // fa_purchase_date
            //
            fa_purchase_date = new System.Windows.Forms.MaskedTextBox();
            this.fa_purchase_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //this.fa_purchase_date.Font = new System.Drawing.Font("", F);
            //this.fa_purchase_date.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
            this.fa_purchase_date.Location = new System.Drawing.Point(405, 2);
            this.fa_purchase_date.Name = "fa_purchase_date";
            this.fa_purchase_date.Size = new System.Drawing.Size(53, 20);
            this.fa_purchase_date.TextAlign = HorizontalAlignment.Center;
            //?this.fa_purchase_date.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.fa_purchase_date.Mask = "00/00/00";
            this.fa_purchase_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FaPurchaseDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_purchase_date.TabIndex = 30;
            this.fa_purchase_date.ValidatingType = typeof(System.DateTime);
            this.fa_purchase_date.DataBindings[0].FormatString = "dd/MM/yy";
            this.Controls.Add(fa_purchase_date);

            //
            // fa_purchase_price
            //
            fa_purchase_price = new System.Windows.Forms.MaskedTextBox();
            this.fa_purchase_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //this.fa_purchase_price.Font = new System.Drawing.Font("", F);
            //this.fa_purchase_price.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
            this.fa_purchase_price.Location = new System.Drawing.Point(405, 23);
            this.fa_purchase_price.Name = "fa_purchase_price";
            this.fa_purchase_price.Size = new System.Drawing.Size(59, 20);
            this.fa_purchase_price.TextAlign = HorizontalAlignment.Right;
            //?this.fa_purchase_price.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.fa_purchase_price.Mask = "999,999.00";
            this.fa_purchase_price.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FaPurchasePrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fa_purchase_price.TabIndex = 40;
            this.fa_purchase_price.ValidatingType = typeof(System.Decimal);
            this.fa_purchase_price.DataBindings[0].FormatString = "###,###.00";
            this.Controls.Add(fa_purchase_price);
            //
            // fa_purchase_date_t
            //
            this.fa_purchase_date_t = new System.Windows.Forms.Label();
            this.fa_purchase_date_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fa_purchase_date_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fa_purchase_date_t.Location = new System.Drawing.Point(318, 6);
            this.fa_purchase_date_t.Name = "fa_purchase_date_t";
            this.fa_purchase_date_t.Size = new System.Drawing.Size(80, 13);
            this.fa_purchase_date_t.Text = "Purchase Date";
            this.fa_purchase_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fa_purchase_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(fa_purchase_date_t);

            //
            // fa_purchase_price_t
            //
            this.fa_purchase_price_t = new System.Windows.Forms.Label();
            this.fa_purchase_price_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fa_purchase_price_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fa_purchase_price_t.Location = new System.Drawing.Point(316, 28);
            this.fa_purchase_price_t.Name = "fa_purchase_price_t";
            this.fa_purchase_price_t.Size = new System.Drawing.Size(82, 13);
            this.fa_purchase_price_t.Text = "Purchase Price";
            this.fa_purchase_price_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fa_purchase_price_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(fa_purchase_price_t);

            //
            // fa_fixed_asset_no_t
            //
            this.fa_fixed_asset_no_t = new System.Windows.Forms.Label();
            this.fa_fixed_asset_no_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fa_fixed_asset_no_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fa_fixed_asset_no_t.Location = new System.Drawing.Point(7, 5);
            this.fa_fixed_asset_no_t.Name = "fa_fixed_asset_no_t";
            this.fa_fixed_asset_no_t.Size = new System.Drawing.Size(81, 13);
            this.fa_fixed_asset_no_t.Text = "Fixed Asset No";
            this.fa_fixed_asset_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fa_fixed_asset_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(fa_fixed_asset_no_t);

            //
            // fat_id_t
            //
            this.fat_id_t = new System.Windows.Forms.Label();
            this.fat_id_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fat_id_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fat_id_t.Location = new System.Drawing.Point(-2, 25);
            this.fat_id_t.Name = "fat_id_t";
            this.fat_id_t.Size = new System.Drawing.Size(91, 13);
            this.fat_id_t.Text = "Fixed Asset Type";
            this.fat_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fat_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(fat_id_t);

            //
            // fa_owner_t
            //
            this.fa_owner_t = new System.Windows.Forms.Label();
            this.fa_owner_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fa_owner_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fa_owner_t.Location = new System.Drawing.Point(49, 47);
            this.fa_owner_t.Name = "fa_owner_t";
            this.fa_owner_t.Size = new System.Drawing.Size(39, 13);
            this.fa_owner_t.Text = "Owner";
            this.fa_owner_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fa_owner_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(fa_owner_t);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
        }
        #endregion

    }
}
