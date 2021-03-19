using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using _4SwaggerAPI.Services.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _4SwaggerAPI.Services.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public async Task<List<Car>> GetAll()
        {
            return await _carDal.GetAll();
        }

        public async Task<Car> GetById(int id)
        {
            return await _carDal.Get(c =>c.Id == id);
        }

        public async Task<Car> Add(Car car)
        {
           return await _carDal.Add(car);
            
        }

        public async Task<Car> Delete(Car car)
        {
            return await _carDal.Delete(car);
        }

        public async Task<Car> Update(Car car)
        {
            return await _carDal.Update(car);
        }
    }
}
