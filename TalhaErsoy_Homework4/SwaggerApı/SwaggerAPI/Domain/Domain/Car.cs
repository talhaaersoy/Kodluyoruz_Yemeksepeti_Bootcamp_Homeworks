using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _4SwaggerAPI.Core.Entities;

namespace _4SwaggerAPI.Domain
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }  

    }
}
