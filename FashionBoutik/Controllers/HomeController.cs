using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionBoutik.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to your Fashion Style Builder!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
