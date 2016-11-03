using EMSc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMSc.Controllers
{
    public class RistrictedAreaController : Controller
    {
        // GET: RistrictedArea
        public ActionResult Index()
        {
            
            if (Session["User"] != null)
            {
                ViewBag.user = (a_siteaccessModel)Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                return View();
            }
            else {
                return RedirectToAction("Login", "Auth");
            }
        }
    }
}