using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckRegisterMVC;
using CheckRegisterMVC.Controllers;

namespace CheckRegisterMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexAPI()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.IndexAPI() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
    }
}
