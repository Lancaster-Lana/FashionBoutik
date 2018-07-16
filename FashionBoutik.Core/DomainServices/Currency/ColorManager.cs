using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    public class ColorManager : DomainService, IColorManager
    {
        #region ctor

        private readonly IColorRepository _colorRepository;

        public ColorManager(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        #endregion

        #region implementation IColorManager

        public async Task<IEnumerable<ColorModel>> GetAllColors()
        {
            var entitiesList = await _colorRepository.GetAll();
            var model = entitiesList?.MapTo<ColorModel>();
            return model;
        }

        public async Task<ColorModel> GetColorById(int id)
        {
            var entity = await _colorRepository.GetById(id);
            var model = entity?.MapTo<ColorModel>();
            return model;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SaveColor(ColorModel model)
        {
            var entity = model.MapTo<ColorPallet>();
            if (model.Id < 1)
                await _colorRepository.Insert(entity);
            else
                await _colorRepository.Update(entity);

            return true;
        }

        public async Task<bool> DeleteColor(int id)
        {
            return await _colorRepository.Delete(id);
        }

        #endregion
    }
}