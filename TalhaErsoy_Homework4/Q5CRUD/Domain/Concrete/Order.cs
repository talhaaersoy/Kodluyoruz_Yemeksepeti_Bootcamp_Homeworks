using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Domain.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string FoodId { get; set; }
        public string OrderBy { get; set; }

    }
}
