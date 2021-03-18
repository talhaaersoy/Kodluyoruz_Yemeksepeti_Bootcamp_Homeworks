using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using Microsoft.AspNetCore.Mvc;


namespace _4SwaggerAPI.Services.Abstract
{
    public interface IRentalService
    {
        Task<List<Rental>> GetAll();
        Task<Rental> GetById(int id);

        Task<Rental> Add(Rental rental);
        Task<Rental> Delete(Rental rental);
        Task<Rental> Update(Rental rental);
    }
}
