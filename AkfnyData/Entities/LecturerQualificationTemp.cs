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

    public partial class LecturerQualificationTemp : Entity<int>
    {
        public Nullable<int> RegistrationCode { get; set; }
        public Nullable<int> QualificationId { get; set; }
        public virtual QualificationDefine QualificationDefine { get; set; }
        public Nullable<int> GraduationYear { get; set; }
        public string MajorSpecialization { get; set; }
        public string SecondarySpecialization { get; set; }
        public string TheUniversity { get; set; }
        public string CountryOfGraduation { get; set; }
    
    }
}