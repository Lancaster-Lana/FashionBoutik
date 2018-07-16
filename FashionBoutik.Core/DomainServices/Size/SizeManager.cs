using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    public class SizeManager : DomainService, ISizeManager
    {
        #region ctor

        private readonly ISizeRepository _repository;

        public SizeManager(ISizeRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region implementation ISizeManager

        public async Task<IEnumerable<SizeModel>> GetAllSizes()
        {
            var entitiesList = await _repository.GetAll();
            var model = entitiesList?.MapTo<SizeModel>();
            return model;
        }

        public async Task<SizeModel> GetSizeById(int id)
        {
            var entity = await _repository.GetById(id);
            var model = entity?.MapTo<SizeModel>();
            return model;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SaveSize(SizeModel model)
        {
            var entity = model.MapTo<Size>();
            if (model.Id < 1)
                await _repository.Insert(entity);
            else
                await _repository.Update(entity);

            return true;
        }

        public async Task<bool> DeleteSize(int id)
        {
            return await _repository.Delete(id);
        }

        #endregion
    }
}