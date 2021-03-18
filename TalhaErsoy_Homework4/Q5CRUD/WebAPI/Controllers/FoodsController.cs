using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Concrete;
using Service.Abstract;
using WebAPI.FilterAttribute;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            var result = await _foodService.GetAll();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _foodService.Get(id);
            return Ok(result);
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] Food food)
        {
            await _foodService.Add(food);
            return Ok();
        }
        [HttpPost("update")]

        public async Task<IActionResult> Update([FromBody] Food food)
        {
            await _foodService.Update(food);
            return Ok();
        }
        [HttpPost("delete")]

        public async Task<IActionResult> Delete([FromBody] Food food)
        {
            await _foodService.Delete(food);
            return Ok();
        }
    }
}
