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
    
    public partial class ProviderAccreditation : Entity<int>
    {
      
        public int ProivderId { get; set; }
        public string Accreditation { get; set; }
    
        public virtual Provider Provider { get; set; }
    }
}
