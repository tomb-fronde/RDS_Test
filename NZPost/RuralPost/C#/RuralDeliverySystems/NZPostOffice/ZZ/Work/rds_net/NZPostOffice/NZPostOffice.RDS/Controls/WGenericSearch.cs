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

namespace NZPostOffice.RDS.Controls
{
    public partial class WGenericSearch : WAncestorWindow
    {
        private System.ComponentModel.IContainer components = null;

        public WGenericSearch()
        {
            InitializeComponent();
        }

        public virtual void ue_finishsetup()
        {
            //? MMainMenu mCurrent;
            //? mCurrent = new MMainMenu(this);
        }

        public override void pfc_preopen()
        {
            string ls_Parm;
            string Title;
            ls_Parm = StaticMessage.StringParm;
            if (ls_Parm != null && ls_Parm.Trim().Length > 0)
            {
                Title = ls_Parm;
            }
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.BackColor = System.Drawing.SystemColors.Control;

            // 
            // st_label
            // 
            st_label.Top = 315;
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