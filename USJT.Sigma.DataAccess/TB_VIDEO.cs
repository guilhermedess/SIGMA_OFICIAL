//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USJT.Sigma.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_VIDEO
    {
        public int ID_VIDEO { get; set; }
        public int ID_SUBTOPICO { get; set; }
        public string NOM_VIDEO { get; set; }
        public string DES_URL { get; set; }
    
        public virtual TB_SUBTOPICO TB_SUBTOPICO { get; set; }
    }
}
