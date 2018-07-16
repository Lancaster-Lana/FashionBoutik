using Microsoft.AspNetCore.Mvc;

namespace FashionBoutik.Web.Controllers
{
    public class WeddingController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Wedding Style Builder!";

            return View();
        }
    }
}
