using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.CourseEntity.Commands
{
    public class EditCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CourseTxt { get; set; }
        public string General_Description { get; set; }
        public string Detailed_Goal { get; set; }
        public string The_main_axis { get; set; }
        public string Targeted { get; set; }
        public int? FieldId { get; set; }
        public int? SectorId { get; set; }
        public byte[] Course_Img { get; set; }
        public string Img_Base64 { get; set; }
        public int? InsertCode { get; set; }
        public int? Days { get; set; }
        public int? Hour { get; set; }
        public Dictionary<string,int> InterestId { get; set; }
    }
}
