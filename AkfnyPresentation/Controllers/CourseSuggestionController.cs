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
using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;

namespace AkfnyPresentation.Controllers
{
    //[Authorize]
    public class CourseSuggestionController : Controller
    {
        private readonly ILogger<CourseSuggestionController> _logger;
        private readonly IRepository<CourseSuggestion, int> _repository;
        private readonly IMediator _mediator;

        public CourseSuggestionController(IMediator mediator, ILogger<CourseSuggestionController> logger ,IRepository<CourseSuggestion, int> repository)
        {
            _mediator = mediator;
            _logger = logger;
            _repository = repository;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        public IQueryable<CourseSuggestion> Get(int sectorId, int fieldId, int profferStatuId)
        {
            return _repository.GetAll().Where(o => (o.SectorId == sectorId || sectorId == 0) && (o.FieldId == fieldId || fieldId == 0) 
            && (o.ProfferStatuId == profferStatuId || profferStatuId == 0));
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<bool> Add([FromBody] AddCourseSuggestionCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<bool> Edit([FromBody] EditCourseSuggestionCommand model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        [ActionName("changeStatus")]
        public async Task<CourseSuggestion> changeStatus([FromBody] ChangeCourseSuggestionCommand model)
        {

            var courseSuggestion = await _mediator.Send(model);
            return courseSuggestion;
        }

        public IActionResult Index()
        {
           var x = _repository.GetAll().ToList();
            return View();
        }

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
