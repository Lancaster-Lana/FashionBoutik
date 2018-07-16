
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface ICurrencyManager
    {
        Task<CurrencyModel> GetCurrencyById(int id);

        Task<IEnumerable<CurrencyModel>> GetAllCurrencies();

        Task<bool> SaveCurrency(CurrencyModel model);

        Task<bool> DeleteCurrency(int id);
    }
}