
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IColorManager
    {
        Task<ColorModel> GetColorById(int id);

        Task<IEnumerable<ColorModel>> GetAllColors();

        /// <summary>
        /// Create or update color
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveColor(ColorModel model);

        Task<bool> DeleteColor(int id);
    }
}