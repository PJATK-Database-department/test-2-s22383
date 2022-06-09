using System.Collections.Generic;

namespace Test2.Dto
{
    public class ClientDto
    {
        public int IdClient { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}