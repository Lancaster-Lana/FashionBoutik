using Microsoft.AspNetCore.Mvc;

namespace FashionBoutik.Web.Controllers
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
