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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public async Task<List<Rental>> GetAll()
        {
            return await _rentalDal.GetAll();
        }

        public async Task<Rental> GetById(int id)
        {
            return await _rentalDal.Get(r =>r.Id == id);
        }

        public async Task<Rental> Add(Rental rental)
        {
            return await _rentalDal.Add(rental);
        }

        public async Task<Rental> Delete(Rental rental)
        {
            return await _rentalDal.Delete(rental);
        }

        public async Task<Rental> Update(Rental rental)
        {
            return await _rentalDal.Update(rental);
        }
    }
}
