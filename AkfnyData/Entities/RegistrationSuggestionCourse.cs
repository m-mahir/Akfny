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

    public partial class RegistrationSuggestionCourse : Entity<int>
    {
        public string CourseTxt { get; set; }
        public Nullable<int> RegistrationCode { get; set; }
        public Nullable<int> LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public Nullable<int> FieldId { get; set; }
        public virtual Field Field { get; set; }
        public Nullable<int> SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
