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
    using System.ComponentModel.DataAnnotations;

    public partial class News : Entity<int>
    {
       
        public string NewsSubject { get; set; }
        public string NewsBrief { get; set; }
        public string NewsBoday { get; set; }
        public byte[] NewsImage { get; set; }
        public string NewsDate { get; set; }
        public Nullable<bool> NewsActive { get; set; }
        public Nullable<bool> NewsDelete { get; set; }
        public Nullable<int> InsertCode { get; set; }
        public string CityName { get; set; }
    }
}
