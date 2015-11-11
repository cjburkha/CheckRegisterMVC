using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckRegisterMVC.Models;
using System.Web.Http.Results;
using CheckRegisterMVC.Controllers.WebAPI;
using CheckRegisterMVC.Tests.Models;


namespace CheckRegisterMVC.Tests.Controllers
{
    [TestClass]
    public class apiReceiptControllerTest
    {
        
        [TestMethod]
        public void GetProduct_ShouldReturnReceiptWithSameID()
        {
            //db context, inject into controller
            var context = new ReceiptContextTest();
            context.Receipts.Add(context.GetSingleReceipt());

            var controller = new apiReceiptsController(context);
            var result = controller.GetReceipt(3) as OkNegotiatedContentResult<Receipt>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.ID);

        }

       
    }
}
