using AkfnyData.Entities;
using AkfnyPresentation.Helper;
using AkfnyPresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkfnyPresentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public AccountController(ILogger<AccountController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration config,
            ITokenService tokenService)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                    var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), model.UserName, role);
                    if (generatedToken != null)
                    {
                        return Ok(generatedToken);
                    }
                    else
                    {
                        await _signInManager.SignOutAsync();
                        return BadRequest();
                    }
                }
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RefreshToken(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userName, role);
            if (generatedToken != null)
                return Ok(generatedToken);
            else
                return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
