using Microsoft.AspNetCore.Mvc;

namespace FashionBoutik.Web.Controllers
{
    public class SportController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Sport clothes!";

            return View();
        }
    }
}
