using Microsoft.AspNetCore.Mvc;

namespace FashionBoutik.Web.Controllers
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
