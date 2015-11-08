using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckRegisterMVC.Models;
using CheckRegisterMVC.Data;

namespace CheckRegisterMVC.Controllers
{
    public class CheckController : Controller
    {
        
        // GET: Check
        public ActionResult Index()
        {
            List<Receipt> allReceipts = new ReceiptRepository().GetReceipts();
            ViewBag.Message = "Tom";
            ViewBag.checkPage = 5;
            return View(allReceipts);
        }

        public string Index2()
        {
            return "This is my default";
        }

        public string Add(int id = 0)
        {

            return "This is my Add working on id:" + id.ToString();
        }
    }
}