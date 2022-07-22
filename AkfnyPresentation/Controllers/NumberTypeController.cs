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
    public class NumberTypeController : ControllerBase
    {
        private readonly ILogger<NumberTypeController> _logger;
        private readonly IRepository<NumberType, int> _repository;
        private readonly IMediator _mediator;

        public NumberTypeController(IMediator mediator, ILogger<NumberTypeController> logger ,IRepository<NumberType, int> repository)
        {
            _mediator = mediator;
            _logger = logger;
            _repository = repository;
        }
        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        
        public IQueryable<NumberType> Get()
        {
            return _repository.GetAll();
        }
    }
}
