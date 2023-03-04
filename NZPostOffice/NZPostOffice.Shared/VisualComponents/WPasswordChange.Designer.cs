namespace NZPostOffice.Shared.VisualComponents
{
    public partial class WPasswordChange : NZPostOffice.Shared.VisualComponents.WResponse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            this.dw_1 = new NZPostOffice.DataControls.DPassword();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            Controls.Add(dw_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Password Change";
            this.ControlBox = true;
            this.Height = 142;
            this.Width = 226;
            // 
            // dw_1
            // 
            //dw_1.vscrollbar = false;
            dw_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //dw_1.border = false;
            dw_1.TabIndex = 1;
            dw_1.Height = 85;
            dw_1.Width = 212;
            dw_1.Top = 0;
            dw_1.Left = 0;
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Height = 22;
            cb_ok.Width = 54;
            cb_ok.Top = 88;
            cb_ok.Left = 50;
            cb_ok.Click += new System.EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Height = 22;
            cb_cancel.Width = 54;
            cb_cancel.Top = 88;
            cb_cancel.Left = 111;
            cb_cancel.Click += new System.EventHandler(cb_cancel_clicked);
            this.ResumeLayout();

            this.Load += new System.EventHandler(WPasswordChange_Load);
        }
        
        public NZPostOffice.DataControls.DPassword dw_1;
        public System.Windows.Forms.Button cb_ok;
        public System.Windows.Forms.Button cb_cancel;
    }

}
