using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckRegisterMVC.Models;
using System.Collections.Generic;

namespace CheckRegisterMVC.Tests.Controllers
{
    [TestClass]
    public class ReceiptControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }


        public List<Receipt> GetReceipts()
        {
            List<Receipt> allReceipts = new List<Models.Receipt>();

            allReceipts.Add(new Receipt("55", DateTime.Parse("11/2/2015"), 1, "Best Buy", 5.56m, new List<Category> { new Category("Room", 5.56m) }, "Tom"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Pick n save", 56.99m, new List<Category> { new Category("Bread", 56.99m) }, "Mike"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Citgo", 5.05m, new List<Category> { new Category("Car", 56.99m) }, "Mike"));
            return allReceipts;

        }
    }
}
