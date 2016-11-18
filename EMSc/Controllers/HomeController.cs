using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using AdyknDll.MeNaNu;
using EMSc.Models;

namespace EMSc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var d = new getlistfrmFtp();
            //List<string> files = d.getFileList("ftp://speedtest.tele2.net/");
            //ViewBag.files = files;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Products()
        {
            var pr = new Products();
            //products.FillDS("Products","1=1", "*");
            //products.FillDT("Products", "1=1", "id, itemid, sku, Title, Quantity, ListingType");
            return View("Products",pr);
        }
        public ActionResult ListOfProducts()
        {
            var db = new _ItemsDataContext();
            var prod = db.Products;
            return View(prod);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //var db = new ItemsDataContext();
            //var prod = db.Products.ToArray();
            return View();
        }
        [HttpPost]
        //[Authorize]
        public ActionResult Create([Bind(Exclude = "ConditionID")]Models.Products prod)
        {
            if (ModelState.IsValid)
            {
                
                var db = new _ItemsDataContext();
                db.Products.Add(prod);
                db.SaveChanges();
                //var pro = new Products();
                //pro.Insert(prod);
                return RedirectToAction("Index");
            }

            return Create();
        }
    }
}