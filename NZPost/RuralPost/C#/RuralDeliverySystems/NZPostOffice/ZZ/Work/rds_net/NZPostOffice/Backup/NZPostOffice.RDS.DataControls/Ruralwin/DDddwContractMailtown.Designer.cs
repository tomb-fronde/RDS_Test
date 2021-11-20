using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DDddwContractMailtown
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn mail_town;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox mail_town;
        //private Metex.Windows.DataEntityGrid grid;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            //components = new System.ComponentModel.Container();
            //grid = new Metex.Windows.DataEntityGrid();
            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            //this.SuspendLayout();

            //// 
            //// bindingSource
            ////
            //this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.DddwContractMailtown);

            //// 
            //// grid
            //// 
            //this.grid.AllowUserToAddRows = false;
            //this.grid.AllowUserToResizeRows = false;
            //this.grid.AutoGenerateColumns = false;
            //this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            //this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            //this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
       
            //this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            //this.grid.Location = new System.Drawing.Point(0, 0);
            //this.grid.MultiSelect = true;
            //this.grid.Name = "grid";
            //this.grid.RowHeadersVisible = false;
            //this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.grid.Size = new System.Drawing.Size(638, 252);
            //this.grid.ColumnHeadersVisible = false;
            //this.grid.TabIndex = 0;

            ////
            //// mail_town
            ////
            //mail_town = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.mail_town.DataPropertyName = "MailTown";
            //this.mail_town.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.mail_town.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
            //this.mail_town.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.mail_town.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //this.mail_town.HeaderText = "";
            //this.mail_town.Name = "mail_town";
            //this.mail_town.ReadOnly = true;
            //this.mail_town.Width = 98;
            //this.grid.Columns.Add(mail_town);

            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            //this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.SystemColors.Window;
            //this.Controls.Add(grid);
            components = new System.ComponentModel.Container();
            this.Name = "DDddwContractMailtown";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwContractMailtown);
            //
            // rgn_name
            //
            mail_town = new System.Windows.Forms.TextBox();
            this.mail_town.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mail_town.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.mail_town.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mail_town.Location = new System.Drawing.Point(0, 1);
            this.mail_town.MaxLength = 40;
            this.mail_town.Name = "mail_town";
            this.mail_town.Size = new System.Drawing.Size(246, 13);
            this.mail_town.TextAlign = HorizontalAlignment.Left;
            //?this.mail_town.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.mail_town.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MailTown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mail_town.TabIndex = 20;
            this.Controls.Add(mail_town);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion


	}
}
