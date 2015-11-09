using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CheckRegisterMVC.Models;
using Newtonsoft.Json;

namespace CheckRegisterMVC.Controllers.WebAPI
{
    public class apiReceiptsController : ApiController
    {
        private ReceiptContext db = new ReceiptContext();

        // GET: api/apiReceipts
        public IQueryable<Receipt> GetReceipts()
        {
            return db.Receipts;
        }

        // GET: api/apiReceipts/5
        [ResponseType(typeof(Receipt))]
        public IHttpActionResult GetReceipt(int id)
        {
            //Receipt receipt = db.Receipts.Find(id);
            Receipt receipt = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault();
            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);
        }

        // PUT: api/apiReceipts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReceipt(int id, Receipt receipt)
        {
                       
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receipt.ID)
            {
                return BadRequest();
            }

            Receipt recToModify = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault();
            List<Category> categories = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault().Categories;
            List<Category> toDelete = new List<Category>();
            recToModify.AccountNumber = receipt.AccountNumber;
            recToModify.StoreName = receipt.StoreName;
            recToModify.Amount = receipt.Amount;
            recToModify.Approver = receipt.Approver;
            recToModify.TransactionDate = receipt.TransactionDate;
            recToModify.TransactionType = receipt.TransactionType;
            //recToModify.Categories = receipt.Categories;

            foreach (var oldC in categories)
            {

                if (receipt.Categories.Find(c => c.ID == oldC.ID) == null)
                    toDelete.Add(oldC);
                    
            }

            //Now remove them, cant remove from original while iterating
            foreach (var d in toDelete)
                db.Categories.Remove(d);

            foreach (var newC in receipt.Categories)
            {
                //If in DB but not new data, delete
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

            //receipt.Categories[0].Description = "None";
            //recToModify.ID = receipt.ID;
            //recToModify.StoreName = receipt.StoreName;

            //db.Entry(receipt).State = EntityState.Modified;

            //wouldn't want to blindly set for large objects, but for just one child it is ok
            //http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
            //var e = db.Entry(receipt);
            //e.Collection(p => p.Categories).EntityEntry = true;
            //db.Entry(receipt.Categories).State = EntityState.Modified;
            //db.Categories.AddOrUpdate()
            //AddOrUpdate(c => c.PK, new Person() { PK = 0, FirstName = "John", ... })
            //db.Categories.AddOrUpdate(c => c.ID, c => new Category(c.ID, c.Description, c.Amount));
            //db.Categories.AddOrUpdate(c => c.ID, receipt.Categories.ToArray());
            //db.Entry(receipt.Categories).State = EntityState.Modified;
            //db.Categories.Attach(receipt.Categories[0]);
            //db.Categories.det
            //db.Categories.Attach(receipt.Categories[1]);
            //db.Categories.Add(receipt.Categories[1]);
            try
            {
                db.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/apiReceipts
        [ResponseType(typeof(Receipt))]
        public IHttpActionResult PostReceipt(Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Receipts.Add(receipt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = receipt.ID }, receipt);
        }

        // DELETE: api/apiReceipts/5
        [ResponseType(typeof(Receipt))]
        public IHttpActionResult DeleteReceipt(int id)
        {
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return NotFound();
            }

            db.Receipts.Remove(receipt);
            db.SaveChanges();

            return Ok(receipt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReceiptExists(int id)
        {
            return db.Receipts.Count(e => e.ID == id) > 0;
        }
    }
}