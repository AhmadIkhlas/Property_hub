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
    public class CityController : Controller
    {
        [HttpGet]
        public IActionResult AddCities() {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });
            List <CityModel> models = new LocationsHandler().GetCities().ToModelList();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });

            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "- Select Provinces -" } };
            items.AddRange(new LocationsHandler().GetProvinces().ToSelectItemList());
            ViewBag.creat = items;
            return PartialView("~/views/City/_create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });

            new LocationsHandler().AddCity(model.ToEntity());
            return RedirectToAction("AddCities");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });
            CityModel model = new LocationsHandler().GetCities(id).ToModel();
            List<SelectListItem> items = new LocationsHandler().GetProvinces(new Country ()).ToSelectItemList();
            items.Find(x => Convert.ToInt32(x.Value) == model.Province.Id).Selected = true;
            ViewBag.items = items;
            return PartialView("~/views/city/_edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(CityModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });

            new LocationsHandler().UpdateCity(model.Id, model.ToEntity());
            return RedirectToAction("AddCities");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });

            CityModel model = new LocationsHandler().GetCities(id).ToModel();
            return PartialView("~/views/City/delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(CityModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "City", Action = "AddCities" });

            new LocationsHandler().DeleteCities(model.Id);
            return RedirectToAction("AddCities");
        }

    }
}