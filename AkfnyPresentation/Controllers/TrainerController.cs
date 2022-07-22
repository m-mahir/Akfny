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
using AkfnyServices.MediatR.TrainerEntity.Commands;
using MediatR;
using Microsoft.AspNet.OData;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AkfnyPresentation.Controllers
{
    //[Authorize]
    public class TrainerController : ControllerBase
    {
        private readonly ILogger<TrainerController> _logger;
        private readonly IRepository<Lecturer, int> _lecturerRepository;
        readonly private IRepository<LecturerInterestedCourse, int> _lecturerInterestedCourseRepository;
        readonly private IRepository<LecturerQualification, int> _lecturerQualificationRepository;
        readonly private IRepository<LecturerCertificate, int> _lecturerCertificateRepository; 
        readonly private IRepository<RegistrationSuggestionCourse, int> _registrationSuggestionCourseRepository;
        readonly private IRepository<CourseProffer, int> _courseProfferRepository; 
        readonly private IRepository<SelectedLecturer, int> _selectedLecturerRepository; 
        readonly private IRepository<Provider, int> _providerRepository; 
        readonly private IRepository<CourseSuggestion, int> _courseSuggestionRepository;
        readonly private IRepository<DevelopCourse, int> _developCourseRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TrainerController(IMediator mediator, ILogger<TrainerController> logger ,IRepository<Lecturer, int> lecturerRepository, IRepository<LecturerInterestedCourse, int> lecturerInterestedCourseRepository, 
            IRepository<LecturerQualification, int> lecturerQualificationRepository, IRepository<LecturerCertificate, int> lecturerCertificateRepository, 
            IRepository<RegistrationSuggestionCourse, int> registrationSuggestionCourseRepository, IRepository<CourseProffer, int> courseProfferRepository,
            IRepository<SelectedLecturer, int> selectedLecturerRepository, IRepository<Provider, int> providerRepository, IRepository<CourseSuggestion, int> courseSuggestionRepository,
            IRepository<DevelopCourse, int> developCourseRepository, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _lecturerRepository = lecturerRepository;
            _lecturerInterestedCourseRepository = lecturerInterestedCourseRepository;
            _lecturerQualificationRepository = lecturerQualificationRepository;
            _lecturerCertificateRepository = lecturerCertificateRepository;
            _registrationSuggestionCourseRepository = registrationSuggestionCourseRepository;
            _courseProfferRepository = courseProfferRepository;
            _selectedLecturerRepository = selectedLecturerRepository;
            _providerRepository = providerRepository;
            _courseSuggestionRepository = courseSuggestionRepository;
            _developCourseRepository = developCourseRepository;
            _mapper = mapper;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]        
        public IQueryable<Lecturer> Get(int courseId)
        {
            if (courseId > 0)
                return _lecturerRepository.GetAll().Where(o => o.LecturerInterestedCourses.Count(e => e.CourseId == courseId)>0);
            return _lecturerRepository.GetAll();
        }

        [HttpGet]
        public EditLecturerCommand GetById(int id)
        {
            var obj = _mapper.Map<EditLecturerCommand>(_lecturerRepository.Get(id));
            obj.LecturerCertificateList = _mapper.Map<List<LecturerCertificateCommand>>(_lecturerCertificateRepository.GetAll(s => s.LecturerId == id).ToList());
            obj.LecturerInterestedCourseList = _lecturerInterestedCourseRepository.GetAll(s => s.LecturerId == id).ToList();
            obj.LecturerQualificationList = _lecturerQualificationRepository.GetAll(s => s.LecturerId == id).ToList();
            obj.RegistrationSuggestionCourseList = _registrationSuggestionCourseRepository.GetAll(s => s.LecturerId == id).ToList();

            return obj;
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<string> Add([FromForm] AddLecturerCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<bool> Edit([FromBody] EditLecturerCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("changeStatus")]
        public async Task<Lecturer> changeStatus([FromBody]ChangeLecturerStatusCommand model)
        {
            var trainer = await _mediator.Send(model);
            return trainer;
        }

        [HttpPost]
        [ActionName("delete")]
        public async Task<bool> delete([FromBody]DeleteLecturerCommand model)
        {
            var trainer = await _mediator.Send(model);
            return trainer;
        }

        public IActionResult GetSendCourseView(int trainerId)
        {
            List<CourseProffer> CourseProfferList;
            CourseProfferList = _courseProfferRepository.GetAll(x => x.PMPSubmit == false && x.CP == "CS" && x.CS_Finish == false && x.HasLec == true).ToList();
            SelectedLecturer SL = new SelectedLecturer();
            List<CourseProfferModelView> CourseProfferMV = new List<CourseProfferModelView>();

            foreach (var item in CourseProfferList)
            {
                int day = Convert.ToInt32(item.Course.Days);
                int hour = Convert.ToInt32(item.Course.Hour);
                string CreatDateTime = item.CreatDate + " - " + item.CreatTime;
                SL = _selectedLecturerRepository.GetFirst(x => x.CourseProfferId == item.Id && x.LecturerId == trainerId && x.Updated == false);
                if (SL != null)
                {
                    Provider p = _providerRepository.GetFirst(x => x.Id == item.PMPId);
                    CourseProfferMV.Add(new CourseProfferModelView
                    {
                        CourseId = item.CourseId,
                        ProviderName = p.Name,
                        PMPId = p.Id,
                        CourseTxt = item.Course.CourseTxt,
                        Days = day,
                        Hour = hour,
                        Status = item.ProfferStatu.Status,
                        CourseProfferId = item.Id,
                        CreatDateTime = CreatDateTime
                    });
                }
            }
            return Ok(CourseProfferMV);
        }

        public IActionResult GetSendCourseView2(int trainerId)
        {
            List<CourseProffer> CourseProfferList;
            CourseProfferList = _courseProfferRepository.GetAll(x => (x.CP == "CS" || x.CP == "CG") && x.CS_Finish == false && x.HasLec == true).ToList();
            SelectedLecturer SL = new SelectedLecturer();
            List<CourseProfferModelView> CourseProfferMV = new List<CourseProfferModelView>();

            foreach (var item in CourseProfferList)
            {
                int day = Convert.ToInt32(item.Course.Days);
                int hour = Convert.ToInt32(item.Course.Hour);
                string CreatDateTime = item.CreatDate + " - " + item.CreatTime;
                SL = _selectedLecturerRepository.GetFirst(x => x.CourseProfferId == item.Id && x.LecturerId == trainerId && x.Updated == true);
                if (SL != null)
                {
                    Provider p = _providerRepository.GetFirst(x => x.Id == item.PMPId);
                    CourseProfferMV.Add(new CourseProfferModelView
                    {
                        CourseId = item.CourseId,
                        ProviderName = p.Name,
                        PMPId = p.Id,
                        CourseTxt = item.Course.CourseTxt,
                        Days = day,
                        Hour = hour,
                        Status = item.ProfferStatu.Status,
                        CourseProfferId = item.Id,
                        CreatDateTime = CreatDateTime,
                        PMPSubmit = item.PMPSubmit,
                        FinanceSubmit = item.FinanceSubmit,
                        GMSubmit = item.GMSubmit,
                        selectedLect = SL.Selected
                    });
                }
            }
            return Ok(CourseProfferMV);
        }

        public IActionResult GetCoursePublicView(int trainerId)
        {
            List<CourseProffer> CourseProfferList;
            CourseProfferList = _courseProfferRepository.GetAll(x => x.PMPSubmit == false && x.CP == "CS" && x.LecturerId == null && x.CS_Finish == false && x.HasLec == false).ToList();

            List<CourseProfferModelView> CourseProfferMV = new List<CourseProfferModelView>();
            foreach (var item in CourseProfferList)
            {
                int day = Convert.ToInt32(item.Course.Days);
                int hour = Convert.ToInt32(item.Course.Hour);
                string CreatDateTime = item.CreatDate + " - " + item.CreatTime;
                Provider p = _providerRepository.GetFirst(x => x.Id == item.PMPId);
                SelectedLecturer sl = _selectedLecturerRepository.GetFirst(x => x.CourseProfferId == item.Id && x.LecturerId == trainerId);
                string status = "طلب جديد";
                if (sl != null)
                {
                    status = item.ProfferStatu.Status;
                }
                CourseProfferMV.Add(new CourseProfferModelView
                {
                    CourseId = item.CourseId,
                    ProviderName = p.Name,
                    PMPId = p.Id,
                    CourseTxt = item.Course.CourseTxt,
                    Days = day,
                    Hour = hour,
                    Status = status,
                    CourseProfferId = item.Id,
                    CreatDateTime = CreatDateTime
                });
            }

            return Ok(CourseProfferMV);
        }

        public IActionResult GetEmptyFields(int trainerId, int id)
        {
            List<LecturerInterestedCourse> LI = new List<LecturerInterestedCourse>();
            LI = _lecturerInterestedCourseRepository.GetAll(x => x.LecturerId == trainerId && x.Course.SectorId == id).ToList();
            List<Field> FieldListFinal = new List<Field>();
            int FieldId = 0;
            foreach (var item in LI)
            {
                FieldId = Convert.ToInt32(item.Course.FieldId);
                int exit = FieldListFinal.Where(x => x.Id == FieldId).Count();
                if (exit == 0)
                {
                    FieldListFinal.Add(new Field
                    {
                        Id = FieldId,
                        FieldTxt = item.Course.Field.FieldTxt
                    });
                }

            }
            return Ok(FieldListFinal);
        }

        public IActionResult GetCourseSuggestion(int trainerId, int fieldId, int statusId)
        {
            List<CourseSuggestion> CourseList;
            if (statusId != 0)
            {
                CourseList = _courseSuggestionRepository.GetAll(x => x.LecturerId == trainerId && x.FieldId == fieldId && x.StatusId == statusId).ToList();
            }
            else
            {
                CourseList = _courseSuggestionRepository.GetAll(x => x.LecturerId == trainerId && x.FieldId == fieldId).ToList();
            }
            return Ok(CourseList);
        }

        public IActionResult GetDevelopCourse(int trainerId, int statusId)
        {
            List<DevelopCourse> CourseList;
            if (statusId != 0)
            {
                CourseList = _developCourseRepository.GetAll(x => x.LecturerId == trainerId && x.ProfferStatuId == statusId).ToList();
            }
            else
            {
                CourseList = _developCourseRepository.GetAll(x => x.LecturerId == trainerId).ToList();
            }
            return Ok(CourseList);
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
