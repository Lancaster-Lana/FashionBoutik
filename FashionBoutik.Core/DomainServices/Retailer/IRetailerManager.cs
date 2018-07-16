
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IRetailerManager
    {
        Task<RetailerModel> GetRetailerById(int id);

        Task<IEnumerable<RetailerModel>> GetAllRetailers();

        /// <summary>
        /// Create or update 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveRetailer(RetailerModel model);

        Task<bool> DeleteRetailer(int id);
    }
}