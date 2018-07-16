using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.Entities;
using FashionBoutik.Models;
using FashionBoutik.DomainServices;
using FashionBoutik.Controllers;
using FashionBoutik.Core.Mappers;

namespace FashionBoutik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUsersGroupManager _userGroupManager;

        public UserController(UserManager<User> userManager, 
            RoleManager<Role> roleManager, 
            IUsersGroupManager userGroupManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userGroupManager = userGroupManager;
        }

        #region Methods

        [HttpGet]
        public IActionResult Index()
        {
            var model = new List<UserListViewModel>();
            model = _userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                Name = u.UserName, //TODO:
                UserName = u.UserName,
                Email = u.Email,
                //EmailConfirmed = u.EmailConfirmed,
                //RoleName = u.UsersRoles != null ? u.Role.Name : "",
                UsersGroupName = u.UsersGroup != null ? u.UsersGroup.Name : ""
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new UserViewModel
            {
                ApplicationRoles = _roleManager.Roles?.ToList(),
                UsersGroups = await _userGroupManager.GetAllUsersGroups()
            };
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = model.MapTo<User>();
                var user = new User
                {
                    NormalizedUserName = model.Name,
                    UserName = model.UserName,
                    Email = model.Email,  EmailConfirmed = false,
                    UsersGroupId = model.UsersGroupId,
                    //PhoneNumber = model.PhoneNumber,
                    //PasswordHash
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId.ToString());
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    var errorsList = string.Join(", ", result.Errors.Select(i => i.Description));
                    AddError(errorsList);
                }
            }
            return PartialView(model);//with errors
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = new EditUserViewModel();
            model.ApplicationRoles = _roleManager.Roles.ToList();
            model.UsersGroups = await _userGroupManager.GetAllUsersGroups();

            if (!String.IsNullOrEmpty(id))
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.Id = user.Id;
                    model.Name = user.UserName;
                    model.Email = user.Email;
                    model.UsersGroupId = user.UsersGroupId.HasValue ? user.UsersGroupId.Value : -1;//TODO: set user group

                    //TODO: selected user roles (TODO: to be selected as checkboxes)
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (userRoles.Any())
                        model.ApplicationRoleId = _roleManager.Roles.Single(r => r.Name == userRoles.FirstOrDefault()).Id;
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {
                    user.Name = user.UserName = model.Name;
                    user.Email = model.Email;
                    user.UsersGroupId = model.UsersGroupId; //Update users group

                    var existingUserRoles = await _userManager.GetRolesAsync(user);

                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        //Remove old user role
                        if (existingUserRoles.Any())
                        {
                            string existingRoleName = existingUserRoles.FirstOrDefault();
                            var existingRoleId = _roleManager.Roles.Single(r => r.Name == existingRoleName).Id;

                            if (existingRoleId != model.ApplicationRoleId)
                            {
                                IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRoleName);
                            }
                        }

                        //Update role of the user //if (roleResult.Succeeded)
                        var applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId.ToString());
                        if (applicationRole != null)
                        {
                            IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                            if (newRoleResult.Succeeded)
                            {
                                return RedirectToAction("Index");
                            }
                        }

                    }
                }
            }
            return View(model); //with errors
        }

        //[HttpPost]
        //public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _userManager.FindByIdAsync(id);
        //        if (user != null)
        //        {
        //            user.Name = model.Name;
        //            user.Email = model.Email;
        //            user.UsersGroupId = model.UsersGroupId;

        //            IdentityResult result = await _userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return PartialView(model);
        //}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //string name = string.Empty;
            if (id > 0)
            {
                User appUser = await _userManager.FindByIdAsync(id.ToString());
                if (appUser != null)
                {
                    var model = new UserViewModel
                    {
                        Id = appUser.Id,
                        Name = appUser.Name,
                        UserName = appUser.UserName,
                    };
                    return PartialView(model);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(UserViewModel model)
        {
            if (model.Id > 0)
            {
                User applicationUser = await _userManager.FindByIdAsync(model.Id.ToString());
                if (applicationUser != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            //Display view with errors
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                AddError("User id is empty");
                return View();
            }

            var applicationUser = await _userManager.FindByIdAsync(id);
            return PartialView("ConfirmDeleteUser", applicationUser);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(User user)
        {
            if (user != null)
            {

                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            AddError("Cannot delete empty user");
            return View();
        }

        #endregion
    }
}
