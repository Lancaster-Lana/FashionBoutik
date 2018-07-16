using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.Models;
using FashionBoutik.Entities;
using FashionBoutik.Controllers;

namespace FashionBoutik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<Role> roleManager;

        public RoleController(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult List()
        {
            List<RoleListViewModel> model = new List<RoleListViewModel>();
            model = roleManager.Roles.Select(r => new RoleListViewModel
            {
                RoleName = r.Name,
                Id = r.Id,
                Description = r.Description,
                //NumberOfUsers = r.Users.Any() ? r.Users.Count() : 0
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(string id)
        {
            var model = new RoleViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                var applicationRole = await roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    model.Id = applicationRole.Id;
                    model.Name = applicationRole.Name;
                    model.Description = applicationRole.Description;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = model.Id > 0;//!String.IsNullOrEmpty(model.Id);
                var applicationRole = isExist ? await roleManager.FindByIdAsync(model.Id.ToString()) :
                                                new Role
                                                {
                                                    CreatedDate = DateTime.UtcNow
                                                };
                applicationRole.Name = model.Name;
                applicationRole.Description = model.Description;
                //applicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IdentityResult result = isExist ? await roleManager.UpdateAsync(applicationRole)
                                                : await roleManager.CreateAsync(applicationRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    var errorsList = string.Join(", \\r\\n", result.Errors.Select(i => i.Description));
                    AddError(errorsList);
                }
            }
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var role = await roleManager.FindByIdAsync(id);
                var model = new RoleViewModel { Name = role.Name, Id=role.Id };
                return PartialView("ConfirmDelete", model);
            }

            AddError("Cannot delete role is empty");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(RoleViewModel model)
        {
            if (model != null)
            {
                var role = await roleManager.FindByIdAsync(model.Id.ToString());
                var roleResult = await roleManager.DeleteAsync(role);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("List");
                }
            }
            AddError("Cannot delete role. Id is Empty");
            return View();
        }
    }
}
