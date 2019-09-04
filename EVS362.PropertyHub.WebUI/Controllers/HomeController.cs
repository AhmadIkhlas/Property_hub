using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EVS362.PropertyHub.WebUI;
using EVS360.UsersMgt;

namespace EVS362.PropertyHub.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Admin()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Home", Action = "Admin" });
            return View();
            
        }
    }
}