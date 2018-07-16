using Microsoft.AspNetCore.Mvc;

namespace FashionBoutik.Web.Controllers
{
    public class FurshetController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Furshet Style Builder!";

            return View();
        }
    }
}
