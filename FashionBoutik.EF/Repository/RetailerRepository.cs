using System;
using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class RetailerRepository : Repository<Retailer, int>, IRetailerRepository
    {
        public RetailerRepository(AppDbContext context) : base(context)
        {
        }
    }
}