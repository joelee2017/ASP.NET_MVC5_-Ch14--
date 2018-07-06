using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Katalon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id, string password)
        {
            if(id == "joe" && password == "123")
            {
                //Redirect to index
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Message = "帳號或密碼有誤 !!";
                return View();
            }
            
        }
    }
}