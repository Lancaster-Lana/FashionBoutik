using FashionBoutik.EF.DBModel;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class CurrencyRepository : Repository<Currency, int>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context)
        {
        }
    }
}