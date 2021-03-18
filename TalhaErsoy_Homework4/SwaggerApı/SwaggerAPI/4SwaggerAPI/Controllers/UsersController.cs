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
    public class UsersController : ControllerBase
    {
        private IUserDal _userDal;

        public UsersController(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userDal.GetAll();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _userDal.Add(user);
            return Ok();
        }
    }
}
