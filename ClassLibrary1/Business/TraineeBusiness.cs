using AkfnyData.Entities;
using AkfnyServices.Helper;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using AkfnyServices.Model;
using AutoMapper;
using CrossCutting.Identity;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkfnyServices.Business
{
    public interface ITraineeBusiness
    {
        Task<string> AddTrainee(AddTraineeCommand model);
        Task<bool> EditTrainee(EditTraineeCommand model);
        Task<Trainer> ChangeTraineeStatus(ChangeTraineeStatusCommand model);
        Task<bool> DeleteTrainee(DeleteTraineeCommand model);
    }
    public class TraineeBusiness : ITraineeBusiness
    {
        readonly private IRepository<Trainer, int> _traineeRepository;
        readonly private IRepository<TrainerUser, int> _trainerUserRepository;
        readonly private IRepository<TrainerInterested, int> _trainerInterestedRepository;
        readonly private IRepository<TrainerOtherInterestedCourse, int> _trainerOtherInterestedCourseRepository;
        readonly private IRepository<Lecturer, int> _lecturerRepository;
        readonly private IRepository<Organization, int> _organizationRepository;
        readonly private IRepository<Provider, int> _providerRepository;
        readonly private IRepository<EmailsLog, int> _emailsLogRepository;
        readonly private IRepository<TrainerInterestedCourse, int> _trainerInterestedCourseRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly MailSettings _mailSettings;
        
        public TraineeBusiness(IRepository<Trainer, int> traineeRepository, IRepository<Lecturer, int> lecturerRepository, IRepository<Organization, int> organizationRepository,
            IRepository<Provider, int> providerRepository, IRepository<TrainerUser, int> trainerUserRepository, UserManager<ApplicationUser> userManager,
            IRepository<TrainerInterested, int> trainerInterestedRepository, IRepository<TrainerOtherInterestedCourse, int> trainerOtherInterestedCourseRepository,
            IRepository<EmailsLog, int> emailsLogRepository, IRepository<TrainerInterestedCourse, int> trainerInterestedCourseRepository, IOptions<MailSettings> mailSettings, IMapper mapper)
        {
            _traineeRepository = traineeRepository;
            _lecturerRepository = lecturerRepository;
            _organizationRepository = organizationRepository;
            _providerRepository = providerRepository;
            _trainerUserRepository = trainerUserRepository;
            _trainerInterestedRepository = trainerInterestedRepository;
            _trainerOtherInterestedCourseRepository = trainerOtherInterestedCourseRepository;
            _emailsLogRepository = emailsLogRepository;
            _trainerInterestedCourseRepository = trainerInterestedCourseRepository;
            _userManager = userManager;
            _mapper = mapper;
            _mailSettings = mailSettings.Value;
        }

        public async Task<string> AddTrainee(AddTraineeCommand model)
        {
            var obj = _mapper.Map<Trainer>(model);
            var trainee = await _userManager.FindByNameAsync(obj.Email1);
            if (trainee != null)
            {
                return "Email already exist";
            }
            obj.RegistrationDate = DateTime.Now.AddHours(10).ToShortDateString();
            obj.RegistrationTime = DateTime.Now.AddHours(10).ToShortTimeString();
            obj.IsActive = true;
            obj.IsSuspend = false;
            obj.IsDeleted = false;
            obj.ProfileUpdate = true;
            obj.AddId = 0;
            obj.AddType = "SYS";

            int serial = AddNewSerial();
            while (CheckSerial(serial) > 0)
            {
                serial = AddNewSerial();
            }
            obj.RegistrationCode = serial;

            string code = GetInvitationCode();
            while (CheckInvitationCode(code) > 0)
            {
                code = GetInvitationCode();
            }

            obj.InvitationCode = code.ToUpper();
            obj.RegistrationInvitationCode = "0";

            var traineeId = await _traineeRepository.Add(obj);

            string Password = NFN.RandomNumber(111111, 999999).ToString();
            string EncryptedPassword = EncryptionHelper.Encrypt(Password);

            TrainerUser LU = new TrainerUser();
            LU.TrainerId = traineeId;
            LU.TrainerUserName = model.Email1;
            LU.TrainerUserPassword = EncryptedPassword;
            await _trainerUserRepository.Add(LU);

            var user = new ApplicationUser { UserName = model.Email1, Email = model.Email1, TrainerId = traineeId, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, Password);
            await _userManager.AddToRoleAsync(user, Roles.Trainee);

            SendEmails mail = new SendEmails(_mailSettings, _emailsLogRepository);
            mail.Send_RegistrationTrainer(obj, Password);
            mail.Send_RegistrationMarket(obj);

            List<TrainerInterested> LC = new List<TrainerInterested>();
            foreach (var item in model.InterestId)
            {
                LC.Add(new TrainerInterested
                {
                    MajorInterestId = int.Parse(item.Key),
                    SubInterestId = item.Value,
                    TrainerId = traineeId,
                    RegistrationCode = model.RegistrationCode
                });
            }
            await _trainerInterestedRepository.AddRange(LC);

            //List<TrainerOtherInterestedCourse> LLC = new List<TrainerOtherInterestedCourse>();
            //foreach (var item in model.TrainerOtherInterestedCourseList)
            //{
            //    LLC.Add(new TrainerOtherInterestedCourse
            //    {
            //        OtherField = item.OtherField,
            //        TrainerId = traineeId,
            //        RegistrationCode = item.RegistrationCode
            //    });
            //}
            //await _trainerOtherInterestedCourseRepository.AddRange(LLC);

            return string.Empty;
        }

        public async Task<bool> EditTrainee(EditTraineeCommand model)
        {
            var obj = _mapper.Map<Trainer>(model);
            _traineeRepository.Update(obj);
            await _traineeRepository.SaveChangesAsync();

            if (model.InterestId != null)
            {
                var currentInterests = _trainerInterestedRepository.GetAll(s => s.TrainerId == obj.Id).ToList();
                var deletedInterests = currentInterests.Where(s => model.InterestId.All(x => int.Parse(x.Key) != s.MajorInterestId && x.Value != s.SubInterestId)).ToList();
                foreach (var interest in deletedInterests)
                {
                    _trainerInterestedRepository.Delete(interest);
                }
                var newInterests = model.InterestId.Where(x => currentInterests.All(s => int.Parse(x.Key) != s.MajorInterestId && x.Value != s.SubInterestId));
                foreach (var dic in newInterests)
                {
                    await _trainerInterestedRepository.Add(new TrainerInterested { TrainerId = obj.Id, MajorInterestId = int.Parse(dic.Key), SubInterestId = dic.Value, RegistrationCode = model.RegistrationCode });
                };
                await _trainerInterestedRepository.SaveChangesAsync();
            }
            else
            {
                var currentInterests = _trainerInterestedRepository.GetAll(s => s.TrainerId == obj.Id);
                foreach (var interest in currentInterests)
                {
                    _trainerInterestedRepository.Delete(interest);
                }
                await _trainerInterestedRepository.SaveChangesAsync();
            }

            if (model.TrainerOtherInterestedCourseList != null)
            {
                var currentInterests = _trainerOtherInterestedCourseRepository.GetAll(s => s.TrainerId == obj.Id).ToList();
                var deletedInterests = currentInterests.Where(s => model.TrainerOtherInterestedCourseList.All(x => x.Id != s.Id)).ToList();
                foreach (var interest in deletedInterests)
                {
                    _trainerOtherInterestedCourseRepository.Delete(interest);
                }
                var newInterests = model.TrainerOtherInterestedCourseList.Where(x => x.Id == 0);
                List<TrainerOtherInterestedCourse> LLC = new List<TrainerOtherInterestedCourse>();
                foreach (var item in newInterests)
                {
                    LLC.Add(new TrainerOtherInterestedCourse
                    {
                        OtherField = item.OtherField,
                        TrainerId = obj.Id,
                        RegistrationCode = item.RegistrationCode
                    });
                }
                await _trainerOtherInterestedCourseRepository.AddRange(LLC);
            }
            else
            {
                var currentInterests = _trainerOtherInterestedCourseRepository.GetAll(s => s.TrainerId == obj.Id);
                foreach (var interest in currentInterests)
                {
                    _trainerOtherInterestedCourseRepository.Delete(interest);
                }
                await _trainerOtherInterestedCourseRepository.SaveChangesAsync();
            }

            return true;
        }

        public async Task<Trainer> ChangeTraineeStatus(ChangeTraineeStatusCommand model)
        {
            //var trainer = _mapper.Map<Trainer>(model);
            var trainee = _traineeRepository.GetAll().FirstOrDefault(o => o.Id == model.Id);
            if (trainee != null)
            {
                if (model.isReactivate)
                {
                    trainee.IsActive = true;
                    trainee.IsSuspend = false; 
                }
                else if (model.isDeactivate)
                {
                    trainee.IsActive = false;
                }
                if (_traineeRepository.SaveChanges() <= 0)
                    throw new Exception("");
            }
            return trainee;
        }

        public async Task<bool> DeleteTrainee(DeleteTraineeCommand model)
        {
            var trainee = _traineeRepository.GetAll().FirstOrDefault(o => o.Id == model.Id);
            if(trainee != null)
            {
                trainee.IsDeleted = true;
                if (_traineeRepository.SaveChanges() <= 0)
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
            int count = _traineeRepository.GetAll(s=> s.InvitationCode == code).Count();
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

        private int CheckSerial(int serial)
        {
            int count1 = _trainerInterestedCourseRepository.GetAll(x => x.RegistrationCode == serial).Count();
            int count2 = _trainerInterestedRepository.GetAll(x => x.RegistrationCode == serial).Count();
            int count = count1 + count2;
            return count;
        }
    }
}
