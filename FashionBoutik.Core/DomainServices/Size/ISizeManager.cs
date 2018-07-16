
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface ISizeManager
    {
        Task<SizeModel> GetSizeById(int id);

        Task<IEnumerable<SizeModel>> GetAllSizes();

        /// <summary>
        /// Create or update size
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveSize(SizeModel model);

        Task<bool> DeleteSize(int id);
    }
}