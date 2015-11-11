using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckRegisterMVC.Models;
using System.Web.Http.Results;
using CheckRegisterMVC.Controllers;
using System.Web.Mvc;
using CheckRegisterMVC.Tests.Models;
using System.Collections.Generic;

namespace CheckRegisterMVC.Tests.Controllers
{
    [TestClass]
    public class ReceiptControllerTest
    {

        [TestMethod]
        public void Index()
        {
            var context = new ReceiptContextTest();
            // Arrange
            ReceiptsController controller = new ReceiptsController(context);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_ShouldReturnReceiptWithSameID()
        {
            //db context, inject into controller
            var context = new ReceiptContextTest();
            context.Receipts.Add(context.GetSingleReceipt());

            var controller = new ReceiptsController(context);
            var result = controller.Details(3) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, ((Receipt)result.Model).ID);

        }

        public void Edit_ShouldReturnUpdateReceipt()
        {
            //db context, inject into controller
            //Hard to test kind of testing database action.
            //Would have to move out CopyChanges and make it injectible

        }




    }
}
