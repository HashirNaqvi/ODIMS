//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DIMS.BAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PublicMessage
    {
        public int PublicMessageID { get; set; }
        public Nullable<int> RehabilitationInstituteID { get; set; }
        public Nullable<int> NDMAUserID { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
    
        public virtual NDMAUser NDMAUser { get; set; }
        public virtual RehabilitationInstitutes RehabilitationInstitutes { get; set; }
    }
}