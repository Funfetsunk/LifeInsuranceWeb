using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LifeInsuranceWeb.Models;
using LifeInsurance;

namespace LifeInsuranceWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            About about = new About();

            about.FirstName = "Tom";
            about.Surname = "Evans";
            about.Location = "Peterboough, UK";
            about.Description = "This is a test site for me to practice using MVC and Razor";
                                

            return View(about);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Calculate()
        {


            return View();
        }
        
        [HttpPost]
        public ActionResult Calculate(CalculateModel model)
        {
            var client = new Client();
            client.Age = LifeInsurance.Capture.CaptureAge(model.Age);
            client.Children = LifeInsurance.Capture.CaptureChildren(model.Children);
            client.Country = LifeInsurance.Postcode.LookupCountry(model.Country);
            client.Gender = LifeInsurance.Capture.CaptureGender(model.Gender);
            client.HoursOfExercise = LifeInsurance.Capture.CaptureExercise(model.HoursOfExercise);
            client.Smoker = LifeInsurance.Capture.CaptureSmoker(model.Smoker);

            model.TotalPremium = LifeInsurance.Calculation.CalculatePrice(client);

            return View(model);
        }


    }
}