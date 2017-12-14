using System.Web.Mvc;

namespace FashionBoutik.Controllers
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
