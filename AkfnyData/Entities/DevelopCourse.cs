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

    public partial class DevelopCourse : Entity<int>
    {
        
        public string DevelopCourseTxt { get; set; }
        public string E_DevelopCourseTxt { get; set; }
        public string General_Description { get; set; }
        public string E_General_Description { get; set; }
        public string Detailed_Goal { get; set; }
        public string E_Detailed_Goal { get; set; }
        public string The_main_axis { get; set; }
        public string E_The_main_axis { get; set; }
        public string DevelopCourseField { get; set; }
        public string DevelopCourseSector { get; set; }
        public int? Days { get; set; }
        public int? Hour { get; set; }
        public int? LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public string LecturerDate { get; set; }
        public string LecturerTime { get; set; }
        public string LecturerNote { get; set; }
        public int? SectorSupervisorId { get; set; }
        public virtual SectorSupervisor SectorSupervisor { get; set; }
        public string SectorSupervisorDate { get; set; }
        public string SectorSupervisorTime { get; set; }
        public string SectorSupervisorNote { get; set; }
        public int? ProfferStatuId { get; set; }
        public virtual ProfferStatu ProfferStatu { get; set; }
        public string OriginalUploadFileName { get; set; }
        public string UploadFileName { get; set; }
        public Nullable<bool> PMPSubmit { get; set; }
    
    }
}
