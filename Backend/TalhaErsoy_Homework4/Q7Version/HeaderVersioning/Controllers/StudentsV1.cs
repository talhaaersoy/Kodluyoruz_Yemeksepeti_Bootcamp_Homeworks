using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q7Version.Controllers
{
    [Route("api/students")]
    [ApiVersion("1.0")]
    [ApiController]
  
    public class StudentsV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("students from v1 controller");
        }
    }
}
