//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMMENT
    {
        public int ID_Customer { get; set; }
        public int ID_App { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
    
        public virtual APP APP { get; set; }
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
