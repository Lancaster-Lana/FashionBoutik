using System.Web.Mvc;

namespace FashionBoutik.Controllers
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
