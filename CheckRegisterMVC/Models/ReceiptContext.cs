using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckRegisterMVC.Models
{
    public class ReceiptContext : DbContext, IReceiptContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ReceiptContext() : base("name=ReceiptContext")
        {
        }

        


        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.Receipt> Receipts { get; set; }

        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.CategoryOption> CategoryOptions { get; set; }

        public System.Data.Entity.DbSet<CheckRegisterMVC.Models.TransactionType> TransactionTypes { get; set; }

        public void CopyChanges(int id, Receipt receipt)
        {
            Receipt recToModify = this.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault();
            List<Category> categoriesForReceipt = this.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault().Categories;

            List<Category> toDelete = new List<Category>();
            recToModify.AccountNumber = receipt.AccountNumber;
            recToModify.StoreName = receipt.StoreName;
            recToModify.Amount = receipt.Amount;
            recToModify.Approver = receipt.Approver;
            recToModify.TransactionDate = receipt.TransactionDate;
            recToModify.TransactionType = receipt.TransactionType;


            //If in DB but not new data, delete
            foreach (var oldC in categoriesForReceipt)
            {
                if (receipt.Categories == null || receipt.Categories.Find(c => c.ID == oldC.ID) == null)
                    toDelete.Add(oldC);
            }

            //Now remove them, cant remove from original while iterating
            foreach (var d in toDelete)
                categoriesForReceipt.Remove(d);

            if (receipt.Categories != null)
            {
                foreach (var newC in receipt.Categories)
                {

                    var cToUpdate = categoriesForReceipt.Find(c => c.ID == newC.ID);
                    if (cToUpdate != null)
                    {
                        cToUpdate.Amount = newC.Amount;
                        cToUpdate.Description = newC.Description;
                    }
                    else
                    {
                        categoriesForReceipt.Add(newC);
                    }
                }
            }
        }

        public void MarkAsModified(Receipt item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
