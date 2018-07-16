using System;
using System.Collections.Generic;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FashionBoutik.Core.Mappers;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    /// <summary>
    /// Ordering Domain service
    /// </summary>
    public class OrderManager : DomainService, IOrderManager
    {
        private IOrderRepository _repository;

        public OrderManager(IOrderRepository ctx)
        {
            _repository = ctx;
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            var entity = await _repository.GetById(id);
            var model = entity.MapTo<OrderModel>();

            return model;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            var list = (await _repository.GetAll())
                .Include(o => o.OrderItems)
                .Include(o => o.Payment);
            return list?.MapTo<OrderModel>();
        }

        public async Task MarkShipped(int id)
        {
            Order order = await _repository.GetById(id);
            if (order != null)
            {
                order.Delivered = true;
                //order.ShippingDate = DateTime.Now;
                //order.OrderStatus = OrderStatus.Completed;
                //TODO:
                await _repository.SaveChanges();
            }
        }

        //public async Task CreateOrderAsync(int basketId, Address shippingAddress)
        //{
        //    var basket = await _basketRepository.GetByIdAsync(basketId);
        //    Guard.Against.NullBasket(basketId, basket);
        //    var items = new List<CartItem>();
        //    foreach (var item in basket.Items)
        //    {
        //        //Read catalog items and add to real order
        //        var catalogItem = await _itemRepository.GetByIdAsync(item.CatalogItemId);
        //        var itemOrdered = new CatalogItemOrdered(catalogItem.Id, catalogItem.Name, catalogItem.PictureUri);
        //        var orderItem = new OrderItem(itemOrdered, item.UnitPrice, item.Quantity);
        //        items.Add(orderItem);
        //    }
        //    var order = new Order(basket.BuyerId, shippingAddress, items);

        //    await _orderRepository.AddAsync(order);
        //}


        public async Task<bool> SaveOrder(OrderModel model)
        {
            var entity = model.MapTo<Order>();
            if (entity.Id < 1)
            {
                await _repository.Insert(entity);

            }
            else
                await _repository.Update(entity);

            return true;
        }

        //[HttpPost]
        //public async Task<bool> SaveOrder(OrderModel order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        order.Shipped = false;
        //        order.Payment.Total = await CalculatePrice(order.Products);

        //        ProcessPayment(order.Payment);
        //        if (order.Payment.AuthCode != null)
        //        {
        //            await _repository.Insert(order);
        //            await _repository.SaveChanges();

        //            return Ok(order);
        //        }
        //        else
        //        {
        //            return BadRequest("Payment rejected");
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        public async Task<bool> DeleteOrder(int id)
        {
            return await _repository.Delete(id);
        }


        #region private methods

        /// <summary>
        /// TODO: different product may have price in different currencies, so there 
        /// should be a price calculator to convert to currency each product
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public async Task<decimal> CalculatePrice(IEnumerable<CartItem> lines)
        {
            var ids = lines.Select(l => l.ProductId);
            return lines.Sum(l => l.Quantity * l.Product.PricePerUnit.Value);
            //(await _repository.GetProducts() .Where(p => ids.Contains(p.ProductId))
            //.Select(p => lines.First(l => l.ProductId == p.ProductId).Quantity * p.Price)
            //.Sum();
        }

        private void ProcessPayment(Payment payment)
        {
            // integrate your payment system here
            //payment.AuthCode = "12345"; //TODO:
        }

        #endregion
    }
}
