using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using DataAccess.Abstract;

namespace _4SwaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalDal _rentalDal;

        public RentalsController(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rentals = await _rentalDal.GetAll();
            return Ok(rentals);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rental rental)
        {
            await _rentalDal.Add(rental);
            return Ok();
        }
    }
}
