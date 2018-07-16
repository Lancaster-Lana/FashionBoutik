using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    public class CurrencyManager : DomainService, ICurrencyManager
    {
        #region ctor

        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyManager(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        #endregion

        #region implementation ICurrencyManager

        public async Task<IEnumerable<CurrencyModel>> GetAllCurrencies()
        {
            var entitiesList = await _currencyRepository.GetAll();
            var model = entitiesList?.MapTo<CurrencyModel>();
            return model;
        }

        public async Task<CurrencyModel> GetCurrencyById(int id)
        {
            var entity = await _currencyRepository.GetById(id);
            var model = entity?.MapTo<CurrencyModel>();
            return model;
        }

        public async Task<bool> SaveCurrency(CurrencyModel model)
        {
            var entity = model.MapTo<Currency>();
            if (model.Id < 1)
                await _currencyRepository.Insert(entity);
            else
                await _currencyRepository.Update(entity);

            return true;
        }

        public async Task<bool> DeleteCurrency(int id)
        {
            return await _currencyRepository.Delete(id);
        }

        #endregion
    }
}