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

            a_UserAAModel model = new a_UserAAModel();
            if (Request.Cookies["Login"] != null)
            {
                model.Email = Request.Cookies["Login"].Values["email"];
                model.Password = Request.Cookies["Login"].Values["password"];
                model.ApiToken = Request.Cookies["Login"].Values["Token"];
                return Login(model);
              }
                         return RedirectToAction("Login", "Auth");
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Exclude = "id,picfid,name,contact")]a_UserAAModel loginDetails)
        {
            

            if (ModelState.IsValid)
            {
                
                  var emp = db.UserAccessAccounts.ToList();
                 
                 
                
               

                var LoginUser = emp.Where(a => a.Email == loginDetails.Email && a.Password == loginDetails.Password).FirstOrDefault();
                if (LoginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(loginDetails.Email, loginDetails.RememberMe);
                    Session["User"] = LoginUser;
                    Session["timeStamp"] = DateTime.Now;
                    //Session["list"] = list.Find(LoginUser.id);
                    //var yourList1 = (a_siteaccessModel)Session["User"];
                    //var yourList2 = (a_siteaccesslistModel)Session["list"];

                    if (loginDetails.RememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Values.Add("email", LoginUser.Email);
                        cookie.Values.Add("password", LoginUser.Password);
                        cookie.Values.Add("Token", LoginUser.ApiToken);
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
        public ActionResult PCC([Bind(Exclude = "id,picfid,name,contact")]a_UserAAModel loginDetails) {
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