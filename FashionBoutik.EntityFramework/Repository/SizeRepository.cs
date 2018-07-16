using System;
using FashionBoutik.Data;
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