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

    public partial class LecturerArchive : Entity<int>
    {
        
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public string Jawwal { get; set; }
        public string Nationality { get; set; }
        public string City { get; set; }
        public string Experience { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string OriginalUploadFileName { get; set; }
        public string UploadFileName { get; set; }
        public string Courses { get; set; }
        public string sex { get; set; }
    }
}