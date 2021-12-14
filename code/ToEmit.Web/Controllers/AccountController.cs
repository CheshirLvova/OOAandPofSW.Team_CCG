using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToEmit.Web.Models;
using ToEmit.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ToEmit.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManagement _accountManagement;
        public AccountController(IAccountManagement accountManagement)
        {
            _accountManagement = accountManagement;
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
        public IActionResult SignUp(UserModel userModel)
        {
            if(_accountManagement.UserAlreadyExist(userModel.UserName))
            {
                ModelState.AddModelError("UserName", "User already exist");
            }
            else if(_accountManagement.EmailAlreadyInUse(userModel.EmailAddres))
            {
                ModelState.AddModelError("EmailAddres", "Email addres has already been used");
            }
            else
            {
                _accountManagement.AddUser(userModel.UserName, userModel.EmailAddres, userModel.Password);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}