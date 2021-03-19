using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Domain.DTOs
{
    public class OrderResponse :IDto
    {
        public List<string> OrderDetail { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
