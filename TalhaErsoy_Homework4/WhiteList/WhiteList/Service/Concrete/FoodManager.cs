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
    public class FoodManager :IFoodService
    {
        private IFoodRepository _foodRepository;

        public FoodManager(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<IQueryable<Food>> GetAll()
        {
            return await _foodRepository.GetAll();
        }

        public async Task<Food> Get(int id)
        {
            return await _foodRepository.GetById(id);
        }

        public async Task<Food> Add(Food food)
        {
            return await _foodRepository.Add(food);
        }

        public async Task<Food> Update(Food food)
        {
            return await _foodRepository.Update(food);
        }

        public async Task<bool> Delete(Food food)
        {
            return await _foodRepository.Delete(food);
        }
    }
}
