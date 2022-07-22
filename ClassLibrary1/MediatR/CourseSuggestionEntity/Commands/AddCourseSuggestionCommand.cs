using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.CourseSuggestionEntity.Commands
{
    public class AddCourseSuggestionCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public string CourseTxt { get; set; }
        public string E_CourseTxt { get; set; }
        public string General_Description { get; set; }
        public string E_General_Description { get; set; }
        public string Detailed_Goal { get; set; }
        public string E_Detailed_Goal { get; set; }
        public string The_main_axis { get; set; }
        public string E_The_main_axis { get; set; }
        public int? Days { get; set; }
        public int? Hour { get; set; }
        public int? LecturerId { get; set; }
        public int? PMPId { get; set; }
        public string LecturerDate { get; set; }
        public string LecturerTime { get; set; }
        public string LecturerNote { get; set; }
        public string PMPDate { get; set; }
        public string PMPTime { get; set; }
        public string PMPNote { get; set; }
        public int? StatusId { get; set; }
        public string OriginalUploadFileName { get; set; }
        public string UploadFileName { get; set; }
        public Nullable<bool> PMPSubmit { get; set; }
        public int? SectorId { get; set; }
        public int? FieldId { get; set; }
        public int? ProfferStatuId { get; set; }
    }
}
