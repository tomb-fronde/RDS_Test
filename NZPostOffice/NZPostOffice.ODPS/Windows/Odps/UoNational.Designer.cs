namespace NZPostOffice.ODPS.Windows.Odps
{
    partial class UoNational
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

            // 
            // cb_new
            // 
            // cb_new.Enabled = false;
            cb_new.Enabled = true;
         
            // 
            // dw_selection
            // 
            dw_selection.DataObject = new NZPostOffice.ODPS.DataControls.Odps.DwNational();
            dw_selection.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           
            this.ResumeLayout();
        }

        #endregion
    }
}
