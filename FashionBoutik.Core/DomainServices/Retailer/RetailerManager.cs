using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    public class RetailerManager : DomainService, IRetailerManager
    {
        #region ctor

        private readonly IRetailerRepository _retailerRepository;

        public RetailerManager(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }

        #endregion

        #region implementation IRetailerManager

        public async Task<IEnumerable<RetailerModel>> GetAllRetailers()
        {
            var entitiesList = await _retailerRepository.GetAll();
            var model = entitiesList?.MapTo<RetailerModel>(); //used automapper (not old ModelMapper.Map(list)
            return model;
        }

        public async Task<RetailerModel> GetRetailerById(int id)
        {
            var entity = await _retailerRepository.GetById(id);
            var model = entity?.MapTo<RetailerModel>();
            return model;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SaveRetailer(RetailerModel model)
        {
            var entity = model?.MapTo<Retailer>();
            if (model.Id < 1)
                await _retailerRepository.Insert(entity);
            else
                await _retailerRepository.Update(entity);

            return true;
        }

        public async Task<bool> DeleteRetailer(int id)
        {
            return await _retailerRepository.Delete(id);
        }

        #endregion
    }
}