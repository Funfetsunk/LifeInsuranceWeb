using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LifeInsuranceWeb.Models
{
    public class CalculateModel
    {
        [Required(ErrorMessage="Date of birth required")]
        [Display(Name = "Date of birth?")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Postcode required")]
        [Display(Name = "Post code?")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Smoker details required")]
        [Display(Name = "Smoker?")]
        public string Smoker { get; set; }
        [Required(ErrorMessage = "Exercise details required")]
        [Display(Name = "Exercise per week?")]
        public int HoursOfExercise { get; set; }
        [Required(ErrorMessage = "Children details required")]
        [Display(Name = "Children?")]
        public string Children { get; set; }

        public double TotalPremium { get; set; }
    }
}