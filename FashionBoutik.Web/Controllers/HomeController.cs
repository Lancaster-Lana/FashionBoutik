using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.Entities;

namespace FashionBoutik.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;

        public HomeController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        //[Authorize(Roles = "Customer")]
        /// <summary>
        /// Display info page for current user (short details about shoppings, actions, future events) 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            string userName = userManager.GetUserName(User);
            return View("Index", userName);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
