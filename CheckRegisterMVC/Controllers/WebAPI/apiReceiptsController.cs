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
using CheckRegisterMVC.Data;

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

            //idea from //http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
            //tried this but added everytime //db.Categories.AddOrUpdate(c => c.ID, receipt.Categories.ToArray());
            ReceiptRepository.copyChanges(id, receipt, ref db);
            

            //was
            //db.Entry(receipt).State = EntityState.Modified;
            
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