using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

        public static void copyChanges(int id, Receipt receipt, ref ReceiptContext db)
        {
            Receipt recToModify = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault();
            List<Category> categories = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault().Categories;

            List<Category> toDelete = new List<Category>();
            recToModify.AccountNumber = receipt.AccountNumber;
            recToModify.StoreName = receipt.StoreName;
            recToModify.Amount = receipt.Amount;
            recToModify.Approver = receipt.Approver;
            recToModify.TransactionDate = receipt.TransactionDate;
            recToModify.TransactionType = receipt.TransactionType;


            //If in DB but not new data, delete
            foreach (var oldC in categories)
            {
                if (receipt.Categories == null || receipt.Categories.Find(c => c.ID == oldC.ID) == null)
                    toDelete.Add(oldC);
            }

            //Now remove them, cant remove from original while iterating
            foreach (var d in toDelete)
                db.Categories.Remove(d);

            if (receipt.Categories != null)
            {
                foreach (var newC in receipt.Categories)
                {

                    var cToUpdate = categories.Find(c => c.ID == newC.ID);
                    if (cToUpdate != null)
                    {
                        cToUpdate.Amount = newC.Amount;
                        cToUpdate.Description = newC.Description;
                    }
                    else
                    {
                        categories.Add(newC);
                    }
                }
            }
           


        }

    }
}