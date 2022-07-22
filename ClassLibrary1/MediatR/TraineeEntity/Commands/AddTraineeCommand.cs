using Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TraineeEntity.Commands
{
    public class AddTraineeCommand : IRequest<string>
    {
        public string TrainerFname { get; set; }
        public string TrainerSname { get; set; }
        public string TrainerTname { get; set; }
        public string TrainerLname { get; set; }
        public string ETrainerFname { get; set; }
        public string ETrainerSname { get; set; }
        public string ETrainerTname { get; set; }
        public string ETrainerLname { get; set; }
        public string IDNumber { get; set; }
        public Nullable<int> NumberTypeId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> SexId { get; set; }
        public string JawwalNumber1 { get; set; }
        public string JawwalNumber2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public byte[] Photograph { get; set; }
        public string Photograph_Base64 { get; set; }
        public Nullable<int> RegistrationCode { get; set; }
        public string RegistrationDate { get; set; }
        public string RegistrationTime { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsSuspend { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public Nullable<bool> ProfileUpdate { get; set; }
        public Nullable<int> AddId { get; set; }
        public string AddType { get; set; }
        public string InvitationCode { get; set; }
        public string RegistrationInvitationCode { get; set; }
        public Nullable<int> IsSend { get; set; }
        public string TotalMsg { get; set; }
        public Dictionary<string, int> InterestId { get; set; }
        public List<TrainerOtherInterestedCourse> TrainerOtherInterestedCourseList { get; set; }
    }
}
