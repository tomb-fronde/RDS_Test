using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DDddwCustTitle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox customer_title;
        private TextBox customer_title_id;


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
            this.Name = "DDddwCustTitle";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwCustTitle);
            //
            // customer_title
            //
            customer_title = new System.Windows.Forms.TextBox();
            this.customer_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customer_title.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.customer_title.ForeColor = System.Drawing.SystemColors.WindowText;
            this.customer_title.Location = new System.Drawing.Point(0, 1);
            this.customer_title.MaxLength = 40;
            this.customer_title.Name = "customer_title";
            this.customer_title.Size = new System.Drawing.Size(246, 13);
            this.customer_title.TextAlign = HorizontalAlignment.Left;

            this.customer_title.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "CustomerTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customer_title.TabIndex = 20;
            this.Controls.Add(customer_title);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //
            // customer_title_id
            //
            customer_title_id = new System.Windows.Forms.TextBox();
            this.customer_title_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customer_title_id.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.customer_title_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.customer_title_id.Location = new System.Drawing.Point(0, 1);
            this.customer_title_id.MaxLength = 40;
            this.customer_title_id.Name = "customer_title";
            this.customer_title_id.Size = new System.Drawing.Size(246, 13);
            this.customer_title_id.TextAlign = HorizontalAlignment.Left;

            this.customer_title_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "CustomerTitleId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customer_title.TabIndex = 20;
            this.Controls.Add(customer_title_id);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
