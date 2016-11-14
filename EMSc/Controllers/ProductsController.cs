using EMSc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMSc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View("Steps");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Steps() {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step1()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step2()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step3()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step4()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step5()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step6()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult Step7()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (a_UserAAModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }


    }
}