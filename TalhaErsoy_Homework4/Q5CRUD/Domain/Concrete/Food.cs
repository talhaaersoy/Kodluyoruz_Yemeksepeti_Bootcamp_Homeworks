using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Domain.Concrete
{
    public class Food :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  

    }
}
