//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Entities
{
    using Data.ViewModels;
    using System;
    using System.Collections.Generic;
    
    public partial class TermsAndCondition : Entity<int>
    {
        public string TC_Text { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }
        public string TC_Type { get; set; }
    }
}
