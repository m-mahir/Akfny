using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TrainerEntity.Commands
{
    public class EditLecturerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string LecturerFname { get; set; }
        public string LecturerSname { get; set; }
        public string LecturerTname { get; set; }
        public string LecturerLname { get; set; }
        public string ELecturerFname { get; set; }
        public string ELecturerSname { get; set; }
        public string ELecturerTname { get; set; }
        public string ELecturerLname { get; set; }
        public string IDNumber { get; set; }
        public int? NumberTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string JawwalNumber1 { get; set; }
        public string JawwalNumber2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Fieldofexpertise { get; set; }
        public int? TheNumberOfYears { get; set; }
        public string SubFieldofexpertise { get; set; }
        public int? SubTheNumberOfYears { get; set; }
        public string Photograph_Base64 { get; set; }
        public byte[] Photograph { get; set; }
        public int? SexId { get; set; }
        public int? NationalityId { get; set; }
        public int? RegistrationCode { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsSuspend { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string OriginalUploadFileName { get; set; }
        public string UploadFileName { get; set; }
        public string RegistrationDate { get; set; }
        public string RegistrationTime { get; set; }
        public string InvitationCode { get; set; }
        public string RegistrationInvitationCode { get; set; }
        public int? LecturerId1 { get; set; }
        public int? LecturerId2 { get; set; }

        public List<LecturerCertificateCommand> LecturerCertificateList { get; set; }
        public List<LecturerQualification> LecturerQualificationList { get; set; }
        public List<LecturerInterestedCourse> LecturerInterestedCourseList { get; set; }
        public List<RegistrationSuggestionCourse> RegistrationSuggestionCourseList { get; set; }
    }
}
