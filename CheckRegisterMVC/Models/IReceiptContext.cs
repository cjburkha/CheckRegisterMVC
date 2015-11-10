using System;

namespace CheckRegisterMVC.Models
{
    //From http://www.asp.net/web-api/overview/testing-and-debugging/mocking-entity-framework-when-unit-testing-aspnet-web-api-2
    public interface IReceiptContext : IDisposable
    {

        int SaveChanges();
        void MarkAsModified(Receipt item);

        void CopyChanges(int id, Receipt receipt);

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.Receipt> Receipts { get; set; }

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.Category> Categories { get; set; }

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.CategoryOption> CategoryOptions { get; set; }

        System.Data.Entity.DbSet<CheckRegisterMVC.Models.TransactionType> TransactionTypes { get; set; }
    }
}
