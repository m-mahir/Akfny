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

    public partial class CoordinatorCourse : Entity<int>
    { 
       
        public string CourseTitle { get; set; }
        public string CourseNote { get; set; }
        public int? CoordinatorId { get; set; }
    
        public virtual Coordinator Coordinator { get; set; }
    }
}
