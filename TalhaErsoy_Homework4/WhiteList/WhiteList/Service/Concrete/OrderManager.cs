using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abtract;
using Domain.Concrete;
using Service.Abstract;

namespace Service.Concrete
{
    public class OrderManager :IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IQueryable<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> Get(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<Order> Add(Order order)
        {
            return await _orderRepository.Add(order);
        }

        public async Task<Order> Update(Order order)
        {
            return await _orderRepository.Update(order);
        }

        public async Task<bool> Delete(Order order)
        {
            return await _orderRepository.Delete(order);
        }
    }
}
