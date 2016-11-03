using EMSc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMSc.Controllers
{
   
    enum AccessTypes { All, Create, Read, Update, Delete, option1, option2,option3 }
    public class AccountBasicController : Controller
    {
        private ItemsDataContext db = new ItemsDataContext();

        // GET: AccountBasic
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {

                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                var model = db.a_pageinfo.ToList();
                return View("Index", model);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult ListPagePolicies()
        {

            if (Session["User"] != null)
            {
               
                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                    var model = db.a_pageinfo.ToList(); 
                    return View("ListPagePolicies", model);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Details(int id) {
            if (Session["User"] != null)
            {

                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                var enums = Enum.GetNames(typeof(AccessTypes));
                ViewBag.AccessType = enums;
                var model = db.a_pageinfo.Where(c=>c.id==id);
                return View("Details" ,model);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Delete(int id) {
            if (Session["User"] != null)
            {

                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                a_pageinfoModel existing = db.a_pageinfo.Find(id);
                db.a_pageinfo.Remove(existing);
                db.SaveChanges();

                var model = db.a_pageinfo.ToList();
                return View("Index", model);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
            
        }
        public ActionResult Edit(int id) {

            if (Session["User"] != null)
            {
                var enums = Enum.GetNames(typeof(AccessTypes));
                ViewBag.AccessType = enums;
                ViewBag.SubVal = "Update";
                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                var model = db.a_pageinfo.Find(id);
                return View("create", model);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpPost]
        public ActionResult Update()
        {
            if (Session["User"] != null)
            {
                if (ModelState.IsValid)
                {
                    var model = new a_pageinfoModel();
                    
                    var db = new ItemsDataContext();
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    var enums = Enum.GetNames(typeof(AccessTypes));
                    var keys = Request.Form.AllKeys;

                    foreach (var i in enums)
                    {
                        dict.Add(i.ToString(), "0");
                    }
                    for (int i = 3; i < keys.Length; i++)
                    {
                        if (dict.ContainsKey(keys[i]))
                        {
                            dict[keys[i]] = "1";
                        }
                    }
                    string x = null;
                    foreach (var i in enums)
                    {
                        x += dict[i];
                    }
                    model.id = Convert.ToInt32(Request.Form.Get(keys[1]));
                    model.title = Request.Form.Get(keys[2]);
                    model.url = Request.Form.Get(keys[3]);
                    model.attribs = x;


                    //var upd = db.a_pageinfo.Find(c => c.id == model.id);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");

            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Create() {
            if (Session["User"] != null)
            {
                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                ViewBag.SubVal = "Create";
                var enums = Enum.GetNames(typeof(AccessTypes));
                ViewBag.AccessType = enums;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
           
        }
        [HttpPost]
        public ActionResult Create2()
        {
            if (Session["User"] != null)
            {
                if (ModelState.IsValid)
                    {
                    var model = new a_pageinfoModel();
                    var db = new ItemsDataContext();
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    var enums = Enum.GetNames(typeof(AccessTypes));
                    var keys = Request.Form.AllKeys;
                    
                    foreach (var i in enums)
                    {
                        dict.Add(i.ToString(), "0");
                    }
                    for (int i=3;i<keys.Length;i++) {
                        if (dict.ContainsKey(keys[i]))
                        {
                         dict[keys[i]] = "1";
                        } 
                    }
                    string x=null;
                    foreach (var i in enums)
                    {
                        x += dict[i];
                    }
                    model.title = Request.Form.Get(keys[2]);
                    model.url = Request.Form.Get(keys[3]);
                    model.attribs = x;
                    

                    db.a_pageinfo.Add(model);
                    db.SaveChanges();
                    //var pro = new Products();
                    //pro.Insert(prod);
                    return RedirectToAction("Index");
                    }
                return RedirectToAction("Create");
             
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

    }
}