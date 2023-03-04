using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.ODPS.Menus;

namespace NZPostOffice.ODPS.Controls
{
    public partial class WOdpsMdiframe : FormBase
    {
        public MOdpsFrame m_odps_frame;

        public WOdpsMdiframe()
        {
            this.InitializeComponent();
            m_odps_frame = new MOdpsFrame(this);
            this.Load += new EventHandler(WOdpsMdiframe_Load);
        }

        public void WOdpsMdiframe_Load(object sender, EventArgs e)
        {
            open();
        }

        public override void open() 
        {
            base.open();
            bool lb_valid = true;
            //  TJB SR4630 - Override title set in properties
            //this.Text = StaticVariables.gnv_app.of_get_title();
            // Set up other appmanager stuff
            StaticVariables.gnv_app.of_setframe(this);
            // Make sure security services are running
            StaticVariables.gnv_app.of_initialise_security();
            // Enable menuitems on the frame menu
            StaticVariables.gnv_app.of_get_securitymanager().of_enable_component_menuitems(this.MainMenuStrip);
            // Open the contract search window if user has rights to it
            //  Start the syncronisation
            //?lb_valid = StaticVariables.gnv_app.inv_sync != null;

            if (lb_valid)
            {
                if (false)//?(StaticVariables.gnv_app.inv_sync.of_check() == -(1)) 
                {
                    //  Something went wrong Close the app
                    System.Environment.Exit(0);
                }
            }

            /*   TJB  SR4685  May 2006  
            *  Disable status bar
            * This.of_SetStatusBar  (  TRUE )
            * inv_StatusBar.of_Open  (  TRUE )
            * inv_StatusBar.of_SetTimer  (  TRUE )
            * inv_StatusBar.of_SetTimerFormat  (  "dd-mm-yyyy hh:mm AM/PM" )
            * inv_StatusBar.of_SetTimerWidth  ( 500) 
            * inv_StatusBar.of_SetTimerInterval  (  10000 )
             */
        }
    }
}
