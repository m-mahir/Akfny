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
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IRepository<Country, int> _repository;
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator, ILogger<CountryController> logger ,IRepository<Country, int> repository)
        {
            _mediator = mediator;
            _logger = logger;
            _repository = repository;
        }
        [EnableQuery(MaxExpansionDepth = 4)]
        [HttpGet]
        
        public IQueryable<Country> Get()
        {
            return _repository.GetAll();
        }
    }
}
