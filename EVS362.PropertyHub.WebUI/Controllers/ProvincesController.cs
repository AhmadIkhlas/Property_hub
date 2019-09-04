using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS360;
using EVS360.UsersMgt;
using EVS362.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS362.PropertyHub.WebUI.Controllers
{
    public class ProvincesController : Controller
    {
        [HttpGet]
        public IActionResult addProvinces()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });
            List<ProvinceModel> models = new LocationsHandler().GetProvinces().ToModelList();
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "- Select Country -" } };
            items.AddRange(new LocationsHandler().GetCountries().ToSelectItemList());
            ViewBag.items = items;
            return PartialView("~/views/Provinces/_create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(ProvinceModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });
            new LocationsHandler().AddProvince(model.ToEntity());
            return RedirectToAction("addProvinces");
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });

            ProvinceModel model = new LocationsHandler().GetProvince(id).ToModel();
            List<SelectListItem> items = new LocationsHandler().GetCountries().ToSelectItemList();
            items.Find(x => Convert.ToInt32(x.Value) == model.Country.id).Selected = true;
            ViewBag.items = items;
            return PartialView("~/views/Provinces/_edit.cshtml", model);

          
        }

        [HttpPost]
        public IActionResult Edit(ProvinceModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });

            new LocationsHandler().UpdateProvince(model.Id, model.ToEntity());
            return RedirectToAction("addProvinces");
        }











        [HttpGet]
        public IActionResult Delete(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });



            ProvinceModel model = new LocationsHandler().GetProvince(id).ToModel();
            return PartialView("~/views/Provinces/_delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(ProvinceModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Provinces", Action = "addProvinces" });

            new LocationsHandler().DeleteProvince(model.Id);
            return RedirectToAction("addProvinces");
        }

    }
}