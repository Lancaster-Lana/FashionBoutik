using FashionBoutik.Data;
using FashionBoutik.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBoutik.EntityFramework.Repository
{
    public class UsersGroupRepository : Repository<UsersGroup, int>, IUsersGroupRepository
    {
        public UsersGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
