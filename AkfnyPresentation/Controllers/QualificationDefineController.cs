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
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;

namespace AkfnyPresentation.Controllers
{
    //[Authorize]
    public class QualificationDefineController : ControllerBase
    {
        private readonly ILogger<QualificationDefineController> _logger;
        private readonly IRepository<QualificationDefine, int> _repository;
        private readonly IMediator _mediator;

        public QualificationDefineController(IMediator mediator, ILogger<QualificationDefineController> logger ,IRepository<QualificationDefine, int> repository)
        {
            _mediator = mediator;
            _logger = logger;
            _repository = repository;
        }
        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        
        public IQueryable<QualificationDefine> Get()
        {
            return _repository.GetAll();
        }
    }
}
