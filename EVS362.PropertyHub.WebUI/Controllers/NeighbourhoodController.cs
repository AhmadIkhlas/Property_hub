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
    public class NeighbourhoodController : Controller

    {
        [HttpGet]
        public IActionResult Manage()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });
            List<NeighborhoodModel> models = new PropertyAdvsHandler().GetNeighborhoods().ToModelList();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "- Select City -" } };
            items.AddRange(new LocationsHandler().GetCities(new Country { Id = 2 }).ToSelectItemList());
            ViewBag.Cities = items;
            return PartialView("~/views/neighbourhood/_create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(NeighborhoodModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });
            new PropertyAdvsHandler().AddNeighborhood(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });

            NeighborhoodModel model = new PropertyAdvsHandler().GetNeighborhood(id).ToModel();
            List<SelectListItem> items = new LocationsHandler().GetCities(new Country { Id = 2 }).ToSelectItemList();
            items.Find(x => Convert.ToInt32(x.Value) == model.City.Id).Selected = true;
            ViewBag.Cities = items;
            return PartialView("~/views/neighbourhood/_edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(NeighborhoodModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });
            new PropertyAdvsHandler().UpdateNeighborhood(model.Id, model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });
            NeighborhoodModel model = new PropertyAdvsHandler().GetNeighborhood(id).ToModel();
            return PartialView("~/views/neighbourhood/_delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(NeighborhoodModel model)
        {
            User currentUser = HttpContext.Session.Get<User>(WebUtil.CURRENT_USER);
            if (!(currentUser?.Role?.Id == WebUtil.ADMIN)) return RedirectToAction("login", "users", new { Controller = "Neighbourhood", Action = "Manage" });
            new PropertyAdvsHandler().DeleteNeighborhood(model.Id);
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Filter()
        {
            string key = Request.Query["key"];

            List<NeighborhoodModel> models = new PropertyAdvsHandler().GetNeighborhoods().ToModelList();

            var result = (from m in models
                          where m.Name.StartsWith(key)
                          select m).ToList();
            return PartialView("~/views/neighbourhood/_Filter.cshtml", result);
        }



    }
}