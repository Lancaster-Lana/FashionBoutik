using FashionBoutik.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionBoutik.EntityFramework.Repository
{
    public interface IUserToUsersGroupRepository: IRepository<UserToUsersGroup>
    {
        Task<UserToUsersGroup> GetById(int userId, int groupId);

        Task<IList<UserToUsersGroup>> GetGroupsByUserId(int userId);

        Task<bool> Delete(int userId, int groupId);
    }
}
