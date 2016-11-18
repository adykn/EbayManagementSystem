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
        private _ItemsDataContext db = new _ItemsDataContext();
        public ActionResult Index()
        {
            
           if (Session["User"] != null)
            {
                ViewBag.User = Session["User"];
                ViewBag.timeStamp = Session["timeStamp"];
                //var Users = (List<a_UserRolesModel>)ViewBag.User;
                //var getlist = ViewBag.User as IEnumerable<EMSc.Models.a_UserRolesModel>;
                //var x = getlist.FirstOrDefault().SiteAccessUser.Name;

                //ViewBag.Tiles = 
                return View();
            }
            else {
                return RedirectToAction("index", "Auth");
            }
        }
    }
}