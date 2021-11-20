namespace NZPostOffice.Shared.LogicUnits
{
    using System;

    // Class:   LogonAttrib
    // Purpose: Used to provide display information to WLogon form
    //
    
    public class LogonAttrib
    {
        public int returnCode  = -99;
        
        public int logonAttempts  = 3;
        
        public string userID = string.Empty;
        
        public string password = string.Empty;
        
        public string logo = string.Empty;
        
        public string appName = string.Empty;

        public string company = string.Empty;

        public string copyright = string.Empty;

        public string version = string.Empty;
        
        public object ipo_source;   //! not currently in use
        
        public LogonAttrib()
        {
        }
    }
}
