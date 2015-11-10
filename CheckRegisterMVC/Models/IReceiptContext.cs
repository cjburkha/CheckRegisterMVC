using System;
using System.Linq;
using System.Data.Entity;

namespace CheckRegisterMVC.Models
{
    //From http://www.asp.net/web-api/overview/testing-and-debugging/mocking-entity-framework-when-unit-testing-aspnet-web-api-2
    interface IReceiptContext : IDisposable
    {

        int SaveChanges();
        void MarkAsModified(Receipt item);

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.Receipt> Receipts { get; set; }

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.Category> Categories { get; set; }

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.CategoryOption> CategoryOptions { get; set; }

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.TransactionType> TransactionTypes { get; set; }
    }
}
