using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkfnyPresentation.Models
{
    public class CourseProfferModelView
    {
        public int CourseProfferId { get; set; }
        public Nullable<int> InsertCode { get; set; }
        //LocationTypeId
        public Nullable<int> LocationTypeId { get; set; }
        public Nullable<int> LecturerId { get; set; }
        public Nullable<int> SectorId { get; set; }
        public Nullable<int> FieldId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> NumberOfTrainees { get; set; }
        public string Location { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public Nullable<int> ReviewJawwal { get; set; }
        public string SuggestedDate { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string Note { get; set; }
        public string CreatDate { get; set; }
        public string CreatTime { get; set; }
        public string AcceptRejectDate { get; set; }
        public string AcceptRejectTime { get; set; }
        public Nullable<int> PriceId { get; set; }
        public string AcceptRejectNote { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> locId { get; set; }
        public Nullable<int> coordinatorId { get; set; }
        public string coordinatorDate { get; set; }
        public string coordinatorTime { get; set; }
        public Nullable<bool> coordinatorSubmit { get; set; }
        public string TimeFrom2 { get; set; }
        public Nullable<bool> HasLec { get; set; }
        public string CourseTxt { get; set; }
        public string SectorTxt { get; set; }
        public string FieldTxt { get; set; }
        public int Hour { get; set; }
        public int Days { get; set; }
        public Nullable<int> Hour2 { get; set; }
        public Nullable<int> Days2 { get; set; }
        public System.DateTime SuggestedDate2 { get; set; }
        public string Status { get; set; }
        public string CreatDateTime { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string LecturerName { get; set; }
        public Nullable<decimal> LocPrice { get; set; }
        public string coordinatorNote { get; set; }
        public string LocationNote { get; set; }
        public Nullable<int> FinanceId { get; set; }
        public string FinanceDate { get; set; }
        public string FinanceTime { get; set; }
        public Nullable<bool> FinanceSubmit { get; set; }
        public Nullable<decimal> PriceTrainer { get; set; }
        public Nullable<int> CurrencyId1 { get; set; }
        public Nullable<int> CurrencyId2 { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string FinanceNote { get; set; }
        public int CourseHourDays { get; set; }
        public Nullable<int> PMPId { get; set; }
        public string PMPDate { get; set; }
        public string PMPTime { get; set; }
        public Nullable<bool> PMPSubmit { get; set; }
        public string PMPNote { get; set; }
        //UploadFileName
        public string UploadFileName { get; set; }
        public string LocNote { get; set; }
        public string LocTypeTxt { get; set; }
        public string classification { get; set; }
        public string GMName { get; set; }
        public int GMPhone { get; set; }
        public Nullable<bool> GMSubmit { get; set; }
        public Nullable<int> GMId { get; set; }
        public double ProCountPercent { get; set; }
        public Nullable<bool> ForwardCoordinator { get; set; }
        public string ForwardCoordinatorType { get; set; }
        public Nullable<int> ForwardCoordinatorId { get; set; }
        public string ForwardCoordinatorNote { get; set; }
        public string ForwardCoordinatorDateTime { get; set; }
        public Nullable<bool> ForwardFinance { get; set; }
        public string ForwardFinanceType { get; set; }
        public Nullable<int> ForwardFinanceId { get; set; }
        public string ForwardFinanceNote { get; set; }
        public string ForwardFinanceDateTime { get; set; }
        public Nullable<bool> ForwardPMP { get; set; }
        public string ForwardPMPType { get; set; }
        public Nullable<int> ForwardPMPId { get; set; }
        public string ForwardPMPNote { get; set; }
        public string ForwardPMPDateTime { get; set; }
        public string CP { get; set; }
        public Nullable<decimal> TempLocPrice { get; set; }
        public Nullable<decimal> PriceTemp { get; set; }
        public Nullable<decimal> SelectPrice { get; set; }
        public string LecturerNote { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }
        public Nullable<bool> Updated { get; set; }
        public Nullable<bool> selectedLect { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public bool Register { get; set; }
        public int Payment { get; set; }
        public string EncryptCourseProfferId { get; set; }
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
