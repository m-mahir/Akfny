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
    
    public partial class ProviderCourse : Entity<int>
    {
       
        public int? ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        public string General_Description { get; set; }
        public string Detailed_Goal { get; set; }
        public string The_main_axis { get; set; }
        public byte[] Course_Img { get; set; }
        public int? InsertCode { get; set; }
        public string EtmadId { get; set; }
        public string EtmadFrom { get; set; }
    
    }
}
