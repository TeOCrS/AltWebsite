using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AltWebsite;
using AltWebsite.Controllers;

namespace AltWebsite.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            BookingsController controller = new BookingsController();

            // Act
            ViewResult result = controller.Bookings() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

       
    }
}
