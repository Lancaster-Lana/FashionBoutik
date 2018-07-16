
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IUsersGroupManager
    {

        Task<UsersGroupModel> GetUsersGroupById(int id);

        Task<IList<UsersGroupModel>> GetAllUsersGroups();

        
        Task<bool> SaveUsersGroup(UsersGroupModel model);

        Task<bool> DeleteUsersGroup(int id);
    }
}