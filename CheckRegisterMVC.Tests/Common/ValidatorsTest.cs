using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using CheckRegisterMVC.Tests.Models;

namespace CheckRegisterMVC.Tests.Common
{
    [TestClass]
    public class ValidatorsTest
    {
        //http://stackoverflow.com/questions/5354894/how-do-i-invoke-a-validation-attribute-for-testing
        [TestMethod]
        public void Save_ShouldFailValidation()
        {
            //db context, inject into controller
            var context = new ReceiptContextTest();
            var receipttoValidate = context.GetSingleReceipt();
            receipttoValidate.Amount = 99;
            var result = Validator.TryValidateObject(receipttoValidate, new ValidationContext(receipttoValidate), null, true);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Save_ShouldPassValidation()
        {
            //db context, inject into controller
            var context = new ReceiptContextTest();
            var receipttoValidate = context.GetSingleReceipt();
            var result = Validator.TryValidateObject(receipttoValidate, new ValidationContext(receipttoValidate), null, true);
            Assert.IsTrue(result);
        }
    }
}
