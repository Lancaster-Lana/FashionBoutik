using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.DomainServices;
using FashionBoutik.Entities;
using FashionBoutik.Models;
using FashionBoutik.Controllers;

namespace FashionBoutik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersGroupController : BaseController
    {
        private readonly IUsersGroupManager _manager;

        public UsersGroupController(IUsersGroupManager usersGroupManager)
        {
            _manager = usersGroupManager;
        }

        #region UI View actions

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _manager.GetAllUsersGroups();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int? id)
        {
            var model = id != null
                ? await _manager.GetUsersGroupById(id.Value)
                : new UsersGroupModel();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(UsersGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.SaveUsersGroup(model);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }
            //else 
            //AddErrors(ModelState);

            return View(model); //view with validation errors
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var usersGroup = await _manager.GetUsersGroupById(id);
                if (usersGroup != null)
                {
                    return PartialView(usersGroup);
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(UsersGroup model)
        {
            if (model.Id > 0)
            {
                var result = await _manager.DeleteUsersGroup(model.Id);
                if (result)
                {
                    return RedirectToAction("List");
                }

            }
            //Display view with errors
            return View();
        }

        #endregion
    }
}
