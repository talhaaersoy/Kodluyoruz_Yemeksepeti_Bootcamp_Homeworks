using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Context;
using Domain.Concrete;
using Domain.DTOs;

namespace WebAPI
{
    public static class MappingExtension
    {
        public static OrderResponse OrderMapping(this Order order)
        {
            List<string> names = new List<string>();
            List<decimal> prices = new List<decimal>();


            using (OrderContext context = new OrderContext())
            {
                decimal totalPrice = 0;
                var intList = order.FoodId.Trim('"').Split(",").Select(int.Parse).ToList();
                foreach (var id in intList)
                {

                    prices.Add(context.Foods.SingleOrDefault(p => p.Id == id).Price);
                    names.Add(context.Foods.SingleOrDefault(p => p.Id == id).Name);
                }
                
            }
            var result = prices.Sum();
            if (result > 50)
                result -= 10;
            return new OrderResponse { OrderDetail = names, TotalPrice = result };
        }
    }
}
