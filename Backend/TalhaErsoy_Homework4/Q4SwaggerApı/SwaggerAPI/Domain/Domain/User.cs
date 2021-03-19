using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Core.Entities;

namespace _4SwaggerAPI.Domain
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
