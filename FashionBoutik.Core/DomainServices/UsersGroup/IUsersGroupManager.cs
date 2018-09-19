using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IUsersGroupManager
    {
        Task<IList<UsersGroupModel>> GetAllUsersGroups();

        /// <summary>
        /// Get specific group info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UsersGroupModel> GetUsersGroupById(int id);

        /// <summary>
        /// Get all groups the user belong to
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<int>> GetUserInGroups(int userId);

        Task<bool> SaveUsersGroup(UsersGroupModel model);

        /// <summary>
        /// Update (add\remove) groups user belongs to
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateUserGroups(int userId, IEnumerable<int> groupsIds);

        /// <summary>
        /// Delete all users relationships with this group 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUsersGroup(int id);
    }
}