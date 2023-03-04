using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WSelectEffectiveDate : WResponse
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public TextBox sle_effdate;

        public Label st_1;

        public Button cb_ok;

        #endregion

        public WSelectEffectiveDate()
        {
            this.InitializeComponent();
        }

        public override void open()
        {
            base.open();
            sle_effdate.Text = DateTime.Today.ToString();
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.sle_effdate = new TextBox();
            this.st_1 = new Label();
            this.cb_ok = new Button();
            Controls.Add(sle_effdate);
            Controls.Add(st_1);
            Controls.Add(cb_ok);
            this.Icon = System.Drawing.SystemIcons.Question;
            this.Text = "Select Effective Date";
            this.ControlBox = true;
            this.Height = 116;
            this.Width = 302;
            // 
            // sle_effdate
            // 
            sle_effdate.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_effdate.ForeColor = System.Drawing.SystemColors.WindowText;
            //?sle_effdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_effdate.TabIndex = 1;
            sle_effdate.Location = new System.Drawing.Point(167, 15);
            sle_effdate.Size = new System.Drawing.Size(72, 23);
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.TabStop = false;
            st_1.Text = "Effective Date (dd/mm/yyyy):";
            st_1.Location = new System.Drawing.Point(14, 15);
            st_1.Size = new System.Drawing.Size(162, 19);
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(113, 55);
            cb_ok.Size = new System.Drawing.Size(54, 23);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            this.ResumeLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Events

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            DateTime res;
            if (!(DateTime.TryParse(sle_effdate.Text, out res)))
            {
                MessageBox.Show("Please enter an effective date", "Effective Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //CloseWithReturn(parent, sle_effdate.text);
                StaticMessage.StringParm = sle_effdate.Text;
                this.Close();
            }
        }
        #endregion
    }
}
