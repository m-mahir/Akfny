using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkfnyData.Migrations
{
    public partial class initializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    AdminName = table.Column<string>(nullable: true),
                    AdminEmail = table.Column<string>(nullable: true),
                    AdminImg = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: true),
                    IsDelete = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    albumName = table.Column<string>(nullable: true),
                    albumDescription = table.Column<string>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    AuthorityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "btnTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    btnName = table.Column<string>(nullable: true),
                    btnValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_btnTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentManagements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ContentManagementName = table.Column<string>(nullable: true),
                    ContentManagementEmail = table.Column<string>(nullable: true),
                    ContentManagementImg = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentManagements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    ECountryName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseBookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    BookingType = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Jawwal = table.Column<int>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    BookingDate = table.Column<string>(nullable: true),
                    BookingTime = table.Column<string>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    NoteDate = table.Column<string>(nullable: true),
                    NoteTime = table.Column<string>(nullable: true),
                    BookingMax = table.Column<int>(nullable: true),
                    BookRead = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CurrencyTxt = table.Column<string>(nullable: true),
                    CurrencySymbol = table.Column<string>(nullable: true),
                    FinanceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Send = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    time = table.Column<string>(nullable: true),
                    SendBy = table.Column<string>(nullable: true),
                    SendById = table.Column<int>(nullable: true),
                    SendTo = table.Column<string>(nullable: true),
                    SDay = table.Column<int>(nullable: true),
                    SMonth = table.Column<int>(nullable: true),
                    SYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Greets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    GreetType = table.Column<string>(nullable: true),
                    GreetActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturerArchives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    Jawwal = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Workplace = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    Courses = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerArchives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturerCertificateTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LecturerCertificateImg = table.Column<byte[]>(nullable: true),
                    LecturerCertificateDate = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    LecturerCertificateTital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerCertificateTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationRoomImageTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    RoomImage = table.Column<byte[]>(nullable: true),
                    Code = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRoomImageTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TypeTxt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginAdminTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LoginAdminType1 = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAdminTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LoginDate = table.Column<DateTime>(nullable: true),
                    LoginTime = table.Column<string>(nullable: true),
                    LoginType = table.Column<string>(nullable: true),
                    LoginTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTrackings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LoginType1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MajorInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    MajorInterestTxt = table.Column<string>(nullable: true),
                    E_MajorInterest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MsgTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    MsgTypeTxt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TaskFrom = table.Column<int>(nullable: true),
                    TaskTo = table.Column<int>(nullable: true),
                    FromType = table.Column<string>(nullable: true),
                    ToType = table.Column<string>(nullable: true),
                    TaskDate = table.Column<DateTime>(nullable: true),
                    TaskTime = table.Column<string>(nullable: true),
                    TaskPriority = table.Column<string>(nullable: true),
                    TaskNote = table.Column<string>(nullable: true),
                    TaskImg = table.Column<byte[]>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    TaskStatus = table.Column<string>(nullable: true),
                    TaskProgress = table.Column<int>(nullable: true),
                    TaskEnd = table.Column<bool>(nullable: true),
                    TaskSubject = table.Column<string>(nullable: true),
                    TaskPeriod = table.Column<int>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: true),
                    DateTo = table.Column<DateTime>(nullable: true),
                    DateFinsh = table.Column<DateTime>(nullable: true),
                    TimeFinsh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    NationalityType = table.Column<string>(nullable: true),
                    ENationalityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    NewsSubject = table.Column<string>(nullable: true),
                    NewsBrief = table.Column<string>(nullable: true),
                    NewsBoday = table.Column<string>(nullable: true),
                    NewsImage = table.Column<byte[]>(nullable: true),
                    NewsDate = table.Column<string>(nullable: true),
                    NewsActive = table.Column<bool>(nullable: true),
                    NewsDelete = table.Column<bool>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    NumType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    PriceTxt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfferStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfferStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAccreditationTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Accreditation = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAccreditationTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProviderFieldsTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Field = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderFieldsTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationDefines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    QualificationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationDefines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SectorTxt = table.Column<string>(nullable: true),
                    E_SectorTxt = table.Column<string>(nullable: true),
                    SectorI_Describe = table.Column<string>(nullable: true),
                    E_SectorI_Describe = table.Column<string>(nullable: true),
                    icon = table.Column<byte[]>(nullable: true),
                    DisplayHome = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SexType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Rss = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Google = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Whatsapp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Jawwal = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    MsgRead = table.Column<bool>(nullable: true),
                    ReadDate = table.Column<string>(nullable: true),
                    ReadTime = table.Column<string>(nullable: true),
                    ReadNote = table.Column<string>(nullable: true),
                    CourseDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTrainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    subscribeName = table.Column<string>(nullable: true),
                    subscribeEmail = table.Column<string>(nullable: true),
                    subscribeDate = table.Column<DateTime>(nullable: true),
                    subscribeTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TC_Text = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true),
                    TC_Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TraineeDeletes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    DeleteDate = table.Column<string>(nullable: true),
                    DeleteTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeDeletes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerInterestedCourseTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerInterestedCourseTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerOtherInterestedCourseTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    OtherField = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerOtherInterestedCourseTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "albumLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    albumId = table.Column<int>(nullable: true),
                    albumImg = table.Column<byte[]>(nullable: true),
                    albumImgDescription = table.Column<string>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albumLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_albumLists_albums_albumId",
                        column: x => x.albumId,
                        principalTable: "albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slideshows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SlideshowName = table.Column<string>(nullable: true),
                    SlideshowBtnName = table.Column<string>(nullable: true),
                    SlideshowLink = table.Column<string>(nullable: true),
                    btnTypeId = table.Column<int>(nullable: true),
                    SlideshowImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slideshows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slideshows_btnTypes_btnTypeId",
                        column: x => x.btnTypeId,
                        principalTable: "btnTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    ECityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SubInterestTxt = table.Column<string>(nullable: true),
                    E_SubInterest = table.Column<string>(nullable: true),
                    MajorInterestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubInterests_MajorInterests_MajorInterestId",
                        column: x => x.MajorInterestId,
                        principalTable: "MajorInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    NoteFrom = table.Column<string>(nullable: true),
                    FromType = table.Column<string>(nullable: true),
                    MyTaskId = table.Column<int>(nullable: true),
                    NoteDate = table.Column<DateTime>(nullable: true),
                    NoteTime = table.Column<string>(nullable: true),
                    FromId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskNotes_MyTasks_MyTaskId",
                        column: x => x.MyTaskId,
                        principalTable: "MyTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectorSupervisors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SectorSupervisorName = table.Column<string>(nullable: true),
                    SectorSupervisorEmail = table.Column<string>(nullable: true),
                    SectorSupervisorImg = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    Phone = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ReciveRequist = table.Column<bool>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    CVOriginalUploadFileName = table.Column<string>(nullable: true),
                    CVUploadFileName = table.Column<string>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true),
                    IDType = table.Column<int>(nullable: true),
                    IDimage = table.Column<byte[]>(nullable: true),
                    ContractOriginalUploadFileName = table.Column<string>(nullable: true),
                    ContractUploadFileName = table.Column<string>(nullable: true),
                    NumberTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorSupervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorSupervisors_NumberTypes_NumberTypeId",
                        column: x => x.NumberTypeId,
                        principalTable: "NumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerQualificationTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    QualificationId = table.Column<int>(nullable: true),
                    QualificationDefineId = table.Column<int>(nullable: true),
                    GraduationYear = table.Column<int>(nullable: true),
                    MajorSpecialization = table.Column<string>(nullable: true),
                    SecondarySpecialization = table.Column<string>(nullable: true),
                    TheUniversity = table.Column<string>(nullable: true),
                    CountryOfGraduation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerQualificationTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerQualificationTemps_QualificationDefines_QualificationDefineId",
                        column: x => x.QualificationDefineId,
                        principalTable: "QualificationDefines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    FieldTxt = table.Column<string>(nullable: true),
                    E_FieldTxt = table.Column<string>(nullable: true),
                    SectorId = table.Column<int>(nullable: true),
                    Field_Describe = table.Column<string>(nullable: true),
                    E_Field_Describe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coordinators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CoordinatorName = table.Column<string>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true),
                    IDType = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    SexId = table.Column<int>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    JawwalNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: true),
                    IsSuspend = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: true),
                    IDimage = table.Column<byte[]>(nullable: true),
                    QualificationDefineId = table.Column<int>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    MajorSpecialization = table.Column<string>(nullable: true),
                    SecondarySpecialization = table.Column<string>(nullable: true),
                    GraduationYear = table.Column<int>(nullable: true),
                    CountryOfGraduation = table.Column<string>(nullable: true),
                    TheUniversity = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    CoordinatorName2 = table.Column<string>(nullable: true),
                    CoordinatorEmail = table.Column<string>(nullable: true),
                    Headquarters = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Rooms = table.Column<int>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    AuthorityTypeId = table.Column<int>(nullable: true),
                    AuthorityNote = table.Column<string>(nullable: true),
                    NumberTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinators_AuthorityTypes_AuthorityTypeId",
                        column: x => x.AuthorityTypeId,
                        principalTable: "AuthorityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinators_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinators_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinators_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinators_NumberTypes_NumberTypeId",
                        column: x => x.NumberTypeId,
                        principalTable: "NumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinators_QualificationDefines_QualificationDefineId",
                        column: x => x.QualificationDefineId,
                        principalTable: "QualificationDefines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinators_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    FinanceName = table.Column<string>(nullable: true),
                    FinanceUserName = table.Column<string>(nullable: true),
                    FinancePassword = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Finances_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Finances_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GMs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    GMName = table.Column<string>(nullable: true),
                    GMUserName = table.Column<string>(nullable: true),
                    GMPassword = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GMs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GMs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LecturerFname = table.Column<string>(nullable: true),
                    LecturerSname = table.Column<string>(nullable: true),
                    LecturerTname = table.Column<string>(nullable: true),
                    LecturerLname = table.Column<string>(nullable: true),
                    ELecturerFname = table.Column<string>(nullable: true),
                    ELecturerSname = table.Column<string>(nullable: true),
                    ELecturerTname = table.Column<string>(nullable: true),
                    ELecturerLname = table.Column<string>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true),
                    NumberTypeId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    JawwalNumber1 = table.Column<string>(nullable: true),
                    JawwalNumber2 = table.Column<string>(nullable: true),
                    Email1 = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Fieldofexpertise = table.Column<string>(nullable: true),
                    TheNumberOfYears = table.Column<int>(nullable: true),
                    SubFieldofexpertise = table.Column<string>(nullable: true),
                    SubTheNumberOfYears = table.Column<int>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    SexId = table.Column<int>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsSuspend = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    InvitationCode = table.Column<string>(nullable: true),
                    RegistrationInvitationCode = table.Column<string>(nullable: true),
                    LecturerId1 = table.Column<int>(nullable: true),
                    LecturerId2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_Lecturers_LecturerId1",
                        column: x => x.LecturerId1,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lecturers_Lecturers_LecturerId2",
                        column: x => x.LecturerId2,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lecturers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_NumberTypes_NumberTypeId",
                        column: x => x.NumberTypeId,
                        principalTable: "NumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    OrgName = table.Column<string>(nullable: true),
                    OrgType = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    ResponsibleManagement = table.Column<string>(nullable: true),
                    ManagerName = table.Column<string>(nullable: true),
                    Jawal = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CR = table.Column<byte[]>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Headquarters = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsSuspend = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    InvitationCode = table.Column<string>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    Auth = table.Column<bool>(nullable: true),
                    InfoUpdate = table.Column<bool>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organizations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PMPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    PMPName = table.Column<string>(nullable: true),
                    PMPUserName = table.Column<string>(nullable: true),
                    PMPPassword = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    ProfileImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PMPs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PMPs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OfficerName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Jawwal = table.Column<string>(nullable: true),
                    CallAdress = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsSuspend = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    InvitationCode = table.Column<string>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    License = table.Column<byte[]>(nullable: true),
                    CR = table.Column<byte[]>(nullable: true),
                    AboutUs = table.Column<string>(nullable: true),
                    FoundationYear = table.Column<string>(nullable: true),
                    BranchesNumber = table.Column<string>(nullable: true),
                    CourseArcheived = table.Column<string>(nullable: true),
                    WorkHoursFrom = table.Column<string>(nullable: true),
                    WorkHoursTo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Providers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TrainerFname = table.Column<string>(nullable: true),
                    TrainerSname = table.Column<string>(nullable: true),
                    TrainerTname = table.Column<string>(nullable: true),
                    TrainerLname = table.Column<string>(nullable: true),
                    ETrainerFname = table.Column<string>(nullable: true),
                    ETrainerSname = table.Column<string>(nullable: true),
                    ETrainerTname = table.Column<string>(nullable: true),
                    ETrainerLname = table.Column<string>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true),
                    NumberTypeId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    SexId = table.Column<int>(nullable: true),
                    JawwalNumber1 = table.Column<string>(nullable: true),
                    JawwalNumber2 = table.Column<string>(nullable: true),
                    Email1 = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Photograph = table.Column<byte[]>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsSuspend = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    ProfileUpdate = table.Column<bool>(nullable: true),
                    AddId = table.Column<int>(nullable: true),
                    AddType = table.Column<string>(nullable: true),
                    InvitationCode = table.Column<string>(nullable: true),
                    RegistrationInvitationCode = table.Column<string>(nullable: true),
                    IsSend = table.Column<int>(nullable: true),
                    TotalMsg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_NumberTypes_NumberTypeId",
                        column: x => x.NumberTypeId,
                        principalTable: "NumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTargeteds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Num = table.Column<int>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    SubInterestId = table.Column<int>(nullable: true),
                    MajorInterestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTargeteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTargeteds_MajorInterests_MajorInterestId",
                        column: x => x.MajorInterestId,
                        principalTable: "MajorInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTargeteds_SubInterests_SubInterestId",
                        column: x => x.SubInterestId,
                        principalTable: "SubInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerInterestedTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    MajorInterestId = table.Column<int>(nullable: true),
                    SubInterestId = table.Column<int>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerInterestedTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerInterestedTemps_MajorInterests_MajorInterestId",
                        column: x => x.MajorInterestId,
                        principalTable: "MajorInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerInterestedTemps_SubInterests_SubInterestId",
                        column: x => x.SubInterestId,
                        principalTable: "SubInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectorSupervisorCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SectorSupervisorCertificateImg = table.Column<byte[]>(nullable: true),
                    SectorSupervisorId = table.Column<int>(nullable: true),
                    SectorSupervisorCertificateTital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorSupervisorCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorSupervisorCertificates_SectorSupervisors_SectorSupervisorId",
                        column: x => x.SectorSupervisorId,
                        principalTable: "SectorSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectorSupervisorInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    InstitutionName = table.Column<string>(nullable: true),
                    InstitutionContact = table.Column<string>(nullable: true),
                    InstitutionPhone = table.Column<string>(nullable: true),
                    InstitutionEmail = table.Column<string>(nullable: true),
                    SectorSupervisorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorSupervisorInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorSupervisorInstitutions_SectorSupervisors_SectorSupervisorId",
                        column: x => x.SectorSupervisorId,
                        principalTable: "SectorSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SSectorLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SectorSupervisorId = table.Column<int>(nullable: true),
                    SectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSectorLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SSectorLists_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SSectorLists_SectorSupervisors_SectorSupervisorId",
                        column: x => x.SectorSupervisorId,
                        principalTable: "SectorSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseTxt = table.Column<string>(nullable: true),
                    E_CourseTxt = table.Column<string>(nullable: true),
                    General_Description = table.Column<string>(nullable: true),
                    E_General_Description = table.Column<string>(nullable: true),
                    Detailed_Goal = table.Column<string>(nullable: true),
                    E_Detailed_Goal = table.Column<string>(nullable: true),
                    The_main_axis = table.Column<string>(nullable: true),
                    E_The_main_axis = table.Column<string>(nullable: true),
                    Targeted = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: true),
                    SectorId = table.Column<int>(nullable: true),
                    Course_Img = table.Column<byte[]>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    Days = table.Column<int>(nullable: true),
                    Hour = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationSuggestionCourseTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseTxt = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    FieldId = table.Column<int>(nullable: true),
                    SectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationSuggestionCourseTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationSuggestionCourseTemps_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSuggestionCourseTemps_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatorCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseTitle = table.Column<string>(nullable: true),
                    CourseNote = table.Column<string>(nullable: true),
                    CoordinatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoordinatorCourses_Coordinators_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "Coordinators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatorUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CoordinatorUserName = table.Column<string>(nullable: true),
                    CoordinatorUserPassword = table.Column<string>(nullable: true),
                    CoordinatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoordinatorUsers_Coordinators_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "Coordinators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DevelopCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    DevelopCourseTxt = table.Column<string>(nullable: true),
                    E_DevelopCourseTxt = table.Column<string>(nullable: true),
                    General_Description = table.Column<string>(nullable: true),
                    E_General_Description = table.Column<string>(nullable: true),
                    Detailed_Goal = table.Column<string>(nullable: true),
                    E_Detailed_Goal = table.Column<string>(nullable: true),
                    The_main_axis = table.Column<string>(nullable: true),
                    E_The_main_axis = table.Column<string>(nullable: true),
                    DevelopCourseField = table.Column<string>(nullable: true),
                    DevelopCourseSector = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: true),
                    Hour = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    LecturerDate = table.Column<string>(nullable: true),
                    LecturerTime = table.Column<string>(nullable: true),
                    LecturerNote = table.Column<string>(nullable: true),
                    SectorSupervisorId = table.Column<int>(nullable: true),
                    SectorSupervisorDate = table.Column<string>(nullable: true),
                    SectorSupervisorTime = table.Column<string>(nullable: true),
                    SectorSupervisorNote = table.Column<string>(nullable: true),
                    ProfferStatuId = table.Column<int>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    PMPSubmit = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopCourses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DevelopCourses_ProfferStatus_ProfferStatuId",
                        column: x => x.ProfferStatuId,
                        principalTable: "ProfferStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DevelopCourses_SectorSupervisors_SectorSupervisorId",
                        column: x => x.SectorSupervisorId,
                        principalTable: "SectorSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LecturerCertificateImg = table.Column<byte[]>(nullable: true),
                    LecturerCertificateDate = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    LecturerCertificateTital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerCertificates_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    QualificationDefineId = table.Column<int>(nullable: true),
                    GraduationYear = table.Column<int>(nullable: true),
                    MajorSpecialization = table.Column<string>(nullable: true),
                    SecondarySpecialization = table.Column<string>(nullable: true),
                    TheUniversity = table.Column<string>(nullable: true),
                    CountryOfGraduation = table.Column<string>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerQualifications_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerQualifications_QualificationDefines_QualificationDefineId",
                        column: x => x.QualificationDefineId,
                        principalTable: "QualificationDefines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LecturerUserName = table.Column<string>(nullable: true),
                    LecturerUserPassword = table.Column<string>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerUsers_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationSuggestionCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseTxt = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    FieldId = table.Column<int>(nullable: true),
                    SectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationSuggestionCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationSuggestionCourses_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSuggestionCourses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSuggestionCourses_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationOfficers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    OfficerName = table.Column<string>(nullable: true),
                    OfficerJawwal = table.Column<string>(nullable: true),
                    OfficerEmail = table.Column<string>(nullable: true),
                    OfficerPassword = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationOfficers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationOfficers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationOfficers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationOfficers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    CourseTxt = table.Column<string>(nullable: true),
                    E_CourseTxt = table.Column<string>(nullable: true),
                    General_Description = table.Column<string>(nullable: true),
                    E_General_Description = table.Column<string>(nullable: true),
                    Detailed_Goal = table.Column<string>(nullable: true),
                    E_Detailed_Goal = table.Column<string>(nullable: true),
                    The_main_axis = table.Column<string>(nullable: true),
                    E_The_main_axis = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: true),
                    Hour = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    PMPId = table.Column<int>(nullable: true),
                    LecturerDate = table.Column<string>(nullable: true),
                    LecturerTime = table.Column<string>(nullable: true),
                    LecturerNote = table.Column<string>(nullable: true),
                    PMPDate = table.Column<string>(nullable: true),
                    PMPTime = table.Column<string>(nullable: true),
                    PMPNote = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    PMPSubmit = table.Column<bool>(nullable: true),
                    SectorId = table.Column<int>(nullable: true),
                    FieldId = table.Column<int>(nullable: true),
                    ProfferStatuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSuggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSuggestions_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSuggestions_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSuggestions_PMPs_PMPId",
                        column: x => x.PMPId,
                        principalTable: "PMPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSuggestions_ProfferStatus_ProfferStatuId",
                        column: x => x.ProfferStatuId,
                        principalTable: "ProfferStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSuggestions_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatorLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Building = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    lng = table.Column<string>(nullable: true),
                    coordinatorId = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    latlng = table.Column<string>(nullable: true),
                    valid = table.Column<bool>(nullable: true),
                    LocationTypeId = table.Column<int>(nullable: true),
                    GMName = table.Column<string>(nullable: true),
                    GMPhone = table.Column<int>(nullable: true),
                    classification = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    LocationEmail = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoordinatorLocations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoordinatorLocations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoordinatorLocations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoordinatorLocations_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoordinatorLocations_Coordinators_coordinatorId",
                        column: x => x.coordinatorId,
                        principalTable: "Coordinators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAccreditations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ProivderId = table.Column<int>(nullable: false),
                    Accreditation = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAccreditations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderAccreditations_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    Field = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderFields_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationCourseRequestTrainerTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    OrgId = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCourseRequestTrainerTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequestTrainerTemps_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerInterestedCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerInterestedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerInterestedCourses_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerInteresteds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    MajorInterestId = table.Column<int>(nullable: true),
                    SubInterestId = table.Column<int>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerInteresteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerInteresteds_MajorInterests_MajorInterestId",
                        column: x => x.MajorInterestId,
                        principalTable: "MajorInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerInteresteds_SubInterests_SubInterestId",
                        column: x => x.SubInterestId,
                        principalTable: "SubInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerInteresteds_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerOtherInterestedCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    OtherField = table.Column<string>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerOtherInterestedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerOtherInterestedCourses_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TrainerUserName = table.Column<string>(nullable: true),
                    TrainerUserPassword = table.Column<string>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerUsers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseBookingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    BookingType = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Jawwal = table.Column<int>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    BookingDate = table.Column<string>(nullable: true),
                    BookingTime = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    NoteDate = table.Column<string>(nullable: true),
                    NoteTime = table.Column<string>(nullable: true),
                    BookingMax = table.Column<int>(nullable: true),
                    BookRead = table.Column<bool>(nullable: true),
                    TimeFrom = table.Column<string>(nullable: true),
                    TimeTo = table.Column<string>(nullable: true),
                    SuggestedDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseBookingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseBookingRequests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTargetedFinals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Num = table.Column<int>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    MajorInterestId = table.Column<int>(nullable: true),
                    SubInterestId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTargetedFinals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTargetedFinals_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTargetedFinals_MajorInterests_MajorInterestId",
                        column: x => x.MajorInterestId,
                        principalTable: "MajorInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTargetedFinals_SubInterests_SubInterestId",
                        column: x => x.SubInterestId,
                        principalTable: "SubInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    InquiryName = table.Column<string>(nullable: true),
                    InquiryEmail = table.Column<string>(nullable: true),
                    InquirySubject = table.Column<string>(nullable: true),
                    InquiryMsg = table.Column<string>(nullable: true),
                    InquiryDate = table.Column<DateTime>(nullable: true),
                    InquiryTime = table.Column<string>(nullable: true),
                    InquiryRead = table.Column<bool>(nullable: true),
                    InquiryReplay = table.Column<string>(nullable: true),
                    InquiryReplayBy = table.Column<int>(nullable: true),
                    InquiryReplayDate = table.Column<DateTime>(nullable: true),
                    InquiryReplayTime = table.Column<string>(nullable: true),
                    InquiryType = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerInterestedCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerInterestedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerInterestedCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerInterestedCourses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerInterestedCourseTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    RegistrationCode = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerInterestedCourseTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerInterestedCourseTemps_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationCourseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    BookingDate = table.Column<string>(nullable: true),
                    BookingTime = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    SuggestedDate = table.Column<string>(nullable: true),
                    SuggestedTime = table.Column<string>(nullable: true),
                    ReqStatus = table.Column<bool>(nullable: true),
                    ReqNote = table.Column<string>(nullable: true),
                    ReqDate = table.Column<string>(nullable: true),
                    ReqTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCourseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequests_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequests_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequests_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    General_Description = table.Column<string>(nullable: true),
                    Detailed_Goal = table.Column<string>(nullable: true),
                    The_main_axis = table.Column<string>(nullable: true),
                    Course_Img = table.Column<byte[]>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    EtmadId = table.Column<string>(nullable: true),
                    EtmadFrom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderCourses_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectorSupervisorInstitutionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    SectorSupervisorInstitutionId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    SectorSupervisorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorSupervisorInstitutionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorSupervisorInstitutionDetails_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectorSupervisorInstitutionDetails_SectorSupervisors_SectorSupervisorId",
                        column: x => x.SectorSupervisorId,
                        principalTable: "SectorSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectorSupervisorInstitutionDetails_SectorSupervisorInstitutions_SectorSupervisorInstitutionId",
                        column: x => x.SectorSupervisorInstitutionId,
                        principalTable: "SectorSupervisorInstitutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrineeCourseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    BookingDate = table.Column<string>(nullable: true),
                    BookingTime = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    SuggestedDate = table.Column<string>(nullable: true),
                    SuggestedTime = table.Column<string>(nullable: true),
                    ReqStatus = table.Column<bool>(nullable: true),
                    ReqNote = table.Column<string>(nullable: true),
                    ReqDate = table.Column<string>(nullable: true),
                    ReqTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrineeCourseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrineeCourseRequests_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrineeCourseRequests_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrineeCourseRequests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrineeCourseRequests_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    RoomName = table.Column<string>(nullable: true),
                    CapacityFrom = table.Column<int>(nullable: true),
                    CapacityTo = table.Column<int>(nullable: true),
                    Ranking = table.Column<string>(nullable: true),
                    locId = table.Column<int>(nullable: true),
                    Cafe = table.Column<string>(nullable: true),
                    RoomOrder = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    RoomView = table.Column<string>(nullable: true),
                    RoomPrice = table.Column<decimal>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    CoordinatorLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationRooms_CoordinatorLocations_CoordinatorLocationId",
                        column: x => x.CoordinatorLocationId,
                        principalTable: "CoordinatorLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationCourseRequestTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CRid = table.Column<int>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true),
                    OrganizationCourseRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCourseRequestTrainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequestTrainers_OrganizationCourseRequests_OrganizationCourseRequestId",
                        column: x => x.OrganizationCourseRequestId,
                        principalTable: "OrganizationCourseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationCourseRequestTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseProffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    NumberOfTrainees = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    TimeFrom = table.Column<string>(nullable: true),
                    TimeTo = table.Column<string>(nullable: true),
                    ReviewJawwal = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreatDate = table.Column<string>(nullable: true),
                    CreatTime = table.Column<string>(nullable: true),
                    AcceptRejectDate = table.Column<string>(nullable: true),
                    AcceptRejectTime = table.Column<string>(nullable: true),
                    PriceId = table.Column<int>(nullable: true),
                    AcceptRejectNote = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    locId = table.Column<int>(nullable: true),
                    coordinatorId = table.Column<int>(nullable: true),
                    coordinatorDate = table.Column<string>(nullable: true),
                    coordinatorTime = table.Column<string>(nullable: true),
                    coordinatorSubmit = table.Column<bool>(nullable: true),
                    TimeFrom2 = table.Column<string>(nullable: true),
                    LocPrice = table.Column<decimal>(nullable: true),
                    coordinatorNote = table.Column<string>(nullable: true),
                    FinanceId = table.Column<int>(nullable: true),
                    FinanceDate = table.Column<string>(nullable: true),
                    FinanceTime = table.Column<string>(nullable: true),
                    FinanceSubmit = table.Column<bool>(nullable: true),
                    PriceTrainer = table.Column<decimal>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    CurrencyId1 = table.Column<int>(nullable: true),
                    FinanceNote = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    PMPId = table.Column<int>(nullable: true),
                    PMPDate = table.Column<string>(nullable: true),
                    PMPTime = table.Column<string>(nullable: true),
                    PMPSubmit = table.Column<bool>(nullable: true),
                    PMPNote = table.Column<string>(nullable: true),
                    SuggestedDate = table.Column<DateTime>(nullable: false),
                    GMSubmit = table.Column<bool>(nullable: true),
                    GMId = table.Column<int>(nullable: true),
                    ForwardCoordinator = table.Column<bool>(nullable: true),
                    ForwardCoordinatorType = table.Column<string>(nullable: true),
                    ForwardCoordinatorId = table.Column<int>(nullable: true),
                    ForwardCoordinatorNote = table.Column<string>(nullable: true),
                    ForwardCoordinatorDateTime = table.Column<string>(nullable: true),
                    ForwardFinance = table.Column<bool>(nullable: true),
                    ForwardFinanceType = table.Column<string>(nullable: true),
                    ForwardFinanceId = table.Column<int>(nullable: true),
                    ForwardFinanceNote = table.Column<string>(nullable: true),
                    ForwardFinanceDateTime = table.Column<string>(nullable: true),
                    ForwardPMP = table.Column<bool>(nullable: true),
                    ForwardPMPType = table.Column<string>(nullable: true),
                    ForwardPMPId = table.Column<int>(nullable: true),
                    ForwardPMPNote = table.Column<string>(nullable: true),
                    ForwardPMPDateTime = table.Column<string>(nullable: true),
                    CP = table.Column<string>(nullable: true),
                    CS_Finish = table.Column<bool>(nullable: true),
                    Brochures = table.Column<byte[]>(nullable: true),
                    RoomId = table.Column<int>(nullable: true),
                    HasLec = table.Column<bool>(nullable: true),
                    CoordinatorLocationId = table.Column<int>(nullable: true),
                    PriceTypeId = table.Column<int>(nullable: true),
                    ProfferStatuId = table.Column<int>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    LocationRoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_CoordinatorLocations_CoordinatorLocationId",
                        column: x => x.CoordinatorLocationId,
                        principalTable: "CoordinatorLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseProffers_Currencies_CurrencyId1",
                        column: x => x.CurrencyId1,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseProffers_Finances_FinanceId",
                        column: x => x.FinanceId,
                        principalTable: "Finances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_GMs_GMId",
                        column: x => x.GMId,
                        principalTable: "GMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_LocationRooms_LocationRoomId",
                        column: x => x.LocationRoomId,
                        principalTable: "LocationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_PMPs_PMPId",
                        column: x => x.PMPId,
                        principalTable: "PMPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_PriceTypes_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "PriceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_ProfferStatus_ProfferStatuId",
                        column: x => x.ProfferStatuId,
                        principalTable: "ProfferStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseProffers_Coordinators_coordinatorId",
                        column: x => x.coordinatorId,
                        principalTable: "Coordinators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationRoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    LocationRoomId = table.Column<int>(nullable: true),
                    RoomImage = table.Column<byte[]>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationRoomImages_LocationRooms_LocationRoomId",
                        column: x => x.LocationRoomId,
                        principalTable: "LocationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CSLocation_Temp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    locId = table.Column<int>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    LocPrice = table.Column<decimal>(nullable: true),
                    PriceTypeId = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    selected = table.Column<bool>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    LocationRoomId = table.Column<int>(nullable: true),
                    CoordinatorLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSLocation_Temp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSLocation_Temp_CoordinatorLocations_CoordinatorLocationId",
                        column: x => x.CoordinatorLocationId,
                        principalTable: "CoordinatorLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CSLocation_Temp_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CSLocation_Temp_LocationRooms_LocationRoomId",
                        column: x => x.LocationRoomId,
                        principalTable: "LocationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CSLocation_Temp_PriceTypes_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "PriceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CSLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    CoordinatorLocationId = table.Column<int>(nullable: true),
                    OriginalUploadFileName = table.Column<string>(nullable: true),
                    UploadFileName = table.Column<string>(nullable: true),
                    LocPrice = table.Column<decimal>(nullable: true),
                    PriceTypeId = table.Column<int>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    selected = table.Column<bool>(nullable: true),
                    LocationRoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CSLocations_CoordinatorLocations_CoordinatorLocationId",
                        column: x => x.CoordinatorLocationId,
                        principalTable: "CoordinatorLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CSLocations_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CSLocations_LocationRooms_LocationRoomId",
                        column: x => x.LocationRoomId,
                        principalTable: "LocationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CSLocations_PriceTypes_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "PriceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationCourseProffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    PaymentTime = table.Column<string>(nullable: true),
                    IsPayment = table.Column<bool>(nullable: true),
                    PaymentType = table.Column<string>(nullable: true),
                    PaymentId = table.Column<int>(nullable: true),
                    PaymentIdType = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<string>(nullable: true),
                    RegistrationTime = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PaymentPrice = table.Column<decimal>(nullable: true),
                    PaymentDiscount = table.Column<decimal>(nullable: true),
                    PaymentTotal = table.Column<decimal>(nullable: true),
                    PriceType = table.Column<string>(nullable: true),
                    InvoiceNo = table.Column<string>(nullable: true),
                    Tax = table.Column<decimal>(nullable: true),
                    TotalPriceTax = table.Column<decimal>(nullable: true),
                    PriceAfertDiscount = table.Column<decimal>(nullable: true),
                    PaymentImg = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationCourseProffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationCourseProffers_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationCourseProffers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedLecturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    PriceTemp = table.Column<decimal>(nullable: true),
                    SelectPrice = table.Column<decimal>(nullable: true),
                    LecturerNote = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true),
                    Updated = table.Column<bool>(nullable: true),
                    finish = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedLecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedLecturers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedLecturers_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedLecturers_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedLecturerTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    InsertCode = table.Column<int>(nullable: true),
                    PriceTemp = table.Column<decimal>(nullable: true),
                    SelectPrice = table.Column<decimal>(nullable: true),
                    LecturerNote = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedLecturerTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedLecturerTemps_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedLecturerTemps_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedLecturerTemps_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Progress = table.Column<string>(nullable: true),
                    ProgressDate = table.Column<string>(nullable: true),
                    ProgressTime = table.Column<string>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    coordinatorId = table.Column<int>(nullable: true),
                    FinanceId = table.Column<int>(nullable: true),
                    PMPId = table.Column<int>(nullable: true),
                    GMId = table.Column<int>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskProgresses_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskProgresses_Finances_FinanceId",
                        column: x => x.FinanceId,
                        principalTable: "Finances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskProgresses_GMs_GMId",
                        column: x => x.GMId,
                        principalTable: "GMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskProgresses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskProgresses_PMPs_PMPId",
                        column: x => x.PMPId,
                        principalTable: "PMPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerInquiries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true),
                    InquirySubject = table.Column<string>(nullable: true),
                    InquiryMsg = table.Column<string>(nullable: true),
                    InquiryDate = table.Column<string>(nullable: true),
                    InquiryTime = table.Column<string>(nullable: true),
                    InquiryRead = table.Column<bool>(nullable: true),
                    InquiryReplay = table.Column<string>(nullable: true),
                    InquiryReplayBy = table.Column<int>(nullable: true),
                    InquiryReplayDate = table.Column<string>(nullable: true),
                    InquiryReplayTime = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    CourseProfferId = table.Column<int>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerInquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerInquiries_CourseProffers_CourseProfferId",
                        column: x => x.CourseProfferId,
                        principalTable: "CourseProffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerInquiries_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albumLists_albumId",
                table: "albumLists",
                column: "albumId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorCourses_CoordinatorId",
                table: "CoordinatorCourses",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorLocations_CityId",
                table: "CoordinatorLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorLocations_CountryId",
                table: "CoordinatorLocations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorLocations_LocationTypeId",
                table: "CoordinatorLocations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorLocations_ProviderId",
                table: "CoordinatorLocations",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorLocations_coordinatorId",
                table: "CoordinatorLocations",
                column: "coordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_AuthorityTypeId",
                table: "Coordinators",
                column: "AuthorityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_CityId",
                table: "Coordinators",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_CountryId",
                table: "Coordinators",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_NationalityId",
                table: "Coordinators",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_NumberTypeId",
                table: "Coordinators",
                column: "NumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_QualificationDefineId",
                table: "Coordinators",
                column: "QualificationDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_SexId",
                table: "Coordinators",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorUsers_CoordinatorId",
                table: "CoordinatorUsers",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseBookingRequests_CourseId",
                table: "CourseBookingRequests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_CityId",
                table: "CourseProffers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_CoordinatorLocationId",
                table: "CourseProffers",
                column: "CoordinatorLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_CountryId",
                table: "CourseProffers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_CourseId",
                table: "CourseProffers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_CurrencyId",
                table: "CourseProffers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_CurrencyId1",
                table: "CourseProffers",
                column: "CurrencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_FinanceId",
                table: "CourseProffers",
                column: "FinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_GMId",
                table: "CourseProffers",
                column: "GMId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_LecturerId",
                table: "CourseProffers",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_LocationRoomId",
                table: "CourseProffers",
                column: "LocationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_PMPId",
                table: "CourseProffers",
                column: "PMPId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_PriceTypeId",
                table: "CourseProffers",
                column: "PriceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_ProfferStatuId",
                table: "CourseProffers",
                column: "ProfferStatuId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_ProviderId",
                table: "CourseProffers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProffers_coordinatorId",
                table: "CourseProffers",
                column: "coordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FieldId",
                table: "Courses",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SectorId",
                table: "Courses",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSuggestions_FieldId",
                table: "CourseSuggestions",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSuggestions_LecturerId",
                table: "CourseSuggestions",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSuggestions_PMPId",
                table: "CourseSuggestions",
                column: "PMPId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSuggestions_ProfferStatuId",
                table: "CourseSuggestions",
                column: "ProfferStatuId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSuggestions_SectorId",
                table: "CourseSuggestions",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargetedFinals_CourseId",
                table: "CourseTargetedFinals",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargetedFinals_MajorInterestId",
                table: "CourseTargetedFinals",
                column: "MajorInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargetedFinals_SubInterestId",
                table: "CourseTargetedFinals",
                column: "SubInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargeteds_MajorInterestId",
                table: "CourseTargeteds",
                column: "MajorInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTargeteds_SubInterestId",
                table: "CourseTargeteds",
                column: "SubInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocation_Temp_CoordinatorLocationId",
                table: "CSLocation_Temp",
                column: "CoordinatorLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocation_Temp_CourseProfferId",
                table: "CSLocation_Temp",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocation_Temp_LocationRoomId",
                table: "CSLocation_Temp",
                column: "LocationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocation_Temp_PriceTypeId",
                table: "CSLocation_Temp",
                column: "PriceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocations_CoordinatorLocationId",
                table: "CSLocations",
                column: "CoordinatorLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocations_CourseProfferId",
                table: "CSLocations",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocations_LocationRoomId",
                table: "CSLocations",
                column: "LocationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CSLocations_PriceTypeId",
                table: "CSLocations",
                column: "PriceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopCourses_LecturerId",
                table: "DevelopCourses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopCourses_ProfferStatuId",
                table: "DevelopCourses",
                column: "ProfferStatuId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopCourses_SectorSupervisorId",
                table: "DevelopCourses",
                column: "SectorSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_SectorId",
                table: "Fields",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_CityId",
                table: "Finances",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_CountryId",
                table: "Finances",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_GMs_CityId",
                table: "GMs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_GMs_CountryId",
                table: "GMs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CourseId",
                table: "Inquiries",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCertificates_LecturerId",
                table: "LecturerCertificates",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerInterestedCourses_CourseId",
                table: "LecturerInterestedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerInterestedCourses_LecturerId",
                table: "LecturerInterestedCourses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerInterestedCourseTemps_CourseId",
                table: "LecturerInterestedCourseTemps",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerQualifications_LecturerId",
                table: "LecturerQualifications",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerQualifications_QualificationDefineId",
                table: "LecturerQualifications",
                column: "QualificationDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerQualificationTemps_QualificationDefineId",
                table: "LecturerQualificationTemps",
                column: "QualificationDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CityId",
                table: "Lecturers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CountryId",
                table: "Lecturers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_LecturerId1",
                table: "Lecturers",
                column: "LecturerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_LecturerId2",
                table: "Lecturers",
                column: "LecturerId2");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_NationalityId",
                table: "Lecturers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_NumberTypeId",
                table: "Lecturers",
                column: "NumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_SexId",
                table: "Lecturers",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerUsers_LecturerId",
                table: "LecturerUsers",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationRoomImages_LocationRoomId",
                table: "LocationRoomImages",
                column: "LocationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationRooms_CoordinatorLocationId",
                table: "LocationRooms",
                column: "CoordinatorLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequests_CityId",
                table: "OrganizationCourseRequests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequests_CountryId",
                table: "OrganizationCourseRequests",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequests_CourseId",
                table: "OrganizationCourseRequests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequests_OrganizationId",
                table: "OrganizationCourseRequests",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequestTrainers_OrganizationCourseRequestId",
                table: "OrganizationCourseRequestTrainers",
                column: "OrganizationCourseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequestTrainers_TrainerId",
                table: "OrganizationCourseRequestTrainers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCourseRequestTrainerTemps_TrainerId",
                table: "OrganizationCourseRequestTrainerTemps",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationOfficers_CityId",
                table: "OrganizationOfficers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationOfficers_CountryId",
                table: "OrganizationOfficers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationOfficers_OrganizationId",
                table: "OrganizationOfficers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CityId",
                table: "Organizations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CountryId",
                table: "Organizations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PMPs_CityId",
                table: "PMPs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PMPs_CountryId",
                table: "PMPs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAccreditations_ProviderId",
                table: "ProviderAccreditations",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderCourses_CourseId",
                table: "ProviderCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderCourses_ProviderId",
                table: "ProviderCourses",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderFields_ProviderId",
                table: "ProviderFields",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CityId",
                table: "Providers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CountryId",
                table: "Providers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationCourseProffers_CourseProfferId",
                table: "RegistrationCourseProffers",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationCourseProffers_TrainerId",
                table: "RegistrationCourseProffers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSuggestionCourses_FieldId",
                table: "RegistrationSuggestionCourses",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSuggestionCourses_LecturerId",
                table: "RegistrationSuggestionCourses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSuggestionCourses_SectorId",
                table: "RegistrationSuggestionCourses",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSuggestionCourseTemps_FieldId",
                table: "RegistrationSuggestionCourseTemps",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSuggestionCourseTemps_SectorId",
                table: "RegistrationSuggestionCourseTemps",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSupervisorCertificates_SectorSupervisorId",
                table: "SectorSupervisorCertificates",
                column: "SectorSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSupervisorInstitutionDetails_CourseId",
                table: "SectorSupervisorInstitutionDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSupervisorInstitutionDetails_SectorSupervisorId",
                table: "SectorSupervisorInstitutionDetails",
                column: "SectorSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSupervisorInstitutionDetails_SectorSupervisorInstitutionId",
                table: "SectorSupervisorInstitutionDetails",
                column: "SectorSupervisorInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSupervisorInstitutions_SectorSupervisorId",
                table: "SectorSupervisorInstitutions",
                column: "SectorSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorSupervisors_NumberTypeId",
                table: "SectorSupervisors",
                column: "NumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedLecturers_CourseId",
                table: "SelectedLecturers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedLecturers_CourseProfferId",
                table: "SelectedLecturers",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedLecturers_LecturerId",
                table: "SelectedLecturers",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedLecturerTemps_CourseId",
                table: "SelectedLecturerTemps",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedLecturerTemps_CourseProfferId",
                table: "SelectedLecturerTemps",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedLecturerTemps_LecturerId",
                table: "SelectedLecturerTemps",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Slideshows_btnTypeId",
                table: "Slideshows",
                column: "btnTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SSectorLists_SectorId",
                table: "SSectorLists",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SSectorLists_SectorSupervisorId",
                table: "SSectorLists",
                column: "SectorSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInterests_MajorInterestId",
                table: "SubInterests",
                column: "MajorInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_MyTaskId",
                table: "TaskNotes",
                column: "MyTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskProgresses_CourseProfferId",
                table: "TaskProgresses",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskProgresses_FinanceId",
                table: "TaskProgresses",
                column: "FinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskProgresses_GMId",
                table: "TaskProgresses",
                column: "GMId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskProgresses_LecturerId",
                table: "TaskProgresses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskProgresses_PMPId",
                table: "TaskProgresses",
                column: "PMPId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInquiries_CourseProfferId",
                table: "TrainerInquiries",
                column: "CourseProfferId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInquiries_TrainerId",
                table: "TrainerInquiries",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInterestedCourses_TrainerId",
                table: "TrainerInterestedCourses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInteresteds_MajorInterestId",
                table: "TrainerInteresteds",
                column: "MajorInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInteresteds_SubInterestId",
                table: "TrainerInteresteds",
                column: "SubInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInteresteds_TrainerId",
                table: "TrainerInteresteds",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInterestedTemps_MajorInterestId",
                table: "TrainerInterestedTemps",
                column: "MajorInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerInterestedTemps_SubInterestId",
                table: "TrainerInterestedTemps",
                column: "SubInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerOtherInterestedCourses_TrainerId",
                table: "TrainerOtherInterestedCourses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CityId",
                table: "Trainers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CountryId",
                table: "Trainers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_NationalityId",
                table: "Trainers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_NumberTypeId",
                table: "Trainers",
                column: "NumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_SexId",
                table: "Trainers",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerUsers_TrainerId",
                table: "TrainerUsers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrineeCourseRequests_CityId",
                table: "TrineeCourseRequests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrineeCourseRequests_CountryId",
                table: "TrineeCourseRequests",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrineeCourseRequests_CourseId",
                table: "TrineeCourseRequests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrineeCourseRequests_TrainerId",
                table: "TrineeCourseRequests",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "albumLists");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContentManagements");

            migrationBuilder.DropTable(
                name: "CoordinatorCourses");

            migrationBuilder.DropTable(
                name: "CoordinatorUsers");

            migrationBuilder.DropTable(
                name: "CourseBookingRequests");

            migrationBuilder.DropTable(
                name: "CourseBookings");

            migrationBuilder.DropTable(
                name: "CourseSuggestions");

            migrationBuilder.DropTable(
                name: "CourseTargetedFinals");

            migrationBuilder.DropTable(
                name: "CourseTargeteds");

            migrationBuilder.DropTable(
                name: "CSLocation_Temp");

            migrationBuilder.DropTable(
                name: "CSLocations");

            migrationBuilder.DropTable(
                name: "DevelopCourses");

            migrationBuilder.DropTable(
                name: "EmailsLogs");

            migrationBuilder.DropTable(
                name: "Greets");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "LecturerArchives");

            migrationBuilder.DropTable(
                name: "LecturerCertificates");

            migrationBuilder.DropTable(
                name: "LecturerCertificateTemps");

            migrationBuilder.DropTable(
                name: "LecturerInterestedCourses");

            migrationBuilder.DropTable(
                name: "LecturerInterestedCourseTemps");

            migrationBuilder.DropTable(
                name: "LecturerQualifications");

            migrationBuilder.DropTable(
                name: "LecturerQualificationTemps");

            migrationBuilder.DropTable(
                name: "LecturerUsers");

            migrationBuilder.DropTable(
                name: "LocationRoomImages");

            migrationBuilder.DropTable(
                name: "LocationRoomImageTemps");

            migrationBuilder.DropTable(
                name: "LoginAdminTypes");

            migrationBuilder.DropTable(
                name: "LoginTrackings");

            migrationBuilder.DropTable(
                name: "LoginTypes");

            migrationBuilder.DropTable(
                name: "MsgTypes");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OrganizationCourseRequestTrainers");

            migrationBuilder.DropTable(
                name: "OrganizationCourseRequestTrainerTemps");

            migrationBuilder.DropTable(
                name: "OrganizationOfficers");

            migrationBuilder.DropTable(
                name: "ProviderAccreditations");

            migrationBuilder.DropTable(
                name: "ProviderAccreditationTemps");

            migrationBuilder.DropTable(
                name: "ProviderCourses");

            migrationBuilder.DropTable(
                name: "ProviderFields");

            migrationBuilder.DropTable(
                name: "ProviderFieldsTemps");

            migrationBuilder.DropTable(
                name: "RegistrationCourseProffers");

            migrationBuilder.DropTable(
                name: "RegistrationSuggestionCourses");

            migrationBuilder.DropTable(
                name: "RegistrationSuggestionCourseTemps");

            migrationBuilder.DropTable(
                name: "SectorSupervisorCertificates");

            migrationBuilder.DropTable(
                name: "SectorSupervisorInstitutionDetails");

            migrationBuilder.DropTable(
                name: "SelectedLecturers");

            migrationBuilder.DropTable(
                name: "SelectedLecturerTemps");

            migrationBuilder.DropTable(
                name: "Slideshows");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "SpecialTrainings");

            migrationBuilder.DropTable(
                name: "SSectorLists");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "TaskNotes");

            migrationBuilder.DropTable(
                name: "TaskProgresses");

            migrationBuilder.DropTable(
                name: "TermsAndConditions");

            migrationBuilder.DropTable(
                name: "TraineeDeletes");

            migrationBuilder.DropTable(
                name: "TrainerInquiries");

            migrationBuilder.DropTable(
                name: "TrainerInterestedCourses");

            migrationBuilder.DropTable(
                name: "TrainerInterestedCourseTemps");

            migrationBuilder.DropTable(
                name: "TrainerInteresteds");

            migrationBuilder.DropTable(
                name: "TrainerInterestedTemps");

            migrationBuilder.DropTable(
                name: "TrainerOtherInterestedCourses");

            migrationBuilder.DropTable(
                name: "TrainerOtherInterestedCourseTemps");

            migrationBuilder.DropTable(
                name: "TrainerUsers");

            migrationBuilder.DropTable(
                name: "TrineeCourseRequests");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrganizationCourseRequests");

            migrationBuilder.DropTable(
                name: "SectorSupervisorInstitutions");

            migrationBuilder.DropTable(
                name: "btnTypes");

            migrationBuilder.DropTable(
                name: "MyTasks");

            migrationBuilder.DropTable(
                name: "CourseProffers");

            migrationBuilder.DropTable(
                name: "SubInterests");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "SectorSupervisors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "GMs");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "LocationRooms");

            migrationBuilder.DropTable(
                name: "PMPs");

            migrationBuilder.DropTable(
                name: "PriceTypes");

            migrationBuilder.DropTable(
                name: "ProfferStatus");

            migrationBuilder.DropTable(
                name: "MajorInterests");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "CoordinatorLocations");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Coordinators");

            migrationBuilder.DropTable(
                name: "AuthorityTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "NumberTypes");

            migrationBuilder.DropTable(
                name: "QualificationDefines");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
