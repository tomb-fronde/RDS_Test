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
using NZPostOffice.RDS.Windows.Ruralwin;

namespace NZPostOffice.RDS.Controls
{
    public partial class WMdiClock : WMaster
    {
        #region Define
        public WMainMdi iw_parent_window;

        public int ii_menu_ht = 0;

        public int ii_menu_ht2 = 74;

        public int ii_not_menu_ht = 0;

        public int ii_resizeable_offset;

        public int ii_border;

        public int ii_border_width;

        public int ii_border_height;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label lb_resource;

        public Label lb_env;

        public Label st_systype;

        public Label st_userid;

        public Label st_time;

        #endregion

        public WMdiClock()
        {
            this.InitializeComponent();
            // this.Shown += new EventHandler(WMdiClock_Shown);
        }

        public override void open()
        {
            string cUserName;
            //? Environment st_Env;
            //  Initialize and determine environment information 
            iw_parent_window = (WMainMdi)StaticVariables.MainMDI;
            this.Width = st_time.Top + st_time.Width;
            // this.height  = st_time.height
            if (!(iw_parent_window.Menu == null))
            {
                ii_menu_ht = ii_menu_ht2;
            }
            else
            {
                ii_menu_ht = ii_not_menu_ht;
            }
/*? 
             GetEnvironment(st_Env);
             lb_env.text = "Environment " + st_Env.PBMajorRevision.ToString() + '.' + st_Env.PBMinorRevision.ToString() + '.' + String(st_Env.PBFixesRevision, "#####00");
             ii_border = System.Convert.ToInt32 ( ProfileString("win.ini", "windows", "borderwidth", '2' ));
             ii_border_height = 4 * ii_border;
             //?ii_border_width = PixelsToUnits(ii_border, xpixelstounits!);
             //  If the window argument passed is resizable...
             if (iw_parent_window.Resizable) {
                 ii_resizeable_offset = 0;
             }
             else {
                 ii_resizeable_offset = 8 * (ii_border + 2);
             }
             if (IsValid(StaticVariables.gnv_app)) {
                 if (IsValid(StaticVariables.gnv_app.of_get_securitymanager())) {
                     cUserName = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_username() + "  ( " + StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionname() + ')';
                     st_userid.Text = cUserName;
                 }
             }
*/
            //? Timer(60);
            //?this.TriggerEvent(timer!);
            of_parent_resized();
            //? st_systype.Text = StaticVariables.gnv_app.of_get_systype() + ' ' + StaticVariables.gnv_app.of_getversion();
        }

