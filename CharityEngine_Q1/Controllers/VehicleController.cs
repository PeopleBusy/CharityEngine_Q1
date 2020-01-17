using CharityEngine_Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityEngine_Q1.Controllers
{
    public class VehicleController : Controller
    {
        // **************** SEARCH OR FETCH VEHICLES *********************
        public ActionResult Index(FormCollection form)
        {          
            VehicleModelHandler dbhandle = new VehicleModelHandler();
            ViewBag.RegistrationNumber = 0;

            //Retrieving registration number entered in the search field
            var id = Convert.ToInt32(form["RegistrationNumber"]);
            if (id == 0) ModelState.Clear();
            else ViewBag.RegistrationNumber = id;

            //if id == 0 we return all vehicles
            //else we return the vehicle which id is provided
            return View(dbhandle.GetVehicles(id));
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

        // **************** EDIT/UPDATE VEHICLE *********************
        // GET: Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            VehicleModelHandler dbhandle = new VehicleModelHandler();
            return View(dbhandle.GetVehicles(id).FirstOrDefault());
        }

        // POST: Vehicle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleModelHandler dbhandle = new VehicleModelHandler();
                    if (dbhandle.AddOrUpdateVehicle(vehicleModel, id))
                    {
                        ViewBag.Message = "Vehicle Details Updated Successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}