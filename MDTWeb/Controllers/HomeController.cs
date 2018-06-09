using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDTWeb.Models;

namespace MDTWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            using (var db = new MyDbContext("Name=MDTDbConn"))
            {
             var user =   db.Users.FirstOrDefault(x => x.UserName == model.UserName && x.IsActive && !x.Deleted);
                if (user != null)
                  return  RedirectToAction("index", "Patient");
                else
                    return View();

            };
            
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
    }
}