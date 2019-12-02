using System.Threading.Tasks;
using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    /// <summary>
    /// Repository to create\remove users GROUP
    /// </summary>
    public class UsersGroupRepository : Repository<UsersGroup, int>, IUsersGroupRepository
    {
        public UsersGroupRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<UsersGroup> GetById(int userGroupId)
        {
            return await GetByIdIncluding(userGroupId, new[] { "Users" });
        }
    }
}
