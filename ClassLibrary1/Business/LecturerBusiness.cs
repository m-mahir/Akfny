using AkfnyData.Entities;
using AkfnyServices.Helper;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using AkfnyServices.Model;
using AutoMapper;
using CrossCutting.Identity;
using Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkfnyServices.Business
{
    public interface ILecturerBusiness
    {
        Task<string> AddLecturer(AddLecturerCommand model);
        Task<bool> EditLecturer(EditLecturerCommand model);
        Task<Lecturer> ChangeLecturerStatus(ChangeLecturerStatusCommand model);
        Task<bool> DeleteLecturer(DeleteLecturerCommand model);
    }
    public class LecturerBusiness : ILecturerBusiness
    {
        readonly private IRepository<Lecturer, int> _lecturerRepository;
        readonly private IRepository<Trainer, int> _traineeRepository;
        readonly private IRepository<Organization, int> _organizationRepository;
        readonly private IRepository<Provider, int> _providerRepository;
        readonly private IRepository<LecturerInterestedCourse, int> _lecturerInterestedCourseRepository;
        readonly private IRepository<LecturerQualification, int> _lecturerQualificationRepository;
        readonly private IRepository<LecturerCertificate, int> _lecturerCertificateRepository;
        readonly private IRepository<RegistrationSuggestionCourse, int> _registrationSuggestionCourseRepository;
        readonly private IRepository<LecturerUser, int> _lecturerUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        readonly private IRepository<EmailsLog, int> _emailsLogRepository;
        private readonly IMapper _mapper;
        private readonly MailSettings _mailSettings;
        private readonly IWebHostEnvironment _hostEnvironment;


        public LecturerBusiness(IRepository<Lecturer, int> lecturerRepository, IRepository<Trainer, int> traineeRepository, IRepository<Organization, int> organizationRepository,
            IRepository<Provider, int> providerRepository, IRepository<LecturerInterestedCourse, int> lecturerInterestedCourseRepository, IRepository<LecturerQualification, int> lecturerQualificationRepository,
            IRepository<LecturerCertificate, int> lecturerCertificateRepository, IRepository<RegistrationSuggestionCourse, int> registrationSuggestionCourseRepository,
            IRepository<LecturerUser, int> lecturerUserRepository, IRepository<EmailsLog, int> emailsLogRepository, UserManager<ApplicationUser> userManager,
            IOptions<MailSettings> mailSettings, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _lecturerRepository = lecturerRepository;
            _traineeRepository = traineeRepository;
            _organizationRepository = organizationRepository;
            _providerRepository = providerRepository;
            _lecturerInterestedCourseRepository = lecturerInterestedCourseRepository;
            _lecturerQualificationRepository = lecturerQualificationRepository;
            _lecturerCertificateRepository = lecturerCertificateRepository;
            _registrationSuggestionCourseRepository = registrationSuggestionCourseRepository;
            _lecturerUserRepository = lecturerUserRepository;
            _emailsLogRepository = emailsLogRepository;
            _userManager = userManager;
            _mapper = mapper;
            _mailSettings = mailSettings.Value;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> AddLecturer(AddLecturerCommand model)
        {
            var LM = _mapper.Map<Lecturer>(model);
            var trainer = await _userManager.FindByNameAsync(LM.Email1);
            if (trainer != null)
            {
                return "Email already exist";
            }
            LM.IsActive = false;
            LM.IsSuspend = false;
            LM.IsDeleted = false;

            var obj = UploadCv(model.CVFile);
            LM.OriginalUploadFileName = obj.Item1;
            LM.UploadFileName = obj.Item2;

            int serial = AddNewSerial();
            while (CheckSerial(serial) > 0)
            {
                serial = AddNewSerial();
            }
            LM.RegistrationCode = serial;

            string code = GetInvitationCode();
            while (CheckInvitationCode(code) > 0)
            {
                code = GetInvitationCode();
            }
            LM.InvitationCode = code.ToUpper();
            LM.RegistrationInvitationCode = "0";

            var lecturerId = await _lecturerRepository.Add(LM);

            string Password = NFN.RandomNumber(111111, 999999).ToString();
            string EncryptedPassword = EncryptionHelper.Encrypt(Password);

            LecturerUser LU = new LecturerUser();
            LU.LecturerId = lecturerId;
            LU.LecturerUserName = model.Email1;
            LU.LecturerUserPassword = EncryptedPassword;
            await _lecturerUserRepository.Add(LU);

            var user = new ApplicationUser { UserName = model.Email1, Email = model.Email1, LecturerId = lecturerId, EmailConfirmed = true };
            await _userManager.CreateAsync(user, Password);
            await _userManager.AddToRoleAsync(user, Roles.Trainer);

            SendEmails mail = new SendEmails(_mailSettings, _emailsLogRepository);
            mail.Send_RegistrationLecturer(LM);
            mail.Send_RegistrationPMP(LM);

            if (model.LecturerCertificateList != null)
            {
                List<LecturerCertificate> LC = new List<LecturerCertificate>();
                foreach (var item in model.LecturerCertificateList)
                {
                    LC.Add(new LecturerCertificate
                    {
                        CreationDate = DateTime.Now,
                        LecturerCertificateDate = item.LecturerCertificateDate,
                        LecturerCertificateImg = Convert.FromBase64String(item.LecturerCertificateImg_Base64),
                        LecturerCertificateTital = item.LecturerCertificateTital,
                        LecturerId = lecturerId,
                        RegistrationCode = item.RegistrationCode
                    });
                }
                await _lecturerCertificateRepository.AddRange(LC);
            }
            if (model.LecturerQualificationList != null) {
                List<LecturerQualification> LQ = new List<LecturerQualification>();
                foreach (var item in model.LecturerQualificationList)
                {
                    LQ.Add(new LecturerQualification
                    {
                        CountryOfGraduation = item.CountryOfGraduation,
                        GraduationYear = item.GraduationYear,
                        LecturerId = lecturerId,
                        MajorSpecialization = item.MajorSpecialization,
                        QualificationDefineId = item.QualificationDefineId,
                        RegistrationCode = item.RegistrationCode,
                        SecondarySpecialization = item.SecondarySpecialization,
                        TheUniversity = item.TheUniversity
                    });
                }
                await _lecturerQualificationRepository.AddRange(LQ);
            }
            if (model.LecturerInterestedCourseList != null) {
                List<LecturerInterestedCourse> LI = new List<LecturerInterestedCourse>();
                foreach (var item in model.LecturerInterestedCourseList)
                {
                    LI.Add(new LecturerInterestedCourse
                    {
                        CourseId = item.CourseId,
                        //FieldId = item.FieldId,
                        LecturerId = lecturerId,
                        Price = item.Price,
                        RegistrationCode = item.RegistrationCode
                        //SectorId = item.SectorId
                    });
                }
                await _lecturerInterestedCourseRepository.AddRange(LI);
            }
            if (model.RegistrationSuggestionCourseList != null)
            {
                List<RegistrationSuggestionCourse> RS = new List<RegistrationSuggestionCourse>();
                foreach (var item in model.RegistrationSuggestionCourseList)
                {
                    RS.Add(new RegistrationSuggestionCourse
                    {
                        CourseTxt = item.CourseTxt,
                        FieldId = item.FieldId,
                        LecturerId = lecturerId,
                        RegistrationCode = item.RegistrationCode,
                        SectorId = item.SectorId,
                        //SuggestionId = item.SuggestionId
                    });
                }
                await _registrationSuggestionCourseRepository.AddRange(RS);
            }
            return string.Empty;
        }

        private Tuple<string, string> UploadCv(IFormFile file)
        {
            string filename = Path.GetFileName(file.FileName);
            string Ex = Path.GetExtension(filename);

            string fname = NFN.RandomFileName();
            fname = fname + Path.GetExtension(filename);

            while (CheckFileSerial(fname))
            {
                fname = AddNewFileSerial();
                fname = fname + Ex;
            }

            string originalUploadFileName = file.FileName;
            string uploadFileName = fname;

            var path = Path.Combine(_hostEnvironment.ContentRootPath, "UploadedFiles/CVUploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            using (var fileStream = new FileStream(path + fname, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Tuple.Create(originalUploadFileName, uploadFileName);
        }

        private bool CheckFileSerial(string Serial)
        {
            string LCV = Path.Combine(_hostEnvironment.ContentRootPath, "UploadedFiles/CVUploads", Serial);
            if (System.IO.File.Exists(LCV))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AddNewFileSerial()
        {
            string Serial = NFN.RandomFileName();
            return Serial;
        }

        public async Task<bool> EditLecturer(EditLecturerCommand model)
        {
            var obj = _mapper.Map<Lecturer>(model);
            _lecturerRepository.Update(obj);
            await _lecturerRepository.SaveChangesAsync();

            if (model.LecturerCertificateList != null)
            {
                var currentList = _lecturerCertificateRepository.GetAll(s => s.LecturerId == obj.Id).ToList();
                var deletedItems = currentList.Where(s => model.LecturerCertificateList.All(x => x.Id != s.Id)).ToList();
                foreach (var interest in deletedItems)
                {
                    _lecturerCertificateRepository.Delete(interest);
                }

                var newItems = model.LecturerCertificateList.Where(x => x.Id == 0);
                List<LecturerCertificate> LC = new List<LecturerCertificate>();
                foreach (var item in newItems)
                {
                    LC.Add(new LecturerCertificate
                    {
                        CreationDate = DateTime.Now,
                        LecturerCertificateDate = item.LecturerCertificateDate,
                        LecturerCertificateImg = Convert.FromBase64String(item.LecturerCertificateImg_Base64),
                        LecturerCertificateTital = item.LecturerCertificateTital,
                        LecturerId = obj.Id,
                        RegistrationCode = item.RegistrationCode
                    });
                }
                await _lecturerCertificateRepository.AddRange(LC);
            }
            else
            {
                var currentItems = _lecturerCertificateRepository.GetAll(s => s.LecturerId == obj.Id);
                foreach (var interest in currentItems)
                {
                    _lecturerCertificateRepository.Delete(interest);
                }
                await _lecturerCertificateRepository.SaveChangesAsync();
            }

            if (model.LecturerQualificationList != null)
            {
                var currentList = _lecturerQualificationRepository.GetAll(s => s.LecturerId == obj.Id).ToList();
                var deletedItems = currentList.Where(s => model.LecturerQualificationList.All(x => x.Id != s.Id)).ToList();
                foreach (var interest in deletedItems)
                {
                    _lecturerQualificationRepository.Delete(interest);
                }

                var newItems = model.LecturerQualificationList.Where(x => x.Id == 0);
                List<LecturerQualification> LQ = new List<LecturerQualification>();
                foreach (var item in newItems)
                {
                    LQ.Add(new LecturerQualification
                    {
                        CountryOfGraduation = item.CountryOfGraduation,
                        GraduationYear = item.GraduationYear,
                        LecturerId = obj.Id,
                        MajorSpecialization = item.MajorSpecialization,
                        QualificationDefineId = item.QualificationDefineId,
                        RegistrationCode = item.RegistrationCode,
                        SecondarySpecialization = item.SecondarySpecialization,
                        TheUniversity = item.TheUniversity
                    });
                }
                await _lecturerQualificationRepository.AddRange(LQ);
            }
            else
            {
                var currentItems = _lecturerQualificationRepository.GetAll(s => s.LecturerId == obj.Id);
                foreach (var interest in currentItems)
                {
                    _lecturerQualificationRepository.Delete(interest);
                }
                await _lecturerQualificationRepository.SaveChangesAsync();
            }

            if (model.LecturerInterestedCourseList != null)
            {
                var currentList = _lecturerInterestedCourseRepository.GetAll(s => s.LecturerId == obj.Id).ToList();
                var deletedItems = currentList.Where(s => model.LecturerInterestedCourseList.All(x => x.Id != s.Id)).ToList();
                foreach (var interest in deletedItems)
                {
                    _lecturerInterestedCourseRepository.Delete(interest);
                }

                var newItems = model.LecturerInterestedCourseList.Where(x => x.Id == 0);
                List<LecturerInterestedCourse> LI = new List<LecturerInterestedCourse>();
                foreach (var item in newItems)
                {
                    LI.Add(new LecturerInterestedCourse
                    {
                        CourseId = item.CourseId,
                        //FieldId = item.FieldId,
                        LecturerId = obj.Id,
                        Price = item.Price,
                        RegistrationCode = item.RegistrationCode
                        //SectorId = item.SectorId
                    });
                }
                await _lecturerInterestedCourseRepository.AddRange(LI);

            }
            else
            {
                var currentItems = _lecturerInterestedCourseRepository.GetAll(s => s.LecturerId == obj.Id);
                foreach (var interest in currentItems)
                {
                    _lecturerInterestedCourseRepository.Delete(interest);
                }
                await _lecturerInterestedCourseRepository.SaveChangesAsync();
            }

            if (model.RegistrationSuggestionCourseList != null)
            {
                var currentList = _registrationSuggestionCourseRepository.GetAll(s => s.LecturerId == obj.Id).ToList();
                var deletedItems = currentList.Where(s => model.RegistrationSuggestionCourseList.All(x => x.Id != s.Id)).ToList();
                foreach (var interest in deletedItems)
                {
                    _registrationSuggestionCourseRepository.Delete(interest);
                }

                var newItems = model.RegistrationSuggestionCourseList.Where(x => x.Id == 0);
                List<RegistrationSuggestionCourse> RS = new List<RegistrationSuggestionCourse>();
                foreach (var item in newItems)
                {
                    RS.Add(new RegistrationSuggestionCourse
                    {
                        CourseTxt = item.CourseTxt,
                        FieldId = item.FieldId,
                        LecturerId = obj.Id,
                        RegistrationCode = item.RegistrationCode,
                        SectorId = item.SectorId,
                        //SuggestionId = item.SuggestionId
                    });
                }
                await _registrationSuggestionCourseRepository.AddRange(RS);
            }
            else
            {
                var currentItems = _registrationSuggestionCourseRepository.GetAll(s => s.LecturerId == obj.Id);
                foreach (var interest in currentItems)
                {
                    _registrationSuggestionCourseRepository.Delete(interest);
                }
                await _registrationSuggestionCourseRepository.SaveChangesAsync();
            }

            return true;
        }

        public async Task<Lecturer> ChangeLecturerStatus(ChangeLecturerStatusCommand model)
        {
            //var trainer = _mapper.Map<Trainer>(model);
            var trainer = _lecturerRepository.GetAll().FirstOrDefault(o => o.Id == model.Id);
            if (trainer != null)
            {
                if (model.isReactivate)
                {
                    trainer.IsActive = true;
                    trainer.IsSuspend = false;
                }
                else if (model.isDeactivate)
                {
                    trainer.IsActive = false;
                }
                if (_lecturerRepository.SaveChanges() <= 0)
                    throw new Exception("");
            }
            return trainer;
        }

        public async Task<bool> DeleteLecturer(DeleteLecturerCommand model)
        {
            var trainer = _lecturerRepository.GetAll().FirstOrDefault(o => o.Id == model.Id);
            if(trainer != null)
            {
                trainer.IsDeleted = true;
                if (_lecturerRepository.SaveChanges() <= 0)
                    throw new Exception("");
                return true;
            }
            return false;
        }

        private string GetInvitationCode()
        {
            return NFN.RandomFileName();
        }

        private int CheckInvitationCode(string code)
        {
            int count = _traineeRepository.GetAll(s => s.InvitationCode == code).Count();
            int count2 = _lecturerRepository.GetAll(s => s.InvitationCode == code).Count();
            int count3 = _organizationRepository.GetAll(s => s.InvitationCode == code).Count();
            int count4 = _providerRepository.GetAll(s => s.InvitationCode == code).Count();
            int TotalCount = count + count2 + count3 + count4;
            return TotalCount;
        }

        private int AddNewSerial()
        {
            return NFN.RandomNumber(10000, 99999);
        }

        public int CheckSerial(int Serial)
        {
            int LCT = _lecturerCertificateRepository.GetAll(x => x.RegistrationCode == Serial).Count();
            int LICT = _lecturerInterestedCourseRepository.GetAll(x => x.RegistrationCode == Serial).Count();
            int LQT = _lecturerQualificationRepository.GetAll(x => x.RegistrationCode == Serial).Count();
            int RSCT = _registrationSuggestionCourseRepository.GetAll(x => x.RegistrationCode == Serial).Count();
            int count = LCT + LICT + LQT + RSCT;
            return count;
        }

    }
}
