using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CheckRegisterMVC.Models;

namespace CheckRegisterMVC.Tests.Models
{
    class ReceiptContextTest : IReceiptContext
    {
        public ReceiptContextTest()
        {
            this.Receipts = new ReceiptDbSetTest();
        }

        public DbSet<Receipt> Receipts { get; set; }
        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.CategoryOption> CategoryOptions { get; set; }

        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.TransactionType> TransactionTypes { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Receipt item) { }
        public void Dispose() { }

        public void CopyChanges(int i, Receipt r) { }

        public List<Receipt> GetReceipts()
        {
            List<Receipt> allReceipts = new List<Receipt>();

            allReceipts.Add(new Receipt("55", DateTime.Parse("11/2/2015"), 1, "Best Buy", 5.56m, new List<Category> { new Category("Room", 5.56m) }, "Tom"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Pick n save", 56.99m, new List<Category> { new Category("Bread", 56.99m) }, "Mike"));
            allReceipts.Add(new Receipt("55", DateTime.Parse("11/5/2015"), 1, "Citgo", 5.05m, new List<Category> { new Category("Car", 5.05m) }, "Mike"));
            return allReceipts;

        }

        public Receipt GetSingleReceipt()
        {
            Receipt r = new Receipt("55", DateTime.Parse("11/2/2015"), 1, "Best Buy", 5.56m, new List<Category> { new Category("Room", 5.56m) }, "Tom");
            r.ID = 3;
            return r;

        }

    }
}
