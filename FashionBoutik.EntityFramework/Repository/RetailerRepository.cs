using System;
using FashionBoutik.Data;
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