using System;
using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) :  base (context)
        {
        }
    }
}