using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS360.UsersMgt;
using EVS362.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EVS362.PropertyHub.WebUI.Controllers
{
    public class UsersController : Controller
    {
        //private readonly IHttpContextAccessor currentContext;

        //public UsersController(IHttpContextAccessor httpContextAccessor)
        //{
        //    currentContext = httpContextAccessor;
        //}


        [HttpGet]
        public IActionResult Login()
        {
            string temp = HttpContext.Request.Cookies["C262"];
            if (temp != null)
            {
                string[] loginData = temp.Split(',');
                User user = new UsersHandler().GetUser(loginData[0], loginData[1]);
                if (user != null)
                {
                    HttpContext.Session.Set(WebUtil.CURRENT_USER, user);
                    if (user.IsInRole(WebUtil.ADMIN))
                    {
                        return RedirectToAction("admin", "home");
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            User user = new UsersHandler().GetUser(model.LoginId, model.Password);
            if (user != null)
            {
                HttpContext.Session.Set(WebUtil.CURRENT_USER,   user);
                if (model.RemeberMe)
                {
                    HttpContext.Response.Cookies.Append(
                       "C262", //name
                        $"{user.LoginId},{user.Password}",  //value
                        new CookieOptions //options
                        {
                            IsEssential = true,
                            HttpOnly = true,
                            MaxAge = new TimeSpan(7, 0, 0, 0)
                        }
                   );
                }
                if(user.IsInRole(WebUtil.ADMIN))
                {
                    return RedirectToAction("admin", "home");
                }
                else
                {
                    return RedirectToAction("index", "home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            string temp = HttpContext.Request.Cookies["C262"];
            if (temp != null)
            {
                Response.Cookies.Delete("C262");
            }
            return RedirectToAction("login");
        }
    }
}