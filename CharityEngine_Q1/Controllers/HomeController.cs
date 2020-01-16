using CharityEngine_Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityEngine_Q1.Controllers
{
    public class HomeController : Controller
    {
        // **************** SEARCH OR FETCH VEHICLES *********************
        public ActionResult Index()
        {
            VehicleModelHandler dbhandle = new VehicleModelHandler();
            ModelState.Clear();
            return View(dbhandle.GetVehicles());
        }

        // **************** ADD NEW VEHICLE *********************
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(VehicleModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleModelHandler dbhandle = new VehicleModelHandler();
                    if (dbhandle.AddOrUpdateVehicle(vehicleModel))
                    {
                        ViewBag.Message = "Vehicle Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}