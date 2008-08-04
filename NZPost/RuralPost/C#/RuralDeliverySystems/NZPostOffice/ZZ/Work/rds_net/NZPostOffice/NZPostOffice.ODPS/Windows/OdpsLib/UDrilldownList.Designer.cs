using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using System;
namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class UDrilldownList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.cb_delete = new UCb();
            this.cb_new = new UCb();
            this.dw_selection = new URdsDw();
            this.cb_open = new UCb();
            Controls.Add(cb_delete);
            Controls.Add(cb_new);
            Controls.Add(dw_selection);
            Controls.Add(cb_open);

            this.Size = new System.Drawing.Size(280, 150);
     
            // 
            // cb_open
            // 
            cb_open.Text = "Open";
            cb_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            cb_open.TabIndex = 2;
            cb_open.Location = new System.Drawing.Point(208, 8);
            cb_open.Size = new System.Drawing.Size(60, 23);
            cb_open.Click += new EventHandler(cb_open_clicked);
          
            // 
            // cb_new
            //
            cb_new.Text = "&New";
            cb_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            cb_new.Location = new System.Drawing.Point(208, 40);
            cb_new.Size = new System.Drawing.Size(60, 23);
            cb_new.Click += new EventHandler(cb_new_clicked);      
       
            // 
            // cb_delete
            // 
            cb_delete.Text = "&Delete";
            cb_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            cb_delete.Location = new System.Drawing.Point(208, 72);
            cb_delete.Size = new System.Drawing.Size(60, 23);
            cb_delete.Click += new EventHandler(cb_delete_clicked);
            

           
            // 
            // dw_selection
            // 
            dw_selection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dw_selection.Location = new System.Drawing.Point(3, 3);
            dw_selection.Size = new System.Drawing.Size(190, 140);
            dw_selection.DoubleClick += new EventHandler(dw_selection_doubleclicked);
            //?dw_selection.DbError += new DbEventHandler(dw_selection_dberror);
         
    
            this.ResumeLayout();
        }


        public UCb cb_delete;
        public UCb cb_new;
        public URdsDw dw_selection;
        public UCb cb_open;

        #endregion
    }
}
