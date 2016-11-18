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
        private _ItemsDataContext db = new _ItemsDataContext();
        // GET: Auth
        
        public ActionResult Index()
        {
             var emp1 = db.UserAccessAccounts.ToList();

            if (emp1.Count() == 0)
            {

                var emp = new a_UserAAModel();
                emp.Email = "4d.kh4n@gmail.com";
                emp.Name = "Adnan khan";
                emp.Password = "test";
                emp.Picfid = 0;
                emp.Contact = "03339323452";
                db.UserAccessAccounts.Add(emp);

                var Gh1 = new a_GroupHeadModel(); Gh1.Title = "Developer"; db.GroupHead.Add(Gh1);
                var Gh2 = new a_GroupHeadModel(); Gh2.Title = "Administration"; db.GroupHead.Add(Gh2);
                var Gh3 = new a_GroupHeadModel(); Gh3.Title = "DataEntryOperator"; db.GroupHead.Add(Gh3);
               
                var page = new a_PageDefinitionModel(); page.Title = "Products"; page.Url = "Products"; page.Attribs = "100"; db.PageDefinition.Add(page);
                var page1 = new a_PageDefinitionModel(); page1.Title = "Products2"; page1.Url = "Products"; page1.Attribs = "100"; db.PageDefinition.Add(page1);
                
                var x = new a_GroupPoliciesModel(); x.Attribs = "100"; x.GroupHead = Gh1; x.PageDefinition = page;db.GroupPolicies.Add(x);
               
                var role = new a_Roles(); role.SiteAccessUser = emp; role.GroupPolicy = x; db.UserRolePolicie.Add(role);

                db.SaveChanges();
                RedirectToAction("Logout", "Auth");
            }
             
           
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
                    var role = db.UserRolePolicie.ToList();
                 
                
               

                var LoginUser = emp.Where(a => a.Email == loginDetails.Email && a.Password == loginDetails.Password).FirstOrDefault();
                if (LoginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(loginDetails.Email, loginDetails.RememberMe);
                    var rsult=role.Where(x => x.SiteAccessUser.id == LoginUser.id);
                    if (rsult.Count() == 0) { ModelState.AddModelError("", "Login data is incorrect!"); return RedirectToAction("Login", "Auth"); }
                    Session["User"] = rsult;
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