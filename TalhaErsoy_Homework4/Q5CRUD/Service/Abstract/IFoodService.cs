using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Concrete;

namespace Service.Abstract
{
    public interface IFoodService
    {
        Task<IQueryable<Food>> GetAll();
        Task<Food> Get(int id);

        Task<Food> Add(Food food);
        Task<Food> Update(Food food);
        Task<bool> Delete(Food food);

    }
}
