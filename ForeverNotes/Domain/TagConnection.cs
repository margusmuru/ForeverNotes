//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForeverNotes.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class TagConnection
    {
        public int TagConnectionID { get; set; }
        public int NoteID { get; set; }
        public int TagID { get; set; }
    
        public virtual Note Note { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
