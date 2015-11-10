using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckRegisterMVC.Models;
using CheckRegisterMVC.Data;

//all code from http://www.asp.net/mvc/overview/getting-started/introduction/getting-started
namespace CheckRegisterMVC.Controllers
{
    public class ReceiptsController : Controller
    {
        private ReceiptContext db = new ReceiptContext();
        
        // GET: Receipts/IndexAPI
        public ActionResult IndexAPI()
        {
            return View();
        }

        // GET: Receipts
        public ActionResult Index()
        {
            return View(db.Receipts.ToList());
        }

        // GET: Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //To eager load categories. Can also include the where clause in SingleOrDefault
            Receipt receipt = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault();

            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/CreateEdit/5
        //Need to start both here so they return here. Kind of makes sense anyway
        //https://evolpin.wordpress.com/2011/05/09/mvc-and-posting-data-using-html-beginform-and-url-routing/
        public ActionResult CreateEdit(int? id)
        {
            Receipt receipt;
            if (id != null)
                 receipt = db.Receipts.Where(c => c.ID == id).Include("Categories").SingleOrDefault();
            else
                receipt = new Receipt();
            return View("CreateEdit", receipt);
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,AccountNumber,TransactionDate,TransactionType,StoreName,Amount,Approver,Rebates,Categories")] Receipt receipt)
        //{
        //    var c = receipt;
        //    if (ModelState.IsValid)
        //    {
        //        db.Receipts.Add(receipt);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View("CreateEdit", receipt);
        //}

        // GET: Receipts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Receipt receipt = db.Receipts.Find(id);
        //    if (receipt == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(receipt);
        //}

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,AccountNumber,TransactionDate,TransactionType,StoreName,Amount,Approver, Rebates,Categories")] Receipt receipt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(receipt).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(receipt);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "ID,AccountNumber,TransactionDate,TransactionType,StoreName,Amount,Approver, Rebates,Categories")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                if (receipt.ID == 0)
                {
                    //Create
                    db.Receipts.Add(receipt);
                }
                else
                {
                    //Edit
                    //should be tracking changes from prior
                    //db.Entry(receipt).State = EntityState.Modified;
                    ReceiptRepository.copyChanges(receipt.ID, receipt, ref db);
                }

                //Validation errors should be caught and can be interrigated with 
                //((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt receipt = db.Receipts.Find(id);
            db.Receipts.Remove(receipt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
