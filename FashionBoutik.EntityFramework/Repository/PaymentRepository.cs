using System;
using FashionBoutik.Data;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class PaymentRepository : Repository<Payment, int>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
    }
}