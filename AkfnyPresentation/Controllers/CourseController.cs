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
using AkfnyServices.MediatR.CourseEntity.Commands;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;

namespace AkfnyPresentation.Controllers
{
    //[Authorize]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IRepository<Course, int> _repository;
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator, ILogger<CourseController> logger ,IRepository<Course, int> repository)
        {
            _mediator = mediator;
            _logger = logger;
            _repository = repository;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        public IQueryable<Course> Get(int sectorId, int fieldId, int courseId)
        {
            return _repository.GetAll().Where(o => (o.SectorId == sectorId || sectorId == 0) && (o.FieldId == fieldId || fieldId == 0) 
            && (o.Id == courseId || courseId == 0));
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<bool> Add([FromBody] AddCourseCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<bool> Edit([FromBody] EditCourseCommand model)
        {
            return await _mediator.Send(model);
        }

        public IActionResult Index()
        {
           var x = _repository.GetAll().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
