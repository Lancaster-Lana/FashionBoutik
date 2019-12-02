using System;
using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}