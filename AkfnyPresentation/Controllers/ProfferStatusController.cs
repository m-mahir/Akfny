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
using Microsoft.AspNetCore.Authorization;

namespace AkfnyPresentation.Controllers
{
    //[Authorize]
    public class ProfferStatusController : ControllerBase
    {
        private readonly ILogger<ProfferStatusController> _logger;
        private readonly IRepository<ProfferStatu, int> _repository;
        private readonly IMediator _mediator;

        public ProfferStatusController(IMediator mediator, ILogger<ProfferStatusController> logger ,IRepository<ProfferStatu, int> repository)
        {
            _mediator = mediator;
            _logger = logger;
            _repository = repository;
        }

        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        public IQueryable<ProfferStatu> Get()
        {
            return _repository.GetAll();
        }

    }
}
