using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralbase;
using NZPostOffice.RDS.Entity.Ruralbase;

namespace NZPostOffice.RDS.Windows.Ruralbase
{
    public class WStatusabort : FormBase
    {
        #region Define
        public WMaster iw_parent;

        private System.ComponentModel.IContainer components = null;

        public Button cb_1;

        public Label st_bar;

        public Label st_limit;

        #endregion

        public WStatusabort()
        {
            this.InitializeComponent();
        }

        public override void pfc_preopen()
        {
            //? this.of_setbase(true);
            //? this.inv_base.of_center();
            
            iw_parent = (WMaster) StaticMessage.PowerObjectParm;
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_1 = new Button();
            this.st_bar = new Label();
            this.st_limit = new Label();
            Controls.Add(cb_1);
            Controls.Add(st_bar);
            Controls.Add(st_limit);

            this.BringToFront();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           
            this.Icon = System.Drawing.SystemIcons.Information;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Printing your document ( s)...";
            this.ControlBox = true;
            this.Size = new Size(333, 96);
            this.Location = new Point(128, 116);

            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_1;
            cb_1.Text = "&Abort";
            cb_1.TabIndex = 1;
            cb_1.Size = new Size(54, 23);
            cb_1.Location = new Point(130, 41);
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // st_bar
            // 
            st_bar.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_bar.BackColor = System.Drawing.Color.Teal;
            st_bar.ForeColor = System.Drawing.SystemColors.WindowText;
            st_bar.TabStop = false;
            st_bar.Size = new Size(299, 18);
            st_bar.Location = new Point(14, 17);
            // 
            // st_limit
            // 
            st_limit.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_limit.BackColor = System.Drawing.Color.Silver;
            st_limit.ForeColor = System.Drawing.SystemColors.WindowText;
            st_limit.TabStop = false;
            st_limit.Size=new Size(299,22);
            st_limit.Location = new Point(12, 15);
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

        #region Methods   
        
        public virtual void ue_abort()
        {
            // Tell parent window that we are aborting
            if (iw_parent != null)
            {
                //? iw_parent.ue_abort();
                iw_parent.GetType().GetMethod("ue_abort", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod).Invoke(iw_parent, new object[] { });
            }
            this.Close();
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
            // st_message.Text=as_message
            // setredraw ( true)
            return 0;
        }
        #endregion

        #region Events

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            this.ue_abort();
        }
        #endregion
    }
}