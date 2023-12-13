using _8_1_TripLog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _8_1_TripLog.Controllers
{
    public class HomeController : Controller
    {

        private TripsContext context { get; set; }
        public HomeController(TripsContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var trip = context.Trip.OrderBy(m => m.Destination).ToList();
            return View(trip);
        }

        [HttpGet]
        public IActionResult Destination()
        {
            TempData["message"] = "Add Trip And Destination Dates";
            ViewBag.Action = "Next";
            return View(new Trips());
        }
        [HttpPost]
        public IActionResult Destination(Trips trip)
        {
            TempData["dest"] = trip.Destination;
            TempData["dest1"] = trip.Destination;
            TempData["dest2"] = trip.Destination;
            TempData["acom"] = trip.Accommodation;
            TempData["start"] = trip.StartDate;
            TempData["end"] = trip.EndDate;


            if (trip.Destination != null && trip.Destination != "")
            {

                if (trip.Accommodation != null && trip.Accommodation != "")
                {
                    return RedirectToAction("Acomidations", "Home", trip);
                }
                else
                {
                    return RedirectToAction("Activities", "Home", trip);
                }
            }
            else
            {
                TempData["message"] = "Add Trip And Destination Dates";
                ViewBag.Action = "Next";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Acomidations(Trips trip)
        {
            ViewBag.Action = "Next";
            TempData["message"] = "Add Info for "+ trip.Accommodation;
            return View(trip);
        }
        [HttpPost]
        public IActionResult AcomidationsPost(Trips trip)
        {
            TempData["aphone"] = trip.AccommodationPhone;
            TempData["aemail"] = trip.AccommodationEmail;
            return RedirectToAction("Activities", "Home", trip);
        }

        [HttpGet]
        public IActionResult Activities(Trips trip)
        {
            ViewBag.Action = "Save";
            TempData["message"] = "Add Things To Do In " + TempData["dest1"];
            return View(trip);
        }

        [HttpPost]
        public IActionResult ActivitiesPost(Trips trip)
        {
            TempData["message"] = "Please Enter All Things To Do";
            if (trip.ThingToDo1 == null || trip.ThingToDo1 == "") return View("Activities");
            if (trip.ThingToDo2 == null || trip.ThingToDo2 == "") return View("Activities");
            if (trip.ThingToDo3 == null || trip.ThingToDo3 == "") return View("Activities");




            string dest = ""+TempData["dest"];

            Trips newTrip = new Trips {

                Destination = "" + TempData["dest"],
                StartDate = (DateTime)TempData["start"],
                EndDate = (DateTime)TempData["start"],
                ThingToDo1 = trip.ThingToDo1,
                ThingToDo2 = trip.ThingToDo2,
                ThingToDo3 = trip.ThingToDo3

            };

            if(TempData["acom"] != null && TempData["acom"] != "")
            {

                newTrip.Accommodation = "" + TempData["acom"];
                newTrip.AccommodationEmail = "" + TempData["aemail"];
                newTrip.AccommodationPhone = "" + TempData["aphone"];
            }
            context.Trip.Add(newTrip);
            context.SaveChanges();
            string message = "Trip to " + TempData["dest2"] + " Added.";
            TempData.Clear();
            TempData["message"] = message;
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Cancel()
        {

            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}