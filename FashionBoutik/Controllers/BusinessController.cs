using System.Web.Mvc;

namespace FashionBoutik.Controllers
{
    public class BusinessController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Business Style Builder!";

            return View();
        }
    }
}
