using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToEmit.Web.Models;
using ToEmit.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ToEmit.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManagement;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger,IAccountManager accountManagement)
        {

            _accountManagement = accountManagement;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult SignUp()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserModel userModel)
        {
            if(_accountManagement.UserAlreadyExist(userModel.UserName))
            {
                _logger.LogInformation("User tried to register with existing username {username}",userModel.UserName);
                ModelState.AddModelError("UserName", "User already exist");
            }
            else if(_accountManagement.EmailAlreadyInUse(userModel.EmailAddres))
            {
                _logger.LogInformation("User tried to register with existing email {email}", userModel.EmailAddres);
                ModelState.AddModelError("EmailAddres", "Email addres has already been used");
            }
            else
            {
                _accountManagement.AddUser(userModel.UserName, userModel.EmailAddres, userModel.Password);
                _logger.LogInformation("New user registered {user}", userModel.UserName);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            string user=User.Identity.Name.ToString();
            await HttpContext.SignOutAsync();
            _logger.LogInformation("User :{user} logged out", user);
            return Redirect("/");
        }
    }
}