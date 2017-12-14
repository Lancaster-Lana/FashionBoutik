using System.Web.Mvc;

namespace FashionBoutik.Controllers
{
    public class SeasonController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Season clothes";

            return View();
        }
    }
}
