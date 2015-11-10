using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CheckRegisterMVC.Models;

//all code from http://www.asp.net/mvc/overview/getting-started/introduction/getting-started
//multiple context from here: http://www.codeproject.com/Tips/801628/Code-First-Migration-in-Multiple-DbContext
namespace CheckRegisterMVC.Controllers
{
    public class ReceiptsController : Controller
    {
        private IReceiptContext db = new ReceiptContext();

        public ReceiptsController() { }

        public ReceiptsController(IReceiptContext context)
        {
            db = context;
        }
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

            PopulateTransactionTypeDropDown(receipt.TransactionType);
            return View("CreateEdit", receipt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit([Bind(Include = "ID,AccountNumber,TransactionDate,TransactionType,StoreName,Amount,Approver, Rebates,Categories, Category.ID")] Receipt receipt)
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
                    //db.Entry(receipt).State = EntityState.Modified;
                    db.CopyChanges(receipt.ID, receipt);
                }

                //Validation errors should be caught and can be interrigated with 
                //((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateTransactionTypeDropDown(receipt.TransactionType);
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

        //http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
        private void PopulateTransactionTypeDropDown(int TransactionType)
        {
            List<TransactionType> allTT  = db.TransactionTypes.OrderBy(tt => tt.Ordinal).ToList();
            ViewBag.TransactionTypes = new SelectList(allTT, "ID", "Description", TransactionType);
        }
    }
}
