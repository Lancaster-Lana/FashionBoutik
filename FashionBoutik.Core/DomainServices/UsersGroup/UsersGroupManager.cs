using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    /// <summary>
    /// Domain service to manage UsersGroup logic
    /// </summary>
    public class UsersGroupManager : DomainService, IUsersGroupManager
    {
        #region ctor

        private readonly IUsersGroupRepository _repository;

        public UsersGroupManager(IUsersGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<UsersGroupModel>> GetAllUsersGroups()
        {
            var list = (await _repository.GetAll())?.MapTo<UsersGroupModel>();
            return list.ToList();
        }
        public async Task<UsersGroupModel> GetUsersGroupById(int id)
        {
            var entity = await _repository.GetById(id);

            return entity?.MapTo<UsersGroupModel>();
        }

        public async Task<bool> DeleteUsersGroup(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> SaveUsersGroup(UsersGroupModel model)
        {
            var entity = model?.MapTo<UsersGroup>();
            if (model.Id < 1)
                //TODO: check if exist such name of users group
                await _repository.Insert(entity);
            else
                await _repository.Update(entity);

            return true;
        }

        #endregion


        /*
[HttpGet]
public IActionResult Index()
{
    var model = _db.UsersGroup.Select(gr => 
       new UserGroupListViewModel {
               Id = gr.Id,
               Name = gr.Name,
               Description = gr.Description,
               NumberOfUsers = gr.Users.Count()
       }
    ).ToList();

    return View(model);
}

/// <summary>
/// Start add\edit user group
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
[HttpGet("AddEditUsersGroup")]
public async Task<IActionResult> AddEditUsersGroup(int id)
{
    var model = new UserGroupViewModel();
    if (id > 0)
    {
        var usersGroup = _db.UsersGroup.FirstOrDefault( gr => gr.Id == id);
        if (usersGroup != null)
        {
            model.Id = usersGroup.Id;
            model.Name = usersGroup.Name;
            model.Description = usersGroup.Description;
        }
    }
    return PartialView(model);
}

/// <summary>
/// Save (create or update) a user group
/// </summary>
/// <param name="id"></param>
/// <param name="model"></param>
/// <returns></returns>
[HttpPost("AddEditUsersGroup")]
public async Task<IActionResult> AddEditUsersGroup(UserGroupViewModel model)
{
    if (ModelState.IsValid)
    {
        bool isExist = model.Id > 0;
        var usersGroup = isExist ? _db.UsersGroup.FirstOrDefault(gr => gr.Id == model.Id) :
                                    new FashionBoutik.Entities.UsersGroup
                                    {
                                        CreatedDate = DateTime.UtcNow
                                    };
        usersGroup.Name = model.Name;
        usersGroup.Description = model.Description;

        if (!isExist)
           await _db.UsersGroup.AddAsync(usersGroup);
        else
            _db.Entry<UsersGroup>(usersGroup).State =  Microsoft.EntityFrameworkCore.EntityState.Modified;

        var result =  await _db.SaveChangesAsync();

        if (result > 0)
        {
            return RedirectToAction("Index");
        }
    }
    return View(model);
}

[HttpGet("DeleteUsersGroup")]
public async Task<IActionResult> DeleteUsersGroup(int id)
{
    var usersGroup = _db.UsersGroup.FirstOrDefault(gr => gr.Id == id);

    if (usersGroup != null)
    {
        var model = new UserGroupViewModel
        {
            Id = usersGroup.Id,
            Name = usersGroup.Name
        };
        return PartialView(model);
    }
    return View("Index");
}

[HttpPost("DeleteUsersGroup")]
public async Task<IActionResult> DeleteUsersGroup(UserGroupViewModel model)
{
    if (model.Id > 0)
    {
        var uGroup =  _db.UsersGroup.FirstOrDefault(gr => gr.Id == model.Id);
        if (uGroup != null)
        {
            _db.UsersGroup.Remove(uGroup);
            await _db.SaveChangesAsync();

        }
    }
    //TODO: if ok ->
    return RedirectToAction("Index");
}

*/
    }
}