        public override void show()
        {
            //? Visible = false;
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_resource = new System.Windows.Forms.Label();
            this.lb_env = new System.Windows.Forms.Label();
            this.st_systype = new System.Windows.Forms.Label();
            this.st_userid = new System.Windows.Forms.Label();
            this.st_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_resource
            // 
            this.lb_resource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_resource.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lb_resource.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_resource.Location = new System.Drawing.Point(1, 0);
            this.lb_resource.Name = "lb_resource";
            this.lb_resource.Size = new System.Drawing.Size(28, 10);
            this.lb_resource.TabIndex = 0;
            this.lb_resource.Text = "OK";
            this.lb_resource.Click += new System.EventHandler(this.lb_resource_clicked);
            // 
            // lb_env
            // 
            this.lb_env.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_env.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lb_env.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_env.Location = new System.Drawing.Point(30, 0);
            this.lb_env.Name = "lb_env";
            this.lb_env.Size = new System.Drawing.Size(94, 10);
            this.lb_env.TabIndex = 1;
            this.lb_env.Text = "Environment 8.0.00";
            this.lb_env.DoubleClick += new System.EventHandler(this.lb_env_doubleclicked);
            this.lb_env.Click += new System.EventHandler(this.lb_env_clicked);
            // 
            // st_systype
            // 
            this.st_systype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.st_systype.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.st_systype.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_systype.Location = new System.Drawing.Point(125, 0);
            this.st_systype.Name = "st_systype";
            this.st_systype.Size = new System.Drawing.Size(78, 10);
            this.st_systype.TabIndex = 2;
            //?this.st_systype.Text = "System Type";
            this.st_systype.Text = "Production Version";
            this.st_systype.DoubleClick += new System.EventHandler(this.st_systype_doubleclicked);
            this.st_systype.Click += new System.EventHandler(this.st_systype_clicked);
            // 
            // st_userid
            // 
            this.st_userid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.st_userid.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.st_userid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_userid.Location = new System.Drawing.Point(204, 0);
            this.st_userid.Name = "st_userid";
            this.st_userid.Size = new System.Drawing.Size(132, 10);
            this.st_userid.TabIndex = 3;
            this.st_userid.Text = "Local";
            this.st_userid.DoubleClick += new System.EventHandler(this.st_userid_doubleclicked);
            this.st_userid.Click += new System.EventHandler(this.st_userid_clicked);
            // 
            // st_time
            // 
            this.st_time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.st_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.st_time.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_time.Location = new System.Drawing.Point(337, 0);
            this.st_time.Name = "st_time";
            this.st_time.Size = new System.Drawing.Size(99, 10);
            this.st_time.TabIndex = 4;
            this.st_time.Text = "12/12/12 09:12 pm";
            this.st_time.DoubleClick += new System.EventHandler(this.st_time_doubleclicked);
            this.st_time.Click += new System.EventHandler(this.st_time_clicked);
            // 
            // WMdiClock
            // 
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.Controls.Add(this.lb_resource);
            this.Controls.Add(this.lb_env);
            this.Controls.Add(this.st_systype);
            this.Controls.Add(this.st_userid);
            this.Controls.Add(this.st_time);
            this.Enabled = false;
           //? this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Size = new Size(425, 10);
            this.Name = "WMdiClock";
            this.ResumeLayout(false);

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

        public virtual void of_parent_resized()
        {
            //  move the window so it is positioned over the lower right hand portion of the Microhelp bar
            int winht;
            int winwd;
            string cUserName;
            if (iw_parent_window == null)
            {
                this.Size = new Size(425, 10);
                return;
            }
            if (st_time.Left + st_time.Width + 100 < iw_parent_window.Width)
            {
                this.Width = st_time.Left + st_time.Width;
            }
            else
            {
                this.Width = iw_parent_window.Width - ii_border_width * 4 - 100;
            }
            winht = iw_parent_window.Top + iw_parent_window.Height;
            winwd = iw_parent_window.Left + iw_parent_window.ClientSize.Width + ii_border_width - this.Width - 10;
            if (StaticVariables.gnv_app != null)
            {
                if (StaticVariables.gnv_app.of_get_securitymanager() != null)
                {
                    cUserName = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_username() + " (" + StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionname() + ')';
                    st_userid.Text = cUserName;
                }
            }
            this.Top = winht - 18;
            this.Left = winwd - 9;
            if (!Visible)
                Visible = true;
        }

        #region Events
        public virtual void lb_resource_clicked(object sender, EventArgs e)
        {
            //?  w_main_mdi.SetMicroHelp("Nothing to worry about");
            // iw_parent_window.bringtotop=true
        }

        public virtual void lb_env_doubleclicked(object sender, EventArgs e)
        {
            // messagebox ( "Status Bar","RDS is using "+lb_env.text)
        }

        public virtual void lb_env_clicked(object sender, EventArgs e)
        {
            //? w_main_mdi.SetMicroHelp("The Powerbuilder version you are using is " + lb_env.text);
            // iw_parent_window.bringtotop=true
        }

        public virtual void st_systype_doubleclicked(object sender, EventArgs e)
        {
            // messagebox ( "Status Bar","You are connected to the "+st_systype.text+" database")
        }

        public virtual void st_systype_clicked(object sender, EventArgs e)
        {
            //?  w_main_mdi.SetMicroHelp("You are connected to the " + st_systype.text + " database");
            // iw_parent_window.bringtotop=true
        }

        public virtual void st_userid_doubleclicked(object sender, EventArgs e)
        {
            // messagebox ( "Status Bar","Hi "  + st_userid.text)
        }

        public virtual void st_userid_clicked(object sender, EventArgs e)
        {
            //?  w_main_mdi.SetMicroHelp("Hi " + st_userid.text);
            // iw_parent_window.bringtotop=true
        }

        public virtual void st_time_doubleclicked(object sender, EventArgs e)
        {
            // messagebox ( "Status Bar","The time is "+st_time.text)
        }

        public virtual void st_time_clicked(object sender, EventArgs e)
        {
            //? w_main_mdi.SetMicroHelp("Today\'s date and time");
            // this.bringtotop=false
        }
        #endregion
    }
}