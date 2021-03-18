using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Concrete;

namespace Service.Abstract
{
    public interface IOrderService
    {
        Task<IQueryable<Order>> GetAll();
        Task<Order> Get(int id);

        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task<bool> Delete(Order order);
    }
}
