using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using _4SwaggerAPI.Services.Abstract;

namespace _4SwaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _carService.GetAll();
            return Ok(cars);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car car)
        {
            await _carService.Add(car);
            return Ok();
        }
    }
}
