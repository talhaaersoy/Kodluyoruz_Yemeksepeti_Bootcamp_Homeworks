using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace _4SwaggerAPI.Services.Abstract
{
    public interface ICarService
    {
        Task<List<Car>> GetAll();
        Task<Car> GetById(int id);
        Task<Car> Add(Car car);
        Task<Car> Delete(Car car);
        Task<Car> Update(Car car);
    }
}
