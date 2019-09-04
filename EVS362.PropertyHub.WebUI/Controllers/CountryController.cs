using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS360;
using EVS360.PropertyHub;
using EVS360.UsersMgt;
using EVS362.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS362.PropertyHub.WebUI.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet]
        public IActionResult addCountry()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });
            List<CountryModel> models = new LocationsHandler().GetCountries().ToModelList();
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });
              return PartialView("~/views/Country/Create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(CountryModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });

            new LocationsHandler().AddCountry(model.ToEntity());

            return RedirectToAction("addCountry");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });

            CountryModel model = new LocationsHandler().GetCountries(id).ToModel();
            List<SelectListItem> items = new LocationsHandler().GetCountries().ToSelectItemList();
            items.Find(x => Convert.ToInt32(x.Value) == model.id).Selected = true;
            ViewBag.Cities = items;
            return PartialView("~/views/Country/Edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(CountryModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });

            new LocationsHandler().UpdateCountry(model.id, model.ToEntity());
            return RedirectToAction("addCountry");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });

            CountryModel model = new LocationsHandler().GetCountries(id).ToModel();
            return PartialView("~/views/Country/delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(CountryModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Country", Action = "addCountry" });

            new LocationsHandler().DeleteCountry(model.id);
            return RedirectToAction("addCountry");
        }
    }
}