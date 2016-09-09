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
            about.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ullamcorper elementum turpis, " +
                                "sed sollicitudin est. Nunc tempor auctor lacus vel commodo. Integer justo eros, imperdiet sit amet" +
                                "sem sit amet, consequat iaculis ante. Pellentesque suscipit bibendum ipsum vitae mattis. Quisque molestie" +
                                "purus sed augue egestas, ut facilisis tortor malesuada. Quisque aliquam placerat libero quis rhoncus. " +
                                "Quisque ut ultrices mi. Sed id interdum tortor. Donec volutpat, augue nec elementum tincidunt, dolor enim" +
                                "maximus ex, id imperdiet diam magna in lacus. Nam gravida a turpis vel feugiat. Vivamus nulla mauris, " +
                                "hendrerit vitae elementum eu, luctus in massa. Praesent vel turpis facilisis, ultrices urna in, eleifend velit.";

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