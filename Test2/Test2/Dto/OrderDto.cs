using System.Collections.Generic;
using Test2.Models;

namespace Test2.Dto
{
    public class OrderDto
    {
        public List<ConfectioneryOrderDto> Products { get; set; }
        public int TotalAmount { get; set; }
    }
}