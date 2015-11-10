using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CheckRegisterMVC.Models;

namespace CheckRegisterMVC.Tests.Models
{
    class TestReceiptContext : IReceiptContext
    {
        public TestReceiptContext()
        {
            this.Receipts = new TestReceiptDbSet();
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
        
    }
}
