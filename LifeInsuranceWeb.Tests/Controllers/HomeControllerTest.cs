using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeInsuranceWeb;
using LifeInsuranceWeb.Controllers;
using LifeInsurance;

namespace LifeInsuranceWeb.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestCalculation()
        {
            // Arrange
            Client client = new Client();
            client.Age = 31;
            client.Children = "N";
            client.Gender = "M";
            client.HoursOfExercise = 3;
            client.Smoker = "Y";
            client.Country = "England";

            // Act
            Double ExpectedPremium = 560.00;
            Double TotalPremium = LifeInsurance.Calculation.CalculatePrice(client);
            
            // Assert
            Assert.IsNotNull(TotalPremium);
            Assert.AreEqual(ExpectedPremium, TotalPremium);
        }
    }
}
