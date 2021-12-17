using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToEmit.Application;
using ToEmit.Web.Models;

namespace ToEmit.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountManager _accountManagement;
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger,IAccountManager accountManagement)
        {
            _accountManagement = accountManagement;
            _logger = logger;
        }
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        private async Task Authenticate(string username, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "Authorization", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorize(LoginModel user)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            try
            {
                bool verify = _accountManagement.verifyUser(user.Login, user.Password);
                if (verify)
                {
                    string role = _accountManagement.getRole(user.Login);
                    string username = _accountManagement.getUsername(user.Login);
                    await Authenticate(username, role);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogWarning("Attempt to login with invalid login or password {usedLogin}, {usedPassword}", user.Login, user.Password);
                    TempData["Error"] = "Error. Username or Password is invalid";
                    return View("Login");
                }
               
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occured \n {error}", e);
                return View("Error");
            }
        }
    }
}