using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckRegisterMVC.Models;

namespace CheckRegisterMVC.Data
{
    public class ReceiptRepository
    {
        public List<Receipt> GetReceipts()
        {
            List<Receipt> allReceipts = new List<Models.Receipt>();

            allReceipts.Add(new Receipt("55", DateTime.Parse("11/2/2015"), 1, "Best Buy", 5.56m, new List<Category> { new Category("Room", 5.59m) }, "Tom"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Pick n save", 56.99m, new List<Category> { new Category("Bread",9.99m) }, "Mike"));

            return allReceipts;

        }
    }
}