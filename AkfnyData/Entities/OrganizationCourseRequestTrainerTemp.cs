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
    
    public partial class OrganizationCourseRequestTrainerTemp : Entity<int>
    {
        public Nullable<int> InsertCode { get; set; }
        public Nullable<int> OrgId { get; set; }
        public Nullable<int> TrainerId { get; set; }
    
        public virtual Trainer Trainer { get; set; }
    }
}
