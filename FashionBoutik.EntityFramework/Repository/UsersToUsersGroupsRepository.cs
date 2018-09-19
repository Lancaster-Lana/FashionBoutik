using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionBoutik.Entities;
using Microsoft.EntityFrameworkCore;

namespace FashionBoutik.EntityFramework.Repository
{
    /// <summary>
    /// Repositoty to add\remove user to specific users GROUP
    /// </summary>
    public class UserToUsersGroupRepository : Repository<UserToUsersGroup>,  IUserToUsersGroupRepository
    {
        public UserToUsersGroupRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get user membership info
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<UserToUsersGroup> GetById(int userId, int groupId)
        {
            return await _entities.SingleOrDefaultAsync(s => s.UserId == userId && s.UsersGroupId == groupId);
        }

        /// <summary>
        /// Get all groups a user belongs to
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<UserToUsersGroup>> GetGroupsByUserId(int userId)
        {
            var entities = await GetAllIncluding("User", "UsersGroup");
            return entities.Where(s => s.UserId == userId).ToList();
        }


        public async virtual Task<bool> Delete(int userId, int groupId)
        {
            var entity = await GetById(userId, groupId);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return await Delete(entity);
        }
    }
}
