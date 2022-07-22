using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AkfnyPresentation.Models;
using Repository;
using Data.Entities;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using MediatR;
using Microsoft.AspNet.OData;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AkfnyPresentation.Controllers
{
    //[Authorize]
    public class TraineeController : ControllerBase
    {
        private readonly ILogger<TraineeController> _logger;
        private readonly IRepository<Trainer, int> _trainerRepository;
        private readonly IRepository<TrainerInterested, int> _trainerInterestedRepository; 
        private readonly IRepository<TrainerOtherInterestedCourse, int> _trainerOtherInterestedCourseRepository;
        private readonly IRepository<CourseTargetedFinal, int> _courseTargetedFinalRepository; 
        private readonly IRepository<CourseProffer, int> _courseProfferRepository;
        private readonly IRepository<RegistrationCourseProffer, int> _registrationCourseProfferRepository;
        private readonly IRepository<TrineeCourseRequest, int> _trineeCourseRequestRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TraineeController(IMediator mediator, ILogger<TraineeController> logger, IRepository<Trainer, int> trainerRepository, IRepository<TrainerInterested, int> trainerInterestedRepository,
            IRepository<TrainerOtherInterestedCourse, int> trainerOtherInterestedCourseRepository, IRepository<CourseTargetedFinal, int> courseTargetedFinalRepository,
            IRepository<CourseProffer, int> courseProfferRepository, IRepository<RegistrationCourseProffer, int> registrationCourseProfferRepository,
            IRepository<TrineeCourseRequest, int> trineeCourseRequestRepository, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _trainerRepository = trainerRepository;
            _trainerInterestedRepository = trainerInterestedRepository;
            _trainerOtherInterestedCourseRepository = trainerOtherInterestedCourseRepository;
            _courseTargetedFinalRepository = courseTargetedFinalRepository;
            _courseProfferRepository = courseProfferRepository;
            _registrationCourseProfferRepository = registrationCourseProfferRepository;
            _trineeCourseRequestRepository = trineeCourseRequestRepository;
            _mapper = mapper;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        public IQueryable<Trainer> Get(int traineeId, int courseId, int majorInterestId, int subInterestId)
        {
            return _trainerRepository.GetAll().Where(o => (o.Id == traineeId || traineeId == 0) && 
            (o.TrainerInterestedCourses.Count(e => e.Id == courseId) > 0 || courseId == 0) &&
            (o.TrainerInteresteds.Count(e => e.MajorInterestId == majorInterestId) > 0 || majorInterestId == 0) &&
            (o.TrainerInteresteds.Count(e => e.SubInterestId == subInterestId) > 0 || subInterestId == 0));
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<string> Add([FromBody] AddTraineeCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<bool> Edit([FromBody] EditTraineeCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("changeStatus")]
        public async Task<Trainer> changeStatus([FromBody]ChangeTraineeStatusCommand model)
        {
            var trainee = await _mediator.Send(model);
            return trainee;
        }

        [HttpPost]
        [ActionName("delete")]
        public async Task<bool> delete([FromBody]DeleteTraineeCommand model)
        {
            var trainee = await _mediator.Send(model);
            return trainee;
        }

        [HttpGet]
        public IQueryable<SubInterest> GetSubIntersetByTraineeId(int traineeId)
        {
            return _trainerInterestedRepository.GetAll().Where(o => o.Id == traineeId).Select(s => s.SubInterest);
        }
        
        [HttpGet]
        public IActionResult GetCourseSchedule(int type, int traineeId)
        {
            Trainer trainee = _trainerRepository.GetFirst(x => x.Id == traineeId);
            DateTime todayDate = DateTime.Now.AddDays(-1);
            List<CourseTargetedFinal> CourseTF = new List<CourseTargetedFinal>();
            List<CourseProfferModelView> Fc = new List<CourseProfferModelView>();
            if (type == 0)
            {
                List<TrainerInterested> CourseTI = _trainerInterestedRepository.GetAll(x => x.TrainerId == traineeId).ToList();

                foreach (var item in CourseTI)
                {
                    List<CourseTargetedFinal> l = _courseTargetedFinalRepository.GetAll(x => x.SubInterestId == item.SubInterestId).ToList();
                    CourseTF.AddRange(l);
                }

                foreach (var item in CourseTF)
                {
                    var c = _courseProfferRepository.GetAll(x => x.CourseId == item.CourseId && x.CountryId == trainee.CountryId && x.SuggestedDate >= todayDate && x.PMPSubmit == true && (x.StatusId == 1 || x.StatusId == 2 || x.StatusId == 4)).Select(x => new CourseProfferModelView()
                    {
                        ProviderName = x.Provider.Name,
                        ProviderId = x.Provider.Id,
                        CityId = x.CityId,
                        CountryId = x.CountryId,
                        CityName = x.City.CityName,
                        CountryName = x.Country.CountryName,
                        CourseTxt = x.Course.CourseTxt,
                        CourseId = x.CourseId,
                        CourseProfferId = x.Id,
                        CreatDate = x.CreatDate,
                        CreatTime = x.CreatTime,
                        CurrencyId1 = x.CurrencyId,
                        CurrencyId2 = x.CurrencyId1,
                        FieldId = x.Course.FieldId,
                        FieldTxt = x.Course.Field.FieldTxt,
                        Hour2 = x.Course.Hour,
                        Days2 = x.Course.Days,
                        Price = x.Price,
                        PriceId = x.PriceId,
                        locId = x.locId,
                        Location = x.CoordinatorLocation.Building,
                        SuggestedDate2 = x.SuggestedDate,
                        PriceTrainer = x.PriceTrainer,
                    }).ToList();

                    Fc.AddRange(c);
                }
            }
            else
            {
                List<CourseTargetedFinal> l = _courseTargetedFinalRepository.GetAll(x => x.SubInterestId == type).ToList();

                foreach (var item in l)
                {
                    var c = _courseProfferRepository.GetAll(x => x.CourseId == item.CourseId && x.CountryId == trainee.CountryId && x.SuggestedDate >= todayDate && x.PMPSubmit == true && (x.StatusId == 1 || x.StatusId == 2 || x.StatusId == 4)).Select(x => new CourseProfferModelView
                    {

                        CityId = x.CityId,
                        ProviderName = x.Provider.Name,
                        ProviderId = x.Provider.Id,
                        CountryId = x.CountryId,
                        CityName = x.City.CityName,
                        CountryName = x.Country.CountryName,
                        CourseTxt = x.Course.CourseTxt,
                        CourseId = x.CourseId,
                        CourseProfferId = x.Id,
                        CreatDate = x.CreatDate,
                        CreatTime = x.CreatTime,
                        CurrencyId1 = x.CurrencyId,
                        CurrencyId2 = x.CurrencyId1,
                        //FieldId = x.FieldId,
                        FieldTxt = x.Course.Field.FieldTxt,
                        Hour2 = x.Course.Hour,
                        Days2 = x.Course.Days,
                        Price = x.Price,
                        PriceId = x.PriceId,
                        locId = x.locId,
                        Location = x.CoordinatorLocation.Building,
                        SuggestedDate2 = x.SuggestedDate,
                        PriceTrainer = x.PriceTrainer,
                    }).ToList();

                    Fc.AddRange(c);
                }
            }
            RegistrationCourseProffer RCP;
            if (Fc.Count > 0)
            {
                foreach (var item in Fc)
                {
                    RCP = _registrationCourseProfferRepository.GetFirst(x => x.TrainerId == traineeId && x.CourseProfferId == item.CourseProfferId);
                    if (RCP != null)
                    {
                        if (Convert.ToBoolean(RCP.IsPayment))
                        {
                            item.Payment = 1;
                        }
                        else
                        {
                            item.Payment = 0;
                        }
                    }
                    else
                    {
                        item.Payment = 3;
                    }
                }
            }
            return Ok(Fc);
        }

        public IActionResult GetCourseForPayment(int traineeId)
        {
            DateTime todayDate = DateTime.Now.AddDays(-1);
            Trainer trainee = _trainerRepository.GetFirst(x => x.Id == traineeId);

            List<CourseProfferModelView> FC = new List<CourseProfferModelView>();
            List<RegistrationCourseProffer> CourseTI = _registrationCourseProfferRepository.GetAll(x => x.TrainerId == traineeId && x.IsPayment == false).ToList();
            foreach (var item in CourseTI)
            {
                List<CourseProfferModelView> c = _courseProfferRepository.GetAll(x => x.Id == item.CourseProfferId && x.CountryId == trainee.CountryId && x.SuggestedDate >= todayDate && (x.StatusId == 1 || x.StatusId == 2 || x.StatusId == 4)).Select(x => new CourseProfferModelView
                {
                    CityId = x.CityId,
                    CountryId = x.CountryId,
                    CityName = x.City.CityName,
                    CountryName = x.Country.CountryName,
                    CourseTxt = x.Course.CourseTxt,
                    CourseId = x.CourseId,
                    CourseProfferId = x.Id,
                    CreatDate = x.CreatDate,
                    CreatTime = x.CreatTime,
                    CurrencyId1 = x.CurrencyId,
                    CurrencyId2 = x.CurrencyId1,
                    //FieldId = x.FieldId,
                    FieldTxt = x.Course.Field.FieldTxt,
                    Hour2 = x.Course.Hour,
                    Days2 = x.Course.Days,
                    Price = x.Price,
                    PriceId = x.PriceId,
                    locId = x.locId,
                    Location = x.CoordinatorLocation.Building,
                    SuggestedDate2 = x.SuggestedDate,
                    PriceTrainer = x.PriceTrainer,
                }).ToList();
                FC.AddRange(c);
            }

            //foreach (var item in FC)
            //{
            //    item.EncryptCourseProfferId = EncryptionHelper.Encrypt(Convert.ToString(item.CourseProfferId));
            //}

            return Ok(FC);
        }

        public IActionResult GetCoursesRegistered(int traineeId)
        {
            Trainer trainee = _trainerRepository.GetFirst(x => x.Id == traineeId);
            List<CourseProfferModelView> FC = new List<CourseProfferModelView>();
            List<RegistrationCourseProffer> CourseTI = _registrationCourseProfferRepository.GetAll(x => x.TrainerId == traineeId && x.IsPayment == true).ToList();
            foreach (var item in CourseTI)
            {
                List<CourseProfferModelView> c = _courseProfferRepository.GetAll(x => x.Id == item.CourseProfferId && x.CountryId == trainee.CountryId && (x.StatusId == 1 || x.StatusId == 2 || x.StatusId == 4)).Select(x => new CourseProfferModelView
                {
                    CityId = x.CityId,
                    CountryId = x.CountryId,
                    CityName = x.City.CityName,
                    CountryName = x.Country.CountryName,
                    CourseTxt = x.Course.CourseTxt,
                    CourseId = x.CourseId,
                    CourseProfferId = x.Id,
                    CreatDate = x.CreatDate,
                    CreatTime = x.CreatTime,
                    CurrencyId1 = x.CurrencyId,
                    CurrencyId2 = x.CurrencyId1,
                    //FieldId = x.FieldId,
                    FieldTxt = x.Course.Field.FieldTxt,
                    Hour2 = x.Course.Hour,
                    Days2 = x.Course.Days,
                    Price = x.Price,
                    PriceId = x.PriceId,
                    locId = x.locId,
                    Location = x.CoordinatorLocation.Building,
                    SuggestedDate2 = x.SuggestedDate,
                    PriceTrainer = x.PriceTrainer,
                }).ToList();
                FC.AddRange(c);
            }

            //foreach (var item in FC)
            //{
            //    item.EncryptCourseProfferId = EncryptionHelper.Encrypt(Convert.ToString(item.CourseProfferId));
            //}

            return Ok(FC);
        }

        public IActionResult GetCourseListByInterest(int type, int traineeId)
        {
            Trainer trainee = _trainerRepository.GetFirst(x => x.Id == traineeId);

            List<CourseTargetedFinal> l = _courseTargetedFinalRepository.GetAll(x => x.SubInterestId == type).ToList();
            List<Course> c = new List<Course>();
            foreach (var item in l)
            {
                c.Add(new Course { Id = item.Course.Id, CourseTxt = item.Course.CourseTxt });
            }

            return Ok(c);
        }

        public IActionResult GetCourseRequest(int traineeId)
        {
            Trainer trainee = _trainerRepository.GetFirst(x => x.Id == traineeId);
            List<TrineeCourseRequest> TR = _trineeCourseRequestRepository.GetAll(x => x.TrainerId == traineeId).ToList();

            return Ok(TR);
        }

        //public IActionResult Index()
        //{
        //   var x = _repository.GetAll().ToList();
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
