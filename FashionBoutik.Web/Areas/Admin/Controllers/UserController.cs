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
using Microsoft.EntityFrameworkCore;

namespace FashionBoutik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IUsersGroupManager _userGroupManager;
        private readonly UserManager<User> _userManager;

        private readonly ICachManager _cachManager;

        static IEnumerable<UsersGroupModel> _allUsersGroups;
        private async Task<IEnumerable<UsersGroupModel>> GetAllUsersGroups()
        {
            if (_allUsersGroups == null)
                _allUsersGroups = await _cachManager.GetAllUsersGroups();
            return _allUsersGroups;
        }

        public UserController(ICachManager cachManager,
            IUsersGroupManager userGroupManager,
            RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userGroupManager = userGroupManager;
            _cachManager = cachManager;
        }

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new List<UserListViewModel>();
            model = _userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                UserName = u.UserName, //Name = u.FirstName + " " + u.LastName,
                Email = u.Email,
                //EmailConfirmed = u.EmailConfirmed,
                //RoleName = u.UsersRoles != null ? u.Role.Name : "",
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new UserViewModel
            {
                ApplicationRoles = _roleManager.Roles?.ToList(),
                AllUsersGroups = await _cachManager.GetAllUsersGroups() //_userGroupManager.GetAllUsersGroups()
            };
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //1. check if user with such name exists
                var existingUser = await _userManager.FindByNameAsync(model.Name);
                if (existingUser != null)
                {
                    var errorsList = "The user with such name exists already";
                    AddError(errorsList);
                }
                else
                {
                    //Create a new user 
                    var user = new User
                    {
                        NormalizedUserName = model.Name,
                        UserName = model.UserName,
                        Email = model.Email,
                        EmailConfirmed = false,
                        //UsersGroups = (await GetAllUsersGroups()).Where(g => model.UsersGroupsIds.Contains(g.Id))?.MapTo<UsersGroup>(),
                        //PhoneNumber = model.PhoneNumber,
                        //PasswordHash
                    };
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //Add user to specific role
                        var applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId.ToString());
                        if (applicationRole != null)
                        {
                            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                            if (roleResult.Succeeded)
                            {
                                return RedirectToAction("Index");
                            }
                        }

                        //Update user groups (add user to some groups)
                        await _userGroupManager.UpdateUserGroups(user.Id, model.UsersGroupsIds);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var errorsList = string.Join(", ", result.Errors.Select(i => i.Description));
                        AddError(errorsList);
                    }
                }
            }
            return PartialView(model);//with errors
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new EditUserViewModel();
            model.AllAppRoles = _roleManager.Roles.MapTo<RoleViewModel>();
            model.AllUsersGroups = await GetAllUsersGroups();

            if (id > 0)
            {
                //await context.Entry(user).Reference(x => x.Address).LoadAsync();
                var user = await _userManager.Users.Include(x => x.UsersGroups)
                    .SingleAsync(x => x.Id == id);//_userManager.FindByIdAsync(id.ToString());
                if (user != null)
                {
                    model.Id = user.Id;
                    model.Name = user.UserName;
                    model.Email = user.Email;

                    //groups to which user belongs to
                    model.UsersGroupsIds = (await _userGroupManager.GetUserInGroups(user.Id));

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
                if (model.Id > 0)
                {
                    user.Name = user.UserName = model.Name;
                    user.Email = model.Email;

                    //1. Update users groups
                    await _userGroupManager.UpdateUserGroups(model.Id, model.UsersGroupsIds);

                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        //2. Update user role
                        var existingUserRoles = await _userManager.GetRolesAsync(user);
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
                        if (applicationRole != null && !await _userManager.IsInRoleAsync(user, applicationRole.Name))
                        {
                            IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                            if (newRoleResult.Succeeded)
                            {
                                return RedirectToAction("Index");
                            }
                        }

                        //Success - redirect to list of all users
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var errorsList = string.Join(", ", result.Errors.Select(i => i.Description));
                        AddError(errorsList);
                    }
                }
            }
            return View(model); //show current view with errors
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
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
                    return PartialView("ConfirmDelete", model);
                }
            }
            AddError("Cannot delete an empty user !");
            return View();
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
                    else
                    {
                        var errorsList = string.Join(", ", result.Errors.Select(i => i.Description));
                        AddError(errorsList);
                    }
                }
            }
            //Display view with errors
            return View();
        }

        #endregion
    }
}
