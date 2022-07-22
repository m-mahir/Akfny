using System;
using System.Collections.Generic;
using System.Text;
using AkfnyData.Entities;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Akfny.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lecturer>()
     .HasOne(e => e.Lecturer1).WithMany().HasForeignKey(o => o.LecturerId1).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Lecturer>()
     .HasOne(e => e.Lecturer2).WithMany().HasForeignKey(o => o.LecturerId2).OnDelete(DeleteBehavior.NoAction); ;
            builder.Entity<CourseProffer>()
.HasOne(e => e.Currency).WithMany(f => f.CourseProffers).HasForeignKey(o => o.CurrencyId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<CourseProffer>()
.HasOne(e => e.Currency1).WithMany(f => f.CourseProffers1).HasForeignKey(o => o.CurrencyId1).OnDelete(DeleteBehavior.NoAction);
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<album> albums { get; set; }
        public virtual DbSet<albumList> albumLists { get; set; }
        public virtual DbSet<AuthorityType> AuthorityTypes { get; set; }
        public virtual DbSet<btnType> btnTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ContentManagement> ContentManagements { get; set; }
        public virtual DbSet<Coordinator> Coordinators { get; set; }
        public virtual DbSet<CoordinatorCourse> CoordinatorCourses { get; set; }
        public virtual DbSet<CoordinatorLocation> CoordinatorLocations { get; set; }
        public virtual DbSet<CoordinatorUser> CoordinatorUsers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseBooking> CourseBookings { get; set; }
        public virtual DbSet<CourseTargeted> CourseTargeteds { get; set; }
        public virtual DbSet<CourseTargetedFinal> CourseTargetedFinals { get; set; }
        public virtual DbSet<CSLocation> CSLocations { get; set; }
        public virtual DbSet<CSLocation_Temp> CSLocation_Temp { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<DevelopCourse> DevelopCourses { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Finance> Finances { get; set; }
        public virtual DbSet<GM> GMs { get; set; }
        public virtual DbSet<Inquiry> Inquiries { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<LecturerArchive> LecturerArchives { get; set; }
        public virtual DbSet<LecturerCertificate> LecturerCertificates { get; set; }
        public virtual DbSet<LecturerCertificateTemp> LecturerCertificateTemps { get; set; }
        public virtual DbSet<LecturerQualification> LecturerQualifications { get; set; }
        public virtual DbSet<LecturerQualificationTemp> LecturerQualificationTemps { get; set; }
        public virtual DbSet<LecturerUser> LecturerUsers { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<LoginAdminType> LoginAdminTypes { get; set; }
        public virtual DbSet<LoginTracking> LoginTrackings { get; set; }
        public virtual DbSet<LoginType> LoginTypes { get; set; }
        public virtual DbSet<MajorInterest> MajorInterests { get; set; }
        public virtual DbSet<MsgType> MsgTypes { get; set; }
        public virtual DbSet<MyTask> MyTasks { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NumberType> NumberTypes { get; set; }
        public virtual DbSet<PMP> PMPs { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<ProfferStatu> ProfferStatus { get; set; }
        public virtual DbSet<QualificationDefine> QualificationDefines { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<SectorSupervisor> SectorSupervisors { get; set; }
        public virtual DbSet<SectorSupervisorCertificate> SectorSupervisorCertificates { get; set; }
        public virtual DbSet<SectorSupervisorInstitution> SectorSupervisorInstitutions { get; set; }
        public virtual DbSet<SectorSupervisorInstitutionDetail> SectorSupervisorInstitutionDetails { get; set; }
        public virtual DbSet<SelectedLecturer> SelectedLecturers { get; set; }
        public virtual DbSet<SelectedLecturerTemp> SelectedLecturerTemps { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<Slideshow> Slideshows { get; set; }
        public virtual DbSet<SocialMedia> SocialMedias { get; set; }
        public virtual DbSet<SSectorList> SSectorLists { get; set; }
        public virtual DbSet<SubInterest> SubInterests { get; set; }
        public virtual DbSet<Subscribe> Subscribes { get; set; }
        public virtual DbSet<TaskNote> TaskNotes { get; set; }
        public virtual DbSet<TaskProgress> TaskProgresses { get; set; }
        public virtual DbSet<TermsAndCondition> TermsAndConditions { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainerInterested> TrainerInteresteds { get; set; }
        public virtual DbSet<TrainerInterestedTemp> TrainerInterestedTemps { get; set; }
        public virtual DbSet<TrainerUser> TrainerUsers { get; set; }
        public virtual DbSet<SpecialTraining> SpecialTrainings { get; set; }
        public virtual DbSet<RegistrationCourseProffer> RegistrationCourseProffers { get; set; }
        public virtual DbSet<TrainerOtherInterestedCourse> TrainerOtherInterestedCourses { get; set; }
        public virtual DbSet<TrainerOtherInterestedCourseTemp> TrainerOtherInterestedCourseTemps { get; set; }
        public virtual DbSet<TrineeCourseRequest> TrineeCourseRequests { get; set; }
        public virtual DbSet<EmailsLog> EmailsLogs { get; set; }
        public virtual DbSet<CourseProffer> CourseProffers { get; set; }
        public virtual DbSet<LecturerInterestedCourse> LecturerInterestedCourses { get; set; }
        public virtual DbSet<LecturerInterestedCourseTemp> LecturerInterestedCourseTemps { get; set; }
        public virtual DbSet<TrainerInterestedCourse> TrainerInterestedCourses { get; set; }
        public virtual DbSet<TrainerInterestedCourseTemp> TrainerInterestedCourseTemps { get; set; }
        public virtual DbSet<RegistrationSuggestionCourse> RegistrationSuggestionCourses { get; set; }
        public virtual DbSet<RegistrationSuggestionCourseTemp> RegistrationSuggestionCourseTemps { get; set; }
        public virtual DbSet<CourseSuggestion> CourseSuggestions { get; set; }
        public virtual DbSet<TraineeDelete> TraineeDeletes { get; set; }
        public virtual DbSet<Greet> Greets { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationOfficer> OrganizationOfficers { get; set; }
        public virtual DbSet<CourseBookingRequest> CourseBookingRequests { get; set; }
        public virtual DbSet<OrganizationCourseRequestTrainer> OrganizationCourseRequestTrainers { get; set; }
        public virtual DbSet<OrganizationCourseRequestTrainerTemp> OrganizationCourseRequestTrainerTemps { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderCourse> ProviderCourses { get; set; }
        public virtual DbSet<ProviderAccreditation> ProviderAccreditations { get; set; }
        public virtual DbSet<ProviderField> ProviderFields { get; set; }
        public virtual DbSet<ProviderAccreditationTemp> ProviderAccreditationTemps { get; set; }
        public virtual DbSet<ProviderFieldsTemp> ProviderFieldsTemps { get; set; }
        public virtual DbSet<TrainerInquiry> TrainerInquiries { get; set; }
        public virtual DbSet<LocationRoom> LocationRooms { get; set; }
        public virtual DbSet<LocationRoomImageTemp> LocationRoomImageTemps { get; set; }
        public virtual DbSet<LocationRoomImage> LocationRoomImages { get; set; }
        public virtual DbSet<OrganizationCourseRequest> OrganizationCourseRequests { get; set; }

    }
}
