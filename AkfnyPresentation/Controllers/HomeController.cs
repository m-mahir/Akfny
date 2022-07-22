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
using Microsoft.AspNetCore.Identity;
using AkfnyData.Entities;
using CrossCutting.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Akfny.Data;

namespace AkfnyPresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<PMP, int> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager, 
            ILogger<HomeController> logger ,IRepository<PMP, int> repository)
        {
            _logger = logger;
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           //var PMs = _repository.GetAll().ToList();
          
           // foreach (var item in PMs)
           // {
           //     var user = new ApplicationUser { UserName = item.PMPUserName, Email = item.PMPUserName, PMPId = item.Id ,EmailConfirmed=true};
               
           //     await _userManager.CreateAsync(user, Encryption.OldDecrypt(item.PMPPassword));
           //    await _userManager.AddToRoleAsync(user, Roles.PM);
           // }
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
