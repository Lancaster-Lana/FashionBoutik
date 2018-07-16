using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IOrderManager
    {

        Task<OrderModel> GetOrderById(int id);

        Task<IEnumerable<OrderModel>> GetAllOrders();

        //Task CreateOrderAsync(int basketId, Address shippingAddress);

        /// <summary>
        /// Notify that order is completed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task MarkShipped(int id);

        /// <summary>
        /// Create or update order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<bool> SaveOrder(OrderModel order);

        Task<bool> DeleteOrder(int id);

        Task<decimal> CalculatePrice(IEnumerable<CartItem> lines);
    }
}
