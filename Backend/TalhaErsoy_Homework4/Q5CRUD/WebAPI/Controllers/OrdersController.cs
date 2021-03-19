using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Concrete;
using Service;
using Service.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            var result = await _orderService.GetAll();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderService.Get(id);
            return Ok(result);
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] Order order)
        {
            await _orderService.Add(order);
            return Ok(order.OrderMapping());
        }
        [HttpPost("update")]

        public async Task<IActionResult> Update([FromBody] Order order)
        {
            await _orderService.Update(order);
            return Ok();
        }
        [HttpPost("delete")]

        public async Task<IActionResult> Delete([FromBody] Order order)
        {
            await _orderService.Delete(order);
            return Ok();
        }
    }
}
