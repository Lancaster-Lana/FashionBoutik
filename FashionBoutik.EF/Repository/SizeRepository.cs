using System;
using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class SizeRepository : Repository<Size, int>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}