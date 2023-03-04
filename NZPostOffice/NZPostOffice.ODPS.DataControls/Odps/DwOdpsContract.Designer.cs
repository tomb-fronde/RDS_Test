using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwOdpsContract
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

        private System.Windows.Forms.Label c_first_names_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.TextBox contract_no;
        private Metex.Windows.DataEntityCombo pbu_id;
        private System.Windows.Forms.TextBox c_surname_company;
        private System.Windows.Forms.TextBox c_first_names;
        private System.Windows.Forms.Label contract_no_t;
        private Metex.Windows.DataEntityCombo ac_id;
        private System.Windows.Forms.Label pbu_code_t;
        private System.Windows.Forms.Label message_for_invoice_t;
        private System.Windows.Forms.Label con_title_t;
        private System.Windows.Forms.Label c_surname_company_t;
        private System.Windows.Forms.TextBox con_title;
        private System.Windows.Forms.RichTextBox message_for_invoice;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwOdpsContract";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.OdpsContract);
        
            //
            // pbu_code_t
            //
            this.pbu_code_t = new System.Windows.Forms.Label();
            this.pbu_code_t.Font = new System.Drawing.Font("Arial", 10F);
            this.pbu_code_t.ForeColor = System.Drawing.Color.Black;
            this.pbu_code_t.Location = new System.Drawing.Point(85, 130);
            this.pbu_code_t.Name = "pbu_code_t";
            this.pbu_code_t.Size = new System.Drawing.Size(50, 16);
            this.pbu_code_t.Text = "PBU:";
            this.pbu_code_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(pbu_code_t);

            //
            // contract_no_t
            //
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no_t.Font = new System.Drawing.Font("Arial", 10F);
            this.contract_no_t.ForeColor = System.Drawing.Color.Black;
            this.contract_no_t.Location = new System.Drawing.Point(8, 10);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(128, 16);
            this.contract_no_t.Text = "Contract No:";
            this.contract_no_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(contract_no_t);

            //
            // con_title_t
            //
            this.con_title_t = new System.Windows.Forms.Label();
            this.con_title_t.Font = new System.Drawing.Font("Arial", 10F);
            this.con_title_t.ForeColor = System.Drawing.Color.Black;
            this.con_title_t.Location = new System.Drawing.Point(8, 34);
            this.con_title_t.Name = "con_title_t";
            this.con_title_t.Size = new System.Drawing.Size(128, 16);
            this.con_title_t.Text = "Con Title:";
            this.con_title_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(con_title_t);

            //
            // c_surname_company_t
            //
            this.c_surname_company_t = new System.Windows.Forms.Label();
            this.c_surname_company_t.Font = new System.Drawing.Font("Arial", 10F);
            this.c_surname_company_t.ForeColor = System.Drawing.Color.Black;
            this.c_surname_company_t.Location = new System.Drawing.Point(0, 56);
            this.c_surname_company_t.Name = "c_surname_company_t";
            this.c_surname_company_t.Size = new System.Drawing.Size(140, 16);
            this.c_surname_company_t.Text = "Surname/Company:";
            this.c_surname_company_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(c_surname_company_t);

            //
            // c_first_names_t
            //
            this.c_first_names_t = new System.Windows.Forms.Label();
            this.c_first_names_t.Font = new System.Drawing.Font("Arial", 10F);
            this.c_first_names_t.ForeColor = System.Drawing.Color.Black;
            this.c_first_names_t.Location = new System.Drawing.Point(35, 82);
            this.c_first_names_t.Name = "c_first_names_t";
            this.c_first_names_t.Size = new System.Drawing.Size(100, 16);
            this.c_first_names_t.Text = "First Names:";
            this.c_first_names_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(c_first_names_t);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("Arial", 10F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(35, 105);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(100, 16);
            this.t_1.Text = "Account ID:";
            this.t_1.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(t_1);

            //
            // message_for_invoice_t
            //
            this.message_for_invoice_t = new System.Windows.Forms.Label();
            this.message_for_invoice_t.Font = new System.Drawing.Font("Arial", 10F);
            this.message_for_invoice_t.ForeColor = System.Drawing.Color.Black;
            this.message_for_invoice_t.Location = new System.Drawing.Point(-20, 155);
            this.message_for_invoice_t.Name = "message_for_invoice_t";
            this.message_for_invoice_t.Size = new System.Drawing.Size(160, 16);
            this.message_for_invoice_t.Text = "Message For Invoice:";
            this.message_for_invoice_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(message_for_invoice_t);

            //
            // ac_id
            //
            ac_id = new Metex.Windows.DataEntityCombo();
            this.ac_id.AutoRetrieve = true;
            this.ac_id.DisplayMember = "AcDescription";
            this.ac_id.Font = new System.Drawing.Font("Arial", 10F);
            this.ac_id.ForeColor = System.Drawing.Color.Black;
            this.ac_id.Location = new System.Drawing.Point(144, 102);
            this.ac_id.Name = "ac_id";
            this.ac_id.Size = new System.Drawing.Size(247, 19);
            this.ac_id.TabIndex = 10;
            this.ac_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ac_id.Value = null;
            this.ac_id.ValueMember = "AcId";
            this.ac_id.DropDownWidth = 247;
            this.ac_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(ac_id);

            //
            // pbu_id
            //
            pbu_id = new Metex.Windows.DataEntityCombo();
            this.pbu_id.AutoRetrieve = true;
            this.pbu_id.DisplayMember = "PbuDescription";
            this.pbu_id.Font = new System.Drawing.Font("Arial", 10F);
            this.pbu_id.ForeColor = System.Drawing.Color.Black;
            this.pbu_id.Location = new System.Drawing.Point(144, 126);
            this.pbu_id.Name = "pbu_id";
            this.pbu_id.Size = new System.Drawing.Size(247, 19);
            this.pbu_id.TabIndex = 20;
            this.pbu_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pbu_id.Value = null;
            this.pbu_id.ValueMember = "PbuId";
            this.pbu_id.DropDownWidth = 247;
            this.pbu_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PbuId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(pbu_id);

            //
            // message_for_invoice
            //
            message_for_invoice = new System.Windows.Forms.RichTextBox();
            this.message_for_invoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.message_for_invoice.Font = new System.Drawing.Font("Arial", 10F);
            this.message_for_invoice.ForeColor = System.Drawing.Color.Black;
            this.message_for_invoice.Location = new System.Drawing.Point(144, 150);
            this.message_for_invoice.MaxLength = 1000;
            this.message_for_invoice.Name = "message_for_invoice";
            this.message_for_invoice.Size = new System.Drawing.Size(366, 59);
            this.message_for_invoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "MessageForInvoice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.message_for_invoice.TabIndex = 30;
            this.Controls.Add(message_for_invoice);

            //
            // contract_no
            //
            contract_no = new System.Windows.Forms.TextBox();
            this.contract_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.contract_no.Font = new System.Drawing.Font("Arial", 10F);
            this.contract_no.ForeColor = System.Drawing.Color.Black;
            this.contract_no.Location = new System.Drawing.Point(144, 6);
            this.contract_no.MaxLength = 0;
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(72, 19);
            this.contract_no.TextAlign = HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.ReadOnly = true;
            this.Controls.Add(contract_no);

            //
            // con_title
            //
            con_title = new System.Windows.Forms.TextBox();
            this.con_title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.con_title.Font = new System.Drawing.Font("Arial", 10F);
            this.con_title.ForeColor = System.Drawing.Color.Black;
            this.con_title.Location = new System.Drawing.Point(144, 30);
            this.con_title.MaxLength = 60;
            this.con_title.Name = "con_title";
            this.con_title.Size = new System.Drawing.Size(366, 19);
            this.con_title.TextAlign = HorizontalAlignment.Left;
            this.con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "ConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_title.ReadOnly = true;
            this.Controls.Add(con_title);

            //
            // c_surname_company
            //
            c_surname_company = new System.Windows.Forms.TextBox();
            this.c_surname_company.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_surname_company.Font = new System.Drawing.Font("Arial", 10F);
            this.c_surname_company.ForeColor = System.Drawing.Color.Black;
            this.c_surname_company.Location = new System.Drawing.Point(144, 54);
            this.c_surname_company.MaxLength = 40;
            this.c_surname_company.Name = "c_surname_company";
            this.c_surname_company.Size = new System.Drawing.Size(247, 19);
            this.c_surname_company.TextAlign = HorizontalAlignment.Left;
            this.c_surname_company.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CSurnameCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_surname_company.ReadOnly = true;
            this.Controls.Add(c_surname_company);

            //
            // c_first_names
            //
            c_first_names = new System.Windows.Forms.TextBox();
            this.c_first_names.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_first_names.Font = new System.Drawing.Font("Arial", 10F);
            this.c_first_names.ForeColor = System.Drawing.Color.Black;
            this.c_first_names.Location = new System.Drawing.Point(144, 78);
            this.c_first_names.MaxLength = 40;
            this.c_first_names.Name = "c_first_names";
            this.c_first_names.Size = new System.Drawing.Size(247, 19);
            this.c_first_names.TextAlign = HorizontalAlignment.Left;
            this.c_first_names.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CFirstNames", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.c_first_names.ReadOnly = true;
            this.Controls.Add(c_first_names);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
