
using System.Windows.Forms;
using System;
namespace NZPostOffice.Shared.VisualComponents
{

    public class WStatus : FormBase
    {

        /// <summary>
        /// reference to the global variables/methods of the PB application
        /// </summary>


        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_message;

        public Label st_bar;

        public Label st_limit;

        public WStatus()
        {
            this.InitializeComponent();
        }

        public virtual void open(object sender, EventArgs e)
        {
            int screen_height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int screen_width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.Left = screen_width - this.Width / 2;
            this.Top = screen_height - this.Height / 2;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.st_message = new Label();
            this.st_bar = new Label();
            this.st_limit = new Label();
            Controls.Add(st_message);
            Controls.Add(st_bar);
            Controls.Add(st_limit);
            // Please add the corespondent full path of the icon
            this.Icon = System.Drawing.SystemIcons.Information;
            // Metex Migrator Warning: color 80269524 was not converted
            // w_status.BackColor = 80269524;
            this.BackColor = System.Drawing.SystemColors.Control;//this.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
            this.Text = "Please wait while I process your request....";
            this.ControlBox = true;
            this.Height = 96;
            this.Width = 333;
            this.Top = 116;
            this.Left = 128;
            this.Load += new EventHandler(open);
            // 
            // st_message
            // 
            st_message.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            // Metex Migrator Warning: color 80269524 was not converted
            // st_message.BackColor = 80269524;
            st_message.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_message.ForeColor = System.Drawing.SystemColors.WindowText;
            st_message.TabStop = false;
            st_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_message.Text = " ";
            st_message.Height = 17;
            st_message.Width = 296;
            st_message.Top = 42;
            st_message.Left = 12;
            // 
            // st_bar
            // 
            st_bar.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_bar.BackColor = System.Drawing.Color.Teal;
            st_bar.ForeColor = System.Drawing.SystemColors.WindowText;
            st_bar.TabStop = false;
            st_bar.Height = 18;
            st_bar.Width = 270;
            st_bar.Top = 17;
            st_bar.Left = 14;
            // 
            // st_limit
            // 
            st_limit.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_limit.BackColor = System.Drawing.Color.Silver;
            st_limit.ForeColor = System.Drawing.SystemColors.WindowText;
            st_limit.TabStop = false;
            st_limit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            st_limit.Height = 22;
            st_limit.Width = 299;
            st_limit.Top = 15;
            st_limit.Left = 12;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ResumeLayout();
        }

        public virtual int of_draw(int lcount, int llimit)
        {
            int limit;
            limit = st_limit.Width - 20;
            st_bar.Width = lcount / llimit * limit;
            return 0;
        }

        public virtual int of_draw(int lcount, int llimit, string as_message)
        {
            // setredraw ( false)
            int limit;
            limit = st_limit.Width - 20;
            st_bar.Width = lcount / llimit * limit;
            st_message.Text = as_message;
            // setredraw ( true)
            return 0;
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
    }
}

