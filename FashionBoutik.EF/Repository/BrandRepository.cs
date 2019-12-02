using System;
using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class BrandRepository : Repository<Brand, int>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}