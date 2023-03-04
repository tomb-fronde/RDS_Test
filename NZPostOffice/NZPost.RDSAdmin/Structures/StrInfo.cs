namespace NZPostOffice.RDSAdmin.Structures
{
    using System;
    using System.Collections.Generic;  
    
    // Strucutre used to store id and name pair information
    public struct StrInfo 
    {        
        public List<int> p_id;

        public List<string> p_name;

        public List<string> p_read;

        public List<string> p_modify;

        public List<string> p_delete;

        public List<string> p_create;

    }
}
