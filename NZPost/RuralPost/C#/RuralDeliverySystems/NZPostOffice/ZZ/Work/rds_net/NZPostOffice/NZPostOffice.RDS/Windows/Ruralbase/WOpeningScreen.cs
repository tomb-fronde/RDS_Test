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
    public partial class WOpeningScreen : WMaster
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public DSystemTitle dw_title;

        public TextBox mle_copyright;

        public PictureBox p_logo;

        #endregion

        public WOpeningScreen()
        {
            InitializeComponent();
        }

        public override void open()
        {
            /*? Environment env;
             GetEnvironment(env);
             this.Left  = PixelsToUnits(env.ScreenWidth - UnitsToPixels(this.Width, xunitstopixels), xpixelstounits) / 2;
             this.Top  = PixelsToUnits(env.ScreenHeight - UnitsToPixels(this.Height, yunitstopixels), ypixelstounits) / 2;*/
            this.Text = StaticVariables.gnv_app.of_get_title();
            dw_title.GetItem<SystemTitle>(0).Systemtitle = StaticVariables.gnv_app.of_get_title();
            dw_title.GetItem<SystemTitle>(0).Systemversion = StaticVariables.gnv_app.of_getversion();
            this.show();
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_title = new DSystemTitle();
            this.mle_copyright = new TextBox();
            this.p_logo = new PictureBox();
            Controls.Add(dw_title);
            Controls.Add(mle_copyright);
            Controls.Add(p_logo);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new Size(389, 351);
            this.Location=new Point( 115,77);
            // 
            // dw_title
            // 
            dw_title.Size = new Size(310, 65);
            dw_title.Location = new Point(69, 199);
            // 
            // mle_copyright
            // 
            mle_copyright.Multiline = true;
            mle_copyright.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            mle_copyright.BackColor = System.Drawing.Color.Silver;
            mle_copyright.ForeColor = System.Drawing.SystemColors.WindowText;
            mle_copyright.Text = @" Warning: This computer program is protected by copyright law and international treaties.  Unauthorised reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties, and will be prosecuted to the maximum extent possible under law.";
            mle_copyright.Size = new Size(377, 64);
            mle_copyright.Location = new Point(5, 272);
            // 
            // p_logo
            // 
            p_logo.TabStop = false;
            p_logo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            p_logo.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;
            p_logo.Size = new Size(378, 264);
            p_logo.Location = new Point(3, 4);
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
    }
}