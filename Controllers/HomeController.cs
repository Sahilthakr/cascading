using cascading.Data;
using cascading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace cascading.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context { get; }
        public HomeController(ApplicationDbContext _context)
        {
            this.Context = _context;
        }
     
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
        {
            CascadingModel model = new CascadingModel();
            model.Country = (from customer in this.Context.Country
                               select new SelectListItem
                               {
                                   Value = customer.CountryId.ToString(),
                                   Text = customer.CountryName
                               }).ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {
            CascadingModel model = new CascadingModel();
            switch (type)
            {
                case "ddlCountries":
                    model.State = (from customer in this.Context.State
                                    where customer.CountryId == value
                                    select new SelectListItem
                                    {
                                        Value = customer.StateId.ToString(),
                                        Text = customer.StateName
                                    }).ToList();
                    break;
                case "ddlStates":
                    model.City = (from customer in this.Context.City
                                    where customer.StateId == value
                                    select new SelectListItem
                                    {
                                        Value = customer.CityId.ToString(),
                                        Text = customer.CityName
                                    }).ToList();
                    break;
            }
            return Json(model);
        }

        [HttpPost]
        public ActionResult Index(int countryId, int stateId, int cityId)
        {
            CascadingModel model = new CascadingModel();
            model.Country = (from customer in this.Context.Country
                               select new SelectListItem
                               {
                                   Value = customer.CountryId.ToString(),
                                   Text = customer.CountryName
                               }).ToList();

            model.State= (from customer in this.Context.State
                            where customer.CountryId == countryId
                            select new SelectListItem
                            {
                                Value = customer.StateId.ToString(),
                                Text = customer.StateName
                            }).ToList();

            model.City = (from customer in this.Context.City
                            where customer.StateId == stateId
                            select new SelectListItem
                            {
                                Value = customer.CityId.ToString(),
                                Text = customer.CityName
                            }).ToList();

            return View(model);
        }

    }
}
