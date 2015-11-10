﻿using System;
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

        //[TestMethod]
        //public void Index()
        //{
        //    HomeController controller = new HomeController();


        //    return View(db.Receipts.ToList());
        //}

        public void Index()
        {
            // Arrange
            ReceiptsController controller = new ReceiptsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        //Refactor for Receipt controller
        //public void GetProduct_ShouldReturnProductWithSameID()
        //{
        //    //db context, inject into controller
        //    var context = new TestReceiptContext();
        //    context.Receipts.Add(GetSingleReceipt());

        //    var controller = new ReceiptsController(context);
        //    var result = controller.GetReceipt(3) as OkNegotiatedContentResult<Receipt>;

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(3, result.Content.ID);

        //}



        public List<Receipt> GetReceipts()
        {
            List<Receipt> allReceipts = new List<Receipt>();

            allReceipts.Add(new Receipt("55", DateTime.Parse("11/2/2015"), 1, "Best Buy", 5.56m, new List<Category> { new Category("Room", 5.56m) }, "Tom"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Pick n save", 56.99m, new List<Category> { new Category("Bread", 56.99m) }, "Mike"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Citgo", 5.05m, new List<Category> { new Category("Car", 5.05m) }, "Mike"));
            return allReceipts;

        }

        private Receipt GetSingleReceipt()
        {
            Receipt r = new Receipt("55", DateTime.Parse("11/2/2015"), 1, "Best Buy", 5.56m, new List<Category> { new Category("Room", 5.56m) }, "Tom");
            r.ID = 3;
            return r;

        }
    }
}
