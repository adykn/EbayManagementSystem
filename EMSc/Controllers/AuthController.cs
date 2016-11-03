using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMSc.Models;
using System.Web.Security;
using System.Web.Configuration;

namespace EMSc.Controllers
{
    public class AuthController : Controller
    {
        private ItemsDataContext db = new ItemsDataContext();
        // GET: Auth
        
        public ActionResult Index()
        {

            a_siteaccessModel model = new a_siteaccessModel();
            if (Request.Cookies["Login"] != null)
            {
                model.email = Request.Cookies["Login"].Values["email"];
                model.password = Request.Cookies["Login"].Values["password"];
                model.apiToken = Request.Cookies["Login"].Values["Token"];
                return Login(model);
              }
            

            //FormsAuthentication.SignOut();
            //Session.Abandon();
            //HttpCookie cookie = new HttpCookie("Login");
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cookie);
            return RedirectToAction("Login", "Auth");


        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Exclude = "id,picfid,name,contact")]a_siteaccessModel loginDetails)
        {
            

            if (ModelState.IsValid)
            {

                var emp = db.a_siteaccess.ToList();
                var list = db.a_siteaccesslist;

                var LoginUser = emp.Where(a => a.email == loginDetails.email && a.password == loginDetails.password).FirstOrDefault();
                if (LoginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(loginDetails.email, loginDetails.RememberMe);
                    Session["User"] = LoginUser;
                    Session["timeStamp"] = DateTime.Now;
                    //Session["list"] = list.Find(LoginUser.id);
                    //var yourList1 = (a_siteaccessModel)Session["User"];
                    //var yourList2 = (a_siteaccesslistModel)Session["list"];

                    if (loginDetails.RememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Values.Add("email", LoginUser.email);
                        cookie.Values.Add("password", LoginUser.password);
                        cookie.Values.Add("Token", LoginUser.apiToken);
                        cookie.Expires = DateTime.Now.AddDays(14);
                        Response.Cookies.Add(cookie);

                    }
                    return RedirectToAction("index", "RistrictedArea");
                }else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }



            }

            return View(loginDetails);
        }
        public ActionResult Login() { return View(); }
        public ActionResult Logout() {

            FormsAuthentication.SignOut();
            Session.Abandon();
          
                HttpCookie cookie = new HttpCookie("Login");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);

            return RedirectToAction("index", "Auth");
        }

        public ActionResult PCC() { return View(); }
        [HttpPost]
        public ActionResult PCC([Bind(Exclude = "id,picfid,name,contact")]a_siteaccessModel loginDetails) {
            return View();
        }


    }
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                filterContext.Result = new RedirectResult("~/Auth/check");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}